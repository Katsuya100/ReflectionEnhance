using Katuusagi.ILPostProcessorCommon.Editor;
using Mono.Cecil;
using Mono.Cecil.Cil;
using Mono.Cecil.Rocks;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Unity.CompilationPipeline.Common.ILPostProcessing;
using UnityEngine.Scripting;

namespace Katuusagi.ReflectionEnhance.Editor
{
    internal class ReflectionEnhanceILPostProcessor : ILPostProcessor
    {
        public class TypeReferenceDictionaryPool<TKey, TValue> : ThreadStaticCollectionPool<Dictionary<TKey, TValue>, KeyValuePair<TKey, TValue>, TypeReferenceDictionaryPool<TKey, TValue>>
            where TKey : TypeReference
        {
            static TypeReferenceDictionaryPool()
            {
                _createInstance = () => new Dictionary<TKey, TValue>(TypeReferenceComparer.Default);
            }

            public static Handle Get(out Dictionary<TKey, TValue> result, IEnumerable<KeyValuePair<TKey, TValue>> init)
            {
                var ret = Get(out result);
                foreach (var e in init)
                {
                    result.Add(e.Key, e.Value);
                }
                return ret;
            }

            public static Dictionary<TKey, TValue> Get(IEnumerable<KeyValuePair<TKey, TValue>> init)
            {
                var result = Get();
                foreach (var e in init)
                {
                    result.Add(e.Key, e.Value);
                }
                return result;
            }
        }
        public static class TypeReferenceDictionaryPool
        {
            public static TypeReferenceDictionaryPool<TKey, TValue>.Handle Get<TKey, TValue>(out Dictionary<TKey, TValue> result)
            where TKey : TypeReference
            {
                return TypeReferenceDictionaryPool<TKey, TValue>.Get(out result);
            }

            public static Dictionary<TKey, TValue> Get<TKey, TValue>()
            where TKey : TypeReference
            {
                return TypeReferenceDictionaryPool<TKey, TValue>.Get();
            }

            public static TypeReferenceDictionaryPool<TKey, TValue>.Handle Get<TKey, TValue>(out Dictionary<TKey, TValue> result, IEnumerable<KeyValuePair<TKey, TValue>> init)
            where TKey : TypeReference
            {
                return TypeReferenceDictionaryPool<TKey, TValue>.Get(out result, init);
            }

            public static Dictionary<TKey, TValue> Get<TKey, TValue>(IEnumerable<KeyValuePair<TKey, TValue>> init)
            where TKey : TypeReference
            {
                return TypeReferenceDictionaryPool<TKey, TValue>.Get(init);
            }
        }

        private TypeReference _typeListType = null;
        private TypeReference _methodListType = null;
        private MethodReference _preserveAttributeConstructor = null;
        private MethodReference _getTypeFromHandle = null;
        private MethodReference _getMethodFromHandle = null;
        private MethodReference _getFieldFromHandle = null;
        private MethodReference _typeListAdd = null;
        private MethodReference _methodListAdd = null;
        private Instruction _constructor;
        private ICompiledAssembly _compiledAssembly;
        private AssemblyDefinition _assembly;

        public override ILPostProcessor GetInstance() => this;
        public override bool WillProcess(ICompiledAssembly compiledAssembly)
        {
            return true;
        }

        public override ILPostProcessResult Process(ICompiledAssembly compiledAssembly)
        {
            if (!WillProcess(compiledAssembly))
            {
                return null;
            }

            try
            {
                ILPPUtils.InitLog<ReflectionEnhanceILPostProcessor>(compiledAssembly);
                using (var assembly = ILPPUtils.LoadAssemblyDefinition(compiledAssembly))
                {
                    _assembly = assembly;
                    _compiledAssembly = compiledAssembly;
                    var module = assembly.MainModule;

                    _preserveAttributeConstructor = module.ImportReference(typeof(PreserveAttribute).GetConstructor(Type.EmptyTypes));
                    _getTypeFromHandle = module.ImportReference(typeof(Type).GetMethod(nameof(Type.GetTypeFromHandle)));
                    _typeListType = module.ImportReference(typeof(ConcurrentBag<Type>));
                    _typeListAdd = module.ImportReference(typeof(ConcurrentBag<Type>).GetMethod(nameof(ConcurrentBag<Type>.Add)));
                    _getMethodFromHandle = module.ImportReference(((Func<RuntimeMethodHandle, RuntimeTypeHandle, System.Reflection.MethodBase>)System.Reflection.MethodBase.GetMethodFromHandle).Method);
                    _methodListType = module.ImportReference(typeof(ConcurrentBag<System.Reflection.MethodBase>));
                    _methodListAdd = module.ImportReference(typeof(ConcurrentBag<System.Reflection.MethodBase>).GetMethod(nameof(ConcurrentBag<System.Reflection.MethodBase>.Add)));
                    _getFieldFromHandle = module.ImportReference(((Func<RuntimeFieldHandle, RuntimeTypeHandle, System.Reflection.FieldInfo>)System.Reflection.FieldInfo.GetFieldFromHandle).Method);

                    var collectorType = new TypeDefinition("Katuusagi.ReflectionEnhance.Generated", "$$Collector", TypeAttributes.Class | TypeAttributes.Public | TypeAttributes.Sealed | TypeAttributes.Abstract);
                    collectorType.BaseType = module.TypeSystem.Object;
                    if (compiledAssembly.Name == "Katuusagi.ReflectionEnhance.Collector")
                    {
                        using (ThreadStaticArrayPool.Get(out var types, compiledAssembly.References
                                                                        .Select(AssemblyDefinition.ReadAssembly)
                                                                        .SelectMany(v => v.Modules)
                                                                        .SelectMany(v => v.Types)))
                        {
                            CreateCollectUsingType(module, collectorType, types);
                        }
                    }
                    else
                    {
                        using (ThreadStaticArrayPool.Get(out var types, assembly.Modules.SelectMany(v => v.Types)))
                        {
                            CheckError(compiledAssembly, types);
                            CreateCollectUsingType(module, collectorType, types);
                            if (compiledAssembly.Defines.Contains("ENABLE_IL2CPP"))
                            {
                                CreateCollectStaticFields(module, types);
                                CreateCollectCreateInstance(module, types);
                            }
                        }
                    }

                    if (collectorType.Methods.Any())
                    {
                        module.Types.Add(collectorType);
                    }

                    if (compiledAssembly.References.Any(v => v.EndsWith("Katuusagi.ReflectionEnhance.dll")))
                    {
                        using (ThreadStaticArrayPool.Get(out var types, assembly.Modules.SelectMany(v => v.Types).GetAllTypes()))
                        {
                            foreach (var type in types)
                            {
                                if (!type.HasMethods)
                                {
                                    continue;
                                }

                                foreach (var method in type.Methods)
                                {
                                    var body = method.Body;
                                    if (body == null)
                                    {
                                        continue;
                                    }

                                    bool isChanged = false;
                                    var ilProcessor = body.GetILProcessor();
                                    var instructions = body.Instructions;
                                    for (var i = 0; i < instructions.Count; ++i)
                                    {
                                        var instruction = instructions[i];
                                        int diff = 0;
                                        isChanged = OptimizeCreateInstanceProcess(ilProcessor, method, instruction, ref diff) || isChanged;
                                        isChanged = OptimizeRETypeProcess(ilProcessor, method, instruction, ref diff) || isChanged;
                                        isChanged = TypeOfProcess(ilProcessor, method, instruction, ref diff) || isChanged;
                                        isChanged = FieldOfProcess(ilProcessor, method, instruction, ref diff) || isChanged;
                                        isChanged = MethodOfProcess(ilProcessor, method, instruction, ref diff) || isChanged;
                                        isChanged = ConstructorOfProcess(ilProcessor, method, instruction, ref diff) || isChanged;
                                        i += diff;
                                    }

                                    if (!isChanged)
                                    {
                                        continue;
                                    }

                                    ILPPUtils.ResolveInstructionOpCode(body.Instructions);
                                }
                            }
                        }
                    }

                    var pe  = new MemoryStream();
                    var pdb = new MemoryStream();
                    var writeParameter = new WriterParameters()
                    {
                        SymbolWriterProvider = new PortablePdbWriterProvider(),
                        SymbolStream         = pdb,
                        WriteSymbols         = true
                    };

                    assembly.Write(pe, writeParameter);
                    return new ILPostProcessResult(new InMemoryAssembly(pe.ToArray(), pdb.ToArray()), ILPPUtils.Logger.Messages);
                }
            }
            catch (Exception e)
            {
                ILPPUtils.LogException(e);
            }
            return new ILPostProcessResult(null, ILPPUtils.Logger.Messages);
        }

        private void CheckError(ICompiledAssembly assembly, IEnumerable<TypeDefinition> types)
        {
            if (assembly.Name == "Katuusagi.ReflectionEnhance")
            {
                return;
            }

            foreach (var type in types.GetAllTypes())
            {
                foreach (var i in type.Interfaces)
                {
                    if (ContainsSubstitution(i.InterfaceType))
                    {
                        ILPPUtils.LogError("REFLECTINENHANCE5001", "ReflectionEnhance failed.", $"\"{i.InterfaceType.Name}\" cannot be specified as a Interface.", type);
                    }
                }
                if (ContainsSubstitution(type.BaseType))
                {
                    ILPPUtils.LogError("REFLECTINENHANCE5002", "ReflectionEnhance failed.", $"\"{type.BaseType.Name}\" cannot be specified as a Base Type.", type);
                }
                foreach (var f in type.Fields)
                {
                    if (ContainsSubstitution(f.FieldType))
                    {
                        ILPPUtils.LogError("REFLECTINENHANCE5003", "ReflectionEnhance failed.", $"\"{f.FieldType.Name}\" cannot be defined as a Field.", f);
                    }
                }
                foreach (var p in type.Properties)
                {
                    if (ContainsSubstitution(p.PropertyType))
                    {
                        ILPPUtils.LogError("REFLECTINENHANCE5004", "ReflectionEnhance failed.", $"\"{p.PropertyType.Name}\" cannot be defined as a Property.", p);
                    }
                }
                foreach (var e in type.Events)
                {
                    if (ContainsSubstitution(e.EventType))
                    {
                        ILPPUtils.LogError("REFLECTINENHANCE5005", "ReflectionEnhance failed.", $"\"{e.EventType.Name}\" cannot be defined as a Event.", e);
                    }
                }
                foreach (var m in type.Methods)
                {
                    if (ContainsSubstitution(m.ReturnType))
                    {
                        ILPPUtils.LogError("REFLECTINENHANCE5006", "ReflectionEnhance failed.", $"\"{m.ReturnType.Name}\" cannot be defined as a Return Type.", m);
                    }

                    foreach (var p in m.Parameters)
                    {
                        if (ContainsSubstitution(p.ParameterType))
                        {
                            if (p.ParameterType is ByReferenceType refType2 && SubstitutionUtils.IsSubstitution(refType2.ElementType))
                            {
                                ILPPUtils.LogError("REFLECTINENHANCE5007", "ReflectionEnhance failed.", $"\"{refType2.ElementType.Name}\" cannot be specified as a ref/out parameter.", m);
                            }
                            else
                            {
                                ILPPUtils.LogError("REFLECTINENHANCE5008", "ReflectionEnhance failed.", $"\"{p.ParameterType.Name}\" cannot be specified as a Generic Argument/Array Element/Pointer Element.", m);
                            }
                        }
                    }

                    if (m.Body == null)
                    {
                        continue;
                    }

                    foreach (var variable in m.Body.Variables)
                    {
                        if (SubstitutionUtils.IsSubstitution(variable.VariableType))
                        {
                            continue;
                        }

                        if (ContainsSubstitution(variable.VariableType))
                        {
                            ILPPUtils.LogError("REFLECTINENHANCE5009", "ReflectionEnhance failed.", $"\"{variable.VariableType.Name}\" cannot be specified as a Generic Argument/Array Element/Pointer Element/ByRef Element.", m);
                        }
                    }

                    foreach (var instruction in m.Body.Instructions)
                    {
                        if (instruction.Operand is TypeReference operand)
                        {
                            if (instruction.OpCode != OpCodes.Ldtoken &&
                                ContainsSubstitution(operand))
                            {
                                ILPPUtils.LogError("REFLECTINENHANCE5010", "ReflectionEnhance failed.", $"\"{operand.Name}\" cannot be specified as a {instruction.OpCode}.", m, instruction);
                            }

                            continue;
                        }

                        if (instruction.Operand is GenericInstanceMethod genMethod)
                        {
                            var def = genMethod.Resolve();
                            if (def.Module.Assembly.Name.Name == "Katuusagi.ReflectionEnhance")
                            {
                                continue;
                            }

                            foreach (var t in genMethod.GenericArguments)
                            {
                                if (ContainsSubstitution(t))
                                {
                                    ILPPUtils.LogError("REFLECTINENHANCE5011", "ReflectionEnhance failed.", $"\"{t.Name}\" cannot be specified as a Generic Argument.", m, instruction);
                                }
                            }
                            continue;
                        }
                    }
                }
            }
        }

        private static bool ContainsSubstitution(TypeReference typeRef)
        {
            if (SubstitutionUtils.IsSubstitution(typeRef))
            {
                return true;
            }

            if (typeRef is TypeSpecification specType)
            {
                if (typeRef is GenericInstanceType genType)
                {
                    var def = genType.Resolve();
                    if (def.Module.Assembly.Name.Name == "Katuusagi.ReflectionEnhance")
                    {
                        return false;
                    }

                    foreach (var genArg in genType.GenericArguments)
                    {
                        if (ContainsSubstitution(genArg))
                        {
                            return true;
                        }
                    }
                }
                else if (typeRef is FunctionPointerType fpType)
                {
                    if (ContainsSubstitution(fpType.ReturnType))
                    {
                        return true;
                    }

                    foreach (var parameter in fpType.Parameters)
                    {
                        if (ContainsSubstitution(parameter.ParameterType))
                        {
                            return true;
                        }
                    }
                }
                else
                {
                    if (ContainsSubstitution(specType.ElementType))
                    {
                        return true;
                    }

                    if (typeRef is RequiredModifierType reqType)
                    {
                        if (ContainsSubstitution(reqType.ModifierType))
                        {
                            return true;
                        }
                    }
                    else if (typeRef is OptionalModifierType optType)
                    {
                        if (ContainsSubstitution(optType.ModifierType))
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        private void CreateCollectUsingType(ModuleDefinition module, TypeDefinition collectorType, TypeDefinition[] types)
        {
            var makableTypes = GetAllUsingTypes(module, types.OfType<TypeReference>());
            CreateCollectUsingTypesMethod<GenericInstanceType>(module, collectorType, makableTypes.GenericInstanceTypes);
            CreateCollectUsingTypesMethod<ArrayType>(module, collectorType, makableTypes.ArrayTypes);
            CreateCollectUsingTypesMethod<PointerType>(module, collectorType, makableTypes.PointerTypes);
            CreateCollectUsingTypesMethod<ByReferenceType>(module, collectorType, makableTypes.ByRefTypes);
            CreateCollectUsingTypesMethod<SentinelType>(module, collectorType, makableTypes.SentinelTypes);
            CreateCollectUsingTypesMethod<PinnedType>(module, collectorType, makableTypes.PinnedTypes);
            CreateCollectUsingTypesMethod<RequiredModifierType>(module, collectorType, makableTypes.RequiredModifierTypes);
            CreateCollectUsingTypesMethod<OptionalModifierType>(module, collectorType, makableTypes.OptionalModifierTypes);
            CreateCollectUsingTypesMethod<FunctionPointerType>(module, collectorType, makableTypes.FunctionPointerTypes);
            CreateCollectUsingGenericInstanceMethodsMethod(module, collectorType, makableTypes.GenericInstanceMethods);
        }

        private void CreateCollectUsingTypesMethod<T>(ModuleDefinition module, TypeDefinition collectorType, HashSet<TypeReference> types)
        {
            if (!types.Any())
            {
                return;
            }

            const int stepSize = 100;
            using (ThreadStaticArrayPool.Get(out var typeArray, types.OrderBy(v => v.FullName)))
            {
                var stepCount = typeArray.Length / stepSize;
                stepCount += ((typeArray.Length % stepSize) != 0) ? 1 : 0;
                for (int i = 0; i < stepCount; ++i)
                {
                    var collectMethod = new MethodDefinition($"$CollectUsing{typeof(T).Name}s{i}", MethodAttributes.Public | MethodAttributes.Static, module.TypeSystem.Void);
                    collectMethod.CustomAttributes.Add(new CustomAttribute(_preserveAttributeConstructor));
                    var resultParameter = new ParameterDefinition("result", ParameterAttributes.None, _typeListType);
                    collectMethod.Parameters.Add(resultParameter);

                    var collectILProcessor = collectMethod.Body.GetILProcessor();
                    for (int j = 0; (i * stepSize + j) < typeArray.Length && j < stepSize; ++j)
                    {
                        var index = i * stepSize + j;
                        var addMethod = new MethodDefinition($"$AddUsing{typeof(T).Name}{index}", MethodAttributes.Private | MethodAttributes.Static, module.TypeSystem.Void);
                        addMethod.Parameters.Add(new ParameterDefinition("result", ParameterAttributes.None, _typeListType));
                        addMethod.NoInlining = true;
                        var addILProcessor = addMethod.Body.GetILProcessor();

                        var type = typeArray[index];
                        addILProcessor.Emit(OpCodes.Ldarg_0);
                        addILProcessor.Emit(OpCodes.Ldtoken, type);
                        addILProcessor.Emit(OpCodes.Call, _getTypeFromHandle);
                        addILProcessor.Emit(OpCodes.Call, _typeListAdd);
                        addILProcessor.Emit(OpCodes.Ret);

                        collectorType.Methods.Add(addMethod);

                        var leaveTarget = Instruction.Create(OpCodes.Nop);
                        var tryStart = Instruction.Create(OpCodes.Ldarg_0);
                        collectILProcessor.Append(tryStart);
                        collectILProcessor.Emit(OpCodes.Call, addMethod);
                        collectILProcessor.Emit(OpCodes.Leave, leaveTarget);

                        var handlerStart = Instruction.Create(OpCodes.Pop);
                        collectILProcessor.Append(handlerStart);
                        collectILProcessor.Emit(OpCodes.Leave, leaveTarget);

                        collectILProcessor.Append(leaveTarget);

                        collectMethod.Body.ExceptionHandlers.Add(new ExceptionHandler(ExceptionHandlerType.Catch)
                        {
                            TryStart = tryStart,
                            TryEnd = handlerStart,
                            HandlerStart = handlerStart,
                            HandlerEnd = leaveTarget,
                            CatchType = module.TypeSystem.Object,
                        });
                    }

                    collectILProcessor.Emit(OpCodes.Ret);
                    collectorType.Methods.Add(collectMethod);
                }
            }
        }

        private void CreateCollectUsingGenericInstanceMethodsMethod(ModuleDefinition module, TypeDefinition collectorType, HashSet<MethodReference> methods)
        {
            if (!methods.Any())
            {
                return;
            }

            const int stepSize = 100;
            using (ThreadStaticArrayPool.Get(out var methodArray, methods.OrderBy(v => v.FullName)))
            {
                var count = methodArray.Length;
                var stepCount = count / stepSize;
                stepCount += ((count % stepSize) != 0) ? 1 : 0;
                for (int i = 0; i < stepCount; ++i)
                {
                    var collectMethod = new MethodDefinition($"$CollectUsingGenericInstanceMethods{i}", MethodAttributes.Public | MethodAttributes.Static, module.TypeSystem.Void);
                    collectMethod.CustomAttributes.Add(new CustomAttribute(_preserveAttributeConstructor));
                    collectMethod.Parameters.Add(new ParameterDefinition("result", ParameterAttributes.None, _methodListType));

                    var collectILProcessor = collectMethod.Body.GetILProcessor();
                    for (int j = 0; (i * stepSize + j) < count && j < stepSize; ++j)
                    {
                        var index = i * stepSize + j;
                        var addMethod = new MethodDefinition($"$AddUsingGenericInstanceMethod{index}", MethodAttributes.Private | MethodAttributes.Static, module.TypeSystem.Void);
                        addMethod.Parameters.Add(new ParameterDefinition("result", ParameterAttributes.None, _methodListType));
                        addMethod.NoInlining = true;
                        var addILProcessor = addMethod.Body.GetILProcessor();

                        var method = methodArray[index];
                        addILProcessor.Emit(OpCodes.Ldarg_0);
                        addILProcessor.Emit(OpCodes.Ldtoken, method);
                        addILProcessor.Emit(OpCodes.Ldtoken, method.DeclaringType);
                        addILProcessor.Emit(OpCodes.Call, _getMethodFromHandle);
                        addILProcessor.Emit(OpCodes.Call, _methodListAdd);
                        addILProcessor.Emit(OpCodes.Ret);

                        collectorType.Methods.Add(addMethod);
                        var leaveTarget = Instruction.Create(OpCodes.Nop);
                        var tryStart = Instruction.Create(OpCodes.Ldarg_0);
                        collectILProcessor.Append(tryStart);
                        collectILProcessor.Emit(OpCodes.Call, addMethod);
                        collectILProcessor.Emit(OpCodes.Leave, leaveTarget);

                        var handlerStart = Instruction.Create(OpCodes.Pop);
                        collectILProcessor.Append(handlerStart);
                        collectILProcessor.Emit(OpCodes.Leave, leaveTarget);

                        collectILProcessor.Append(leaveTarget);
                        collectMethod.Body.ExceptionHandlers.Add(new ExceptionHandler(ExceptionHandlerType.Catch)
                        {
                            TryStart = tryStart,
                            TryEnd = handlerStart,
                            HandlerStart = handlerStart,
                            HandlerEnd = leaveTarget,
                            CatchType = module.TypeSystem.Object,
                        });
                    }

                    collectILProcessor.Emit(OpCodes.Ret);
                    collectorType.Methods.Add(collectMethod);
                }
            }
        }

        private void CreateCollectStaticFields(ModuleDefinition module, IEnumerable<TypeDefinition> types)
        {
            foreach (var type in types)
            {
                if (type.IsEnum)
                {
                    continue;
                }

                foreach (var field in type.Fields)
                {
                    if (!field.IsStatic || field.IsLiteral)
                    {
                        continue;
                    }

                    var method = new MethodDefinition($"$GetPointer_{field.Name}", MethodAttributes.Public | MethodAttributes.Static, module.TypeSystem.IntPtr);
                    method.CustomAttributes.Add(new CustomAttribute(_preserveAttributeConstructor));
                    var ilProcessor = method.Body.GetILProcessor();

                    var decType = field.DeclaringType.GetForceInstancedGenericType();
                    var genField = new FieldReference(field.Name, field.FieldType, decType);
                    ilProcessor.Emit(OpCodes.Ldsflda, genField);
                    ilProcessor.Emit(OpCodes.Ret);

                    type.Methods.Add(method);
                }

                CreateCollectStaticFields(module, type.NestedTypes);
            }
        }

        private void CreateCollectCreateInstance(ModuleDefinition module, IEnumerable<TypeDefinition> types)
        {
            foreach (var type in types)
            {
                if (type.IsEnum)
                {
                    continue;
                }

                TypeReference importedType;
                if (type.IsGenericDefinition())
                {
                    importedType = module.ImportReference(type.MakeGenericInstanceType(type.GenericParameters));
                }
                else
                {
                    importedType = module.ImportReference(type);
                }

                using (ThreadStaticArrayPool.Get(out var ctors, type.GetConstructors()))
                {
                    foreach (var ctor in ctors)
                    {
                        if (ctor.IsStatic)
                        {
                            continue;
                        }

                        var method = new MethodDefinition($"$CreateInstance", MethodAttributes.Public | MethodAttributes.Static, importedType);
                        method.CustomAttributes.Add(new CustomAttribute(_preserveAttributeConstructor));
                        var ilProcessor = method.Body.GetILProcessor();

                        if (type.IsValueType && !ctor.Parameters.Any())
                        {
                            var v = new VariableDefinition(importedType);
                            method.Body.Variables.Add(v);
                            ilProcessor.Emit(OpCodes.Ldloca_S, 0);
                            ilProcessor.Emit(OpCodes.Initobj, importedType);
                            ilProcessor.Emit(OpCodes.Ldloc_0);
                        }
                        else
                        {
                            foreach (var p in ctor.Parameters)
                            {
                                var newParam = new ParameterDefinition(p.Name, p.Attributes, p.ParameterType);
                                method.Parameters.Add(newParam);
                                ilProcessor.Append(ILPPUtils.LoadArgument(newParam));
                            }

                            ilProcessor.Emit(OpCodes.Newobj, ctor);
                        }
                        ilProcessor.Emit(OpCodes.Ret);

                        type.Methods.Add(method);
                    }
                }

                CreateCollectCreateInstance(module, type.NestedTypes);
            }
        }

        private MakableTypes GetAllUsingTypes(ModuleDefinition module, IEnumerable<TypeReference> root)
        {
            var result = new MakableTypes();
            result.RegisterIgnoreMethodCheck(v => TypeDeclaringOf(v.DeclaringType, "Unity.Collections.LowLevel.Unsafe.BurstLike"));
            result.RegisterIgnoreMethodCheck(v => TypeDeclaringOf(v.DeclaringType.GetElementType(), "Unity.Collections.LowLevel.Unsafe.UnsafeList`1"));

            foreach (var t in root)
            {
                GetUsingTypes(module, t, result, null, true);
            }

            return result;
        }

        private bool TypeDeclaringOf(TypeReference type, string methodName)
        {
            if (type.DeclaringType != null)
            {
                return TypeDeclaringOf(type.DeclaringType, methodName);
            }

            return type.FullName == methodName;
        }

        private void GetUsingTypes(ModuleDefinition module, TypeReference typeRef, MakableTypes result, Dictionary<GenericParameter, TypeReference> baseTypeParameters, bool isRoot = false)
        {
            if (typeRef == null || typeRef.IsGenericDefinition())
            {
                return;
            }

            Dictionary<GenericParameter, TypeReference> typeParameters;
            if (baseTypeParameters == null)
            {
                typeParameters = new Dictionary<GenericParameter, TypeReference>(TypeReferenceComparer.Default);
            }
            else
            {
                if (!isRoot)
                {
                    typeRef = ILPPUtils.ReplaceGeneric(module, typeRef, baseTypeParameters);
                    if (!result.Add(typeRef))
                    {
                        return;
                    }

                    if (!typeRef.IsGenericInstance && 
                        typeRef is TypeSpecification specType)
                    {
                        if (typeRef is FunctionPointerType functionPointerType)
                        {
                            GetUsingTypes(module, functionPointerType.ReturnType, result, baseTypeParameters);
                            foreach (var p in functionPointerType.Parameters)
                            {
                                GetUsingTypes(module, p.ParameterType, result, baseTypeParameters);
                            }
                        }
                        else
                        {
                            GetUsingTypes(module, specType.ElementType, result, baseTypeParameters);
                            if (typeRef is RequiredModifierType rmType)
                            {
                                GetUsingTypes(module, rmType.ModifierType, result, baseTypeParameters);
                            }
                            else if (typeRef is RequiredModifierType omType)
                            {
                                GetUsingTypes(module, omType.ModifierType, result, baseTypeParameters);
                            }
                        }

                        return;
                    }

                    GetUsingTypes(module, typeRef.GetDeclaringType(), result, baseTypeParameters);
                }

                typeParameters = new Dictionary<GenericParameter, TypeReference>(baseTypeParameters, TypeReferenceComparer.Default);
            }

            ILPPUtils.CreateTypeParameters(module, typeRef, typeParameters);
            foreach (var t in typeRef.GetGenericArguments())
            {
                GetUsingTypes(module, t, result, typeParameters);
            }

            var type = typeRef.Resolve();
            if (type == null)
            {
                return;
            }

            foreach (var i in type.Interfaces)
            {
                GetUsingTypes(module, i.InterfaceType, result, typeParameters);
            }

            GetUsingTypes(module, type.BaseType, result, typeParameters);
            foreach (var t in typeRef.GetNestedTypes(type))
            {
                GetUsingTypes(module, t, result, typeParameters);
            }
            foreach (var f in type.Fields)
            {
                GetUsingTypes(module, f.FieldType, result, typeParameters);
            }
            foreach (var p in type.Properties)
            {
                GetUsingTypes(module, p.PropertyType, result, typeParameters);
            }
            foreach (var e in type.Events)
            {
                GetUsingTypes(module, e.EventType, result, typeParameters);
            }
            foreach (var m in type.Methods)
            {
                GetUsingTypes(module, m, result, typeParameters);
            }
        }

        private void GetUsingTypes(ModuleDefinition module, MethodReference methodRef, MakableTypes result, Dictionary<GenericParameter, TypeReference> baseTypeParameters)
        {
            if (methodRef == null || methodRef.IsGenericDefinition())
            {
                return;
            }

            Dictionary<GenericParameter, TypeReference> typeParameters;
            if (baseTypeParameters == null)
            {
                typeParameters = new Dictionary<GenericParameter, TypeReference>(TypeReferenceComparer.Default);
            }
            else
            {
                methodRef = ILPPUtils.ReplaceGeneric(module, methodRef, baseTypeParameters);
                if (!result.Add(methodRef))
                {
                    return;
                }

                typeParameters = new Dictionary<GenericParameter, TypeReference>(baseTypeParameters, TypeReferenceComparer.Default);
            }

            ILPPUtils.CreateTypeParameters(module, methodRef, typeParameters);

            foreach (var p in methodRef.Parameters)
            {
                GetUsingTypes(module, p.ParameterType, result, typeParameters);
            }

            GetUsingTypes(module, methodRef.ReturnType, result, typeParameters);
            GetUsingTypes(module, methodRef.DeclaringType, result, baseTypeParameters);

            foreach (var t in methodRef.GetGenericArguments())
            {
                GetUsingTypes(module, t, result, typeParameters);
            }

            var method = methodRef.Resolve();
            if (method == null)
            {
                return;
            }

            var methodBody = method.Body;
            if (methodBody == null)
            {
                return;
            }

            foreach (var variable in methodBody.Variables)
            {
                GetUsingTypes(module, variable.VariableType, result, typeParameters);
            }

            foreach (var instruction in methodBody.Instructions)
            {
                if (instruction.Operand is TypeReference type)
                {
                    if (type.ContainsGenericParameter)
                    {
                        continue;
                    }

                    GetUsingTypes(module, type, result, typeParameters);
                    continue;
                }

                if (instruction.Operand is GenericInstanceMethod subMethodRef)
                {
                    GetUsingTypes(module, subMethodRef, result, typeParameters);
                    continue;
                }

                if (instruction.Operand is MemberReference member)
                {
                    GetUsingTypes(module, member.DeclaringType, result, typeParameters);
                    continue;
                }
            }
        }

        private bool OptimizeCreateInstanceProcess(ILProcessor ilProcessor, MethodDefinition method, Instruction instruction, ref int instructionDiff)
        {
            if (instruction.OpCode != OpCodes.Call || !(instruction.Operand is MethodReference called) ||
                called.DeclaringType.FullName != "Katuusagi.ReflectionEnhance.REType" ||
                called.Name != "CreateInstance" ||
                called.HasParameters ||
                !(called is GenericInstanceMethod genMethod))
            {
                return false;
            }

            var t = genMethod.GenericArguments.FirstOrDefault();
            if (!IsInitializableValueType(t))
            {
                return false;
            }

            var variable = new VariableDefinition(t);
            method.Body.Variables.Add(variable);

            var loadLocalAddress = ILPPUtils.LoadLocalAddress(variable);
            instruction.OpCode = loadLocalAddress.OpCode;
            instruction.Operand = loadLocalAddress.Operand;

            var init = Instruction.Create(OpCodes.Initobj, t);
            ilProcessor.InsertAfter(instruction, init);
            ++instructionDiff;

            var loadLocal = ILPPUtils.LoadLocal(variable);
            ilProcessor.InsertAfter(init, loadLocal);
            ++instructionDiff;

            return true;
        }

        private bool IsInitializableValueType(TypeReference t)
        {
            if (t.FullName == "System.ValueType" ||
                t.IsValueType || t.IsPointer || t.IsPinned || t.IsFunctionPointer)
            {
                return true;
            }

            if (t.IsArray)
            {
                return false;
            }

            if (t is GenericParameter genParam)
            {
#if UNITY_2022_1_OR_NEWER
                return genParam.Constraints.Any(v => IsInitializableValueType(v.ConstraintType));
#else
                return genParam.Constraints.Any(v => IsInitializableValueType(v));
#endif
            }

            var typeDef = t.Resolve();
            if (typeDef == null)
            {
                return false;
            }

            return typeDef.IsValueType;
        }

        private bool OptimizeRETypeProcess(ILProcessor ilProcessor, MethodDefinition method, Instruction instruction, ref int instructionDiff)
        {
            if (instruction.OpCode != OpCodes.Call || !(instruction.Operand is MethodReference called) ||
                !called.HasParameters ||
                called.DeclaringType.FullName != "Katuusagi.ReflectionEnhance.REType")
            {
                return false;
            }

            var firstParameter = called.Parameters.FirstOrDefault();
            if (firstParameter.ParameterType.FullName != "System.Type")
            {
                return false;
            }

            using (ThreadStaticListPool<Instruction>.Get(out var argInstructions))
            {
                if (!instruction.TryGetPushConstArgumentInstructions(0, out TypeReference declaringType, argInstructions))
                {
                    return false;
                }

                if (declaringType.IsGenericDefinition() ||
                    declaringType.IsFunctionPointer ||
                    declaringType.IsPointer ||
                    declaringType.IsByReference)
                {
                    return false;
                }

                var calledDef = called.Resolve();
                if (calledDef == null)
                {
                    return false;
                }

                var newCalled = new MethodReference(called.Name, calledDef.ReturnType, calledDef.DeclaringType);
                foreach (var p in calledDef.Parameters.Skip(1))
                {
                    newCalled.Parameters.Add(p);
                }

                newCalled.GenericParameters.Add(new GenericParameter("T", newCalled));
                foreach (var p in calledDef.GenericParameters)
                {
                    newCalled.GenericParameters.Add(p);
                }

                var resolved = newCalled.Resolve();
                if (resolved == null)
                {
                    return false;
                }

                var newGenMethod = new GenericInstanceMethod(method.Module.ImportReference(newCalled));
                newGenMethod.GenericArguments.Add(declaringType);
                if (called is GenericInstanceMethod genMethod)
                {
                    foreach (var a in genMethod.GenericArguments)
                    {
                        newGenMethod.GenericArguments.Add(a);
                    }
                }

                instruction.Operand = method.Module.ImportReference(newGenMethod);

                foreach (var argInstruction in argInstructions)
                {
                    argInstruction.OpCode = OpCodes.Nop;
                    argInstruction.Operand = null;
                }
                return true;
            }
        }

        private bool TypeOfProcess(ILProcessor ilProcessor, MethodDefinition method, Instruction instruction, ref int instructionDiff)
        {
            if (instruction.OpCode != OpCodes.Call || !(instruction.Operand is MethodReference called) ||
                called.DeclaringType.FullName != "Katuusagi.ReflectionEnhance.REReflection" || called.Name != "TypeOf")
            {
                return false;
            }

            using (ThreadStaticListPool<Instruction>.Get(out var argInstructions))
            {
                var parameterCount = called.Parameters.Count;
                if (!instruction.TryGetPushConstArgumentInstructions(1, out string name, argInstructions))
                {
                    ILPPUtils.LogError("REFLECTINENHANCE5020", "ReflectionEnhance failed.", "TypeOf method accepts only constant parameters.", method, instruction);
                    return false;
                }

                TypeReference target;
                var firstParameter = called.Parameters.First();
                var firstParameterTypeName = firstParameter.ParameterType.FullName;
                if (firstParameterTypeName == "System.String")
                {
                    if (!instruction.TryGetPushConstArgumentInstructions(0, out string assemblyName, argInstructions))
                    {
                        ILPPUtils.LogError("REFLECTINENHANCE5020", "ReflectionEnhance failed.", "TypeOf method accepts only constant parameters.", method, instruction);
                        return false;
                    }

                    if (!CheckJumpTarget(method, argInstructions.Skip(1).Append(instruction)))
                    {
                        ILPPUtils.LogError("REFLECTINENHANCE5020", "ReflectionEnhance failed.", "TypeOf method accepts only constant parameters.", method, instruction);
                    }

                    AssemblyDefinition assembly = null;
                    if (_compiledAssembly.Name == assemblyName)
                    {
                        assembly = _assembly;
                    }
                    else
                    {
                        var asmPath = _compiledAssembly.References.FirstOrDefault(v => Path.GetFileNameWithoutExtension(v) == assemblyName);
                        if (asmPath != null)
                        {
                            assembly = AssemblyDefinition.ReadAssembly(asmPath);
                        }
                    }

                    if (assembly == null)
                    {
                        ILPPUtils.LogError("REFLECTINENHANCE5021", "ReflectionEnhance failed.", $"\"{assemblyName}\" is not imported.", method, instruction);
                        return false;
                    }

                    target = assembly.Modules.SelectMany(v => v.Types).GetAllTypes().FirstOrDefault(v => v.FullName == name);
                    if (target == null)
                    {
                        ILPPUtils.LogError("REFLECTINENHANCE5022", "ReflectionEnhance failed.", $"\"{assembly}\" has not \"{name}\".", method, instruction);
                        return false;
                    }
                }
                else if (firstParameterTypeName == "System.Type")
                {
                    if (!instruction.TryGetPushConstArgumentInstructions(0, out TypeReference declaringType, argInstructions))
                    {
                        ILPPUtils.LogError("REFLECTINENHANCE5020", "ReflectionEnhance failed.", "TypeOf method accepts only constant parameters.", method, instruction);
                        return false;
                    }

                    if (!CheckJumpTarget(method, argInstructions.Skip(1).Append(instruction)))
                    {
                        ILPPUtils.LogError("REFLECTINENHANCE5020", "ReflectionEnhance failed.", "TypeOf method accepts only constant parameters.", method, instruction);
                        return false;
                    }

                    if (declaringType.IsGenericParameter)
                    {
                        ILPPUtils.LogError("REFLECTINENHANCE5023", "ReflectionEnhance failed.", "GenericParameter cannot be specified as the type argument of the TypeOf method.", method, instruction);
                        return false;
                    }

                    var type = declaringType.Resolve();
                    target = type.NestedTypes.FirstOrDefault(v => v.Name == name);
                    if (target == null)
                    {
                        ILPPUtils.LogError("REFLECTINENHANCE5024", "ReflectionEnhance failed.", $"\"{declaringType}\" has not \"{name}\".", method, instruction);
                        return false;
                    }
                }
                else
                {
                    return false;
                }

                foreach (var argInstruction in argInstructions.Skip(1))
                {
                    argInstruction.OpCode = OpCodes.Nop;
                    argInstruction.Operand = null;
                }

                argInstructions[0].OpCode = OpCodes.Ldtoken;
                argInstructions[0].Operand = target;

                instruction.OpCode = OpCodes.Call;
                instruction.Operand = _getTypeFromHandle;
                return true;
            }
        }

        private bool FieldOfProcess(ILProcessor ilProcessor, MethodDefinition method, Instruction instruction, ref int instructionDiff)
        {
            if (instruction.OpCode != OpCodes.Call || !(instruction.Operand is MethodReference called) ||
                called.DeclaringType.FullName != "Katuusagi.ReflectionEnhance.REReflection" || called.Name != "FieldOf")
            {
                return false;
            }

            using (ThreadStaticListPool<Instruction>.Get(out var argInstructions))
            {
                var parameterCount = called.Parameters.Count;

                if (!instruction.TryGetPushConstArgumentInstructions(0, out TypeReference declaringType, argInstructions))
                {
                    ILPPUtils.LogError("REFLECTINENHANCE5030", "ReflectionEnhance failed.", "FieldOf method accepts only constant parameters.", method, instruction);
                    return false;
                }

                if (!instruction.TryGetPushConstArgumentInstructions(1, out string name, argInstructions))
                {
                    ILPPUtils.LogError("REFLECTINENHANCE5030", "ReflectionEnhance failed.", "FieldOf method accepts only constant parameters.", method, instruction);
                    return false;
                }

                if (!CheckJumpTarget(method, argInstructions.Skip(1).Append(instruction)))
                {
                    ILPPUtils.LogError("REFLECTINENHANCE5030", "ReflectionEnhance failed.", "FieldOf method accepts only constant parameters.", method, instruction);
                }

                if (declaringType.IsGenericParameter)
                {
                    ILPPUtils.LogError("REFLECTINENHANCE5031", "ReflectionEnhance failed.", "GenericParameter cannot be specified as the type argument of the FieldOf method.", method, instruction);
                    return false;
                }

                var type = declaringType.Resolve();
                FieldReference target = type.Fields.FirstOrDefault(v => v.Name == name);
                if (target == null)
                {
                    ILPPUtils.LogError("REFLECTINENHANCE5032", "ReflectionEnhance failed.", $"\"{declaringType}\" has not \"{name}\" field.", method, instruction);
                    return false;
                }

                if (declaringType.IsGenericInstance)
                {
                    target = new FieldReference(target.Name, target.FieldType, declaringType);
                }

                foreach (var argInstruction in argInstructions.Skip(3))
                {
                    argInstruction.OpCode = OpCodes.Nop;
                    argInstruction.Operand = null;
                }

                argInstructions[0].OpCode = OpCodes.Nop;
                argInstructions[0].Operand = null;

                argInstructions[1].OpCode = OpCodes.Ldtoken;
                argInstructions[1].Operand = target;

                argInstructions[2].OpCode = OpCodes.Ldtoken;
                argInstructions[2].Operand = declaringType;

                instruction.OpCode = OpCodes.Call;
                instruction.Operand = _getFieldFromHandle;
                return true;
            }
        }

        private bool MethodOfProcess(ILProcessor ilProcessor, MethodDefinition method, Instruction instruction, ref int instructionDiff)
        {
            if (instruction.OpCode != OpCodes.Call || !(instruction.Operand is MethodReference called) ||
                called.DeclaringType.FullName != "Katuusagi.ReflectionEnhance.REReflection" || called.Name != "MethodOf")
            {
                return false;
            }

            using (ThreadStaticListPool<Instruction>.Get(out var argInstructions))
            {
                var parameterCount = called.Parameters.Count;
                if (!instruction.TryGetPushConstArgumentInstructions(0, out TypeReference declaringType, argInstructions))
                {
                    ILPPUtils.LogError("REFLECTINENHANCE5040", "ReflectionEnhance failed.", "MethodOf method accepts only constant parameters.", method, instruction);
                    return false;
                }

                if (!instruction.TryGetPushConstArgumentInstructions(1, out string name, argInstructions))
                {
                    ILPPUtils.LogError("REFLECTINENHANCE5040", "ReflectionEnhance failed.", "MethodOf method accepts only constant parameters.", method, instruction);
                    return false;
                }

                ThreadStaticArrayPool<TypeReference>.Handle hTypeArgs = default;
                IList<TypeReference> typeArgs;
                if (called.GetGenericArguments().Any())
                {
                    typeArgs = called.GetGenericArguments();
                }
                else
                {
                    hTypeArgs = ThreadStaticArrayPool.Get<TypeReference>(out var tmp, parameterCount - 3);
                    typeArgs = tmp;

                    for (int i = 2; i < parameterCount - 1; ++i)
                    {
                        if (!instruction.TryGetPushConstArgumentInstructions(i, out TypeReference typeArg, argInstructions))
                        {
                            ILPPUtils.LogError("REFLECTINENHANCE5040", "ReflectionEnhance failed.", "MethodOf method accepts only constant parameters.", method, instruction);
                            return false;
                        }

                        typeArgs[i - 2] = typeArg;
                    }
                }

                using (hTypeArgs)
                {
                    if (!instruction.TryGetPushConstArgumentInstructions(parameterCount - 1, out int genericCount, argInstructions))
                    {
                        ILPPUtils.LogError("REFLECTINENHANCE5040", "ReflectionEnhance failed.", "MethodOf method accepts only constant parameters.", method, instruction);
                        return false;
                    }

                    if (!CheckJumpTarget(method, argInstructions.Skip(1).Append(instruction)))
                    {
                        ILPPUtils.LogError("REFLECTINENHANCE5040", "ReflectionEnhance failed.", "MethodOf method accepts only constant parameters.", method, instruction);
                    }

                    if (declaringType.IsGenericParameter)
                    {
                        ILPPUtils.LogError("REFLECTINENHANCE5041", "ReflectionEnhance failed.", "GenericParameter cannot be specified as the type argument of the MethodOf method.", method, instruction);
                        return false;
                    }

                    var module = method.Module;
                    var returnType = typeArgs.Last();
                    using (ThreadStaticArrayPool.Get(out var parameterTypes, typeArgs.Take(typeArgs.Count - 1)))
                    using (TypeReferenceDictionaryPool.Get<GenericParameter, TypeReference>(out var typeParameters))
                    {
                        ILPPUtils.CreateTypeParameters(module, declaringType, typeParameters);

                        var comparer = SubstitutionTypeReferenceComparer.Default;

                        var type = declaringType.Resolve();
                        MethodReference target = type.Methods.FirstOrDefault(v => v.Name == name && v.GenericParameters.Count == genericCount &&
                                                                    comparer.Equals(v.ReturnType, returnType) &&
                                                                    v.Parameters.Select(v => ILPPUtils.ReplaceGeneric(module, v.ParameterType, typeParameters))
                                                                                .SequenceEqual(parameterTypes, comparer));
                        if (target == null)
                        {
                            var generic = genericCount == 0 ? "" : $"<{genericCount}>";
                            var parameterStr = string.Join(", ", parameterTypes.Select(v => v.FullName));
                            ILPPUtils.LogError("REFLECTINENHANCE5042", "ReflectionEnhance failed.", $"\"{declaringType}\" has not \"{returnType} {name}{generic}({parameterStr})\" method.", method, instruction);
                            return false;
                        }

                        target = ILPPUtils.ReplaceGeneric(module, target, typeParameters);

                        foreach (var argInstruction in argInstructions.Skip(2))
                        {
                            argInstruction.OpCode = OpCodes.Nop;
                            argInstruction.Operand = null;
                        }

                        argInstructions[0].OpCode = OpCodes.Ldtoken;
                        argInstructions[0].Operand = target;

                        argInstructions[1].OpCode = OpCodes.Ldtoken;
                        argInstructions[1].Operand = declaringType;

                        instruction.OpCode = OpCodes.Call;
                        instruction.Operand = _getMethodFromHandle;
                        return true;
                    }
                }
            }
        }

        private bool ConstructorOfProcess(ILProcessor ilProcessor, MethodDefinition method, Instruction instruction, ref int instructionDiff)
        {
            if (instruction.OpCode != OpCodes.Call || !(instruction.Operand is MethodReference called) ||
                called.DeclaringType.FullName != "Katuusagi.ReflectionEnhance.REReflection" || called.Name != "ConstructorOf")
            {
                return false;
            }

            using (ThreadStaticListPool<Instruction>.Get(out var argInstructions))
            {
                var parameterCount = called.Parameters.Count;
                if (!instruction.TryGetPushConstArgumentInstructions(0, out TypeReference declaringType, argInstructions))
                {
                    ILPPUtils.LogError("REFLECTINENHANCE5050", "ReflectionEnhance failed.", "ConstructorOf method accepts only constant parameters.", method, instruction);
                    return false;
                }

                ThreadStaticArrayPool<TypeReference>.Handle hTypeArgs;
                IList<TypeReference> typeArgs;
                if (called.GetGenericArguments().Any())
                {
                    typeArgs = called.GetGenericArguments();
                }
                else
                {
                    hTypeArgs = ThreadStaticArrayPool.Get<TypeReference>(out var tmp, parameterCount - 1);
                    typeArgs = tmp;
                    for (int i = 1; i < parameterCount; ++i)
                    {
                        if (!instruction.TryGetPushConstArgumentInstructions(i, out TypeReference typeArg, argInstructions))
                        {
                            ILPPUtils.LogError("REFLECTINENHANCE5050", "ReflectionEnhance failed.", "ConstructorOf method accepts only constant parameters.", method, instruction);
                            return false;
                        }

                        typeArgs[i - 1] = typeArg;
                    }
                }

                using (hTypeArgs)
                {
                    if (!CheckJumpTarget(method, argInstructions.Skip(1).Append(instruction)))
                    {
                        ILPPUtils.LogError("REFLECTINENHANCE5050", "ReflectionEnhance failed.", "ConstructorOf method accepts only constant parameters.", method, instruction);
                    }

                    if (declaringType.IsGenericParameter)
                    {
                        ILPPUtils.LogError("REFLECTINENHANCE5051", "ReflectionEnhance failed.", "GenericParameter cannot be specified as the type argument of the ConstructorOf method.", method, instruction);
                        return false;
                    }

                    var parameterTypes = typeArgs;
                    var module = method.Module;

                    using (TypeReferenceDictionaryPool.Get<GenericParameter, TypeReference>(out var typeParameters))
                    {
                        ILPPUtils.CreateTypeParameters(module, declaringType, typeParameters);

                        var comparer = SubstitutionTypeReferenceComparer.Default;

                        var type = declaringType.Resolve();
                        MethodReference target = type.GetConstructors().FirstOrDefault(v => v.Parameters.Select(v => ILPPUtils.ReplaceGeneric(module, v.ParameterType, typeParameters))
                                                                                 .SequenceEqual(parameterTypes, comparer));
                        if (target == null)
                        {
                            var parameterStr = string.Join(", ", parameterTypes.Select(v => v.FullName));
                            ILPPUtils.LogError("REFLECTINENHANCE5052", "ReflectionEnhance failed.", $"\"{declaringType}\" has not \".ctor({parameterStr})\" method.", method, instruction);
                            return false;
                        }

                        target = ILPPUtils.ReplaceGeneric(module, target, typeParameters);

                        foreach (var argInstruction in argInstructions.Skip(2))
                        {
                            argInstruction.OpCode = OpCodes.Nop;
                            argInstruction.Operand = null;
                        }

                        argInstructions[0].OpCode = OpCodes.Ldtoken;
                        argInstructions[0].Operand = target;

                        argInstructions[1].OpCode = OpCodes.Ldtoken;
                        argInstructions[1].Operand = declaringType;

                        instruction.OpCode = OpCodes.Call;
                        instruction.Operand = _getMethodFromHandle;
                        return true;
                    }
                }
            }
        }

        private bool TryGetTypeToken(Instruction instruction, out TypeReference t, out Instruction loadToken)
        {
            if (instruction.OpCode != OpCodes.Call ||
                !(instruction.Operand is MethodReference getTypeFromHandle) ||
                !getTypeFromHandle.Is(_getTypeFromHandle))
            {
                t = null;
                loadToken = null;
                return false;
            }

            return instruction.TryGetPushConstArgumentInstruction(0, out t, out loadToken);
        }

        private bool CheckJumpTarget(MethodDefinition method, IEnumerable<Instruction> instructions)
        {
            using (ThreadStaticHashSetPool.Get<Instruction>(out var jumpTargets))
            {
                method.Body.GetJumpTargets(jumpTargets);
                foreach (var instruction in instructions)
                {
                    if (jumpTargets.Contains(instruction))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}

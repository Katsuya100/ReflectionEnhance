using Katuusagi.MemoizationForUnity;
using System;
using System.Buffers;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Katuusagi.ReflectionEnhance.Signature
{
    [Serializable]
    public partial class ReflectionSignature : IEquatable<ReflectionSignature>, ISerializationCallbackReceiver, ISignature
    {
        [SerializeField]
        private SignatureType _signatureType;
        [SerializeField]
        private string _name;
        [SerializeField]
        private int _count;
        [SerializeField]
        private string _ownerSignature;
        [SerializeField]
        private string _returnSignature;
        [SerializeField]
        private string[] _parameterSignatures;
        [SerializeField]
        private string[] _genericArgumentSignatures;

        [NonSerialized]
        private ReflectionSignature _owner;
        [NonSerialized]
        private ReflectionSignature _return;
        [NonSerialized]
        private ReflectionSignature[] _parameters;
        [NonSerialized]
        private ReflectionSignature[] _genericArguments;

        [NonSerialized]
        private Assembly _assembly = null;
        [NonSerialized]
        private Module _module = null;
        [NonSerialized]
        private MemberInfo _member = null;
        [NonSerialized]
        private MemberInfo _genericOwner = null;

        private ReflectionSignature()
        {
        }

        public ReflectionSignature(Assembly assembly)
        {
            _assembly = assembly;
        }

        public ReflectionSignature(Module module)
        {
            _module = module;
        }

        public ReflectionSignature(MemberInfo member)
        {
            _member = member;
        }

        public ReflectionSignature(MemberInfo member, MemberInfo genericOwner)
        {
            _member = member;
            _genericOwner = genericOwner;
        }

        public static implicit operator ReflectionSignature(MemberInfo member)
        {
            return new ReflectionSignature(member);
        }

        public static implicit operator Assembly(ReflectionSignature signature)
        {
            return signature._assembly;
        }

        public static implicit operator Module(ReflectionSignature signature)
        {
            return signature._module;
        }

        public static implicit operator MemberInfo(ReflectionSignature signature)
        {
            return signature._member;
        }

        public static implicit operator MethodBase(ReflectionSignature signature)
        {
            return signature._member as MethodBase;
        }

        public static implicit operator Type(ReflectionSignature signature)
        {
            return signature._member as Type;
        }

        public static implicit operator ConstructorInfo(ReflectionSignature signature)
        {
            return signature._member as ConstructorInfo;
        }

        public static implicit operator FieldInfo(ReflectionSignature signature)
        {
            return signature._member as FieldInfo;
        }

        public static implicit operator PropertyInfo(ReflectionSignature signature)
        {
            return signature._member as PropertyInfo;
        }

        public static implicit operator MethodInfo(ReflectionSignature signature)
        {
            return signature._member as MethodInfo;
        }

        public static implicit operator EventInfo(ReflectionSignature signature)
        {
            return signature._member as EventInfo;
        }

        public static explicit operator ReflectionSignature(string str)
        {
            return FromString(str);
        }
        
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReflectionSignature FromStringRaw(string str)
        {
            return JsonUtility.FromJson<ReflectionSignature>(str);
        }

        [Memoization(Modifier = "public override")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private string ToStringRaw()
        {
            return JsonUtility.ToJson(this);
        }

        void ISerializationCallbackReceiver.OnBeforeSerialize()
        {
            if (_assembly != null)
            {
                Serialize(_assembly);
            }
            else if (_module != null)
            {
                Serialize(_module);
            }
            else if (_member is Type type)
            {
                Serialize(type);
            }
            else if (_member is ConstructorInfo constructor)
            {
                Serialize(constructor);
            }
            else if (_member is FieldInfo field)
            {
                Serialize(field);
            }
            else if (_member is PropertyInfo property)
            {
                Serialize(property);
            }
            else if (_member is MethodInfo method)
            {
                Serialize(method);
            }
            else if (_member is EventInfo @event)
            {
                Serialize(@event);
            }

            _ownerSignature = _owner is null ? string.Empty : _owner.ToStringRaw();
            _returnSignature = _return is null ? string.Empty : _return.ToStringRaw();

            if (_parameters != null)
            {
                _parameterSignatures = new string[_parameters.Length];
                for (int i = 0; i < _parameterSignatures.Length; ++i)
                {
                    _parameterSignatures[i] = _parameters[i].ToStringRaw();
                }
            }
            else
            {
                _parameterSignatures = Array.Empty<string>();
            }

            if (_genericArguments != null)
            {
                _genericArgumentSignatures = new string[_genericArguments.Length];
                for (int i = 0; i < _genericArgumentSignatures.Length; ++i)
                {
                    _genericArgumentSignatures[i] = _genericArguments[i].ToStringRaw();
                }
            }
            else
            {
                _genericArgumentSignatures = Array.Empty<string>();
            }
        }

        private void Serialize(Assembly assembly)
        {
            _signatureType = SignatureType.Assembly;
            _name = assembly.FullName;
        }

        private void Serialize(Module module)
        {
            _signatureType = SignatureType.Module;
            _owner = new ReflectionSignature(module.Assembly);
            _name = module.Name;
        }

        private void Serialize(Type type)
        {
            if (!type.ContainsGenericParameters || type.IsGenericTypeDefinition)
            {
                _signatureType = SignatureType.Type;
                _name = type.AssemblyQualifiedName;
                return;
            }

            if (type.IsGenericParameter)
            {
                _count = type.GenericParameterPosition;

                if (type.IsGenericTypeParameterFast())
                {
                    _signatureType = SignatureType.GenericTypeParameter;
                    _owner = new ReflectionSignature(type.DeclaringType);
                    return;
                }

                if (type.IsGenericParameterDeclaringFrom(_genericOwner))
                {
                    _signatureType = SignatureType.OwnedGenericMethodParameter;
                }
                else
                {
                    _signatureType = SignatureType.GenericMethodParameter;
                    _owner = new ReflectionSignature(type.DeclaringMethod);
                }
                return;
            }

            if (type.HasElementType)
            {
                _owner = new ReflectionSignature(type.GetElementType(), _genericOwner);
                if (type.IsSZArray)
                {
                    _signatureType = SignatureType.SZArrayContainingGenericParameter;
                    return;
                }

                if (type.IsArray)
                {
                    _signatureType = SignatureType.ArrayContainingGenericParameter;
                    _count = type.GetArrayRank();
                    return;
                }

                if (type.IsPointer)
                {
                    _signatureType = SignatureType.PointerContainingGenericParameter;
                    return;
                }

                if (type.IsByRef)
                {
                    _signatureType = SignatureType.ByRefContainingGenericParameter;
                    return;
                }
            }

            if (type.IsGenericType)
            {
                _signatureType = SignatureType.GenericInstanceTypeContainingGenericParameter;
                _owner = new ReflectionSignature(type.GetGenericTypeDefinition());
                var genericArguments = type.GetGenericArgumentsFast();
                _genericArguments = new ReflectionSignature[genericArguments.Count];
                for (int i = 0; i < genericArguments.Count; ++i)
                {
                    _genericArguments[i] = new ReflectionSignature(genericArguments[i], _genericOwner);
                }
                return;
            }
        }

        private void Serialize(ConstructorInfo constructor)
        {
            _owner = new ReflectionSignature(constructor.DeclaringType);
            if (constructor.IsStatic)
            {
                _signatureType = SignatureType.StaticConstructor;
                return;
            }

            _signatureType = SignatureType.Constructor;
            var parameters = constructor.GetParametersFast();
            _parameters = new ReflectionSignature[parameters.Count];
            for (int i = 0; i < parameters.Count; ++i)
            {
                var parameterType = parameters[i].ParameterType;
                _parameters[i] = new ReflectionSignature(parameterType);
            }
        }

        private void Serialize(FieldInfo field)
        {
            _signatureType = SignatureType.Field;
            _name = field.Name;
            _owner = new ReflectionSignature(field.DeclaringType);
        }

        private void Serialize(PropertyInfo property)
        {
            _name = property.Name;
            _owner = new ReflectionSignature(property.DeclaringType);
            var parameters = property.GetIndexParametersFast();
            if (!parameters.Any())
            {
                _signatureType = SignatureType.Property;
                return;
            }

            _signatureType = SignatureType.IndexerProperty;
            _parameters = new ReflectionSignature[parameters.Count];
            for (int i = 0; i < parameters.Count; ++i)
            {
                var parameterType = parameters[i].ParameterType;
                _parameters[i] = new ReflectionSignature(parameterType);
            }
        }

        private void Serialize(MethodInfo method)
        {
            var genericArguments = method.GetGenericArgumentsFast();
            if (method.IsGenericInstanceMethod())
            {
                _signatureType = SignatureType.GenericInstanceMethod;
                _owner = new ReflectionSignature(method.GetGenericMethodDefinitionFast());
                _genericArguments = new ReflectionSignature[genericArguments.Count];
                for (int i = 0; i < _genericArguments.Length; ++i)
                {
                    _genericArguments[i] = new ReflectionSignature(genericArguments[i]);
                }
                return;
            }

            var parameters = method.GetParametersFast();
            _owner = new ReflectionSignature(method.DeclaringType);
            _parameters = new ReflectionSignature[parameters.Count];
            bool isContainingOwnedGenericParameter = false;
            for (int i = 0; i < parameters.Count; ++i)
            {
                var parameterType = parameters[i].ParameterType;
                _parameters[i] = new ReflectionSignature(parameterType, method);
                if (!isContainingOwnedGenericParameter && ContainsGenericParameterOwner(parameterType, method))
                {
                    isContainingOwnedGenericParameter = true;
                }
            }

            _name = method.Name;
            _count = genericArguments.Count;

            if (method.IsOperator())
            {
                _return = new ReflectionSignature(method.ReturnType, method);
                if (!isContainingOwnedGenericParameter && ContainsGenericParameterOwner(method.ReturnType, method))
                {
                    isContainingOwnedGenericParameter = true;
                }

                if (isContainingOwnedGenericParameter)
                {
                    _signatureType = SignatureType.OperatorMethodContainingOwnedGenericParameter;
                    return;
                }

                _signatureType = SignatureType.OperatorMethod;
                return;
            }

            if (isContainingOwnedGenericParameter)
            {
                _signatureType = SignatureType.MethodContainingOwnedGenericParameter;
                return;
            }

            _signatureType = SignatureType.Method;
        }

        private void Serialize(EventInfo @event)
        {
            _signatureType = SignatureType.Event;
            _name = @event.Name;
            _owner = new ReflectionSignature(@event.DeclaringType);
        }

        void ISerializationCallbackReceiver.OnAfterDeserialize()
        {
            _owner = string.IsNullOrEmpty(_ownerSignature) ? null : FromStringRaw(_ownerSignature);
            _return = string.IsNullOrEmpty(_returnSignature) ? null : FromStringRaw(_returnSignature);
            if (_parameterSignatures != null)
            {
                _parameters = new ReflectionSignature[_parameterSignatures.Length];
                for (int i = 0; i < _parameters.Length; ++i)
                {
                    _parameters[i] = FromStringRaw(_parameterSignatures[i]);
                }
            }
            else
            {
                _parameters = Array.Empty<ReflectionSignature>();
            }

            if (_genericArgumentSignatures != null)
            {
                _genericArguments = new ReflectionSignature[_genericArgumentSignatures.Length];
                for (int i = 0; i < _genericArguments.Length; ++i)
                {
                    _genericArguments[i] = FromStringRaw(_genericArgumentSignatures[i]);
                }
            }
            else
            {
                _genericArguments = Array.Empty<ReflectionSignature>();
            }

            switch (_signatureType)
            {
                case SignatureType.Assembly:
                    _assembly = DeserializeToAssembly();
                    _module = null;
                    _member = null;
                    break;
                case SignatureType.Module:
                    _assembly = null;
                    _module = DeserializeToModule();
                    _member = null;
                    break;
                case SignatureType.Type:
                    _assembly = null;
                    _module = null;
                    _member = DeserializeToType();
                    break;
                case SignatureType.SZArrayContainingGenericParameter:
                    _assembly = null;
                    _module = null;
                    _member = DeserializeToSZArrayContainingGenericParameter();
                    break;
                case SignatureType.ArrayContainingGenericParameter:
                    _assembly = null;
                    _module = null;
                    _member = DeserializeToArrayContainingGenericParameter();
                    break;
                case SignatureType.PointerContainingGenericParameter:
                    _assembly = null;
                    _module = null;
                    _member = DeserializeToPointerContainingGenericParameter();
                    break;
                case SignatureType.ByRefContainingGenericParameter:
                    _assembly = null;
                    _module = null;
                    _member = DeserializeToByRefContainingGenericParameter();
                    break;
                case SignatureType.GenericInstanceTypeContainingGenericParameter:
                    _assembly = null;
                    _module = null;
                    _member = DeserializeToGenericInstanceTypeContainingGenericParameter();
                    break;
                case SignatureType.GenericTypeParameter:
                    _assembly = null;
                    _module = null;
                    _member = DeserializeToGenericTypeParameter();
                    break;
                case SignatureType.GenericMethodParameter:
                    _assembly = null;
                    _module = null;
                    _member = DeserializeToGenericMethodParameter();
                    break;
                case SignatureType.Constructor:
                    _assembly = null;
                    _module = null;
                    _member = DeserializeToConstructor();
                    break;
                case SignatureType.StaticConstructor:
                    _assembly = null;
                    _module = null;
                    _member = DeserializeToStaticConstructor();
                    break;
                case SignatureType.Field:
                    _assembly = null;
                    _module = null;
                    _member = DeserializeToField();
                    break;
                case SignatureType.Property:
                    _assembly = null;
                    _module = null;
                    _member = DeserializeToProperty();
                    break;
                case SignatureType.IndexerProperty:
                    _assembly = null;
                    _module = null;
                    _member = DeserializeToIndexerProperty();
                    break;
                case SignatureType.Method:
                    _assembly = null;
                    _module = null;
                    _member = DeserializeToMethod();
                    break;
                case SignatureType.OperatorMethod:
                    _assembly = null;
                    _module = null;
                    _member = DeserializeToOperatorMethod();
                    break;
                case SignatureType.GenericInstanceMethod:
                    _assembly = null;
                    _module = null;
                    _member = DeserializeToGenericInstanceMethod();
                    break;
                case SignatureType.MethodContainingOwnedGenericParameter:
                    _assembly = null;
                    _module = null;
                    _member = DeserializeToMethodContainingOwnedGenericParameter();
                    break;
                case SignatureType.OperatorMethodContainingOwnedGenericParameter:
                    _assembly = null;
                    _module = null;
                    _member = DeserializeToOperatorMethodContainingOwnedGenericParameter();
                    break;
                case SignatureType.Event:
                    _assembly = null;
                    _module = null;
                    _member = DeserializeToEvent();
                    break;
            }
        }

        private Assembly DeserializeToAssembly()
        {
            try
            {
                return REReflection.GetAssembliesWithMoved(_name).FirstOrDefault();
            }
            catch
            {
                return null;
            }
        }

        private Module DeserializeToModule()
        {
            Assembly assembly = _owner;
            return assembly.GetModuleFast(_name);
        }

        private Type DeserializeToType()
        {
            return REType.GetTypeWithMoved(_name);
        }

        private Type DeserializeToSZArrayContainingGenericParameter()
        {
            Type elementType = _owner;
            if (elementType == null)
            {
                return null;
            }
            return elementType.MakeArrayType();
        }

        private Type DeserializeToArrayContainingGenericParameter()
        {
            Type elementType = _owner;
            if (elementType == null)
            {
                return null;
            }
            var rank = _count;
            return elementType.MakeArrayType(rank);
        }

        private Type DeserializeToPointerContainingGenericParameter()
        {
            Type elementType = _owner;
            if (elementType == null)
            {
                return null;
            }
            return elementType.MakePointerType();
        }

        private Type DeserializeToByRefContainingGenericParameter()
        {
            Type elementType = _owner;
            if (elementType == null)
            {
                return null;
            }
            return elementType.MakeByRefType();
        }

        private Type DeserializeToGenericInstanceTypeContainingGenericParameter()
        {
            Type elementType = _owner;
            if (elementType == null)
            {
                return null;
            }
            var genericArguments = REReflection.GetArrayCache<Type>(_genericArguments.Length);
            for (int i = 0; i < genericArguments.Length; ++i)
            {
                genericArguments[i] = _genericArguments[i];
                if (genericArguments[i] == null)
                {
                    return null;
                }
            }
            return elementType.MakeGenericTypeFast(genericArguments);
        }

        private Type DeserializeToGenericTypeParameter()
        {
            Type type = _owner;
            return type.GetGenericArgumentsFast()[_count];
        }

        private Type DeserializeToGenericMethodParameter()
        {
            MethodInfo method = _owner;
            return method.GetGenericArgumentsFast()[_count];
        }

        private Type DeserializeToType(MethodInfo genericOwner)
        {
            if (_member != null)
            {
                return _member as Type;
            }

            switch (_signatureType)
            {
                case SignatureType.SZArrayContainingGenericParameter:
                    return DeserializeToSZArrayContainingGenericParameter(genericOwner);
                case SignatureType.ArrayContainingGenericParameter:
                    return DeserializeToArrayContainingGenericParameter(genericOwner);
                case SignatureType.PointerContainingGenericParameter:
                    return DeserializeToPointerContainingGenericParameter(genericOwner);
                case SignatureType.ByRefContainingGenericParameter:
                    return DeserializeToByRefContainingGenericParameter(genericOwner);
                case SignatureType.GenericInstanceTypeContainingGenericParameter:
                    return DeserializeToGenericInstanceTypeContainingGenericParameter(genericOwner);
                case SignatureType.OwnedGenericMethodParameter:
                    return DeserializeToOwnedGenericMethodParameter(genericOwner);
            }

            return null;
        }

        private Type DeserializeToSZArrayContainingGenericParameter(MethodInfo genericOwner)
        {
            Type elementType = _owner.DeserializeToType(genericOwner);
            return elementType.MakeArrayType();
        }

        private Type DeserializeToArrayContainingGenericParameter(MethodInfo genericOwner)
        {
            Type elementType = _owner.DeserializeToType(genericOwner);
            var rank = _count;
            return elementType.MakeArrayType(rank);
        }

        private Type DeserializeToPointerContainingGenericParameter(MethodInfo genericOwner)
        {
            Type elementType = _owner.DeserializeToType(genericOwner);
            return elementType.MakePointerType();
        }

        private Type DeserializeToByRefContainingGenericParameter(MethodInfo genericOwner)
        {
            Type elementType = _owner.DeserializeToType(genericOwner);
            return elementType.MakeByRefType();
        }

        private Type DeserializeToGenericInstanceTypeContainingGenericParameter(MethodInfo genericOwner)
        {
            var size = _genericArguments.Length;
            Type elementType = _owner.DeserializeToType(genericOwner);
            var shared = ArrayPool<Type>.Shared;
            var genericArgumentsTmp = shared.Rent(size);
            try
            {
                for (int i = 0; i < _genericArguments.Length; ++i)
                {
                    genericArgumentsTmp[i] = _genericArguments[i].DeserializeToType(genericOwner);
                }

                var genericArguments = REReflection.GetArrayCache<Type>(size);
                for (int i = 0; i < genericArguments.Length; ++i)
                {
                    genericArguments[i] = genericArgumentsTmp[i];
                }

                return elementType.MakeGenericTypeFast(genericArguments);
            }
            finally
            {
                shared.Return(genericArgumentsTmp);
            }
        }

        private Type DeserializeToOwnedGenericMethodParameter(MethodInfo genericOwner)
        {
            return genericOwner.GetGenericArgumentsFast()[_count];
        }

        private ConstructorInfo DeserializeToConstructor()
        {
            Type ownerType = _owner;
            var parameters = REReflection.GetArrayCache<Type>(_parameters.Length);
            for (int i = 0; i < parameters.Length; ++i)
            {
                parameters[i] = _parameters[i];
            }
            return ownerType.GetInstanceConstructorFullAccess(parameters);
        }

        private ConstructorInfo DeserializeToStaticConstructor()
        {
            Type ownerType = _owner;
            return ownerType.GetStaticConstructorFullAccess(ArrayCache.Types0);
        }

        private FieldInfo DeserializeToField()
        {
            Type ownerType = _owner;
            return ownerType.GetFieldWithMovedFullAccess(_name);
        }

        private PropertyInfo DeserializeToProperty()
        {
            Type ownerType = _owner;
            var properties = ownerType.GetPropertiesFullAccess();
            foreach (var property in properties)
            {
                if (property.Name != _name)
                {
                    continue;
                }

                var parameterCount = property.GetIndexParameterCount();
                if (parameterCount != 0)
                {
                    continue;
                }

                return property;
            }

            return null;
        }

        private PropertyInfo DeserializeToIndexerProperty()
        {
            Type ownerType = _owner;
            var parameters = REReflection.GetArrayCache<Type>(_parameters.Length);
            for (int i = 0; i < parameters.Length; ++i)
            {
                parameters[i] = _parameters[i];
            }
            var properties = ownerType.GetPropertiesFullAccess();
            foreach (var property in properties)
            {
                if (property.Name != _name)
                {
                    continue;
                }

                var propertyParameters = property.GetIndexParametersFast();
                if (propertyParameters.Count != parameters.Length)
                {
                    continue;
                }

                bool found = false;
                for (int i = 0; i < parameters.Length; ++i)
                {
                    if (propertyParameters[i].ParameterType != parameters[i])
                    {
                        found = true;
                        break;
                    }
                }

                if (found)
                {
                    continue;
                }

                return property;
            }

            return null;
        }

        private MethodInfo DeserializeToMethod()
        {
            Type ownerType = _owner;
            var parameters = REReflection.GetArrayCache<Type>(_parameters.Length);
            for (int i = 0; i < parameters.Length; ++i)
            {
                parameters[i] = _parameters[i];
            }
            return ownerType.GetMethodFullAccess(_name, _count, null, parameters, null);
        }

        private MethodInfo DeserializeToOperatorMethod()
        {
            Type ownerType = _owner;
            Type returnType = _return;
            var parameters = REReflection.GetArrayCache<Type>(_parameters.Length);
            for (int i = 0; i < parameters.Length; ++i)
            {
                parameters[i] = _parameters[i];
            }

            var methods = ownerType.GetMethodsFullAccess();
            foreach (var method in methods)
            {
                if (method.ReturnType != returnType)
                {
                    continue;
                }

                if (method.Name != _name)
                {
                    continue;
                }

                var methodParameters = method.GetParametersFast();
                if (methodParameters.Count != parameters.Length)
                {
                    continue;
                }

                bool found = false;
                for (int i = 0; i < parameters.Length; ++i)
                {
                    if (methodParameters[i].ParameterType != parameters[i])
                    {
                        found = true;
                        break;
                    }
                }

                if (found)
                {
                    continue;
                }

                return method;
            }

            return null;
        }

        private MethodInfo DeserializeToGenericInstanceMethod()
        {
            MethodInfo genericMethod = _owner;
            var genericArguments = REReflection.GetArrayCache<Type>(_genericArguments.Length);
            for (int i = 0; i < genericArguments.Length; ++i)
            {
                genericArguments[i] = _genericArguments[i];
            }
            return genericMethod.MakeGenericMethodFast(genericArguments);
        }

        private MethodInfo DeserializeToMethodContainingOwnedGenericParameter()
        {
            Type ownerType = _owner;
            var shared = ArrayPool<Type>.Shared;
            var size = _parameters.Length;
            var parameters = shared.Rent(size);
            try
            {
                for (int i = 0; i < size; ++i)
                {
                    parameters[i] = _parameters[i];
                }

                var methods = ownerType.GetMethodsFullAccess();
                foreach (var method in methods)
                {
                    if (method.Name != _name)
                    {
                        continue;
                    }

                    var genArgs = method.GetGenericArgumentsFast();
                    if (genArgs.Count != _count)
                    {
                        continue;
                    }

                    var methodParameters = method.GetParametersFast();
                    if (methodParameters.Count != size)
                    {
                        continue;
                    }

                    bool found = false;
                    for (int i = 0; i < size; ++i)
                    {
                        var rebuild = parameters[i] == null;
                        if (rebuild)
                        {
                            var parameterType = _parameters[i];
                            parameters[i] = parameterType.DeserializeToType(method);
                        }

                        try
                        {
                            if (methodParameters[i].ParameterType != parameters[i])
                            {
                                found = true;
                                break;
                            }
                        }
                        finally
                        {
                            if (rebuild)
                            {
                                parameters[i] = null;
                            }
                        }
                    }

                    if (found)
                    {
                        continue;
                    }

                    return method;
                }
            }
            finally
            {
                shared.Return(parameters);
            }

            return null;
        }

        private MethodInfo DeserializeToOperatorMethodContainingOwnedGenericParameter()
        {
            Type ownerType = _owner;
            Type returnType = _return;

            var shared = ArrayPool<Type>.Shared;
            var size = _parameters.Length;
            var parameters = shared.Rent(size);
            try
            {
                for (int i = 0; i < size; ++i)
                {
                    parameters[i] = _parameters[i];
                }

                var methods = ownerType.GetMethodsFullAccess();
                foreach (var method in methods)
                {
                    if (method.ReturnType != returnType)
                    {
                        continue;
                    }

                    if (method.Name != _name)
                    {
                        continue;
                    }

                    var genArgs = method.GetGenericArgumentsFast();
                    if (genArgs.Count != _count)
                    {
                        continue;
                    }

                    var methodParameters = method.GetParametersFast();
                    if (methodParameters.Count != size)
                    {
                        continue;
                    }

                    bool found = false;
                    for (int i = 0; i < size; ++i)
                    {
                        var rebuild = parameters[i] == null;
                        if (rebuild)
                        {
                            var parameterType = _parameters[i];
                            parameters[i] = parameterType.DeserializeToType(method);
                        }

                        try
                        {
                            if (methodParameters[i].ParameterType != parameters[i])
                            {
                                found = true;
                                break;
                            }
                        }
                        finally
                        {
                            if (rebuild)
                            {
                                parameters[i] = null;
                            }
                        }
                    }

                    if (found)
                    {
                        continue;
                    }

                    return method;
                }
            }
            finally
            {
                shared.Return(parameters);
            }

            return null;
        }

        private EventInfo DeserializeToEvent()
        {
            Type ownerType = _owner;
            return ownerType.GetEventFullAccess(_name);
        }

        public static bool operator ==(ReflectionSignature l, ReflectionSignature r)
        {
            if (!(l is null))
            {
                return l.Equals(r);
            }

            if (!(r is null))
            {
                return r.Equals(l);
            }

            return true;
        }

        public static bool operator !=(ReflectionSignature l, ReflectionSignature r)
        {
            if (!(l is null))
            {
                return !l.Equals(r);
            }

            if (!(r is null))
            {
                return !r.Equals(l);
            }

            return false;
        }

        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                return IsNull();
            }

            if (obj is ReflectionSignature signature)
            {
                return Equals(signature);
            }

            return false;
        }

        public bool Equals(ReflectionSignature other)
        {
            if (other is null)
            {
                return IsNull();
            }

            if (_assembly != null)
            {
                return _assembly == other._assembly;
            }

            if (_module != null)
            {
                return _module == other._module;
            }

            if (_member != null)
            {
                if (_member is Type lt && other._member is Type rt)
                {
                    return lt.TypeHandle.Value == rt.TypeHandle.Value;
                }

                if (_member is FieldInfo lf && other._member is FieldInfo rf)
                {
                    return lf.FieldHandle == rf.FieldHandle;
                }

                if (_member is PropertyInfo lp && other._member is PropertyInfo rp)
                {
                    return lp.GetGetMethod(true)?.MethodHandle == rp.GetGetMethod(true)?.MethodHandle ||
                           lp.GetSetMethod(true)?.MethodHandle == rp.GetSetMethod(true)?.MethodHandle ||
                           lp.GetAccessorsFullAccess().Select(v => v.MethodHandle).SequenceEqual(rp.GetAccessorsFullAccess().Select(v => v.MethodHandle));
                }

                if (_member is MethodBase lm && other._member is MethodBase rm)
                {
                    return lm.MethodHandle == rm.MethodHandle;
                }

                if (_member is EventInfo le && other._member is EventInfo re)
                {
                    return le.GetAddMethod(true)?.MethodHandle == re.GetAddMethod(true)?.MethodHandle ||
                           le.GetRemoveMethod(true)?.MethodHandle == re.GetRemoveMethod(true)?.MethodHandle ||
                           le.GetOtherMethodsFullAccess().Select(v => v.MethodHandle).SequenceEqual(re.GetOtherMethodsFullAccess().Select(v => v.MethodHandle));
                }

                return _member == other._member;
            }

            return other.IsNull();
        }

        public override int GetHashCode()
        {
            if (_assembly != null)
            {
                return _assembly.GetHashCode();
            }

            if (_module != null)
            {
                return _module.GetHashCode();
            }

            if (_member != null)
            {
                if (_member is Type t)
                {
                    return t.TypeHandle.Value.GetHashCode();
                }

                if (_member is FieldInfo f)
                {
                    return f.FieldHandle.GetHashCode();
                }

                if (_member is PropertyInfo p)
                {
                    return (p.GetMethod ?? p.SetMethod).MethodHandle.GetHashCode();
                }

                if (_member is MethodBase m)
                {
                    return m.MethodHandle.GetHashCode();
                }

                if (_member is EventInfo e)
                {
                    return (e.AddMethod ?? e.RemoveMethod ?? e.RaiseMethod).MethodHandle.GetHashCode();
                }

                return _member.GetHashCode();
            }

            return 0;
        }

        private bool IsNull()
        {
            return _assembly == null && _module == null && _member == null;
        }

        private static bool ContainsGenericParameterOwner(Type target, MethodInfo owner)
        {
            if (!target.ContainsGenericParameters)
            {
                return false;
            }

            if (target.IsGenericParameterDeclaringFrom(owner))
            {
                return true;
            }

            if (target.IsArray || target.IsPointer || target.IsByRef)
            {
                return ContainsGenericParameterOwner(target.GetElementType(), owner);
            }

            if (target.IsGenericInstanceType())
            {
                foreach (var argument in target.GetGenericArgumentsFast())
                {
                    if (ContainsGenericParameterOwner(argument, owner))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}

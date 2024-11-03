using Katuusagi.ConstExpressionForUnity;
using Katuusagi.ILPostProcessorCommon;
using Katuusagi.MemoizationForUnity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Katuusagi.ReflectionEnhance
{
    public static partial class REMethodInfo
    {
        private static HashSet<string> OperatorOverLoadNames = new HashSet<string>()
        {
            "op_Implicit",
            "op_Explicit",
            "op_Addition",
            "op_Subtraction",
            "op_Multiply",
            "op_Division",
            "op_Modulus",
            "op_LeftShift",
            "op_RightShift",
            "op_LessThan",
            "op_GreaterThan",
            "op_LessThanOrEqual",
            "op_GreaterThanOrEqual",
            "op_Equality",
            "op_Inequality",
            "op_BitwiseAnd",
            "op_ExclusiveOr",
            "op_BitwiseOr",
            "op_LogicalNot",
            "op_Addition",
            "op_Subtraction",
            "op_Multiply",
            "op_Division",
            "op_Modulus",
            "op_BitwiseAnd",
            "op_ExclusiveOr",
            "op_BitwiseOr",
            "op_LeftShift",
            "op_RightShift",
            "op_UnaryNegation",
            "op_UnaryPlus",
            "op_OnesComplement",
            "op_True",
            "op_False",
            "op_Increment",
            "op_Decrement",
        };

        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasReturn(this MethodInfo self)
        {
            return self.ReturnType != typeof(void);
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] { "Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)" })]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetGenericMethodDefinitionFastRaw(this MethodInfo self)
        {
#if ENABLE_IL2CPP
            var dec = self.DeclaringType;
            if (!dec.IsGenericInstanceType())
            {
                return self.GetGenericMethodDefinition();
            }

            Type ReplaceGeneric(Type genType, ReadOnlyArray<Type> types)
            {
                if (genType.IsGenericTypeParameterFast())
                {
                    var p = genType.GenericParameterPosition;
                    return types[p];
                }

                if (genType.ContainsGenericParameters)
                {
                    if (genType.IsGenericInstanceType())
                    {
                        var genArgs = genType.GetGenericArgumentsFast().ToArray();
                        for (int i = 0; i < genArgs.Length; ++i)
                        {
                            genArgs[i] = ReplaceGeneric(genArgs[i], types);
                        }

                        return genType.GetGenericTypeDefinitionFast().MakeGenericTypeFast(genArgs);
                    }

                    if (genType.HasElementType)
                    {
                        var elementType = genType.GetElementType();
                        elementType = ReplaceGeneric(elementType, types);
                        if (genType.IsSZArray)
                        {
                            return elementType.MakeArrayType();
                        }

                        if (genType.IsArray)
                        {
                            return elementType.MakeArrayType(genType.GetArrayRank());
                        }

                        if (genType.IsPointer)
                        {
                            return elementType.MakePointerType();
                        }

                        if (genType.IsByRef)
                        {
                            return elementType.MakeByRefType();
                        }
                    }
                }

                return genType;
            }

            var argTypes = dec.GetGenericArgumentsFast();

            var method = self.GetGenericMethodDefinition();
            var genCount = method.GetGenericArgumentsFast().Count;
            var returnType = ReplaceGeneric(method.ReturnType, argTypes);
            var parameterTypes = method.GetParameterTypes().Select(v => ReplaceGeneric(v, argTypes)).ToArray();
            var genMethodDef = dec.GetMethodsFullAccess().FirstOrDefault(v => v.Name == method.Name && v.GetGenericArgumentsFast().Count == genCount && v.ReturnType == returnType && v.GetParameterTypes().SequenceEqual(parameterTypes));
            return genMethodDef;
#else
            return self.GetGenericMethodDefinition();
#endif
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] { "Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)" })]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<MethodInfo> GetBaseDefinitionsRaw(this MethodInfo self)
        {
            if (self == null)
            {
                return Array.Empty<MethodInfo>();
            }

            var baseMethod = self.GetBaseDefinition();
            var baseMethods = baseMethod.GetBaseDefinitions();
            return baseMethods.Prepend(baseMethod).ToArray();
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] { "Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)" })]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<MethodInfo> GetBaseDefinitionsAndSelfRaw(this MethodInfo self)
        {
            var baseMethods = self.GetBaseDefinitions();
            return baseMethods.Prepend(self).ToArray();
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<ParameterInfo> GetAllParametersRaw(this MethodInfo self)
        {
            return self.GetParametersFast().Append(self.ReturnParameter).ToArray();
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] { "Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)" })]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<Type> GetAllParameterTypesRaw(this MethodInfo self)
        {
            return self.GetAllParameters().Select(v => v.ParameterType).ToArray();
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] { "Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)" })]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static int GetAllParameterCountRaw(this MethodInfo self)
        {
            return self.GetAllParameters().Count;
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] { "Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)" })]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool HasParameterInAllRaw(this MethodInfo self)
        {
            return self.GetAllParameters().Any();
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] { "Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)" })]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool HasByRefParameterInAllRaw(this MethodInfo self)
        {
            return self.GetAllParameters().Any(v => v.ParameterType.IsByRef);
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo MakeGenericMethodFastRaw(this MethodInfo self, params Type[] types)
        {
            return self.MakeGenericMethod(types);
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] { "Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)" })]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool IsGenericInstanceMethodRaw(this MethodInfo method)
        {
            return !method.IsGenericMethodDefinition && method.IsGenericMethod;
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] { "Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)" })]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool IsOperatorRaw(this MethodInfo method)
        {
            return method.IsSpecialName && method.IsStatic && OperatorOverLoadNames.Contains(method.Name);
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] { "Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)" })]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool IsIndexerRaw(this MethodInfo method)
        {
            return method.IsSpecialName &&
                (
                    (method.Name == "get_Item" && method.GetParameterCount() >= 1) ||
                    (method.Name == "set_Item" && method.GetParameterCount() >= 2)
                );
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool IsCompatibleRaw(this MethodInfo m, Type retType, params Type[] parameterTypes)
        {
            if (m == null || m.ReturnType != retType)
            {
                return false;
            }

            parameterTypes = parameterTypes ?? ArrayCache.Types0;

            var methodParameterTypes = m.GetParameterTypes();
            if (methodParameterTypes.Count != parameterTypes.Length)
            {
                return false;
            }

            return methodParameterTypes.SequenceEqual(parameterTypes);
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] { "Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)" })]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool IsPropertyRaw(this MethodInfo m)
        {
            if (m == null)
            {
                return false;
            }

            if (m.Name.StartsWith("get_", StringComparison.Ordinal))
            {
                var properties = m.DeclaringType.GetPropertiesWithBaseFullAccess();
                foreach (var property in properties)
                {
                    var method = property.GetMethod;
                    if (method == null)
                    {
                        continue;
                    }

                    if (method.MethodHandle.Value == m.MethodHandle.Value)
                    {
                        return true;
                    }
                }
            }

            if (m.Name.StartsWith("set_", StringComparison.Ordinal))
            {
                var properties = m.DeclaringType.GetPropertiesWithBaseFullAccess();
                foreach (var property in properties)
                {
                    var method = property.SetMethod;
                    if (method == null)
                    {
                        continue;
                    }

                    if (method.MethodHandle.Value == m.MethodHandle.Value)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}

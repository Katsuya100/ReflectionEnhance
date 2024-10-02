using Katuusagi.ILPostProcessorCommon;
using Katuusagi.MemoizationForUnity;
using Katuusagi.Pool;
using Katuusagi.ReflectionEnhance.Utils;
using System;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Katuusagi.ReflectionEnhance
{
    public static partial class REDelegate
    {
        private static Type[] Actions = new Type[]
        {
            typeof(Action),
            typeof(Action<>),
            typeof(Action<,>),
            typeof(Action<,,>),
            typeof(Action<,,,>),
            typeof(Action<,,,,>),
            typeof(Action<,,,,,>),
            typeof(Action<,,,,,,>),
            typeof(Action<,,,,,,,>),
            typeof(Action<,,,,,,,,>),
            typeof(Action<,,,,,,,,,>),
            typeof(Action<,,,,,,,,,,>),
            typeof(Action<,,,,,,,,,,,>),
            typeof(Action<,,,,,,,,,,,,>),
            typeof(Action<,,,,,,,,,,,,,>),
            typeof(Action<,,,,,,,,,,,,,,>),
            typeof(Action<,,,,,,,,,,,,,,,>),
        };

        private static Type[] Funcs = new Type[]
        {
            typeof(Func<>),
            typeof(Func<,>),
            typeof(Func<,,>),
            typeof(Func<,,,>),
            typeof(Func<,,,,>),
            typeof(Func<,,,,,>),
            typeof(Func<,,,,,,>),
            typeof(Func<,,,,,,,>),
            typeof(Func<,,,,,,,,>),
            typeof(Func<,,,,,,,,,>),
            typeof(Func<,,,,,,,,,,>),
            typeof(Func<,,,,,,,,,,,>),
            typeof(Func<,,,,,,,,,,,,>),
            typeof(Func<,,,,,,,,,,,,,>),
            typeof(Func<,,,,,,,,,,,,,,>),
            typeof(Func<,,,,,,,,,,,,,,,>),
            typeof(Func<,,,,,,,,,,,,,,,,>),
        };

        private static Type[] AbstractActions = new Type[]
        {
            typeof(Action),
            typeof(Action<object>),
            typeof(Action<object, object>),
            typeof(Action<object, object ,object>),
            typeof(Action<object, object ,object ,object>),
            typeof(Action<object, object ,object ,object ,object>),
            typeof(Action<object, object ,object ,object ,object ,object>),
            typeof(Action<object, object ,object ,object ,object ,object ,object>),
            typeof(Action<object, object ,object ,object ,object ,object ,object ,object>),
            typeof(Action<object, object ,object ,object ,object ,object ,object ,object ,object>),
            typeof(Action<object, object ,object ,object ,object ,object ,object ,object ,object ,object>),
            typeof(Action<object, object ,object ,object ,object ,object ,object ,object ,object ,object ,object>),
            typeof(Action<object, object ,object ,object ,object ,object ,object ,object ,object ,object ,object ,object>),
            typeof(Action<object, object ,object ,object ,object ,object ,object ,object ,object ,object ,object ,object ,object>),
            typeof(Action<object, object ,object ,object ,object ,object ,object ,object ,object ,object ,object ,object ,object ,object>),
            typeof(Action<object, object ,object ,object ,object ,object ,object ,object ,object ,object ,object ,object ,object ,object ,object>),
            typeof(Action<object, object ,object ,object ,object ,object ,object ,object ,object ,object ,object ,object ,object ,object ,object ,object>),
        };

        private static Type[] AbstractFuncs = new Type[]
        {
            typeof(Func<object>),
            typeof(Func<object, object>),
            typeof(Func<object, object ,object>),
            typeof(Func<object, object ,object ,object>),
            typeof(Func<object, object ,object ,object ,object>),
            typeof(Func<object, object ,object ,object ,object ,object>),
            typeof(Func<object, object ,object ,object ,object ,object ,object>),
            typeof(Func<object, object ,object ,object ,object ,object ,object ,object>),
            typeof(Func<object, object ,object ,object ,object ,object ,object ,object ,object>),
            typeof(Func<object, object ,object ,object ,object ,object ,object ,object ,object ,object>),
            typeof(Func<object, object ,object ,object ,object ,object ,object ,object ,object ,object ,object>),
            typeof(Func<object, object ,object ,object ,object ,object ,object ,object ,object ,object ,object ,object>),
            typeof(Func<object, object ,object ,object ,object ,object ,object ,object ,object ,object ,object ,object ,object>),
            typeof(Func<object, object ,object ,object ,object ,object ,object ,object ,object ,object ,object ,object ,object ,object>),
            typeof(Func<object, object ,object ,object ,object ,object ,object ,object ,object ,object ,object ,object ,object ,object ,object>),
            typeof(Func<object, object ,object ,object ,object ,object ,object ,object ,object ,object ,object ,object ,object ,object ,object ,object>),
            typeof(Func<object, object ,object ,object ,object ,object ,object ,object ,object ,object ,object ,object ,object ,object ,object ,object ,object>),
        };

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static TDelegate CreateDelegateFastRaw<TDelegate>(this MethodInfo method)
            where TDelegate : Delegate
        {
            return method.CreateDelegateFast(typeof(TDelegate)) as TDelegate;
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Delegate CreateDelegateFastRaw(this MethodInfo method, Type delegateType)
        {
            return method.CreateDelegate(delegateType);
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static TDelegate CreateDelegateFastRaw<TDelegate>(this MethodInfo method, object target)
            where TDelegate : Delegate
        {
            return method.CreateDelegateFast(typeof(TDelegate), target) as TDelegate;
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Delegate CreateDelegateFastRaw(this MethodInfo method, Type delegateType, object target)
        {
            return method.CreateDelegate(delegateType, target);
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static TDelegate CreateDelegateFastRaw<TDelegate, TTarget>(string methodName)
            where TDelegate : Delegate
        {
            if (string.IsNullOrEmpty(methodName) ||
                REType.ContainsGenericParametersFast<TDelegate>())
            {
                return null;
            }

            var invokeMethod = REType.GetInstanceMethodFullAccess<TDelegate>("Invoke");
            if (invokeMethod == null)
            {
                return null;
            }

            var ret = invokeMethod.ReturnType;
            var argTypes = REReflection.GetArrayCache(invokeMethod.GetParameterTypes());

            var method = REType.GetStaticMethodWithBaseFullAccess<TTarget>(methodName, null, argTypes, null);
            if (!method.IsCompatible(ret, argTypes))
            {
                return null;
            }

            var result = method.CreateDelegateFast<TDelegate>();
            return result;
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static TDelegate CreateDelegateFastRaw<TDelegate>(Type target, string methodName)
            where TDelegate : Delegate
        {
            if (target == null ||
                string.IsNullOrEmpty(methodName) ||
                REType.ContainsGenericParametersFast<TDelegate>())
            {
                return null;
            }

            var invokeMethod = REType.GetInstanceMethodFullAccess<TDelegate>("Invoke");
            if (invokeMethod == null)
            {
                return null;
            }

            var ret = invokeMethod.ReturnType;
            var argTypes = REReflection.GetArrayCache(invokeMethod.GetParameterTypes());

            var method = target.GetStaticMethodWithBaseFullAccess(methodName, null, argTypes, null);
            if (!method.IsCompatible(ret, argTypes))
            {
                return null;
            }

            var result = method.CreateDelegateFast<TDelegate>();
            return result;
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Delegate CreateDelegateFastRaw(Type delegateType, Type target, string methodName)
        {
            if (target == null ||
                string.IsNullOrEmpty(methodName) ||
                delegateType.IsAssignableFromFast<Delegate>() ||
                delegateType.ContainsGenericParameters)
            {
                return null;
            }

            var invokeMethod = delegateType.GetInstanceMethodFullAccess("Invoke");
            if (invokeMethod == null)
            {
                return null;
            }

            var ret = invokeMethod.ReturnType;
            var argTypes = REReflection.GetArrayCache(invokeMethod.GetParameterTypes());

            var method = target.GetStaticMethodWithBaseFullAccess(methodName, null, argTypes, null);
            if (!method.IsCompatible(ret, argTypes))
            {
                return null;
            }

            var result = method.CreateDelegateFast(delegateType);
            return result;
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static TDelegate CreateDelegateFastRaw<TDelegate>(object target, string methodName)
            where TDelegate : Delegate
        {
            if (target == null ||
                string.IsNullOrEmpty(methodName) ||
                REType.ContainsGenericParametersFast<TDelegate>())
            {
                return null;
            }

            var invokeMethod = REType.GetInstanceMethodFullAccess<TDelegate>("Invoke");
            if (invokeMethod == null)
            {
                return null;
            }

            var ret = invokeMethod.ReturnType;
            var argTypes = REReflection.GetArrayCache(invokeMethod.GetParameterTypes());

            var targetType = target.GetType();
            var method = targetType.GetInstanceMethodWithBaseFullAccess(methodName, null, argTypes, null);
            if (!method.IsCompatible(ret, argTypes))
            {
                return null;
            }

            var result = method.CreateDelegateFast<TDelegate>(target);
            return result;
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Delegate CreateDelegateFastRaw(Type delegateType, object target, string methodName)
        {
            if (target == null ||
                string.IsNullOrEmpty(methodName) ||
                delegateType.IsAssignableFromFast<Delegate>() ||
                delegateType.ContainsGenericParameters)
            {
                return null;
            }

            var invokeMethod = delegateType.GetInstanceMethodFullAccess("Invoke");
            if (invokeMethod == null)
            {
                return null;
            }

            var ret = invokeMethod.ReturnType;
            var argTypes = REReflection.GetArrayCache(invokeMethod.GetParameterTypes());

            var targetType = target.GetType();
            var method = targetType.GetInstanceMethodWithBaseFullAccess(methodName, null, argTypes, null);
            if (!method.IsCompatible(ret, argTypes))
            {
                return null;
            }

            var result = method.CreateDelegateFast(delegateType, target);
            return result;
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static T CreateDelegateFastRaw<T>(IntPtr pFunc)
            where T : Delegate
        {
            return CreateDelegateFast(typeof(T), null, pFunc) as T;
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Delegate CreateDelegateFastRaw(Type type, IntPtr pFunc)
        {
            return type.CreateInstance<Type, IntPtr>(null, pFunc) as Delegate;
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static T CreateDelegateFastRaw<T>(object target, IntPtr pFunc)
            where T : Delegate
        {
            return CreateDelegateFast(typeof(T), target, pFunc) as T;
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Delegate CreateDelegateFastRaw(Type type, object target, IntPtr pFunc)
        {
            return type.CreateInstance(target, pFunc) as Delegate;
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<TDelegate> CreateDelegatesByAttributeRaw<TDelegate, TAttribute>()
            where TDelegate : Delegate
            where TAttribute : Attribute
        {
            var invokeMethod = REType.GetMethodFullAccess<TDelegate>("Invoke");
            if (invokeMethod == null)
            {
                return Array.Empty<TDelegate>();
            }

            var retType = invokeMethod.ReturnType;
            var paramTypes = REReflection.GetArrayCache(invokeMethod.GetParameterTypes());
            var result = REReflection.GetAssembliesFast()
                            .AsSafeParallel()
                            .SelectMany(v => v.GetTypesFast())
                            .SelectMany(v => v.GetStaticMethodsFullAccess())
                            .Where(v => v.HasAttribute<TAttribute>() && v.IsCompatible(retType, paramTypes))
                            .Select(v => v.CreateDelegateFast<TDelegate>())
                            .ToArray();
            return result;
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<TDelegate> CreateDelegatesByAttributeRaw<TDelegate>(Type attributeType)
            where TDelegate : Delegate
        {
            var invokeMethod = REType.GetMethodFullAccess<TDelegate>("Invoke");
            if (invokeMethod == null || attributeType.IsAssignableFromFast<Attribute>())
            {
                return Array.Empty<TDelegate>();
            }

            var retType = invokeMethod.ReturnType;
            var paramTypes = REReflection.GetArrayCache(invokeMethod.GetParameterTypes());
            var result = REReflection.GetAssembliesFast()
                            .AsSafeParallel()
                            .SelectMany(v => v.GetTypesFast())
                            .SelectMany(v => v.GetStaticMethodsFullAccess())
                            .Where(v => v.HasAttribute(attributeType) && v.IsCompatible(retType, paramTypes))
                            .Select(v => v.CreateDelegateFast<TDelegate>())
                            .ToArray();
            return result;
        }


        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<Delegate> CreateDelegatesByAttributeRaw(Type delegateType, Type attributeType)
        {
            var invokeMethod = delegateType.GetMethodFullAccess("Invoke");
            if (invokeMethod == null || attributeType.IsAssignableFromFast<Attribute>())
            {
                return Array.Empty<Delegate>();
            }

            var retType = invokeMethod.ReturnType;
            var paramTypes = REReflection.GetArrayCache(invokeMethod.GetParameterTypes());
            var result = REReflection.GetAssembliesFast()
                            .AsSafeParallel()
                            .SelectMany(v => v.GetTypesFast())
                            .SelectMany(v => v.GetStaticMethodsFullAccess())
                            .Where(v => v.HasAttribute(attributeType) && v.IsCompatible(retType, paramTypes))
                            .Select(v => v.CreateDelegateFast(delegateType))
                            .ToArray();
            return result;
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Delegate CreateGenericDelegateRaw(this MethodInfo self, object target)
        {
            var type = self.CreateGenericDelegateType();
            return self.CreateDelegateFast(type, target);
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Delegate CreateGenericDelegateRaw(this MethodInfo self)
        {
            var type = self.CreateGenericDelegateType();
            return self.CreateDelegateFast(type, null);
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Delegate CreateUsingGenericDelegateRaw(this MethodInfo self, object target)
        {
            if (target != null && self.IsStatic)
            {
                return null;
            }

            var type = self.CreateUsingGenericDelegateType();
            return CreateDelegateFast(type, target, self.GetFunctionPointer());
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Delegate CreateUsingGenericDelegateRaw(this MethodInfo self)
        {
            if (!self.IsStatic)
            {
                return null;
            }

            var type = self.CreateUsingGenericDelegateType();
            return CreateDelegateFast(type, null, self.GetFunctionPointer());
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] { "Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)" })]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool IsGenericDelegatableRaw(this MethodInfo self)
        {
            return !self.IsAbstract &&
                   !self.ContainsGenericParameters &&
                   !self.IsGenericMethodDefinition &&
                   !self.HasByRefParameterInAll() &&
                   self.GetParameterCount() <= 16;
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] { "Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)" })]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Type CreateGenericDelegateTypeRaw(this MethodInfo self)
        {
            if (!self.IsGenericDelegatable())
            {
                return null;
            }

            var hasReturn = self.HasReturn();
            var genericParameterTypes = hasReturn ? self.GetAllParameterTypes() : self.GetParameterTypes();
            return CreateGenericDelegateType(hasReturn, REReflection.GetArrayCache(genericParameterTypes));
        }

        [Memoization(CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Type CreateGenericDelegateTypeRaw(bool hasReturn, Type[] genericParameterTypes)
        {
            var parameterCount = genericParameterTypes.Length;
            var delegateType = CreateGenericDelegateDefinitionType(hasReturn, parameterCount);

            try
            {
                return delegateType.MakeGenericTypeFast(genericParameterTypes);
            }
            catch
            {
                return null;
            }
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] { "Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)" })]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Type CreateUsingGenericDelegateTypeRaw(this MethodInfo self)
        {
            if (!self.IsGenericDelegatable())
            {
                return null;
            }

            var hasReturn = self.HasReturn();
            var genericParameterTypes = hasReturn ? self.GetAllParameterTypes() : self.GetParameterTypes();
            return CreateUsingGenericDelegateType(hasReturn, REReflection.GetArrayCache(genericParameterTypes));
        }

        [Memoization(CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Type CreateUsingGenericDelegateTypeRaw(bool hasReturn, Type[] genericParameterTypes)
        {
            var parameterCount = genericParameterTypes.Length;
            var delegateType = CreateGenericDelegateDefinitionType(hasReturn, parameterCount);
            var genInstanceDelegateTypes = delegateType.GetUsingGenericInstanceTypes();

            foreach (var genInstanceDelegateType in genInstanceDelegateTypes)
            {
                if (genInstanceDelegateType.GetGenericArguments().SequenceEqual(genericParameterTypes))
                {
                    return genInstanceDelegateType;
                }
            }

            if (hasReturn)
            {
                return AbstractFuncs[parameterCount - 1];
            }

            return AbstractActions[parameterCount];
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] { "Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)" })]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Type CreateGenericDelegateDefinitionTypeRaw(bool hasReturn, int parameterCount)
        {
            if (hasReturn)
            {
                parameterCount = parameterCount - 1;
                if (parameterCount >= Funcs.Length)
                {
                    return null;
                }

                return Funcs[parameterCount];
            }

            if (parameterCount >= Actions.Length)
            {
                return null;
            }

            return Actions[parameterCount];
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static void InitDelegate<T>(this T del, MethodInfo method)
            where T : Delegate
        {
            if (!method.IsStatic)
            {
                return;
            }

            InitDelegate(del, method.GetFunctionPointer());
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static void InitDelegate<T>(this T del, object target, MethodInfo method)
            where T : Delegate
        {
            if (target != null && method.IsStatic)
            {
                return;
            }

            InitDelegate(del, target, method.GetFunctionPointer());
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static void InitDelegate<T>(this T del, IntPtr pFunc)
            where T : Delegate
        {
            REType.Clear(del);
            var fp = (delegate*<T, object, IntPtr, void>)GetConstructorPointer<T>();
            fp(del, null, pFunc);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static void InitDelegate<T>(this T del, object target, IntPtr pFunc)
            where T : Delegate
        {
            REType.Clear(del);
            var fp = (delegate*<T, object, IntPtr, void>)GetConstructorPointer<T>();
            fp(del, target, pFunc);
        }

        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static IntPtr GetConstructorPointerRaw<T>()
            where T : Delegate
        {
            var constructorInfo = REType.GetInstanceConstructorFullAccess<T, object, IntPtr>(null, null);
            return constructorInfo.GetFunctionPointer();
        }
    }
}

using Katuusagi.ILPostProcessorCommon;
using Katuusagi.MemoizationForUnity;
using Katuusagi.Pool;
using System;
using System.Buffers;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
namespace Katuusagi.ReflectionEnhance
{
    public static partial class REMethodBase
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void InvokeInstanceFast<TTarget>(this MethodBase self, ref TTarget target)
        {
            bool isValid;
            nint pAddress;
            if (self.IsOverridable())
            {
                isValid = ValidateInstanceVirtualMethod<TTarget>(self, target?.GetType(), out pAddress);
            }
            else
            {
                isValid = ValidateInstanceMethod<TTarget>(self, out pAddress) ||
                          (pAddress != 0 && SecondaryValidateInstanceMethod(self, target?.GetType(), ref pAddress));
            }
            if (!isValid)
            {
                self.InvokeInstanceLowAlloc(ref target);
                return;
            }
            unsafe
            {
                if (REType.IsValueTypeFast<TTarget>())
                {
                    ((delegate*<ref TTarget, void>)pAddress)(ref target);
                    return;
                }
                ((delegate*<TTarget, void>)pAddress)(target);
                return;
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void InvokeClassInstanceFast<TTarget>(this MethodBase self, TTarget target)
        where TTarget: class
        {
            bool isValid;
            nint pAddress;
            if (self.IsOverridable())
            {
                isValid = ValidateInstanceVirtualMethod<TTarget>(self, target?.GetType(), out pAddress);
            }
            else
            {
                isValid = ValidateInstanceMethod<TTarget>(self, out pAddress) ||
                          (pAddress != 0 && SecondaryValidateInstanceMethod(self, target?.GetType(), ref pAddress));
            }
            if (!isValid)
            {
                self.InvokeClassInstanceLowAlloc(target);
                return;
            }
            unsafe
            {
                ((delegate*<TTarget, void>)pAddress)(target);
                return;
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void InvokeStructInstanceFast<TTarget>(this MethodBase self, ref TTarget target)
        where TTarget: struct
        {
            bool isValid;
            nint pAddress;
            if (self.IsOverridable())
            {
                isValid = ValidateInstanceVirtualMethod<TTarget>(self, target.GetType(), out pAddress);
            }
            else
            {
                isValid = ValidateInstanceMethod<TTarget>(self, out pAddress) ||
                          (pAddress != 0 && SecondaryValidateInstanceMethod(self, target.GetType(), ref pAddress));
            }
            if (!isValid)
            {
                self.InvokeInstanceLowAlloc(ref target);
                return;
            }
            unsafe
            {
                ((delegate*<ref TTarget, void>)pAddress)(ref target);
                return;
            }
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool ValidateInstanceMethodRaw<TTarget>(MethodBase method, out nint pAddress)
        {
            pAddress = 0;
            if (method.IsStatic)
            {
                return false;
            }
            if (method.IsOverridable())
            {
                return false;
            }
            var isValidGeneric = !method.IsGenericMethodDefinition || ValidateGenericMethod(ref method);
            if (!isValidGeneric)
            {
                return false;
            }
            var parameters = method.GetParametersFast();
            var parameterLength = parameters.Count;
            if (parameterLength != 0)
            {
                return false;
            }
            if (method is MethodInfo mi)
            {
                var returnType = mi?.ReturnType ?? typeof(void);
                if (returnType != typeof(void))
                {
                    return false;
                }
            }
            var reflectedType = method.ReflectedType;
            if (!reflectedType.IsValidInputWithoutRef<TTarget>(1, ref pAddress))
            {
                return false;
            }
            if (pAddress != 0)
            {
                return false;
            }
            pAddress = method.GetFunctionPointer();
            return true;
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool ValidateInstanceVirtualMethodRaw<TTarget>(MethodBase method, Type targetType, out nint pAddress)
        {
            pAddress = 0;
            if (method.IsStatic)
            {
                return false;
            }
            if (!method.IsOverridable())
            {
                return false;
            }
            var isValidGeneric = !method.IsGenericMethodDefinition || ValidateGenericMethod(ref method);
            if (!isValidGeneric)
            {
                return false;
            }
            var parameters = method.GetParametersFast();
            var parameterLength = parameters.Count;
            if (parameterLength != 0)
            {
                return false;
            }
            if (method is MethodInfo mi)
            {
                var returnType = mi?.ReturnType ?? typeof(void);
                if (returnType != typeof(void))
                {
                    return false;
                }
            }
            var reflectedType = method.ReflectedType;
            if (!reflectedType.IsValidVirtualInput<TTarget>(targetType, out var isVirtualCall))
            {
                return false;
            }
            if (isVirtualCall)
            {
                method = targetType.GetInstanceMethodFullAccess(method.Name, null, ArrayCache.Types0, null);
            }
            if (pAddress != 0)
            {
                return false;
            }
            pAddress = method.GetFunctionPointer();
            return true;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TReturn InvokeInstanceFast<TTarget, TReturn>(this MethodBase self, ref TTarget target)
        {
            bool isValid;
            nint pAddress;
            if (self.IsOverridable())
            {
                isValid = ValidateInstanceReturnableVirtualMethod<TTarget, TReturn>(self, target?.GetType(), out pAddress);
            }
            else
            {
                isValid = ValidateInstanceReturnableMethod<TTarget, TReturn>(self, out pAddress) ||
                          (pAddress != 0 && SecondaryValidateInstanceMethod(self, target?.GetType(), ref pAddress));
            }
            if (!isValid)
            {
                return (TReturn)self.InvokeInstanceLowAlloc(ref target);
            }
            unsafe
            {
                if (REType.IsValueTypeFast<TTarget>())
                {
                    return ((delegate*<ref TTarget, TReturn>)pAddress)(ref target);
                }
                return ((delegate*<TTarget, TReturn>)pAddress)(target);
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TReturn InvokeClassInstanceFast<TTarget, TReturn>(this MethodBase self, TTarget target)
        where TTarget: class
        {
            bool isValid;
            nint pAddress;
            if (self.IsOverridable())
            {
                isValid = ValidateInstanceReturnableVirtualMethod<TTarget, TReturn>(self, target?.GetType(), out pAddress);
            }
            else
            {
                isValid = ValidateInstanceReturnableMethod<TTarget, TReturn>(self, out pAddress) ||
                          (pAddress != 0 && SecondaryValidateInstanceMethod(self, target?.GetType(), ref pAddress));
            }
            if (!isValid)
            {
                return (TReturn)self.InvokeClassInstanceLowAlloc(target);
            }
            unsafe
            {
                return ((delegate*<TTarget, TReturn>)pAddress)(target);
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TReturn InvokeStructInstanceFast<TTarget, TReturn>(this MethodBase self, ref TTarget target)
        where TTarget: struct
        {
            bool isValid;
            nint pAddress;
            if (self.IsOverridable())
            {
                isValid = ValidateInstanceReturnableVirtualMethod<TTarget, TReturn>(self, target.GetType(), out pAddress);
            }
            else
            {
                isValid = ValidateInstanceReturnableMethod<TTarget, TReturn>(self, out pAddress) ||
                          (pAddress != 0 && SecondaryValidateInstanceMethod(self, target.GetType(), ref pAddress));
            }
            if (!isValid)
            {
                return (TReturn)self.InvokeInstanceLowAlloc(ref target);
            }
            unsafe
            {
                return ((delegate*<ref TTarget, TReturn>)pAddress)(ref target);
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static object InvokeInstanceLowAlloc<TTarget>(this MethodBase self, ref TTarget target)
        {
            if (self.IsGenericMethodDefinition)
            {
                ValidateGenericMethod(ref self);
            }
            var targetObj = REReflection.GetBoxWithoutRef(target);
            try
            {
                return self.Invoke(targetObj, ArrayCache.Objects0);
            }
            finally
            {
                REReflection.Unbox(targetObj, out target);
                REReflection.ReturnBoxWithoutRef<TTarget>(targetObj);
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static object InvokeClassInstanceLowAlloc<TTarget>(this MethodBase self, TTarget target)
        where TTarget: class
        {
            return self.Invoke(target, ArrayCache.Objects0);
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool ValidateInstanceReturnableMethodRaw<TTarget, TReturn>(MethodBase method, out nint pAddress)
        {
            pAddress = 0;
            if (method.IsStatic)
            {
                return false;
            }
            if (method.IsOverridable())
            {
                return false;
            }
            var isValidGeneric = !method.IsGenericMethodDefinition || ValidateGenericReturnableMethod<TReturn>(ref method);
            if (!isValidGeneric)
            {
                return false;
            }
            var parameters = method.GetParametersFast();
            var parameterLength = parameters.Count;
            if (parameterLength != 0)
            {
                return false;
            }
            if (method is MethodInfo mi)
            {
                var returnType = mi?.ReturnType ?? typeof(void);
                if (!returnType.IsValidOutput<TReturn>())
                {
                    return false;
                }
            }
            var reflectedType = method.ReflectedType;
            if (!reflectedType.IsValidInputWithoutRef<TTarget>(1, ref pAddress))
            {
                return false;
            }
            if (pAddress != 0)
            {
                return false;
            }
            pAddress = method.GetFunctionPointer();
            return true;
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool ValidateInstanceReturnableVirtualMethodRaw<TTarget, TReturn>(MethodBase method, Type targetType, out nint pAddress)
        {
            pAddress = 0;
            if (method.IsStatic)
            {
                return false;
            }
            if (!method.IsOverridable())
            {
                return false;
            }
            var isValidGeneric = !method.IsGenericMethodDefinition || ValidateGenericReturnableMethod<TReturn>(ref method);
            if (!isValidGeneric)
            {
                return false;
            }
            var parameters = method.GetParametersFast();
            var parameterLength = parameters.Count;
            if (parameterLength != 0)
            {
                return false;
            }
            if (method is MethodInfo mi)
            {
                var returnType = mi?.ReturnType ?? typeof(void);
                if (!returnType.IsValidOutput<TReturn>())
                {
                    return false;
                }
            }
            var reflectedType = method.ReflectedType;
            if (!reflectedType.IsValidVirtualInput<TTarget>(targetType, out var isVirtualCall))
            {
                return false;
            }
            if (isVirtualCall)
            {
                method = targetType.GetInstanceMethodFullAccess(method.Name, null, ArrayCache.Types0, null);
            }
            if (pAddress != 0)
            {
                return false;
            }
            pAddress = method.GetFunctionPointer();
            return true;
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool SecondaryValidateInstanceMethodRaw(MethodBase method, Type target, ref nint pAddress)
        {
            if ((pAddress & 1) != 0)
            {
                var reflectedType = method.ReflectedType;
                if (!reflectedType.IsNullAssignableFromFast(target))
                {
                    return false;
                }
            }
            pAddress = method.GetFunctionPointer();
            return true;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void InvokeStaticFast(this MethodBase self)
        {
            bool isValid;
            nint pAddress;
            isValid = ValidateStaticMethod(self, out pAddress);
            if (!isValid)
            {
                self.InvokeStaticLowAlloc();
                return;
            }
            unsafe
            {
                ((delegate*<void>)pAddress)();
                return;
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static object InvokeStaticLowAlloc(this MethodBase self)
        {
            return self.Invoke(null, ArrayCache.Objects0);
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool ValidateStaticMethodRaw(MethodBase method, out nint pAddress)
        {
            pAddress = 0;
            if (!method.IsStatic)
            {
                return false;
            }
            if (method.IsOverridable())
            {
                return false;
            }
            var isValidGeneric = !method.IsGenericMethodDefinition || ValidateGenericMethod(ref method);
            if (!isValidGeneric)
            {
                return false;
            }
            var parameters = method.GetParametersFast();
            var parameterLength = parameters.Count;
            if (parameterLength != 0)
            {
                return false;
            }
            if (method is MethodInfo mi)
            {
                var returnType = mi?.ReturnType ?? typeof(void);
                if (returnType != typeof(void))
                {
                    return false;
                }
            }
            if (pAddress != 0)
            {
                return false;
            }
            pAddress = method.GetFunctionPointer();
            return true;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TReturn InvokeStaticFast<TReturn>(this MethodBase self)
        {
            bool isValid;
            nint pAddress;
            isValid = ValidateStaticReturnableMethod<TReturn>(self, out pAddress);
            if (!isValid)
            {
                return (TReturn)self.InvokeStaticLowAlloc();
            }
            unsafe
            {
                return ((delegate*<TReturn>)pAddress)();
            }
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool ValidateStaticReturnableMethodRaw<TReturn>(MethodBase method, out nint pAddress)
        {
            pAddress = 0;
            if (!method.IsStatic)
            {
                return false;
            }
            if (method.IsOverridable())
            {
                return false;
            }
            var isValidGeneric = !method.IsGenericMethodDefinition || ValidateGenericReturnableMethod<TReturn>(ref method);
            if (!isValidGeneric)
            {
                return false;
            }
            var parameters = method.GetParametersFast();
            var parameterLength = parameters.Count;
            if (parameterLength != 0)
            {
                return false;
            }
            if (method is MethodInfo mi)
            {
                var returnType = mi?.ReturnType ?? typeof(void);
                if (!returnType.IsValidOutput<TReturn>())
                {
                    return false;
                }
            }
            if (pAddress != 0)
            {
                return false;
            }
            pAddress = method.GetFunctionPointer();
            return true;
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool ValidateGenericMethodRaw(ref MethodBase method)
        {
            if (!method.IsGenericMethodDefinition)
            {
                return true;
            }
            return false;
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool ValidateGenericReturnableMethodRaw<TReturn>(ref MethodBase method)
        {
            if (!method.IsGenericMethodDefinition)
            {
                return true;
            }
            var genericArguments = method.GetGenericArgumentsFast();
            if (genericArguments.Count < 1)
            {
                return false;
            }
            uint mask = 0;
            var mi = method as MethodInfo;
            var returnType = mi.ReturnType ?? typeof(void);
            var index = IndexOf(genericArguments, returnType);
            if (index >= 0)
            {
                mask |= 1u << index;
            }
            var parameters = method.GetParametersFast();
            if (REReflection.BitCount(mask) != genericArguments.Count)
            {
                return false;
            }
            var types = ArrayCache.GetArrayCache<Type>(genericArguments.Count);
            if (index >= 0)
            {
                types[index] = typeof(TReturn);
            }
            #if ENABLE_IL2CPP
            bool isFound = false;
            var usingMethods = method.GetUsingGenericInstanceMethods();
            foreach (var usingMethod in usingMethods)
            {
                if (usingMethod.GetGenericArgumentsFast().SequenceEqual(types))
                {
                    isFound = true;
                    break;
                }
            }
            if (!isFound)
            {
                return false;
            }
            #endif
            method = mi.MakeGenericMethodFast(types);
            return true;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void InvokeInstanceFast<TTarget, TArg0>(this MethodBase self, ref TTarget target, in TArg0 arg0)
        {
            bool isValid;
            nint pAddress;
            if (self.IsOverridable())
            {
                isValid = ValidateInstanceVirtualMethod<TTarget, TArg0>(self, target?.GetType(), out pAddress) ||
                          (pAddress != 0 && SecondaryValidateStaticMethod(self, arg0?.GetType(), ref pAddress));
            }
            else
            {
                isValid = ValidateInstanceMethod<TTarget, TArg0>(self, out pAddress) ||
                          (pAddress != 0 && SecondaryValidateInstanceMethod(self, target?.GetType(), arg0?.GetType(), ref pAddress));
            }
            if (!isValid)
            {
                self.InvokeInstanceLowAlloc(ref target, arg0);
                return;
            }
            unsafe
            {
                if (REType.IsValueTypeFast<TTarget>())
                {
                    ((delegate*<ref TTarget, TArg0, void>)pAddress)(ref target, arg0);
                    return;
                }
                ((delegate*<TTarget, TArg0, void>)pAddress)(target, arg0);
                return;
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void InvokeClassInstanceFast<TTarget, TArg0>(this MethodBase self, TTarget target, in TArg0 arg0)
        where TTarget: class
        {
            bool isValid;
            nint pAddress;
            if (self.IsOverridable())
            {
                isValid = ValidateInstanceVirtualMethod<TTarget, TArg0>(self, target?.GetType(), out pAddress) ||
                          (pAddress != 0 && SecondaryValidateStaticMethod(self, arg0?.GetType(), ref pAddress));
            }
            else
            {
                isValid = ValidateInstanceMethod<TTarget, TArg0>(self, out pAddress) ||
                          (pAddress != 0 && SecondaryValidateInstanceMethod(self, target?.GetType(), arg0?.GetType(), ref pAddress));
            }
            if (!isValid)
            {
                self.InvokeClassInstanceLowAlloc(target, arg0);
                return;
            }
            unsafe
            {
                ((delegate*<TTarget, TArg0, void>)pAddress)(target, arg0);
                return;
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void InvokeStructInstanceFast<TTarget, TArg0>(this MethodBase self, ref TTarget target, in TArg0 arg0)
        where TTarget: struct
        {
            bool isValid;
            nint pAddress;
            if (self.IsOverridable())
            {
                isValid = ValidateInstanceVirtualMethod<TTarget, TArg0>(self, target.GetType(), out pAddress) ||
                          (pAddress != 0 && SecondaryValidateStaticMethod(self, arg0?.GetType(), ref pAddress));
            }
            else
            {
                isValid = ValidateInstanceMethod<TTarget, TArg0>(self, out pAddress) ||
                          (pAddress != 0 && SecondaryValidateInstanceMethod(self, target.GetType(), arg0?.GetType(), ref pAddress));
            }
            if (!isValid)
            {
                self.InvokeInstanceLowAlloc(ref target, arg0);
                return;
            }
            unsafe
            {
                ((delegate*<ref TTarget, TArg0, void>)pAddress)(ref target, arg0);
                return;
            }
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool ValidateInstanceMethodRaw<TTarget, TArg0>(MethodBase method, out nint pAddress)
        {
            pAddress = 0;
            if (method.IsStatic)
            {
                return false;
            }
            if (method.IsOverridable())
            {
                return false;
            }
            var isValidGeneric = !method.IsGenericMethodDefinition || ValidateGenericMethod<TArg0>(ref method);
            if (!isValidGeneric)
            {
                return false;
            }
            var parameters = method.GetParametersFast();
            var parameterLength = parameters.Count;
            if (parameterLength != 1)
            {
                return false;
            }
            if (method is MethodInfo mi)
            {
                var returnType = mi?.ReturnType ?? typeof(void);
                if (returnType != typeof(void))
                {
                    return false;
                }
            }
            var reflectedType = method.ReflectedType;
            if (!reflectedType.IsValidInputWithoutRef<TTarget>(1, ref pAddress))
            {
                return false;
            }
            var paramType0 = parameters[0].ParameterType;
            if (!paramType0.IsValidInput<TArg0>(2, ref pAddress))
            {
                return false;
            }
            if (pAddress != 0)
            {
                return false;
            }
            pAddress = method.GetFunctionPointer();
            return true;
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool ValidateInstanceVirtualMethodRaw<TTarget, TArg0>(MethodBase method, Type targetType, out nint pAddress)
        {
            pAddress = 0;
            if (method.IsStatic)
            {
                return false;
            }
            if (!method.IsOverridable())
            {
                return false;
            }
            var isValidGeneric = !method.IsGenericMethodDefinition || ValidateGenericMethod<TArg0>(ref method);
            if (!isValidGeneric)
            {
                return false;
            }
            var parameters = method.GetParametersFast();
            var parameterLength = parameters.Count;
            if (parameterLength != 1)
            {
                return false;
            }
            if (method is MethodInfo mi)
            {
                var returnType = mi?.ReturnType ?? typeof(void);
                if (returnType != typeof(void))
                {
                    return false;
                }
            }
            var reflectedType = method.ReflectedType;
            if (!reflectedType.IsValidVirtualInput<TTarget>(targetType, out var isVirtualCall))
            {
                return false;
            }
            if (isVirtualCall)
            {
                ArrayCache.Types1[0] = parameters[0].ParameterType;
                method = targetType.GetInstanceMethodFullAccess(method.Name, null, ArrayCache.Types1, null);
            }
            var paramType0 = parameters[0].ParameterType;
            if (!paramType0.IsValidInput<TArg0>(2, ref pAddress))
            {
                return false;
            }
            if (pAddress != 0)
            {
                return false;
            }
            pAddress = method.GetFunctionPointer();
            return true;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TReturn InvokeInstanceFast<TTarget, TArg0, TReturn>(this MethodBase self, ref TTarget target, in TArg0 arg0)
        {
            bool isValid;
            nint pAddress;
            if (self.IsOverridable())
            {
                isValid = ValidateInstanceReturnableVirtualMethod<TTarget, TArg0, TReturn>(self, target?.GetType(), out pAddress) ||
                          (pAddress != 0 && SecondaryValidateStaticMethod(self, arg0?.GetType(), ref pAddress));
            }
            else
            {
                isValid = ValidateInstanceReturnableMethod<TTarget, TArg0, TReturn>(self, out pAddress) ||
                          (pAddress != 0 && SecondaryValidateInstanceMethod(self, target?.GetType(), arg0?.GetType(), ref pAddress));
            }
            if (!isValid)
            {
                return (TReturn)self.InvokeInstanceLowAlloc(ref target, arg0);
            }
            unsafe
            {
                if (REType.IsValueTypeFast<TTarget>())
                {
                    return ((delegate*<ref TTarget, TArg0, TReturn>)pAddress)(ref target, arg0);
                }
                return ((delegate*<TTarget, TArg0, TReturn>)pAddress)(target, arg0);
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TReturn InvokeClassInstanceFast<TTarget, TArg0, TReturn>(this MethodBase self, TTarget target, in TArg0 arg0)
        where TTarget: class
        {
            bool isValid;
            nint pAddress;
            if (self.IsOverridable())
            {
                isValid = ValidateInstanceReturnableVirtualMethod<TTarget, TArg0, TReturn>(self, target?.GetType(), out pAddress) ||
                          (pAddress != 0 && SecondaryValidateStaticMethod(self, arg0?.GetType(), ref pAddress));
            }
            else
            {
                isValid = ValidateInstanceReturnableMethod<TTarget, TArg0, TReturn>(self, out pAddress) ||
                          (pAddress != 0 && SecondaryValidateInstanceMethod(self, target?.GetType(), arg0?.GetType(), ref pAddress));
            }
            if (!isValid)
            {
                return (TReturn)self.InvokeClassInstanceLowAlloc(target, arg0);
            }
            unsafe
            {
                return ((delegate*<TTarget, TArg0, TReturn>)pAddress)(target, arg0);
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TReturn InvokeStructInstanceFast<TTarget, TArg0, TReturn>(this MethodBase self, ref TTarget target, in TArg0 arg0)
        where TTarget: struct
        {
            bool isValid;
            nint pAddress;
            if (self.IsOverridable())
            {
                isValid = ValidateInstanceReturnableVirtualMethod<TTarget, TArg0, TReturn>(self, target.GetType(), out pAddress) ||
                          (pAddress != 0 && SecondaryValidateStaticMethod(self, arg0?.GetType(), ref pAddress));
            }
            else
            {
                isValid = ValidateInstanceReturnableMethod<TTarget, TArg0, TReturn>(self, out pAddress) ||
                          (pAddress != 0 && SecondaryValidateInstanceMethod(self, target.GetType(), arg0?.GetType(), ref pAddress));
            }
            if (!isValid)
            {
                return (TReturn)self.InvokeInstanceLowAlloc(ref target, arg0);
            }
            unsafe
            {
                return ((delegate*<ref TTarget, TArg0, TReturn>)pAddress)(ref target, arg0);
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static object InvokeInstanceLowAlloc<TTarget, TArg0>(this MethodBase self, ref TTarget target, in TArg0 arg0)
        {
            if (self.IsGenericMethodDefinition)
            {
                ValidateGenericMethod<TArg0>(ref self);
            }
            var targetObj = REReflection.GetBoxWithoutRef(target);
            var parameters = self.GetParametersFast();
            ArrayCache.Objects1[0] = REReflection.GetBox(arg0, parameters[0], out var refArg0);
            try
            {
                return self.Invoke(targetObj, ArrayCache.Objects1);
            }
            finally
            {
                REReflection.Unbox(targetObj, out target);
                REReflection.ReturnBoxWithoutRef<TTarget>(targetObj);
                REReflection.ReturnBox<TArg0>(ArrayCache.Objects1[0], parameters[0], refArg0);
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static object InvokeClassInstanceLowAlloc<TTarget, TArg0>(this MethodBase self, TTarget target, in TArg0 arg0)
        where TTarget: class
        {
            if (self.IsGenericMethodDefinition)
            {
                ValidateGenericMethod<TArg0>(ref self);
            }
            var parameters = self.GetParametersFast();
            ArrayCache.Objects1[0] = REReflection.GetBox(arg0, parameters[0], out var refArg0);
            try
            {
                return self.Invoke(target, ArrayCache.Objects1);
            }
            finally
            {
                REReflection.ReturnBox<TArg0>(ArrayCache.Objects1[0], parameters[0], refArg0);
            }
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool ValidateInstanceReturnableMethodRaw<TTarget, TArg0, TReturn>(MethodBase method, out nint pAddress)
        {
            pAddress = 0;
            if (method.IsStatic)
            {
                return false;
            }
            if (method.IsOverridable())
            {
                return false;
            }
            var isValidGeneric = !method.IsGenericMethodDefinition || ValidateGenericReturnableMethod<TArg0, TReturn>(ref method);
            if (!isValidGeneric)
            {
                return false;
            }
            var parameters = method.GetParametersFast();
            var parameterLength = parameters.Count;
            if (parameterLength != 1)
            {
                return false;
            }
            if (method is MethodInfo mi)
            {
                var returnType = mi?.ReturnType ?? typeof(void);
                if (!returnType.IsValidOutput<TReturn>())
                {
                    return false;
                }
            }
            var reflectedType = method.ReflectedType;
            if (!reflectedType.IsValidInputWithoutRef<TTarget>(1, ref pAddress))
            {
                return false;
            }
            var paramType0 = parameters[0].ParameterType;
            if (!paramType0.IsValidInput<TArg0>(2, ref pAddress))
            {
                return false;
            }
            if (pAddress != 0)
            {
                return false;
            }
            pAddress = method.GetFunctionPointer();
            return true;
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool ValidateInstanceReturnableVirtualMethodRaw<TTarget, TArg0, TReturn>(MethodBase method, Type targetType, out nint pAddress)
        {
            pAddress = 0;
            if (method.IsStatic)
            {
                return false;
            }
            if (!method.IsOverridable())
            {
                return false;
            }
            var isValidGeneric = !method.IsGenericMethodDefinition || ValidateGenericReturnableMethod<TArg0, TReturn>(ref method);
            if (!isValidGeneric)
            {
                return false;
            }
            var parameters = method.GetParametersFast();
            var parameterLength = parameters.Count;
            if (parameterLength != 1)
            {
                return false;
            }
            if (method is MethodInfo mi)
            {
                var returnType = mi?.ReturnType ?? typeof(void);
                if (!returnType.IsValidOutput<TReturn>())
                {
                    return false;
                }
            }
            var reflectedType = method.ReflectedType;
            if (!reflectedType.IsValidVirtualInput<TTarget>(targetType, out var isVirtualCall))
            {
                return false;
            }
            if (isVirtualCall)
            {
                ArrayCache.Types1[0] = parameters[0].ParameterType;
                method = targetType.GetInstanceMethodFullAccess(method.Name, null, ArrayCache.Types1, null);
            }
            var paramType0 = parameters[0].ParameterType;
            if (!paramType0.IsValidInput<TArg0>(2, ref pAddress))
            {
                return false;
            }
            if (pAddress != 0)
            {
                return false;
            }
            pAddress = method.GetFunctionPointer();
            return true;
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool SecondaryValidateInstanceMethodRaw(MethodBase method, Type target, Type arg0, ref nint pAddress)
        {
            if ((pAddress & 1) != 0)
            {
                var reflectedType = method.ReflectedType;
                if (!reflectedType.IsNullAssignableFromFast(target))
                {
                    return false;
                }
            }
            var parameters = method.GetParametersFast();
            if ((pAddress & 2) != 0)
            {
                var paramType = parameters[0].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg0))
                {
                    return false;
                }
            }
            pAddress = method.GetFunctionPointer();
            return true;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void InvokeStaticFast<TArg0>(this MethodBase self, in TArg0 arg0)
        {
            bool isValid;
            nint pAddress;
            isValid = ValidateStaticMethod<TArg0>(self, out pAddress) ||
                      (pAddress != 0 && SecondaryValidateStaticMethod(self, arg0?.GetType(), ref pAddress));
            if (!isValid)
            {
                self.InvokeStaticLowAlloc(arg0);
                return;
            }
            unsafe
            {
                ((delegate*<TArg0, void>)pAddress)(arg0);
                return;
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static object InvokeStaticLowAlloc<TArg0>(this MethodBase self, in TArg0 arg0)
        {
            if (self.IsGenericMethodDefinition)
            {
                ValidateGenericMethod<TArg0>(ref self);
            }
            var parameters = self.GetParametersFast();
            ArrayCache.Objects1[0] = REReflection.GetBox(arg0, parameters[0], out var refArg0);
            try
            {
                return self.Invoke(null, ArrayCache.Objects1);
            }
            finally
            {
                REReflection.ReturnBox<TArg0>(ArrayCache.Objects1[0], parameters[0], refArg0);
            }
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool ValidateStaticMethodRaw<TArg0>(MethodBase method, out nint pAddress)
        {
            pAddress = 0;
            if (!method.IsStatic)
            {
                return false;
            }
            if (method.IsOverridable())
            {
                return false;
            }
            var isValidGeneric = !method.IsGenericMethodDefinition || ValidateGenericMethod<TArg0>(ref method);
            if (!isValidGeneric)
            {
                return false;
            }
            var parameters = method.GetParametersFast();
            var parameterLength = parameters.Count;
            if (parameterLength != 1)
            {
                return false;
            }
            if (method is MethodInfo mi)
            {
                var returnType = mi?.ReturnType ?? typeof(void);
                if (returnType != typeof(void))
                {
                    return false;
                }
            }
            var paramType0 = parameters[0].ParameterType;
            if (!paramType0.IsValidInput<TArg0>(2, ref pAddress))
            {
                return false;
            }
            if (pAddress != 0)
            {
                return false;
            }
            pAddress = method.GetFunctionPointer();
            return true;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TReturn InvokeStaticFast<TArg0, TReturn>(this MethodBase self, in TArg0 arg0)
        {
            bool isValid;
            nint pAddress;
            isValid = ValidateStaticReturnableMethod<TArg0, TReturn>(self, out pAddress) ||
                      (pAddress != 0 && SecondaryValidateStaticMethod(self, arg0?.GetType(), ref pAddress));
            if (!isValid)
            {
                return (TReturn)self.InvokeStaticLowAlloc(arg0);
            }
            unsafe
            {
                return ((delegate*<TArg0, TReturn>)pAddress)(arg0);
            }
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool ValidateStaticReturnableMethodRaw<TArg0, TReturn>(MethodBase method, out nint pAddress)
        {
            pAddress = 0;
            if (!method.IsStatic)
            {
                return false;
            }
            if (method.IsOverridable())
            {
                return false;
            }
            var isValidGeneric = !method.IsGenericMethodDefinition || ValidateGenericReturnableMethod<TArg0, TReturn>(ref method);
            if (!isValidGeneric)
            {
                return false;
            }
            var parameters = method.GetParametersFast();
            var parameterLength = parameters.Count;
            if (parameterLength != 1)
            {
                return false;
            }
            if (method is MethodInfo mi)
            {
                var returnType = mi?.ReturnType ?? typeof(void);
                if (!returnType.IsValidOutput<TReturn>())
                {
                    return false;
                }
            }
            var paramType0 = parameters[0].ParameterType;
            if (!paramType0.IsValidInput<TArg0>(2, ref pAddress))
            {
                return false;
            }
            if (pAddress != 0)
            {
                return false;
            }
            pAddress = method.GetFunctionPointer();
            return true;
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool SecondaryValidateStaticMethodRaw(MethodBase method, Type arg0, ref nint pAddress)
        {
            var parameters = method.GetParametersFast();
            if ((pAddress & 2) != 0)
            {
                var paramType = parameters[0].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg0))
                {
                    return false;
                }
            }
            pAddress = method.GetFunctionPointer();
            return true;
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool ValidateGenericMethodRaw<TArg0>(ref MethodBase method)
        {
            if (!method.IsGenericMethodDefinition)
            {
                return true;
            }
            var genericArguments = method.GetGenericArgumentsFast();
            if (genericArguments.Count < 1)
            {
                return false;
            }
            uint mask = 0;
            var mi = method as MethodInfo;
            var parameters = method.GetParametersFast();
            var index0 = IndexOf(genericArguments, parameters[0].ParameterType);
            if (index0 >= 0)
            {
                mask |= 1u << index0;
            }
            if (REReflection.BitCount(mask) != genericArguments.Count)
            {
                return false;
            }
            var types = ArrayCache.GetArrayCache<Type>(genericArguments.Count);
            if (index0 >= 0)
            {
                types[index0] = typeof(TArg0);
            }
            #if ENABLE_IL2CPP
            bool isFound = false;
            var usingMethods = method.GetUsingGenericInstanceMethods();
            foreach (var usingMethod in usingMethods)
            {
                if (usingMethod.GetGenericArgumentsFast().SequenceEqual(types))
                {
                    isFound = true;
                    break;
                }
            }
            if (!isFound)
            {
                return false;
            }
            #endif
            method = mi.MakeGenericMethodFast(types);
            return true;
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool ValidateGenericReturnableMethodRaw<TArg0, TReturn>(ref MethodBase method)
        {
            if (!method.IsGenericMethodDefinition)
            {
                return true;
            }
            var genericArguments = method.GetGenericArgumentsFast();
            if (genericArguments.Count < 2)
            {
                return false;
            }
            uint mask = 0;
            var mi = method as MethodInfo;
            var returnType = mi.ReturnType ?? typeof(void);
            var index = IndexOf(genericArguments, returnType);
            if (index >= 0)
            {
                mask |= 1u << index;
            }
            var parameters = method.GetParametersFast();
            var index0 = IndexOf(genericArguments, parameters[0].ParameterType);
            if (index0 >= 0)
            {
                mask |= 1u << index0;
            }
            if (REReflection.BitCount(mask) != genericArguments.Count)
            {
                return false;
            }
            var types = ArrayCache.GetArrayCache<Type>(genericArguments.Count);
            if (index >= 0)
            {
                types[index] = typeof(TReturn);
            }
            if (index0 >= 0)
            {
                types[index0] = typeof(TArg0);
            }
            #if ENABLE_IL2CPP
            bool isFound = false;
            var usingMethods = method.GetUsingGenericInstanceMethods();
            foreach (var usingMethod in usingMethods)
            {
                if (usingMethod.GetGenericArgumentsFast().SequenceEqual(types))
                {
                    isFound = true;
                    break;
                }
            }
            if (!isFound)
            {
                return false;
            }
            #endif
            method = mi.MakeGenericMethodFast(types);
            return true;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void InvokeInstanceFast<TTarget, TArg0, TArg1>(this MethodBase self, ref TTarget target, in TArg0 arg0, in TArg1 arg1)
        {
            bool isValid;
            nint pAddress;
            if (self.IsOverridable())
            {
                isValid = ValidateInstanceVirtualMethod<TTarget, TArg0, TArg1>(self, target?.GetType(), out pAddress) ||
                          (pAddress != 0 && SecondaryValidateStaticMethod(self, arg0?.GetType(), arg1?.GetType(), ref pAddress));
            }
            else
            {
                isValid = ValidateInstanceMethod<TTarget, TArg0, TArg1>(self, out pAddress) ||
                          (pAddress != 0 && SecondaryValidateInstanceMethod(self, target?.GetType(), arg0?.GetType(), arg1?.GetType(), ref pAddress));
            }
            if (!isValid)
            {
                self.InvokeInstanceLowAlloc(ref target, arg0, arg1);
                return;
            }
            unsafe
            {
                if (REType.IsValueTypeFast<TTarget>())
                {
                    ((delegate*<ref TTarget, TArg0, TArg1, void>)pAddress)(ref target, arg0, arg1);
                    return;
                }
                ((delegate*<TTarget, TArg0, TArg1, void>)pAddress)(target, arg0, arg1);
                return;
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void InvokeClassInstanceFast<TTarget, TArg0, TArg1>(this MethodBase self, TTarget target, in TArg0 arg0, in TArg1 arg1)
        where TTarget: class
        {
            bool isValid;
            nint pAddress;
            if (self.IsOverridable())
            {
                isValid = ValidateInstanceVirtualMethod<TTarget, TArg0, TArg1>(self, target?.GetType(), out pAddress) ||
                          (pAddress != 0 && SecondaryValidateStaticMethod(self, arg0?.GetType(), arg1?.GetType(), ref pAddress));
            }
            else
            {
                isValid = ValidateInstanceMethod<TTarget, TArg0, TArg1>(self, out pAddress) ||
                          (pAddress != 0 && SecondaryValidateInstanceMethod(self, target?.GetType(), arg0?.GetType(), arg1?.GetType(), ref pAddress));
            }
            if (!isValid)
            {
                self.InvokeClassInstanceLowAlloc(target, arg0, arg1);
                return;
            }
            unsafe
            {
                ((delegate*<TTarget, TArg0, TArg1, void>)pAddress)(target, arg0, arg1);
                return;
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void InvokeStructInstanceFast<TTarget, TArg0, TArg1>(this MethodBase self, ref TTarget target, in TArg0 arg0, in TArg1 arg1)
        where TTarget: struct
        {
            bool isValid;
            nint pAddress;
            if (self.IsOverridable())
            {
                isValid = ValidateInstanceVirtualMethod<TTarget, TArg0, TArg1>(self, target.GetType(), out pAddress) ||
                          (pAddress != 0 && SecondaryValidateStaticMethod(self, arg0?.GetType(), arg1?.GetType(), ref pAddress));
            }
            else
            {
                isValid = ValidateInstanceMethod<TTarget, TArg0, TArg1>(self, out pAddress) ||
                          (pAddress != 0 && SecondaryValidateInstanceMethod(self, target.GetType(), arg0?.GetType(), arg1?.GetType(), ref pAddress));
            }
            if (!isValid)
            {
                self.InvokeInstanceLowAlloc(ref target, arg0, arg1);
                return;
            }
            unsafe
            {
                ((delegate*<ref TTarget, TArg0, TArg1, void>)pAddress)(ref target, arg0, arg1);
                return;
            }
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool ValidateInstanceMethodRaw<TTarget, TArg0, TArg1>(MethodBase method, out nint pAddress)
        {
            pAddress = 0;
            if (method.IsStatic)
            {
                return false;
            }
            if (method.IsOverridable())
            {
                return false;
            }
            var isValidGeneric = !method.IsGenericMethodDefinition || ValidateGenericMethod<TArg0, TArg1>(ref method);
            if (!isValidGeneric)
            {
                return false;
            }
            var parameters = method.GetParametersFast();
            var parameterLength = parameters.Count;
            if (parameterLength != 2)
            {
                return false;
            }
            if (method is MethodInfo mi)
            {
                var returnType = mi?.ReturnType ?? typeof(void);
                if (returnType != typeof(void))
                {
                    return false;
                }
            }
            var reflectedType = method.ReflectedType;
            if (!reflectedType.IsValidInputWithoutRef<TTarget>(1, ref pAddress))
            {
                return false;
            }
            var paramType0 = parameters[0].ParameterType;
            if (!paramType0.IsValidInput<TArg0>(2, ref pAddress))
            {
                return false;
            }
            var paramType1 = parameters[1].ParameterType;
            if (!paramType1.IsValidInput<TArg1>(4, ref pAddress))
            {
                return false;
            }
            if (pAddress != 0)
            {
                return false;
            }
            pAddress = method.GetFunctionPointer();
            return true;
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool ValidateInstanceVirtualMethodRaw<TTarget, TArg0, TArg1>(MethodBase method, Type targetType, out nint pAddress)
        {
            pAddress = 0;
            if (method.IsStatic)
            {
                return false;
            }
            if (!method.IsOverridable())
            {
                return false;
            }
            var isValidGeneric = !method.IsGenericMethodDefinition || ValidateGenericMethod<TArg0, TArg1>(ref method);
            if (!isValidGeneric)
            {
                return false;
            }
            var parameters = method.GetParametersFast();
            var parameterLength = parameters.Count;
            if (parameterLength != 2)
            {
                return false;
            }
            if (method is MethodInfo mi)
            {
                var returnType = mi?.ReturnType ?? typeof(void);
                if (returnType != typeof(void))
                {
                    return false;
                }
            }
            var reflectedType = method.ReflectedType;
            if (!reflectedType.IsValidVirtualInput<TTarget>(targetType, out var isVirtualCall))
            {
                return false;
            }
            if (isVirtualCall)
            {
                ArrayCache.Types2[0] = parameters[0].ParameterType;
                ArrayCache.Types2[1] = parameters[1].ParameterType;
                method = targetType.GetInstanceMethodFullAccess(method.Name, null, ArrayCache.Types2, null);
            }
            var paramType0 = parameters[0].ParameterType;
            if (!paramType0.IsValidInput<TArg0>(2, ref pAddress))
            {
                return false;
            }
            var paramType1 = parameters[1].ParameterType;
            if (!paramType1.IsValidInput<TArg1>(4, ref pAddress))
            {
                return false;
            }
            if (pAddress != 0)
            {
                return false;
            }
            pAddress = method.GetFunctionPointer();
            return true;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TReturn InvokeInstanceFast<TTarget, TArg0, TArg1, TReturn>(this MethodBase self, ref TTarget target, in TArg0 arg0, in TArg1 arg1)
        {
            bool isValid;
            nint pAddress;
            if (self.IsOverridable())
            {
                isValid = ValidateInstanceReturnableVirtualMethod<TTarget, TArg0, TArg1, TReturn>(self, target?.GetType(), out pAddress) ||
                          (pAddress != 0 && SecondaryValidateStaticMethod(self, arg0?.GetType(), arg1?.GetType(), ref pAddress));
            }
            else
            {
                isValid = ValidateInstanceReturnableMethod<TTarget, TArg0, TArg1, TReturn>(self, out pAddress) ||
                          (pAddress != 0 && SecondaryValidateInstanceMethod(self, target?.GetType(), arg0?.GetType(), arg1?.GetType(), ref pAddress));
            }
            if (!isValid)
            {
                return (TReturn)self.InvokeInstanceLowAlloc(ref target, arg0, arg1);
            }
            unsafe
            {
                if (REType.IsValueTypeFast<TTarget>())
                {
                    return ((delegate*<ref TTarget, TArg0, TArg1, TReturn>)pAddress)(ref target, arg0, arg1);
                }
                return ((delegate*<TTarget, TArg0, TArg1, TReturn>)pAddress)(target, arg0, arg1);
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TReturn InvokeClassInstanceFast<TTarget, TArg0, TArg1, TReturn>(this MethodBase self, TTarget target, in TArg0 arg0, in TArg1 arg1)
        where TTarget: class
        {
            bool isValid;
            nint pAddress;
            if (self.IsOverridable())
            {
                isValid = ValidateInstanceReturnableVirtualMethod<TTarget, TArg0, TArg1, TReturn>(self, target?.GetType(), out pAddress) ||
                          (pAddress != 0 && SecondaryValidateStaticMethod(self, arg0?.GetType(), arg1?.GetType(), ref pAddress));
            }
            else
            {
                isValid = ValidateInstanceReturnableMethod<TTarget, TArg0, TArg1, TReturn>(self, out pAddress) ||
                          (pAddress != 0 && SecondaryValidateInstanceMethod(self, target?.GetType(), arg0?.GetType(), arg1?.GetType(), ref pAddress));
            }
            if (!isValid)
            {
                return (TReturn)self.InvokeClassInstanceLowAlloc(target, arg0, arg1);
            }
            unsafe
            {
                return ((delegate*<TTarget, TArg0, TArg1, TReturn>)pAddress)(target, arg0, arg1);
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TReturn InvokeStructInstanceFast<TTarget, TArg0, TArg1, TReturn>(this MethodBase self, ref TTarget target, in TArg0 arg0, in TArg1 arg1)
        where TTarget: struct
        {
            bool isValid;
            nint pAddress;
            if (self.IsOverridable())
            {
                isValid = ValidateInstanceReturnableVirtualMethod<TTarget, TArg0, TArg1, TReturn>(self, target.GetType(), out pAddress) ||
                          (pAddress != 0 && SecondaryValidateStaticMethod(self, arg0?.GetType(), arg1?.GetType(), ref pAddress));
            }
            else
            {
                isValid = ValidateInstanceReturnableMethod<TTarget, TArg0, TArg1, TReturn>(self, out pAddress) ||
                          (pAddress != 0 && SecondaryValidateInstanceMethod(self, target.GetType(), arg0?.GetType(), arg1?.GetType(), ref pAddress));
            }
            if (!isValid)
            {
                return (TReturn)self.InvokeInstanceLowAlloc(ref target, arg0, arg1);
            }
            unsafe
            {
                return ((delegate*<ref TTarget, TArg0, TArg1, TReturn>)pAddress)(ref target, arg0, arg1);
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static object InvokeInstanceLowAlloc<TTarget, TArg0, TArg1>(this MethodBase self, ref TTarget target, in TArg0 arg0, in TArg1 arg1)
        {
            if (self.IsGenericMethodDefinition)
            {
                ValidateGenericMethod<TArg0, TArg1>(ref self);
            }
            var targetObj = REReflection.GetBoxWithoutRef(target);
            var parameters = self.GetParametersFast();
            ArrayCache.Objects2[0] = REReflection.GetBox(arg0, parameters[0], out var refArg0);
            ArrayCache.Objects2[1] = REReflection.GetBox(arg1, parameters[1], out var refArg1);
            try
            {
                return self.Invoke(targetObj, ArrayCache.Objects2);
            }
            finally
            {
                REReflection.Unbox(targetObj, out target);
                REReflection.ReturnBoxWithoutRef<TTarget>(targetObj);
                REReflection.ReturnBox<TArg0>(ArrayCache.Objects2[0], parameters[0], refArg0);
                REReflection.ReturnBox<TArg1>(ArrayCache.Objects2[1], parameters[1], refArg1);
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static object InvokeClassInstanceLowAlloc<TTarget, TArg0, TArg1>(this MethodBase self, TTarget target, in TArg0 arg0, in TArg1 arg1)
        where TTarget: class
        {
            if (self.IsGenericMethodDefinition)
            {
                ValidateGenericMethod<TArg0, TArg1>(ref self);
            }
            var parameters = self.GetParametersFast();
            ArrayCache.Objects2[0] = REReflection.GetBox(arg0, parameters[0], out var refArg0);
            ArrayCache.Objects2[1] = REReflection.GetBox(arg1, parameters[1], out var refArg1);
            try
            {
                return self.Invoke(target, ArrayCache.Objects2);
            }
            finally
            {
                REReflection.ReturnBox<TArg0>(ArrayCache.Objects2[0], parameters[0], refArg0);
                REReflection.ReturnBox<TArg1>(ArrayCache.Objects2[1], parameters[1], refArg1);
            }
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool ValidateInstanceReturnableMethodRaw<TTarget, TArg0, TArg1, TReturn>(MethodBase method, out nint pAddress)
        {
            pAddress = 0;
            if (method.IsStatic)
            {
                return false;
            }
            if (method.IsOverridable())
            {
                return false;
            }
            var isValidGeneric = !method.IsGenericMethodDefinition || ValidateGenericReturnableMethod<TArg0, TArg1, TReturn>(ref method);
            if (!isValidGeneric)
            {
                return false;
            }
            var parameters = method.GetParametersFast();
            var parameterLength = parameters.Count;
            if (parameterLength != 2)
            {
                return false;
            }
            if (method is MethodInfo mi)
            {
                var returnType = mi?.ReturnType ?? typeof(void);
                if (!returnType.IsValidOutput<TReturn>())
                {
                    return false;
                }
            }
            var reflectedType = method.ReflectedType;
            if (!reflectedType.IsValidInputWithoutRef<TTarget>(1, ref pAddress))
            {
                return false;
            }
            var paramType0 = parameters[0].ParameterType;
            if (!paramType0.IsValidInput<TArg0>(2, ref pAddress))
            {
                return false;
            }
            var paramType1 = parameters[1].ParameterType;
            if (!paramType1.IsValidInput<TArg1>(4, ref pAddress))
            {
                return false;
            }
            if (pAddress != 0)
            {
                return false;
            }
            pAddress = method.GetFunctionPointer();
            return true;
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool ValidateInstanceReturnableVirtualMethodRaw<TTarget, TArg0, TArg1, TReturn>(MethodBase method, Type targetType, out nint pAddress)
        {
            pAddress = 0;
            if (method.IsStatic)
            {
                return false;
            }
            if (!method.IsOverridable())
            {
                return false;
            }
            var isValidGeneric = !method.IsGenericMethodDefinition || ValidateGenericReturnableMethod<TArg0, TArg1, TReturn>(ref method);
            if (!isValidGeneric)
            {
                return false;
            }
            var parameters = method.GetParametersFast();
            var parameterLength = parameters.Count;
            if (parameterLength != 2)
            {
                return false;
            }
            if (method is MethodInfo mi)
            {
                var returnType = mi?.ReturnType ?? typeof(void);
                if (!returnType.IsValidOutput<TReturn>())
                {
                    return false;
                }
            }
            var reflectedType = method.ReflectedType;
            if (!reflectedType.IsValidVirtualInput<TTarget>(targetType, out var isVirtualCall))
            {
                return false;
            }
            if (isVirtualCall)
            {
                ArrayCache.Types2[0] = parameters[0].ParameterType;
                ArrayCache.Types2[1] = parameters[1].ParameterType;
                method = targetType.GetInstanceMethodFullAccess(method.Name, null, ArrayCache.Types2, null);
            }
            var paramType0 = parameters[0].ParameterType;
            if (!paramType0.IsValidInput<TArg0>(2, ref pAddress))
            {
                return false;
            }
            var paramType1 = parameters[1].ParameterType;
            if (!paramType1.IsValidInput<TArg1>(4, ref pAddress))
            {
                return false;
            }
            if (pAddress != 0)
            {
                return false;
            }
            pAddress = method.GetFunctionPointer();
            return true;
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool SecondaryValidateInstanceMethodRaw(MethodBase method, Type target, Type arg0, Type arg1, ref nint pAddress)
        {
            if ((pAddress & 1) != 0)
            {
                var reflectedType = method.ReflectedType;
                if (!reflectedType.IsNullAssignableFromFast(target))
                {
                    return false;
                }
            }
            var parameters = method.GetParametersFast();
            if ((pAddress & 2) != 0)
            {
                var paramType = parameters[0].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg0))
                {
                    return false;
                }
            }
            if ((pAddress & 4) != 0)
            {
                var paramType = parameters[1].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg1))
                {
                    return false;
                }
            }
            pAddress = method.GetFunctionPointer();
            return true;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void InvokeStaticFast<TArg0, TArg1>(this MethodBase self, in TArg0 arg0, in TArg1 arg1)
        {
            bool isValid;
            nint pAddress;
            isValid = ValidateStaticMethod<TArg0, TArg1>(self, out pAddress) ||
                      (pAddress != 0 && SecondaryValidateStaticMethod(self, arg0?.GetType(), arg1?.GetType(), ref pAddress));
            if (!isValid)
            {
                self.InvokeStaticLowAlloc(arg0, arg1);
                return;
            }
            unsafe
            {
                ((delegate*<TArg0, TArg1, void>)pAddress)(arg0, arg1);
                return;
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static object InvokeStaticLowAlloc<TArg0, TArg1>(this MethodBase self, in TArg0 arg0, in TArg1 arg1)
        {
            if (self.IsGenericMethodDefinition)
            {
                ValidateGenericMethod<TArg0, TArg1>(ref self);
            }
            var parameters = self.GetParametersFast();
            ArrayCache.Objects2[0] = REReflection.GetBox(arg0, parameters[0], out var refArg0);
            ArrayCache.Objects2[1] = REReflection.GetBox(arg1, parameters[1], out var refArg1);
            try
            {
                return self.Invoke(null, ArrayCache.Objects2);
            }
            finally
            {
                REReflection.ReturnBox<TArg0>(ArrayCache.Objects2[0], parameters[0], refArg0);
                REReflection.ReturnBox<TArg1>(ArrayCache.Objects2[1], parameters[1], refArg1);
            }
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool ValidateStaticMethodRaw<TArg0, TArg1>(MethodBase method, out nint pAddress)
        {
            pAddress = 0;
            if (!method.IsStatic)
            {
                return false;
            }
            if (method.IsOverridable())
            {
                return false;
            }
            var isValidGeneric = !method.IsGenericMethodDefinition || ValidateGenericMethod<TArg0, TArg1>(ref method);
            if (!isValidGeneric)
            {
                return false;
            }
            var parameters = method.GetParametersFast();
            var parameterLength = parameters.Count;
            if (parameterLength != 2)
            {
                return false;
            }
            if (method is MethodInfo mi)
            {
                var returnType = mi?.ReturnType ?? typeof(void);
                if (returnType != typeof(void))
                {
                    return false;
                }
            }
            var paramType0 = parameters[0].ParameterType;
            if (!paramType0.IsValidInput<TArg0>(2, ref pAddress))
            {
                return false;
            }
            var paramType1 = parameters[1].ParameterType;
            if (!paramType1.IsValidInput<TArg1>(4, ref pAddress))
            {
                return false;
            }
            if (pAddress != 0)
            {
                return false;
            }
            pAddress = method.GetFunctionPointer();
            return true;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TReturn InvokeStaticFast<TArg0, TArg1, TReturn>(this MethodBase self, in TArg0 arg0, in TArg1 arg1)
        {
            bool isValid;
            nint pAddress;
            isValid = ValidateStaticReturnableMethod<TArg0, TArg1, TReturn>(self, out pAddress) ||
                      (pAddress != 0 && SecondaryValidateStaticMethod(self, arg0?.GetType(), arg1?.GetType(), ref pAddress));
            if (!isValid)
            {
                return (TReturn)self.InvokeStaticLowAlloc(arg0, arg1);
            }
            unsafe
            {
                return ((delegate*<TArg0, TArg1, TReturn>)pAddress)(arg0, arg1);
            }
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool ValidateStaticReturnableMethodRaw<TArg0, TArg1, TReturn>(MethodBase method, out nint pAddress)
        {
            pAddress = 0;
            if (!method.IsStatic)
            {
                return false;
            }
            if (method.IsOverridable())
            {
                return false;
            }
            var isValidGeneric = !method.IsGenericMethodDefinition || ValidateGenericReturnableMethod<TArg0, TArg1, TReturn>(ref method);
            if (!isValidGeneric)
            {
                return false;
            }
            var parameters = method.GetParametersFast();
            var parameterLength = parameters.Count;
            if (parameterLength != 2)
            {
                return false;
            }
            if (method is MethodInfo mi)
            {
                var returnType = mi?.ReturnType ?? typeof(void);
                if (!returnType.IsValidOutput<TReturn>())
                {
                    return false;
                }
            }
            var paramType0 = parameters[0].ParameterType;
            if (!paramType0.IsValidInput<TArg0>(2, ref pAddress))
            {
                return false;
            }
            var paramType1 = parameters[1].ParameterType;
            if (!paramType1.IsValidInput<TArg1>(4, ref pAddress))
            {
                return false;
            }
            if (pAddress != 0)
            {
                return false;
            }
            pAddress = method.GetFunctionPointer();
            return true;
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool SecondaryValidateStaticMethodRaw(MethodBase method, Type arg0, Type arg1, ref nint pAddress)
        {
            var parameters = method.GetParametersFast();
            if ((pAddress & 2) != 0)
            {
                var paramType = parameters[0].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg0))
                {
                    return false;
                }
            }
            if ((pAddress & 4) != 0)
            {
                var paramType = parameters[1].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg1))
                {
                    return false;
                }
            }
            pAddress = method.GetFunctionPointer();
            return true;
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool ValidateGenericMethodRaw<TArg0, TArg1>(ref MethodBase method)
        {
            if (!method.IsGenericMethodDefinition)
            {
                return true;
            }
            var genericArguments = method.GetGenericArgumentsFast();
            if (genericArguments.Count < 2)
            {
                return false;
            }
            uint mask = 0;
            var mi = method as MethodInfo;
            var parameters = method.GetParametersFast();
            var index0 = IndexOf(genericArguments, parameters[0].ParameterType);
            if (index0 >= 0)
            {
                mask |= 1u << index0;
            }
            var index1 = IndexOf(genericArguments, parameters[1].ParameterType);
            if (index1 >= 0)
            {
                mask |= 1u << index1;
            }
            if (REReflection.BitCount(mask) != genericArguments.Count)
            {
                return false;
            }
            var types = ArrayCache.GetArrayCache<Type>(genericArguments.Count);
            if (index0 >= 0)
            {
                types[index0] = typeof(TArg0);
            }
            if (index1 >= 0)
            {
                types[index1] = typeof(TArg1);
            }
            #if ENABLE_IL2CPP
            bool isFound = false;
            var usingMethods = method.GetUsingGenericInstanceMethods();
            foreach (var usingMethod in usingMethods)
            {
                if (usingMethod.GetGenericArgumentsFast().SequenceEqual(types))
                {
                    isFound = true;
                    break;
                }
            }
            if (!isFound)
            {
                return false;
            }
            #endif
            method = mi.MakeGenericMethodFast(types);
            return true;
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool ValidateGenericReturnableMethodRaw<TArg0, TArg1, TReturn>(ref MethodBase method)
        {
            if (!method.IsGenericMethodDefinition)
            {
                return true;
            }
            var genericArguments = method.GetGenericArgumentsFast();
            if (genericArguments.Count < 3)
            {
                return false;
            }
            uint mask = 0;
            var mi = method as MethodInfo;
            var returnType = mi.ReturnType ?? typeof(void);
            var index = IndexOf(genericArguments, returnType);
            if (index >= 0)
            {
                mask |= 1u << index;
            }
            var parameters = method.GetParametersFast();
            var index0 = IndexOf(genericArguments, parameters[0].ParameterType);
            if (index0 >= 0)
            {
                mask |= 1u << index0;
            }
            var index1 = IndexOf(genericArguments, parameters[1].ParameterType);
            if (index1 >= 0)
            {
                mask |= 1u << index1;
            }
            if (REReflection.BitCount(mask) != genericArguments.Count)
            {
                return false;
            }
            var types = ArrayCache.GetArrayCache<Type>(genericArguments.Count);
            if (index >= 0)
            {
                types[index] = typeof(TReturn);
            }
            if (index0 >= 0)
            {
                types[index0] = typeof(TArg0);
            }
            if (index1 >= 0)
            {
                types[index1] = typeof(TArg1);
            }
            #if ENABLE_IL2CPP
            bool isFound = false;
            var usingMethods = method.GetUsingGenericInstanceMethods();
            foreach (var usingMethod in usingMethods)
            {
                if (usingMethod.GetGenericArgumentsFast().SequenceEqual(types))
                {
                    isFound = true;
                    break;
                }
            }
            if (!isFound)
            {
                return false;
            }
            #endif
            method = mi.MakeGenericMethodFast(types);
            return true;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void InvokeInstanceFast<TTarget, TArg0, TArg1, TArg2>(this MethodBase self, ref TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2)
        {
            bool isValid;
            nint pAddress;
            if (self.IsOverridable())
            {
                isValid = ValidateInstanceVirtualMethod<TTarget, TArg0, TArg1, TArg2>(self, target?.GetType(), out pAddress) ||
                          (pAddress != 0 && SecondaryValidateStaticMethod(self, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), ref pAddress));
            }
            else
            {
                isValid = ValidateInstanceMethod<TTarget, TArg0, TArg1, TArg2>(self, out pAddress) ||
                          (pAddress != 0 && SecondaryValidateInstanceMethod(self, target?.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), ref pAddress));
            }
            if (!isValid)
            {
                self.InvokeInstanceLowAlloc(ref target, arg0, arg1, arg2);
                return;
            }
            unsafe
            {
                if (REType.IsValueTypeFast<TTarget>())
                {
                    ((delegate*<ref TTarget, TArg0, TArg1, TArg2, void>)pAddress)(ref target, arg0, arg1, arg2);
                    return;
                }
                ((delegate*<TTarget, TArg0, TArg1, TArg2, void>)pAddress)(target, arg0, arg1, arg2);
                return;
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void InvokeClassInstanceFast<TTarget, TArg0, TArg1, TArg2>(this MethodBase self, TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2)
        where TTarget: class
        {
            bool isValid;
            nint pAddress;
            if (self.IsOverridable())
            {
                isValid = ValidateInstanceVirtualMethod<TTarget, TArg0, TArg1, TArg2>(self, target?.GetType(), out pAddress) ||
                          (pAddress != 0 && SecondaryValidateStaticMethod(self, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), ref pAddress));
            }
            else
            {
                isValid = ValidateInstanceMethod<TTarget, TArg0, TArg1, TArg2>(self, out pAddress) ||
                          (pAddress != 0 && SecondaryValidateInstanceMethod(self, target?.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), ref pAddress));
            }
            if (!isValid)
            {
                self.InvokeClassInstanceLowAlloc(target, arg0, arg1, arg2);
                return;
            }
            unsafe
            {
                ((delegate*<TTarget, TArg0, TArg1, TArg2, void>)pAddress)(target, arg0, arg1, arg2);
                return;
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void InvokeStructInstanceFast<TTarget, TArg0, TArg1, TArg2>(this MethodBase self, ref TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2)
        where TTarget: struct
        {
            bool isValid;
            nint pAddress;
            if (self.IsOverridable())
            {
                isValid = ValidateInstanceVirtualMethod<TTarget, TArg0, TArg1, TArg2>(self, target.GetType(), out pAddress) ||
                          (pAddress != 0 && SecondaryValidateStaticMethod(self, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), ref pAddress));
            }
            else
            {
                isValid = ValidateInstanceMethod<TTarget, TArg0, TArg1, TArg2>(self, out pAddress) ||
                          (pAddress != 0 && SecondaryValidateInstanceMethod(self, target.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), ref pAddress));
            }
            if (!isValid)
            {
                self.InvokeInstanceLowAlloc(ref target, arg0, arg1, arg2);
                return;
            }
            unsafe
            {
                ((delegate*<ref TTarget, TArg0, TArg1, TArg2, void>)pAddress)(ref target, arg0, arg1, arg2);
                return;
            }
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool ValidateInstanceMethodRaw<TTarget, TArg0, TArg1, TArg2>(MethodBase method, out nint pAddress)
        {
            pAddress = 0;
            if (method.IsStatic)
            {
                return false;
            }
            if (method.IsOverridable())
            {
                return false;
            }
            var isValidGeneric = !method.IsGenericMethodDefinition || ValidateGenericMethod<TArg0, TArg1, TArg2>(ref method);
            if (!isValidGeneric)
            {
                return false;
            }
            var parameters = method.GetParametersFast();
            var parameterLength = parameters.Count;
            if (parameterLength != 3)
            {
                return false;
            }
            if (method is MethodInfo mi)
            {
                var returnType = mi?.ReturnType ?? typeof(void);
                if (returnType != typeof(void))
                {
                    return false;
                }
            }
            var reflectedType = method.ReflectedType;
            if (!reflectedType.IsValidInputWithoutRef<TTarget>(1, ref pAddress))
            {
                return false;
            }
            var paramType0 = parameters[0].ParameterType;
            if (!paramType0.IsValidInput<TArg0>(2, ref pAddress))
            {
                return false;
            }
            var paramType1 = parameters[1].ParameterType;
            if (!paramType1.IsValidInput<TArg1>(4, ref pAddress))
            {
                return false;
            }
            var paramType2 = parameters[2].ParameterType;
            if (!paramType2.IsValidInput<TArg2>(8, ref pAddress))
            {
                return false;
            }
            if (pAddress != 0)
            {
                return false;
            }
            pAddress = method.GetFunctionPointer();
            return true;
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool ValidateInstanceVirtualMethodRaw<TTarget, TArg0, TArg1, TArg2>(MethodBase method, Type targetType, out nint pAddress)
        {
            pAddress = 0;
            if (method.IsStatic)
            {
                return false;
            }
            if (!method.IsOverridable())
            {
                return false;
            }
            var isValidGeneric = !method.IsGenericMethodDefinition || ValidateGenericMethod<TArg0, TArg1, TArg2>(ref method);
            if (!isValidGeneric)
            {
                return false;
            }
            var parameters = method.GetParametersFast();
            var parameterLength = parameters.Count;
            if (parameterLength != 3)
            {
                return false;
            }
            if (method is MethodInfo mi)
            {
                var returnType = mi?.ReturnType ?? typeof(void);
                if (returnType != typeof(void))
                {
                    return false;
                }
            }
            var reflectedType = method.ReflectedType;
            if (!reflectedType.IsValidVirtualInput<TTarget>(targetType, out var isVirtualCall))
            {
                return false;
            }
            if (isVirtualCall)
            {
                ArrayCache.Types3[0] = parameters[0].ParameterType;
                ArrayCache.Types3[1] = parameters[1].ParameterType;
                ArrayCache.Types3[2] = parameters[2].ParameterType;
                method = targetType.GetInstanceMethodFullAccess(method.Name, null, ArrayCache.Types3, null);
            }
            var paramType0 = parameters[0].ParameterType;
            if (!paramType0.IsValidInput<TArg0>(2, ref pAddress))
            {
                return false;
            }
            var paramType1 = parameters[1].ParameterType;
            if (!paramType1.IsValidInput<TArg1>(4, ref pAddress))
            {
                return false;
            }
            var paramType2 = parameters[2].ParameterType;
            if (!paramType2.IsValidInput<TArg2>(8, ref pAddress))
            {
                return false;
            }
            if (pAddress != 0)
            {
                return false;
            }
            pAddress = method.GetFunctionPointer();
            return true;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TReturn InvokeInstanceFast<TTarget, TArg0, TArg1, TArg2, TReturn>(this MethodBase self, ref TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2)
        {
            bool isValid;
            nint pAddress;
            if (self.IsOverridable())
            {
                isValid = ValidateInstanceReturnableVirtualMethod<TTarget, TArg0, TArg1, TArg2, TReturn>(self, target?.GetType(), out pAddress) ||
                          (pAddress != 0 && SecondaryValidateStaticMethod(self, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), ref pAddress));
            }
            else
            {
                isValid = ValidateInstanceReturnableMethod<TTarget, TArg0, TArg1, TArg2, TReturn>(self, out pAddress) ||
                          (pAddress != 0 && SecondaryValidateInstanceMethod(self, target?.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), ref pAddress));
            }
            if (!isValid)
            {
                return (TReturn)self.InvokeInstanceLowAlloc(ref target, arg0, arg1, arg2);
            }
            unsafe
            {
                if (REType.IsValueTypeFast<TTarget>())
                {
                    return ((delegate*<ref TTarget, TArg0, TArg1, TArg2, TReturn>)pAddress)(ref target, arg0, arg1, arg2);
                }
                return ((delegate*<TTarget, TArg0, TArg1, TArg2, TReturn>)pAddress)(target, arg0, arg1, arg2);
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TReturn InvokeClassInstanceFast<TTarget, TArg0, TArg1, TArg2, TReturn>(this MethodBase self, TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2)
        where TTarget: class
        {
            bool isValid;
            nint pAddress;
            if (self.IsOverridable())
            {
                isValid = ValidateInstanceReturnableVirtualMethod<TTarget, TArg0, TArg1, TArg2, TReturn>(self, target?.GetType(), out pAddress) ||
                          (pAddress != 0 && SecondaryValidateStaticMethod(self, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), ref pAddress));
            }
            else
            {
                isValid = ValidateInstanceReturnableMethod<TTarget, TArg0, TArg1, TArg2, TReturn>(self, out pAddress) ||
                          (pAddress != 0 && SecondaryValidateInstanceMethod(self, target?.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), ref pAddress));
            }
            if (!isValid)
            {
                return (TReturn)self.InvokeClassInstanceLowAlloc(target, arg0, arg1, arg2);
            }
            unsafe
            {
                return ((delegate*<TTarget, TArg0, TArg1, TArg2, TReturn>)pAddress)(target, arg0, arg1, arg2);
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TReturn InvokeStructInstanceFast<TTarget, TArg0, TArg1, TArg2, TReturn>(this MethodBase self, ref TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2)
        where TTarget: struct
        {
            bool isValid;
            nint pAddress;
            if (self.IsOverridable())
            {
                isValid = ValidateInstanceReturnableVirtualMethod<TTarget, TArg0, TArg1, TArg2, TReturn>(self, target.GetType(), out pAddress) ||
                          (pAddress != 0 && SecondaryValidateStaticMethod(self, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), ref pAddress));
            }
            else
            {
                isValid = ValidateInstanceReturnableMethod<TTarget, TArg0, TArg1, TArg2, TReturn>(self, out pAddress) ||
                          (pAddress != 0 && SecondaryValidateInstanceMethod(self, target.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), ref pAddress));
            }
            if (!isValid)
            {
                return (TReturn)self.InvokeInstanceLowAlloc(ref target, arg0, arg1, arg2);
            }
            unsafe
            {
                return ((delegate*<ref TTarget, TArg0, TArg1, TArg2, TReturn>)pAddress)(ref target, arg0, arg1, arg2);
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static object InvokeInstanceLowAlloc<TTarget, TArg0, TArg1, TArg2>(this MethodBase self, ref TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2)
        {
            if (self.IsGenericMethodDefinition)
            {
                ValidateGenericMethod<TArg0, TArg1, TArg2>(ref self);
            }
            var targetObj = REReflection.GetBoxWithoutRef(target);
            var parameters = self.GetParametersFast();
            ArrayCache.Objects3[0] = REReflection.GetBox(arg0, parameters[0], out var refArg0);
            ArrayCache.Objects3[1] = REReflection.GetBox(arg1, parameters[1], out var refArg1);
            ArrayCache.Objects3[2] = REReflection.GetBox(arg2, parameters[2], out var refArg2);
            try
            {
                return self.Invoke(targetObj, ArrayCache.Objects3);
            }
            finally
            {
                REReflection.Unbox(targetObj, out target);
                REReflection.ReturnBoxWithoutRef<TTarget>(targetObj);
                REReflection.ReturnBox<TArg0>(ArrayCache.Objects3[0], parameters[0], refArg0);
                REReflection.ReturnBox<TArg1>(ArrayCache.Objects3[1], parameters[1], refArg1);
                REReflection.ReturnBox<TArg2>(ArrayCache.Objects3[2], parameters[2], refArg2);
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static object InvokeClassInstanceLowAlloc<TTarget, TArg0, TArg1, TArg2>(this MethodBase self, TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2)
        where TTarget: class
        {
            if (self.IsGenericMethodDefinition)
            {
                ValidateGenericMethod<TArg0, TArg1, TArg2>(ref self);
            }
            var parameters = self.GetParametersFast();
            ArrayCache.Objects3[0] = REReflection.GetBox(arg0, parameters[0], out var refArg0);
            ArrayCache.Objects3[1] = REReflection.GetBox(arg1, parameters[1], out var refArg1);
            ArrayCache.Objects3[2] = REReflection.GetBox(arg2, parameters[2], out var refArg2);
            try
            {
                return self.Invoke(target, ArrayCache.Objects3);
            }
            finally
            {
                REReflection.ReturnBox<TArg0>(ArrayCache.Objects3[0], parameters[0], refArg0);
                REReflection.ReturnBox<TArg1>(ArrayCache.Objects3[1], parameters[1], refArg1);
                REReflection.ReturnBox<TArg2>(ArrayCache.Objects3[2], parameters[2], refArg2);
            }
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool ValidateInstanceReturnableMethodRaw<TTarget, TArg0, TArg1, TArg2, TReturn>(MethodBase method, out nint pAddress)
        {
            pAddress = 0;
            if (method.IsStatic)
            {
                return false;
            }
            if (method.IsOverridable())
            {
                return false;
            }
            var isValidGeneric = !method.IsGenericMethodDefinition || ValidateGenericReturnableMethod<TArg0, TArg1, TArg2, TReturn>(ref method);
            if (!isValidGeneric)
            {
                return false;
            }
            var parameters = method.GetParametersFast();
            var parameterLength = parameters.Count;
            if (parameterLength != 3)
            {
                return false;
            }
            if (method is MethodInfo mi)
            {
                var returnType = mi?.ReturnType ?? typeof(void);
                if (!returnType.IsValidOutput<TReturn>())
                {
                    return false;
                }
            }
            var reflectedType = method.ReflectedType;
            if (!reflectedType.IsValidInputWithoutRef<TTarget>(1, ref pAddress))
            {
                return false;
            }
            var paramType0 = parameters[0].ParameterType;
            if (!paramType0.IsValidInput<TArg0>(2, ref pAddress))
            {
                return false;
            }
            var paramType1 = parameters[1].ParameterType;
            if (!paramType1.IsValidInput<TArg1>(4, ref pAddress))
            {
                return false;
            }
            var paramType2 = parameters[2].ParameterType;
            if (!paramType2.IsValidInput<TArg2>(8, ref pAddress))
            {
                return false;
            }
            if (pAddress != 0)
            {
                return false;
            }
            pAddress = method.GetFunctionPointer();
            return true;
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool ValidateInstanceReturnableVirtualMethodRaw<TTarget, TArg0, TArg1, TArg2, TReturn>(MethodBase method, Type targetType, out nint pAddress)
        {
            pAddress = 0;
            if (method.IsStatic)
            {
                return false;
            }
            if (!method.IsOverridable())
            {
                return false;
            }
            var isValidGeneric = !method.IsGenericMethodDefinition || ValidateGenericReturnableMethod<TArg0, TArg1, TArg2, TReturn>(ref method);
            if (!isValidGeneric)
            {
                return false;
            }
            var parameters = method.GetParametersFast();
            var parameterLength = parameters.Count;
            if (parameterLength != 3)
            {
                return false;
            }
            if (method is MethodInfo mi)
            {
                var returnType = mi?.ReturnType ?? typeof(void);
                if (!returnType.IsValidOutput<TReturn>())
                {
                    return false;
                }
            }
            var reflectedType = method.ReflectedType;
            if (!reflectedType.IsValidVirtualInput<TTarget>(targetType, out var isVirtualCall))
            {
                return false;
            }
            if (isVirtualCall)
            {
                ArrayCache.Types3[0] = parameters[0].ParameterType;
                ArrayCache.Types3[1] = parameters[1].ParameterType;
                ArrayCache.Types3[2] = parameters[2].ParameterType;
                method = targetType.GetInstanceMethodFullAccess(method.Name, null, ArrayCache.Types3, null);
            }
            var paramType0 = parameters[0].ParameterType;
            if (!paramType0.IsValidInput<TArg0>(2, ref pAddress))
            {
                return false;
            }
            var paramType1 = parameters[1].ParameterType;
            if (!paramType1.IsValidInput<TArg1>(4, ref pAddress))
            {
                return false;
            }
            var paramType2 = parameters[2].ParameterType;
            if (!paramType2.IsValidInput<TArg2>(8, ref pAddress))
            {
                return false;
            }
            if (pAddress != 0)
            {
                return false;
            }
            pAddress = method.GetFunctionPointer();
            return true;
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool SecondaryValidateInstanceMethodRaw(MethodBase method, Type target, Type arg0, Type arg1, Type arg2, ref nint pAddress)
        {
            if ((pAddress & 1) != 0)
            {
                var reflectedType = method.ReflectedType;
                if (!reflectedType.IsNullAssignableFromFast(target))
                {
                    return false;
                }
            }
            var parameters = method.GetParametersFast();
            if ((pAddress & 2) != 0)
            {
                var paramType = parameters[0].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg0))
                {
                    return false;
                }
            }
            if ((pAddress & 4) != 0)
            {
                var paramType = parameters[1].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg1))
                {
                    return false;
                }
            }
            if ((pAddress & 8) != 0)
            {
                var paramType = parameters[2].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg2))
                {
                    return false;
                }
            }
            pAddress = method.GetFunctionPointer();
            return true;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void InvokeStaticFast<TArg0, TArg1, TArg2>(this MethodBase self, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2)
        {
            bool isValid;
            nint pAddress;
            isValid = ValidateStaticMethod<TArg0, TArg1, TArg2>(self, out pAddress) ||
                      (pAddress != 0 && SecondaryValidateStaticMethod(self, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), ref pAddress));
            if (!isValid)
            {
                self.InvokeStaticLowAlloc(arg0, arg1, arg2);
                return;
            }
            unsafe
            {
                ((delegate*<TArg0, TArg1, TArg2, void>)pAddress)(arg0, arg1, arg2);
                return;
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static object InvokeStaticLowAlloc<TArg0, TArg1, TArg2>(this MethodBase self, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2)
        {
            if (self.IsGenericMethodDefinition)
            {
                ValidateGenericMethod<TArg0, TArg1, TArg2>(ref self);
            }
            var parameters = self.GetParametersFast();
            ArrayCache.Objects3[0] = REReflection.GetBox(arg0, parameters[0], out var refArg0);
            ArrayCache.Objects3[1] = REReflection.GetBox(arg1, parameters[1], out var refArg1);
            ArrayCache.Objects3[2] = REReflection.GetBox(arg2, parameters[2], out var refArg2);
            try
            {
                return self.Invoke(null, ArrayCache.Objects3);
            }
            finally
            {
                REReflection.ReturnBox<TArg0>(ArrayCache.Objects3[0], parameters[0], refArg0);
                REReflection.ReturnBox<TArg1>(ArrayCache.Objects3[1], parameters[1], refArg1);
                REReflection.ReturnBox<TArg2>(ArrayCache.Objects3[2], parameters[2], refArg2);
            }
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool ValidateStaticMethodRaw<TArg0, TArg1, TArg2>(MethodBase method, out nint pAddress)
        {
            pAddress = 0;
            if (!method.IsStatic)
            {
                return false;
            }
            if (method.IsOverridable())
            {
                return false;
            }
            var isValidGeneric = !method.IsGenericMethodDefinition || ValidateGenericMethod<TArg0, TArg1, TArg2>(ref method);
            if (!isValidGeneric)
            {
                return false;
            }
            var parameters = method.GetParametersFast();
            var parameterLength = parameters.Count;
            if (parameterLength != 3)
            {
                return false;
            }
            if (method is MethodInfo mi)
            {
                var returnType = mi?.ReturnType ?? typeof(void);
                if (returnType != typeof(void))
                {
                    return false;
                }
            }
            var paramType0 = parameters[0].ParameterType;
            if (!paramType0.IsValidInput<TArg0>(2, ref pAddress))
            {
                return false;
            }
            var paramType1 = parameters[1].ParameterType;
            if (!paramType1.IsValidInput<TArg1>(4, ref pAddress))
            {
                return false;
            }
            var paramType2 = parameters[2].ParameterType;
            if (!paramType2.IsValidInput<TArg2>(8, ref pAddress))
            {
                return false;
            }
            if (pAddress != 0)
            {
                return false;
            }
            pAddress = method.GetFunctionPointer();
            return true;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TReturn InvokeStaticFast<TArg0, TArg1, TArg2, TReturn>(this MethodBase self, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2)
        {
            bool isValid;
            nint pAddress;
            isValid = ValidateStaticReturnableMethod<TArg0, TArg1, TArg2, TReturn>(self, out pAddress) ||
                      (pAddress != 0 && SecondaryValidateStaticMethod(self, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), ref pAddress));
            if (!isValid)
            {
                return (TReturn)self.InvokeStaticLowAlloc(arg0, arg1, arg2);
            }
            unsafe
            {
                return ((delegate*<TArg0, TArg1, TArg2, TReturn>)pAddress)(arg0, arg1, arg2);
            }
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool ValidateStaticReturnableMethodRaw<TArg0, TArg1, TArg2, TReturn>(MethodBase method, out nint pAddress)
        {
            pAddress = 0;
            if (!method.IsStatic)
            {
                return false;
            }
            if (method.IsOverridable())
            {
                return false;
            }
            var isValidGeneric = !method.IsGenericMethodDefinition || ValidateGenericReturnableMethod<TArg0, TArg1, TArg2, TReturn>(ref method);
            if (!isValidGeneric)
            {
                return false;
            }
            var parameters = method.GetParametersFast();
            var parameterLength = parameters.Count;
            if (parameterLength != 3)
            {
                return false;
            }
            if (method is MethodInfo mi)
            {
                var returnType = mi?.ReturnType ?? typeof(void);
                if (!returnType.IsValidOutput<TReturn>())
                {
                    return false;
                }
            }
            var paramType0 = parameters[0].ParameterType;
            if (!paramType0.IsValidInput<TArg0>(2, ref pAddress))
            {
                return false;
            }
            var paramType1 = parameters[1].ParameterType;
            if (!paramType1.IsValidInput<TArg1>(4, ref pAddress))
            {
                return false;
            }
            var paramType2 = parameters[2].ParameterType;
            if (!paramType2.IsValidInput<TArg2>(8, ref pAddress))
            {
                return false;
            }
            if (pAddress != 0)
            {
                return false;
            }
            pAddress = method.GetFunctionPointer();
            return true;
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool SecondaryValidateStaticMethodRaw(MethodBase method, Type arg0, Type arg1, Type arg2, ref nint pAddress)
        {
            var parameters = method.GetParametersFast();
            if ((pAddress & 2) != 0)
            {
                var paramType = parameters[0].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg0))
                {
                    return false;
                }
            }
            if ((pAddress & 4) != 0)
            {
                var paramType = parameters[1].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg1))
                {
                    return false;
                }
            }
            if ((pAddress & 8) != 0)
            {
                var paramType = parameters[2].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg2))
                {
                    return false;
                }
            }
            pAddress = method.GetFunctionPointer();
            return true;
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool ValidateGenericMethodRaw<TArg0, TArg1, TArg2>(ref MethodBase method)
        {
            if (!method.IsGenericMethodDefinition)
            {
                return true;
            }
            var genericArguments = method.GetGenericArgumentsFast();
            if (genericArguments.Count < 3)
            {
                return false;
            }
            uint mask = 0;
            var mi = method as MethodInfo;
            var parameters = method.GetParametersFast();
            var index0 = IndexOf(genericArguments, parameters[0].ParameterType);
            if (index0 >= 0)
            {
                mask |= 1u << index0;
            }
            var index1 = IndexOf(genericArguments, parameters[1].ParameterType);
            if (index1 >= 0)
            {
                mask |= 1u << index1;
            }
            var index2 = IndexOf(genericArguments, parameters[2].ParameterType);
            if (index2 >= 0)
            {
                mask |= 1u << index2;
            }
            if (REReflection.BitCount(mask) != genericArguments.Count)
            {
                return false;
            }
            var types = ArrayCache.GetArrayCache<Type>(genericArguments.Count);
            if (index0 >= 0)
            {
                types[index0] = typeof(TArg0);
            }
            if (index1 >= 0)
            {
                types[index1] = typeof(TArg1);
            }
            if (index2 >= 0)
            {
                types[index2] = typeof(TArg2);
            }
            #if ENABLE_IL2CPP
            bool isFound = false;
            var usingMethods = method.GetUsingGenericInstanceMethods();
            foreach (var usingMethod in usingMethods)
            {
                if (usingMethod.GetGenericArgumentsFast().SequenceEqual(types))
                {
                    isFound = true;
                    break;
                }
            }
            if (!isFound)
            {
                return false;
            }
            #endif
            method = mi.MakeGenericMethodFast(types);
            return true;
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool ValidateGenericReturnableMethodRaw<TArg0, TArg1, TArg2, TReturn>(ref MethodBase method)
        {
            if (!method.IsGenericMethodDefinition)
            {
                return true;
            }
            var genericArguments = method.GetGenericArgumentsFast();
            if (genericArguments.Count < 4)
            {
                return false;
            }
            uint mask = 0;
            var mi = method as MethodInfo;
            var returnType = mi.ReturnType ?? typeof(void);
            var index = IndexOf(genericArguments, returnType);
            if (index >= 0)
            {
                mask |= 1u << index;
            }
            var parameters = method.GetParametersFast();
            var index0 = IndexOf(genericArguments, parameters[0].ParameterType);
            if (index0 >= 0)
            {
                mask |= 1u << index0;
            }
            var index1 = IndexOf(genericArguments, parameters[1].ParameterType);
            if (index1 >= 0)
            {
                mask |= 1u << index1;
            }
            var index2 = IndexOf(genericArguments, parameters[2].ParameterType);
            if (index2 >= 0)
            {
                mask |= 1u << index2;
            }
            if (REReflection.BitCount(mask) != genericArguments.Count)
            {
                return false;
            }
            var types = ArrayCache.GetArrayCache<Type>(genericArguments.Count);
            if (index >= 0)
            {
                types[index] = typeof(TReturn);
            }
            if (index0 >= 0)
            {
                types[index0] = typeof(TArg0);
            }
            if (index1 >= 0)
            {
                types[index1] = typeof(TArg1);
            }
            if (index2 >= 0)
            {
                types[index2] = typeof(TArg2);
            }
            #if ENABLE_IL2CPP
            bool isFound = false;
            var usingMethods = method.GetUsingGenericInstanceMethods();
            foreach (var usingMethod in usingMethods)
            {
                if (usingMethod.GetGenericArgumentsFast().SequenceEqual(types))
                {
                    isFound = true;
                    break;
                }
            }
            if (!isFound)
            {
                return false;
            }
            #endif
            method = mi.MakeGenericMethodFast(types);
            return true;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void InvokeInstanceFast<TTarget, TArg0, TArg1, TArg2, TArg3>(this MethodBase self, ref TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3)
        {
            bool isValid;
            nint pAddress;
            if (self.IsOverridable())
            {
                isValid = ValidateInstanceVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3>(self, target?.GetType(), out pAddress) ||
                          (pAddress != 0 && SecondaryValidateStaticMethod(self, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), ref pAddress));
            }
            else
            {
                isValid = ValidateInstanceMethod<TTarget, TArg0, TArg1, TArg2, TArg3>(self, out pAddress) ||
                          (pAddress != 0 && SecondaryValidateInstanceMethod(self, target?.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), ref pAddress));
            }
            if (!isValid)
            {
                self.InvokeInstanceLowAlloc(ref target, arg0, arg1, arg2, arg3);
                return;
            }
            unsafe
            {
                if (REType.IsValueTypeFast<TTarget>())
                {
                    ((delegate*<ref TTarget, TArg0, TArg1, TArg2, TArg3, void>)pAddress)(ref target, arg0, arg1, arg2, arg3);
                    return;
                }
                ((delegate*<TTarget, TArg0, TArg1, TArg2, TArg3, void>)pAddress)(target, arg0, arg1, arg2, arg3);
                return;
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void InvokeClassInstanceFast<TTarget, TArg0, TArg1, TArg2, TArg3>(this MethodBase self, TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3)
        where TTarget: class
        {
            bool isValid;
            nint pAddress;
            if (self.IsOverridable())
            {
                isValid = ValidateInstanceVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3>(self, target?.GetType(), out pAddress) ||
                          (pAddress != 0 && SecondaryValidateStaticMethod(self, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), ref pAddress));
            }
            else
            {
                isValid = ValidateInstanceMethod<TTarget, TArg0, TArg1, TArg2, TArg3>(self, out pAddress) ||
                          (pAddress != 0 && SecondaryValidateInstanceMethod(self, target?.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), ref pAddress));
            }
            if (!isValid)
            {
                self.InvokeClassInstanceLowAlloc(target, arg0, arg1, arg2, arg3);
                return;
            }
            unsafe
            {
                ((delegate*<TTarget, TArg0, TArg1, TArg2, TArg3, void>)pAddress)(target, arg0, arg1, arg2, arg3);
                return;
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void InvokeStructInstanceFast<TTarget, TArg0, TArg1, TArg2, TArg3>(this MethodBase self, ref TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3)
        where TTarget: struct
        {
            bool isValid;
            nint pAddress;
            if (self.IsOverridable())
            {
                isValid = ValidateInstanceVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3>(self, target.GetType(), out pAddress) ||
                          (pAddress != 0 && SecondaryValidateStaticMethod(self, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), ref pAddress));
            }
            else
            {
                isValid = ValidateInstanceMethod<TTarget, TArg0, TArg1, TArg2, TArg3>(self, out pAddress) ||
                          (pAddress != 0 && SecondaryValidateInstanceMethod(self, target.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), ref pAddress));
            }
            if (!isValid)
            {
                self.InvokeInstanceLowAlloc(ref target, arg0, arg1, arg2, arg3);
                return;
            }
            unsafe
            {
                ((delegate*<ref TTarget, TArg0, TArg1, TArg2, TArg3, void>)pAddress)(ref target, arg0, arg1, arg2, arg3);
                return;
            }
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool ValidateInstanceMethodRaw<TTarget, TArg0, TArg1, TArg2, TArg3>(MethodBase method, out nint pAddress)
        {
            pAddress = 0;
            if (method.IsStatic)
            {
                return false;
            }
            if (method.IsOverridable())
            {
                return false;
            }
            var isValidGeneric = !method.IsGenericMethodDefinition || ValidateGenericMethod<TArg0, TArg1, TArg2, TArg3>(ref method);
            if (!isValidGeneric)
            {
                return false;
            }
            var parameters = method.GetParametersFast();
            var parameterLength = parameters.Count;
            if (parameterLength != 4)
            {
                return false;
            }
            if (method is MethodInfo mi)
            {
                var returnType = mi?.ReturnType ?? typeof(void);
                if (returnType != typeof(void))
                {
                    return false;
                }
            }
            var reflectedType = method.ReflectedType;
            if (!reflectedType.IsValidInputWithoutRef<TTarget>(1, ref pAddress))
            {
                return false;
            }
            var paramType0 = parameters[0].ParameterType;
            if (!paramType0.IsValidInput<TArg0>(2, ref pAddress))
            {
                return false;
            }
            var paramType1 = parameters[1].ParameterType;
            if (!paramType1.IsValidInput<TArg1>(4, ref pAddress))
            {
                return false;
            }
            var paramType2 = parameters[2].ParameterType;
            if (!paramType2.IsValidInput<TArg2>(8, ref pAddress))
            {
                return false;
            }
            var paramType3 = parameters[3].ParameterType;
            if (!paramType3.IsValidInput<TArg3>(16, ref pAddress))
            {
                return false;
            }
            if (pAddress != 0)
            {
                return false;
            }
            pAddress = method.GetFunctionPointer();
            return true;
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool ValidateInstanceVirtualMethodRaw<TTarget, TArg0, TArg1, TArg2, TArg3>(MethodBase method, Type targetType, out nint pAddress)
        {
            pAddress = 0;
            if (method.IsStatic)
            {
                return false;
            }
            if (!method.IsOverridable())
            {
                return false;
            }
            var isValidGeneric = !method.IsGenericMethodDefinition || ValidateGenericMethod<TArg0, TArg1, TArg2, TArg3>(ref method);
            if (!isValidGeneric)
            {
                return false;
            }
            var parameters = method.GetParametersFast();
            var parameterLength = parameters.Count;
            if (parameterLength != 4)
            {
                return false;
            }
            if (method is MethodInfo mi)
            {
                var returnType = mi?.ReturnType ?? typeof(void);
                if (returnType != typeof(void))
                {
                    return false;
                }
            }
            var reflectedType = method.ReflectedType;
            if (!reflectedType.IsValidVirtualInput<TTarget>(targetType, out var isVirtualCall))
            {
                return false;
            }
            if (isVirtualCall)
            {
                ArrayCache.Types4[0] = parameters[0].ParameterType;
                ArrayCache.Types4[1] = parameters[1].ParameterType;
                ArrayCache.Types4[2] = parameters[2].ParameterType;
                ArrayCache.Types4[3] = parameters[3].ParameterType;
                method = targetType.GetInstanceMethodFullAccess(method.Name, null, ArrayCache.Types4, null);
            }
            var paramType0 = parameters[0].ParameterType;
            if (!paramType0.IsValidInput<TArg0>(2, ref pAddress))
            {
                return false;
            }
            var paramType1 = parameters[1].ParameterType;
            if (!paramType1.IsValidInput<TArg1>(4, ref pAddress))
            {
                return false;
            }
            var paramType2 = parameters[2].ParameterType;
            if (!paramType2.IsValidInput<TArg2>(8, ref pAddress))
            {
                return false;
            }
            var paramType3 = parameters[3].ParameterType;
            if (!paramType3.IsValidInput<TArg3>(16, ref pAddress))
            {
                return false;
            }
            if (pAddress != 0)
            {
                return false;
            }
            pAddress = method.GetFunctionPointer();
            return true;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TReturn InvokeInstanceFast<TTarget, TArg0, TArg1, TArg2, TArg3, TReturn>(this MethodBase self, ref TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3)
        {
            bool isValid;
            nint pAddress;
            if (self.IsOverridable())
            {
                isValid = ValidateInstanceReturnableVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TReturn>(self, target?.GetType(), out pAddress) ||
                          (pAddress != 0 && SecondaryValidateStaticMethod(self, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), ref pAddress));
            }
            else
            {
                isValid = ValidateInstanceReturnableMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TReturn>(self, out pAddress) ||
                          (pAddress != 0 && SecondaryValidateInstanceMethod(self, target?.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), ref pAddress));
            }
            if (!isValid)
            {
                return (TReturn)self.InvokeInstanceLowAlloc(ref target, arg0, arg1, arg2, arg3);
            }
            unsafe
            {
                if (REType.IsValueTypeFast<TTarget>())
                {
                    return ((delegate*<ref TTarget, TArg0, TArg1, TArg2, TArg3, TReturn>)pAddress)(ref target, arg0, arg1, arg2, arg3);
                }
                return ((delegate*<TTarget, TArg0, TArg1, TArg2, TArg3, TReturn>)pAddress)(target, arg0, arg1, arg2, arg3);
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TReturn InvokeClassInstanceFast<TTarget, TArg0, TArg1, TArg2, TArg3, TReturn>(this MethodBase self, TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3)
        where TTarget: class
        {
            bool isValid;
            nint pAddress;
            if (self.IsOverridable())
            {
                isValid = ValidateInstanceReturnableVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TReturn>(self, target?.GetType(), out pAddress) ||
                          (pAddress != 0 && SecondaryValidateStaticMethod(self, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), ref pAddress));
            }
            else
            {
                isValid = ValidateInstanceReturnableMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TReturn>(self, out pAddress) ||
                          (pAddress != 0 && SecondaryValidateInstanceMethod(self, target?.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), ref pAddress));
            }
            if (!isValid)
            {
                return (TReturn)self.InvokeClassInstanceLowAlloc(target, arg0, arg1, arg2, arg3);
            }
            unsafe
            {
                return ((delegate*<TTarget, TArg0, TArg1, TArg2, TArg3, TReturn>)pAddress)(target, arg0, arg1, arg2, arg3);
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TReturn InvokeStructInstanceFast<TTarget, TArg0, TArg1, TArg2, TArg3, TReturn>(this MethodBase self, ref TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3)
        where TTarget: struct
        {
            bool isValid;
            nint pAddress;
            if (self.IsOverridable())
            {
                isValid = ValidateInstanceReturnableVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TReturn>(self, target.GetType(), out pAddress) ||
                          (pAddress != 0 && SecondaryValidateStaticMethod(self, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), ref pAddress));
            }
            else
            {
                isValid = ValidateInstanceReturnableMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TReturn>(self, out pAddress) ||
                          (pAddress != 0 && SecondaryValidateInstanceMethod(self, target.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), ref pAddress));
            }
            if (!isValid)
            {
                return (TReturn)self.InvokeInstanceLowAlloc(ref target, arg0, arg1, arg2, arg3);
            }
            unsafe
            {
                return ((delegate*<ref TTarget, TArg0, TArg1, TArg2, TArg3, TReturn>)pAddress)(ref target, arg0, arg1, arg2, arg3);
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static object InvokeInstanceLowAlloc<TTarget, TArg0, TArg1, TArg2, TArg3>(this MethodBase self, ref TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3)
        {
            if (self.IsGenericMethodDefinition)
            {
                ValidateGenericMethod<TArg0, TArg1, TArg2, TArg3>(ref self);
            }
            var targetObj = REReflection.GetBoxWithoutRef(target);
            var parameters = self.GetParametersFast();
            ArrayCache.Objects4[0] = REReflection.GetBox(arg0, parameters[0], out var refArg0);
            ArrayCache.Objects4[1] = REReflection.GetBox(arg1, parameters[1], out var refArg1);
            ArrayCache.Objects4[2] = REReflection.GetBox(arg2, parameters[2], out var refArg2);
            ArrayCache.Objects4[3] = REReflection.GetBox(arg3, parameters[3], out var refArg3);
            try
            {
                return self.Invoke(targetObj, ArrayCache.Objects4);
            }
            finally
            {
                REReflection.Unbox(targetObj, out target);
                REReflection.ReturnBoxWithoutRef<TTarget>(targetObj);
                REReflection.ReturnBox<TArg0>(ArrayCache.Objects4[0], parameters[0], refArg0);
                REReflection.ReturnBox<TArg1>(ArrayCache.Objects4[1], parameters[1], refArg1);
                REReflection.ReturnBox<TArg2>(ArrayCache.Objects4[2], parameters[2], refArg2);
                REReflection.ReturnBox<TArg3>(ArrayCache.Objects4[3], parameters[3], refArg3);
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static object InvokeClassInstanceLowAlloc<TTarget, TArg0, TArg1, TArg2, TArg3>(this MethodBase self, TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3)
        where TTarget: class
        {
            if (self.IsGenericMethodDefinition)
            {
                ValidateGenericMethod<TArg0, TArg1, TArg2, TArg3>(ref self);
            }
            var parameters = self.GetParametersFast();
            ArrayCache.Objects4[0] = REReflection.GetBox(arg0, parameters[0], out var refArg0);
            ArrayCache.Objects4[1] = REReflection.GetBox(arg1, parameters[1], out var refArg1);
            ArrayCache.Objects4[2] = REReflection.GetBox(arg2, parameters[2], out var refArg2);
            ArrayCache.Objects4[3] = REReflection.GetBox(arg3, parameters[3], out var refArg3);
            try
            {
                return self.Invoke(target, ArrayCache.Objects4);
            }
            finally
            {
                REReflection.ReturnBox<TArg0>(ArrayCache.Objects4[0], parameters[0], refArg0);
                REReflection.ReturnBox<TArg1>(ArrayCache.Objects4[1], parameters[1], refArg1);
                REReflection.ReturnBox<TArg2>(ArrayCache.Objects4[2], parameters[2], refArg2);
                REReflection.ReturnBox<TArg3>(ArrayCache.Objects4[3], parameters[3], refArg3);
            }
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool ValidateInstanceReturnableMethodRaw<TTarget, TArg0, TArg1, TArg2, TArg3, TReturn>(MethodBase method, out nint pAddress)
        {
            pAddress = 0;
            if (method.IsStatic)
            {
                return false;
            }
            if (method.IsOverridable())
            {
                return false;
            }
            var isValidGeneric = !method.IsGenericMethodDefinition || ValidateGenericReturnableMethod<TArg0, TArg1, TArg2, TArg3, TReturn>(ref method);
            if (!isValidGeneric)
            {
                return false;
            }
            var parameters = method.GetParametersFast();
            var parameterLength = parameters.Count;
            if (parameterLength != 4)
            {
                return false;
            }
            if (method is MethodInfo mi)
            {
                var returnType = mi?.ReturnType ?? typeof(void);
                if (!returnType.IsValidOutput<TReturn>())
                {
                    return false;
                }
            }
            var reflectedType = method.ReflectedType;
            if (!reflectedType.IsValidInputWithoutRef<TTarget>(1, ref pAddress))
            {
                return false;
            }
            var paramType0 = parameters[0].ParameterType;
            if (!paramType0.IsValidInput<TArg0>(2, ref pAddress))
            {
                return false;
            }
            var paramType1 = parameters[1].ParameterType;
            if (!paramType1.IsValidInput<TArg1>(4, ref pAddress))
            {
                return false;
            }
            var paramType2 = parameters[2].ParameterType;
            if (!paramType2.IsValidInput<TArg2>(8, ref pAddress))
            {
                return false;
            }
            var paramType3 = parameters[3].ParameterType;
            if (!paramType3.IsValidInput<TArg3>(16, ref pAddress))
            {
                return false;
            }
            if (pAddress != 0)
            {
                return false;
            }
            pAddress = method.GetFunctionPointer();
            return true;
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool ValidateInstanceReturnableVirtualMethodRaw<TTarget, TArg0, TArg1, TArg2, TArg3, TReturn>(MethodBase method, Type targetType, out nint pAddress)
        {
            pAddress = 0;
            if (method.IsStatic)
            {
                return false;
            }
            if (!method.IsOverridable())
            {
                return false;
            }
            var isValidGeneric = !method.IsGenericMethodDefinition || ValidateGenericReturnableMethod<TArg0, TArg1, TArg2, TArg3, TReturn>(ref method);
            if (!isValidGeneric)
            {
                return false;
            }
            var parameters = method.GetParametersFast();
            var parameterLength = parameters.Count;
            if (parameterLength != 4)
            {
                return false;
            }
            if (method is MethodInfo mi)
            {
                var returnType = mi?.ReturnType ?? typeof(void);
                if (!returnType.IsValidOutput<TReturn>())
                {
                    return false;
                }
            }
            var reflectedType = method.ReflectedType;
            if (!reflectedType.IsValidVirtualInput<TTarget>(targetType, out var isVirtualCall))
            {
                return false;
            }
            if (isVirtualCall)
            {
                ArrayCache.Types4[0] = parameters[0].ParameterType;
                ArrayCache.Types4[1] = parameters[1].ParameterType;
                ArrayCache.Types4[2] = parameters[2].ParameterType;
                ArrayCache.Types4[3] = parameters[3].ParameterType;
                method = targetType.GetInstanceMethodFullAccess(method.Name, null, ArrayCache.Types4, null);
            }
            var paramType0 = parameters[0].ParameterType;
            if (!paramType0.IsValidInput<TArg0>(2, ref pAddress))
            {
                return false;
            }
            var paramType1 = parameters[1].ParameterType;
            if (!paramType1.IsValidInput<TArg1>(4, ref pAddress))
            {
                return false;
            }
            var paramType2 = parameters[2].ParameterType;
            if (!paramType2.IsValidInput<TArg2>(8, ref pAddress))
            {
                return false;
            }
            var paramType3 = parameters[3].ParameterType;
            if (!paramType3.IsValidInput<TArg3>(16, ref pAddress))
            {
                return false;
            }
            if (pAddress != 0)
            {
                return false;
            }
            pAddress = method.GetFunctionPointer();
            return true;
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool SecondaryValidateInstanceMethodRaw(MethodBase method, Type target, Type arg0, Type arg1, Type arg2, Type arg3, ref nint pAddress)
        {
            if ((pAddress & 1) != 0)
            {
                var reflectedType = method.ReflectedType;
                if (!reflectedType.IsNullAssignableFromFast(target))
                {
                    return false;
                }
            }
            var parameters = method.GetParametersFast();
            if ((pAddress & 2) != 0)
            {
                var paramType = parameters[0].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg0))
                {
                    return false;
                }
            }
            if ((pAddress & 4) != 0)
            {
                var paramType = parameters[1].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg1))
                {
                    return false;
                }
            }
            if ((pAddress & 8) != 0)
            {
                var paramType = parameters[2].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg2))
                {
                    return false;
                }
            }
            if ((pAddress & 16) != 0)
            {
                var paramType = parameters[3].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg3))
                {
                    return false;
                }
            }
            pAddress = method.GetFunctionPointer();
            return true;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void InvokeStaticFast<TArg0, TArg1, TArg2, TArg3>(this MethodBase self, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3)
        {
            bool isValid;
            nint pAddress;
            isValid = ValidateStaticMethod<TArg0, TArg1, TArg2, TArg3>(self, out pAddress) ||
                      (pAddress != 0 && SecondaryValidateStaticMethod(self, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), ref pAddress));
            if (!isValid)
            {
                self.InvokeStaticLowAlloc(arg0, arg1, arg2, arg3);
                return;
            }
            unsafe
            {
                ((delegate*<TArg0, TArg1, TArg2, TArg3, void>)pAddress)(arg0, arg1, arg2, arg3);
                return;
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static object InvokeStaticLowAlloc<TArg0, TArg1, TArg2, TArg3>(this MethodBase self, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3)
        {
            if (self.IsGenericMethodDefinition)
            {
                ValidateGenericMethod<TArg0, TArg1, TArg2, TArg3>(ref self);
            }
            var parameters = self.GetParametersFast();
            ArrayCache.Objects4[0] = REReflection.GetBox(arg0, parameters[0], out var refArg0);
            ArrayCache.Objects4[1] = REReflection.GetBox(arg1, parameters[1], out var refArg1);
            ArrayCache.Objects4[2] = REReflection.GetBox(arg2, parameters[2], out var refArg2);
            ArrayCache.Objects4[3] = REReflection.GetBox(arg3, parameters[3], out var refArg3);
            try
            {
                return self.Invoke(null, ArrayCache.Objects4);
            }
            finally
            {
                REReflection.ReturnBox<TArg0>(ArrayCache.Objects4[0], parameters[0], refArg0);
                REReflection.ReturnBox<TArg1>(ArrayCache.Objects4[1], parameters[1], refArg1);
                REReflection.ReturnBox<TArg2>(ArrayCache.Objects4[2], parameters[2], refArg2);
                REReflection.ReturnBox<TArg3>(ArrayCache.Objects4[3], parameters[3], refArg3);
            }
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool ValidateStaticMethodRaw<TArg0, TArg1, TArg2, TArg3>(MethodBase method, out nint pAddress)
        {
            pAddress = 0;
            if (!method.IsStatic)
            {
                return false;
            }
            if (method.IsOverridable())
            {
                return false;
            }
            var isValidGeneric = !method.IsGenericMethodDefinition || ValidateGenericMethod<TArg0, TArg1, TArg2, TArg3>(ref method);
            if (!isValidGeneric)
            {
                return false;
            }
            var parameters = method.GetParametersFast();
            var parameterLength = parameters.Count;
            if (parameterLength != 4)
            {
                return false;
            }
            if (method is MethodInfo mi)
            {
                var returnType = mi?.ReturnType ?? typeof(void);
                if (returnType != typeof(void))
                {
                    return false;
                }
            }
            var paramType0 = parameters[0].ParameterType;
            if (!paramType0.IsValidInput<TArg0>(2, ref pAddress))
            {
                return false;
            }
            var paramType1 = parameters[1].ParameterType;
            if (!paramType1.IsValidInput<TArg1>(4, ref pAddress))
            {
                return false;
            }
            var paramType2 = parameters[2].ParameterType;
            if (!paramType2.IsValidInput<TArg2>(8, ref pAddress))
            {
                return false;
            }
            var paramType3 = parameters[3].ParameterType;
            if (!paramType3.IsValidInput<TArg3>(16, ref pAddress))
            {
                return false;
            }
            if (pAddress != 0)
            {
                return false;
            }
            pAddress = method.GetFunctionPointer();
            return true;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TReturn InvokeStaticFast<TArg0, TArg1, TArg2, TArg3, TReturn>(this MethodBase self, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3)
        {
            bool isValid;
            nint pAddress;
            isValid = ValidateStaticReturnableMethod<TArg0, TArg1, TArg2, TArg3, TReturn>(self, out pAddress) ||
                      (pAddress != 0 && SecondaryValidateStaticMethod(self, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), ref pAddress));
            if (!isValid)
            {
                return (TReturn)self.InvokeStaticLowAlloc(arg0, arg1, arg2, arg3);
            }
            unsafe
            {
                return ((delegate*<TArg0, TArg1, TArg2, TArg3, TReturn>)pAddress)(arg0, arg1, arg2, arg3);
            }
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool ValidateStaticReturnableMethodRaw<TArg0, TArg1, TArg2, TArg3, TReturn>(MethodBase method, out nint pAddress)
        {
            pAddress = 0;
            if (!method.IsStatic)
            {
                return false;
            }
            if (method.IsOverridable())
            {
                return false;
            }
            var isValidGeneric = !method.IsGenericMethodDefinition || ValidateGenericReturnableMethod<TArg0, TArg1, TArg2, TArg3, TReturn>(ref method);
            if (!isValidGeneric)
            {
                return false;
            }
            var parameters = method.GetParametersFast();
            var parameterLength = parameters.Count;
            if (parameterLength != 4)
            {
                return false;
            }
            if (method is MethodInfo mi)
            {
                var returnType = mi?.ReturnType ?? typeof(void);
                if (!returnType.IsValidOutput<TReturn>())
                {
                    return false;
                }
            }
            var paramType0 = parameters[0].ParameterType;
            if (!paramType0.IsValidInput<TArg0>(2, ref pAddress))
            {
                return false;
            }
            var paramType1 = parameters[1].ParameterType;
            if (!paramType1.IsValidInput<TArg1>(4, ref pAddress))
            {
                return false;
            }
            var paramType2 = parameters[2].ParameterType;
            if (!paramType2.IsValidInput<TArg2>(8, ref pAddress))
            {
                return false;
            }
            var paramType3 = parameters[3].ParameterType;
            if (!paramType3.IsValidInput<TArg3>(16, ref pAddress))
            {
                return false;
            }
            if (pAddress != 0)
            {
                return false;
            }
            pAddress = method.GetFunctionPointer();
            return true;
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool SecondaryValidateStaticMethodRaw(MethodBase method, Type arg0, Type arg1, Type arg2, Type arg3, ref nint pAddress)
        {
            var parameters = method.GetParametersFast();
            if ((pAddress & 2) != 0)
            {
                var paramType = parameters[0].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg0))
                {
                    return false;
                }
            }
            if ((pAddress & 4) != 0)
            {
                var paramType = parameters[1].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg1))
                {
                    return false;
                }
            }
            if ((pAddress & 8) != 0)
            {
                var paramType = parameters[2].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg2))
                {
                    return false;
                }
            }
            if ((pAddress & 16) != 0)
            {
                var paramType = parameters[3].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg3))
                {
                    return false;
                }
            }
            pAddress = method.GetFunctionPointer();
            return true;
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool ValidateGenericMethodRaw<TArg0, TArg1, TArg2, TArg3>(ref MethodBase method)
        {
            if (!method.IsGenericMethodDefinition)
            {
                return true;
            }
            var genericArguments = method.GetGenericArgumentsFast();
            if (genericArguments.Count < 4)
            {
                return false;
            }
            uint mask = 0;
            var mi = method as MethodInfo;
            var parameters = method.GetParametersFast();
            var index0 = IndexOf(genericArguments, parameters[0].ParameterType);
            if (index0 >= 0)
            {
                mask |= 1u << index0;
            }
            var index1 = IndexOf(genericArguments, parameters[1].ParameterType);
            if (index1 >= 0)
            {
                mask |= 1u << index1;
            }
            var index2 = IndexOf(genericArguments, parameters[2].ParameterType);
            if (index2 >= 0)
            {
                mask |= 1u << index2;
            }
            var index3 = IndexOf(genericArguments, parameters[3].ParameterType);
            if (index3 >= 0)
            {
                mask |= 1u << index3;
            }
            if (REReflection.BitCount(mask) != genericArguments.Count)
            {
                return false;
            }
            var types = ArrayCache.GetArrayCache<Type>(genericArguments.Count);
            if (index0 >= 0)
            {
                types[index0] = typeof(TArg0);
            }
            if (index1 >= 0)
            {
                types[index1] = typeof(TArg1);
            }
            if (index2 >= 0)
            {
                types[index2] = typeof(TArg2);
            }
            if (index3 >= 0)
            {
                types[index3] = typeof(TArg3);
            }
            #if ENABLE_IL2CPP
            bool isFound = false;
            var usingMethods = method.GetUsingGenericInstanceMethods();
            foreach (var usingMethod in usingMethods)
            {
                if (usingMethod.GetGenericArgumentsFast().SequenceEqual(types))
                {
                    isFound = true;
                    break;
                }
            }
            if (!isFound)
            {
                return false;
            }
            #endif
            method = mi.MakeGenericMethodFast(types);
            return true;
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool ValidateGenericReturnableMethodRaw<TArg0, TArg1, TArg2, TArg3, TReturn>(ref MethodBase method)
        {
            if (!method.IsGenericMethodDefinition)
            {
                return true;
            }
            var genericArguments = method.GetGenericArgumentsFast();
            if (genericArguments.Count < 5)
            {
                return false;
            }
            uint mask = 0;
            var mi = method as MethodInfo;
            var returnType = mi.ReturnType ?? typeof(void);
            var index = IndexOf(genericArguments, returnType);
            if (index >= 0)
            {
                mask |= 1u << index;
            }
            var parameters = method.GetParametersFast();
            var index0 = IndexOf(genericArguments, parameters[0].ParameterType);
            if (index0 >= 0)
            {
                mask |= 1u << index0;
            }
            var index1 = IndexOf(genericArguments, parameters[1].ParameterType);
            if (index1 >= 0)
            {
                mask |= 1u << index1;
            }
            var index2 = IndexOf(genericArguments, parameters[2].ParameterType);
            if (index2 >= 0)
            {
                mask |= 1u << index2;
            }
            var index3 = IndexOf(genericArguments, parameters[3].ParameterType);
            if (index3 >= 0)
            {
                mask |= 1u << index3;
            }
            if (REReflection.BitCount(mask) != genericArguments.Count)
            {
                return false;
            }
            var types = ArrayCache.GetArrayCache<Type>(genericArguments.Count);
            if (index >= 0)
            {
                types[index] = typeof(TReturn);
            }
            if (index0 >= 0)
            {
                types[index0] = typeof(TArg0);
            }
            if (index1 >= 0)
            {
                types[index1] = typeof(TArg1);
            }
            if (index2 >= 0)
            {
                types[index2] = typeof(TArg2);
            }
            if (index3 >= 0)
            {
                types[index3] = typeof(TArg3);
            }
            #if ENABLE_IL2CPP
            bool isFound = false;
            var usingMethods = method.GetUsingGenericInstanceMethods();
            foreach (var usingMethod in usingMethods)
            {
                if (usingMethod.GetGenericArgumentsFast().SequenceEqual(types))
                {
                    isFound = true;
                    break;
                }
            }
            if (!isFound)
            {
                return false;
            }
            #endif
            method = mi.MakeGenericMethodFast(types);
            return true;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void InvokeInstanceFast<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4>(this MethodBase self, ref TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4)
        {
            bool isValid;
            nint pAddress;
            if (self.IsOverridable())
            {
                isValid = ValidateInstanceVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4>(self, target?.GetType(), out pAddress) ||
                          (pAddress != 0 && SecondaryValidateStaticMethod(self, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), ref pAddress));
            }
            else
            {
                isValid = ValidateInstanceMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4>(self, out pAddress) ||
                          (pAddress != 0 && SecondaryValidateInstanceMethod(self, target?.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), ref pAddress));
            }
            if (!isValid)
            {
                self.InvokeInstanceLowAlloc(ref target, arg0, arg1, arg2, arg3, arg4);
                return;
            }
            unsafe
            {
                if (REType.IsValueTypeFast<TTarget>())
                {
                    ((delegate*<ref TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, void>)pAddress)(ref target, arg0, arg1, arg2, arg3, arg4);
                    return;
                }
                ((delegate*<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, void>)pAddress)(target, arg0, arg1, arg2, arg3, arg4);
                return;
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void InvokeClassInstanceFast<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4>(this MethodBase self, TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4)
        where TTarget: class
        {
            bool isValid;
            nint pAddress;
            if (self.IsOverridable())
            {
                isValid = ValidateInstanceVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4>(self, target?.GetType(), out pAddress) ||
                          (pAddress != 0 && SecondaryValidateStaticMethod(self, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), ref pAddress));
            }
            else
            {
                isValid = ValidateInstanceMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4>(self, out pAddress) ||
                          (pAddress != 0 && SecondaryValidateInstanceMethod(self, target?.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), ref pAddress));
            }
            if (!isValid)
            {
                self.InvokeClassInstanceLowAlloc(target, arg0, arg1, arg2, arg3, arg4);
                return;
            }
            unsafe
            {
                ((delegate*<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, void>)pAddress)(target, arg0, arg1, arg2, arg3, arg4);
                return;
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void InvokeStructInstanceFast<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4>(this MethodBase self, ref TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4)
        where TTarget: struct
        {
            bool isValid;
            nint pAddress;
            if (self.IsOverridable())
            {
                isValid = ValidateInstanceVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4>(self, target.GetType(), out pAddress) ||
                          (pAddress != 0 && SecondaryValidateStaticMethod(self, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), ref pAddress));
            }
            else
            {
                isValid = ValidateInstanceMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4>(self, out pAddress) ||
                          (pAddress != 0 && SecondaryValidateInstanceMethod(self, target.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), ref pAddress));
            }
            if (!isValid)
            {
                self.InvokeInstanceLowAlloc(ref target, arg0, arg1, arg2, arg3, arg4);
                return;
            }
            unsafe
            {
                ((delegate*<ref TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, void>)pAddress)(ref target, arg0, arg1, arg2, arg3, arg4);
                return;
            }
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool ValidateInstanceMethodRaw<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4>(MethodBase method, out nint pAddress)
        {
            pAddress = 0;
            if (method.IsStatic)
            {
                return false;
            }
            if (method.IsOverridable())
            {
                return false;
            }
            var isValidGeneric = !method.IsGenericMethodDefinition || ValidateGenericMethod<TArg0, TArg1, TArg2, TArg3, TArg4>(ref method);
            if (!isValidGeneric)
            {
                return false;
            }
            var parameters = method.GetParametersFast();
            var parameterLength = parameters.Count;
            if (parameterLength != 5)
            {
                return false;
            }
            if (method is MethodInfo mi)
            {
                var returnType = mi?.ReturnType ?? typeof(void);
                if (returnType != typeof(void))
                {
                    return false;
                }
            }
            var reflectedType = method.ReflectedType;
            if (!reflectedType.IsValidInputWithoutRef<TTarget>(1, ref pAddress))
            {
                return false;
            }
            var paramType0 = parameters[0].ParameterType;
            if (!paramType0.IsValidInput<TArg0>(2, ref pAddress))
            {
                return false;
            }
            var paramType1 = parameters[1].ParameterType;
            if (!paramType1.IsValidInput<TArg1>(4, ref pAddress))
            {
                return false;
            }
            var paramType2 = parameters[2].ParameterType;
            if (!paramType2.IsValidInput<TArg2>(8, ref pAddress))
            {
                return false;
            }
            var paramType3 = parameters[3].ParameterType;
            if (!paramType3.IsValidInput<TArg3>(16, ref pAddress))
            {
                return false;
            }
            var paramType4 = parameters[4].ParameterType;
            if (!paramType4.IsValidInput<TArg4>(32, ref pAddress))
            {
                return false;
            }
            if (pAddress != 0)
            {
                return false;
            }
            pAddress = method.GetFunctionPointer();
            return true;
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool ValidateInstanceVirtualMethodRaw<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4>(MethodBase method, Type targetType, out nint pAddress)
        {
            pAddress = 0;
            if (method.IsStatic)
            {
                return false;
            }
            if (!method.IsOverridable())
            {
                return false;
            }
            var isValidGeneric = !method.IsGenericMethodDefinition || ValidateGenericMethod<TArg0, TArg1, TArg2, TArg3, TArg4>(ref method);
            if (!isValidGeneric)
            {
                return false;
            }
            var parameters = method.GetParametersFast();
            var parameterLength = parameters.Count;
            if (parameterLength != 5)
            {
                return false;
            }
            if (method is MethodInfo mi)
            {
                var returnType = mi?.ReturnType ?? typeof(void);
                if (returnType != typeof(void))
                {
                    return false;
                }
            }
            var reflectedType = method.ReflectedType;
            if (!reflectedType.IsValidVirtualInput<TTarget>(targetType, out var isVirtualCall))
            {
                return false;
            }
            if (isVirtualCall)
            {
                ArrayCache.Types5[0] = parameters[0].ParameterType;
                ArrayCache.Types5[1] = parameters[1].ParameterType;
                ArrayCache.Types5[2] = parameters[2].ParameterType;
                ArrayCache.Types5[3] = parameters[3].ParameterType;
                ArrayCache.Types5[4] = parameters[4].ParameterType;
                method = targetType.GetInstanceMethodFullAccess(method.Name, null, ArrayCache.Types5, null);
            }
            var paramType0 = parameters[0].ParameterType;
            if (!paramType0.IsValidInput<TArg0>(2, ref pAddress))
            {
                return false;
            }
            var paramType1 = parameters[1].ParameterType;
            if (!paramType1.IsValidInput<TArg1>(4, ref pAddress))
            {
                return false;
            }
            var paramType2 = parameters[2].ParameterType;
            if (!paramType2.IsValidInput<TArg2>(8, ref pAddress))
            {
                return false;
            }
            var paramType3 = parameters[3].ParameterType;
            if (!paramType3.IsValidInput<TArg3>(16, ref pAddress))
            {
                return false;
            }
            var paramType4 = parameters[4].ParameterType;
            if (!paramType4.IsValidInput<TArg4>(32, ref pAddress))
            {
                return false;
            }
            if (pAddress != 0)
            {
                return false;
            }
            pAddress = method.GetFunctionPointer();
            return true;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TReturn InvokeInstanceFast<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TReturn>(this MethodBase self, ref TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4)
        {
            bool isValid;
            nint pAddress;
            if (self.IsOverridable())
            {
                isValid = ValidateInstanceReturnableVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TReturn>(self, target?.GetType(), out pAddress) ||
                          (pAddress != 0 && SecondaryValidateStaticMethod(self, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), ref pAddress));
            }
            else
            {
                isValid = ValidateInstanceReturnableMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TReturn>(self, out pAddress) ||
                          (pAddress != 0 && SecondaryValidateInstanceMethod(self, target?.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), ref pAddress));
            }
            if (!isValid)
            {
                return (TReturn)self.InvokeInstanceLowAlloc(ref target, arg0, arg1, arg2, arg3, arg4);
            }
            unsafe
            {
                if (REType.IsValueTypeFast<TTarget>())
                {
                    return ((delegate*<ref TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TReturn>)pAddress)(ref target, arg0, arg1, arg2, arg3, arg4);
                }
                return ((delegate*<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TReturn>)pAddress)(target, arg0, arg1, arg2, arg3, arg4);
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TReturn InvokeClassInstanceFast<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TReturn>(this MethodBase self, TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4)
        where TTarget: class
        {
            bool isValid;
            nint pAddress;
            if (self.IsOverridable())
            {
                isValid = ValidateInstanceReturnableVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TReturn>(self, target?.GetType(), out pAddress) ||
                          (pAddress != 0 && SecondaryValidateStaticMethod(self, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), ref pAddress));
            }
            else
            {
                isValid = ValidateInstanceReturnableMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TReturn>(self, out pAddress) ||
                          (pAddress != 0 && SecondaryValidateInstanceMethod(self, target?.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), ref pAddress));
            }
            if (!isValid)
            {
                return (TReturn)self.InvokeClassInstanceLowAlloc(target, arg0, arg1, arg2, arg3, arg4);
            }
            unsafe
            {
                return ((delegate*<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TReturn>)pAddress)(target, arg0, arg1, arg2, arg3, arg4);
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TReturn InvokeStructInstanceFast<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TReturn>(this MethodBase self, ref TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4)
        where TTarget: struct
        {
            bool isValid;
            nint pAddress;
            if (self.IsOverridable())
            {
                isValid = ValidateInstanceReturnableVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TReturn>(self, target.GetType(), out pAddress) ||
                          (pAddress != 0 && SecondaryValidateStaticMethod(self, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), ref pAddress));
            }
            else
            {
                isValid = ValidateInstanceReturnableMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TReturn>(self, out pAddress) ||
                          (pAddress != 0 && SecondaryValidateInstanceMethod(self, target.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), ref pAddress));
            }
            if (!isValid)
            {
                return (TReturn)self.InvokeInstanceLowAlloc(ref target, arg0, arg1, arg2, arg3, arg4);
            }
            unsafe
            {
                return ((delegate*<ref TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TReturn>)pAddress)(ref target, arg0, arg1, arg2, arg3, arg4);
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static object InvokeInstanceLowAlloc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4>(this MethodBase self, ref TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4)
        {
            if (self.IsGenericMethodDefinition)
            {
                ValidateGenericMethod<TArg0, TArg1, TArg2, TArg3, TArg4>(ref self);
            }
            var targetObj = REReflection.GetBoxWithoutRef(target);
            var parameters = self.GetParametersFast();
            ArrayCache.Objects5[0] = REReflection.GetBox(arg0, parameters[0], out var refArg0);
            ArrayCache.Objects5[1] = REReflection.GetBox(arg1, parameters[1], out var refArg1);
            ArrayCache.Objects5[2] = REReflection.GetBox(arg2, parameters[2], out var refArg2);
            ArrayCache.Objects5[3] = REReflection.GetBox(arg3, parameters[3], out var refArg3);
            ArrayCache.Objects5[4] = REReflection.GetBox(arg4, parameters[4], out var refArg4);
            try
            {
                return self.Invoke(targetObj, ArrayCache.Objects5);
            }
            finally
            {
                REReflection.Unbox(targetObj, out target);
                REReflection.ReturnBoxWithoutRef<TTarget>(targetObj);
                REReflection.ReturnBox<TArg0>(ArrayCache.Objects5[0], parameters[0], refArg0);
                REReflection.ReturnBox<TArg1>(ArrayCache.Objects5[1], parameters[1], refArg1);
                REReflection.ReturnBox<TArg2>(ArrayCache.Objects5[2], parameters[2], refArg2);
                REReflection.ReturnBox<TArg3>(ArrayCache.Objects5[3], parameters[3], refArg3);
                REReflection.ReturnBox<TArg4>(ArrayCache.Objects5[4], parameters[4], refArg4);
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static object InvokeClassInstanceLowAlloc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4>(this MethodBase self, TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4)
        where TTarget: class
        {
            if (self.IsGenericMethodDefinition)
            {
                ValidateGenericMethod<TArg0, TArg1, TArg2, TArg3, TArg4>(ref self);
            }
            var parameters = self.GetParametersFast();
            ArrayCache.Objects5[0] = REReflection.GetBox(arg0, parameters[0], out var refArg0);
            ArrayCache.Objects5[1] = REReflection.GetBox(arg1, parameters[1], out var refArg1);
            ArrayCache.Objects5[2] = REReflection.GetBox(arg2, parameters[2], out var refArg2);
            ArrayCache.Objects5[3] = REReflection.GetBox(arg3, parameters[3], out var refArg3);
            ArrayCache.Objects5[4] = REReflection.GetBox(arg4, parameters[4], out var refArg4);
            try
            {
                return self.Invoke(target, ArrayCache.Objects5);
            }
            finally
            {
                REReflection.ReturnBox<TArg0>(ArrayCache.Objects5[0], parameters[0], refArg0);
                REReflection.ReturnBox<TArg1>(ArrayCache.Objects5[1], parameters[1], refArg1);
                REReflection.ReturnBox<TArg2>(ArrayCache.Objects5[2], parameters[2], refArg2);
                REReflection.ReturnBox<TArg3>(ArrayCache.Objects5[3], parameters[3], refArg3);
                REReflection.ReturnBox<TArg4>(ArrayCache.Objects5[4], parameters[4], refArg4);
            }
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool ValidateInstanceReturnableMethodRaw<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TReturn>(MethodBase method, out nint pAddress)
        {
            pAddress = 0;
            if (method.IsStatic)
            {
                return false;
            }
            if (method.IsOverridable())
            {
                return false;
            }
            var isValidGeneric = !method.IsGenericMethodDefinition || ValidateGenericReturnableMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TReturn>(ref method);
            if (!isValidGeneric)
            {
                return false;
            }
            var parameters = method.GetParametersFast();
            var parameterLength = parameters.Count;
            if (parameterLength != 5)
            {
                return false;
            }
            if (method is MethodInfo mi)
            {
                var returnType = mi?.ReturnType ?? typeof(void);
                if (!returnType.IsValidOutput<TReturn>())
                {
                    return false;
                }
            }
            var reflectedType = method.ReflectedType;
            if (!reflectedType.IsValidInputWithoutRef<TTarget>(1, ref pAddress))
            {
                return false;
            }
            var paramType0 = parameters[0].ParameterType;
            if (!paramType0.IsValidInput<TArg0>(2, ref pAddress))
            {
                return false;
            }
            var paramType1 = parameters[1].ParameterType;
            if (!paramType1.IsValidInput<TArg1>(4, ref pAddress))
            {
                return false;
            }
            var paramType2 = parameters[2].ParameterType;
            if (!paramType2.IsValidInput<TArg2>(8, ref pAddress))
            {
                return false;
            }
            var paramType3 = parameters[3].ParameterType;
            if (!paramType3.IsValidInput<TArg3>(16, ref pAddress))
            {
                return false;
            }
            var paramType4 = parameters[4].ParameterType;
            if (!paramType4.IsValidInput<TArg4>(32, ref pAddress))
            {
                return false;
            }
            if (pAddress != 0)
            {
                return false;
            }
            pAddress = method.GetFunctionPointer();
            return true;
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool ValidateInstanceReturnableVirtualMethodRaw<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TReturn>(MethodBase method, Type targetType, out nint pAddress)
        {
            pAddress = 0;
            if (method.IsStatic)
            {
                return false;
            }
            if (!method.IsOverridable())
            {
                return false;
            }
            var isValidGeneric = !method.IsGenericMethodDefinition || ValidateGenericReturnableMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TReturn>(ref method);
            if (!isValidGeneric)
            {
                return false;
            }
            var parameters = method.GetParametersFast();
            var parameterLength = parameters.Count;
            if (parameterLength != 5)
            {
                return false;
            }
            if (method is MethodInfo mi)
            {
                var returnType = mi?.ReturnType ?? typeof(void);
                if (!returnType.IsValidOutput<TReturn>())
                {
                    return false;
                }
            }
            var reflectedType = method.ReflectedType;
            if (!reflectedType.IsValidVirtualInput<TTarget>(targetType, out var isVirtualCall))
            {
                return false;
            }
            if (isVirtualCall)
            {
                ArrayCache.Types5[0] = parameters[0].ParameterType;
                ArrayCache.Types5[1] = parameters[1].ParameterType;
                ArrayCache.Types5[2] = parameters[2].ParameterType;
                ArrayCache.Types5[3] = parameters[3].ParameterType;
                ArrayCache.Types5[4] = parameters[4].ParameterType;
                method = targetType.GetInstanceMethodFullAccess(method.Name, null, ArrayCache.Types5, null);
            }
            var paramType0 = parameters[0].ParameterType;
            if (!paramType0.IsValidInput<TArg0>(2, ref pAddress))
            {
                return false;
            }
            var paramType1 = parameters[1].ParameterType;
            if (!paramType1.IsValidInput<TArg1>(4, ref pAddress))
            {
                return false;
            }
            var paramType2 = parameters[2].ParameterType;
            if (!paramType2.IsValidInput<TArg2>(8, ref pAddress))
            {
                return false;
            }
            var paramType3 = parameters[3].ParameterType;
            if (!paramType3.IsValidInput<TArg3>(16, ref pAddress))
            {
                return false;
            }
            var paramType4 = parameters[4].ParameterType;
            if (!paramType4.IsValidInput<TArg4>(32, ref pAddress))
            {
                return false;
            }
            if (pAddress != 0)
            {
                return false;
            }
            pAddress = method.GetFunctionPointer();
            return true;
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool SecondaryValidateInstanceMethodRaw(MethodBase method, Type target, Type arg0, Type arg1, Type arg2, Type arg3, Type arg4, ref nint pAddress)
        {
            if ((pAddress & 1) != 0)
            {
                var reflectedType = method.ReflectedType;
                if (!reflectedType.IsNullAssignableFromFast(target))
                {
                    return false;
                }
            }
            var parameters = method.GetParametersFast();
            if ((pAddress & 2) != 0)
            {
                var paramType = parameters[0].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg0))
                {
                    return false;
                }
            }
            if ((pAddress & 4) != 0)
            {
                var paramType = parameters[1].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg1))
                {
                    return false;
                }
            }
            if ((pAddress & 8) != 0)
            {
                var paramType = parameters[2].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg2))
                {
                    return false;
                }
            }
            if ((pAddress & 16) != 0)
            {
                var paramType = parameters[3].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg3))
                {
                    return false;
                }
            }
            if ((pAddress & 32) != 0)
            {
                var paramType = parameters[4].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg4))
                {
                    return false;
                }
            }
            pAddress = method.GetFunctionPointer();
            return true;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void InvokeStaticFast<TArg0, TArg1, TArg2, TArg3, TArg4>(this MethodBase self, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4)
        {
            bool isValid;
            nint pAddress;
            isValid = ValidateStaticMethod<TArg0, TArg1, TArg2, TArg3, TArg4>(self, out pAddress) ||
                      (pAddress != 0 && SecondaryValidateStaticMethod(self, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), ref pAddress));
            if (!isValid)
            {
                self.InvokeStaticLowAlloc(arg0, arg1, arg2, arg3, arg4);
                return;
            }
            unsafe
            {
                ((delegate*<TArg0, TArg1, TArg2, TArg3, TArg4, void>)pAddress)(arg0, arg1, arg2, arg3, arg4);
                return;
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static object InvokeStaticLowAlloc<TArg0, TArg1, TArg2, TArg3, TArg4>(this MethodBase self, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4)
        {
            if (self.IsGenericMethodDefinition)
            {
                ValidateGenericMethod<TArg0, TArg1, TArg2, TArg3, TArg4>(ref self);
            }
            var parameters = self.GetParametersFast();
            ArrayCache.Objects5[0] = REReflection.GetBox(arg0, parameters[0], out var refArg0);
            ArrayCache.Objects5[1] = REReflection.GetBox(arg1, parameters[1], out var refArg1);
            ArrayCache.Objects5[2] = REReflection.GetBox(arg2, parameters[2], out var refArg2);
            ArrayCache.Objects5[3] = REReflection.GetBox(arg3, parameters[3], out var refArg3);
            ArrayCache.Objects5[4] = REReflection.GetBox(arg4, parameters[4], out var refArg4);
            try
            {
                return self.Invoke(null, ArrayCache.Objects5);
            }
            finally
            {
                REReflection.ReturnBox<TArg0>(ArrayCache.Objects5[0], parameters[0], refArg0);
                REReflection.ReturnBox<TArg1>(ArrayCache.Objects5[1], parameters[1], refArg1);
                REReflection.ReturnBox<TArg2>(ArrayCache.Objects5[2], parameters[2], refArg2);
                REReflection.ReturnBox<TArg3>(ArrayCache.Objects5[3], parameters[3], refArg3);
                REReflection.ReturnBox<TArg4>(ArrayCache.Objects5[4], parameters[4], refArg4);
            }
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool ValidateStaticMethodRaw<TArg0, TArg1, TArg2, TArg3, TArg4>(MethodBase method, out nint pAddress)
        {
            pAddress = 0;
            if (!method.IsStatic)
            {
                return false;
            }
            if (method.IsOverridable())
            {
                return false;
            }
            var isValidGeneric = !method.IsGenericMethodDefinition || ValidateGenericMethod<TArg0, TArg1, TArg2, TArg3, TArg4>(ref method);
            if (!isValidGeneric)
            {
                return false;
            }
            var parameters = method.GetParametersFast();
            var parameterLength = parameters.Count;
            if (parameterLength != 5)
            {
                return false;
            }
            if (method is MethodInfo mi)
            {
                var returnType = mi?.ReturnType ?? typeof(void);
                if (returnType != typeof(void))
                {
                    return false;
                }
            }
            var paramType0 = parameters[0].ParameterType;
            if (!paramType0.IsValidInput<TArg0>(2, ref pAddress))
            {
                return false;
            }
            var paramType1 = parameters[1].ParameterType;
            if (!paramType1.IsValidInput<TArg1>(4, ref pAddress))
            {
                return false;
            }
            var paramType2 = parameters[2].ParameterType;
            if (!paramType2.IsValidInput<TArg2>(8, ref pAddress))
            {
                return false;
            }
            var paramType3 = parameters[3].ParameterType;
            if (!paramType3.IsValidInput<TArg3>(16, ref pAddress))
            {
                return false;
            }
            var paramType4 = parameters[4].ParameterType;
            if (!paramType4.IsValidInput<TArg4>(32, ref pAddress))
            {
                return false;
            }
            if (pAddress != 0)
            {
                return false;
            }
            pAddress = method.GetFunctionPointer();
            return true;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TReturn InvokeStaticFast<TArg0, TArg1, TArg2, TArg3, TArg4, TReturn>(this MethodBase self, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4)
        {
            bool isValid;
            nint pAddress;
            isValid = ValidateStaticReturnableMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TReturn>(self, out pAddress) ||
                      (pAddress != 0 && SecondaryValidateStaticMethod(self, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), ref pAddress));
            if (!isValid)
            {
                return (TReturn)self.InvokeStaticLowAlloc(arg0, arg1, arg2, arg3, arg4);
            }
            unsafe
            {
                return ((delegate*<TArg0, TArg1, TArg2, TArg3, TArg4, TReturn>)pAddress)(arg0, arg1, arg2, arg3, arg4);
            }
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool ValidateStaticReturnableMethodRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TReturn>(MethodBase method, out nint pAddress)
        {
            pAddress = 0;
            if (!method.IsStatic)
            {
                return false;
            }
            if (method.IsOverridable())
            {
                return false;
            }
            var isValidGeneric = !method.IsGenericMethodDefinition || ValidateGenericReturnableMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TReturn>(ref method);
            if (!isValidGeneric)
            {
                return false;
            }
            var parameters = method.GetParametersFast();
            var parameterLength = parameters.Count;
            if (parameterLength != 5)
            {
                return false;
            }
            if (method is MethodInfo mi)
            {
                var returnType = mi?.ReturnType ?? typeof(void);
                if (!returnType.IsValidOutput<TReturn>())
                {
                    return false;
                }
            }
            var paramType0 = parameters[0].ParameterType;
            if (!paramType0.IsValidInput<TArg0>(2, ref pAddress))
            {
                return false;
            }
            var paramType1 = parameters[1].ParameterType;
            if (!paramType1.IsValidInput<TArg1>(4, ref pAddress))
            {
                return false;
            }
            var paramType2 = parameters[2].ParameterType;
            if (!paramType2.IsValidInput<TArg2>(8, ref pAddress))
            {
                return false;
            }
            var paramType3 = parameters[3].ParameterType;
            if (!paramType3.IsValidInput<TArg3>(16, ref pAddress))
            {
                return false;
            }
            var paramType4 = parameters[4].ParameterType;
            if (!paramType4.IsValidInput<TArg4>(32, ref pAddress))
            {
                return false;
            }
            if (pAddress != 0)
            {
                return false;
            }
            pAddress = method.GetFunctionPointer();
            return true;
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool SecondaryValidateStaticMethodRaw(MethodBase method, Type arg0, Type arg1, Type arg2, Type arg3, Type arg4, ref nint pAddress)
        {
            var parameters = method.GetParametersFast();
            if ((pAddress & 2) != 0)
            {
                var paramType = parameters[0].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg0))
                {
                    return false;
                }
            }
            if ((pAddress & 4) != 0)
            {
                var paramType = parameters[1].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg1))
                {
                    return false;
                }
            }
            if ((pAddress & 8) != 0)
            {
                var paramType = parameters[2].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg2))
                {
                    return false;
                }
            }
            if ((pAddress & 16) != 0)
            {
                var paramType = parameters[3].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg3))
                {
                    return false;
                }
            }
            if ((pAddress & 32) != 0)
            {
                var paramType = parameters[4].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg4))
                {
                    return false;
                }
            }
            pAddress = method.GetFunctionPointer();
            return true;
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool ValidateGenericMethodRaw<TArg0, TArg1, TArg2, TArg3, TArg4>(ref MethodBase method)
        {
            if (!method.IsGenericMethodDefinition)
            {
                return true;
            }
            var genericArguments = method.GetGenericArgumentsFast();
            if (genericArguments.Count < 5)
            {
                return false;
            }
            uint mask = 0;
            var mi = method as MethodInfo;
            var parameters = method.GetParametersFast();
            var index0 = IndexOf(genericArguments, parameters[0].ParameterType);
            if (index0 >= 0)
            {
                mask |= 1u << index0;
            }
            var index1 = IndexOf(genericArguments, parameters[1].ParameterType);
            if (index1 >= 0)
            {
                mask |= 1u << index1;
            }
            var index2 = IndexOf(genericArguments, parameters[2].ParameterType);
            if (index2 >= 0)
            {
                mask |= 1u << index2;
            }
            var index3 = IndexOf(genericArguments, parameters[3].ParameterType);
            if (index3 >= 0)
            {
                mask |= 1u << index3;
            }
            var index4 = IndexOf(genericArguments, parameters[4].ParameterType);
            if (index4 >= 0)
            {
                mask |= 1u << index4;
            }
            if (REReflection.BitCount(mask) != genericArguments.Count)
            {
                return false;
            }
            var types = ArrayCache.GetArrayCache<Type>(genericArguments.Count);
            if (index0 >= 0)
            {
                types[index0] = typeof(TArg0);
            }
            if (index1 >= 0)
            {
                types[index1] = typeof(TArg1);
            }
            if (index2 >= 0)
            {
                types[index2] = typeof(TArg2);
            }
            if (index3 >= 0)
            {
                types[index3] = typeof(TArg3);
            }
            if (index4 >= 0)
            {
                types[index4] = typeof(TArg4);
            }
            #if ENABLE_IL2CPP
            bool isFound = false;
            var usingMethods = method.GetUsingGenericInstanceMethods();
            foreach (var usingMethod in usingMethods)
            {
                if (usingMethod.GetGenericArgumentsFast().SequenceEqual(types))
                {
                    isFound = true;
                    break;
                }
            }
            if (!isFound)
            {
                return false;
            }
            #endif
            method = mi.MakeGenericMethodFast(types);
            return true;
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool ValidateGenericReturnableMethodRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TReturn>(ref MethodBase method)
        {
            if (!method.IsGenericMethodDefinition)
            {
                return true;
            }
            var genericArguments = method.GetGenericArgumentsFast();
            if (genericArguments.Count < 6)
            {
                return false;
            }
            uint mask = 0;
            var mi = method as MethodInfo;
            var returnType = mi.ReturnType ?? typeof(void);
            var index = IndexOf(genericArguments, returnType);
            if (index >= 0)
            {
                mask |= 1u << index;
            }
            var parameters = method.GetParametersFast();
            var index0 = IndexOf(genericArguments, parameters[0].ParameterType);
            if (index0 >= 0)
            {
                mask |= 1u << index0;
            }
            var index1 = IndexOf(genericArguments, parameters[1].ParameterType);
            if (index1 >= 0)
            {
                mask |= 1u << index1;
            }
            var index2 = IndexOf(genericArguments, parameters[2].ParameterType);
            if (index2 >= 0)
            {
                mask |= 1u << index2;
            }
            var index3 = IndexOf(genericArguments, parameters[3].ParameterType);
            if (index3 >= 0)
            {
                mask |= 1u << index3;
            }
            var index4 = IndexOf(genericArguments, parameters[4].ParameterType);
            if (index4 >= 0)
            {
                mask |= 1u << index4;
            }
            if (REReflection.BitCount(mask) != genericArguments.Count)
            {
                return false;
            }
            var types = ArrayCache.GetArrayCache<Type>(genericArguments.Count);
            if (index >= 0)
            {
                types[index] = typeof(TReturn);
            }
            if (index0 >= 0)
            {
                types[index0] = typeof(TArg0);
            }
            if (index1 >= 0)
            {
                types[index1] = typeof(TArg1);
            }
            if (index2 >= 0)
            {
                types[index2] = typeof(TArg2);
            }
            if (index3 >= 0)
            {
                types[index3] = typeof(TArg3);
            }
            if (index4 >= 0)
            {
                types[index4] = typeof(TArg4);
            }
            #if ENABLE_IL2CPP
            bool isFound = false;
            var usingMethods = method.GetUsingGenericInstanceMethods();
            foreach (var usingMethod in usingMethods)
            {
                if (usingMethod.GetGenericArgumentsFast().SequenceEqual(types))
                {
                    isFound = true;
                    break;
                }
            }
            if (!isFound)
            {
                return false;
            }
            #endif
            method = mi.MakeGenericMethodFast(types);
            return true;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void InvokeInstanceFast<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(this MethodBase self, ref TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5)
        {
            bool isValid;
            nint pAddress;
            if (self.IsOverridable())
            {
                isValid = ValidateInstanceVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(self, target?.GetType(), out pAddress) ||
                          (pAddress != 0 && SecondaryValidateStaticMethod(self, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), ref pAddress));
            }
            else
            {
                isValid = ValidateInstanceMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(self, out pAddress) ||
                          (pAddress != 0 && SecondaryValidateInstanceMethod(self, target?.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), ref pAddress));
            }
            if (!isValid)
            {
                self.InvokeInstanceLowAlloc(ref target, arg0, arg1, arg2, arg3, arg4, arg5);
                return;
            }
            unsafe
            {
                if (REType.IsValueTypeFast<TTarget>())
                {
                    ((delegate*<ref TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, void>)pAddress)(ref target, arg0, arg1, arg2, arg3, arg4, arg5);
                    return;
                }
                ((delegate*<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, void>)pAddress)(target, arg0, arg1, arg2, arg3, arg4, arg5);
                return;
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void InvokeClassInstanceFast<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(this MethodBase self, TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5)
        where TTarget: class
        {
            bool isValid;
            nint pAddress;
            if (self.IsOverridable())
            {
                isValid = ValidateInstanceVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(self, target?.GetType(), out pAddress) ||
                          (pAddress != 0 && SecondaryValidateStaticMethod(self, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), ref pAddress));
            }
            else
            {
                isValid = ValidateInstanceMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(self, out pAddress) ||
                          (pAddress != 0 && SecondaryValidateInstanceMethod(self, target?.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), ref pAddress));
            }
            if (!isValid)
            {
                self.InvokeClassInstanceLowAlloc(target, arg0, arg1, arg2, arg3, arg4, arg5);
                return;
            }
            unsafe
            {
                ((delegate*<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, void>)pAddress)(target, arg0, arg1, arg2, arg3, arg4, arg5);
                return;
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void InvokeStructInstanceFast<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(this MethodBase self, ref TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5)
        where TTarget: struct
        {
            bool isValid;
            nint pAddress;
            if (self.IsOverridable())
            {
                isValid = ValidateInstanceVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(self, target.GetType(), out pAddress) ||
                          (pAddress != 0 && SecondaryValidateStaticMethod(self, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), ref pAddress));
            }
            else
            {
                isValid = ValidateInstanceMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(self, out pAddress) ||
                          (pAddress != 0 && SecondaryValidateInstanceMethod(self, target.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), ref pAddress));
            }
            if (!isValid)
            {
                self.InvokeInstanceLowAlloc(ref target, arg0, arg1, arg2, arg3, arg4, arg5);
                return;
            }
            unsafe
            {
                ((delegate*<ref TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, void>)pAddress)(ref target, arg0, arg1, arg2, arg3, arg4, arg5);
                return;
            }
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool ValidateInstanceMethodRaw<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(MethodBase method, out nint pAddress)
        {
            pAddress = 0;
            if (method.IsStatic)
            {
                return false;
            }
            if (method.IsOverridable())
            {
                return false;
            }
            var isValidGeneric = !method.IsGenericMethodDefinition || ValidateGenericMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(ref method);
            if (!isValidGeneric)
            {
                return false;
            }
            var parameters = method.GetParametersFast();
            var parameterLength = parameters.Count;
            if (parameterLength != 6)
            {
                return false;
            }
            if (method is MethodInfo mi)
            {
                var returnType = mi?.ReturnType ?? typeof(void);
                if (returnType != typeof(void))
                {
                    return false;
                }
            }
            var reflectedType = method.ReflectedType;
            if (!reflectedType.IsValidInputWithoutRef<TTarget>(1, ref pAddress))
            {
                return false;
            }
            var paramType0 = parameters[0].ParameterType;
            if (!paramType0.IsValidInput<TArg0>(2, ref pAddress))
            {
                return false;
            }
            var paramType1 = parameters[1].ParameterType;
            if (!paramType1.IsValidInput<TArg1>(4, ref pAddress))
            {
                return false;
            }
            var paramType2 = parameters[2].ParameterType;
            if (!paramType2.IsValidInput<TArg2>(8, ref pAddress))
            {
                return false;
            }
            var paramType3 = parameters[3].ParameterType;
            if (!paramType3.IsValidInput<TArg3>(16, ref pAddress))
            {
                return false;
            }
            var paramType4 = parameters[4].ParameterType;
            if (!paramType4.IsValidInput<TArg4>(32, ref pAddress))
            {
                return false;
            }
            var paramType5 = parameters[5].ParameterType;
            if (!paramType5.IsValidInput<TArg5>(64, ref pAddress))
            {
                return false;
            }
            if (pAddress != 0)
            {
                return false;
            }
            pAddress = method.GetFunctionPointer();
            return true;
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool ValidateInstanceVirtualMethodRaw<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(MethodBase method, Type targetType, out nint pAddress)
        {
            pAddress = 0;
            if (method.IsStatic)
            {
                return false;
            }
            if (!method.IsOverridable())
            {
                return false;
            }
            var isValidGeneric = !method.IsGenericMethodDefinition || ValidateGenericMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(ref method);
            if (!isValidGeneric)
            {
                return false;
            }
            var parameters = method.GetParametersFast();
            var parameterLength = parameters.Count;
            if (parameterLength != 6)
            {
                return false;
            }
            if (method is MethodInfo mi)
            {
                var returnType = mi?.ReturnType ?? typeof(void);
                if (returnType != typeof(void))
                {
                    return false;
                }
            }
            var reflectedType = method.ReflectedType;
            if (!reflectedType.IsValidVirtualInput<TTarget>(targetType, out var isVirtualCall))
            {
                return false;
            }
            if (isVirtualCall)
            {
                ArrayCache.Types6[0] = parameters[0].ParameterType;
                ArrayCache.Types6[1] = parameters[1].ParameterType;
                ArrayCache.Types6[2] = parameters[2].ParameterType;
                ArrayCache.Types6[3] = parameters[3].ParameterType;
                ArrayCache.Types6[4] = parameters[4].ParameterType;
                ArrayCache.Types6[5] = parameters[5].ParameterType;
                method = targetType.GetInstanceMethodFullAccess(method.Name, null, ArrayCache.Types6, null);
            }
            var paramType0 = parameters[0].ParameterType;
            if (!paramType0.IsValidInput<TArg0>(2, ref pAddress))
            {
                return false;
            }
            var paramType1 = parameters[1].ParameterType;
            if (!paramType1.IsValidInput<TArg1>(4, ref pAddress))
            {
                return false;
            }
            var paramType2 = parameters[2].ParameterType;
            if (!paramType2.IsValidInput<TArg2>(8, ref pAddress))
            {
                return false;
            }
            var paramType3 = parameters[3].ParameterType;
            if (!paramType3.IsValidInput<TArg3>(16, ref pAddress))
            {
                return false;
            }
            var paramType4 = parameters[4].ParameterType;
            if (!paramType4.IsValidInput<TArg4>(32, ref pAddress))
            {
                return false;
            }
            var paramType5 = parameters[5].ParameterType;
            if (!paramType5.IsValidInput<TArg5>(64, ref pAddress))
            {
                return false;
            }
            if (pAddress != 0)
            {
                return false;
            }
            pAddress = method.GetFunctionPointer();
            return true;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TReturn InvokeInstanceFast<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TReturn>(this MethodBase self, ref TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5)
        {
            bool isValid;
            nint pAddress;
            if (self.IsOverridable())
            {
                isValid = ValidateInstanceReturnableVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TReturn>(self, target?.GetType(), out pAddress) ||
                          (pAddress != 0 && SecondaryValidateStaticMethod(self, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), ref pAddress));
            }
            else
            {
                isValid = ValidateInstanceReturnableMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TReturn>(self, out pAddress) ||
                          (pAddress != 0 && SecondaryValidateInstanceMethod(self, target?.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), ref pAddress));
            }
            if (!isValid)
            {
                return (TReturn)self.InvokeInstanceLowAlloc(ref target, arg0, arg1, arg2, arg3, arg4, arg5);
            }
            unsafe
            {
                if (REType.IsValueTypeFast<TTarget>())
                {
                    return ((delegate*<ref TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TReturn>)pAddress)(ref target, arg0, arg1, arg2, arg3, arg4, arg5);
                }
                return ((delegate*<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TReturn>)pAddress)(target, arg0, arg1, arg2, arg3, arg4, arg5);
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TReturn InvokeClassInstanceFast<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TReturn>(this MethodBase self, TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5)
        where TTarget: class
        {
            bool isValid;
            nint pAddress;
            if (self.IsOverridable())
            {
                isValid = ValidateInstanceReturnableVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TReturn>(self, target?.GetType(), out pAddress) ||
                          (pAddress != 0 && SecondaryValidateStaticMethod(self, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), ref pAddress));
            }
            else
            {
                isValid = ValidateInstanceReturnableMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TReturn>(self, out pAddress) ||
                          (pAddress != 0 && SecondaryValidateInstanceMethod(self, target?.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), ref pAddress));
            }
            if (!isValid)
            {
                return (TReturn)self.InvokeClassInstanceLowAlloc(target, arg0, arg1, arg2, arg3, arg4, arg5);
            }
            unsafe
            {
                return ((delegate*<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TReturn>)pAddress)(target, arg0, arg1, arg2, arg3, arg4, arg5);
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TReturn InvokeStructInstanceFast<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TReturn>(this MethodBase self, ref TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5)
        where TTarget: struct
        {
            bool isValid;
            nint pAddress;
            if (self.IsOverridable())
            {
                isValid = ValidateInstanceReturnableVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TReturn>(self, target.GetType(), out pAddress) ||
                          (pAddress != 0 && SecondaryValidateStaticMethod(self, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), ref pAddress));
            }
            else
            {
                isValid = ValidateInstanceReturnableMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TReturn>(self, out pAddress) ||
                          (pAddress != 0 && SecondaryValidateInstanceMethod(self, target.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), ref pAddress));
            }
            if (!isValid)
            {
                return (TReturn)self.InvokeInstanceLowAlloc(ref target, arg0, arg1, arg2, arg3, arg4, arg5);
            }
            unsafe
            {
                return ((delegate*<ref TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TReturn>)pAddress)(ref target, arg0, arg1, arg2, arg3, arg4, arg5);
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static object InvokeInstanceLowAlloc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(this MethodBase self, ref TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5)
        {
            if (self.IsGenericMethodDefinition)
            {
                ValidateGenericMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(ref self);
            }
            var targetObj = REReflection.GetBoxWithoutRef(target);
            var parameters = self.GetParametersFast();
            ArrayCache.Objects6[0] = REReflection.GetBox(arg0, parameters[0], out var refArg0);
            ArrayCache.Objects6[1] = REReflection.GetBox(arg1, parameters[1], out var refArg1);
            ArrayCache.Objects6[2] = REReflection.GetBox(arg2, parameters[2], out var refArg2);
            ArrayCache.Objects6[3] = REReflection.GetBox(arg3, parameters[3], out var refArg3);
            ArrayCache.Objects6[4] = REReflection.GetBox(arg4, parameters[4], out var refArg4);
            ArrayCache.Objects6[5] = REReflection.GetBox(arg5, parameters[5], out var refArg5);
            try
            {
                return self.Invoke(targetObj, ArrayCache.Objects6);
            }
            finally
            {
                REReflection.Unbox(targetObj, out target);
                REReflection.ReturnBoxWithoutRef<TTarget>(targetObj);
                REReflection.ReturnBox<TArg0>(ArrayCache.Objects6[0], parameters[0], refArg0);
                REReflection.ReturnBox<TArg1>(ArrayCache.Objects6[1], parameters[1], refArg1);
                REReflection.ReturnBox<TArg2>(ArrayCache.Objects6[2], parameters[2], refArg2);
                REReflection.ReturnBox<TArg3>(ArrayCache.Objects6[3], parameters[3], refArg3);
                REReflection.ReturnBox<TArg4>(ArrayCache.Objects6[4], parameters[4], refArg4);
                REReflection.ReturnBox<TArg5>(ArrayCache.Objects6[5], parameters[5], refArg5);
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static object InvokeClassInstanceLowAlloc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(this MethodBase self, TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5)
        where TTarget: class
        {
            if (self.IsGenericMethodDefinition)
            {
                ValidateGenericMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(ref self);
            }
            var parameters = self.GetParametersFast();
            ArrayCache.Objects6[0] = REReflection.GetBox(arg0, parameters[0], out var refArg0);
            ArrayCache.Objects6[1] = REReflection.GetBox(arg1, parameters[1], out var refArg1);
            ArrayCache.Objects6[2] = REReflection.GetBox(arg2, parameters[2], out var refArg2);
            ArrayCache.Objects6[3] = REReflection.GetBox(arg3, parameters[3], out var refArg3);
            ArrayCache.Objects6[4] = REReflection.GetBox(arg4, parameters[4], out var refArg4);
            ArrayCache.Objects6[5] = REReflection.GetBox(arg5, parameters[5], out var refArg5);
            try
            {
                return self.Invoke(target, ArrayCache.Objects6);
            }
            finally
            {
                REReflection.ReturnBox<TArg0>(ArrayCache.Objects6[0], parameters[0], refArg0);
                REReflection.ReturnBox<TArg1>(ArrayCache.Objects6[1], parameters[1], refArg1);
                REReflection.ReturnBox<TArg2>(ArrayCache.Objects6[2], parameters[2], refArg2);
                REReflection.ReturnBox<TArg3>(ArrayCache.Objects6[3], parameters[3], refArg3);
                REReflection.ReturnBox<TArg4>(ArrayCache.Objects6[4], parameters[4], refArg4);
                REReflection.ReturnBox<TArg5>(ArrayCache.Objects6[5], parameters[5], refArg5);
            }
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool ValidateInstanceReturnableMethodRaw<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TReturn>(MethodBase method, out nint pAddress)
        {
            pAddress = 0;
            if (method.IsStatic)
            {
                return false;
            }
            if (method.IsOverridable())
            {
                return false;
            }
            var isValidGeneric = !method.IsGenericMethodDefinition || ValidateGenericReturnableMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TReturn>(ref method);
            if (!isValidGeneric)
            {
                return false;
            }
            var parameters = method.GetParametersFast();
            var parameterLength = parameters.Count;
            if (parameterLength != 6)
            {
                return false;
            }
            if (method is MethodInfo mi)
            {
                var returnType = mi?.ReturnType ?? typeof(void);
                if (!returnType.IsValidOutput<TReturn>())
                {
                    return false;
                }
            }
            var reflectedType = method.ReflectedType;
            if (!reflectedType.IsValidInputWithoutRef<TTarget>(1, ref pAddress))
            {
                return false;
            }
            var paramType0 = parameters[0].ParameterType;
            if (!paramType0.IsValidInput<TArg0>(2, ref pAddress))
            {
                return false;
            }
            var paramType1 = parameters[1].ParameterType;
            if (!paramType1.IsValidInput<TArg1>(4, ref pAddress))
            {
                return false;
            }
            var paramType2 = parameters[2].ParameterType;
            if (!paramType2.IsValidInput<TArg2>(8, ref pAddress))
            {
                return false;
            }
            var paramType3 = parameters[3].ParameterType;
            if (!paramType3.IsValidInput<TArg3>(16, ref pAddress))
            {
                return false;
            }
            var paramType4 = parameters[4].ParameterType;
            if (!paramType4.IsValidInput<TArg4>(32, ref pAddress))
            {
                return false;
            }
            var paramType5 = parameters[5].ParameterType;
            if (!paramType5.IsValidInput<TArg5>(64, ref pAddress))
            {
                return false;
            }
            if (pAddress != 0)
            {
                return false;
            }
            pAddress = method.GetFunctionPointer();
            return true;
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool ValidateInstanceReturnableVirtualMethodRaw<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TReturn>(MethodBase method, Type targetType, out nint pAddress)
        {
            pAddress = 0;
            if (method.IsStatic)
            {
                return false;
            }
            if (!method.IsOverridable())
            {
                return false;
            }
            var isValidGeneric = !method.IsGenericMethodDefinition || ValidateGenericReturnableMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TReturn>(ref method);
            if (!isValidGeneric)
            {
                return false;
            }
            var parameters = method.GetParametersFast();
            var parameterLength = parameters.Count;
            if (parameterLength != 6)
            {
                return false;
            }
            if (method is MethodInfo mi)
            {
                var returnType = mi?.ReturnType ?? typeof(void);
                if (!returnType.IsValidOutput<TReturn>())
                {
                    return false;
                }
            }
            var reflectedType = method.ReflectedType;
            if (!reflectedType.IsValidVirtualInput<TTarget>(targetType, out var isVirtualCall))
            {
                return false;
            }
            if (isVirtualCall)
            {
                ArrayCache.Types6[0] = parameters[0].ParameterType;
                ArrayCache.Types6[1] = parameters[1].ParameterType;
                ArrayCache.Types6[2] = parameters[2].ParameterType;
                ArrayCache.Types6[3] = parameters[3].ParameterType;
                ArrayCache.Types6[4] = parameters[4].ParameterType;
                ArrayCache.Types6[5] = parameters[5].ParameterType;
                method = targetType.GetInstanceMethodFullAccess(method.Name, null, ArrayCache.Types6, null);
            }
            var paramType0 = parameters[0].ParameterType;
            if (!paramType0.IsValidInput<TArg0>(2, ref pAddress))
            {
                return false;
            }
            var paramType1 = parameters[1].ParameterType;
            if (!paramType1.IsValidInput<TArg1>(4, ref pAddress))
            {
                return false;
            }
            var paramType2 = parameters[2].ParameterType;
            if (!paramType2.IsValidInput<TArg2>(8, ref pAddress))
            {
                return false;
            }
            var paramType3 = parameters[3].ParameterType;
            if (!paramType3.IsValidInput<TArg3>(16, ref pAddress))
            {
                return false;
            }
            var paramType4 = parameters[4].ParameterType;
            if (!paramType4.IsValidInput<TArg4>(32, ref pAddress))
            {
                return false;
            }
            var paramType5 = parameters[5].ParameterType;
            if (!paramType5.IsValidInput<TArg5>(64, ref pAddress))
            {
                return false;
            }
            if (pAddress != 0)
            {
                return false;
            }
            pAddress = method.GetFunctionPointer();
            return true;
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool SecondaryValidateInstanceMethodRaw(MethodBase method, Type target, Type arg0, Type arg1, Type arg2, Type arg3, Type arg4, Type arg5, ref nint pAddress)
        {
            if ((pAddress & 1) != 0)
            {
                var reflectedType = method.ReflectedType;
                if (!reflectedType.IsNullAssignableFromFast(target))
                {
                    return false;
                }
            }
            var parameters = method.GetParametersFast();
            if ((pAddress & 2) != 0)
            {
                var paramType = parameters[0].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg0))
                {
                    return false;
                }
            }
            if ((pAddress & 4) != 0)
            {
                var paramType = parameters[1].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg1))
                {
                    return false;
                }
            }
            if ((pAddress & 8) != 0)
            {
                var paramType = parameters[2].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg2))
                {
                    return false;
                }
            }
            if ((pAddress & 16) != 0)
            {
                var paramType = parameters[3].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg3))
                {
                    return false;
                }
            }
            if ((pAddress & 32) != 0)
            {
                var paramType = parameters[4].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg4))
                {
                    return false;
                }
            }
            if ((pAddress & 64) != 0)
            {
                var paramType = parameters[5].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg5))
                {
                    return false;
                }
            }
            pAddress = method.GetFunctionPointer();
            return true;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void InvokeStaticFast<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(this MethodBase self, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5)
        {
            bool isValid;
            nint pAddress;
            isValid = ValidateStaticMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(self, out pAddress) ||
                      (pAddress != 0 && SecondaryValidateStaticMethod(self, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), ref pAddress));
            if (!isValid)
            {
                self.InvokeStaticLowAlloc(arg0, arg1, arg2, arg3, arg4, arg5);
                return;
            }
            unsafe
            {
                ((delegate*<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, void>)pAddress)(arg0, arg1, arg2, arg3, arg4, arg5);
                return;
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static object InvokeStaticLowAlloc<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(this MethodBase self, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5)
        {
            if (self.IsGenericMethodDefinition)
            {
                ValidateGenericMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(ref self);
            }
            var parameters = self.GetParametersFast();
            ArrayCache.Objects6[0] = REReflection.GetBox(arg0, parameters[0], out var refArg0);
            ArrayCache.Objects6[1] = REReflection.GetBox(arg1, parameters[1], out var refArg1);
            ArrayCache.Objects6[2] = REReflection.GetBox(arg2, parameters[2], out var refArg2);
            ArrayCache.Objects6[3] = REReflection.GetBox(arg3, parameters[3], out var refArg3);
            ArrayCache.Objects6[4] = REReflection.GetBox(arg4, parameters[4], out var refArg4);
            ArrayCache.Objects6[5] = REReflection.GetBox(arg5, parameters[5], out var refArg5);
            try
            {
                return self.Invoke(null, ArrayCache.Objects6);
            }
            finally
            {
                REReflection.ReturnBox<TArg0>(ArrayCache.Objects6[0], parameters[0], refArg0);
                REReflection.ReturnBox<TArg1>(ArrayCache.Objects6[1], parameters[1], refArg1);
                REReflection.ReturnBox<TArg2>(ArrayCache.Objects6[2], parameters[2], refArg2);
                REReflection.ReturnBox<TArg3>(ArrayCache.Objects6[3], parameters[3], refArg3);
                REReflection.ReturnBox<TArg4>(ArrayCache.Objects6[4], parameters[4], refArg4);
                REReflection.ReturnBox<TArg5>(ArrayCache.Objects6[5], parameters[5], refArg5);
            }
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool ValidateStaticMethodRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(MethodBase method, out nint pAddress)
        {
            pAddress = 0;
            if (!method.IsStatic)
            {
                return false;
            }
            if (method.IsOverridable())
            {
                return false;
            }
            var isValidGeneric = !method.IsGenericMethodDefinition || ValidateGenericMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(ref method);
            if (!isValidGeneric)
            {
                return false;
            }
            var parameters = method.GetParametersFast();
            var parameterLength = parameters.Count;
            if (parameterLength != 6)
            {
                return false;
            }
            if (method is MethodInfo mi)
            {
                var returnType = mi?.ReturnType ?? typeof(void);
                if (returnType != typeof(void))
                {
                    return false;
                }
            }
            var paramType0 = parameters[0].ParameterType;
            if (!paramType0.IsValidInput<TArg0>(2, ref pAddress))
            {
                return false;
            }
            var paramType1 = parameters[1].ParameterType;
            if (!paramType1.IsValidInput<TArg1>(4, ref pAddress))
            {
                return false;
            }
            var paramType2 = parameters[2].ParameterType;
            if (!paramType2.IsValidInput<TArg2>(8, ref pAddress))
            {
                return false;
            }
            var paramType3 = parameters[3].ParameterType;
            if (!paramType3.IsValidInput<TArg3>(16, ref pAddress))
            {
                return false;
            }
            var paramType4 = parameters[4].ParameterType;
            if (!paramType4.IsValidInput<TArg4>(32, ref pAddress))
            {
                return false;
            }
            var paramType5 = parameters[5].ParameterType;
            if (!paramType5.IsValidInput<TArg5>(64, ref pAddress))
            {
                return false;
            }
            if (pAddress != 0)
            {
                return false;
            }
            pAddress = method.GetFunctionPointer();
            return true;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TReturn InvokeStaticFast<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TReturn>(this MethodBase self, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5)
        {
            bool isValid;
            nint pAddress;
            isValid = ValidateStaticReturnableMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TReturn>(self, out pAddress) ||
                      (pAddress != 0 && SecondaryValidateStaticMethod(self, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), ref pAddress));
            if (!isValid)
            {
                return (TReturn)self.InvokeStaticLowAlloc(arg0, arg1, arg2, arg3, arg4, arg5);
            }
            unsafe
            {
                return ((delegate*<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TReturn>)pAddress)(arg0, arg1, arg2, arg3, arg4, arg5);
            }
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool ValidateStaticReturnableMethodRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TReturn>(MethodBase method, out nint pAddress)
        {
            pAddress = 0;
            if (!method.IsStatic)
            {
                return false;
            }
            if (method.IsOverridable())
            {
                return false;
            }
            var isValidGeneric = !method.IsGenericMethodDefinition || ValidateGenericReturnableMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TReturn>(ref method);
            if (!isValidGeneric)
            {
                return false;
            }
            var parameters = method.GetParametersFast();
            var parameterLength = parameters.Count;
            if (parameterLength != 6)
            {
                return false;
            }
            if (method is MethodInfo mi)
            {
                var returnType = mi?.ReturnType ?? typeof(void);
                if (!returnType.IsValidOutput<TReturn>())
                {
                    return false;
                }
            }
            var paramType0 = parameters[0].ParameterType;
            if (!paramType0.IsValidInput<TArg0>(2, ref pAddress))
            {
                return false;
            }
            var paramType1 = parameters[1].ParameterType;
            if (!paramType1.IsValidInput<TArg1>(4, ref pAddress))
            {
                return false;
            }
            var paramType2 = parameters[2].ParameterType;
            if (!paramType2.IsValidInput<TArg2>(8, ref pAddress))
            {
                return false;
            }
            var paramType3 = parameters[3].ParameterType;
            if (!paramType3.IsValidInput<TArg3>(16, ref pAddress))
            {
                return false;
            }
            var paramType4 = parameters[4].ParameterType;
            if (!paramType4.IsValidInput<TArg4>(32, ref pAddress))
            {
                return false;
            }
            var paramType5 = parameters[5].ParameterType;
            if (!paramType5.IsValidInput<TArg5>(64, ref pAddress))
            {
                return false;
            }
            if (pAddress != 0)
            {
                return false;
            }
            pAddress = method.GetFunctionPointer();
            return true;
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool SecondaryValidateStaticMethodRaw(MethodBase method, Type arg0, Type arg1, Type arg2, Type arg3, Type arg4, Type arg5, ref nint pAddress)
        {
            var parameters = method.GetParametersFast();
            if ((pAddress & 2) != 0)
            {
                var paramType = parameters[0].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg0))
                {
                    return false;
                }
            }
            if ((pAddress & 4) != 0)
            {
                var paramType = parameters[1].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg1))
                {
                    return false;
                }
            }
            if ((pAddress & 8) != 0)
            {
                var paramType = parameters[2].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg2))
                {
                    return false;
                }
            }
            if ((pAddress & 16) != 0)
            {
                var paramType = parameters[3].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg3))
                {
                    return false;
                }
            }
            if ((pAddress & 32) != 0)
            {
                var paramType = parameters[4].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg4))
                {
                    return false;
                }
            }
            if ((pAddress & 64) != 0)
            {
                var paramType = parameters[5].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg5))
                {
                    return false;
                }
            }
            pAddress = method.GetFunctionPointer();
            return true;
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool ValidateGenericMethodRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(ref MethodBase method)
        {
            if (!method.IsGenericMethodDefinition)
            {
                return true;
            }
            var genericArguments = method.GetGenericArgumentsFast();
            if (genericArguments.Count < 6)
            {
                return false;
            }
            uint mask = 0;
            var mi = method as MethodInfo;
            var parameters = method.GetParametersFast();
            var index0 = IndexOf(genericArguments, parameters[0].ParameterType);
            if (index0 >= 0)
            {
                mask |= 1u << index0;
            }
            var index1 = IndexOf(genericArguments, parameters[1].ParameterType);
            if (index1 >= 0)
            {
                mask |= 1u << index1;
            }
            var index2 = IndexOf(genericArguments, parameters[2].ParameterType);
            if (index2 >= 0)
            {
                mask |= 1u << index2;
            }
            var index3 = IndexOf(genericArguments, parameters[3].ParameterType);
            if (index3 >= 0)
            {
                mask |= 1u << index3;
            }
            var index4 = IndexOf(genericArguments, parameters[4].ParameterType);
            if (index4 >= 0)
            {
                mask |= 1u << index4;
            }
            var index5 = IndexOf(genericArguments, parameters[5].ParameterType);
            if (index5 >= 0)
            {
                mask |= 1u << index5;
            }
            if (REReflection.BitCount(mask) != genericArguments.Count)
            {
                return false;
            }
            var types = ArrayCache.GetArrayCache<Type>(genericArguments.Count);
            if (index0 >= 0)
            {
                types[index0] = typeof(TArg0);
            }
            if (index1 >= 0)
            {
                types[index1] = typeof(TArg1);
            }
            if (index2 >= 0)
            {
                types[index2] = typeof(TArg2);
            }
            if (index3 >= 0)
            {
                types[index3] = typeof(TArg3);
            }
            if (index4 >= 0)
            {
                types[index4] = typeof(TArg4);
            }
            if (index5 >= 0)
            {
                types[index5] = typeof(TArg5);
            }
            #if ENABLE_IL2CPP
            bool isFound = false;
            var usingMethods = method.GetUsingGenericInstanceMethods();
            foreach (var usingMethod in usingMethods)
            {
                if (usingMethod.GetGenericArgumentsFast().SequenceEqual(types))
                {
                    isFound = true;
                    break;
                }
            }
            if (!isFound)
            {
                return false;
            }
            #endif
            method = mi.MakeGenericMethodFast(types);
            return true;
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool ValidateGenericReturnableMethodRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TReturn>(ref MethodBase method)
        {
            if (!method.IsGenericMethodDefinition)
            {
                return true;
            }
            var genericArguments = method.GetGenericArgumentsFast();
            if (genericArguments.Count < 7)
            {
                return false;
            }
            uint mask = 0;
            var mi = method as MethodInfo;
            var returnType = mi.ReturnType ?? typeof(void);
            var index = IndexOf(genericArguments, returnType);
            if (index >= 0)
            {
                mask |= 1u << index;
            }
            var parameters = method.GetParametersFast();
            var index0 = IndexOf(genericArguments, parameters[0].ParameterType);
            if (index0 >= 0)
            {
                mask |= 1u << index0;
            }
            var index1 = IndexOf(genericArguments, parameters[1].ParameterType);
            if (index1 >= 0)
            {
                mask |= 1u << index1;
            }
            var index2 = IndexOf(genericArguments, parameters[2].ParameterType);
            if (index2 >= 0)
            {
                mask |= 1u << index2;
            }
            var index3 = IndexOf(genericArguments, parameters[3].ParameterType);
            if (index3 >= 0)
            {
                mask |= 1u << index3;
            }
            var index4 = IndexOf(genericArguments, parameters[4].ParameterType);
            if (index4 >= 0)
            {
                mask |= 1u << index4;
            }
            var index5 = IndexOf(genericArguments, parameters[5].ParameterType);
            if (index5 >= 0)
            {
                mask |= 1u << index5;
            }
            if (REReflection.BitCount(mask) != genericArguments.Count)
            {
                return false;
            }
            var types = ArrayCache.GetArrayCache<Type>(genericArguments.Count);
            if (index >= 0)
            {
                types[index] = typeof(TReturn);
            }
            if (index0 >= 0)
            {
                types[index0] = typeof(TArg0);
            }
            if (index1 >= 0)
            {
                types[index1] = typeof(TArg1);
            }
            if (index2 >= 0)
            {
                types[index2] = typeof(TArg2);
            }
            if (index3 >= 0)
            {
                types[index3] = typeof(TArg3);
            }
            if (index4 >= 0)
            {
                types[index4] = typeof(TArg4);
            }
            if (index5 >= 0)
            {
                types[index5] = typeof(TArg5);
            }
            #if ENABLE_IL2CPP
            bool isFound = false;
            var usingMethods = method.GetUsingGenericInstanceMethods();
            foreach (var usingMethod in usingMethods)
            {
                if (usingMethod.GetGenericArgumentsFast().SequenceEqual(types))
                {
                    isFound = true;
                    break;
                }
            }
            if (!isFound)
            {
                return false;
            }
            #endif
            method = mi.MakeGenericMethodFast(types);
            return true;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void InvokeInstanceFast<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(this MethodBase self, ref TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6)
        {
            bool isValid;
            nint pAddress;
            if (self.IsOverridable())
            {
                isValid = ValidateInstanceVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(self, target?.GetType(), out pAddress) ||
                          (pAddress != 0 && SecondaryValidateStaticMethod(self, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), ref pAddress));
            }
            else
            {
                isValid = ValidateInstanceMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(self, out pAddress) ||
                          (pAddress != 0 && SecondaryValidateInstanceMethod(self, target?.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), ref pAddress));
            }
            if (!isValid)
            {
                self.InvokeInstanceLowAlloc(ref target, arg0, arg1, arg2, arg3, arg4, arg5, arg6);
                return;
            }
            unsafe
            {
                if (REType.IsValueTypeFast<TTarget>())
                {
                    ((delegate*<ref TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, void>)pAddress)(ref target, arg0, arg1, arg2, arg3, arg4, arg5, arg6);
                    return;
                }
                ((delegate*<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, void>)pAddress)(target, arg0, arg1, arg2, arg3, arg4, arg5, arg6);
                return;
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void InvokeClassInstanceFast<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(this MethodBase self, TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6)
        where TTarget: class
        {
            bool isValid;
            nint pAddress;
            if (self.IsOverridable())
            {
                isValid = ValidateInstanceVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(self, target?.GetType(), out pAddress) ||
                          (pAddress != 0 && SecondaryValidateStaticMethod(self, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), ref pAddress));
            }
            else
            {
                isValid = ValidateInstanceMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(self, out pAddress) ||
                          (pAddress != 0 && SecondaryValidateInstanceMethod(self, target?.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), ref pAddress));
            }
            if (!isValid)
            {
                self.InvokeClassInstanceLowAlloc(target, arg0, arg1, arg2, arg3, arg4, arg5, arg6);
                return;
            }
            unsafe
            {
                ((delegate*<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, void>)pAddress)(target, arg0, arg1, arg2, arg3, arg4, arg5, arg6);
                return;
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void InvokeStructInstanceFast<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(this MethodBase self, ref TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6)
        where TTarget: struct
        {
            bool isValid;
            nint pAddress;
            if (self.IsOverridable())
            {
                isValid = ValidateInstanceVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(self, target.GetType(), out pAddress) ||
                          (pAddress != 0 && SecondaryValidateStaticMethod(self, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), ref pAddress));
            }
            else
            {
                isValid = ValidateInstanceMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(self, out pAddress) ||
                          (pAddress != 0 && SecondaryValidateInstanceMethod(self, target.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), ref pAddress));
            }
            if (!isValid)
            {
                self.InvokeInstanceLowAlloc(ref target, arg0, arg1, arg2, arg3, arg4, arg5, arg6);
                return;
            }
            unsafe
            {
                ((delegate*<ref TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, void>)pAddress)(ref target, arg0, arg1, arg2, arg3, arg4, arg5, arg6);
                return;
            }
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool ValidateInstanceMethodRaw<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(MethodBase method, out nint pAddress)
        {
            pAddress = 0;
            if (method.IsStatic)
            {
                return false;
            }
            if (method.IsOverridable())
            {
                return false;
            }
            var isValidGeneric = !method.IsGenericMethodDefinition || ValidateGenericMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(ref method);
            if (!isValidGeneric)
            {
                return false;
            }
            var parameters = method.GetParametersFast();
            var parameterLength = parameters.Count;
            if (parameterLength != 7)
            {
                return false;
            }
            if (method is MethodInfo mi)
            {
                var returnType = mi?.ReturnType ?? typeof(void);
                if (returnType != typeof(void))
                {
                    return false;
                }
            }
            var reflectedType = method.ReflectedType;
            if (!reflectedType.IsValidInputWithoutRef<TTarget>(1, ref pAddress))
            {
                return false;
            }
            var paramType0 = parameters[0].ParameterType;
            if (!paramType0.IsValidInput<TArg0>(2, ref pAddress))
            {
                return false;
            }
            var paramType1 = parameters[1].ParameterType;
            if (!paramType1.IsValidInput<TArg1>(4, ref pAddress))
            {
                return false;
            }
            var paramType2 = parameters[2].ParameterType;
            if (!paramType2.IsValidInput<TArg2>(8, ref pAddress))
            {
                return false;
            }
            var paramType3 = parameters[3].ParameterType;
            if (!paramType3.IsValidInput<TArg3>(16, ref pAddress))
            {
                return false;
            }
            var paramType4 = parameters[4].ParameterType;
            if (!paramType4.IsValidInput<TArg4>(32, ref pAddress))
            {
                return false;
            }
            var paramType5 = parameters[5].ParameterType;
            if (!paramType5.IsValidInput<TArg5>(64, ref pAddress))
            {
                return false;
            }
            var paramType6 = parameters[6].ParameterType;
            if (!paramType6.IsValidInput<TArg6>(128, ref pAddress))
            {
                return false;
            }
            if (pAddress != 0)
            {
                return false;
            }
            pAddress = method.GetFunctionPointer();
            return true;
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool ValidateInstanceVirtualMethodRaw<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(MethodBase method, Type targetType, out nint pAddress)
        {
            pAddress = 0;
            if (method.IsStatic)
            {
                return false;
            }
            if (!method.IsOverridable())
            {
                return false;
            }
            var isValidGeneric = !method.IsGenericMethodDefinition || ValidateGenericMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(ref method);
            if (!isValidGeneric)
            {
                return false;
            }
            var parameters = method.GetParametersFast();
            var parameterLength = parameters.Count;
            if (parameterLength != 7)
            {
                return false;
            }
            if (method is MethodInfo mi)
            {
                var returnType = mi?.ReturnType ?? typeof(void);
                if (returnType != typeof(void))
                {
                    return false;
                }
            }
            var reflectedType = method.ReflectedType;
            if (!reflectedType.IsValidVirtualInput<TTarget>(targetType, out var isVirtualCall))
            {
                return false;
            }
            if (isVirtualCall)
            {
                ArrayCache.Types7[0] = parameters[0].ParameterType;
                ArrayCache.Types7[1] = parameters[1].ParameterType;
                ArrayCache.Types7[2] = parameters[2].ParameterType;
                ArrayCache.Types7[3] = parameters[3].ParameterType;
                ArrayCache.Types7[4] = parameters[4].ParameterType;
                ArrayCache.Types7[5] = parameters[5].ParameterType;
                ArrayCache.Types7[6] = parameters[6].ParameterType;
                method = targetType.GetInstanceMethodFullAccess(method.Name, null, ArrayCache.Types7, null);
            }
            var paramType0 = parameters[0].ParameterType;
            if (!paramType0.IsValidInput<TArg0>(2, ref pAddress))
            {
                return false;
            }
            var paramType1 = parameters[1].ParameterType;
            if (!paramType1.IsValidInput<TArg1>(4, ref pAddress))
            {
                return false;
            }
            var paramType2 = parameters[2].ParameterType;
            if (!paramType2.IsValidInput<TArg2>(8, ref pAddress))
            {
                return false;
            }
            var paramType3 = parameters[3].ParameterType;
            if (!paramType3.IsValidInput<TArg3>(16, ref pAddress))
            {
                return false;
            }
            var paramType4 = parameters[4].ParameterType;
            if (!paramType4.IsValidInput<TArg4>(32, ref pAddress))
            {
                return false;
            }
            var paramType5 = parameters[5].ParameterType;
            if (!paramType5.IsValidInput<TArg5>(64, ref pAddress))
            {
                return false;
            }
            var paramType6 = parameters[6].ParameterType;
            if (!paramType6.IsValidInput<TArg6>(128, ref pAddress))
            {
                return false;
            }
            if (pAddress != 0)
            {
                return false;
            }
            pAddress = method.GetFunctionPointer();
            return true;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TReturn InvokeInstanceFast<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TReturn>(this MethodBase self, ref TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6)
        {
            bool isValid;
            nint pAddress;
            if (self.IsOverridable())
            {
                isValid = ValidateInstanceReturnableVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TReturn>(self, target?.GetType(), out pAddress) ||
                          (pAddress != 0 && SecondaryValidateStaticMethod(self, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), ref pAddress));
            }
            else
            {
                isValid = ValidateInstanceReturnableMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TReturn>(self, out pAddress) ||
                          (pAddress != 0 && SecondaryValidateInstanceMethod(self, target?.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), ref pAddress));
            }
            if (!isValid)
            {
                return (TReturn)self.InvokeInstanceLowAlloc(ref target, arg0, arg1, arg2, arg3, arg4, arg5, arg6);
            }
            unsafe
            {
                if (REType.IsValueTypeFast<TTarget>())
                {
                    return ((delegate*<ref TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TReturn>)pAddress)(ref target, arg0, arg1, arg2, arg3, arg4, arg5, arg6);
                }
                return ((delegate*<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TReturn>)pAddress)(target, arg0, arg1, arg2, arg3, arg4, arg5, arg6);
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TReturn InvokeClassInstanceFast<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TReturn>(this MethodBase self, TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6)
        where TTarget: class
        {
            bool isValid;
            nint pAddress;
            if (self.IsOverridable())
            {
                isValid = ValidateInstanceReturnableVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TReturn>(self, target?.GetType(), out pAddress) ||
                          (pAddress != 0 && SecondaryValidateStaticMethod(self, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), ref pAddress));
            }
            else
            {
                isValid = ValidateInstanceReturnableMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TReturn>(self, out pAddress) ||
                          (pAddress != 0 && SecondaryValidateInstanceMethod(self, target?.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), ref pAddress));
            }
            if (!isValid)
            {
                return (TReturn)self.InvokeClassInstanceLowAlloc(target, arg0, arg1, arg2, arg3, arg4, arg5, arg6);
            }
            unsafe
            {
                return ((delegate*<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TReturn>)pAddress)(target, arg0, arg1, arg2, arg3, arg4, arg5, arg6);
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TReturn InvokeStructInstanceFast<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TReturn>(this MethodBase self, ref TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6)
        where TTarget: struct
        {
            bool isValid;
            nint pAddress;
            if (self.IsOverridable())
            {
                isValid = ValidateInstanceReturnableVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TReturn>(self, target.GetType(), out pAddress) ||
                          (pAddress != 0 && SecondaryValidateStaticMethod(self, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), ref pAddress));
            }
            else
            {
                isValid = ValidateInstanceReturnableMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TReturn>(self, out pAddress) ||
                          (pAddress != 0 && SecondaryValidateInstanceMethod(self, target.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), ref pAddress));
            }
            if (!isValid)
            {
                return (TReturn)self.InvokeInstanceLowAlloc(ref target, arg0, arg1, arg2, arg3, arg4, arg5, arg6);
            }
            unsafe
            {
                return ((delegate*<ref TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TReturn>)pAddress)(ref target, arg0, arg1, arg2, arg3, arg4, arg5, arg6);
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static object InvokeInstanceLowAlloc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(this MethodBase self, ref TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6)
        {
            if (self.IsGenericMethodDefinition)
            {
                ValidateGenericMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(ref self);
            }
            var targetObj = REReflection.GetBoxWithoutRef(target);
            var parameters = self.GetParametersFast();
            ArrayCache.Objects7[0] = REReflection.GetBox(arg0, parameters[0], out var refArg0);
            ArrayCache.Objects7[1] = REReflection.GetBox(arg1, parameters[1], out var refArg1);
            ArrayCache.Objects7[2] = REReflection.GetBox(arg2, parameters[2], out var refArg2);
            ArrayCache.Objects7[3] = REReflection.GetBox(arg3, parameters[3], out var refArg3);
            ArrayCache.Objects7[4] = REReflection.GetBox(arg4, parameters[4], out var refArg4);
            ArrayCache.Objects7[5] = REReflection.GetBox(arg5, parameters[5], out var refArg5);
            ArrayCache.Objects7[6] = REReflection.GetBox(arg6, parameters[6], out var refArg6);
            try
            {
                return self.Invoke(targetObj, ArrayCache.Objects7);
            }
            finally
            {
                REReflection.Unbox(targetObj, out target);
                REReflection.ReturnBoxWithoutRef<TTarget>(targetObj);
                REReflection.ReturnBox<TArg0>(ArrayCache.Objects7[0], parameters[0], refArg0);
                REReflection.ReturnBox<TArg1>(ArrayCache.Objects7[1], parameters[1], refArg1);
                REReflection.ReturnBox<TArg2>(ArrayCache.Objects7[2], parameters[2], refArg2);
                REReflection.ReturnBox<TArg3>(ArrayCache.Objects7[3], parameters[3], refArg3);
                REReflection.ReturnBox<TArg4>(ArrayCache.Objects7[4], parameters[4], refArg4);
                REReflection.ReturnBox<TArg5>(ArrayCache.Objects7[5], parameters[5], refArg5);
                REReflection.ReturnBox<TArg6>(ArrayCache.Objects7[6], parameters[6], refArg6);
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static object InvokeClassInstanceLowAlloc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(this MethodBase self, TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6)
        where TTarget: class
        {
            if (self.IsGenericMethodDefinition)
            {
                ValidateGenericMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(ref self);
            }
            var parameters = self.GetParametersFast();
            ArrayCache.Objects7[0] = REReflection.GetBox(arg0, parameters[0], out var refArg0);
            ArrayCache.Objects7[1] = REReflection.GetBox(arg1, parameters[1], out var refArg1);
            ArrayCache.Objects7[2] = REReflection.GetBox(arg2, parameters[2], out var refArg2);
            ArrayCache.Objects7[3] = REReflection.GetBox(arg3, parameters[3], out var refArg3);
            ArrayCache.Objects7[4] = REReflection.GetBox(arg4, parameters[4], out var refArg4);
            ArrayCache.Objects7[5] = REReflection.GetBox(arg5, parameters[5], out var refArg5);
            ArrayCache.Objects7[6] = REReflection.GetBox(arg6, parameters[6], out var refArg6);
            try
            {
                return self.Invoke(target, ArrayCache.Objects7);
            }
            finally
            {
                REReflection.ReturnBox<TArg0>(ArrayCache.Objects7[0], parameters[0], refArg0);
                REReflection.ReturnBox<TArg1>(ArrayCache.Objects7[1], parameters[1], refArg1);
                REReflection.ReturnBox<TArg2>(ArrayCache.Objects7[2], parameters[2], refArg2);
                REReflection.ReturnBox<TArg3>(ArrayCache.Objects7[3], parameters[3], refArg3);
                REReflection.ReturnBox<TArg4>(ArrayCache.Objects7[4], parameters[4], refArg4);
                REReflection.ReturnBox<TArg5>(ArrayCache.Objects7[5], parameters[5], refArg5);
                REReflection.ReturnBox<TArg6>(ArrayCache.Objects7[6], parameters[6], refArg6);
            }
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool ValidateInstanceReturnableMethodRaw<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TReturn>(MethodBase method, out nint pAddress)
        {
            pAddress = 0;
            if (method.IsStatic)
            {
                return false;
            }
            if (method.IsOverridable())
            {
                return false;
            }
            var isValidGeneric = !method.IsGenericMethodDefinition || ValidateGenericReturnableMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TReturn>(ref method);
            if (!isValidGeneric)
            {
                return false;
            }
            var parameters = method.GetParametersFast();
            var parameterLength = parameters.Count;
            if (parameterLength != 7)
            {
                return false;
            }
            if (method is MethodInfo mi)
            {
                var returnType = mi?.ReturnType ?? typeof(void);
                if (!returnType.IsValidOutput<TReturn>())
                {
                    return false;
                }
            }
            var reflectedType = method.ReflectedType;
            if (!reflectedType.IsValidInputWithoutRef<TTarget>(1, ref pAddress))
            {
                return false;
            }
            var paramType0 = parameters[0].ParameterType;
            if (!paramType0.IsValidInput<TArg0>(2, ref pAddress))
            {
                return false;
            }
            var paramType1 = parameters[1].ParameterType;
            if (!paramType1.IsValidInput<TArg1>(4, ref pAddress))
            {
                return false;
            }
            var paramType2 = parameters[2].ParameterType;
            if (!paramType2.IsValidInput<TArg2>(8, ref pAddress))
            {
                return false;
            }
            var paramType3 = parameters[3].ParameterType;
            if (!paramType3.IsValidInput<TArg3>(16, ref pAddress))
            {
                return false;
            }
            var paramType4 = parameters[4].ParameterType;
            if (!paramType4.IsValidInput<TArg4>(32, ref pAddress))
            {
                return false;
            }
            var paramType5 = parameters[5].ParameterType;
            if (!paramType5.IsValidInput<TArg5>(64, ref pAddress))
            {
                return false;
            }
            var paramType6 = parameters[6].ParameterType;
            if (!paramType6.IsValidInput<TArg6>(128, ref pAddress))
            {
                return false;
            }
            if (pAddress != 0)
            {
                return false;
            }
            pAddress = method.GetFunctionPointer();
            return true;
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool ValidateInstanceReturnableVirtualMethodRaw<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TReturn>(MethodBase method, Type targetType, out nint pAddress)
        {
            pAddress = 0;
            if (method.IsStatic)
            {
                return false;
            }
            if (!method.IsOverridable())
            {
                return false;
            }
            var isValidGeneric = !method.IsGenericMethodDefinition || ValidateGenericReturnableMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TReturn>(ref method);
            if (!isValidGeneric)
            {
                return false;
            }
            var parameters = method.GetParametersFast();
            var parameterLength = parameters.Count;
            if (parameterLength != 7)
            {
                return false;
            }
            if (method is MethodInfo mi)
            {
                var returnType = mi?.ReturnType ?? typeof(void);
                if (!returnType.IsValidOutput<TReturn>())
                {
                    return false;
                }
            }
            var reflectedType = method.ReflectedType;
            if (!reflectedType.IsValidVirtualInput<TTarget>(targetType, out var isVirtualCall))
            {
                return false;
            }
            if (isVirtualCall)
            {
                ArrayCache.Types7[0] = parameters[0].ParameterType;
                ArrayCache.Types7[1] = parameters[1].ParameterType;
                ArrayCache.Types7[2] = parameters[2].ParameterType;
                ArrayCache.Types7[3] = parameters[3].ParameterType;
                ArrayCache.Types7[4] = parameters[4].ParameterType;
                ArrayCache.Types7[5] = parameters[5].ParameterType;
                ArrayCache.Types7[6] = parameters[6].ParameterType;
                method = targetType.GetInstanceMethodFullAccess(method.Name, null, ArrayCache.Types7, null);
            }
            var paramType0 = parameters[0].ParameterType;
            if (!paramType0.IsValidInput<TArg0>(2, ref pAddress))
            {
                return false;
            }
            var paramType1 = parameters[1].ParameterType;
            if (!paramType1.IsValidInput<TArg1>(4, ref pAddress))
            {
                return false;
            }
            var paramType2 = parameters[2].ParameterType;
            if (!paramType2.IsValidInput<TArg2>(8, ref pAddress))
            {
                return false;
            }
            var paramType3 = parameters[3].ParameterType;
            if (!paramType3.IsValidInput<TArg3>(16, ref pAddress))
            {
                return false;
            }
            var paramType4 = parameters[4].ParameterType;
            if (!paramType4.IsValidInput<TArg4>(32, ref pAddress))
            {
                return false;
            }
            var paramType5 = parameters[5].ParameterType;
            if (!paramType5.IsValidInput<TArg5>(64, ref pAddress))
            {
                return false;
            }
            var paramType6 = parameters[6].ParameterType;
            if (!paramType6.IsValidInput<TArg6>(128, ref pAddress))
            {
                return false;
            }
            if (pAddress != 0)
            {
                return false;
            }
            pAddress = method.GetFunctionPointer();
            return true;
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool SecondaryValidateInstanceMethodRaw(MethodBase method, Type target, Type arg0, Type arg1, Type arg2, Type arg3, Type arg4, Type arg5, Type arg6, ref nint pAddress)
        {
            if ((pAddress & 1) != 0)
            {
                var reflectedType = method.ReflectedType;
                if (!reflectedType.IsNullAssignableFromFast(target))
                {
                    return false;
                }
            }
            var parameters = method.GetParametersFast();
            if ((pAddress & 2) != 0)
            {
                var paramType = parameters[0].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg0))
                {
                    return false;
                }
            }
            if ((pAddress & 4) != 0)
            {
                var paramType = parameters[1].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg1))
                {
                    return false;
                }
            }
            if ((pAddress & 8) != 0)
            {
                var paramType = parameters[2].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg2))
                {
                    return false;
                }
            }
            if ((pAddress & 16) != 0)
            {
                var paramType = parameters[3].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg3))
                {
                    return false;
                }
            }
            if ((pAddress & 32) != 0)
            {
                var paramType = parameters[4].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg4))
                {
                    return false;
                }
            }
            if ((pAddress & 64) != 0)
            {
                var paramType = parameters[5].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg5))
                {
                    return false;
                }
            }
            if ((pAddress & 128) != 0)
            {
                var paramType = parameters[6].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg6))
                {
                    return false;
                }
            }
            pAddress = method.GetFunctionPointer();
            return true;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void InvokeStaticFast<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(this MethodBase self, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6)
        {
            bool isValid;
            nint pAddress;
            isValid = ValidateStaticMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(self, out pAddress) ||
                      (pAddress != 0 && SecondaryValidateStaticMethod(self, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), ref pAddress));
            if (!isValid)
            {
                self.InvokeStaticLowAlloc(arg0, arg1, arg2, arg3, arg4, arg5, arg6);
                return;
            }
            unsafe
            {
                ((delegate*<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, void>)pAddress)(arg0, arg1, arg2, arg3, arg4, arg5, arg6);
                return;
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static object InvokeStaticLowAlloc<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(this MethodBase self, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6)
        {
            if (self.IsGenericMethodDefinition)
            {
                ValidateGenericMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(ref self);
            }
            var parameters = self.GetParametersFast();
            ArrayCache.Objects7[0] = REReflection.GetBox(arg0, parameters[0], out var refArg0);
            ArrayCache.Objects7[1] = REReflection.GetBox(arg1, parameters[1], out var refArg1);
            ArrayCache.Objects7[2] = REReflection.GetBox(arg2, parameters[2], out var refArg2);
            ArrayCache.Objects7[3] = REReflection.GetBox(arg3, parameters[3], out var refArg3);
            ArrayCache.Objects7[4] = REReflection.GetBox(arg4, parameters[4], out var refArg4);
            ArrayCache.Objects7[5] = REReflection.GetBox(arg5, parameters[5], out var refArg5);
            ArrayCache.Objects7[6] = REReflection.GetBox(arg6, parameters[6], out var refArg6);
            try
            {
                return self.Invoke(null, ArrayCache.Objects7);
            }
            finally
            {
                REReflection.ReturnBox<TArg0>(ArrayCache.Objects7[0], parameters[0], refArg0);
                REReflection.ReturnBox<TArg1>(ArrayCache.Objects7[1], parameters[1], refArg1);
                REReflection.ReturnBox<TArg2>(ArrayCache.Objects7[2], parameters[2], refArg2);
                REReflection.ReturnBox<TArg3>(ArrayCache.Objects7[3], parameters[3], refArg3);
                REReflection.ReturnBox<TArg4>(ArrayCache.Objects7[4], parameters[4], refArg4);
                REReflection.ReturnBox<TArg5>(ArrayCache.Objects7[5], parameters[5], refArg5);
                REReflection.ReturnBox<TArg6>(ArrayCache.Objects7[6], parameters[6], refArg6);
            }
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool ValidateStaticMethodRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(MethodBase method, out nint pAddress)
        {
            pAddress = 0;
            if (!method.IsStatic)
            {
                return false;
            }
            if (method.IsOverridable())
            {
                return false;
            }
            var isValidGeneric = !method.IsGenericMethodDefinition || ValidateGenericMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(ref method);
            if (!isValidGeneric)
            {
                return false;
            }
            var parameters = method.GetParametersFast();
            var parameterLength = parameters.Count;
            if (parameterLength != 7)
            {
                return false;
            }
            if (method is MethodInfo mi)
            {
                var returnType = mi?.ReturnType ?? typeof(void);
                if (returnType != typeof(void))
                {
                    return false;
                }
            }
            var paramType0 = parameters[0].ParameterType;
            if (!paramType0.IsValidInput<TArg0>(2, ref pAddress))
            {
                return false;
            }
            var paramType1 = parameters[1].ParameterType;
            if (!paramType1.IsValidInput<TArg1>(4, ref pAddress))
            {
                return false;
            }
            var paramType2 = parameters[2].ParameterType;
            if (!paramType2.IsValidInput<TArg2>(8, ref pAddress))
            {
                return false;
            }
            var paramType3 = parameters[3].ParameterType;
            if (!paramType3.IsValidInput<TArg3>(16, ref pAddress))
            {
                return false;
            }
            var paramType4 = parameters[4].ParameterType;
            if (!paramType4.IsValidInput<TArg4>(32, ref pAddress))
            {
                return false;
            }
            var paramType5 = parameters[5].ParameterType;
            if (!paramType5.IsValidInput<TArg5>(64, ref pAddress))
            {
                return false;
            }
            var paramType6 = parameters[6].ParameterType;
            if (!paramType6.IsValidInput<TArg6>(128, ref pAddress))
            {
                return false;
            }
            if (pAddress != 0)
            {
                return false;
            }
            pAddress = method.GetFunctionPointer();
            return true;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TReturn InvokeStaticFast<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TReturn>(this MethodBase self, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6)
        {
            bool isValid;
            nint pAddress;
            isValid = ValidateStaticReturnableMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TReturn>(self, out pAddress) ||
                      (pAddress != 0 && SecondaryValidateStaticMethod(self, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), ref pAddress));
            if (!isValid)
            {
                return (TReturn)self.InvokeStaticLowAlloc(arg0, arg1, arg2, arg3, arg4, arg5, arg6);
            }
            unsafe
            {
                return ((delegate*<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TReturn>)pAddress)(arg0, arg1, arg2, arg3, arg4, arg5, arg6);
            }
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool ValidateStaticReturnableMethodRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TReturn>(MethodBase method, out nint pAddress)
        {
            pAddress = 0;
            if (!method.IsStatic)
            {
                return false;
            }
            if (method.IsOverridable())
            {
                return false;
            }
            var isValidGeneric = !method.IsGenericMethodDefinition || ValidateGenericReturnableMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TReturn>(ref method);
            if (!isValidGeneric)
            {
                return false;
            }
            var parameters = method.GetParametersFast();
            var parameterLength = parameters.Count;
            if (parameterLength != 7)
            {
                return false;
            }
            if (method is MethodInfo mi)
            {
                var returnType = mi?.ReturnType ?? typeof(void);
                if (!returnType.IsValidOutput<TReturn>())
                {
                    return false;
                }
            }
            var paramType0 = parameters[0].ParameterType;
            if (!paramType0.IsValidInput<TArg0>(2, ref pAddress))
            {
                return false;
            }
            var paramType1 = parameters[1].ParameterType;
            if (!paramType1.IsValidInput<TArg1>(4, ref pAddress))
            {
                return false;
            }
            var paramType2 = parameters[2].ParameterType;
            if (!paramType2.IsValidInput<TArg2>(8, ref pAddress))
            {
                return false;
            }
            var paramType3 = parameters[3].ParameterType;
            if (!paramType3.IsValidInput<TArg3>(16, ref pAddress))
            {
                return false;
            }
            var paramType4 = parameters[4].ParameterType;
            if (!paramType4.IsValidInput<TArg4>(32, ref pAddress))
            {
                return false;
            }
            var paramType5 = parameters[5].ParameterType;
            if (!paramType5.IsValidInput<TArg5>(64, ref pAddress))
            {
                return false;
            }
            var paramType6 = parameters[6].ParameterType;
            if (!paramType6.IsValidInput<TArg6>(128, ref pAddress))
            {
                return false;
            }
            if (pAddress != 0)
            {
                return false;
            }
            pAddress = method.GetFunctionPointer();
            return true;
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool SecondaryValidateStaticMethodRaw(MethodBase method, Type arg0, Type arg1, Type arg2, Type arg3, Type arg4, Type arg5, Type arg6, ref nint pAddress)
        {
            var parameters = method.GetParametersFast();
            if ((pAddress & 2) != 0)
            {
                var paramType = parameters[0].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg0))
                {
                    return false;
                }
            }
            if ((pAddress & 4) != 0)
            {
                var paramType = parameters[1].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg1))
                {
                    return false;
                }
            }
            if ((pAddress & 8) != 0)
            {
                var paramType = parameters[2].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg2))
                {
                    return false;
                }
            }
            if ((pAddress & 16) != 0)
            {
                var paramType = parameters[3].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg3))
                {
                    return false;
                }
            }
            if ((pAddress & 32) != 0)
            {
                var paramType = parameters[4].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg4))
                {
                    return false;
                }
            }
            if ((pAddress & 64) != 0)
            {
                var paramType = parameters[5].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg5))
                {
                    return false;
                }
            }
            if ((pAddress & 128) != 0)
            {
                var paramType = parameters[6].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg6))
                {
                    return false;
                }
            }
            pAddress = method.GetFunctionPointer();
            return true;
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool ValidateGenericMethodRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(ref MethodBase method)
        {
            if (!method.IsGenericMethodDefinition)
            {
                return true;
            }
            var genericArguments = method.GetGenericArgumentsFast();
            if (genericArguments.Count < 7)
            {
                return false;
            }
            uint mask = 0;
            var mi = method as MethodInfo;
            var parameters = method.GetParametersFast();
            var index0 = IndexOf(genericArguments, parameters[0].ParameterType);
            if (index0 >= 0)
            {
                mask |= 1u << index0;
            }
            var index1 = IndexOf(genericArguments, parameters[1].ParameterType);
            if (index1 >= 0)
            {
                mask |= 1u << index1;
            }
            var index2 = IndexOf(genericArguments, parameters[2].ParameterType);
            if (index2 >= 0)
            {
                mask |= 1u << index2;
            }
            var index3 = IndexOf(genericArguments, parameters[3].ParameterType);
            if (index3 >= 0)
            {
                mask |= 1u << index3;
            }
            var index4 = IndexOf(genericArguments, parameters[4].ParameterType);
            if (index4 >= 0)
            {
                mask |= 1u << index4;
            }
            var index5 = IndexOf(genericArguments, parameters[5].ParameterType);
            if (index5 >= 0)
            {
                mask |= 1u << index5;
            }
            var index6 = IndexOf(genericArguments, parameters[6].ParameterType);
            if (index6 >= 0)
            {
                mask |= 1u << index6;
            }
            if (REReflection.BitCount(mask) != genericArguments.Count)
            {
                return false;
            }
            var types = ArrayCache.GetArrayCache<Type>(genericArguments.Count);
            if (index0 >= 0)
            {
                types[index0] = typeof(TArg0);
            }
            if (index1 >= 0)
            {
                types[index1] = typeof(TArg1);
            }
            if (index2 >= 0)
            {
                types[index2] = typeof(TArg2);
            }
            if (index3 >= 0)
            {
                types[index3] = typeof(TArg3);
            }
            if (index4 >= 0)
            {
                types[index4] = typeof(TArg4);
            }
            if (index5 >= 0)
            {
                types[index5] = typeof(TArg5);
            }
            if (index6 >= 0)
            {
                types[index6] = typeof(TArg6);
            }
            #if ENABLE_IL2CPP
            bool isFound = false;
            var usingMethods = method.GetUsingGenericInstanceMethods();
            foreach (var usingMethod in usingMethods)
            {
                if (usingMethod.GetGenericArgumentsFast().SequenceEqual(types))
                {
                    isFound = true;
                    break;
                }
            }
            if (!isFound)
            {
                return false;
            }
            #endif
            method = mi.MakeGenericMethodFast(types);
            return true;
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool ValidateGenericReturnableMethodRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TReturn>(ref MethodBase method)
        {
            if (!method.IsGenericMethodDefinition)
            {
                return true;
            }
            var genericArguments = method.GetGenericArgumentsFast();
            if (genericArguments.Count < 8)
            {
                return false;
            }
            uint mask = 0;
            var mi = method as MethodInfo;
            var returnType = mi.ReturnType ?? typeof(void);
            var index = IndexOf(genericArguments, returnType);
            if (index >= 0)
            {
                mask |= 1u << index;
            }
            var parameters = method.GetParametersFast();
            var index0 = IndexOf(genericArguments, parameters[0].ParameterType);
            if (index0 >= 0)
            {
                mask |= 1u << index0;
            }
            var index1 = IndexOf(genericArguments, parameters[1].ParameterType);
            if (index1 >= 0)
            {
                mask |= 1u << index1;
            }
            var index2 = IndexOf(genericArguments, parameters[2].ParameterType);
            if (index2 >= 0)
            {
                mask |= 1u << index2;
            }
            var index3 = IndexOf(genericArguments, parameters[3].ParameterType);
            if (index3 >= 0)
            {
                mask |= 1u << index3;
            }
            var index4 = IndexOf(genericArguments, parameters[4].ParameterType);
            if (index4 >= 0)
            {
                mask |= 1u << index4;
            }
            var index5 = IndexOf(genericArguments, parameters[5].ParameterType);
            if (index5 >= 0)
            {
                mask |= 1u << index5;
            }
            var index6 = IndexOf(genericArguments, parameters[6].ParameterType);
            if (index6 >= 0)
            {
                mask |= 1u << index6;
            }
            if (REReflection.BitCount(mask) != genericArguments.Count)
            {
                return false;
            }
            var types = ArrayCache.GetArrayCache<Type>(genericArguments.Count);
            if (index >= 0)
            {
                types[index] = typeof(TReturn);
            }
            if (index0 >= 0)
            {
                types[index0] = typeof(TArg0);
            }
            if (index1 >= 0)
            {
                types[index1] = typeof(TArg1);
            }
            if (index2 >= 0)
            {
                types[index2] = typeof(TArg2);
            }
            if (index3 >= 0)
            {
                types[index3] = typeof(TArg3);
            }
            if (index4 >= 0)
            {
                types[index4] = typeof(TArg4);
            }
            if (index5 >= 0)
            {
                types[index5] = typeof(TArg5);
            }
            if (index6 >= 0)
            {
                types[index6] = typeof(TArg6);
            }
            #if ENABLE_IL2CPP
            bool isFound = false;
            var usingMethods = method.GetUsingGenericInstanceMethods();
            foreach (var usingMethod in usingMethods)
            {
                if (usingMethod.GetGenericArgumentsFast().SequenceEqual(types))
                {
                    isFound = true;
                    break;
                }
            }
            if (!isFound)
            {
                return false;
            }
            #endif
            method = mi.MakeGenericMethodFast(types);
            return true;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void InvokeInstanceFast<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(this MethodBase self, ref TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7)
        {
            bool isValid;
            nint pAddress;
            if (self.IsOverridable())
            {
                isValid = ValidateInstanceVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(self, target?.GetType(), out pAddress) ||
                          (pAddress != 0 && SecondaryValidateStaticMethod(self, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), ref pAddress));
            }
            else
            {
                isValid = ValidateInstanceMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(self, out pAddress) ||
                          (pAddress != 0 && SecondaryValidateInstanceMethod(self, target?.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), ref pAddress));
            }
            if (!isValid)
            {
                self.InvokeInstanceLowAlloc(ref target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
                return;
            }
            unsafe
            {
                if (REType.IsValueTypeFast<TTarget>())
                {
                    ((delegate*<ref TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, void>)pAddress)(ref target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
                    return;
                }
                ((delegate*<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, void>)pAddress)(target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
                return;
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void InvokeClassInstanceFast<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(this MethodBase self, TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7)
        where TTarget: class
        {
            bool isValid;
            nint pAddress;
            if (self.IsOverridable())
            {
                isValid = ValidateInstanceVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(self, target?.GetType(), out pAddress) ||
                          (pAddress != 0 && SecondaryValidateStaticMethod(self, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), ref pAddress));
            }
            else
            {
                isValid = ValidateInstanceMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(self, out pAddress) ||
                          (pAddress != 0 && SecondaryValidateInstanceMethod(self, target?.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), ref pAddress));
            }
            if (!isValid)
            {
                self.InvokeClassInstanceLowAlloc(target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
                return;
            }
            unsafe
            {
                ((delegate*<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, void>)pAddress)(target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
                return;
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void InvokeStructInstanceFast<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(this MethodBase self, ref TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7)
        where TTarget: struct
        {
            bool isValid;
            nint pAddress;
            if (self.IsOverridable())
            {
                isValid = ValidateInstanceVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(self, target.GetType(), out pAddress) ||
                          (pAddress != 0 && SecondaryValidateStaticMethod(self, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), ref pAddress));
            }
            else
            {
                isValid = ValidateInstanceMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(self, out pAddress) ||
                          (pAddress != 0 && SecondaryValidateInstanceMethod(self, target.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), ref pAddress));
            }
            if (!isValid)
            {
                self.InvokeInstanceLowAlloc(ref target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
                return;
            }
            unsafe
            {
                ((delegate*<ref TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, void>)pAddress)(ref target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
                return;
            }
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool ValidateInstanceMethodRaw<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(MethodBase method, out nint pAddress)
        {
            pAddress = 0;
            if (method.IsStatic)
            {
                return false;
            }
            if (method.IsOverridable())
            {
                return false;
            }
            var isValidGeneric = !method.IsGenericMethodDefinition || ValidateGenericMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(ref method);
            if (!isValidGeneric)
            {
                return false;
            }
            var parameters = method.GetParametersFast();
            var parameterLength = parameters.Count;
            if (parameterLength != 8)
            {
                return false;
            }
            if (method is MethodInfo mi)
            {
                var returnType = mi?.ReturnType ?? typeof(void);
                if (returnType != typeof(void))
                {
                    return false;
                }
            }
            var reflectedType = method.ReflectedType;
            if (!reflectedType.IsValidInputWithoutRef<TTarget>(1, ref pAddress))
            {
                return false;
            }
            var paramType0 = parameters[0].ParameterType;
            if (!paramType0.IsValidInput<TArg0>(2, ref pAddress))
            {
                return false;
            }
            var paramType1 = parameters[1].ParameterType;
            if (!paramType1.IsValidInput<TArg1>(4, ref pAddress))
            {
                return false;
            }
            var paramType2 = parameters[2].ParameterType;
            if (!paramType2.IsValidInput<TArg2>(8, ref pAddress))
            {
                return false;
            }
            var paramType3 = parameters[3].ParameterType;
            if (!paramType3.IsValidInput<TArg3>(16, ref pAddress))
            {
                return false;
            }
            var paramType4 = parameters[4].ParameterType;
            if (!paramType4.IsValidInput<TArg4>(32, ref pAddress))
            {
                return false;
            }
            var paramType5 = parameters[5].ParameterType;
            if (!paramType5.IsValidInput<TArg5>(64, ref pAddress))
            {
                return false;
            }
            var paramType6 = parameters[6].ParameterType;
            if (!paramType6.IsValidInput<TArg6>(128, ref pAddress))
            {
                return false;
            }
            var paramType7 = parameters[7].ParameterType;
            if (!paramType7.IsValidInput<TArg7>(256, ref pAddress))
            {
                return false;
            }
            if (pAddress != 0)
            {
                return false;
            }
            pAddress = method.GetFunctionPointer();
            return true;
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool ValidateInstanceVirtualMethodRaw<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(MethodBase method, Type targetType, out nint pAddress)
        {
            pAddress = 0;
            if (method.IsStatic)
            {
                return false;
            }
            if (!method.IsOverridable())
            {
                return false;
            }
            var isValidGeneric = !method.IsGenericMethodDefinition || ValidateGenericMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(ref method);
            if (!isValidGeneric)
            {
                return false;
            }
            var parameters = method.GetParametersFast();
            var parameterLength = parameters.Count;
            if (parameterLength != 8)
            {
                return false;
            }
            if (method is MethodInfo mi)
            {
                var returnType = mi?.ReturnType ?? typeof(void);
                if (returnType != typeof(void))
                {
                    return false;
                }
            }
            var reflectedType = method.ReflectedType;
            if (!reflectedType.IsValidVirtualInput<TTarget>(targetType, out var isVirtualCall))
            {
                return false;
            }
            if (isVirtualCall)
            {
                ArrayCache.Types8[0] = parameters[0].ParameterType;
                ArrayCache.Types8[1] = parameters[1].ParameterType;
                ArrayCache.Types8[2] = parameters[2].ParameterType;
                ArrayCache.Types8[3] = parameters[3].ParameterType;
                ArrayCache.Types8[4] = parameters[4].ParameterType;
                ArrayCache.Types8[5] = parameters[5].ParameterType;
                ArrayCache.Types8[6] = parameters[6].ParameterType;
                ArrayCache.Types8[7] = parameters[7].ParameterType;
                method = targetType.GetInstanceMethodFullAccess(method.Name, null, ArrayCache.Types8, null);
            }
            var paramType0 = parameters[0].ParameterType;
            if (!paramType0.IsValidInput<TArg0>(2, ref pAddress))
            {
                return false;
            }
            var paramType1 = parameters[1].ParameterType;
            if (!paramType1.IsValidInput<TArg1>(4, ref pAddress))
            {
                return false;
            }
            var paramType2 = parameters[2].ParameterType;
            if (!paramType2.IsValidInput<TArg2>(8, ref pAddress))
            {
                return false;
            }
            var paramType3 = parameters[3].ParameterType;
            if (!paramType3.IsValidInput<TArg3>(16, ref pAddress))
            {
                return false;
            }
            var paramType4 = parameters[4].ParameterType;
            if (!paramType4.IsValidInput<TArg4>(32, ref pAddress))
            {
                return false;
            }
            var paramType5 = parameters[5].ParameterType;
            if (!paramType5.IsValidInput<TArg5>(64, ref pAddress))
            {
                return false;
            }
            var paramType6 = parameters[6].ParameterType;
            if (!paramType6.IsValidInput<TArg6>(128, ref pAddress))
            {
                return false;
            }
            var paramType7 = parameters[7].ParameterType;
            if (!paramType7.IsValidInput<TArg7>(256, ref pAddress))
            {
                return false;
            }
            if (pAddress != 0)
            {
                return false;
            }
            pAddress = method.GetFunctionPointer();
            return true;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TReturn InvokeInstanceFast<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TReturn>(this MethodBase self, ref TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7)
        {
            bool isValid;
            nint pAddress;
            if (self.IsOverridable())
            {
                isValid = ValidateInstanceReturnableVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TReturn>(self, target?.GetType(), out pAddress) ||
                          (pAddress != 0 && SecondaryValidateStaticMethod(self, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), ref pAddress));
            }
            else
            {
                isValid = ValidateInstanceReturnableMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TReturn>(self, out pAddress) ||
                          (pAddress != 0 && SecondaryValidateInstanceMethod(self, target?.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), ref pAddress));
            }
            if (!isValid)
            {
                return (TReturn)self.InvokeInstanceLowAlloc(ref target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
            }
            unsafe
            {
                if (REType.IsValueTypeFast<TTarget>())
                {
                    return ((delegate*<ref TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TReturn>)pAddress)(ref target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
                }
                return ((delegate*<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TReturn>)pAddress)(target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TReturn InvokeClassInstanceFast<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TReturn>(this MethodBase self, TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7)
        where TTarget: class
        {
            bool isValid;
            nint pAddress;
            if (self.IsOverridable())
            {
                isValid = ValidateInstanceReturnableVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TReturn>(self, target?.GetType(), out pAddress) ||
                          (pAddress != 0 && SecondaryValidateStaticMethod(self, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), ref pAddress));
            }
            else
            {
                isValid = ValidateInstanceReturnableMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TReturn>(self, out pAddress) ||
                          (pAddress != 0 && SecondaryValidateInstanceMethod(self, target?.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), ref pAddress));
            }
            if (!isValid)
            {
                return (TReturn)self.InvokeClassInstanceLowAlloc(target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
            }
            unsafe
            {
                return ((delegate*<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TReturn>)pAddress)(target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TReturn InvokeStructInstanceFast<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TReturn>(this MethodBase self, ref TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7)
        where TTarget: struct
        {
            bool isValid;
            nint pAddress;
            if (self.IsOverridable())
            {
                isValid = ValidateInstanceReturnableVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TReturn>(self, target.GetType(), out pAddress) ||
                          (pAddress != 0 && SecondaryValidateStaticMethod(self, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), ref pAddress));
            }
            else
            {
                isValid = ValidateInstanceReturnableMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TReturn>(self, out pAddress) ||
                          (pAddress != 0 && SecondaryValidateInstanceMethod(self, target.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), ref pAddress));
            }
            if (!isValid)
            {
                return (TReturn)self.InvokeInstanceLowAlloc(ref target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
            }
            unsafe
            {
                return ((delegate*<ref TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TReturn>)pAddress)(ref target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static object InvokeInstanceLowAlloc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(this MethodBase self, ref TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7)
        {
            if (self.IsGenericMethodDefinition)
            {
                ValidateGenericMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(ref self);
            }
            var targetObj = REReflection.GetBoxWithoutRef(target);
            var parameters = self.GetParametersFast();
            ArrayCache.Objects8[0] = REReflection.GetBox(arg0, parameters[0], out var refArg0);
            ArrayCache.Objects8[1] = REReflection.GetBox(arg1, parameters[1], out var refArg1);
            ArrayCache.Objects8[2] = REReflection.GetBox(arg2, parameters[2], out var refArg2);
            ArrayCache.Objects8[3] = REReflection.GetBox(arg3, parameters[3], out var refArg3);
            ArrayCache.Objects8[4] = REReflection.GetBox(arg4, parameters[4], out var refArg4);
            ArrayCache.Objects8[5] = REReflection.GetBox(arg5, parameters[5], out var refArg5);
            ArrayCache.Objects8[6] = REReflection.GetBox(arg6, parameters[6], out var refArg6);
            ArrayCache.Objects8[7] = REReflection.GetBox(arg7, parameters[7], out var refArg7);
            try
            {
                return self.Invoke(targetObj, ArrayCache.Objects8);
            }
            finally
            {
                REReflection.Unbox(targetObj, out target);
                REReflection.ReturnBoxWithoutRef<TTarget>(targetObj);
                REReflection.ReturnBox<TArg0>(ArrayCache.Objects8[0], parameters[0], refArg0);
                REReflection.ReturnBox<TArg1>(ArrayCache.Objects8[1], parameters[1], refArg1);
                REReflection.ReturnBox<TArg2>(ArrayCache.Objects8[2], parameters[2], refArg2);
                REReflection.ReturnBox<TArg3>(ArrayCache.Objects8[3], parameters[3], refArg3);
                REReflection.ReturnBox<TArg4>(ArrayCache.Objects8[4], parameters[4], refArg4);
                REReflection.ReturnBox<TArg5>(ArrayCache.Objects8[5], parameters[5], refArg5);
                REReflection.ReturnBox<TArg6>(ArrayCache.Objects8[6], parameters[6], refArg6);
                REReflection.ReturnBox<TArg7>(ArrayCache.Objects8[7], parameters[7], refArg7);
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static object InvokeClassInstanceLowAlloc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(this MethodBase self, TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7)
        where TTarget: class
        {
            if (self.IsGenericMethodDefinition)
            {
                ValidateGenericMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(ref self);
            }
            var parameters = self.GetParametersFast();
            ArrayCache.Objects8[0] = REReflection.GetBox(arg0, parameters[0], out var refArg0);
            ArrayCache.Objects8[1] = REReflection.GetBox(arg1, parameters[1], out var refArg1);
            ArrayCache.Objects8[2] = REReflection.GetBox(arg2, parameters[2], out var refArg2);
            ArrayCache.Objects8[3] = REReflection.GetBox(arg3, parameters[3], out var refArg3);
            ArrayCache.Objects8[4] = REReflection.GetBox(arg4, parameters[4], out var refArg4);
            ArrayCache.Objects8[5] = REReflection.GetBox(arg5, parameters[5], out var refArg5);
            ArrayCache.Objects8[6] = REReflection.GetBox(arg6, parameters[6], out var refArg6);
            ArrayCache.Objects8[7] = REReflection.GetBox(arg7, parameters[7], out var refArg7);
            try
            {
                return self.Invoke(target, ArrayCache.Objects8);
            }
            finally
            {
                REReflection.ReturnBox<TArg0>(ArrayCache.Objects8[0], parameters[0], refArg0);
                REReflection.ReturnBox<TArg1>(ArrayCache.Objects8[1], parameters[1], refArg1);
                REReflection.ReturnBox<TArg2>(ArrayCache.Objects8[2], parameters[2], refArg2);
                REReflection.ReturnBox<TArg3>(ArrayCache.Objects8[3], parameters[3], refArg3);
                REReflection.ReturnBox<TArg4>(ArrayCache.Objects8[4], parameters[4], refArg4);
                REReflection.ReturnBox<TArg5>(ArrayCache.Objects8[5], parameters[5], refArg5);
                REReflection.ReturnBox<TArg6>(ArrayCache.Objects8[6], parameters[6], refArg6);
                REReflection.ReturnBox<TArg7>(ArrayCache.Objects8[7], parameters[7], refArg7);
            }
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool ValidateInstanceReturnableMethodRaw<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TReturn>(MethodBase method, out nint pAddress)
        {
            pAddress = 0;
            if (method.IsStatic)
            {
                return false;
            }
            if (method.IsOverridable())
            {
                return false;
            }
            var isValidGeneric = !method.IsGenericMethodDefinition || ValidateGenericReturnableMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TReturn>(ref method);
            if (!isValidGeneric)
            {
                return false;
            }
            var parameters = method.GetParametersFast();
            var parameterLength = parameters.Count;
            if (parameterLength != 8)
            {
                return false;
            }
            if (method is MethodInfo mi)
            {
                var returnType = mi?.ReturnType ?? typeof(void);
                if (!returnType.IsValidOutput<TReturn>())
                {
                    return false;
                }
            }
            var reflectedType = method.ReflectedType;
            if (!reflectedType.IsValidInputWithoutRef<TTarget>(1, ref pAddress))
            {
                return false;
            }
            var paramType0 = parameters[0].ParameterType;
            if (!paramType0.IsValidInput<TArg0>(2, ref pAddress))
            {
                return false;
            }
            var paramType1 = parameters[1].ParameterType;
            if (!paramType1.IsValidInput<TArg1>(4, ref pAddress))
            {
                return false;
            }
            var paramType2 = parameters[2].ParameterType;
            if (!paramType2.IsValidInput<TArg2>(8, ref pAddress))
            {
                return false;
            }
            var paramType3 = parameters[3].ParameterType;
            if (!paramType3.IsValidInput<TArg3>(16, ref pAddress))
            {
                return false;
            }
            var paramType4 = parameters[4].ParameterType;
            if (!paramType4.IsValidInput<TArg4>(32, ref pAddress))
            {
                return false;
            }
            var paramType5 = parameters[5].ParameterType;
            if (!paramType5.IsValidInput<TArg5>(64, ref pAddress))
            {
                return false;
            }
            var paramType6 = parameters[6].ParameterType;
            if (!paramType6.IsValidInput<TArg6>(128, ref pAddress))
            {
                return false;
            }
            var paramType7 = parameters[7].ParameterType;
            if (!paramType7.IsValidInput<TArg7>(256, ref pAddress))
            {
                return false;
            }
            if (pAddress != 0)
            {
                return false;
            }
            pAddress = method.GetFunctionPointer();
            return true;
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool ValidateInstanceReturnableVirtualMethodRaw<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TReturn>(MethodBase method, Type targetType, out nint pAddress)
        {
            pAddress = 0;
            if (method.IsStatic)
            {
                return false;
            }
            if (!method.IsOverridable())
            {
                return false;
            }
            var isValidGeneric = !method.IsGenericMethodDefinition || ValidateGenericReturnableMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TReturn>(ref method);
            if (!isValidGeneric)
            {
                return false;
            }
            var parameters = method.GetParametersFast();
            var parameterLength = parameters.Count;
            if (parameterLength != 8)
            {
                return false;
            }
            if (method is MethodInfo mi)
            {
                var returnType = mi?.ReturnType ?? typeof(void);
                if (!returnType.IsValidOutput<TReturn>())
                {
                    return false;
                }
            }
            var reflectedType = method.ReflectedType;
            if (!reflectedType.IsValidVirtualInput<TTarget>(targetType, out var isVirtualCall))
            {
                return false;
            }
            if (isVirtualCall)
            {
                ArrayCache.Types8[0] = parameters[0].ParameterType;
                ArrayCache.Types8[1] = parameters[1].ParameterType;
                ArrayCache.Types8[2] = parameters[2].ParameterType;
                ArrayCache.Types8[3] = parameters[3].ParameterType;
                ArrayCache.Types8[4] = parameters[4].ParameterType;
                ArrayCache.Types8[5] = parameters[5].ParameterType;
                ArrayCache.Types8[6] = parameters[6].ParameterType;
                ArrayCache.Types8[7] = parameters[7].ParameterType;
                method = targetType.GetInstanceMethodFullAccess(method.Name, null, ArrayCache.Types8, null);
            }
            var paramType0 = parameters[0].ParameterType;
            if (!paramType0.IsValidInput<TArg0>(2, ref pAddress))
            {
                return false;
            }
            var paramType1 = parameters[1].ParameterType;
            if (!paramType1.IsValidInput<TArg1>(4, ref pAddress))
            {
                return false;
            }
            var paramType2 = parameters[2].ParameterType;
            if (!paramType2.IsValidInput<TArg2>(8, ref pAddress))
            {
                return false;
            }
            var paramType3 = parameters[3].ParameterType;
            if (!paramType3.IsValidInput<TArg3>(16, ref pAddress))
            {
                return false;
            }
            var paramType4 = parameters[4].ParameterType;
            if (!paramType4.IsValidInput<TArg4>(32, ref pAddress))
            {
                return false;
            }
            var paramType5 = parameters[5].ParameterType;
            if (!paramType5.IsValidInput<TArg5>(64, ref pAddress))
            {
                return false;
            }
            var paramType6 = parameters[6].ParameterType;
            if (!paramType6.IsValidInput<TArg6>(128, ref pAddress))
            {
                return false;
            }
            var paramType7 = parameters[7].ParameterType;
            if (!paramType7.IsValidInput<TArg7>(256, ref pAddress))
            {
                return false;
            }
            if (pAddress != 0)
            {
                return false;
            }
            pAddress = method.GetFunctionPointer();
            return true;
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool SecondaryValidateInstanceMethodRaw(MethodBase method, Type target, Type arg0, Type arg1, Type arg2, Type arg3, Type arg4, Type arg5, Type arg6, Type arg7, ref nint pAddress)
        {
            if ((pAddress & 1) != 0)
            {
                var reflectedType = method.ReflectedType;
                if (!reflectedType.IsNullAssignableFromFast(target))
                {
                    return false;
                }
            }
            var parameters = method.GetParametersFast();
            if ((pAddress & 2) != 0)
            {
                var paramType = parameters[0].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg0))
                {
                    return false;
                }
            }
            if ((pAddress & 4) != 0)
            {
                var paramType = parameters[1].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg1))
                {
                    return false;
                }
            }
            if ((pAddress & 8) != 0)
            {
                var paramType = parameters[2].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg2))
                {
                    return false;
                }
            }
            if ((pAddress & 16) != 0)
            {
                var paramType = parameters[3].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg3))
                {
                    return false;
                }
            }
            if ((pAddress & 32) != 0)
            {
                var paramType = parameters[4].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg4))
                {
                    return false;
                }
            }
            if ((pAddress & 64) != 0)
            {
                var paramType = parameters[5].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg5))
                {
                    return false;
                }
            }
            if ((pAddress & 128) != 0)
            {
                var paramType = parameters[6].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg6))
                {
                    return false;
                }
            }
            if ((pAddress & 256) != 0)
            {
                var paramType = parameters[7].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg7))
                {
                    return false;
                }
            }
            pAddress = method.GetFunctionPointer();
            return true;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void InvokeStaticFast<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(this MethodBase self, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7)
        {
            bool isValid;
            nint pAddress;
            isValid = ValidateStaticMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(self, out pAddress) ||
                      (pAddress != 0 && SecondaryValidateStaticMethod(self, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), ref pAddress));
            if (!isValid)
            {
                self.InvokeStaticLowAlloc(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
                return;
            }
            unsafe
            {
                ((delegate*<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, void>)pAddress)(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
                return;
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static object InvokeStaticLowAlloc<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(this MethodBase self, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7)
        {
            if (self.IsGenericMethodDefinition)
            {
                ValidateGenericMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(ref self);
            }
            var parameters = self.GetParametersFast();
            ArrayCache.Objects8[0] = REReflection.GetBox(arg0, parameters[0], out var refArg0);
            ArrayCache.Objects8[1] = REReflection.GetBox(arg1, parameters[1], out var refArg1);
            ArrayCache.Objects8[2] = REReflection.GetBox(arg2, parameters[2], out var refArg2);
            ArrayCache.Objects8[3] = REReflection.GetBox(arg3, parameters[3], out var refArg3);
            ArrayCache.Objects8[4] = REReflection.GetBox(arg4, parameters[4], out var refArg4);
            ArrayCache.Objects8[5] = REReflection.GetBox(arg5, parameters[5], out var refArg5);
            ArrayCache.Objects8[6] = REReflection.GetBox(arg6, parameters[6], out var refArg6);
            ArrayCache.Objects8[7] = REReflection.GetBox(arg7, parameters[7], out var refArg7);
            try
            {
                return self.Invoke(null, ArrayCache.Objects8);
            }
            finally
            {
                REReflection.ReturnBox<TArg0>(ArrayCache.Objects8[0], parameters[0], refArg0);
                REReflection.ReturnBox<TArg1>(ArrayCache.Objects8[1], parameters[1], refArg1);
                REReflection.ReturnBox<TArg2>(ArrayCache.Objects8[2], parameters[2], refArg2);
                REReflection.ReturnBox<TArg3>(ArrayCache.Objects8[3], parameters[3], refArg3);
                REReflection.ReturnBox<TArg4>(ArrayCache.Objects8[4], parameters[4], refArg4);
                REReflection.ReturnBox<TArg5>(ArrayCache.Objects8[5], parameters[5], refArg5);
                REReflection.ReturnBox<TArg6>(ArrayCache.Objects8[6], parameters[6], refArg6);
                REReflection.ReturnBox<TArg7>(ArrayCache.Objects8[7], parameters[7], refArg7);
            }
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool ValidateStaticMethodRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(MethodBase method, out nint pAddress)
        {
            pAddress = 0;
            if (!method.IsStatic)
            {
                return false;
            }
            if (method.IsOverridable())
            {
                return false;
            }
            var isValidGeneric = !method.IsGenericMethodDefinition || ValidateGenericMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(ref method);
            if (!isValidGeneric)
            {
                return false;
            }
            var parameters = method.GetParametersFast();
            var parameterLength = parameters.Count;
            if (parameterLength != 8)
            {
                return false;
            }
            if (method is MethodInfo mi)
            {
                var returnType = mi?.ReturnType ?? typeof(void);
                if (returnType != typeof(void))
                {
                    return false;
                }
            }
            var paramType0 = parameters[0].ParameterType;
            if (!paramType0.IsValidInput<TArg0>(2, ref pAddress))
            {
                return false;
            }
            var paramType1 = parameters[1].ParameterType;
            if (!paramType1.IsValidInput<TArg1>(4, ref pAddress))
            {
                return false;
            }
            var paramType2 = parameters[2].ParameterType;
            if (!paramType2.IsValidInput<TArg2>(8, ref pAddress))
            {
                return false;
            }
            var paramType3 = parameters[3].ParameterType;
            if (!paramType3.IsValidInput<TArg3>(16, ref pAddress))
            {
                return false;
            }
            var paramType4 = parameters[4].ParameterType;
            if (!paramType4.IsValidInput<TArg4>(32, ref pAddress))
            {
                return false;
            }
            var paramType5 = parameters[5].ParameterType;
            if (!paramType5.IsValidInput<TArg5>(64, ref pAddress))
            {
                return false;
            }
            var paramType6 = parameters[6].ParameterType;
            if (!paramType6.IsValidInput<TArg6>(128, ref pAddress))
            {
                return false;
            }
            var paramType7 = parameters[7].ParameterType;
            if (!paramType7.IsValidInput<TArg7>(256, ref pAddress))
            {
                return false;
            }
            if (pAddress != 0)
            {
                return false;
            }
            pAddress = method.GetFunctionPointer();
            return true;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TReturn InvokeStaticFast<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TReturn>(this MethodBase self, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7)
        {
            bool isValid;
            nint pAddress;
            isValid = ValidateStaticReturnableMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TReturn>(self, out pAddress) ||
                      (pAddress != 0 && SecondaryValidateStaticMethod(self, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), ref pAddress));
            if (!isValid)
            {
                return (TReturn)self.InvokeStaticLowAlloc(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
            }
            unsafe
            {
                return ((delegate*<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TReturn>)pAddress)(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
            }
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool ValidateStaticReturnableMethodRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TReturn>(MethodBase method, out nint pAddress)
        {
            pAddress = 0;
            if (!method.IsStatic)
            {
                return false;
            }
            if (method.IsOverridable())
            {
                return false;
            }
            var isValidGeneric = !method.IsGenericMethodDefinition || ValidateGenericReturnableMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TReturn>(ref method);
            if (!isValidGeneric)
            {
                return false;
            }
            var parameters = method.GetParametersFast();
            var parameterLength = parameters.Count;
            if (parameterLength != 8)
            {
                return false;
            }
            if (method is MethodInfo mi)
            {
                var returnType = mi?.ReturnType ?? typeof(void);
                if (!returnType.IsValidOutput<TReturn>())
                {
                    return false;
                }
            }
            var paramType0 = parameters[0].ParameterType;
            if (!paramType0.IsValidInput<TArg0>(2, ref pAddress))
            {
                return false;
            }
            var paramType1 = parameters[1].ParameterType;
            if (!paramType1.IsValidInput<TArg1>(4, ref pAddress))
            {
                return false;
            }
            var paramType2 = parameters[2].ParameterType;
            if (!paramType2.IsValidInput<TArg2>(8, ref pAddress))
            {
                return false;
            }
            var paramType3 = parameters[3].ParameterType;
            if (!paramType3.IsValidInput<TArg3>(16, ref pAddress))
            {
                return false;
            }
            var paramType4 = parameters[4].ParameterType;
            if (!paramType4.IsValidInput<TArg4>(32, ref pAddress))
            {
                return false;
            }
            var paramType5 = parameters[5].ParameterType;
            if (!paramType5.IsValidInput<TArg5>(64, ref pAddress))
            {
                return false;
            }
            var paramType6 = parameters[6].ParameterType;
            if (!paramType6.IsValidInput<TArg6>(128, ref pAddress))
            {
                return false;
            }
            var paramType7 = parameters[7].ParameterType;
            if (!paramType7.IsValidInput<TArg7>(256, ref pAddress))
            {
                return false;
            }
            if (pAddress != 0)
            {
                return false;
            }
            pAddress = method.GetFunctionPointer();
            return true;
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool SecondaryValidateStaticMethodRaw(MethodBase method, Type arg0, Type arg1, Type arg2, Type arg3, Type arg4, Type arg5, Type arg6, Type arg7, ref nint pAddress)
        {
            var parameters = method.GetParametersFast();
            if ((pAddress & 2) != 0)
            {
                var paramType = parameters[0].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg0))
                {
                    return false;
                }
            }
            if ((pAddress & 4) != 0)
            {
                var paramType = parameters[1].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg1))
                {
                    return false;
                }
            }
            if ((pAddress & 8) != 0)
            {
                var paramType = parameters[2].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg2))
                {
                    return false;
                }
            }
            if ((pAddress & 16) != 0)
            {
                var paramType = parameters[3].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg3))
                {
                    return false;
                }
            }
            if ((pAddress & 32) != 0)
            {
                var paramType = parameters[4].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg4))
                {
                    return false;
                }
            }
            if ((pAddress & 64) != 0)
            {
                var paramType = parameters[5].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg5))
                {
                    return false;
                }
            }
            if ((pAddress & 128) != 0)
            {
                var paramType = parameters[6].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg6))
                {
                    return false;
                }
            }
            if ((pAddress & 256) != 0)
            {
                var paramType = parameters[7].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg7))
                {
                    return false;
                }
            }
            pAddress = method.GetFunctionPointer();
            return true;
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool ValidateGenericMethodRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(ref MethodBase method)
        {
            if (!method.IsGenericMethodDefinition)
            {
                return true;
            }
            var genericArguments = method.GetGenericArgumentsFast();
            if (genericArguments.Count < 8)
            {
                return false;
            }
            uint mask = 0;
            var mi = method as MethodInfo;
            var parameters = method.GetParametersFast();
            var index0 = IndexOf(genericArguments, parameters[0].ParameterType);
            if (index0 >= 0)
            {
                mask |= 1u << index0;
            }
            var index1 = IndexOf(genericArguments, parameters[1].ParameterType);
            if (index1 >= 0)
            {
                mask |= 1u << index1;
            }
            var index2 = IndexOf(genericArguments, parameters[2].ParameterType);
            if (index2 >= 0)
            {
                mask |= 1u << index2;
            }
            var index3 = IndexOf(genericArguments, parameters[3].ParameterType);
            if (index3 >= 0)
            {
                mask |= 1u << index3;
            }
            var index4 = IndexOf(genericArguments, parameters[4].ParameterType);
            if (index4 >= 0)
            {
                mask |= 1u << index4;
            }
            var index5 = IndexOf(genericArguments, parameters[5].ParameterType);
            if (index5 >= 0)
            {
                mask |= 1u << index5;
            }
            var index6 = IndexOf(genericArguments, parameters[6].ParameterType);
            if (index6 >= 0)
            {
                mask |= 1u << index6;
            }
            var index7 = IndexOf(genericArguments, parameters[7].ParameterType);
            if (index7 >= 0)
            {
                mask |= 1u << index7;
            }
            if (REReflection.BitCount(mask) != genericArguments.Count)
            {
                return false;
            }
            var types = ArrayCache.GetArrayCache<Type>(genericArguments.Count);
            if (index0 >= 0)
            {
                types[index0] = typeof(TArg0);
            }
            if (index1 >= 0)
            {
                types[index1] = typeof(TArg1);
            }
            if (index2 >= 0)
            {
                types[index2] = typeof(TArg2);
            }
            if (index3 >= 0)
            {
                types[index3] = typeof(TArg3);
            }
            if (index4 >= 0)
            {
                types[index4] = typeof(TArg4);
            }
            if (index5 >= 0)
            {
                types[index5] = typeof(TArg5);
            }
            if (index6 >= 0)
            {
                types[index6] = typeof(TArg6);
            }
            if (index7 >= 0)
            {
                types[index7] = typeof(TArg7);
            }
            #if ENABLE_IL2CPP
            bool isFound = false;
            var usingMethods = method.GetUsingGenericInstanceMethods();
            foreach (var usingMethod in usingMethods)
            {
                if (usingMethod.GetGenericArgumentsFast().SequenceEqual(types))
                {
                    isFound = true;
                    break;
                }
            }
            if (!isFound)
            {
                return false;
            }
            #endif
            method = mi.MakeGenericMethodFast(types);
            return true;
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool ValidateGenericReturnableMethodRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TReturn>(ref MethodBase method)
        {
            if (!method.IsGenericMethodDefinition)
            {
                return true;
            }
            var genericArguments = method.GetGenericArgumentsFast();
            if (genericArguments.Count < 9)
            {
                return false;
            }
            uint mask = 0;
            var mi = method as MethodInfo;
            var returnType = mi.ReturnType ?? typeof(void);
            var index = IndexOf(genericArguments, returnType);
            if (index >= 0)
            {
                mask |= 1u << index;
            }
            var parameters = method.GetParametersFast();
            var index0 = IndexOf(genericArguments, parameters[0].ParameterType);
            if (index0 >= 0)
            {
                mask |= 1u << index0;
            }
            var index1 = IndexOf(genericArguments, parameters[1].ParameterType);
            if (index1 >= 0)
            {
                mask |= 1u << index1;
            }
            var index2 = IndexOf(genericArguments, parameters[2].ParameterType);
            if (index2 >= 0)
            {
                mask |= 1u << index2;
            }
            var index3 = IndexOf(genericArguments, parameters[3].ParameterType);
            if (index3 >= 0)
            {
                mask |= 1u << index3;
            }
            var index4 = IndexOf(genericArguments, parameters[4].ParameterType);
            if (index4 >= 0)
            {
                mask |= 1u << index4;
            }
            var index5 = IndexOf(genericArguments, parameters[5].ParameterType);
            if (index5 >= 0)
            {
                mask |= 1u << index5;
            }
            var index6 = IndexOf(genericArguments, parameters[6].ParameterType);
            if (index6 >= 0)
            {
                mask |= 1u << index6;
            }
            var index7 = IndexOf(genericArguments, parameters[7].ParameterType);
            if (index7 >= 0)
            {
                mask |= 1u << index7;
            }
            if (REReflection.BitCount(mask) != genericArguments.Count)
            {
                return false;
            }
            var types = ArrayCache.GetArrayCache<Type>(genericArguments.Count);
            if (index >= 0)
            {
                types[index] = typeof(TReturn);
            }
            if (index0 >= 0)
            {
                types[index0] = typeof(TArg0);
            }
            if (index1 >= 0)
            {
                types[index1] = typeof(TArg1);
            }
            if (index2 >= 0)
            {
                types[index2] = typeof(TArg2);
            }
            if (index3 >= 0)
            {
                types[index3] = typeof(TArg3);
            }
            if (index4 >= 0)
            {
                types[index4] = typeof(TArg4);
            }
            if (index5 >= 0)
            {
                types[index5] = typeof(TArg5);
            }
            if (index6 >= 0)
            {
                types[index6] = typeof(TArg6);
            }
            if (index7 >= 0)
            {
                types[index7] = typeof(TArg7);
            }
            #if ENABLE_IL2CPP
            bool isFound = false;
            var usingMethods = method.GetUsingGenericInstanceMethods();
            foreach (var usingMethod in usingMethods)
            {
                if (usingMethod.GetGenericArgumentsFast().SequenceEqual(types))
                {
                    isFound = true;
                    break;
                }
            }
            if (!isFound)
            {
                return false;
            }
            #endif
            method = mi.MakeGenericMethodFast(types);
            return true;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void InvokeInstanceFast<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(this MethodBase self, ref TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8)
        {
            bool isValid;
            nint pAddress;
            if (self.IsOverridable())
            {
                isValid = ValidateInstanceVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(self, target?.GetType(), out pAddress) ||
                          (pAddress != 0 && SecondaryValidateStaticMethod(self, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), ref pAddress));
            }
            else
            {
                isValid = ValidateInstanceMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(self, out pAddress) ||
                          (pAddress != 0 && SecondaryValidateInstanceMethod(self, target?.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), ref pAddress));
            }
            if (!isValid)
            {
                self.InvokeInstanceLowAlloc(ref target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
                return;
            }
            unsafe
            {
                if (REType.IsValueTypeFast<TTarget>())
                {
                    ((delegate*<ref TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, void>)pAddress)(ref target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
                    return;
                }
                ((delegate*<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, void>)pAddress)(target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
                return;
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void InvokeClassInstanceFast<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(this MethodBase self, TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8)
        where TTarget: class
        {
            bool isValid;
            nint pAddress;
            if (self.IsOverridable())
            {
                isValid = ValidateInstanceVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(self, target?.GetType(), out pAddress) ||
                          (pAddress != 0 && SecondaryValidateStaticMethod(self, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), ref pAddress));
            }
            else
            {
                isValid = ValidateInstanceMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(self, out pAddress) ||
                          (pAddress != 0 && SecondaryValidateInstanceMethod(self, target?.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), ref pAddress));
            }
            if (!isValid)
            {
                self.InvokeClassInstanceLowAlloc(target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
                return;
            }
            unsafe
            {
                ((delegate*<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, void>)pAddress)(target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
                return;
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void InvokeStructInstanceFast<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(this MethodBase self, ref TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8)
        where TTarget: struct
        {
            bool isValid;
            nint pAddress;
            if (self.IsOverridable())
            {
                isValid = ValidateInstanceVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(self, target.GetType(), out pAddress) ||
                          (pAddress != 0 && SecondaryValidateStaticMethod(self, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), ref pAddress));
            }
            else
            {
                isValid = ValidateInstanceMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(self, out pAddress) ||
                          (pAddress != 0 && SecondaryValidateInstanceMethod(self, target.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), ref pAddress));
            }
            if (!isValid)
            {
                self.InvokeInstanceLowAlloc(ref target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
                return;
            }
            unsafe
            {
                ((delegate*<ref TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, void>)pAddress)(ref target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
                return;
            }
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool ValidateInstanceMethodRaw<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(MethodBase method, out nint pAddress)
        {
            pAddress = 0;
            if (method.IsStatic)
            {
                return false;
            }
            if (method.IsOverridable())
            {
                return false;
            }
            var isValidGeneric = !method.IsGenericMethodDefinition || ValidateGenericMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(ref method);
            if (!isValidGeneric)
            {
                return false;
            }
            var parameters = method.GetParametersFast();
            var parameterLength = parameters.Count;
            if (parameterLength != 9)
            {
                return false;
            }
            if (method is MethodInfo mi)
            {
                var returnType = mi?.ReturnType ?? typeof(void);
                if (returnType != typeof(void))
                {
                    return false;
                }
            }
            var reflectedType = method.ReflectedType;
            if (!reflectedType.IsValidInputWithoutRef<TTarget>(1, ref pAddress))
            {
                return false;
            }
            var paramType0 = parameters[0].ParameterType;
            if (!paramType0.IsValidInput<TArg0>(2, ref pAddress))
            {
                return false;
            }
            var paramType1 = parameters[1].ParameterType;
            if (!paramType1.IsValidInput<TArg1>(4, ref pAddress))
            {
                return false;
            }
            var paramType2 = parameters[2].ParameterType;
            if (!paramType2.IsValidInput<TArg2>(8, ref pAddress))
            {
                return false;
            }
            var paramType3 = parameters[3].ParameterType;
            if (!paramType3.IsValidInput<TArg3>(16, ref pAddress))
            {
                return false;
            }
            var paramType4 = parameters[4].ParameterType;
            if (!paramType4.IsValidInput<TArg4>(32, ref pAddress))
            {
                return false;
            }
            var paramType5 = parameters[5].ParameterType;
            if (!paramType5.IsValidInput<TArg5>(64, ref pAddress))
            {
                return false;
            }
            var paramType6 = parameters[6].ParameterType;
            if (!paramType6.IsValidInput<TArg6>(128, ref pAddress))
            {
                return false;
            }
            var paramType7 = parameters[7].ParameterType;
            if (!paramType7.IsValidInput<TArg7>(256, ref pAddress))
            {
                return false;
            }
            var paramType8 = parameters[8].ParameterType;
            if (!paramType8.IsValidInput<TArg8>(512, ref pAddress))
            {
                return false;
            }
            if (pAddress != 0)
            {
                return false;
            }
            pAddress = method.GetFunctionPointer();
            return true;
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool ValidateInstanceVirtualMethodRaw<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(MethodBase method, Type targetType, out nint pAddress)
        {
            pAddress = 0;
            if (method.IsStatic)
            {
                return false;
            }
            if (!method.IsOverridable())
            {
                return false;
            }
            var isValidGeneric = !method.IsGenericMethodDefinition || ValidateGenericMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(ref method);
            if (!isValidGeneric)
            {
                return false;
            }
            var parameters = method.GetParametersFast();
            var parameterLength = parameters.Count;
            if (parameterLength != 9)
            {
                return false;
            }
            if (method is MethodInfo mi)
            {
                var returnType = mi?.ReturnType ?? typeof(void);
                if (returnType != typeof(void))
                {
                    return false;
                }
            }
            var reflectedType = method.ReflectedType;
            if (!reflectedType.IsValidVirtualInput<TTarget>(targetType, out var isVirtualCall))
            {
                return false;
            }
            if (isVirtualCall)
            {
                ArrayCache.Types9[0] = parameters[0].ParameterType;
                ArrayCache.Types9[1] = parameters[1].ParameterType;
                ArrayCache.Types9[2] = parameters[2].ParameterType;
                ArrayCache.Types9[3] = parameters[3].ParameterType;
                ArrayCache.Types9[4] = parameters[4].ParameterType;
                ArrayCache.Types9[5] = parameters[5].ParameterType;
                ArrayCache.Types9[6] = parameters[6].ParameterType;
                ArrayCache.Types9[7] = parameters[7].ParameterType;
                ArrayCache.Types9[8] = parameters[8].ParameterType;
                method = targetType.GetInstanceMethodFullAccess(method.Name, null, ArrayCache.Types9, null);
            }
            var paramType0 = parameters[0].ParameterType;
            if (!paramType0.IsValidInput<TArg0>(2, ref pAddress))
            {
                return false;
            }
            var paramType1 = parameters[1].ParameterType;
            if (!paramType1.IsValidInput<TArg1>(4, ref pAddress))
            {
                return false;
            }
            var paramType2 = parameters[2].ParameterType;
            if (!paramType2.IsValidInput<TArg2>(8, ref pAddress))
            {
                return false;
            }
            var paramType3 = parameters[3].ParameterType;
            if (!paramType3.IsValidInput<TArg3>(16, ref pAddress))
            {
                return false;
            }
            var paramType4 = parameters[4].ParameterType;
            if (!paramType4.IsValidInput<TArg4>(32, ref pAddress))
            {
                return false;
            }
            var paramType5 = parameters[5].ParameterType;
            if (!paramType5.IsValidInput<TArg5>(64, ref pAddress))
            {
                return false;
            }
            var paramType6 = parameters[6].ParameterType;
            if (!paramType6.IsValidInput<TArg6>(128, ref pAddress))
            {
                return false;
            }
            var paramType7 = parameters[7].ParameterType;
            if (!paramType7.IsValidInput<TArg7>(256, ref pAddress))
            {
                return false;
            }
            var paramType8 = parameters[8].ParameterType;
            if (!paramType8.IsValidInput<TArg8>(512, ref pAddress))
            {
                return false;
            }
            if (pAddress != 0)
            {
                return false;
            }
            pAddress = method.GetFunctionPointer();
            return true;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TReturn InvokeInstanceFast<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TReturn>(this MethodBase self, ref TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8)
        {
            bool isValid;
            nint pAddress;
            if (self.IsOverridable())
            {
                isValid = ValidateInstanceReturnableVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TReturn>(self, target?.GetType(), out pAddress) ||
                          (pAddress != 0 && SecondaryValidateStaticMethod(self, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), ref pAddress));
            }
            else
            {
                isValid = ValidateInstanceReturnableMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TReturn>(self, out pAddress) ||
                          (pAddress != 0 && SecondaryValidateInstanceMethod(self, target?.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), ref pAddress));
            }
            if (!isValid)
            {
                return (TReturn)self.InvokeInstanceLowAlloc(ref target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
            }
            unsafe
            {
                if (REType.IsValueTypeFast<TTarget>())
                {
                    return ((delegate*<ref TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TReturn>)pAddress)(ref target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
                }
                return ((delegate*<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TReturn>)pAddress)(target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TReturn InvokeClassInstanceFast<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TReturn>(this MethodBase self, TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8)
        where TTarget: class
        {
            bool isValid;
            nint pAddress;
            if (self.IsOverridable())
            {
                isValid = ValidateInstanceReturnableVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TReturn>(self, target?.GetType(), out pAddress) ||
                          (pAddress != 0 && SecondaryValidateStaticMethod(self, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), ref pAddress));
            }
            else
            {
                isValid = ValidateInstanceReturnableMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TReturn>(self, out pAddress) ||
                          (pAddress != 0 && SecondaryValidateInstanceMethod(self, target?.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), ref pAddress));
            }
            if (!isValid)
            {
                return (TReturn)self.InvokeClassInstanceLowAlloc(target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
            }
            unsafe
            {
                return ((delegate*<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TReturn>)pAddress)(target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TReturn InvokeStructInstanceFast<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TReturn>(this MethodBase self, ref TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8)
        where TTarget: struct
        {
            bool isValid;
            nint pAddress;
            if (self.IsOverridable())
            {
                isValid = ValidateInstanceReturnableVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TReturn>(self, target.GetType(), out pAddress) ||
                          (pAddress != 0 && SecondaryValidateStaticMethod(self, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), ref pAddress));
            }
            else
            {
                isValid = ValidateInstanceReturnableMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TReturn>(self, out pAddress) ||
                          (pAddress != 0 && SecondaryValidateInstanceMethod(self, target.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), ref pAddress));
            }
            if (!isValid)
            {
                return (TReturn)self.InvokeInstanceLowAlloc(ref target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
            }
            unsafe
            {
                return ((delegate*<ref TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TReturn>)pAddress)(ref target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static object InvokeInstanceLowAlloc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(this MethodBase self, ref TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8)
        {
            if (self.IsGenericMethodDefinition)
            {
                ValidateGenericMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(ref self);
            }
            var targetObj = REReflection.GetBoxWithoutRef(target);
            var parameters = self.GetParametersFast();
            ArrayCache.Objects9[0] = REReflection.GetBox(arg0, parameters[0], out var refArg0);
            ArrayCache.Objects9[1] = REReflection.GetBox(arg1, parameters[1], out var refArg1);
            ArrayCache.Objects9[2] = REReflection.GetBox(arg2, parameters[2], out var refArg2);
            ArrayCache.Objects9[3] = REReflection.GetBox(arg3, parameters[3], out var refArg3);
            ArrayCache.Objects9[4] = REReflection.GetBox(arg4, parameters[4], out var refArg4);
            ArrayCache.Objects9[5] = REReflection.GetBox(arg5, parameters[5], out var refArg5);
            ArrayCache.Objects9[6] = REReflection.GetBox(arg6, parameters[6], out var refArg6);
            ArrayCache.Objects9[7] = REReflection.GetBox(arg7, parameters[7], out var refArg7);
            ArrayCache.Objects9[8] = REReflection.GetBox(arg8, parameters[8], out var refArg8);
            try
            {
                return self.Invoke(targetObj, ArrayCache.Objects9);
            }
            finally
            {
                REReflection.Unbox(targetObj, out target);
                REReflection.ReturnBoxWithoutRef<TTarget>(targetObj);
                REReflection.ReturnBox<TArg0>(ArrayCache.Objects9[0], parameters[0], refArg0);
                REReflection.ReturnBox<TArg1>(ArrayCache.Objects9[1], parameters[1], refArg1);
                REReflection.ReturnBox<TArg2>(ArrayCache.Objects9[2], parameters[2], refArg2);
                REReflection.ReturnBox<TArg3>(ArrayCache.Objects9[3], parameters[3], refArg3);
                REReflection.ReturnBox<TArg4>(ArrayCache.Objects9[4], parameters[4], refArg4);
                REReflection.ReturnBox<TArg5>(ArrayCache.Objects9[5], parameters[5], refArg5);
                REReflection.ReturnBox<TArg6>(ArrayCache.Objects9[6], parameters[6], refArg6);
                REReflection.ReturnBox<TArg7>(ArrayCache.Objects9[7], parameters[7], refArg7);
                REReflection.ReturnBox<TArg8>(ArrayCache.Objects9[8], parameters[8], refArg8);
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static object InvokeClassInstanceLowAlloc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(this MethodBase self, TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8)
        where TTarget: class
        {
            if (self.IsGenericMethodDefinition)
            {
                ValidateGenericMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(ref self);
            }
            var parameters = self.GetParametersFast();
            ArrayCache.Objects9[0] = REReflection.GetBox(arg0, parameters[0], out var refArg0);
            ArrayCache.Objects9[1] = REReflection.GetBox(arg1, parameters[1], out var refArg1);
            ArrayCache.Objects9[2] = REReflection.GetBox(arg2, parameters[2], out var refArg2);
            ArrayCache.Objects9[3] = REReflection.GetBox(arg3, parameters[3], out var refArg3);
            ArrayCache.Objects9[4] = REReflection.GetBox(arg4, parameters[4], out var refArg4);
            ArrayCache.Objects9[5] = REReflection.GetBox(arg5, parameters[5], out var refArg5);
            ArrayCache.Objects9[6] = REReflection.GetBox(arg6, parameters[6], out var refArg6);
            ArrayCache.Objects9[7] = REReflection.GetBox(arg7, parameters[7], out var refArg7);
            ArrayCache.Objects9[8] = REReflection.GetBox(arg8, parameters[8], out var refArg8);
            try
            {
                return self.Invoke(target, ArrayCache.Objects9);
            }
            finally
            {
                REReflection.ReturnBox<TArg0>(ArrayCache.Objects9[0], parameters[0], refArg0);
                REReflection.ReturnBox<TArg1>(ArrayCache.Objects9[1], parameters[1], refArg1);
                REReflection.ReturnBox<TArg2>(ArrayCache.Objects9[2], parameters[2], refArg2);
                REReflection.ReturnBox<TArg3>(ArrayCache.Objects9[3], parameters[3], refArg3);
                REReflection.ReturnBox<TArg4>(ArrayCache.Objects9[4], parameters[4], refArg4);
                REReflection.ReturnBox<TArg5>(ArrayCache.Objects9[5], parameters[5], refArg5);
                REReflection.ReturnBox<TArg6>(ArrayCache.Objects9[6], parameters[6], refArg6);
                REReflection.ReturnBox<TArg7>(ArrayCache.Objects9[7], parameters[7], refArg7);
                REReflection.ReturnBox<TArg8>(ArrayCache.Objects9[8], parameters[8], refArg8);
            }
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool ValidateInstanceReturnableMethodRaw<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TReturn>(MethodBase method, out nint pAddress)
        {
            pAddress = 0;
            if (method.IsStatic)
            {
                return false;
            }
            if (method.IsOverridable())
            {
                return false;
            }
            var isValidGeneric = !method.IsGenericMethodDefinition || ValidateGenericReturnableMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TReturn>(ref method);
            if (!isValidGeneric)
            {
                return false;
            }
            var parameters = method.GetParametersFast();
            var parameterLength = parameters.Count;
            if (parameterLength != 9)
            {
                return false;
            }
            if (method is MethodInfo mi)
            {
                var returnType = mi?.ReturnType ?? typeof(void);
                if (!returnType.IsValidOutput<TReturn>())
                {
                    return false;
                }
            }
            var reflectedType = method.ReflectedType;
            if (!reflectedType.IsValidInputWithoutRef<TTarget>(1, ref pAddress))
            {
                return false;
            }
            var paramType0 = parameters[0].ParameterType;
            if (!paramType0.IsValidInput<TArg0>(2, ref pAddress))
            {
                return false;
            }
            var paramType1 = parameters[1].ParameterType;
            if (!paramType1.IsValidInput<TArg1>(4, ref pAddress))
            {
                return false;
            }
            var paramType2 = parameters[2].ParameterType;
            if (!paramType2.IsValidInput<TArg2>(8, ref pAddress))
            {
                return false;
            }
            var paramType3 = parameters[3].ParameterType;
            if (!paramType3.IsValidInput<TArg3>(16, ref pAddress))
            {
                return false;
            }
            var paramType4 = parameters[4].ParameterType;
            if (!paramType4.IsValidInput<TArg4>(32, ref pAddress))
            {
                return false;
            }
            var paramType5 = parameters[5].ParameterType;
            if (!paramType5.IsValidInput<TArg5>(64, ref pAddress))
            {
                return false;
            }
            var paramType6 = parameters[6].ParameterType;
            if (!paramType6.IsValidInput<TArg6>(128, ref pAddress))
            {
                return false;
            }
            var paramType7 = parameters[7].ParameterType;
            if (!paramType7.IsValidInput<TArg7>(256, ref pAddress))
            {
                return false;
            }
            var paramType8 = parameters[8].ParameterType;
            if (!paramType8.IsValidInput<TArg8>(512, ref pAddress))
            {
                return false;
            }
            if (pAddress != 0)
            {
                return false;
            }
            pAddress = method.GetFunctionPointer();
            return true;
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool ValidateInstanceReturnableVirtualMethodRaw<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TReturn>(MethodBase method, Type targetType, out nint pAddress)
        {
            pAddress = 0;
            if (method.IsStatic)
            {
                return false;
            }
            if (!method.IsOverridable())
            {
                return false;
            }
            var isValidGeneric = !method.IsGenericMethodDefinition || ValidateGenericReturnableMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TReturn>(ref method);
            if (!isValidGeneric)
            {
                return false;
            }
            var parameters = method.GetParametersFast();
            var parameterLength = parameters.Count;
            if (parameterLength != 9)
            {
                return false;
            }
            if (method is MethodInfo mi)
            {
                var returnType = mi?.ReturnType ?? typeof(void);
                if (!returnType.IsValidOutput<TReturn>())
                {
                    return false;
                }
            }
            var reflectedType = method.ReflectedType;
            if (!reflectedType.IsValidVirtualInput<TTarget>(targetType, out var isVirtualCall))
            {
                return false;
            }
            if (isVirtualCall)
            {
                ArrayCache.Types9[0] = parameters[0].ParameterType;
                ArrayCache.Types9[1] = parameters[1].ParameterType;
                ArrayCache.Types9[2] = parameters[2].ParameterType;
                ArrayCache.Types9[3] = parameters[3].ParameterType;
                ArrayCache.Types9[4] = parameters[4].ParameterType;
                ArrayCache.Types9[5] = parameters[5].ParameterType;
                ArrayCache.Types9[6] = parameters[6].ParameterType;
                ArrayCache.Types9[7] = parameters[7].ParameterType;
                ArrayCache.Types9[8] = parameters[8].ParameterType;
                method = targetType.GetInstanceMethodFullAccess(method.Name, null, ArrayCache.Types9, null);
            }
            var paramType0 = parameters[0].ParameterType;
            if (!paramType0.IsValidInput<TArg0>(2, ref pAddress))
            {
                return false;
            }
            var paramType1 = parameters[1].ParameterType;
            if (!paramType1.IsValidInput<TArg1>(4, ref pAddress))
            {
                return false;
            }
            var paramType2 = parameters[2].ParameterType;
            if (!paramType2.IsValidInput<TArg2>(8, ref pAddress))
            {
                return false;
            }
            var paramType3 = parameters[3].ParameterType;
            if (!paramType3.IsValidInput<TArg3>(16, ref pAddress))
            {
                return false;
            }
            var paramType4 = parameters[4].ParameterType;
            if (!paramType4.IsValidInput<TArg4>(32, ref pAddress))
            {
                return false;
            }
            var paramType5 = parameters[5].ParameterType;
            if (!paramType5.IsValidInput<TArg5>(64, ref pAddress))
            {
                return false;
            }
            var paramType6 = parameters[6].ParameterType;
            if (!paramType6.IsValidInput<TArg6>(128, ref pAddress))
            {
                return false;
            }
            var paramType7 = parameters[7].ParameterType;
            if (!paramType7.IsValidInput<TArg7>(256, ref pAddress))
            {
                return false;
            }
            var paramType8 = parameters[8].ParameterType;
            if (!paramType8.IsValidInput<TArg8>(512, ref pAddress))
            {
                return false;
            }
            if (pAddress != 0)
            {
                return false;
            }
            pAddress = method.GetFunctionPointer();
            return true;
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool SecondaryValidateInstanceMethodRaw(MethodBase method, Type target, Type arg0, Type arg1, Type arg2, Type arg3, Type arg4, Type arg5, Type arg6, Type arg7, Type arg8, ref nint pAddress)
        {
            if ((pAddress & 1) != 0)
            {
                var reflectedType = method.ReflectedType;
                if (!reflectedType.IsNullAssignableFromFast(target))
                {
                    return false;
                }
            }
            var parameters = method.GetParametersFast();
            if ((pAddress & 2) != 0)
            {
                var paramType = parameters[0].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg0))
                {
                    return false;
                }
            }
            if ((pAddress & 4) != 0)
            {
                var paramType = parameters[1].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg1))
                {
                    return false;
                }
            }
            if ((pAddress & 8) != 0)
            {
                var paramType = parameters[2].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg2))
                {
                    return false;
                }
            }
            if ((pAddress & 16) != 0)
            {
                var paramType = parameters[3].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg3))
                {
                    return false;
                }
            }
            if ((pAddress & 32) != 0)
            {
                var paramType = parameters[4].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg4))
                {
                    return false;
                }
            }
            if ((pAddress & 64) != 0)
            {
                var paramType = parameters[5].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg5))
                {
                    return false;
                }
            }
            if ((pAddress & 128) != 0)
            {
                var paramType = parameters[6].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg6))
                {
                    return false;
                }
            }
            if ((pAddress & 256) != 0)
            {
                var paramType = parameters[7].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg7))
                {
                    return false;
                }
            }
            if ((pAddress & 512) != 0)
            {
                var paramType = parameters[8].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg8))
                {
                    return false;
                }
            }
            pAddress = method.GetFunctionPointer();
            return true;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void InvokeStaticFast<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(this MethodBase self, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8)
        {
            bool isValid;
            nint pAddress;
            isValid = ValidateStaticMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(self, out pAddress) ||
                      (pAddress != 0 && SecondaryValidateStaticMethod(self, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), ref pAddress));
            if (!isValid)
            {
                self.InvokeStaticLowAlloc(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
                return;
            }
            unsafe
            {
                ((delegate*<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, void>)pAddress)(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
                return;
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static object InvokeStaticLowAlloc<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(this MethodBase self, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8)
        {
            if (self.IsGenericMethodDefinition)
            {
                ValidateGenericMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(ref self);
            }
            var parameters = self.GetParametersFast();
            ArrayCache.Objects9[0] = REReflection.GetBox(arg0, parameters[0], out var refArg0);
            ArrayCache.Objects9[1] = REReflection.GetBox(arg1, parameters[1], out var refArg1);
            ArrayCache.Objects9[2] = REReflection.GetBox(arg2, parameters[2], out var refArg2);
            ArrayCache.Objects9[3] = REReflection.GetBox(arg3, parameters[3], out var refArg3);
            ArrayCache.Objects9[4] = REReflection.GetBox(arg4, parameters[4], out var refArg4);
            ArrayCache.Objects9[5] = REReflection.GetBox(arg5, parameters[5], out var refArg5);
            ArrayCache.Objects9[6] = REReflection.GetBox(arg6, parameters[6], out var refArg6);
            ArrayCache.Objects9[7] = REReflection.GetBox(arg7, parameters[7], out var refArg7);
            ArrayCache.Objects9[8] = REReflection.GetBox(arg8, parameters[8], out var refArg8);
            try
            {
                return self.Invoke(null, ArrayCache.Objects9);
            }
            finally
            {
                REReflection.ReturnBox<TArg0>(ArrayCache.Objects9[0], parameters[0], refArg0);
                REReflection.ReturnBox<TArg1>(ArrayCache.Objects9[1], parameters[1], refArg1);
                REReflection.ReturnBox<TArg2>(ArrayCache.Objects9[2], parameters[2], refArg2);
                REReflection.ReturnBox<TArg3>(ArrayCache.Objects9[3], parameters[3], refArg3);
                REReflection.ReturnBox<TArg4>(ArrayCache.Objects9[4], parameters[4], refArg4);
                REReflection.ReturnBox<TArg5>(ArrayCache.Objects9[5], parameters[5], refArg5);
                REReflection.ReturnBox<TArg6>(ArrayCache.Objects9[6], parameters[6], refArg6);
                REReflection.ReturnBox<TArg7>(ArrayCache.Objects9[7], parameters[7], refArg7);
                REReflection.ReturnBox<TArg8>(ArrayCache.Objects9[8], parameters[8], refArg8);
            }
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool ValidateStaticMethodRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(MethodBase method, out nint pAddress)
        {
            pAddress = 0;
            if (!method.IsStatic)
            {
                return false;
            }
            if (method.IsOverridable())
            {
                return false;
            }
            var isValidGeneric = !method.IsGenericMethodDefinition || ValidateGenericMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(ref method);
            if (!isValidGeneric)
            {
                return false;
            }
            var parameters = method.GetParametersFast();
            var parameterLength = parameters.Count;
            if (parameterLength != 9)
            {
                return false;
            }
            if (method is MethodInfo mi)
            {
                var returnType = mi?.ReturnType ?? typeof(void);
                if (returnType != typeof(void))
                {
                    return false;
                }
            }
            var paramType0 = parameters[0].ParameterType;
            if (!paramType0.IsValidInput<TArg0>(2, ref pAddress))
            {
                return false;
            }
            var paramType1 = parameters[1].ParameterType;
            if (!paramType1.IsValidInput<TArg1>(4, ref pAddress))
            {
                return false;
            }
            var paramType2 = parameters[2].ParameterType;
            if (!paramType2.IsValidInput<TArg2>(8, ref pAddress))
            {
                return false;
            }
            var paramType3 = parameters[3].ParameterType;
            if (!paramType3.IsValidInput<TArg3>(16, ref pAddress))
            {
                return false;
            }
            var paramType4 = parameters[4].ParameterType;
            if (!paramType4.IsValidInput<TArg4>(32, ref pAddress))
            {
                return false;
            }
            var paramType5 = parameters[5].ParameterType;
            if (!paramType5.IsValidInput<TArg5>(64, ref pAddress))
            {
                return false;
            }
            var paramType6 = parameters[6].ParameterType;
            if (!paramType6.IsValidInput<TArg6>(128, ref pAddress))
            {
                return false;
            }
            var paramType7 = parameters[7].ParameterType;
            if (!paramType7.IsValidInput<TArg7>(256, ref pAddress))
            {
                return false;
            }
            var paramType8 = parameters[8].ParameterType;
            if (!paramType8.IsValidInput<TArg8>(512, ref pAddress))
            {
                return false;
            }
            if (pAddress != 0)
            {
                return false;
            }
            pAddress = method.GetFunctionPointer();
            return true;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TReturn InvokeStaticFast<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TReturn>(this MethodBase self, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8)
        {
            bool isValid;
            nint pAddress;
            isValid = ValidateStaticReturnableMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TReturn>(self, out pAddress) ||
                      (pAddress != 0 && SecondaryValidateStaticMethod(self, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), ref pAddress));
            if (!isValid)
            {
                return (TReturn)self.InvokeStaticLowAlloc(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
            }
            unsafe
            {
                return ((delegate*<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TReturn>)pAddress)(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
            }
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool ValidateStaticReturnableMethodRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TReturn>(MethodBase method, out nint pAddress)
        {
            pAddress = 0;
            if (!method.IsStatic)
            {
                return false;
            }
            if (method.IsOverridable())
            {
                return false;
            }
            var isValidGeneric = !method.IsGenericMethodDefinition || ValidateGenericReturnableMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TReturn>(ref method);
            if (!isValidGeneric)
            {
                return false;
            }
            var parameters = method.GetParametersFast();
            var parameterLength = parameters.Count;
            if (parameterLength != 9)
            {
                return false;
            }
            if (method is MethodInfo mi)
            {
                var returnType = mi?.ReturnType ?? typeof(void);
                if (!returnType.IsValidOutput<TReturn>())
                {
                    return false;
                }
            }
            var paramType0 = parameters[0].ParameterType;
            if (!paramType0.IsValidInput<TArg0>(2, ref pAddress))
            {
                return false;
            }
            var paramType1 = parameters[1].ParameterType;
            if (!paramType1.IsValidInput<TArg1>(4, ref pAddress))
            {
                return false;
            }
            var paramType2 = parameters[2].ParameterType;
            if (!paramType2.IsValidInput<TArg2>(8, ref pAddress))
            {
                return false;
            }
            var paramType3 = parameters[3].ParameterType;
            if (!paramType3.IsValidInput<TArg3>(16, ref pAddress))
            {
                return false;
            }
            var paramType4 = parameters[4].ParameterType;
            if (!paramType4.IsValidInput<TArg4>(32, ref pAddress))
            {
                return false;
            }
            var paramType5 = parameters[5].ParameterType;
            if (!paramType5.IsValidInput<TArg5>(64, ref pAddress))
            {
                return false;
            }
            var paramType6 = parameters[6].ParameterType;
            if (!paramType6.IsValidInput<TArg6>(128, ref pAddress))
            {
                return false;
            }
            var paramType7 = parameters[7].ParameterType;
            if (!paramType7.IsValidInput<TArg7>(256, ref pAddress))
            {
                return false;
            }
            var paramType8 = parameters[8].ParameterType;
            if (!paramType8.IsValidInput<TArg8>(512, ref pAddress))
            {
                return false;
            }
            if (pAddress != 0)
            {
                return false;
            }
            pAddress = method.GetFunctionPointer();
            return true;
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool SecondaryValidateStaticMethodRaw(MethodBase method, Type arg0, Type arg1, Type arg2, Type arg3, Type arg4, Type arg5, Type arg6, Type arg7, Type arg8, ref nint pAddress)
        {
            var parameters = method.GetParametersFast();
            if ((pAddress & 2) != 0)
            {
                var paramType = parameters[0].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg0))
                {
                    return false;
                }
            }
            if ((pAddress & 4) != 0)
            {
                var paramType = parameters[1].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg1))
                {
                    return false;
                }
            }
            if ((pAddress & 8) != 0)
            {
                var paramType = parameters[2].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg2))
                {
                    return false;
                }
            }
            if ((pAddress & 16) != 0)
            {
                var paramType = parameters[3].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg3))
                {
                    return false;
                }
            }
            if ((pAddress & 32) != 0)
            {
                var paramType = parameters[4].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg4))
                {
                    return false;
                }
            }
            if ((pAddress & 64) != 0)
            {
                var paramType = parameters[5].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg5))
                {
                    return false;
                }
            }
            if ((pAddress & 128) != 0)
            {
                var paramType = parameters[6].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg6))
                {
                    return false;
                }
            }
            if ((pAddress & 256) != 0)
            {
                var paramType = parameters[7].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg7))
                {
                    return false;
                }
            }
            if ((pAddress & 512) != 0)
            {
                var paramType = parameters[8].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg8))
                {
                    return false;
                }
            }
            pAddress = method.GetFunctionPointer();
            return true;
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool ValidateGenericMethodRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(ref MethodBase method)
        {
            if (!method.IsGenericMethodDefinition)
            {
                return true;
            }
            var genericArguments = method.GetGenericArgumentsFast();
            if (genericArguments.Count < 9)
            {
                return false;
            }
            uint mask = 0;
            var mi = method as MethodInfo;
            var parameters = method.GetParametersFast();
            var index0 = IndexOf(genericArguments, parameters[0].ParameterType);
            if (index0 >= 0)
            {
                mask |= 1u << index0;
            }
            var index1 = IndexOf(genericArguments, parameters[1].ParameterType);
            if (index1 >= 0)
            {
                mask |= 1u << index1;
            }
            var index2 = IndexOf(genericArguments, parameters[2].ParameterType);
            if (index2 >= 0)
            {
                mask |= 1u << index2;
            }
            var index3 = IndexOf(genericArguments, parameters[3].ParameterType);
            if (index3 >= 0)
            {
                mask |= 1u << index3;
            }
            var index4 = IndexOf(genericArguments, parameters[4].ParameterType);
            if (index4 >= 0)
            {
                mask |= 1u << index4;
            }
            var index5 = IndexOf(genericArguments, parameters[5].ParameterType);
            if (index5 >= 0)
            {
                mask |= 1u << index5;
            }
            var index6 = IndexOf(genericArguments, parameters[6].ParameterType);
            if (index6 >= 0)
            {
                mask |= 1u << index6;
            }
            var index7 = IndexOf(genericArguments, parameters[7].ParameterType);
            if (index7 >= 0)
            {
                mask |= 1u << index7;
            }
            var index8 = IndexOf(genericArguments, parameters[8].ParameterType);
            if (index8 >= 0)
            {
                mask |= 1u << index8;
            }
            if (REReflection.BitCount(mask) != genericArguments.Count)
            {
                return false;
            }
            var types = ArrayCache.GetArrayCache<Type>(genericArguments.Count);
            if (index0 >= 0)
            {
                types[index0] = typeof(TArg0);
            }
            if (index1 >= 0)
            {
                types[index1] = typeof(TArg1);
            }
            if (index2 >= 0)
            {
                types[index2] = typeof(TArg2);
            }
            if (index3 >= 0)
            {
                types[index3] = typeof(TArg3);
            }
            if (index4 >= 0)
            {
                types[index4] = typeof(TArg4);
            }
            if (index5 >= 0)
            {
                types[index5] = typeof(TArg5);
            }
            if (index6 >= 0)
            {
                types[index6] = typeof(TArg6);
            }
            if (index7 >= 0)
            {
                types[index7] = typeof(TArg7);
            }
            if (index8 >= 0)
            {
                types[index8] = typeof(TArg8);
            }
            #if ENABLE_IL2CPP
            bool isFound = false;
            var usingMethods = method.GetUsingGenericInstanceMethods();
            foreach (var usingMethod in usingMethods)
            {
                if (usingMethod.GetGenericArgumentsFast().SequenceEqual(types))
                {
                    isFound = true;
                    break;
                }
            }
            if (!isFound)
            {
                return false;
            }
            #endif
            method = mi.MakeGenericMethodFast(types);
            return true;
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool ValidateGenericReturnableMethodRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TReturn>(ref MethodBase method)
        {
            if (!method.IsGenericMethodDefinition)
            {
                return true;
            }
            var genericArguments = method.GetGenericArgumentsFast();
            if (genericArguments.Count < 10)
            {
                return false;
            }
            uint mask = 0;
            var mi = method as MethodInfo;
            var returnType = mi.ReturnType ?? typeof(void);
            var index = IndexOf(genericArguments, returnType);
            if (index >= 0)
            {
                mask |= 1u << index;
            }
            var parameters = method.GetParametersFast();
            var index0 = IndexOf(genericArguments, parameters[0].ParameterType);
            if (index0 >= 0)
            {
                mask |= 1u << index0;
            }
            var index1 = IndexOf(genericArguments, parameters[1].ParameterType);
            if (index1 >= 0)
            {
                mask |= 1u << index1;
            }
            var index2 = IndexOf(genericArguments, parameters[2].ParameterType);
            if (index2 >= 0)
            {
                mask |= 1u << index2;
            }
            var index3 = IndexOf(genericArguments, parameters[3].ParameterType);
            if (index3 >= 0)
            {
                mask |= 1u << index3;
            }
            var index4 = IndexOf(genericArguments, parameters[4].ParameterType);
            if (index4 >= 0)
            {
                mask |= 1u << index4;
            }
            var index5 = IndexOf(genericArguments, parameters[5].ParameterType);
            if (index5 >= 0)
            {
                mask |= 1u << index5;
            }
            var index6 = IndexOf(genericArguments, parameters[6].ParameterType);
            if (index6 >= 0)
            {
                mask |= 1u << index6;
            }
            var index7 = IndexOf(genericArguments, parameters[7].ParameterType);
            if (index7 >= 0)
            {
                mask |= 1u << index7;
            }
            var index8 = IndexOf(genericArguments, parameters[8].ParameterType);
            if (index8 >= 0)
            {
                mask |= 1u << index8;
            }
            if (REReflection.BitCount(mask) != genericArguments.Count)
            {
                return false;
            }
            var types = ArrayCache.GetArrayCache<Type>(genericArguments.Count);
            if (index >= 0)
            {
                types[index] = typeof(TReturn);
            }
            if (index0 >= 0)
            {
                types[index0] = typeof(TArg0);
            }
            if (index1 >= 0)
            {
                types[index1] = typeof(TArg1);
            }
            if (index2 >= 0)
            {
                types[index2] = typeof(TArg2);
            }
            if (index3 >= 0)
            {
                types[index3] = typeof(TArg3);
            }
            if (index4 >= 0)
            {
                types[index4] = typeof(TArg4);
            }
            if (index5 >= 0)
            {
                types[index5] = typeof(TArg5);
            }
            if (index6 >= 0)
            {
                types[index6] = typeof(TArg6);
            }
            if (index7 >= 0)
            {
                types[index7] = typeof(TArg7);
            }
            if (index8 >= 0)
            {
                types[index8] = typeof(TArg8);
            }
            #if ENABLE_IL2CPP
            bool isFound = false;
            var usingMethods = method.GetUsingGenericInstanceMethods();
            foreach (var usingMethod in usingMethods)
            {
                if (usingMethod.GetGenericArgumentsFast().SequenceEqual(types))
                {
                    isFound = true;
                    break;
                }
            }
            if (!isFound)
            {
                return false;
            }
            #endif
            method = mi.MakeGenericMethodFast(types);
            return true;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void InvokeInstanceFast<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(this MethodBase self, ref TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9)
        {
            bool isValid;
            nint pAddress;
            if (self.IsOverridable())
            {
                isValid = ValidateInstanceVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(self, target?.GetType(), out pAddress) ||
                          (pAddress != 0 && SecondaryValidateStaticMethod(self, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), ref pAddress));
            }
            else
            {
                isValid = ValidateInstanceMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(self, out pAddress) ||
                          (pAddress != 0 && SecondaryValidateInstanceMethod(self, target?.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), ref pAddress));
            }
            if (!isValid)
            {
                self.InvokeInstanceLowAlloc(ref target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
                return;
            }
            unsafe
            {
                if (REType.IsValueTypeFast<TTarget>())
                {
                    ((delegate*<ref TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, void>)pAddress)(ref target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
                    return;
                }
                ((delegate*<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, void>)pAddress)(target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
                return;
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void InvokeClassInstanceFast<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(this MethodBase self, TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9)
        where TTarget: class
        {
            bool isValid;
            nint pAddress;
            if (self.IsOverridable())
            {
                isValid = ValidateInstanceVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(self, target?.GetType(), out pAddress) ||
                          (pAddress != 0 && SecondaryValidateStaticMethod(self, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), ref pAddress));
            }
            else
            {
                isValid = ValidateInstanceMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(self, out pAddress) ||
                          (pAddress != 0 && SecondaryValidateInstanceMethod(self, target?.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), ref pAddress));
            }
            if (!isValid)
            {
                self.InvokeClassInstanceLowAlloc(target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
                return;
            }
            unsafe
            {
                ((delegate*<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, void>)pAddress)(target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
                return;
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void InvokeStructInstanceFast<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(this MethodBase self, ref TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9)
        where TTarget: struct
        {
            bool isValid;
            nint pAddress;
            if (self.IsOverridable())
            {
                isValid = ValidateInstanceVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(self, target.GetType(), out pAddress) ||
                          (pAddress != 0 && SecondaryValidateStaticMethod(self, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), ref pAddress));
            }
            else
            {
                isValid = ValidateInstanceMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(self, out pAddress) ||
                          (pAddress != 0 && SecondaryValidateInstanceMethod(self, target.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), ref pAddress));
            }
            if (!isValid)
            {
                self.InvokeInstanceLowAlloc(ref target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
                return;
            }
            unsafe
            {
                ((delegate*<ref TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, void>)pAddress)(ref target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
                return;
            }
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool ValidateInstanceMethodRaw<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(MethodBase method, out nint pAddress)
        {
            pAddress = 0;
            if (method.IsStatic)
            {
                return false;
            }
            if (method.IsOverridable())
            {
                return false;
            }
            var isValidGeneric = !method.IsGenericMethodDefinition || ValidateGenericMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(ref method);
            if (!isValidGeneric)
            {
                return false;
            }
            var parameters = method.GetParametersFast();
            var parameterLength = parameters.Count;
            if (parameterLength != 10)
            {
                return false;
            }
            if (method is MethodInfo mi)
            {
                var returnType = mi?.ReturnType ?? typeof(void);
                if (returnType != typeof(void))
                {
                    return false;
                }
            }
            var reflectedType = method.ReflectedType;
            if (!reflectedType.IsValidInputWithoutRef<TTarget>(1, ref pAddress))
            {
                return false;
            }
            var paramType0 = parameters[0].ParameterType;
            if (!paramType0.IsValidInput<TArg0>(2, ref pAddress))
            {
                return false;
            }
            var paramType1 = parameters[1].ParameterType;
            if (!paramType1.IsValidInput<TArg1>(4, ref pAddress))
            {
                return false;
            }
            var paramType2 = parameters[2].ParameterType;
            if (!paramType2.IsValidInput<TArg2>(8, ref pAddress))
            {
                return false;
            }
            var paramType3 = parameters[3].ParameterType;
            if (!paramType3.IsValidInput<TArg3>(16, ref pAddress))
            {
                return false;
            }
            var paramType4 = parameters[4].ParameterType;
            if (!paramType4.IsValidInput<TArg4>(32, ref pAddress))
            {
                return false;
            }
            var paramType5 = parameters[5].ParameterType;
            if (!paramType5.IsValidInput<TArg5>(64, ref pAddress))
            {
                return false;
            }
            var paramType6 = parameters[6].ParameterType;
            if (!paramType6.IsValidInput<TArg6>(128, ref pAddress))
            {
                return false;
            }
            var paramType7 = parameters[7].ParameterType;
            if (!paramType7.IsValidInput<TArg7>(256, ref pAddress))
            {
                return false;
            }
            var paramType8 = parameters[8].ParameterType;
            if (!paramType8.IsValidInput<TArg8>(512, ref pAddress))
            {
                return false;
            }
            var paramType9 = parameters[9].ParameterType;
            if (!paramType9.IsValidInput<TArg9>(1024, ref pAddress))
            {
                return false;
            }
            if (pAddress != 0)
            {
                return false;
            }
            pAddress = method.GetFunctionPointer();
            return true;
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool ValidateInstanceVirtualMethodRaw<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(MethodBase method, Type targetType, out nint pAddress)
        {
            pAddress = 0;
            if (method.IsStatic)
            {
                return false;
            }
            if (!method.IsOverridable())
            {
                return false;
            }
            var isValidGeneric = !method.IsGenericMethodDefinition || ValidateGenericMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(ref method);
            if (!isValidGeneric)
            {
                return false;
            }
            var parameters = method.GetParametersFast();
            var parameterLength = parameters.Count;
            if (parameterLength != 10)
            {
                return false;
            }
            if (method is MethodInfo mi)
            {
                var returnType = mi?.ReturnType ?? typeof(void);
                if (returnType != typeof(void))
                {
                    return false;
                }
            }
            var reflectedType = method.ReflectedType;
            if (!reflectedType.IsValidVirtualInput<TTarget>(targetType, out var isVirtualCall))
            {
                return false;
            }
            if (isVirtualCall)
            {
                ArrayCache.Types10[0] = parameters[0].ParameterType;
                ArrayCache.Types10[1] = parameters[1].ParameterType;
                ArrayCache.Types10[2] = parameters[2].ParameterType;
                ArrayCache.Types10[3] = parameters[3].ParameterType;
                ArrayCache.Types10[4] = parameters[4].ParameterType;
                ArrayCache.Types10[5] = parameters[5].ParameterType;
                ArrayCache.Types10[6] = parameters[6].ParameterType;
                ArrayCache.Types10[7] = parameters[7].ParameterType;
                ArrayCache.Types10[8] = parameters[8].ParameterType;
                ArrayCache.Types10[9] = parameters[9].ParameterType;
                method = targetType.GetInstanceMethodFullAccess(method.Name, null, ArrayCache.Types10, null);
            }
            var paramType0 = parameters[0].ParameterType;
            if (!paramType0.IsValidInput<TArg0>(2, ref pAddress))
            {
                return false;
            }
            var paramType1 = parameters[1].ParameterType;
            if (!paramType1.IsValidInput<TArg1>(4, ref pAddress))
            {
                return false;
            }
            var paramType2 = parameters[2].ParameterType;
            if (!paramType2.IsValidInput<TArg2>(8, ref pAddress))
            {
                return false;
            }
            var paramType3 = parameters[3].ParameterType;
            if (!paramType3.IsValidInput<TArg3>(16, ref pAddress))
            {
                return false;
            }
            var paramType4 = parameters[4].ParameterType;
            if (!paramType4.IsValidInput<TArg4>(32, ref pAddress))
            {
                return false;
            }
            var paramType5 = parameters[5].ParameterType;
            if (!paramType5.IsValidInput<TArg5>(64, ref pAddress))
            {
                return false;
            }
            var paramType6 = parameters[6].ParameterType;
            if (!paramType6.IsValidInput<TArg6>(128, ref pAddress))
            {
                return false;
            }
            var paramType7 = parameters[7].ParameterType;
            if (!paramType7.IsValidInput<TArg7>(256, ref pAddress))
            {
                return false;
            }
            var paramType8 = parameters[8].ParameterType;
            if (!paramType8.IsValidInput<TArg8>(512, ref pAddress))
            {
                return false;
            }
            var paramType9 = parameters[9].ParameterType;
            if (!paramType9.IsValidInput<TArg9>(1024, ref pAddress))
            {
                return false;
            }
            if (pAddress != 0)
            {
                return false;
            }
            pAddress = method.GetFunctionPointer();
            return true;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TReturn InvokeInstanceFast<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TReturn>(this MethodBase self, ref TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9)
        {
            bool isValid;
            nint pAddress;
            if (self.IsOverridable())
            {
                isValid = ValidateInstanceReturnableVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TReturn>(self, target?.GetType(), out pAddress) ||
                          (pAddress != 0 && SecondaryValidateStaticMethod(self, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), ref pAddress));
            }
            else
            {
                isValid = ValidateInstanceReturnableMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TReturn>(self, out pAddress) ||
                          (pAddress != 0 && SecondaryValidateInstanceMethod(self, target?.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), ref pAddress));
            }
            if (!isValid)
            {
                return (TReturn)self.InvokeInstanceLowAlloc(ref target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
            }
            unsafe
            {
                if (REType.IsValueTypeFast<TTarget>())
                {
                    return ((delegate*<ref TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TReturn>)pAddress)(ref target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
                }
                return ((delegate*<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TReturn>)pAddress)(target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TReturn InvokeClassInstanceFast<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TReturn>(this MethodBase self, TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9)
        where TTarget: class
        {
            bool isValid;
            nint pAddress;
            if (self.IsOverridable())
            {
                isValid = ValidateInstanceReturnableVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TReturn>(self, target?.GetType(), out pAddress) ||
                          (pAddress != 0 && SecondaryValidateStaticMethod(self, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), ref pAddress));
            }
            else
            {
                isValid = ValidateInstanceReturnableMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TReturn>(self, out pAddress) ||
                          (pAddress != 0 && SecondaryValidateInstanceMethod(self, target?.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), ref pAddress));
            }
            if (!isValid)
            {
                return (TReturn)self.InvokeClassInstanceLowAlloc(target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
            }
            unsafe
            {
                return ((delegate*<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TReturn>)pAddress)(target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TReturn InvokeStructInstanceFast<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TReturn>(this MethodBase self, ref TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9)
        where TTarget: struct
        {
            bool isValid;
            nint pAddress;
            if (self.IsOverridable())
            {
                isValid = ValidateInstanceReturnableVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TReturn>(self, target.GetType(), out pAddress) ||
                          (pAddress != 0 && SecondaryValidateStaticMethod(self, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), ref pAddress));
            }
            else
            {
                isValid = ValidateInstanceReturnableMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TReturn>(self, out pAddress) ||
                          (pAddress != 0 && SecondaryValidateInstanceMethod(self, target.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), ref pAddress));
            }
            if (!isValid)
            {
                return (TReturn)self.InvokeInstanceLowAlloc(ref target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
            }
            unsafe
            {
                return ((delegate*<ref TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TReturn>)pAddress)(ref target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static object InvokeInstanceLowAlloc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(this MethodBase self, ref TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9)
        {
            if (self.IsGenericMethodDefinition)
            {
                ValidateGenericMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(ref self);
            }
            var targetObj = REReflection.GetBoxWithoutRef(target);
            var parameters = self.GetParametersFast();
            ArrayCache.Objects10[0] = REReflection.GetBox(arg0, parameters[0], out var refArg0);
            ArrayCache.Objects10[1] = REReflection.GetBox(arg1, parameters[1], out var refArg1);
            ArrayCache.Objects10[2] = REReflection.GetBox(arg2, parameters[2], out var refArg2);
            ArrayCache.Objects10[3] = REReflection.GetBox(arg3, parameters[3], out var refArg3);
            ArrayCache.Objects10[4] = REReflection.GetBox(arg4, parameters[4], out var refArg4);
            ArrayCache.Objects10[5] = REReflection.GetBox(arg5, parameters[5], out var refArg5);
            ArrayCache.Objects10[6] = REReflection.GetBox(arg6, parameters[6], out var refArg6);
            ArrayCache.Objects10[7] = REReflection.GetBox(arg7, parameters[7], out var refArg7);
            ArrayCache.Objects10[8] = REReflection.GetBox(arg8, parameters[8], out var refArg8);
            ArrayCache.Objects10[9] = REReflection.GetBox(arg9, parameters[9], out var refArg9);
            try
            {
                return self.Invoke(targetObj, ArrayCache.Objects10);
            }
            finally
            {
                REReflection.Unbox(targetObj, out target);
                REReflection.ReturnBoxWithoutRef<TTarget>(targetObj);
                REReflection.ReturnBox<TArg0>(ArrayCache.Objects10[0], parameters[0], refArg0);
                REReflection.ReturnBox<TArg1>(ArrayCache.Objects10[1], parameters[1], refArg1);
                REReflection.ReturnBox<TArg2>(ArrayCache.Objects10[2], parameters[2], refArg2);
                REReflection.ReturnBox<TArg3>(ArrayCache.Objects10[3], parameters[3], refArg3);
                REReflection.ReturnBox<TArg4>(ArrayCache.Objects10[4], parameters[4], refArg4);
                REReflection.ReturnBox<TArg5>(ArrayCache.Objects10[5], parameters[5], refArg5);
                REReflection.ReturnBox<TArg6>(ArrayCache.Objects10[6], parameters[6], refArg6);
                REReflection.ReturnBox<TArg7>(ArrayCache.Objects10[7], parameters[7], refArg7);
                REReflection.ReturnBox<TArg8>(ArrayCache.Objects10[8], parameters[8], refArg8);
                REReflection.ReturnBox<TArg9>(ArrayCache.Objects10[9], parameters[9], refArg9);
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static object InvokeClassInstanceLowAlloc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(this MethodBase self, TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9)
        where TTarget: class
        {
            if (self.IsGenericMethodDefinition)
            {
                ValidateGenericMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(ref self);
            }
            var parameters = self.GetParametersFast();
            ArrayCache.Objects10[0] = REReflection.GetBox(arg0, parameters[0], out var refArg0);
            ArrayCache.Objects10[1] = REReflection.GetBox(arg1, parameters[1], out var refArg1);
            ArrayCache.Objects10[2] = REReflection.GetBox(arg2, parameters[2], out var refArg2);
            ArrayCache.Objects10[3] = REReflection.GetBox(arg3, parameters[3], out var refArg3);
            ArrayCache.Objects10[4] = REReflection.GetBox(arg4, parameters[4], out var refArg4);
            ArrayCache.Objects10[5] = REReflection.GetBox(arg5, parameters[5], out var refArg5);
            ArrayCache.Objects10[6] = REReflection.GetBox(arg6, parameters[6], out var refArg6);
            ArrayCache.Objects10[7] = REReflection.GetBox(arg7, parameters[7], out var refArg7);
            ArrayCache.Objects10[8] = REReflection.GetBox(arg8, parameters[8], out var refArg8);
            ArrayCache.Objects10[9] = REReflection.GetBox(arg9, parameters[9], out var refArg9);
            try
            {
                return self.Invoke(target, ArrayCache.Objects10);
            }
            finally
            {
                REReflection.ReturnBox<TArg0>(ArrayCache.Objects10[0], parameters[0], refArg0);
                REReflection.ReturnBox<TArg1>(ArrayCache.Objects10[1], parameters[1], refArg1);
                REReflection.ReturnBox<TArg2>(ArrayCache.Objects10[2], parameters[2], refArg2);
                REReflection.ReturnBox<TArg3>(ArrayCache.Objects10[3], parameters[3], refArg3);
                REReflection.ReturnBox<TArg4>(ArrayCache.Objects10[4], parameters[4], refArg4);
                REReflection.ReturnBox<TArg5>(ArrayCache.Objects10[5], parameters[5], refArg5);
                REReflection.ReturnBox<TArg6>(ArrayCache.Objects10[6], parameters[6], refArg6);
                REReflection.ReturnBox<TArg7>(ArrayCache.Objects10[7], parameters[7], refArg7);
                REReflection.ReturnBox<TArg8>(ArrayCache.Objects10[8], parameters[8], refArg8);
                REReflection.ReturnBox<TArg9>(ArrayCache.Objects10[9], parameters[9], refArg9);
            }
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool ValidateInstanceReturnableMethodRaw<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TReturn>(MethodBase method, out nint pAddress)
        {
            pAddress = 0;
            if (method.IsStatic)
            {
                return false;
            }
            if (method.IsOverridable())
            {
                return false;
            }
            var isValidGeneric = !method.IsGenericMethodDefinition || ValidateGenericReturnableMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TReturn>(ref method);
            if (!isValidGeneric)
            {
                return false;
            }
            var parameters = method.GetParametersFast();
            var parameterLength = parameters.Count;
            if (parameterLength != 10)
            {
                return false;
            }
            if (method is MethodInfo mi)
            {
                var returnType = mi?.ReturnType ?? typeof(void);
                if (!returnType.IsValidOutput<TReturn>())
                {
                    return false;
                }
            }
            var reflectedType = method.ReflectedType;
            if (!reflectedType.IsValidInputWithoutRef<TTarget>(1, ref pAddress))
            {
                return false;
            }
            var paramType0 = parameters[0].ParameterType;
            if (!paramType0.IsValidInput<TArg0>(2, ref pAddress))
            {
                return false;
            }
            var paramType1 = parameters[1].ParameterType;
            if (!paramType1.IsValidInput<TArg1>(4, ref pAddress))
            {
                return false;
            }
            var paramType2 = parameters[2].ParameterType;
            if (!paramType2.IsValidInput<TArg2>(8, ref pAddress))
            {
                return false;
            }
            var paramType3 = parameters[3].ParameterType;
            if (!paramType3.IsValidInput<TArg3>(16, ref pAddress))
            {
                return false;
            }
            var paramType4 = parameters[4].ParameterType;
            if (!paramType4.IsValidInput<TArg4>(32, ref pAddress))
            {
                return false;
            }
            var paramType5 = parameters[5].ParameterType;
            if (!paramType5.IsValidInput<TArg5>(64, ref pAddress))
            {
                return false;
            }
            var paramType6 = parameters[6].ParameterType;
            if (!paramType6.IsValidInput<TArg6>(128, ref pAddress))
            {
                return false;
            }
            var paramType7 = parameters[7].ParameterType;
            if (!paramType7.IsValidInput<TArg7>(256, ref pAddress))
            {
                return false;
            }
            var paramType8 = parameters[8].ParameterType;
            if (!paramType8.IsValidInput<TArg8>(512, ref pAddress))
            {
                return false;
            }
            var paramType9 = parameters[9].ParameterType;
            if (!paramType9.IsValidInput<TArg9>(1024, ref pAddress))
            {
                return false;
            }
            if (pAddress != 0)
            {
                return false;
            }
            pAddress = method.GetFunctionPointer();
            return true;
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool ValidateInstanceReturnableVirtualMethodRaw<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TReturn>(MethodBase method, Type targetType, out nint pAddress)
        {
            pAddress = 0;
            if (method.IsStatic)
            {
                return false;
            }
            if (!method.IsOverridable())
            {
                return false;
            }
            var isValidGeneric = !method.IsGenericMethodDefinition || ValidateGenericReturnableMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TReturn>(ref method);
            if (!isValidGeneric)
            {
                return false;
            }
            var parameters = method.GetParametersFast();
            var parameterLength = parameters.Count;
            if (parameterLength != 10)
            {
                return false;
            }
            if (method is MethodInfo mi)
            {
                var returnType = mi?.ReturnType ?? typeof(void);
                if (!returnType.IsValidOutput<TReturn>())
                {
                    return false;
                }
            }
            var reflectedType = method.ReflectedType;
            if (!reflectedType.IsValidVirtualInput<TTarget>(targetType, out var isVirtualCall))
            {
                return false;
            }
            if (isVirtualCall)
            {
                ArrayCache.Types10[0] = parameters[0].ParameterType;
                ArrayCache.Types10[1] = parameters[1].ParameterType;
                ArrayCache.Types10[2] = parameters[2].ParameterType;
                ArrayCache.Types10[3] = parameters[3].ParameterType;
                ArrayCache.Types10[4] = parameters[4].ParameterType;
                ArrayCache.Types10[5] = parameters[5].ParameterType;
                ArrayCache.Types10[6] = parameters[6].ParameterType;
                ArrayCache.Types10[7] = parameters[7].ParameterType;
                ArrayCache.Types10[8] = parameters[8].ParameterType;
                ArrayCache.Types10[9] = parameters[9].ParameterType;
                method = targetType.GetInstanceMethodFullAccess(method.Name, null, ArrayCache.Types10, null);
            }
            var paramType0 = parameters[0].ParameterType;
            if (!paramType0.IsValidInput<TArg0>(2, ref pAddress))
            {
                return false;
            }
            var paramType1 = parameters[1].ParameterType;
            if (!paramType1.IsValidInput<TArg1>(4, ref pAddress))
            {
                return false;
            }
            var paramType2 = parameters[2].ParameterType;
            if (!paramType2.IsValidInput<TArg2>(8, ref pAddress))
            {
                return false;
            }
            var paramType3 = parameters[3].ParameterType;
            if (!paramType3.IsValidInput<TArg3>(16, ref pAddress))
            {
                return false;
            }
            var paramType4 = parameters[4].ParameterType;
            if (!paramType4.IsValidInput<TArg4>(32, ref pAddress))
            {
                return false;
            }
            var paramType5 = parameters[5].ParameterType;
            if (!paramType5.IsValidInput<TArg5>(64, ref pAddress))
            {
                return false;
            }
            var paramType6 = parameters[6].ParameterType;
            if (!paramType6.IsValidInput<TArg6>(128, ref pAddress))
            {
                return false;
            }
            var paramType7 = parameters[7].ParameterType;
            if (!paramType7.IsValidInput<TArg7>(256, ref pAddress))
            {
                return false;
            }
            var paramType8 = parameters[8].ParameterType;
            if (!paramType8.IsValidInput<TArg8>(512, ref pAddress))
            {
                return false;
            }
            var paramType9 = parameters[9].ParameterType;
            if (!paramType9.IsValidInput<TArg9>(1024, ref pAddress))
            {
                return false;
            }
            if (pAddress != 0)
            {
                return false;
            }
            pAddress = method.GetFunctionPointer();
            return true;
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool SecondaryValidateInstanceMethodRaw(MethodBase method, Type target, Type arg0, Type arg1, Type arg2, Type arg3, Type arg4, Type arg5, Type arg6, Type arg7, Type arg8, Type arg9, ref nint pAddress)
        {
            if ((pAddress & 1) != 0)
            {
                var reflectedType = method.ReflectedType;
                if (!reflectedType.IsNullAssignableFromFast(target))
                {
                    return false;
                }
            }
            var parameters = method.GetParametersFast();
            if ((pAddress & 2) != 0)
            {
                var paramType = parameters[0].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg0))
                {
                    return false;
                }
            }
            if ((pAddress & 4) != 0)
            {
                var paramType = parameters[1].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg1))
                {
                    return false;
                }
            }
            if ((pAddress & 8) != 0)
            {
                var paramType = parameters[2].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg2))
                {
                    return false;
                }
            }
            if ((pAddress & 16) != 0)
            {
                var paramType = parameters[3].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg3))
                {
                    return false;
                }
            }
            if ((pAddress & 32) != 0)
            {
                var paramType = parameters[4].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg4))
                {
                    return false;
                }
            }
            if ((pAddress & 64) != 0)
            {
                var paramType = parameters[5].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg5))
                {
                    return false;
                }
            }
            if ((pAddress & 128) != 0)
            {
                var paramType = parameters[6].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg6))
                {
                    return false;
                }
            }
            if ((pAddress & 256) != 0)
            {
                var paramType = parameters[7].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg7))
                {
                    return false;
                }
            }
            if ((pAddress & 512) != 0)
            {
                var paramType = parameters[8].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg8))
                {
                    return false;
                }
            }
            if ((pAddress & 1024) != 0)
            {
                var paramType = parameters[9].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg9))
                {
                    return false;
                }
            }
            pAddress = method.GetFunctionPointer();
            return true;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void InvokeStaticFast<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(this MethodBase self, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9)
        {
            bool isValid;
            nint pAddress;
            isValid = ValidateStaticMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(self, out pAddress) ||
                      (pAddress != 0 && SecondaryValidateStaticMethod(self, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), ref pAddress));
            if (!isValid)
            {
                self.InvokeStaticLowAlloc(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
                return;
            }
            unsafe
            {
                ((delegate*<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, void>)pAddress)(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
                return;
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static object InvokeStaticLowAlloc<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(this MethodBase self, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9)
        {
            if (self.IsGenericMethodDefinition)
            {
                ValidateGenericMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(ref self);
            }
            var parameters = self.GetParametersFast();
            ArrayCache.Objects10[0] = REReflection.GetBox(arg0, parameters[0], out var refArg0);
            ArrayCache.Objects10[1] = REReflection.GetBox(arg1, parameters[1], out var refArg1);
            ArrayCache.Objects10[2] = REReflection.GetBox(arg2, parameters[2], out var refArg2);
            ArrayCache.Objects10[3] = REReflection.GetBox(arg3, parameters[3], out var refArg3);
            ArrayCache.Objects10[4] = REReflection.GetBox(arg4, parameters[4], out var refArg4);
            ArrayCache.Objects10[5] = REReflection.GetBox(arg5, parameters[5], out var refArg5);
            ArrayCache.Objects10[6] = REReflection.GetBox(arg6, parameters[6], out var refArg6);
            ArrayCache.Objects10[7] = REReflection.GetBox(arg7, parameters[7], out var refArg7);
            ArrayCache.Objects10[8] = REReflection.GetBox(arg8, parameters[8], out var refArg8);
            ArrayCache.Objects10[9] = REReflection.GetBox(arg9, parameters[9], out var refArg9);
            try
            {
                return self.Invoke(null, ArrayCache.Objects10);
            }
            finally
            {
                REReflection.ReturnBox<TArg0>(ArrayCache.Objects10[0], parameters[0], refArg0);
                REReflection.ReturnBox<TArg1>(ArrayCache.Objects10[1], parameters[1], refArg1);
                REReflection.ReturnBox<TArg2>(ArrayCache.Objects10[2], parameters[2], refArg2);
                REReflection.ReturnBox<TArg3>(ArrayCache.Objects10[3], parameters[3], refArg3);
                REReflection.ReturnBox<TArg4>(ArrayCache.Objects10[4], parameters[4], refArg4);
                REReflection.ReturnBox<TArg5>(ArrayCache.Objects10[5], parameters[5], refArg5);
                REReflection.ReturnBox<TArg6>(ArrayCache.Objects10[6], parameters[6], refArg6);
                REReflection.ReturnBox<TArg7>(ArrayCache.Objects10[7], parameters[7], refArg7);
                REReflection.ReturnBox<TArg8>(ArrayCache.Objects10[8], parameters[8], refArg8);
                REReflection.ReturnBox<TArg9>(ArrayCache.Objects10[9], parameters[9], refArg9);
            }
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool ValidateStaticMethodRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(MethodBase method, out nint pAddress)
        {
            pAddress = 0;
            if (!method.IsStatic)
            {
                return false;
            }
            if (method.IsOverridable())
            {
                return false;
            }
            var isValidGeneric = !method.IsGenericMethodDefinition || ValidateGenericMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(ref method);
            if (!isValidGeneric)
            {
                return false;
            }
            var parameters = method.GetParametersFast();
            var parameterLength = parameters.Count;
            if (parameterLength != 10)
            {
                return false;
            }
            if (method is MethodInfo mi)
            {
                var returnType = mi?.ReturnType ?? typeof(void);
                if (returnType != typeof(void))
                {
                    return false;
                }
            }
            var paramType0 = parameters[0].ParameterType;
            if (!paramType0.IsValidInput<TArg0>(2, ref pAddress))
            {
                return false;
            }
            var paramType1 = parameters[1].ParameterType;
            if (!paramType1.IsValidInput<TArg1>(4, ref pAddress))
            {
                return false;
            }
            var paramType2 = parameters[2].ParameterType;
            if (!paramType2.IsValidInput<TArg2>(8, ref pAddress))
            {
                return false;
            }
            var paramType3 = parameters[3].ParameterType;
            if (!paramType3.IsValidInput<TArg3>(16, ref pAddress))
            {
                return false;
            }
            var paramType4 = parameters[4].ParameterType;
            if (!paramType4.IsValidInput<TArg4>(32, ref pAddress))
            {
                return false;
            }
            var paramType5 = parameters[5].ParameterType;
            if (!paramType5.IsValidInput<TArg5>(64, ref pAddress))
            {
                return false;
            }
            var paramType6 = parameters[6].ParameterType;
            if (!paramType6.IsValidInput<TArg6>(128, ref pAddress))
            {
                return false;
            }
            var paramType7 = parameters[7].ParameterType;
            if (!paramType7.IsValidInput<TArg7>(256, ref pAddress))
            {
                return false;
            }
            var paramType8 = parameters[8].ParameterType;
            if (!paramType8.IsValidInput<TArg8>(512, ref pAddress))
            {
                return false;
            }
            var paramType9 = parameters[9].ParameterType;
            if (!paramType9.IsValidInput<TArg9>(1024, ref pAddress))
            {
                return false;
            }
            if (pAddress != 0)
            {
                return false;
            }
            pAddress = method.GetFunctionPointer();
            return true;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TReturn InvokeStaticFast<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TReturn>(this MethodBase self, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9)
        {
            bool isValid;
            nint pAddress;
            isValid = ValidateStaticReturnableMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TReturn>(self, out pAddress) ||
                      (pAddress != 0 && SecondaryValidateStaticMethod(self, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), ref pAddress));
            if (!isValid)
            {
                return (TReturn)self.InvokeStaticLowAlloc(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
            }
            unsafe
            {
                return ((delegate*<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TReturn>)pAddress)(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
            }
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool ValidateStaticReturnableMethodRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TReturn>(MethodBase method, out nint pAddress)
        {
            pAddress = 0;
            if (!method.IsStatic)
            {
                return false;
            }
            if (method.IsOverridable())
            {
                return false;
            }
            var isValidGeneric = !method.IsGenericMethodDefinition || ValidateGenericReturnableMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TReturn>(ref method);
            if (!isValidGeneric)
            {
                return false;
            }
            var parameters = method.GetParametersFast();
            var parameterLength = parameters.Count;
            if (parameterLength != 10)
            {
                return false;
            }
            if (method is MethodInfo mi)
            {
                var returnType = mi?.ReturnType ?? typeof(void);
                if (!returnType.IsValidOutput<TReturn>())
                {
                    return false;
                }
            }
            var paramType0 = parameters[0].ParameterType;
            if (!paramType0.IsValidInput<TArg0>(2, ref pAddress))
            {
                return false;
            }
            var paramType1 = parameters[1].ParameterType;
            if (!paramType1.IsValidInput<TArg1>(4, ref pAddress))
            {
                return false;
            }
            var paramType2 = parameters[2].ParameterType;
            if (!paramType2.IsValidInput<TArg2>(8, ref pAddress))
            {
                return false;
            }
            var paramType3 = parameters[3].ParameterType;
            if (!paramType3.IsValidInput<TArg3>(16, ref pAddress))
            {
                return false;
            }
            var paramType4 = parameters[4].ParameterType;
            if (!paramType4.IsValidInput<TArg4>(32, ref pAddress))
            {
                return false;
            }
            var paramType5 = parameters[5].ParameterType;
            if (!paramType5.IsValidInput<TArg5>(64, ref pAddress))
            {
                return false;
            }
            var paramType6 = parameters[6].ParameterType;
            if (!paramType6.IsValidInput<TArg6>(128, ref pAddress))
            {
                return false;
            }
            var paramType7 = parameters[7].ParameterType;
            if (!paramType7.IsValidInput<TArg7>(256, ref pAddress))
            {
                return false;
            }
            var paramType8 = parameters[8].ParameterType;
            if (!paramType8.IsValidInput<TArg8>(512, ref pAddress))
            {
                return false;
            }
            var paramType9 = parameters[9].ParameterType;
            if (!paramType9.IsValidInput<TArg9>(1024, ref pAddress))
            {
                return false;
            }
            if (pAddress != 0)
            {
                return false;
            }
            pAddress = method.GetFunctionPointer();
            return true;
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool SecondaryValidateStaticMethodRaw(MethodBase method, Type arg0, Type arg1, Type arg2, Type arg3, Type arg4, Type arg5, Type arg6, Type arg7, Type arg8, Type arg9, ref nint pAddress)
        {
            var parameters = method.GetParametersFast();
            if ((pAddress & 2) != 0)
            {
                var paramType = parameters[0].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg0))
                {
                    return false;
                }
            }
            if ((pAddress & 4) != 0)
            {
                var paramType = parameters[1].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg1))
                {
                    return false;
                }
            }
            if ((pAddress & 8) != 0)
            {
                var paramType = parameters[2].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg2))
                {
                    return false;
                }
            }
            if ((pAddress & 16) != 0)
            {
                var paramType = parameters[3].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg3))
                {
                    return false;
                }
            }
            if ((pAddress & 32) != 0)
            {
                var paramType = parameters[4].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg4))
                {
                    return false;
                }
            }
            if ((pAddress & 64) != 0)
            {
                var paramType = parameters[5].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg5))
                {
                    return false;
                }
            }
            if ((pAddress & 128) != 0)
            {
                var paramType = parameters[6].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg6))
                {
                    return false;
                }
            }
            if ((pAddress & 256) != 0)
            {
                var paramType = parameters[7].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg7))
                {
                    return false;
                }
            }
            if ((pAddress & 512) != 0)
            {
                var paramType = parameters[8].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg8))
                {
                    return false;
                }
            }
            if ((pAddress & 1024) != 0)
            {
                var paramType = parameters[9].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg9))
                {
                    return false;
                }
            }
            pAddress = method.GetFunctionPointer();
            return true;
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool ValidateGenericMethodRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(ref MethodBase method)
        {
            if (!method.IsGenericMethodDefinition)
            {
                return true;
            }
            var genericArguments = method.GetGenericArgumentsFast();
            if (genericArguments.Count < 10)
            {
                return false;
            }
            uint mask = 0;
            var mi = method as MethodInfo;
            var parameters = method.GetParametersFast();
            var index0 = IndexOf(genericArguments, parameters[0].ParameterType);
            if (index0 >= 0)
            {
                mask |= 1u << index0;
            }
            var index1 = IndexOf(genericArguments, parameters[1].ParameterType);
            if (index1 >= 0)
            {
                mask |= 1u << index1;
            }
            var index2 = IndexOf(genericArguments, parameters[2].ParameterType);
            if (index2 >= 0)
            {
                mask |= 1u << index2;
            }
            var index3 = IndexOf(genericArguments, parameters[3].ParameterType);
            if (index3 >= 0)
            {
                mask |= 1u << index3;
            }
            var index4 = IndexOf(genericArguments, parameters[4].ParameterType);
            if (index4 >= 0)
            {
                mask |= 1u << index4;
            }
            var index5 = IndexOf(genericArguments, parameters[5].ParameterType);
            if (index5 >= 0)
            {
                mask |= 1u << index5;
            }
            var index6 = IndexOf(genericArguments, parameters[6].ParameterType);
            if (index6 >= 0)
            {
                mask |= 1u << index6;
            }
            var index7 = IndexOf(genericArguments, parameters[7].ParameterType);
            if (index7 >= 0)
            {
                mask |= 1u << index7;
            }
            var index8 = IndexOf(genericArguments, parameters[8].ParameterType);
            if (index8 >= 0)
            {
                mask |= 1u << index8;
            }
            var index9 = IndexOf(genericArguments, parameters[9].ParameterType);
            if (index9 >= 0)
            {
                mask |= 1u << index9;
            }
            if (REReflection.BitCount(mask) != genericArguments.Count)
            {
                return false;
            }
            var types = ArrayCache.GetArrayCache<Type>(genericArguments.Count);
            if (index0 >= 0)
            {
                types[index0] = typeof(TArg0);
            }
            if (index1 >= 0)
            {
                types[index1] = typeof(TArg1);
            }
            if (index2 >= 0)
            {
                types[index2] = typeof(TArg2);
            }
            if (index3 >= 0)
            {
                types[index3] = typeof(TArg3);
            }
            if (index4 >= 0)
            {
                types[index4] = typeof(TArg4);
            }
            if (index5 >= 0)
            {
                types[index5] = typeof(TArg5);
            }
            if (index6 >= 0)
            {
                types[index6] = typeof(TArg6);
            }
            if (index7 >= 0)
            {
                types[index7] = typeof(TArg7);
            }
            if (index8 >= 0)
            {
                types[index8] = typeof(TArg8);
            }
            if (index9 >= 0)
            {
                types[index9] = typeof(TArg9);
            }
            #if ENABLE_IL2CPP
            bool isFound = false;
            var usingMethods = method.GetUsingGenericInstanceMethods();
            foreach (var usingMethod in usingMethods)
            {
                if (usingMethod.GetGenericArgumentsFast().SequenceEqual(types))
                {
                    isFound = true;
                    break;
                }
            }
            if (!isFound)
            {
                return false;
            }
            #endif
            method = mi.MakeGenericMethodFast(types);
            return true;
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool ValidateGenericReturnableMethodRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TReturn>(ref MethodBase method)
        {
            if (!method.IsGenericMethodDefinition)
            {
                return true;
            }
            var genericArguments = method.GetGenericArgumentsFast();
            if (genericArguments.Count < 11)
            {
                return false;
            }
            uint mask = 0;
            var mi = method as MethodInfo;
            var returnType = mi.ReturnType ?? typeof(void);
            var index = IndexOf(genericArguments, returnType);
            if (index >= 0)
            {
                mask |= 1u << index;
            }
            var parameters = method.GetParametersFast();
            var index0 = IndexOf(genericArguments, parameters[0].ParameterType);
            if (index0 >= 0)
            {
                mask |= 1u << index0;
            }
            var index1 = IndexOf(genericArguments, parameters[1].ParameterType);
            if (index1 >= 0)
            {
                mask |= 1u << index1;
            }
            var index2 = IndexOf(genericArguments, parameters[2].ParameterType);
            if (index2 >= 0)
            {
                mask |= 1u << index2;
            }
            var index3 = IndexOf(genericArguments, parameters[3].ParameterType);
            if (index3 >= 0)
            {
                mask |= 1u << index3;
            }
            var index4 = IndexOf(genericArguments, parameters[4].ParameterType);
            if (index4 >= 0)
            {
                mask |= 1u << index4;
            }
            var index5 = IndexOf(genericArguments, parameters[5].ParameterType);
            if (index5 >= 0)
            {
                mask |= 1u << index5;
            }
            var index6 = IndexOf(genericArguments, parameters[6].ParameterType);
            if (index6 >= 0)
            {
                mask |= 1u << index6;
            }
            var index7 = IndexOf(genericArguments, parameters[7].ParameterType);
            if (index7 >= 0)
            {
                mask |= 1u << index7;
            }
            var index8 = IndexOf(genericArguments, parameters[8].ParameterType);
            if (index8 >= 0)
            {
                mask |= 1u << index8;
            }
            var index9 = IndexOf(genericArguments, parameters[9].ParameterType);
            if (index9 >= 0)
            {
                mask |= 1u << index9;
            }
            if (REReflection.BitCount(mask) != genericArguments.Count)
            {
                return false;
            }
            var types = ArrayCache.GetArrayCache<Type>(genericArguments.Count);
            if (index >= 0)
            {
                types[index] = typeof(TReturn);
            }
            if (index0 >= 0)
            {
                types[index0] = typeof(TArg0);
            }
            if (index1 >= 0)
            {
                types[index1] = typeof(TArg1);
            }
            if (index2 >= 0)
            {
                types[index2] = typeof(TArg2);
            }
            if (index3 >= 0)
            {
                types[index3] = typeof(TArg3);
            }
            if (index4 >= 0)
            {
                types[index4] = typeof(TArg4);
            }
            if (index5 >= 0)
            {
                types[index5] = typeof(TArg5);
            }
            if (index6 >= 0)
            {
                types[index6] = typeof(TArg6);
            }
            if (index7 >= 0)
            {
                types[index7] = typeof(TArg7);
            }
            if (index8 >= 0)
            {
                types[index8] = typeof(TArg8);
            }
            if (index9 >= 0)
            {
                types[index9] = typeof(TArg9);
            }
            #if ENABLE_IL2CPP
            bool isFound = false;
            var usingMethods = method.GetUsingGenericInstanceMethods();
            foreach (var usingMethod in usingMethods)
            {
                if (usingMethod.GetGenericArgumentsFast().SequenceEqual(types))
                {
                    isFound = true;
                    break;
                }
            }
            if (!isFound)
            {
                return false;
            }
            #endif
            method = mi.MakeGenericMethodFast(types);
            return true;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void InvokeInstanceFast<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(this MethodBase self, ref TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9, in TArg10 arg10)
        {
            bool isValid;
            nint pAddress;
            if (self.IsOverridable())
            {
                isValid = ValidateInstanceVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(self, target?.GetType(), out pAddress) ||
                          (pAddress != 0 && SecondaryValidateStaticMethod(self, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), ref pAddress));
            }
            else
            {
                isValid = ValidateInstanceMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(self, out pAddress) ||
                          (pAddress != 0 && SecondaryValidateInstanceMethod(self, target?.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), ref pAddress));
            }
            if (!isValid)
            {
                self.InvokeInstanceLowAlloc(ref target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
                return;
            }
            unsafe
            {
                if (REType.IsValueTypeFast<TTarget>())
                {
                    ((delegate*<ref TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, void>)pAddress)(ref target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
                    return;
                }
                ((delegate*<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, void>)pAddress)(target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
                return;
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void InvokeClassInstanceFast<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(this MethodBase self, TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9, in TArg10 arg10)
        where TTarget: class
        {
            bool isValid;
            nint pAddress;
            if (self.IsOverridable())
            {
                isValid = ValidateInstanceVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(self, target?.GetType(), out pAddress) ||
                          (pAddress != 0 && SecondaryValidateStaticMethod(self, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), ref pAddress));
            }
            else
            {
                isValid = ValidateInstanceMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(self, out pAddress) ||
                          (pAddress != 0 && SecondaryValidateInstanceMethod(self, target?.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), ref pAddress));
            }
            if (!isValid)
            {
                self.InvokeClassInstanceLowAlloc(target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
                return;
            }
            unsafe
            {
                ((delegate*<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, void>)pAddress)(target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
                return;
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void InvokeStructInstanceFast<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(this MethodBase self, ref TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9, in TArg10 arg10)
        where TTarget: struct
        {
            bool isValid;
            nint pAddress;
            if (self.IsOverridable())
            {
                isValid = ValidateInstanceVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(self, target.GetType(), out pAddress) ||
                          (pAddress != 0 && SecondaryValidateStaticMethod(self, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), ref pAddress));
            }
            else
            {
                isValid = ValidateInstanceMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(self, out pAddress) ||
                          (pAddress != 0 && SecondaryValidateInstanceMethod(self, target.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), ref pAddress));
            }
            if (!isValid)
            {
                self.InvokeInstanceLowAlloc(ref target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
                return;
            }
            unsafe
            {
                ((delegate*<ref TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, void>)pAddress)(ref target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
                return;
            }
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool ValidateInstanceMethodRaw<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(MethodBase method, out nint pAddress)
        {
            pAddress = 0;
            if (method.IsStatic)
            {
                return false;
            }
            if (method.IsOverridable())
            {
                return false;
            }
            var isValidGeneric = !method.IsGenericMethodDefinition || ValidateGenericMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(ref method);
            if (!isValidGeneric)
            {
                return false;
            }
            var parameters = method.GetParametersFast();
            var parameterLength = parameters.Count;
            if (parameterLength != 11)
            {
                return false;
            }
            if (method is MethodInfo mi)
            {
                var returnType = mi?.ReturnType ?? typeof(void);
                if (returnType != typeof(void))
                {
                    return false;
                }
            }
            var reflectedType = method.ReflectedType;
            if (!reflectedType.IsValidInputWithoutRef<TTarget>(1, ref pAddress))
            {
                return false;
            }
            var paramType0 = parameters[0].ParameterType;
            if (!paramType0.IsValidInput<TArg0>(2, ref pAddress))
            {
                return false;
            }
            var paramType1 = parameters[1].ParameterType;
            if (!paramType1.IsValidInput<TArg1>(4, ref pAddress))
            {
                return false;
            }
            var paramType2 = parameters[2].ParameterType;
            if (!paramType2.IsValidInput<TArg2>(8, ref pAddress))
            {
                return false;
            }
            var paramType3 = parameters[3].ParameterType;
            if (!paramType3.IsValidInput<TArg3>(16, ref pAddress))
            {
                return false;
            }
            var paramType4 = parameters[4].ParameterType;
            if (!paramType4.IsValidInput<TArg4>(32, ref pAddress))
            {
                return false;
            }
            var paramType5 = parameters[5].ParameterType;
            if (!paramType5.IsValidInput<TArg5>(64, ref pAddress))
            {
                return false;
            }
            var paramType6 = parameters[6].ParameterType;
            if (!paramType6.IsValidInput<TArg6>(128, ref pAddress))
            {
                return false;
            }
            var paramType7 = parameters[7].ParameterType;
            if (!paramType7.IsValidInput<TArg7>(256, ref pAddress))
            {
                return false;
            }
            var paramType8 = parameters[8].ParameterType;
            if (!paramType8.IsValidInput<TArg8>(512, ref pAddress))
            {
                return false;
            }
            var paramType9 = parameters[9].ParameterType;
            if (!paramType9.IsValidInput<TArg9>(1024, ref pAddress))
            {
                return false;
            }
            var paramType10 = parameters[10].ParameterType;
            if (!paramType10.IsValidInput<TArg10>(2048, ref pAddress))
            {
                return false;
            }
            if (pAddress != 0)
            {
                return false;
            }
            pAddress = method.GetFunctionPointer();
            return true;
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool ValidateInstanceVirtualMethodRaw<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(MethodBase method, Type targetType, out nint pAddress)
        {
            pAddress = 0;
            if (method.IsStatic)
            {
                return false;
            }
            if (!method.IsOverridable())
            {
                return false;
            }
            var isValidGeneric = !method.IsGenericMethodDefinition || ValidateGenericMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(ref method);
            if (!isValidGeneric)
            {
                return false;
            }
            var parameters = method.GetParametersFast();
            var parameterLength = parameters.Count;
            if (parameterLength != 11)
            {
                return false;
            }
            if (method is MethodInfo mi)
            {
                var returnType = mi?.ReturnType ?? typeof(void);
                if (returnType != typeof(void))
                {
                    return false;
                }
            }
            var reflectedType = method.ReflectedType;
            if (!reflectedType.IsValidVirtualInput<TTarget>(targetType, out var isVirtualCall))
            {
                return false;
            }
            if (isVirtualCall)
            {
                ArrayCache.Types11[0] = parameters[0].ParameterType;
                ArrayCache.Types11[1] = parameters[1].ParameterType;
                ArrayCache.Types11[2] = parameters[2].ParameterType;
                ArrayCache.Types11[3] = parameters[3].ParameterType;
                ArrayCache.Types11[4] = parameters[4].ParameterType;
                ArrayCache.Types11[5] = parameters[5].ParameterType;
                ArrayCache.Types11[6] = parameters[6].ParameterType;
                ArrayCache.Types11[7] = parameters[7].ParameterType;
                ArrayCache.Types11[8] = parameters[8].ParameterType;
                ArrayCache.Types11[9] = parameters[9].ParameterType;
                ArrayCache.Types11[10] = parameters[10].ParameterType;
                method = targetType.GetInstanceMethodFullAccess(method.Name, null, ArrayCache.Types11, null);
            }
            var paramType0 = parameters[0].ParameterType;
            if (!paramType0.IsValidInput<TArg0>(2, ref pAddress))
            {
                return false;
            }
            var paramType1 = parameters[1].ParameterType;
            if (!paramType1.IsValidInput<TArg1>(4, ref pAddress))
            {
                return false;
            }
            var paramType2 = parameters[2].ParameterType;
            if (!paramType2.IsValidInput<TArg2>(8, ref pAddress))
            {
                return false;
            }
            var paramType3 = parameters[3].ParameterType;
            if (!paramType3.IsValidInput<TArg3>(16, ref pAddress))
            {
                return false;
            }
            var paramType4 = parameters[4].ParameterType;
            if (!paramType4.IsValidInput<TArg4>(32, ref pAddress))
            {
                return false;
            }
            var paramType5 = parameters[5].ParameterType;
            if (!paramType5.IsValidInput<TArg5>(64, ref pAddress))
            {
                return false;
            }
            var paramType6 = parameters[6].ParameterType;
            if (!paramType6.IsValidInput<TArg6>(128, ref pAddress))
            {
                return false;
            }
            var paramType7 = parameters[7].ParameterType;
            if (!paramType7.IsValidInput<TArg7>(256, ref pAddress))
            {
                return false;
            }
            var paramType8 = parameters[8].ParameterType;
            if (!paramType8.IsValidInput<TArg8>(512, ref pAddress))
            {
                return false;
            }
            var paramType9 = parameters[9].ParameterType;
            if (!paramType9.IsValidInput<TArg9>(1024, ref pAddress))
            {
                return false;
            }
            var paramType10 = parameters[10].ParameterType;
            if (!paramType10.IsValidInput<TArg10>(2048, ref pAddress))
            {
                return false;
            }
            if (pAddress != 0)
            {
                return false;
            }
            pAddress = method.GetFunctionPointer();
            return true;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TReturn InvokeInstanceFast<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TReturn>(this MethodBase self, ref TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9, in TArg10 arg10)
        {
            bool isValid;
            nint pAddress;
            if (self.IsOverridable())
            {
                isValid = ValidateInstanceReturnableVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TReturn>(self, target?.GetType(), out pAddress) ||
                          (pAddress != 0 && SecondaryValidateStaticMethod(self, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), ref pAddress));
            }
            else
            {
                isValid = ValidateInstanceReturnableMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TReturn>(self, out pAddress) ||
                          (pAddress != 0 && SecondaryValidateInstanceMethod(self, target?.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), ref pAddress));
            }
            if (!isValid)
            {
                return (TReturn)self.InvokeInstanceLowAlloc(ref target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
            }
            unsafe
            {
                if (REType.IsValueTypeFast<TTarget>())
                {
                    return ((delegate*<ref TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TReturn>)pAddress)(ref target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
                }
                return ((delegate*<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TReturn>)pAddress)(target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TReturn InvokeClassInstanceFast<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TReturn>(this MethodBase self, TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9, in TArg10 arg10)
        where TTarget: class
        {
            bool isValid;
            nint pAddress;
            if (self.IsOverridable())
            {
                isValid = ValidateInstanceReturnableVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TReturn>(self, target?.GetType(), out pAddress) ||
                          (pAddress != 0 && SecondaryValidateStaticMethod(self, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), ref pAddress));
            }
            else
            {
                isValid = ValidateInstanceReturnableMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TReturn>(self, out pAddress) ||
                          (pAddress != 0 && SecondaryValidateInstanceMethod(self, target?.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), ref pAddress));
            }
            if (!isValid)
            {
                return (TReturn)self.InvokeClassInstanceLowAlloc(target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
            }
            unsafe
            {
                return ((delegate*<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TReturn>)pAddress)(target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TReturn InvokeStructInstanceFast<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TReturn>(this MethodBase self, ref TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9, in TArg10 arg10)
        where TTarget: struct
        {
            bool isValid;
            nint pAddress;
            if (self.IsOverridable())
            {
                isValid = ValidateInstanceReturnableVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TReturn>(self, target.GetType(), out pAddress) ||
                          (pAddress != 0 && SecondaryValidateStaticMethod(self, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), ref pAddress));
            }
            else
            {
                isValid = ValidateInstanceReturnableMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TReturn>(self, out pAddress) ||
                          (pAddress != 0 && SecondaryValidateInstanceMethod(self, target.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), ref pAddress));
            }
            if (!isValid)
            {
                return (TReturn)self.InvokeInstanceLowAlloc(ref target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
            }
            unsafe
            {
                return ((delegate*<ref TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TReturn>)pAddress)(ref target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static object InvokeInstanceLowAlloc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(this MethodBase self, ref TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9, in TArg10 arg10)
        {
            if (self.IsGenericMethodDefinition)
            {
                ValidateGenericMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(ref self);
            }
            var targetObj = REReflection.GetBoxWithoutRef(target);
            var parameters = self.GetParametersFast();
            ArrayCache.Objects11[0] = REReflection.GetBox(arg0, parameters[0], out var refArg0);
            ArrayCache.Objects11[1] = REReflection.GetBox(arg1, parameters[1], out var refArg1);
            ArrayCache.Objects11[2] = REReflection.GetBox(arg2, parameters[2], out var refArg2);
            ArrayCache.Objects11[3] = REReflection.GetBox(arg3, parameters[3], out var refArg3);
            ArrayCache.Objects11[4] = REReflection.GetBox(arg4, parameters[4], out var refArg4);
            ArrayCache.Objects11[5] = REReflection.GetBox(arg5, parameters[5], out var refArg5);
            ArrayCache.Objects11[6] = REReflection.GetBox(arg6, parameters[6], out var refArg6);
            ArrayCache.Objects11[7] = REReflection.GetBox(arg7, parameters[7], out var refArg7);
            ArrayCache.Objects11[8] = REReflection.GetBox(arg8, parameters[8], out var refArg8);
            ArrayCache.Objects11[9] = REReflection.GetBox(arg9, parameters[9], out var refArg9);
            ArrayCache.Objects11[10] = REReflection.GetBox(arg10, parameters[10], out var refArg10);
            try
            {
                return self.Invoke(targetObj, ArrayCache.Objects11);
            }
            finally
            {
                REReflection.Unbox(targetObj, out target);
                REReflection.ReturnBoxWithoutRef<TTarget>(targetObj);
                REReflection.ReturnBox<TArg0>(ArrayCache.Objects11[0], parameters[0], refArg0);
                REReflection.ReturnBox<TArg1>(ArrayCache.Objects11[1], parameters[1], refArg1);
                REReflection.ReturnBox<TArg2>(ArrayCache.Objects11[2], parameters[2], refArg2);
                REReflection.ReturnBox<TArg3>(ArrayCache.Objects11[3], parameters[3], refArg3);
                REReflection.ReturnBox<TArg4>(ArrayCache.Objects11[4], parameters[4], refArg4);
                REReflection.ReturnBox<TArg5>(ArrayCache.Objects11[5], parameters[5], refArg5);
                REReflection.ReturnBox<TArg6>(ArrayCache.Objects11[6], parameters[6], refArg6);
                REReflection.ReturnBox<TArg7>(ArrayCache.Objects11[7], parameters[7], refArg7);
                REReflection.ReturnBox<TArg8>(ArrayCache.Objects11[8], parameters[8], refArg8);
                REReflection.ReturnBox<TArg9>(ArrayCache.Objects11[9], parameters[9], refArg9);
                REReflection.ReturnBox<TArg10>(ArrayCache.Objects11[10], parameters[10], refArg10);
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static object InvokeClassInstanceLowAlloc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(this MethodBase self, TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9, in TArg10 arg10)
        where TTarget: class
        {
            if (self.IsGenericMethodDefinition)
            {
                ValidateGenericMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(ref self);
            }
            var parameters = self.GetParametersFast();
            ArrayCache.Objects11[0] = REReflection.GetBox(arg0, parameters[0], out var refArg0);
            ArrayCache.Objects11[1] = REReflection.GetBox(arg1, parameters[1], out var refArg1);
            ArrayCache.Objects11[2] = REReflection.GetBox(arg2, parameters[2], out var refArg2);
            ArrayCache.Objects11[3] = REReflection.GetBox(arg3, parameters[3], out var refArg3);
            ArrayCache.Objects11[4] = REReflection.GetBox(arg4, parameters[4], out var refArg4);
            ArrayCache.Objects11[5] = REReflection.GetBox(arg5, parameters[5], out var refArg5);
            ArrayCache.Objects11[6] = REReflection.GetBox(arg6, parameters[6], out var refArg6);
            ArrayCache.Objects11[7] = REReflection.GetBox(arg7, parameters[7], out var refArg7);
            ArrayCache.Objects11[8] = REReflection.GetBox(arg8, parameters[8], out var refArg8);
            ArrayCache.Objects11[9] = REReflection.GetBox(arg9, parameters[9], out var refArg9);
            ArrayCache.Objects11[10] = REReflection.GetBox(arg10, parameters[10], out var refArg10);
            try
            {
                return self.Invoke(target, ArrayCache.Objects11);
            }
            finally
            {
                REReflection.ReturnBox<TArg0>(ArrayCache.Objects11[0], parameters[0], refArg0);
                REReflection.ReturnBox<TArg1>(ArrayCache.Objects11[1], parameters[1], refArg1);
                REReflection.ReturnBox<TArg2>(ArrayCache.Objects11[2], parameters[2], refArg2);
                REReflection.ReturnBox<TArg3>(ArrayCache.Objects11[3], parameters[3], refArg3);
                REReflection.ReturnBox<TArg4>(ArrayCache.Objects11[4], parameters[4], refArg4);
                REReflection.ReturnBox<TArg5>(ArrayCache.Objects11[5], parameters[5], refArg5);
                REReflection.ReturnBox<TArg6>(ArrayCache.Objects11[6], parameters[6], refArg6);
                REReflection.ReturnBox<TArg7>(ArrayCache.Objects11[7], parameters[7], refArg7);
                REReflection.ReturnBox<TArg8>(ArrayCache.Objects11[8], parameters[8], refArg8);
                REReflection.ReturnBox<TArg9>(ArrayCache.Objects11[9], parameters[9], refArg9);
                REReflection.ReturnBox<TArg10>(ArrayCache.Objects11[10], parameters[10], refArg10);
            }
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool ValidateInstanceReturnableMethodRaw<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TReturn>(MethodBase method, out nint pAddress)
        {
            pAddress = 0;
            if (method.IsStatic)
            {
                return false;
            }
            if (method.IsOverridable())
            {
                return false;
            }
            var isValidGeneric = !method.IsGenericMethodDefinition || ValidateGenericReturnableMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TReturn>(ref method);
            if (!isValidGeneric)
            {
                return false;
            }
            var parameters = method.GetParametersFast();
            var parameterLength = parameters.Count;
            if (parameterLength != 11)
            {
                return false;
            }
            if (method is MethodInfo mi)
            {
                var returnType = mi?.ReturnType ?? typeof(void);
                if (!returnType.IsValidOutput<TReturn>())
                {
                    return false;
                }
            }
            var reflectedType = method.ReflectedType;
            if (!reflectedType.IsValidInputWithoutRef<TTarget>(1, ref pAddress))
            {
                return false;
            }
            var paramType0 = parameters[0].ParameterType;
            if (!paramType0.IsValidInput<TArg0>(2, ref pAddress))
            {
                return false;
            }
            var paramType1 = parameters[1].ParameterType;
            if (!paramType1.IsValidInput<TArg1>(4, ref pAddress))
            {
                return false;
            }
            var paramType2 = parameters[2].ParameterType;
            if (!paramType2.IsValidInput<TArg2>(8, ref pAddress))
            {
                return false;
            }
            var paramType3 = parameters[3].ParameterType;
            if (!paramType3.IsValidInput<TArg3>(16, ref pAddress))
            {
                return false;
            }
            var paramType4 = parameters[4].ParameterType;
            if (!paramType4.IsValidInput<TArg4>(32, ref pAddress))
            {
                return false;
            }
            var paramType5 = parameters[5].ParameterType;
            if (!paramType5.IsValidInput<TArg5>(64, ref pAddress))
            {
                return false;
            }
            var paramType6 = parameters[6].ParameterType;
            if (!paramType6.IsValidInput<TArg6>(128, ref pAddress))
            {
                return false;
            }
            var paramType7 = parameters[7].ParameterType;
            if (!paramType7.IsValidInput<TArg7>(256, ref pAddress))
            {
                return false;
            }
            var paramType8 = parameters[8].ParameterType;
            if (!paramType8.IsValidInput<TArg8>(512, ref pAddress))
            {
                return false;
            }
            var paramType9 = parameters[9].ParameterType;
            if (!paramType9.IsValidInput<TArg9>(1024, ref pAddress))
            {
                return false;
            }
            var paramType10 = parameters[10].ParameterType;
            if (!paramType10.IsValidInput<TArg10>(2048, ref pAddress))
            {
                return false;
            }
            if (pAddress != 0)
            {
                return false;
            }
            pAddress = method.GetFunctionPointer();
            return true;
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool ValidateInstanceReturnableVirtualMethodRaw<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TReturn>(MethodBase method, Type targetType, out nint pAddress)
        {
            pAddress = 0;
            if (method.IsStatic)
            {
                return false;
            }
            if (!method.IsOverridable())
            {
                return false;
            }
            var isValidGeneric = !method.IsGenericMethodDefinition || ValidateGenericReturnableMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TReturn>(ref method);
            if (!isValidGeneric)
            {
                return false;
            }
            var parameters = method.GetParametersFast();
            var parameterLength = parameters.Count;
            if (parameterLength != 11)
            {
                return false;
            }
            if (method is MethodInfo mi)
            {
                var returnType = mi?.ReturnType ?? typeof(void);
                if (!returnType.IsValidOutput<TReturn>())
                {
                    return false;
                }
            }
            var reflectedType = method.ReflectedType;
            if (!reflectedType.IsValidVirtualInput<TTarget>(targetType, out var isVirtualCall))
            {
                return false;
            }
            if (isVirtualCall)
            {
                ArrayCache.Types11[0] = parameters[0].ParameterType;
                ArrayCache.Types11[1] = parameters[1].ParameterType;
                ArrayCache.Types11[2] = parameters[2].ParameterType;
                ArrayCache.Types11[3] = parameters[3].ParameterType;
                ArrayCache.Types11[4] = parameters[4].ParameterType;
                ArrayCache.Types11[5] = parameters[5].ParameterType;
                ArrayCache.Types11[6] = parameters[6].ParameterType;
                ArrayCache.Types11[7] = parameters[7].ParameterType;
                ArrayCache.Types11[8] = parameters[8].ParameterType;
                ArrayCache.Types11[9] = parameters[9].ParameterType;
                ArrayCache.Types11[10] = parameters[10].ParameterType;
                method = targetType.GetInstanceMethodFullAccess(method.Name, null, ArrayCache.Types11, null);
            }
            var paramType0 = parameters[0].ParameterType;
            if (!paramType0.IsValidInput<TArg0>(2, ref pAddress))
            {
                return false;
            }
            var paramType1 = parameters[1].ParameterType;
            if (!paramType1.IsValidInput<TArg1>(4, ref pAddress))
            {
                return false;
            }
            var paramType2 = parameters[2].ParameterType;
            if (!paramType2.IsValidInput<TArg2>(8, ref pAddress))
            {
                return false;
            }
            var paramType3 = parameters[3].ParameterType;
            if (!paramType3.IsValidInput<TArg3>(16, ref pAddress))
            {
                return false;
            }
            var paramType4 = parameters[4].ParameterType;
            if (!paramType4.IsValidInput<TArg4>(32, ref pAddress))
            {
                return false;
            }
            var paramType5 = parameters[5].ParameterType;
            if (!paramType5.IsValidInput<TArg5>(64, ref pAddress))
            {
                return false;
            }
            var paramType6 = parameters[6].ParameterType;
            if (!paramType6.IsValidInput<TArg6>(128, ref pAddress))
            {
                return false;
            }
            var paramType7 = parameters[7].ParameterType;
            if (!paramType7.IsValidInput<TArg7>(256, ref pAddress))
            {
                return false;
            }
            var paramType8 = parameters[8].ParameterType;
            if (!paramType8.IsValidInput<TArg8>(512, ref pAddress))
            {
                return false;
            }
            var paramType9 = parameters[9].ParameterType;
            if (!paramType9.IsValidInput<TArg9>(1024, ref pAddress))
            {
                return false;
            }
            var paramType10 = parameters[10].ParameterType;
            if (!paramType10.IsValidInput<TArg10>(2048, ref pAddress))
            {
                return false;
            }
            if (pAddress != 0)
            {
                return false;
            }
            pAddress = method.GetFunctionPointer();
            return true;
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool SecondaryValidateInstanceMethodRaw(MethodBase method, Type target, Type arg0, Type arg1, Type arg2, Type arg3, Type arg4, Type arg5, Type arg6, Type arg7, Type arg8, Type arg9, Type arg10, ref nint pAddress)
        {
            if ((pAddress & 1) != 0)
            {
                var reflectedType = method.ReflectedType;
                if (!reflectedType.IsNullAssignableFromFast(target))
                {
                    return false;
                }
            }
            var parameters = method.GetParametersFast();
            if ((pAddress & 2) != 0)
            {
                var paramType = parameters[0].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg0))
                {
                    return false;
                }
            }
            if ((pAddress & 4) != 0)
            {
                var paramType = parameters[1].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg1))
                {
                    return false;
                }
            }
            if ((pAddress & 8) != 0)
            {
                var paramType = parameters[2].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg2))
                {
                    return false;
                }
            }
            if ((pAddress & 16) != 0)
            {
                var paramType = parameters[3].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg3))
                {
                    return false;
                }
            }
            if ((pAddress & 32) != 0)
            {
                var paramType = parameters[4].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg4))
                {
                    return false;
                }
            }
            if ((pAddress & 64) != 0)
            {
                var paramType = parameters[5].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg5))
                {
                    return false;
                }
            }
            if ((pAddress & 128) != 0)
            {
                var paramType = parameters[6].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg6))
                {
                    return false;
                }
            }
            if ((pAddress & 256) != 0)
            {
                var paramType = parameters[7].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg7))
                {
                    return false;
                }
            }
            if ((pAddress & 512) != 0)
            {
                var paramType = parameters[8].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg8))
                {
                    return false;
                }
            }
            if ((pAddress & 1024) != 0)
            {
                var paramType = parameters[9].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg9))
                {
                    return false;
                }
            }
            if ((pAddress & 2048) != 0)
            {
                var paramType = parameters[10].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg10))
                {
                    return false;
                }
            }
            pAddress = method.GetFunctionPointer();
            return true;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void InvokeStaticFast<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(this MethodBase self, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9, in TArg10 arg10)
        {
            bool isValid;
            nint pAddress;
            isValid = ValidateStaticMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(self, out pAddress) ||
                      (pAddress != 0 && SecondaryValidateStaticMethod(self, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), ref pAddress));
            if (!isValid)
            {
                self.InvokeStaticLowAlloc(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
                return;
            }
            unsafe
            {
                ((delegate*<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, void>)pAddress)(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
                return;
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static object InvokeStaticLowAlloc<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(this MethodBase self, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9, in TArg10 arg10)
        {
            if (self.IsGenericMethodDefinition)
            {
                ValidateGenericMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(ref self);
            }
            var parameters = self.GetParametersFast();
            ArrayCache.Objects11[0] = REReflection.GetBox(arg0, parameters[0], out var refArg0);
            ArrayCache.Objects11[1] = REReflection.GetBox(arg1, parameters[1], out var refArg1);
            ArrayCache.Objects11[2] = REReflection.GetBox(arg2, parameters[2], out var refArg2);
            ArrayCache.Objects11[3] = REReflection.GetBox(arg3, parameters[3], out var refArg3);
            ArrayCache.Objects11[4] = REReflection.GetBox(arg4, parameters[4], out var refArg4);
            ArrayCache.Objects11[5] = REReflection.GetBox(arg5, parameters[5], out var refArg5);
            ArrayCache.Objects11[6] = REReflection.GetBox(arg6, parameters[6], out var refArg6);
            ArrayCache.Objects11[7] = REReflection.GetBox(arg7, parameters[7], out var refArg7);
            ArrayCache.Objects11[8] = REReflection.GetBox(arg8, parameters[8], out var refArg8);
            ArrayCache.Objects11[9] = REReflection.GetBox(arg9, parameters[9], out var refArg9);
            ArrayCache.Objects11[10] = REReflection.GetBox(arg10, parameters[10], out var refArg10);
            try
            {
                return self.Invoke(null, ArrayCache.Objects11);
            }
            finally
            {
                REReflection.ReturnBox<TArg0>(ArrayCache.Objects11[0], parameters[0], refArg0);
                REReflection.ReturnBox<TArg1>(ArrayCache.Objects11[1], parameters[1], refArg1);
                REReflection.ReturnBox<TArg2>(ArrayCache.Objects11[2], parameters[2], refArg2);
                REReflection.ReturnBox<TArg3>(ArrayCache.Objects11[3], parameters[3], refArg3);
                REReflection.ReturnBox<TArg4>(ArrayCache.Objects11[4], parameters[4], refArg4);
                REReflection.ReturnBox<TArg5>(ArrayCache.Objects11[5], parameters[5], refArg5);
                REReflection.ReturnBox<TArg6>(ArrayCache.Objects11[6], parameters[6], refArg6);
                REReflection.ReturnBox<TArg7>(ArrayCache.Objects11[7], parameters[7], refArg7);
                REReflection.ReturnBox<TArg8>(ArrayCache.Objects11[8], parameters[8], refArg8);
                REReflection.ReturnBox<TArg9>(ArrayCache.Objects11[9], parameters[9], refArg9);
                REReflection.ReturnBox<TArg10>(ArrayCache.Objects11[10], parameters[10], refArg10);
            }
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool ValidateStaticMethodRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(MethodBase method, out nint pAddress)
        {
            pAddress = 0;
            if (!method.IsStatic)
            {
                return false;
            }
            if (method.IsOverridable())
            {
                return false;
            }
            var isValidGeneric = !method.IsGenericMethodDefinition || ValidateGenericMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(ref method);
            if (!isValidGeneric)
            {
                return false;
            }
            var parameters = method.GetParametersFast();
            var parameterLength = parameters.Count;
            if (parameterLength != 11)
            {
                return false;
            }
            if (method is MethodInfo mi)
            {
                var returnType = mi?.ReturnType ?? typeof(void);
                if (returnType != typeof(void))
                {
                    return false;
                }
            }
            var paramType0 = parameters[0].ParameterType;
            if (!paramType0.IsValidInput<TArg0>(2, ref pAddress))
            {
                return false;
            }
            var paramType1 = parameters[1].ParameterType;
            if (!paramType1.IsValidInput<TArg1>(4, ref pAddress))
            {
                return false;
            }
            var paramType2 = parameters[2].ParameterType;
            if (!paramType2.IsValidInput<TArg2>(8, ref pAddress))
            {
                return false;
            }
            var paramType3 = parameters[3].ParameterType;
            if (!paramType3.IsValidInput<TArg3>(16, ref pAddress))
            {
                return false;
            }
            var paramType4 = parameters[4].ParameterType;
            if (!paramType4.IsValidInput<TArg4>(32, ref pAddress))
            {
                return false;
            }
            var paramType5 = parameters[5].ParameterType;
            if (!paramType5.IsValidInput<TArg5>(64, ref pAddress))
            {
                return false;
            }
            var paramType6 = parameters[6].ParameterType;
            if (!paramType6.IsValidInput<TArg6>(128, ref pAddress))
            {
                return false;
            }
            var paramType7 = parameters[7].ParameterType;
            if (!paramType7.IsValidInput<TArg7>(256, ref pAddress))
            {
                return false;
            }
            var paramType8 = parameters[8].ParameterType;
            if (!paramType8.IsValidInput<TArg8>(512, ref pAddress))
            {
                return false;
            }
            var paramType9 = parameters[9].ParameterType;
            if (!paramType9.IsValidInput<TArg9>(1024, ref pAddress))
            {
                return false;
            }
            var paramType10 = parameters[10].ParameterType;
            if (!paramType10.IsValidInput<TArg10>(2048, ref pAddress))
            {
                return false;
            }
            if (pAddress != 0)
            {
                return false;
            }
            pAddress = method.GetFunctionPointer();
            return true;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TReturn InvokeStaticFast<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TReturn>(this MethodBase self, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9, in TArg10 arg10)
        {
            bool isValid;
            nint pAddress;
            isValid = ValidateStaticReturnableMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TReturn>(self, out pAddress) ||
                      (pAddress != 0 && SecondaryValidateStaticMethod(self, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), ref pAddress));
            if (!isValid)
            {
                return (TReturn)self.InvokeStaticLowAlloc(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
            }
            unsafe
            {
                return ((delegate*<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TReturn>)pAddress)(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
            }
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool ValidateStaticReturnableMethodRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TReturn>(MethodBase method, out nint pAddress)
        {
            pAddress = 0;
            if (!method.IsStatic)
            {
                return false;
            }
            if (method.IsOverridable())
            {
                return false;
            }
            var isValidGeneric = !method.IsGenericMethodDefinition || ValidateGenericReturnableMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TReturn>(ref method);
            if (!isValidGeneric)
            {
                return false;
            }
            var parameters = method.GetParametersFast();
            var parameterLength = parameters.Count;
            if (parameterLength != 11)
            {
                return false;
            }
            if (method is MethodInfo mi)
            {
                var returnType = mi?.ReturnType ?? typeof(void);
                if (!returnType.IsValidOutput<TReturn>())
                {
                    return false;
                }
            }
            var paramType0 = parameters[0].ParameterType;
            if (!paramType0.IsValidInput<TArg0>(2, ref pAddress))
            {
                return false;
            }
            var paramType1 = parameters[1].ParameterType;
            if (!paramType1.IsValidInput<TArg1>(4, ref pAddress))
            {
                return false;
            }
            var paramType2 = parameters[2].ParameterType;
            if (!paramType2.IsValidInput<TArg2>(8, ref pAddress))
            {
                return false;
            }
            var paramType3 = parameters[3].ParameterType;
            if (!paramType3.IsValidInput<TArg3>(16, ref pAddress))
            {
                return false;
            }
            var paramType4 = parameters[4].ParameterType;
            if (!paramType4.IsValidInput<TArg4>(32, ref pAddress))
            {
                return false;
            }
            var paramType5 = parameters[5].ParameterType;
            if (!paramType5.IsValidInput<TArg5>(64, ref pAddress))
            {
                return false;
            }
            var paramType6 = parameters[6].ParameterType;
            if (!paramType6.IsValidInput<TArg6>(128, ref pAddress))
            {
                return false;
            }
            var paramType7 = parameters[7].ParameterType;
            if (!paramType7.IsValidInput<TArg7>(256, ref pAddress))
            {
                return false;
            }
            var paramType8 = parameters[8].ParameterType;
            if (!paramType8.IsValidInput<TArg8>(512, ref pAddress))
            {
                return false;
            }
            var paramType9 = parameters[9].ParameterType;
            if (!paramType9.IsValidInput<TArg9>(1024, ref pAddress))
            {
                return false;
            }
            var paramType10 = parameters[10].ParameterType;
            if (!paramType10.IsValidInput<TArg10>(2048, ref pAddress))
            {
                return false;
            }
            if (pAddress != 0)
            {
                return false;
            }
            pAddress = method.GetFunctionPointer();
            return true;
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool SecondaryValidateStaticMethodRaw(MethodBase method, Type arg0, Type arg1, Type arg2, Type arg3, Type arg4, Type arg5, Type arg6, Type arg7, Type arg8, Type arg9, Type arg10, ref nint pAddress)
        {
            var parameters = method.GetParametersFast();
            if ((pAddress & 2) != 0)
            {
                var paramType = parameters[0].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg0))
                {
                    return false;
                }
            }
            if ((pAddress & 4) != 0)
            {
                var paramType = parameters[1].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg1))
                {
                    return false;
                }
            }
            if ((pAddress & 8) != 0)
            {
                var paramType = parameters[2].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg2))
                {
                    return false;
                }
            }
            if ((pAddress & 16) != 0)
            {
                var paramType = parameters[3].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg3))
                {
                    return false;
                }
            }
            if ((pAddress & 32) != 0)
            {
                var paramType = parameters[4].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg4))
                {
                    return false;
                }
            }
            if ((pAddress & 64) != 0)
            {
                var paramType = parameters[5].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg5))
                {
                    return false;
                }
            }
            if ((pAddress & 128) != 0)
            {
                var paramType = parameters[6].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg6))
                {
                    return false;
                }
            }
            if ((pAddress & 256) != 0)
            {
                var paramType = parameters[7].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg7))
                {
                    return false;
                }
            }
            if ((pAddress & 512) != 0)
            {
                var paramType = parameters[8].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg8))
                {
                    return false;
                }
            }
            if ((pAddress & 1024) != 0)
            {
                var paramType = parameters[9].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg9))
                {
                    return false;
                }
            }
            if ((pAddress & 2048) != 0)
            {
                var paramType = parameters[10].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg10))
                {
                    return false;
                }
            }
            pAddress = method.GetFunctionPointer();
            return true;
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool ValidateGenericMethodRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(ref MethodBase method)
        {
            if (!method.IsGenericMethodDefinition)
            {
                return true;
            }
            var genericArguments = method.GetGenericArgumentsFast();
            if (genericArguments.Count < 11)
            {
                return false;
            }
            uint mask = 0;
            var mi = method as MethodInfo;
            var parameters = method.GetParametersFast();
            var index0 = IndexOf(genericArguments, parameters[0].ParameterType);
            if (index0 >= 0)
            {
                mask |= 1u << index0;
            }
            var index1 = IndexOf(genericArguments, parameters[1].ParameterType);
            if (index1 >= 0)
            {
                mask |= 1u << index1;
            }
            var index2 = IndexOf(genericArguments, parameters[2].ParameterType);
            if (index2 >= 0)
            {
                mask |= 1u << index2;
            }
            var index3 = IndexOf(genericArguments, parameters[3].ParameterType);
            if (index3 >= 0)
            {
                mask |= 1u << index3;
            }
            var index4 = IndexOf(genericArguments, parameters[4].ParameterType);
            if (index4 >= 0)
            {
                mask |= 1u << index4;
            }
            var index5 = IndexOf(genericArguments, parameters[5].ParameterType);
            if (index5 >= 0)
            {
                mask |= 1u << index5;
            }
            var index6 = IndexOf(genericArguments, parameters[6].ParameterType);
            if (index6 >= 0)
            {
                mask |= 1u << index6;
            }
            var index7 = IndexOf(genericArguments, parameters[7].ParameterType);
            if (index7 >= 0)
            {
                mask |= 1u << index7;
            }
            var index8 = IndexOf(genericArguments, parameters[8].ParameterType);
            if (index8 >= 0)
            {
                mask |= 1u << index8;
            }
            var index9 = IndexOf(genericArguments, parameters[9].ParameterType);
            if (index9 >= 0)
            {
                mask |= 1u << index9;
            }
            var index10 = IndexOf(genericArguments, parameters[10].ParameterType);
            if (index10 >= 0)
            {
                mask |= 1u << index10;
            }
            if (REReflection.BitCount(mask) != genericArguments.Count)
            {
                return false;
            }
            var types = ArrayCache.GetArrayCache<Type>(genericArguments.Count);
            if (index0 >= 0)
            {
                types[index0] = typeof(TArg0);
            }
            if (index1 >= 0)
            {
                types[index1] = typeof(TArg1);
            }
            if (index2 >= 0)
            {
                types[index2] = typeof(TArg2);
            }
            if (index3 >= 0)
            {
                types[index3] = typeof(TArg3);
            }
            if (index4 >= 0)
            {
                types[index4] = typeof(TArg4);
            }
            if (index5 >= 0)
            {
                types[index5] = typeof(TArg5);
            }
            if (index6 >= 0)
            {
                types[index6] = typeof(TArg6);
            }
            if (index7 >= 0)
            {
                types[index7] = typeof(TArg7);
            }
            if (index8 >= 0)
            {
                types[index8] = typeof(TArg8);
            }
            if (index9 >= 0)
            {
                types[index9] = typeof(TArg9);
            }
            if (index10 >= 0)
            {
                types[index10] = typeof(TArg10);
            }
            #if ENABLE_IL2CPP
            bool isFound = false;
            var usingMethods = method.GetUsingGenericInstanceMethods();
            foreach (var usingMethod in usingMethods)
            {
                if (usingMethod.GetGenericArgumentsFast().SequenceEqual(types))
                {
                    isFound = true;
                    break;
                }
            }
            if (!isFound)
            {
                return false;
            }
            #endif
            method = mi.MakeGenericMethodFast(types);
            return true;
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool ValidateGenericReturnableMethodRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TReturn>(ref MethodBase method)
        {
            if (!method.IsGenericMethodDefinition)
            {
                return true;
            }
            var genericArguments = method.GetGenericArgumentsFast();
            if (genericArguments.Count < 12)
            {
                return false;
            }
            uint mask = 0;
            var mi = method as MethodInfo;
            var returnType = mi.ReturnType ?? typeof(void);
            var index = IndexOf(genericArguments, returnType);
            if (index >= 0)
            {
                mask |= 1u << index;
            }
            var parameters = method.GetParametersFast();
            var index0 = IndexOf(genericArguments, parameters[0].ParameterType);
            if (index0 >= 0)
            {
                mask |= 1u << index0;
            }
            var index1 = IndexOf(genericArguments, parameters[1].ParameterType);
            if (index1 >= 0)
            {
                mask |= 1u << index1;
            }
            var index2 = IndexOf(genericArguments, parameters[2].ParameterType);
            if (index2 >= 0)
            {
                mask |= 1u << index2;
            }
            var index3 = IndexOf(genericArguments, parameters[3].ParameterType);
            if (index3 >= 0)
            {
                mask |= 1u << index3;
            }
            var index4 = IndexOf(genericArguments, parameters[4].ParameterType);
            if (index4 >= 0)
            {
                mask |= 1u << index4;
            }
            var index5 = IndexOf(genericArguments, parameters[5].ParameterType);
            if (index5 >= 0)
            {
                mask |= 1u << index5;
            }
            var index6 = IndexOf(genericArguments, parameters[6].ParameterType);
            if (index6 >= 0)
            {
                mask |= 1u << index6;
            }
            var index7 = IndexOf(genericArguments, parameters[7].ParameterType);
            if (index7 >= 0)
            {
                mask |= 1u << index7;
            }
            var index8 = IndexOf(genericArguments, parameters[8].ParameterType);
            if (index8 >= 0)
            {
                mask |= 1u << index8;
            }
            var index9 = IndexOf(genericArguments, parameters[9].ParameterType);
            if (index9 >= 0)
            {
                mask |= 1u << index9;
            }
            var index10 = IndexOf(genericArguments, parameters[10].ParameterType);
            if (index10 >= 0)
            {
                mask |= 1u << index10;
            }
            if (REReflection.BitCount(mask) != genericArguments.Count)
            {
                return false;
            }
            var types = ArrayCache.GetArrayCache<Type>(genericArguments.Count);
            if (index >= 0)
            {
                types[index] = typeof(TReturn);
            }
            if (index0 >= 0)
            {
                types[index0] = typeof(TArg0);
            }
            if (index1 >= 0)
            {
                types[index1] = typeof(TArg1);
            }
            if (index2 >= 0)
            {
                types[index2] = typeof(TArg2);
            }
            if (index3 >= 0)
            {
                types[index3] = typeof(TArg3);
            }
            if (index4 >= 0)
            {
                types[index4] = typeof(TArg4);
            }
            if (index5 >= 0)
            {
                types[index5] = typeof(TArg5);
            }
            if (index6 >= 0)
            {
                types[index6] = typeof(TArg6);
            }
            if (index7 >= 0)
            {
                types[index7] = typeof(TArg7);
            }
            if (index8 >= 0)
            {
                types[index8] = typeof(TArg8);
            }
            if (index9 >= 0)
            {
                types[index9] = typeof(TArg9);
            }
            if (index10 >= 0)
            {
                types[index10] = typeof(TArg10);
            }
            #if ENABLE_IL2CPP
            bool isFound = false;
            var usingMethods = method.GetUsingGenericInstanceMethods();
            foreach (var usingMethod in usingMethods)
            {
                if (usingMethod.GetGenericArgumentsFast().SequenceEqual(types))
                {
                    isFound = true;
                    break;
                }
            }
            if (!isFound)
            {
                return false;
            }
            #endif
            method = mi.MakeGenericMethodFast(types);
            return true;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void InvokeInstanceFast<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(this MethodBase self, ref TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9, in TArg10 arg10, in TArg11 arg11)
        {
            bool isValid;
            nint pAddress;
            if (self.IsOverridable())
            {
                isValid = ValidateInstanceVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(self, target?.GetType(), out pAddress) ||
                          (pAddress != 0 && SecondaryValidateStaticMethod(self, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), arg11?.GetType(), ref pAddress));
            }
            else
            {
                isValid = ValidateInstanceMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(self, out pAddress) ||
                          (pAddress != 0 && SecondaryValidateInstanceMethod(self, target?.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), arg11?.GetType(), ref pAddress));
            }
            if (!isValid)
            {
                self.InvokeInstanceLowAlloc(ref target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
                return;
            }
            unsafe
            {
                if (REType.IsValueTypeFast<TTarget>())
                {
                    ((delegate*<ref TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, void>)pAddress)(ref target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
                    return;
                }
                ((delegate*<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, void>)pAddress)(target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
                return;
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void InvokeClassInstanceFast<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(this MethodBase self, TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9, in TArg10 arg10, in TArg11 arg11)
        where TTarget: class
        {
            bool isValid;
            nint pAddress;
            if (self.IsOverridable())
            {
                isValid = ValidateInstanceVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(self, target?.GetType(), out pAddress) ||
                          (pAddress != 0 && SecondaryValidateStaticMethod(self, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), arg11?.GetType(), ref pAddress));
            }
            else
            {
                isValid = ValidateInstanceMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(self, out pAddress) ||
                          (pAddress != 0 && SecondaryValidateInstanceMethod(self, target?.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), arg11?.GetType(), ref pAddress));
            }
            if (!isValid)
            {
                self.InvokeClassInstanceLowAlloc(target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
                return;
            }
            unsafe
            {
                ((delegate*<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, void>)pAddress)(target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
                return;
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void InvokeStructInstanceFast<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(this MethodBase self, ref TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9, in TArg10 arg10, in TArg11 arg11)
        where TTarget: struct
        {
            bool isValid;
            nint pAddress;
            if (self.IsOverridable())
            {
                isValid = ValidateInstanceVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(self, target.GetType(), out pAddress) ||
                          (pAddress != 0 && SecondaryValidateStaticMethod(self, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), arg11?.GetType(), ref pAddress));
            }
            else
            {
                isValid = ValidateInstanceMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(self, out pAddress) ||
                          (pAddress != 0 && SecondaryValidateInstanceMethod(self, target.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), arg11?.GetType(), ref pAddress));
            }
            if (!isValid)
            {
                self.InvokeInstanceLowAlloc(ref target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
                return;
            }
            unsafe
            {
                ((delegate*<ref TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, void>)pAddress)(ref target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
                return;
            }
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool ValidateInstanceMethodRaw<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(MethodBase method, out nint pAddress)
        {
            pAddress = 0;
            if (method.IsStatic)
            {
                return false;
            }
            if (method.IsOverridable())
            {
                return false;
            }
            var isValidGeneric = !method.IsGenericMethodDefinition || ValidateGenericMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(ref method);
            if (!isValidGeneric)
            {
                return false;
            }
            var parameters = method.GetParametersFast();
            var parameterLength = parameters.Count;
            if (parameterLength != 12)
            {
                return false;
            }
            if (method is MethodInfo mi)
            {
                var returnType = mi?.ReturnType ?? typeof(void);
                if (returnType != typeof(void))
                {
                    return false;
                }
            }
            var reflectedType = method.ReflectedType;
            if (!reflectedType.IsValidInputWithoutRef<TTarget>(1, ref pAddress))
            {
                return false;
            }
            var paramType0 = parameters[0].ParameterType;
            if (!paramType0.IsValidInput<TArg0>(2, ref pAddress))
            {
                return false;
            }
            var paramType1 = parameters[1].ParameterType;
            if (!paramType1.IsValidInput<TArg1>(4, ref pAddress))
            {
                return false;
            }
            var paramType2 = parameters[2].ParameterType;
            if (!paramType2.IsValidInput<TArg2>(8, ref pAddress))
            {
                return false;
            }
            var paramType3 = parameters[3].ParameterType;
            if (!paramType3.IsValidInput<TArg3>(16, ref pAddress))
            {
                return false;
            }
            var paramType4 = parameters[4].ParameterType;
            if (!paramType4.IsValidInput<TArg4>(32, ref pAddress))
            {
                return false;
            }
            var paramType5 = parameters[5].ParameterType;
            if (!paramType5.IsValidInput<TArg5>(64, ref pAddress))
            {
                return false;
            }
            var paramType6 = parameters[6].ParameterType;
            if (!paramType6.IsValidInput<TArg6>(128, ref pAddress))
            {
                return false;
            }
            var paramType7 = parameters[7].ParameterType;
            if (!paramType7.IsValidInput<TArg7>(256, ref pAddress))
            {
                return false;
            }
            var paramType8 = parameters[8].ParameterType;
            if (!paramType8.IsValidInput<TArg8>(512, ref pAddress))
            {
                return false;
            }
            var paramType9 = parameters[9].ParameterType;
            if (!paramType9.IsValidInput<TArg9>(1024, ref pAddress))
            {
                return false;
            }
            var paramType10 = parameters[10].ParameterType;
            if (!paramType10.IsValidInput<TArg10>(2048, ref pAddress))
            {
                return false;
            }
            var paramType11 = parameters[11].ParameterType;
            if (!paramType11.IsValidInput<TArg11>(4096, ref pAddress))
            {
                return false;
            }
            if (pAddress != 0)
            {
                return false;
            }
            pAddress = method.GetFunctionPointer();
            return true;
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool ValidateInstanceVirtualMethodRaw<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(MethodBase method, Type targetType, out nint pAddress)
        {
            pAddress = 0;
            if (method.IsStatic)
            {
                return false;
            }
            if (!method.IsOverridable())
            {
                return false;
            }
            var isValidGeneric = !method.IsGenericMethodDefinition || ValidateGenericMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(ref method);
            if (!isValidGeneric)
            {
                return false;
            }
            var parameters = method.GetParametersFast();
            var parameterLength = parameters.Count;
            if (parameterLength != 12)
            {
                return false;
            }
            if (method is MethodInfo mi)
            {
                var returnType = mi?.ReturnType ?? typeof(void);
                if (returnType != typeof(void))
                {
                    return false;
                }
            }
            var reflectedType = method.ReflectedType;
            if (!reflectedType.IsValidVirtualInput<TTarget>(targetType, out var isVirtualCall))
            {
                return false;
            }
            if (isVirtualCall)
            {
                ArrayCache.Types12[0] = parameters[0].ParameterType;
                ArrayCache.Types12[1] = parameters[1].ParameterType;
                ArrayCache.Types12[2] = parameters[2].ParameterType;
                ArrayCache.Types12[3] = parameters[3].ParameterType;
                ArrayCache.Types12[4] = parameters[4].ParameterType;
                ArrayCache.Types12[5] = parameters[5].ParameterType;
                ArrayCache.Types12[6] = parameters[6].ParameterType;
                ArrayCache.Types12[7] = parameters[7].ParameterType;
                ArrayCache.Types12[8] = parameters[8].ParameterType;
                ArrayCache.Types12[9] = parameters[9].ParameterType;
                ArrayCache.Types12[10] = parameters[10].ParameterType;
                ArrayCache.Types12[11] = parameters[11].ParameterType;
                method = targetType.GetInstanceMethodFullAccess(method.Name, null, ArrayCache.Types12, null);
            }
            var paramType0 = parameters[0].ParameterType;
            if (!paramType0.IsValidInput<TArg0>(2, ref pAddress))
            {
                return false;
            }
            var paramType1 = parameters[1].ParameterType;
            if (!paramType1.IsValidInput<TArg1>(4, ref pAddress))
            {
                return false;
            }
            var paramType2 = parameters[2].ParameterType;
            if (!paramType2.IsValidInput<TArg2>(8, ref pAddress))
            {
                return false;
            }
            var paramType3 = parameters[3].ParameterType;
            if (!paramType3.IsValidInput<TArg3>(16, ref pAddress))
            {
                return false;
            }
            var paramType4 = parameters[4].ParameterType;
            if (!paramType4.IsValidInput<TArg4>(32, ref pAddress))
            {
                return false;
            }
            var paramType5 = parameters[5].ParameterType;
            if (!paramType5.IsValidInput<TArg5>(64, ref pAddress))
            {
                return false;
            }
            var paramType6 = parameters[6].ParameterType;
            if (!paramType6.IsValidInput<TArg6>(128, ref pAddress))
            {
                return false;
            }
            var paramType7 = parameters[7].ParameterType;
            if (!paramType7.IsValidInput<TArg7>(256, ref pAddress))
            {
                return false;
            }
            var paramType8 = parameters[8].ParameterType;
            if (!paramType8.IsValidInput<TArg8>(512, ref pAddress))
            {
                return false;
            }
            var paramType9 = parameters[9].ParameterType;
            if (!paramType9.IsValidInput<TArg9>(1024, ref pAddress))
            {
                return false;
            }
            var paramType10 = parameters[10].ParameterType;
            if (!paramType10.IsValidInput<TArg10>(2048, ref pAddress))
            {
                return false;
            }
            var paramType11 = parameters[11].ParameterType;
            if (!paramType11.IsValidInput<TArg11>(4096, ref pAddress))
            {
                return false;
            }
            if (pAddress != 0)
            {
                return false;
            }
            pAddress = method.GetFunctionPointer();
            return true;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TReturn InvokeInstanceFast<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TReturn>(this MethodBase self, ref TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9, in TArg10 arg10, in TArg11 arg11)
        {
            bool isValid;
            nint pAddress;
            if (self.IsOverridable())
            {
                isValid = ValidateInstanceReturnableVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TReturn>(self, target?.GetType(), out pAddress) ||
                          (pAddress != 0 && SecondaryValidateStaticMethod(self, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), arg11?.GetType(), ref pAddress));
            }
            else
            {
                isValid = ValidateInstanceReturnableMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TReturn>(self, out pAddress) ||
                          (pAddress != 0 && SecondaryValidateInstanceMethod(self, target?.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), arg11?.GetType(), ref pAddress));
            }
            if (!isValid)
            {
                return (TReturn)self.InvokeInstanceLowAlloc(ref target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
            }
            unsafe
            {
                if (REType.IsValueTypeFast<TTarget>())
                {
                    return ((delegate*<ref TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TReturn>)pAddress)(ref target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
                }
                return ((delegate*<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TReturn>)pAddress)(target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TReturn InvokeClassInstanceFast<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TReturn>(this MethodBase self, TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9, in TArg10 arg10, in TArg11 arg11)
        where TTarget: class
        {
            bool isValid;
            nint pAddress;
            if (self.IsOverridable())
            {
                isValid = ValidateInstanceReturnableVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TReturn>(self, target?.GetType(), out pAddress) ||
                          (pAddress != 0 && SecondaryValidateStaticMethod(self, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), arg11?.GetType(), ref pAddress));
            }
            else
            {
                isValid = ValidateInstanceReturnableMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TReturn>(self, out pAddress) ||
                          (pAddress != 0 && SecondaryValidateInstanceMethod(self, target?.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), arg11?.GetType(), ref pAddress));
            }
            if (!isValid)
            {
                return (TReturn)self.InvokeClassInstanceLowAlloc(target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
            }
            unsafe
            {
                return ((delegate*<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TReturn>)pAddress)(target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TReturn InvokeStructInstanceFast<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TReturn>(this MethodBase self, ref TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9, in TArg10 arg10, in TArg11 arg11)
        where TTarget: struct
        {
            bool isValid;
            nint pAddress;
            if (self.IsOverridable())
            {
                isValid = ValidateInstanceReturnableVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TReturn>(self, target.GetType(), out pAddress) ||
                          (pAddress != 0 && SecondaryValidateStaticMethod(self, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), arg11?.GetType(), ref pAddress));
            }
            else
            {
                isValid = ValidateInstanceReturnableMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TReturn>(self, out pAddress) ||
                          (pAddress != 0 && SecondaryValidateInstanceMethod(self, target.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), arg11?.GetType(), ref pAddress));
            }
            if (!isValid)
            {
                return (TReturn)self.InvokeInstanceLowAlloc(ref target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
            }
            unsafe
            {
                return ((delegate*<ref TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TReturn>)pAddress)(ref target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static object InvokeInstanceLowAlloc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(this MethodBase self, ref TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9, in TArg10 arg10, in TArg11 arg11)
        {
            if (self.IsGenericMethodDefinition)
            {
                ValidateGenericMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(ref self);
            }
            var targetObj = REReflection.GetBoxWithoutRef(target);
            var parameters = self.GetParametersFast();
            ArrayCache.Objects12[0] = REReflection.GetBox(arg0, parameters[0], out var refArg0);
            ArrayCache.Objects12[1] = REReflection.GetBox(arg1, parameters[1], out var refArg1);
            ArrayCache.Objects12[2] = REReflection.GetBox(arg2, parameters[2], out var refArg2);
            ArrayCache.Objects12[3] = REReflection.GetBox(arg3, parameters[3], out var refArg3);
            ArrayCache.Objects12[4] = REReflection.GetBox(arg4, parameters[4], out var refArg4);
            ArrayCache.Objects12[5] = REReflection.GetBox(arg5, parameters[5], out var refArg5);
            ArrayCache.Objects12[6] = REReflection.GetBox(arg6, parameters[6], out var refArg6);
            ArrayCache.Objects12[7] = REReflection.GetBox(arg7, parameters[7], out var refArg7);
            ArrayCache.Objects12[8] = REReflection.GetBox(arg8, parameters[8], out var refArg8);
            ArrayCache.Objects12[9] = REReflection.GetBox(arg9, parameters[9], out var refArg9);
            ArrayCache.Objects12[10] = REReflection.GetBox(arg10, parameters[10], out var refArg10);
            ArrayCache.Objects12[11] = REReflection.GetBox(arg11, parameters[11], out var refArg11);
            try
            {
                return self.Invoke(targetObj, ArrayCache.Objects12);
            }
            finally
            {
                REReflection.Unbox(targetObj, out target);
                REReflection.ReturnBoxWithoutRef<TTarget>(targetObj);
                REReflection.ReturnBox<TArg0>(ArrayCache.Objects12[0], parameters[0], refArg0);
                REReflection.ReturnBox<TArg1>(ArrayCache.Objects12[1], parameters[1], refArg1);
                REReflection.ReturnBox<TArg2>(ArrayCache.Objects12[2], parameters[2], refArg2);
                REReflection.ReturnBox<TArg3>(ArrayCache.Objects12[3], parameters[3], refArg3);
                REReflection.ReturnBox<TArg4>(ArrayCache.Objects12[4], parameters[4], refArg4);
                REReflection.ReturnBox<TArg5>(ArrayCache.Objects12[5], parameters[5], refArg5);
                REReflection.ReturnBox<TArg6>(ArrayCache.Objects12[6], parameters[6], refArg6);
                REReflection.ReturnBox<TArg7>(ArrayCache.Objects12[7], parameters[7], refArg7);
                REReflection.ReturnBox<TArg8>(ArrayCache.Objects12[8], parameters[8], refArg8);
                REReflection.ReturnBox<TArg9>(ArrayCache.Objects12[9], parameters[9], refArg9);
                REReflection.ReturnBox<TArg10>(ArrayCache.Objects12[10], parameters[10], refArg10);
                REReflection.ReturnBox<TArg11>(ArrayCache.Objects12[11], parameters[11], refArg11);
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static object InvokeClassInstanceLowAlloc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(this MethodBase self, TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9, in TArg10 arg10, in TArg11 arg11)
        where TTarget: class
        {
            if (self.IsGenericMethodDefinition)
            {
                ValidateGenericMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(ref self);
            }
            var parameters = self.GetParametersFast();
            ArrayCache.Objects12[0] = REReflection.GetBox(arg0, parameters[0], out var refArg0);
            ArrayCache.Objects12[1] = REReflection.GetBox(arg1, parameters[1], out var refArg1);
            ArrayCache.Objects12[2] = REReflection.GetBox(arg2, parameters[2], out var refArg2);
            ArrayCache.Objects12[3] = REReflection.GetBox(arg3, parameters[3], out var refArg3);
            ArrayCache.Objects12[4] = REReflection.GetBox(arg4, parameters[4], out var refArg4);
            ArrayCache.Objects12[5] = REReflection.GetBox(arg5, parameters[5], out var refArg5);
            ArrayCache.Objects12[6] = REReflection.GetBox(arg6, parameters[6], out var refArg6);
            ArrayCache.Objects12[7] = REReflection.GetBox(arg7, parameters[7], out var refArg7);
            ArrayCache.Objects12[8] = REReflection.GetBox(arg8, parameters[8], out var refArg8);
            ArrayCache.Objects12[9] = REReflection.GetBox(arg9, parameters[9], out var refArg9);
            ArrayCache.Objects12[10] = REReflection.GetBox(arg10, parameters[10], out var refArg10);
            ArrayCache.Objects12[11] = REReflection.GetBox(arg11, parameters[11], out var refArg11);
            try
            {
                return self.Invoke(target, ArrayCache.Objects12);
            }
            finally
            {
                REReflection.ReturnBox<TArg0>(ArrayCache.Objects12[0], parameters[0], refArg0);
                REReflection.ReturnBox<TArg1>(ArrayCache.Objects12[1], parameters[1], refArg1);
                REReflection.ReturnBox<TArg2>(ArrayCache.Objects12[2], parameters[2], refArg2);
                REReflection.ReturnBox<TArg3>(ArrayCache.Objects12[3], parameters[3], refArg3);
                REReflection.ReturnBox<TArg4>(ArrayCache.Objects12[4], parameters[4], refArg4);
                REReflection.ReturnBox<TArg5>(ArrayCache.Objects12[5], parameters[5], refArg5);
                REReflection.ReturnBox<TArg6>(ArrayCache.Objects12[6], parameters[6], refArg6);
                REReflection.ReturnBox<TArg7>(ArrayCache.Objects12[7], parameters[7], refArg7);
                REReflection.ReturnBox<TArg8>(ArrayCache.Objects12[8], parameters[8], refArg8);
                REReflection.ReturnBox<TArg9>(ArrayCache.Objects12[9], parameters[9], refArg9);
                REReflection.ReturnBox<TArg10>(ArrayCache.Objects12[10], parameters[10], refArg10);
                REReflection.ReturnBox<TArg11>(ArrayCache.Objects12[11], parameters[11], refArg11);
            }
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool ValidateInstanceReturnableMethodRaw<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TReturn>(MethodBase method, out nint pAddress)
        {
            pAddress = 0;
            if (method.IsStatic)
            {
                return false;
            }
            if (method.IsOverridable())
            {
                return false;
            }
            var isValidGeneric = !method.IsGenericMethodDefinition || ValidateGenericReturnableMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TReturn>(ref method);
            if (!isValidGeneric)
            {
                return false;
            }
            var parameters = method.GetParametersFast();
            var parameterLength = parameters.Count;
            if (parameterLength != 12)
            {
                return false;
            }
            if (method is MethodInfo mi)
            {
                var returnType = mi?.ReturnType ?? typeof(void);
                if (!returnType.IsValidOutput<TReturn>())
                {
                    return false;
                }
            }
            var reflectedType = method.ReflectedType;
            if (!reflectedType.IsValidInputWithoutRef<TTarget>(1, ref pAddress))
            {
                return false;
            }
            var paramType0 = parameters[0].ParameterType;
            if (!paramType0.IsValidInput<TArg0>(2, ref pAddress))
            {
                return false;
            }
            var paramType1 = parameters[1].ParameterType;
            if (!paramType1.IsValidInput<TArg1>(4, ref pAddress))
            {
                return false;
            }
            var paramType2 = parameters[2].ParameterType;
            if (!paramType2.IsValidInput<TArg2>(8, ref pAddress))
            {
                return false;
            }
            var paramType3 = parameters[3].ParameterType;
            if (!paramType3.IsValidInput<TArg3>(16, ref pAddress))
            {
                return false;
            }
            var paramType4 = parameters[4].ParameterType;
            if (!paramType4.IsValidInput<TArg4>(32, ref pAddress))
            {
                return false;
            }
            var paramType5 = parameters[5].ParameterType;
            if (!paramType5.IsValidInput<TArg5>(64, ref pAddress))
            {
                return false;
            }
            var paramType6 = parameters[6].ParameterType;
            if (!paramType6.IsValidInput<TArg6>(128, ref pAddress))
            {
                return false;
            }
            var paramType7 = parameters[7].ParameterType;
            if (!paramType7.IsValidInput<TArg7>(256, ref pAddress))
            {
                return false;
            }
            var paramType8 = parameters[8].ParameterType;
            if (!paramType8.IsValidInput<TArg8>(512, ref pAddress))
            {
                return false;
            }
            var paramType9 = parameters[9].ParameterType;
            if (!paramType9.IsValidInput<TArg9>(1024, ref pAddress))
            {
                return false;
            }
            var paramType10 = parameters[10].ParameterType;
            if (!paramType10.IsValidInput<TArg10>(2048, ref pAddress))
            {
                return false;
            }
            var paramType11 = parameters[11].ParameterType;
            if (!paramType11.IsValidInput<TArg11>(4096, ref pAddress))
            {
                return false;
            }
            if (pAddress != 0)
            {
                return false;
            }
            pAddress = method.GetFunctionPointer();
            return true;
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool ValidateInstanceReturnableVirtualMethodRaw<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TReturn>(MethodBase method, Type targetType, out nint pAddress)
        {
            pAddress = 0;
            if (method.IsStatic)
            {
                return false;
            }
            if (!method.IsOverridable())
            {
                return false;
            }
            var isValidGeneric = !method.IsGenericMethodDefinition || ValidateGenericReturnableMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TReturn>(ref method);
            if (!isValidGeneric)
            {
                return false;
            }
            var parameters = method.GetParametersFast();
            var parameterLength = parameters.Count;
            if (parameterLength != 12)
            {
                return false;
            }
            if (method is MethodInfo mi)
            {
                var returnType = mi?.ReturnType ?? typeof(void);
                if (!returnType.IsValidOutput<TReturn>())
                {
                    return false;
                }
            }
            var reflectedType = method.ReflectedType;
            if (!reflectedType.IsValidVirtualInput<TTarget>(targetType, out var isVirtualCall))
            {
                return false;
            }
            if (isVirtualCall)
            {
                ArrayCache.Types12[0] = parameters[0].ParameterType;
                ArrayCache.Types12[1] = parameters[1].ParameterType;
                ArrayCache.Types12[2] = parameters[2].ParameterType;
                ArrayCache.Types12[3] = parameters[3].ParameterType;
                ArrayCache.Types12[4] = parameters[4].ParameterType;
                ArrayCache.Types12[5] = parameters[5].ParameterType;
                ArrayCache.Types12[6] = parameters[6].ParameterType;
                ArrayCache.Types12[7] = parameters[7].ParameterType;
                ArrayCache.Types12[8] = parameters[8].ParameterType;
                ArrayCache.Types12[9] = parameters[9].ParameterType;
                ArrayCache.Types12[10] = parameters[10].ParameterType;
                ArrayCache.Types12[11] = parameters[11].ParameterType;
                method = targetType.GetInstanceMethodFullAccess(method.Name, null, ArrayCache.Types12, null);
            }
            var paramType0 = parameters[0].ParameterType;
            if (!paramType0.IsValidInput<TArg0>(2, ref pAddress))
            {
                return false;
            }
            var paramType1 = parameters[1].ParameterType;
            if (!paramType1.IsValidInput<TArg1>(4, ref pAddress))
            {
                return false;
            }
            var paramType2 = parameters[2].ParameterType;
            if (!paramType2.IsValidInput<TArg2>(8, ref pAddress))
            {
                return false;
            }
            var paramType3 = parameters[3].ParameterType;
            if (!paramType3.IsValidInput<TArg3>(16, ref pAddress))
            {
                return false;
            }
            var paramType4 = parameters[4].ParameterType;
            if (!paramType4.IsValidInput<TArg4>(32, ref pAddress))
            {
                return false;
            }
            var paramType5 = parameters[5].ParameterType;
            if (!paramType5.IsValidInput<TArg5>(64, ref pAddress))
            {
                return false;
            }
            var paramType6 = parameters[6].ParameterType;
            if (!paramType6.IsValidInput<TArg6>(128, ref pAddress))
            {
                return false;
            }
            var paramType7 = parameters[7].ParameterType;
            if (!paramType7.IsValidInput<TArg7>(256, ref pAddress))
            {
                return false;
            }
            var paramType8 = parameters[8].ParameterType;
            if (!paramType8.IsValidInput<TArg8>(512, ref pAddress))
            {
                return false;
            }
            var paramType9 = parameters[9].ParameterType;
            if (!paramType9.IsValidInput<TArg9>(1024, ref pAddress))
            {
                return false;
            }
            var paramType10 = parameters[10].ParameterType;
            if (!paramType10.IsValidInput<TArg10>(2048, ref pAddress))
            {
                return false;
            }
            var paramType11 = parameters[11].ParameterType;
            if (!paramType11.IsValidInput<TArg11>(4096, ref pAddress))
            {
                return false;
            }
            if (pAddress != 0)
            {
                return false;
            }
            pAddress = method.GetFunctionPointer();
            return true;
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool SecondaryValidateInstanceMethodRaw(MethodBase method, Type target, Type arg0, Type arg1, Type arg2, Type arg3, Type arg4, Type arg5, Type arg6, Type arg7, Type arg8, Type arg9, Type arg10, Type arg11, ref nint pAddress)
        {
            if ((pAddress & 1) != 0)
            {
                var reflectedType = method.ReflectedType;
                if (!reflectedType.IsNullAssignableFromFast(target))
                {
                    return false;
                }
            }
            var parameters = method.GetParametersFast();
            if ((pAddress & 2) != 0)
            {
                var paramType = parameters[0].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg0))
                {
                    return false;
                }
            }
            if ((pAddress & 4) != 0)
            {
                var paramType = parameters[1].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg1))
                {
                    return false;
                }
            }
            if ((pAddress & 8) != 0)
            {
                var paramType = parameters[2].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg2))
                {
                    return false;
                }
            }
            if ((pAddress & 16) != 0)
            {
                var paramType = parameters[3].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg3))
                {
                    return false;
                }
            }
            if ((pAddress & 32) != 0)
            {
                var paramType = parameters[4].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg4))
                {
                    return false;
                }
            }
            if ((pAddress & 64) != 0)
            {
                var paramType = parameters[5].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg5))
                {
                    return false;
                }
            }
            if ((pAddress & 128) != 0)
            {
                var paramType = parameters[6].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg6))
                {
                    return false;
                }
            }
            if ((pAddress & 256) != 0)
            {
                var paramType = parameters[7].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg7))
                {
                    return false;
                }
            }
            if ((pAddress & 512) != 0)
            {
                var paramType = parameters[8].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg8))
                {
                    return false;
                }
            }
            if ((pAddress & 1024) != 0)
            {
                var paramType = parameters[9].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg9))
                {
                    return false;
                }
            }
            if ((pAddress & 2048) != 0)
            {
                var paramType = parameters[10].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg10))
                {
                    return false;
                }
            }
            if ((pAddress & 4096) != 0)
            {
                var paramType = parameters[11].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg11))
                {
                    return false;
                }
            }
            pAddress = method.GetFunctionPointer();
            return true;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void InvokeStaticFast<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(this MethodBase self, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9, in TArg10 arg10, in TArg11 arg11)
        {
            bool isValid;
            nint pAddress;
            isValid = ValidateStaticMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(self, out pAddress) ||
                      (pAddress != 0 && SecondaryValidateStaticMethod(self, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), arg11?.GetType(), ref pAddress));
            if (!isValid)
            {
                self.InvokeStaticLowAlloc(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
                return;
            }
            unsafe
            {
                ((delegate*<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, void>)pAddress)(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
                return;
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static object InvokeStaticLowAlloc<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(this MethodBase self, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9, in TArg10 arg10, in TArg11 arg11)
        {
            if (self.IsGenericMethodDefinition)
            {
                ValidateGenericMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(ref self);
            }
            var parameters = self.GetParametersFast();
            ArrayCache.Objects12[0] = REReflection.GetBox(arg0, parameters[0], out var refArg0);
            ArrayCache.Objects12[1] = REReflection.GetBox(arg1, parameters[1], out var refArg1);
            ArrayCache.Objects12[2] = REReflection.GetBox(arg2, parameters[2], out var refArg2);
            ArrayCache.Objects12[3] = REReflection.GetBox(arg3, parameters[3], out var refArg3);
            ArrayCache.Objects12[4] = REReflection.GetBox(arg4, parameters[4], out var refArg4);
            ArrayCache.Objects12[5] = REReflection.GetBox(arg5, parameters[5], out var refArg5);
            ArrayCache.Objects12[6] = REReflection.GetBox(arg6, parameters[6], out var refArg6);
            ArrayCache.Objects12[7] = REReflection.GetBox(arg7, parameters[7], out var refArg7);
            ArrayCache.Objects12[8] = REReflection.GetBox(arg8, parameters[8], out var refArg8);
            ArrayCache.Objects12[9] = REReflection.GetBox(arg9, parameters[9], out var refArg9);
            ArrayCache.Objects12[10] = REReflection.GetBox(arg10, parameters[10], out var refArg10);
            ArrayCache.Objects12[11] = REReflection.GetBox(arg11, parameters[11], out var refArg11);
            try
            {
                return self.Invoke(null, ArrayCache.Objects12);
            }
            finally
            {
                REReflection.ReturnBox<TArg0>(ArrayCache.Objects12[0], parameters[0], refArg0);
                REReflection.ReturnBox<TArg1>(ArrayCache.Objects12[1], parameters[1], refArg1);
                REReflection.ReturnBox<TArg2>(ArrayCache.Objects12[2], parameters[2], refArg2);
                REReflection.ReturnBox<TArg3>(ArrayCache.Objects12[3], parameters[3], refArg3);
                REReflection.ReturnBox<TArg4>(ArrayCache.Objects12[4], parameters[4], refArg4);
                REReflection.ReturnBox<TArg5>(ArrayCache.Objects12[5], parameters[5], refArg5);
                REReflection.ReturnBox<TArg6>(ArrayCache.Objects12[6], parameters[6], refArg6);
                REReflection.ReturnBox<TArg7>(ArrayCache.Objects12[7], parameters[7], refArg7);
                REReflection.ReturnBox<TArg8>(ArrayCache.Objects12[8], parameters[8], refArg8);
                REReflection.ReturnBox<TArg9>(ArrayCache.Objects12[9], parameters[9], refArg9);
                REReflection.ReturnBox<TArg10>(ArrayCache.Objects12[10], parameters[10], refArg10);
                REReflection.ReturnBox<TArg11>(ArrayCache.Objects12[11], parameters[11], refArg11);
            }
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool ValidateStaticMethodRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(MethodBase method, out nint pAddress)
        {
            pAddress = 0;
            if (!method.IsStatic)
            {
                return false;
            }
            if (method.IsOverridable())
            {
                return false;
            }
            var isValidGeneric = !method.IsGenericMethodDefinition || ValidateGenericMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(ref method);
            if (!isValidGeneric)
            {
                return false;
            }
            var parameters = method.GetParametersFast();
            var parameterLength = parameters.Count;
            if (parameterLength != 12)
            {
                return false;
            }
            if (method is MethodInfo mi)
            {
                var returnType = mi?.ReturnType ?? typeof(void);
                if (returnType != typeof(void))
                {
                    return false;
                }
            }
            var paramType0 = parameters[0].ParameterType;
            if (!paramType0.IsValidInput<TArg0>(2, ref pAddress))
            {
                return false;
            }
            var paramType1 = parameters[1].ParameterType;
            if (!paramType1.IsValidInput<TArg1>(4, ref pAddress))
            {
                return false;
            }
            var paramType2 = parameters[2].ParameterType;
            if (!paramType2.IsValidInput<TArg2>(8, ref pAddress))
            {
                return false;
            }
            var paramType3 = parameters[3].ParameterType;
            if (!paramType3.IsValidInput<TArg3>(16, ref pAddress))
            {
                return false;
            }
            var paramType4 = parameters[4].ParameterType;
            if (!paramType4.IsValidInput<TArg4>(32, ref pAddress))
            {
                return false;
            }
            var paramType5 = parameters[5].ParameterType;
            if (!paramType5.IsValidInput<TArg5>(64, ref pAddress))
            {
                return false;
            }
            var paramType6 = parameters[6].ParameterType;
            if (!paramType6.IsValidInput<TArg6>(128, ref pAddress))
            {
                return false;
            }
            var paramType7 = parameters[7].ParameterType;
            if (!paramType7.IsValidInput<TArg7>(256, ref pAddress))
            {
                return false;
            }
            var paramType8 = parameters[8].ParameterType;
            if (!paramType8.IsValidInput<TArg8>(512, ref pAddress))
            {
                return false;
            }
            var paramType9 = parameters[9].ParameterType;
            if (!paramType9.IsValidInput<TArg9>(1024, ref pAddress))
            {
                return false;
            }
            var paramType10 = parameters[10].ParameterType;
            if (!paramType10.IsValidInput<TArg10>(2048, ref pAddress))
            {
                return false;
            }
            var paramType11 = parameters[11].ParameterType;
            if (!paramType11.IsValidInput<TArg11>(4096, ref pAddress))
            {
                return false;
            }
            if (pAddress != 0)
            {
                return false;
            }
            pAddress = method.GetFunctionPointer();
            return true;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TReturn InvokeStaticFast<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TReturn>(this MethodBase self, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9, in TArg10 arg10, in TArg11 arg11)
        {
            bool isValid;
            nint pAddress;
            isValid = ValidateStaticReturnableMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TReturn>(self, out pAddress) ||
                      (pAddress != 0 && SecondaryValidateStaticMethod(self, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), arg11?.GetType(), ref pAddress));
            if (!isValid)
            {
                return (TReturn)self.InvokeStaticLowAlloc(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
            }
            unsafe
            {
                return ((delegate*<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TReturn>)pAddress)(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
            }
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool ValidateStaticReturnableMethodRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TReturn>(MethodBase method, out nint pAddress)
        {
            pAddress = 0;
            if (!method.IsStatic)
            {
                return false;
            }
            if (method.IsOverridable())
            {
                return false;
            }
            var isValidGeneric = !method.IsGenericMethodDefinition || ValidateGenericReturnableMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TReturn>(ref method);
            if (!isValidGeneric)
            {
                return false;
            }
            var parameters = method.GetParametersFast();
            var parameterLength = parameters.Count;
            if (parameterLength != 12)
            {
                return false;
            }
            if (method is MethodInfo mi)
            {
                var returnType = mi?.ReturnType ?? typeof(void);
                if (!returnType.IsValidOutput<TReturn>())
                {
                    return false;
                }
            }
            var paramType0 = parameters[0].ParameterType;
            if (!paramType0.IsValidInput<TArg0>(2, ref pAddress))
            {
                return false;
            }
            var paramType1 = parameters[1].ParameterType;
            if (!paramType1.IsValidInput<TArg1>(4, ref pAddress))
            {
                return false;
            }
            var paramType2 = parameters[2].ParameterType;
            if (!paramType2.IsValidInput<TArg2>(8, ref pAddress))
            {
                return false;
            }
            var paramType3 = parameters[3].ParameterType;
            if (!paramType3.IsValidInput<TArg3>(16, ref pAddress))
            {
                return false;
            }
            var paramType4 = parameters[4].ParameterType;
            if (!paramType4.IsValidInput<TArg4>(32, ref pAddress))
            {
                return false;
            }
            var paramType5 = parameters[5].ParameterType;
            if (!paramType5.IsValidInput<TArg5>(64, ref pAddress))
            {
                return false;
            }
            var paramType6 = parameters[6].ParameterType;
            if (!paramType6.IsValidInput<TArg6>(128, ref pAddress))
            {
                return false;
            }
            var paramType7 = parameters[7].ParameterType;
            if (!paramType7.IsValidInput<TArg7>(256, ref pAddress))
            {
                return false;
            }
            var paramType8 = parameters[8].ParameterType;
            if (!paramType8.IsValidInput<TArg8>(512, ref pAddress))
            {
                return false;
            }
            var paramType9 = parameters[9].ParameterType;
            if (!paramType9.IsValidInput<TArg9>(1024, ref pAddress))
            {
                return false;
            }
            var paramType10 = parameters[10].ParameterType;
            if (!paramType10.IsValidInput<TArg10>(2048, ref pAddress))
            {
                return false;
            }
            var paramType11 = parameters[11].ParameterType;
            if (!paramType11.IsValidInput<TArg11>(4096, ref pAddress))
            {
                return false;
            }
            if (pAddress != 0)
            {
                return false;
            }
            pAddress = method.GetFunctionPointer();
            return true;
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool SecondaryValidateStaticMethodRaw(MethodBase method, Type arg0, Type arg1, Type arg2, Type arg3, Type arg4, Type arg5, Type arg6, Type arg7, Type arg8, Type arg9, Type arg10, Type arg11, ref nint pAddress)
        {
            var parameters = method.GetParametersFast();
            if ((pAddress & 2) != 0)
            {
                var paramType = parameters[0].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg0))
                {
                    return false;
                }
            }
            if ((pAddress & 4) != 0)
            {
                var paramType = parameters[1].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg1))
                {
                    return false;
                }
            }
            if ((pAddress & 8) != 0)
            {
                var paramType = parameters[2].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg2))
                {
                    return false;
                }
            }
            if ((pAddress & 16) != 0)
            {
                var paramType = parameters[3].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg3))
                {
                    return false;
                }
            }
            if ((pAddress & 32) != 0)
            {
                var paramType = parameters[4].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg4))
                {
                    return false;
                }
            }
            if ((pAddress & 64) != 0)
            {
                var paramType = parameters[5].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg5))
                {
                    return false;
                }
            }
            if ((pAddress & 128) != 0)
            {
                var paramType = parameters[6].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg6))
                {
                    return false;
                }
            }
            if ((pAddress & 256) != 0)
            {
                var paramType = parameters[7].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg7))
                {
                    return false;
                }
            }
            if ((pAddress & 512) != 0)
            {
                var paramType = parameters[8].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg8))
                {
                    return false;
                }
            }
            if ((pAddress & 1024) != 0)
            {
                var paramType = parameters[9].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg9))
                {
                    return false;
                }
            }
            if ((pAddress & 2048) != 0)
            {
                var paramType = parameters[10].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg10))
                {
                    return false;
                }
            }
            if ((pAddress & 4096) != 0)
            {
                var paramType = parameters[11].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg11))
                {
                    return false;
                }
            }
            pAddress = method.GetFunctionPointer();
            return true;
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool ValidateGenericMethodRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(ref MethodBase method)
        {
            if (!method.IsGenericMethodDefinition)
            {
                return true;
            }
            var genericArguments = method.GetGenericArgumentsFast();
            if (genericArguments.Count < 12)
            {
                return false;
            }
            uint mask = 0;
            var mi = method as MethodInfo;
            var parameters = method.GetParametersFast();
            var index0 = IndexOf(genericArguments, parameters[0].ParameterType);
            if (index0 >= 0)
            {
                mask |= 1u << index0;
            }
            var index1 = IndexOf(genericArguments, parameters[1].ParameterType);
            if (index1 >= 0)
            {
                mask |= 1u << index1;
            }
            var index2 = IndexOf(genericArguments, parameters[2].ParameterType);
            if (index2 >= 0)
            {
                mask |= 1u << index2;
            }
            var index3 = IndexOf(genericArguments, parameters[3].ParameterType);
            if (index3 >= 0)
            {
                mask |= 1u << index3;
            }
            var index4 = IndexOf(genericArguments, parameters[4].ParameterType);
            if (index4 >= 0)
            {
                mask |= 1u << index4;
            }
            var index5 = IndexOf(genericArguments, parameters[5].ParameterType);
            if (index5 >= 0)
            {
                mask |= 1u << index5;
            }
            var index6 = IndexOf(genericArguments, parameters[6].ParameterType);
            if (index6 >= 0)
            {
                mask |= 1u << index6;
            }
            var index7 = IndexOf(genericArguments, parameters[7].ParameterType);
            if (index7 >= 0)
            {
                mask |= 1u << index7;
            }
            var index8 = IndexOf(genericArguments, parameters[8].ParameterType);
            if (index8 >= 0)
            {
                mask |= 1u << index8;
            }
            var index9 = IndexOf(genericArguments, parameters[9].ParameterType);
            if (index9 >= 0)
            {
                mask |= 1u << index9;
            }
            var index10 = IndexOf(genericArguments, parameters[10].ParameterType);
            if (index10 >= 0)
            {
                mask |= 1u << index10;
            }
            var index11 = IndexOf(genericArguments, parameters[11].ParameterType);
            if (index11 >= 0)
            {
                mask |= 1u << index11;
            }
            if (REReflection.BitCount(mask) != genericArguments.Count)
            {
                return false;
            }
            var types = ArrayCache.GetArrayCache<Type>(genericArguments.Count);
            if (index0 >= 0)
            {
                types[index0] = typeof(TArg0);
            }
            if (index1 >= 0)
            {
                types[index1] = typeof(TArg1);
            }
            if (index2 >= 0)
            {
                types[index2] = typeof(TArg2);
            }
            if (index3 >= 0)
            {
                types[index3] = typeof(TArg3);
            }
            if (index4 >= 0)
            {
                types[index4] = typeof(TArg4);
            }
            if (index5 >= 0)
            {
                types[index5] = typeof(TArg5);
            }
            if (index6 >= 0)
            {
                types[index6] = typeof(TArg6);
            }
            if (index7 >= 0)
            {
                types[index7] = typeof(TArg7);
            }
            if (index8 >= 0)
            {
                types[index8] = typeof(TArg8);
            }
            if (index9 >= 0)
            {
                types[index9] = typeof(TArg9);
            }
            if (index10 >= 0)
            {
                types[index10] = typeof(TArg10);
            }
            if (index11 >= 0)
            {
                types[index11] = typeof(TArg11);
            }
            #if ENABLE_IL2CPP
            bool isFound = false;
            var usingMethods = method.GetUsingGenericInstanceMethods();
            foreach (var usingMethod in usingMethods)
            {
                if (usingMethod.GetGenericArgumentsFast().SequenceEqual(types))
                {
                    isFound = true;
                    break;
                }
            }
            if (!isFound)
            {
                return false;
            }
            #endif
            method = mi.MakeGenericMethodFast(types);
            return true;
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool ValidateGenericReturnableMethodRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TReturn>(ref MethodBase method)
        {
            if (!method.IsGenericMethodDefinition)
            {
                return true;
            }
            var genericArguments = method.GetGenericArgumentsFast();
            if (genericArguments.Count < 13)
            {
                return false;
            }
            uint mask = 0;
            var mi = method as MethodInfo;
            var returnType = mi.ReturnType ?? typeof(void);
            var index = IndexOf(genericArguments, returnType);
            if (index >= 0)
            {
                mask |= 1u << index;
            }
            var parameters = method.GetParametersFast();
            var index0 = IndexOf(genericArguments, parameters[0].ParameterType);
            if (index0 >= 0)
            {
                mask |= 1u << index0;
            }
            var index1 = IndexOf(genericArguments, parameters[1].ParameterType);
            if (index1 >= 0)
            {
                mask |= 1u << index1;
            }
            var index2 = IndexOf(genericArguments, parameters[2].ParameterType);
            if (index2 >= 0)
            {
                mask |= 1u << index2;
            }
            var index3 = IndexOf(genericArguments, parameters[3].ParameterType);
            if (index3 >= 0)
            {
                mask |= 1u << index3;
            }
            var index4 = IndexOf(genericArguments, parameters[4].ParameterType);
            if (index4 >= 0)
            {
                mask |= 1u << index4;
            }
            var index5 = IndexOf(genericArguments, parameters[5].ParameterType);
            if (index5 >= 0)
            {
                mask |= 1u << index5;
            }
            var index6 = IndexOf(genericArguments, parameters[6].ParameterType);
            if (index6 >= 0)
            {
                mask |= 1u << index6;
            }
            var index7 = IndexOf(genericArguments, parameters[7].ParameterType);
            if (index7 >= 0)
            {
                mask |= 1u << index7;
            }
            var index8 = IndexOf(genericArguments, parameters[8].ParameterType);
            if (index8 >= 0)
            {
                mask |= 1u << index8;
            }
            var index9 = IndexOf(genericArguments, parameters[9].ParameterType);
            if (index9 >= 0)
            {
                mask |= 1u << index9;
            }
            var index10 = IndexOf(genericArguments, parameters[10].ParameterType);
            if (index10 >= 0)
            {
                mask |= 1u << index10;
            }
            var index11 = IndexOf(genericArguments, parameters[11].ParameterType);
            if (index11 >= 0)
            {
                mask |= 1u << index11;
            }
            if (REReflection.BitCount(mask) != genericArguments.Count)
            {
                return false;
            }
            var types = ArrayCache.GetArrayCache<Type>(genericArguments.Count);
            if (index >= 0)
            {
                types[index] = typeof(TReturn);
            }
            if (index0 >= 0)
            {
                types[index0] = typeof(TArg0);
            }
            if (index1 >= 0)
            {
                types[index1] = typeof(TArg1);
            }
            if (index2 >= 0)
            {
                types[index2] = typeof(TArg2);
            }
            if (index3 >= 0)
            {
                types[index3] = typeof(TArg3);
            }
            if (index4 >= 0)
            {
                types[index4] = typeof(TArg4);
            }
            if (index5 >= 0)
            {
                types[index5] = typeof(TArg5);
            }
            if (index6 >= 0)
            {
                types[index6] = typeof(TArg6);
            }
            if (index7 >= 0)
            {
                types[index7] = typeof(TArg7);
            }
            if (index8 >= 0)
            {
                types[index8] = typeof(TArg8);
            }
            if (index9 >= 0)
            {
                types[index9] = typeof(TArg9);
            }
            if (index10 >= 0)
            {
                types[index10] = typeof(TArg10);
            }
            if (index11 >= 0)
            {
                types[index11] = typeof(TArg11);
            }
            #if ENABLE_IL2CPP
            bool isFound = false;
            var usingMethods = method.GetUsingGenericInstanceMethods();
            foreach (var usingMethod in usingMethods)
            {
                if (usingMethod.GetGenericArgumentsFast().SequenceEqual(types))
                {
                    isFound = true;
                    break;
                }
            }
            if (!isFound)
            {
                return false;
            }
            #endif
            method = mi.MakeGenericMethodFast(types);
            return true;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void InvokeInstanceFast<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(this MethodBase self, ref TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9, in TArg10 arg10, in TArg11 arg11, in TArg12 arg12)
        {
            bool isValid;
            nint pAddress;
            if (self.IsOverridable())
            {
                isValid = ValidateInstanceVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(self, target?.GetType(), out pAddress) ||
                          (pAddress != 0 && SecondaryValidateStaticMethod(self, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), arg11?.GetType(), arg12?.GetType(), ref pAddress));
            }
            else
            {
                isValid = ValidateInstanceMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(self, out pAddress) ||
                          (pAddress != 0 && SecondaryValidateInstanceMethod(self, target?.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), arg11?.GetType(), arg12?.GetType(), ref pAddress));
            }
            if (!isValid)
            {
                self.InvokeInstanceLowAlloc(ref target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
                return;
            }
            unsafe
            {
                if (REType.IsValueTypeFast<TTarget>())
                {
                    ((delegate*<ref TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, void>)pAddress)(ref target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
                    return;
                }
                ((delegate*<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, void>)pAddress)(target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
                return;
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void InvokeClassInstanceFast<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(this MethodBase self, TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9, in TArg10 arg10, in TArg11 arg11, in TArg12 arg12)
        where TTarget: class
        {
            bool isValid;
            nint pAddress;
            if (self.IsOverridable())
            {
                isValid = ValidateInstanceVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(self, target?.GetType(), out pAddress) ||
                          (pAddress != 0 && SecondaryValidateStaticMethod(self, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), arg11?.GetType(), arg12?.GetType(), ref pAddress));
            }
            else
            {
                isValid = ValidateInstanceMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(self, out pAddress) ||
                          (pAddress != 0 && SecondaryValidateInstanceMethod(self, target?.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), arg11?.GetType(), arg12?.GetType(), ref pAddress));
            }
            if (!isValid)
            {
                self.InvokeClassInstanceLowAlloc(target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
                return;
            }
            unsafe
            {
                ((delegate*<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, void>)pAddress)(target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
                return;
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void InvokeStructInstanceFast<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(this MethodBase self, ref TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9, in TArg10 arg10, in TArg11 arg11, in TArg12 arg12)
        where TTarget: struct
        {
            bool isValid;
            nint pAddress;
            if (self.IsOverridable())
            {
                isValid = ValidateInstanceVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(self, target.GetType(), out pAddress) ||
                          (pAddress != 0 && SecondaryValidateStaticMethod(self, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), arg11?.GetType(), arg12?.GetType(), ref pAddress));
            }
            else
            {
                isValid = ValidateInstanceMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(self, out pAddress) ||
                          (pAddress != 0 && SecondaryValidateInstanceMethod(self, target.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), arg11?.GetType(), arg12?.GetType(), ref pAddress));
            }
            if (!isValid)
            {
                self.InvokeInstanceLowAlloc(ref target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
                return;
            }
            unsafe
            {
                ((delegate*<ref TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, void>)pAddress)(ref target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
                return;
            }
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool ValidateInstanceMethodRaw<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(MethodBase method, out nint pAddress)
        {
            pAddress = 0;
            if (method.IsStatic)
            {
                return false;
            }
            if (method.IsOverridable())
            {
                return false;
            }
            var isValidGeneric = !method.IsGenericMethodDefinition || ValidateGenericMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(ref method);
            if (!isValidGeneric)
            {
                return false;
            }
            var parameters = method.GetParametersFast();
            var parameterLength = parameters.Count;
            if (parameterLength != 13)
            {
                return false;
            }
            if (method is MethodInfo mi)
            {
                var returnType = mi?.ReturnType ?? typeof(void);
                if (returnType != typeof(void))
                {
                    return false;
                }
            }
            var reflectedType = method.ReflectedType;
            if (!reflectedType.IsValidInputWithoutRef<TTarget>(1, ref pAddress))
            {
                return false;
            }
            var paramType0 = parameters[0].ParameterType;
            if (!paramType0.IsValidInput<TArg0>(2, ref pAddress))
            {
                return false;
            }
            var paramType1 = parameters[1].ParameterType;
            if (!paramType1.IsValidInput<TArg1>(4, ref pAddress))
            {
                return false;
            }
            var paramType2 = parameters[2].ParameterType;
            if (!paramType2.IsValidInput<TArg2>(8, ref pAddress))
            {
                return false;
            }
            var paramType3 = parameters[3].ParameterType;
            if (!paramType3.IsValidInput<TArg3>(16, ref pAddress))
            {
                return false;
            }
            var paramType4 = parameters[4].ParameterType;
            if (!paramType4.IsValidInput<TArg4>(32, ref pAddress))
            {
                return false;
            }
            var paramType5 = parameters[5].ParameterType;
            if (!paramType5.IsValidInput<TArg5>(64, ref pAddress))
            {
                return false;
            }
            var paramType6 = parameters[6].ParameterType;
            if (!paramType6.IsValidInput<TArg6>(128, ref pAddress))
            {
                return false;
            }
            var paramType7 = parameters[7].ParameterType;
            if (!paramType7.IsValidInput<TArg7>(256, ref pAddress))
            {
                return false;
            }
            var paramType8 = parameters[8].ParameterType;
            if (!paramType8.IsValidInput<TArg8>(512, ref pAddress))
            {
                return false;
            }
            var paramType9 = parameters[9].ParameterType;
            if (!paramType9.IsValidInput<TArg9>(1024, ref pAddress))
            {
                return false;
            }
            var paramType10 = parameters[10].ParameterType;
            if (!paramType10.IsValidInput<TArg10>(2048, ref pAddress))
            {
                return false;
            }
            var paramType11 = parameters[11].ParameterType;
            if (!paramType11.IsValidInput<TArg11>(4096, ref pAddress))
            {
                return false;
            }
            var paramType12 = parameters[12].ParameterType;
            if (!paramType12.IsValidInput<TArg12>(8192, ref pAddress))
            {
                return false;
            }
            if (pAddress != 0)
            {
                return false;
            }
            pAddress = method.GetFunctionPointer();
            return true;
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool ValidateInstanceVirtualMethodRaw<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(MethodBase method, Type targetType, out nint pAddress)
        {
            pAddress = 0;
            if (method.IsStatic)
            {
                return false;
            }
            if (!method.IsOverridable())
            {
                return false;
            }
            var isValidGeneric = !method.IsGenericMethodDefinition || ValidateGenericMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(ref method);
            if (!isValidGeneric)
            {
                return false;
            }
            var parameters = method.GetParametersFast();
            var parameterLength = parameters.Count;
            if (parameterLength != 13)
            {
                return false;
            }
            if (method is MethodInfo mi)
            {
                var returnType = mi?.ReturnType ?? typeof(void);
                if (returnType != typeof(void))
                {
                    return false;
                }
            }
            var reflectedType = method.ReflectedType;
            if (!reflectedType.IsValidVirtualInput<TTarget>(targetType, out var isVirtualCall))
            {
                return false;
            }
            if (isVirtualCall)
            {
                ArrayCache.Types13[0] = parameters[0].ParameterType;
                ArrayCache.Types13[1] = parameters[1].ParameterType;
                ArrayCache.Types13[2] = parameters[2].ParameterType;
                ArrayCache.Types13[3] = parameters[3].ParameterType;
                ArrayCache.Types13[4] = parameters[4].ParameterType;
                ArrayCache.Types13[5] = parameters[5].ParameterType;
                ArrayCache.Types13[6] = parameters[6].ParameterType;
                ArrayCache.Types13[7] = parameters[7].ParameterType;
                ArrayCache.Types13[8] = parameters[8].ParameterType;
                ArrayCache.Types13[9] = parameters[9].ParameterType;
                ArrayCache.Types13[10] = parameters[10].ParameterType;
                ArrayCache.Types13[11] = parameters[11].ParameterType;
                ArrayCache.Types13[12] = parameters[12].ParameterType;
                method = targetType.GetInstanceMethodFullAccess(method.Name, null, ArrayCache.Types13, null);
            }
            var paramType0 = parameters[0].ParameterType;
            if (!paramType0.IsValidInput<TArg0>(2, ref pAddress))
            {
                return false;
            }
            var paramType1 = parameters[1].ParameterType;
            if (!paramType1.IsValidInput<TArg1>(4, ref pAddress))
            {
                return false;
            }
            var paramType2 = parameters[2].ParameterType;
            if (!paramType2.IsValidInput<TArg2>(8, ref pAddress))
            {
                return false;
            }
            var paramType3 = parameters[3].ParameterType;
            if (!paramType3.IsValidInput<TArg3>(16, ref pAddress))
            {
                return false;
            }
            var paramType4 = parameters[4].ParameterType;
            if (!paramType4.IsValidInput<TArg4>(32, ref pAddress))
            {
                return false;
            }
            var paramType5 = parameters[5].ParameterType;
            if (!paramType5.IsValidInput<TArg5>(64, ref pAddress))
            {
                return false;
            }
            var paramType6 = parameters[6].ParameterType;
            if (!paramType6.IsValidInput<TArg6>(128, ref pAddress))
            {
                return false;
            }
            var paramType7 = parameters[7].ParameterType;
            if (!paramType7.IsValidInput<TArg7>(256, ref pAddress))
            {
                return false;
            }
            var paramType8 = parameters[8].ParameterType;
            if (!paramType8.IsValidInput<TArg8>(512, ref pAddress))
            {
                return false;
            }
            var paramType9 = parameters[9].ParameterType;
            if (!paramType9.IsValidInput<TArg9>(1024, ref pAddress))
            {
                return false;
            }
            var paramType10 = parameters[10].ParameterType;
            if (!paramType10.IsValidInput<TArg10>(2048, ref pAddress))
            {
                return false;
            }
            var paramType11 = parameters[11].ParameterType;
            if (!paramType11.IsValidInput<TArg11>(4096, ref pAddress))
            {
                return false;
            }
            var paramType12 = parameters[12].ParameterType;
            if (!paramType12.IsValidInput<TArg12>(8192, ref pAddress))
            {
                return false;
            }
            if (pAddress != 0)
            {
                return false;
            }
            pAddress = method.GetFunctionPointer();
            return true;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TReturn InvokeInstanceFast<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TReturn>(this MethodBase self, ref TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9, in TArg10 arg10, in TArg11 arg11, in TArg12 arg12)
        {
            bool isValid;
            nint pAddress;
            if (self.IsOverridable())
            {
                isValid = ValidateInstanceReturnableVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TReturn>(self, target?.GetType(), out pAddress) ||
                          (pAddress != 0 && SecondaryValidateStaticMethod(self, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), arg11?.GetType(), arg12?.GetType(), ref pAddress));
            }
            else
            {
                isValid = ValidateInstanceReturnableMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TReturn>(self, out pAddress) ||
                          (pAddress != 0 && SecondaryValidateInstanceMethod(self, target?.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), arg11?.GetType(), arg12?.GetType(), ref pAddress));
            }
            if (!isValid)
            {
                return (TReturn)self.InvokeInstanceLowAlloc(ref target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
            }
            unsafe
            {
                if (REType.IsValueTypeFast<TTarget>())
                {
                    return ((delegate*<ref TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TReturn>)pAddress)(ref target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
                }
                return ((delegate*<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TReturn>)pAddress)(target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TReturn InvokeClassInstanceFast<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TReturn>(this MethodBase self, TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9, in TArg10 arg10, in TArg11 arg11, in TArg12 arg12)
        where TTarget: class
        {
            bool isValid;
            nint pAddress;
            if (self.IsOverridable())
            {
                isValid = ValidateInstanceReturnableVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TReturn>(self, target?.GetType(), out pAddress) ||
                          (pAddress != 0 && SecondaryValidateStaticMethod(self, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), arg11?.GetType(), arg12?.GetType(), ref pAddress));
            }
            else
            {
                isValid = ValidateInstanceReturnableMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TReturn>(self, out pAddress) ||
                          (pAddress != 0 && SecondaryValidateInstanceMethod(self, target?.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), arg11?.GetType(), arg12?.GetType(), ref pAddress));
            }
            if (!isValid)
            {
                return (TReturn)self.InvokeClassInstanceLowAlloc(target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
            }
            unsafe
            {
                return ((delegate*<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TReturn>)pAddress)(target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TReturn InvokeStructInstanceFast<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TReturn>(this MethodBase self, ref TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9, in TArg10 arg10, in TArg11 arg11, in TArg12 arg12)
        where TTarget: struct
        {
            bool isValid;
            nint pAddress;
            if (self.IsOverridable())
            {
                isValid = ValidateInstanceReturnableVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TReturn>(self, target.GetType(), out pAddress) ||
                          (pAddress != 0 && SecondaryValidateStaticMethod(self, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), arg11?.GetType(), arg12?.GetType(), ref pAddress));
            }
            else
            {
                isValid = ValidateInstanceReturnableMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TReturn>(self, out pAddress) ||
                          (pAddress != 0 && SecondaryValidateInstanceMethod(self, target.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), arg11?.GetType(), arg12?.GetType(), ref pAddress));
            }
            if (!isValid)
            {
                return (TReturn)self.InvokeInstanceLowAlloc(ref target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
            }
            unsafe
            {
                return ((delegate*<ref TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TReturn>)pAddress)(ref target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static object InvokeInstanceLowAlloc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(this MethodBase self, ref TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9, in TArg10 arg10, in TArg11 arg11, in TArg12 arg12)
        {
            if (self.IsGenericMethodDefinition)
            {
                ValidateGenericMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(ref self);
            }
            var targetObj = REReflection.GetBoxWithoutRef(target);
            var parameters = self.GetParametersFast();
            ArrayCache.Objects13[0] = REReflection.GetBox(arg0, parameters[0], out var refArg0);
            ArrayCache.Objects13[1] = REReflection.GetBox(arg1, parameters[1], out var refArg1);
            ArrayCache.Objects13[2] = REReflection.GetBox(arg2, parameters[2], out var refArg2);
            ArrayCache.Objects13[3] = REReflection.GetBox(arg3, parameters[3], out var refArg3);
            ArrayCache.Objects13[4] = REReflection.GetBox(arg4, parameters[4], out var refArg4);
            ArrayCache.Objects13[5] = REReflection.GetBox(arg5, parameters[5], out var refArg5);
            ArrayCache.Objects13[6] = REReflection.GetBox(arg6, parameters[6], out var refArg6);
            ArrayCache.Objects13[7] = REReflection.GetBox(arg7, parameters[7], out var refArg7);
            ArrayCache.Objects13[8] = REReflection.GetBox(arg8, parameters[8], out var refArg8);
            ArrayCache.Objects13[9] = REReflection.GetBox(arg9, parameters[9], out var refArg9);
            ArrayCache.Objects13[10] = REReflection.GetBox(arg10, parameters[10], out var refArg10);
            ArrayCache.Objects13[11] = REReflection.GetBox(arg11, parameters[11], out var refArg11);
            ArrayCache.Objects13[12] = REReflection.GetBox(arg12, parameters[12], out var refArg12);
            try
            {
                return self.Invoke(targetObj, ArrayCache.Objects13);
            }
            finally
            {
                REReflection.Unbox(targetObj, out target);
                REReflection.ReturnBoxWithoutRef<TTarget>(targetObj);
                REReflection.ReturnBox<TArg0>(ArrayCache.Objects13[0], parameters[0], refArg0);
                REReflection.ReturnBox<TArg1>(ArrayCache.Objects13[1], parameters[1], refArg1);
                REReflection.ReturnBox<TArg2>(ArrayCache.Objects13[2], parameters[2], refArg2);
                REReflection.ReturnBox<TArg3>(ArrayCache.Objects13[3], parameters[3], refArg3);
                REReflection.ReturnBox<TArg4>(ArrayCache.Objects13[4], parameters[4], refArg4);
                REReflection.ReturnBox<TArg5>(ArrayCache.Objects13[5], parameters[5], refArg5);
                REReflection.ReturnBox<TArg6>(ArrayCache.Objects13[6], parameters[6], refArg6);
                REReflection.ReturnBox<TArg7>(ArrayCache.Objects13[7], parameters[7], refArg7);
                REReflection.ReturnBox<TArg8>(ArrayCache.Objects13[8], parameters[8], refArg8);
                REReflection.ReturnBox<TArg9>(ArrayCache.Objects13[9], parameters[9], refArg9);
                REReflection.ReturnBox<TArg10>(ArrayCache.Objects13[10], parameters[10], refArg10);
                REReflection.ReturnBox<TArg11>(ArrayCache.Objects13[11], parameters[11], refArg11);
                REReflection.ReturnBox<TArg12>(ArrayCache.Objects13[12], parameters[12], refArg12);
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static object InvokeClassInstanceLowAlloc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(this MethodBase self, TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9, in TArg10 arg10, in TArg11 arg11, in TArg12 arg12)
        where TTarget: class
        {
            if (self.IsGenericMethodDefinition)
            {
                ValidateGenericMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(ref self);
            }
            var parameters = self.GetParametersFast();
            ArrayCache.Objects13[0] = REReflection.GetBox(arg0, parameters[0], out var refArg0);
            ArrayCache.Objects13[1] = REReflection.GetBox(arg1, parameters[1], out var refArg1);
            ArrayCache.Objects13[2] = REReflection.GetBox(arg2, parameters[2], out var refArg2);
            ArrayCache.Objects13[3] = REReflection.GetBox(arg3, parameters[3], out var refArg3);
            ArrayCache.Objects13[4] = REReflection.GetBox(arg4, parameters[4], out var refArg4);
            ArrayCache.Objects13[5] = REReflection.GetBox(arg5, parameters[5], out var refArg5);
            ArrayCache.Objects13[6] = REReflection.GetBox(arg6, parameters[6], out var refArg6);
            ArrayCache.Objects13[7] = REReflection.GetBox(arg7, parameters[7], out var refArg7);
            ArrayCache.Objects13[8] = REReflection.GetBox(arg8, parameters[8], out var refArg8);
            ArrayCache.Objects13[9] = REReflection.GetBox(arg9, parameters[9], out var refArg9);
            ArrayCache.Objects13[10] = REReflection.GetBox(arg10, parameters[10], out var refArg10);
            ArrayCache.Objects13[11] = REReflection.GetBox(arg11, parameters[11], out var refArg11);
            ArrayCache.Objects13[12] = REReflection.GetBox(arg12, parameters[12], out var refArg12);
            try
            {
                return self.Invoke(target, ArrayCache.Objects13);
            }
            finally
            {
                REReflection.ReturnBox<TArg0>(ArrayCache.Objects13[0], parameters[0], refArg0);
                REReflection.ReturnBox<TArg1>(ArrayCache.Objects13[1], parameters[1], refArg1);
                REReflection.ReturnBox<TArg2>(ArrayCache.Objects13[2], parameters[2], refArg2);
                REReflection.ReturnBox<TArg3>(ArrayCache.Objects13[3], parameters[3], refArg3);
                REReflection.ReturnBox<TArg4>(ArrayCache.Objects13[4], parameters[4], refArg4);
                REReflection.ReturnBox<TArg5>(ArrayCache.Objects13[5], parameters[5], refArg5);
                REReflection.ReturnBox<TArg6>(ArrayCache.Objects13[6], parameters[6], refArg6);
                REReflection.ReturnBox<TArg7>(ArrayCache.Objects13[7], parameters[7], refArg7);
                REReflection.ReturnBox<TArg8>(ArrayCache.Objects13[8], parameters[8], refArg8);
                REReflection.ReturnBox<TArg9>(ArrayCache.Objects13[9], parameters[9], refArg9);
                REReflection.ReturnBox<TArg10>(ArrayCache.Objects13[10], parameters[10], refArg10);
                REReflection.ReturnBox<TArg11>(ArrayCache.Objects13[11], parameters[11], refArg11);
                REReflection.ReturnBox<TArg12>(ArrayCache.Objects13[12], parameters[12], refArg12);
            }
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool ValidateInstanceReturnableMethodRaw<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TReturn>(MethodBase method, out nint pAddress)
        {
            pAddress = 0;
            if (method.IsStatic)
            {
                return false;
            }
            if (method.IsOverridable())
            {
                return false;
            }
            var isValidGeneric = !method.IsGenericMethodDefinition || ValidateGenericReturnableMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TReturn>(ref method);
            if (!isValidGeneric)
            {
                return false;
            }
            var parameters = method.GetParametersFast();
            var parameterLength = parameters.Count;
            if (parameterLength != 13)
            {
                return false;
            }
            if (method is MethodInfo mi)
            {
                var returnType = mi?.ReturnType ?? typeof(void);
                if (!returnType.IsValidOutput<TReturn>())
                {
                    return false;
                }
            }
            var reflectedType = method.ReflectedType;
            if (!reflectedType.IsValidInputWithoutRef<TTarget>(1, ref pAddress))
            {
                return false;
            }
            var paramType0 = parameters[0].ParameterType;
            if (!paramType0.IsValidInput<TArg0>(2, ref pAddress))
            {
                return false;
            }
            var paramType1 = parameters[1].ParameterType;
            if (!paramType1.IsValidInput<TArg1>(4, ref pAddress))
            {
                return false;
            }
            var paramType2 = parameters[2].ParameterType;
            if (!paramType2.IsValidInput<TArg2>(8, ref pAddress))
            {
                return false;
            }
            var paramType3 = parameters[3].ParameterType;
            if (!paramType3.IsValidInput<TArg3>(16, ref pAddress))
            {
                return false;
            }
            var paramType4 = parameters[4].ParameterType;
            if (!paramType4.IsValidInput<TArg4>(32, ref pAddress))
            {
                return false;
            }
            var paramType5 = parameters[5].ParameterType;
            if (!paramType5.IsValidInput<TArg5>(64, ref pAddress))
            {
                return false;
            }
            var paramType6 = parameters[6].ParameterType;
            if (!paramType6.IsValidInput<TArg6>(128, ref pAddress))
            {
                return false;
            }
            var paramType7 = parameters[7].ParameterType;
            if (!paramType7.IsValidInput<TArg7>(256, ref pAddress))
            {
                return false;
            }
            var paramType8 = parameters[8].ParameterType;
            if (!paramType8.IsValidInput<TArg8>(512, ref pAddress))
            {
                return false;
            }
            var paramType9 = parameters[9].ParameterType;
            if (!paramType9.IsValidInput<TArg9>(1024, ref pAddress))
            {
                return false;
            }
            var paramType10 = parameters[10].ParameterType;
            if (!paramType10.IsValidInput<TArg10>(2048, ref pAddress))
            {
                return false;
            }
            var paramType11 = parameters[11].ParameterType;
            if (!paramType11.IsValidInput<TArg11>(4096, ref pAddress))
            {
                return false;
            }
            var paramType12 = parameters[12].ParameterType;
            if (!paramType12.IsValidInput<TArg12>(8192, ref pAddress))
            {
                return false;
            }
            if (pAddress != 0)
            {
                return false;
            }
            pAddress = method.GetFunctionPointer();
            return true;
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool ValidateInstanceReturnableVirtualMethodRaw<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TReturn>(MethodBase method, Type targetType, out nint pAddress)
        {
            pAddress = 0;
            if (method.IsStatic)
            {
                return false;
            }
            if (!method.IsOverridable())
            {
                return false;
            }
            var isValidGeneric = !method.IsGenericMethodDefinition || ValidateGenericReturnableMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TReturn>(ref method);
            if (!isValidGeneric)
            {
                return false;
            }
            var parameters = method.GetParametersFast();
            var parameterLength = parameters.Count;
            if (parameterLength != 13)
            {
                return false;
            }
            if (method is MethodInfo mi)
            {
                var returnType = mi?.ReturnType ?? typeof(void);
                if (!returnType.IsValidOutput<TReturn>())
                {
                    return false;
                }
            }
            var reflectedType = method.ReflectedType;
            if (!reflectedType.IsValidVirtualInput<TTarget>(targetType, out var isVirtualCall))
            {
                return false;
            }
            if (isVirtualCall)
            {
                ArrayCache.Types13[0] = parameters[0].ParameterType;
                ArrayCache.Types13[1] = parameters[1].ParameterType;
                ArrayCache.Types13[2] = parameters[2].ParameterType;
                ArrayCache.Types13[3] = parameters[3].ParameterType;
                ArrayCache.Types13[4] = parameters[4].ParameterType;
                ArrayCache.Types13[5] = parameters[5].ParameterType;
                ArrayCache.Types13[6] = parameters[6].ParameterType;
                ArrayCache.Types13[7] = parameters[7].ParameterType;
                ArrayCache.Types13[8] = parameters[8].ParameterType;
                ArrayCache.Types13[9] = parameters[9].ParameterType;
                ArrayCache.Types13[10] = parameters[10].ParameterType;
                ArrayCache.Types13[11] = parameters[11].ParameterType;
                ArrayCache.Types13[12] = parameters[12].ParameterType;
                method = targetType.GetInstanceMethodFullAccess(method.Name, null, ArrayCache.Types13, null);
            }
            var paramType0 = parameters[0].ParameterType;
            if (!paramType0.IsValidInput<TArg0>(2, ref pAddress))
            {
                return false;
            }
            var paramType1 = parameters[1].ParameterType;
            if (!paramType1.IsValidInput<TArg1>(4, ref pAddress))
            {
                return false;
            }
            var paramType2 = parameters[2].ParameterType;
            if (!paramType2.IsValidInput<TArg2>(8, ref pAddress))
            {
                return false;
            }
            var paramType3 = parameters[3].ParameterType;
            if (!paramType3.IsValidInput<TArg3>(16, ref pAddress))
            {
                return false;
            }
            var paramType4 = parameters[4].ParameterType;
            if (!paramType4.IsValidInput<TArg4>(32, ref pAddress))
            {
                return false;
            }
            var paramType5 = parameters[5].ParameterType;
            if (!paramType5.IsValidInput<TArg5>(64, ref pAddress))
            {
                return false;
            }
            var paramType6 = parameters[6].ParameterType;
            if (!paramType6.IsValidInput<TArg6>(128, ref pAddress))
            {
                return false;
            }
            var paramType7 = parameters[7].ParameterType;
            if (!paramType7.IsValidInput<TArg7>(256, ref pAddress))
            {
                return false;
            }
            var paramType8 = parameters[8].ParameterType;
            if (!paramType8.IsValidInput<TArg8>(512, ref pAddress))
            {
                return false;
            }
            var paramType9 = parameters[9].ParameterType;
            if (!paramType9.IsValidInput<TArg9>(1024, ref pAddress))
            {
                return false;
            }
            var paramType10 = parameters[10].ParameterType;
            if (!paramType10.IsValidInput<TArg10>(2048, ref pAddress))
            {
                return false;
            }
            var paramType11 = parameters[11].ParameterType;
            if (!paramType11.IsValidInput<TArg11>(4096, ref pAddress))
            {
                return false;
            }
            var paramType12 = parameters[12].ParameterType;
            if (!paramType12.IsValidInput<TArg12>(8192, ref pAddress))
            {
                return false;
            }
            if (pAddress != 0)
            {
                return false;
            }
            pAddress = method.GetFunctionPointer();
            return true;
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool SecondaryValidateInstanceMethodRaw(MethodBase method, Type target, Type arg0, Type arg1, Type arg2, Type arg3, Type arg4, Type arg5, Type arg6, Type arg7, Type arg8, Type arg9, Type arg10, Type arg11, Type arg12, ref nint pAddress)
        {
            if ((pAddress & 1) != 0)
            {
                var reflectedType = method.ReflectedType;
                if (!reflectedType.IsNullAssignableFromFast(target))
                {
                    return false;
                }
            }
            var parameters = method.GetParametersFast();
            if ((pAddress & 2) != 0)
            {
                var paramType = parameters[0].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg0))
                {
                    return false;
                }
            }
            if ((pAddress & 4) != 0)
            {
                var paramType = parameters[1].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg1))
                {
                    return false;
                }
            }
            if ((pAddress & 8) != 0)
            {
                var paramType = parameters[2].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg2))
                {
                    return false;
                }
            }
            if ((pAddress & 16) != 0)
            {
                var paramType = parameters[3].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg3))
                {
                    return false;
                }
            }
            if ((pAddress & 32) != 0)
            {
                var paramType = parameters[4].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg4))
                {
                    return false;
                }
            }
            if ((pAddress & 64) != 0)
            {
                var paramType = parameters[5].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg5))
                {
                    return false;
                }
            }
            if ((pAddress & 128) != 0)
            {
                var paramType = parameters[6].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg6))
                {
                    return false;
                }
            }
            if ((pAddress & 256) != 0)
            {
                var paramType = parameters[7].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg7))
                {
                    return false;
                }
            }
            if ((pAddress & 512) != 0)
            {
                var paramType = parameters[8].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg8))
                {
                    return false;
                }
            }
            if ((pAddress & 1024) != 0)
            {
                var paramType = parameters[9].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg9))
                {
                    return false;
                }
            }
            if ((pAddress & 2048) != 0)
            {
                var paramType = parameters[10].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg10))
                {
                    return false;
                }
            }
            if ((pAddress & 4096) != 0)
            {
                var paramType = parameters[11].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg11))
                {
                    return false;
                }
            }
            if ((pAddress & 8192) != 0)
            {
                var paramType = parameters[12].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg12))
                {
                    return false;
                }
            }
            pAddress = method.GetFunctionPointer();
            return true;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void InvokeStaticFast<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(this MethodBase self, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9, in TArg10 arg10, in TArg11 arg11, in TArg12 arg12)
        {
            bool isValid;
            nint pAddress;
            isValid = ValidateStaticMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(self, out pAddress) ||
                      (pAddress != 0 && SecondaryValidateStaticMethod(self, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), arg11?.GetType(), arg12?.GetType(), ref pAddress));
            if (!isValid)
            {
                self.InvokeStaticLowAlloc(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
                return;
            }
            unsafe
            {
                ((delegate*<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, void>)pAddress)(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
                return;
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static object InvokeStaticLowAlloc<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(this MethodBase self, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9, in TArg10 arg10, in TArg11 arg11, in TArg12 arg12)
        {
            if (self.IsGenericMethodDefinition)
            {
                ValidateGenericMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(ref self);
            }
            var parameters = self.GetParametersFast();
            ArrayCache.Objects13[0] = REReflection.GetBox(arg0, parameters[0], out var refArg0);
            ArrayCache.Objects13[1] = REReflection.GetBox(arg1, parameters[1], out var refArg1);
            ArrayCache.Objects13[2] = REReflection.GetBox(arg2, parameters[2], out var refArg2);
            ArrayCache.Objects13[3] = REReflection.GetBox(arg3, parameters[3], out var refArg3);
            ArrayCache.Objects13[4] = REReflection.GetBox(arg4, parameters[4], out var refArg4);
            ArrayCache.Objects13[5] = REReflection.GetBox(arg5, parameters[5], out var refArg5);
            ArrayCache.Objects13[6] = REReflection.GetBox(arg6, parameters[6], out var refArg6);
            ArrayCache.Objects13[7] = REReflection.GetBox(arg7, parameters[7], out var refArg7);
            ArrayCache.Objects13[8] = REReflection.GetBox(arg8, parameters[8], out var refArg8);
            ArrayCache.Objects13[9] = REReflection.GetBox(arg9, parameters[9], out var refArg9);
            ArrayCache.Objects13[10] = REReflection.GetBox(arg10, parameters[10], out var refArg10);
            ArrayCache.Objects13[11] = REReflection.GetBox(arg11, parameters[11], out var refArg11);
            ArrayCache.Objects13[12] = REReflection.GetBox(arg12, parameters[12], out var refArg12);
            try
            {
                return self.Invoke(null, ArrayCache.Objects13);
            }
            finally
            {
                REReflection.ReturnBox<TArg0>(ArrayCache.Objects13[0], parameters[0], refArg0);
                REReflection.ReturnBox<TArg1>(ArrayCache.Objects13[1], parameters[1], refArg1);
                REReflection.ReturnBox<TArg2>(ArrayCache.Objects13[2], parameters[2], refArg2);
                REReflection.ReturnBox<TArg3>(ArrayCache.Objects13[3], parameters[3], refArg3);
                REReflection.ReturnBox<TArg4>(ArrayCache.Objects13[4], parameters[4], refArg4);
                REReflection.ReturnBox<TArg5>(ArrayCache.Objects13[5], parameters[5], refArg5);
                REReflection.ReturnBox<TArg6>(ArrayCache.Objects13[6], parameters[6], refArg6);
                REReflection.ReturnBox<TArg7>(ArrayCache.Objects13[7], parameters[7], refArg7);
                REReflection.ReturnBox<TArg8>(ArrayCache.Objects13[8], parameters[8], refArg8);
                REReflection.ReturnBox<TArg9>(ArrayCache.Objects13[9], parameters[9], refArg9);
                REReflection.ReturnBox<TArg10>(ArrayCache.Objects13[10], parameters[10], refArg10);
                REReflection.ReturnBox<TArg11>(ArrayCache.Objects13[11], parameters[11], refArg11);
                REReflection.ReturnBox<TArg12>(ArrayCache.Objects13[12], parameters[12], refArg12);
            }
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool ValidateStaticMethodRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(MethodBase method, out nint pAddress)
        {
            pAddress = 0;
            if (!method.IsStatic)
            {
                return false;
            }
            if (method.IsOverridable())
            {
                return false;
            }
            var isValidGeneric = !method.IsGenericMethodDefinition || ValidateGenericMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(ref method);
            if (!isValidGeneric)
            {
                return false;
            }
            var parameters = method.GetParametersFast();
            var parameterLength = parameters.Count;
            if (parameterLength != 13)
            {
                return false;
            }
            if (method is MethodInfo mi)
            {
                var returnType = mi?.ReturnType ?? typeof(void);
                if (returnType != typeof(void))
                {
                    return false;
                }
            }
            var paramType0 = parameters[0].ParameterType;
            if (!paramType0.IsValidInput<TArg0>(2, ref pAddress))
            {
                return false;
            }
            var paramType1 = parameters[1].ParameterType;
            if (!paramType1.IsValidInput<TArg1>(4, ref pAddress))
            {
                return false;
            }
            var paramType2 = parameters[2].ParameterType;
            if (!paramType2.IsValidInput<TArg2>(8, ref pAddress))
            {
                return false;
            }
            var paramType3 = parameters[3].ParameterType;
            if (!paramType3.IsValidInput<TArg3>(16, ref pAddress))
            {
                return false;
            }
            var paramType4 = parameters[4].ParameterType;
            if (!paramType4.IsValidInput<TArg4>(32, ref pAddress))
            {
                return false;
            }
            var paramType5 = parameters[5].ParameterType;
            if (!paramType5.IsValidInput<TArg5>(64, ref pAddress))
            {
                return false;
            }
            var paramType6 = parameters[6].ParameterType;
            if (!paramType6.IsValidInput<TArg6>(128, ref pAddress))
            {
                return false;
            }
            var paramType7 = parameters[7].ParameterType;
            if (!paramType7.IsValidInput<TArg7>(256, ref pAddress))
            {
                return false;
            }
            var paramType8 = parameters[8].ParameterType;
            if (!paramType8.IsValidInput<TArg8>(512, ref pAddress))
            {
                return false;
            }
            var paramType9 = parameters[9].ParameterType;
            if (!paramType9.IsValidInput<TArg9>(1024, ref pAddress))
            {
                return false;
            }
            var paramType10 = parameters[10].ParameterType;
            if (!paramType10.IsValidInput<TArg10>(2048, ref pAddress))
            {
                return false;
            }
            var paramType11 = parameters[11].ParameterType;
            if (!paramType11.IsValidInput<TArg11>(4096, ref pAddress))
            {
                return false;
            }
            var paramType12 = parameters[12].ParameterType;
            if (!paramType12.IsValidInput<TArg12>(8192, ref pAddress))
            {
                return false;
            }
            if (pAddress != 0)
            {
                return false;
            }
            pAddress = method.GetFunctionPointer();
            return true;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TReturn InvokeStaticFast<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TReturn>(this MethodBase self, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9, in TArg10 arg10, in TArg11 arg11, in TArg12 arg12)
        {
            bool isValid;
            nint pAddress;
            isValid = ValidateStaticReturnableMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TReturn>(self, out pAddress) ||
                      (pAddress != 0 && SecondaryValidateStaticMethod(self, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), arg11?.GetType(), arg12?.GetType(), ref pAddress));
            if (!isValid)
            {
                return (TReturn)self.InvokeStaticLowAlloc(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
            }
            unsafe
            {
                return ((delegate*<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TReturn>)pAddress)(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
            }
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool ValidateStaticReturnableMethodRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TReturn>(MethodBase method, out nint pAddress)
        {
            pAddress = 0;
            if (!method.IsStatic)
            {
                return false;
            }
            if (method.IsOverridable())
            {
                return false;
            }
            var isValidGeneric = !method.IsGenericMethodDefinition || ValidateGenericReturnableMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TReturn>(ref method);
            if (!isValidGeneric)
            {
                return false;
            }
            var parameters = method.GetParametersFast();
            var parameterLength = parameters.Count;
            if (parameterLength != 13)
            {
                return false;
            }
            if (method is MethodInfo mi)
            {
                var returnType = mi?.ReturnType ?? typeof(void);
                if (!returnType.IsValidOutput<TReturn>())
                {
                    return false;
                }
            }
            var paramType0 = parameters[0].ParameterType;
            if (!paramType0.IsValidInput<TArg0>(2, ref pAddress))
            {
                return false;
            }
            var paramType1 = parameters[1].ParameterType;
            if (!paramType1.IsValidInput<TArg1>(4, ref pAddress))
            {
                return false;
            }
            var paramType2 = parameters[2].ParameterType;
            if (!paramType2.IsValidInput<TArg2>(8, ref pAddress))
            {
                return false;
            }
            var paramType3 = parameters[3].ParameterType;
            if (!paramType3.IsValidInput<TArg3>(16, ref pAddress))
            {
                return false;
            }
            var paramType4 = parameters[4].ParameterType;
            if (!paramType4.IsValidInput<TArg4>(32, ref pAddress))
            {
                return false;
            }
            var paramType5 = parameters[5].ParameterType;
            if (!paramType5.IsValidInput<TArg5>(64, ref pAddress))
            {
                return false;
            }
            var paramType6 = parameters[6].ParameterType;
            if (!paramType6.IsValidInput<TArg6>(128, ref pAddress))
            {
                return false;
            }
            var paramType7 = parameters[7].ParameterType;
            if (!paramType7.IsValidInput<TArg7>(256, ref pAddress))
            {
                return false;
            }
            var paramType8 = parameters[8].ParameterType;
            if (!paramType8.IsValidInput<TArg8>(512, ref pAddress))
            {
                return false;
            }
            var paramType9 = parameters[9].ParameterType;
            if (!paramType9.IsValidInput<TArg9>(1024, ref pAddress))
            {
                return false;
            }
            var paramType10 = parameters[10].ParameterType;
            if (!paramType10.IsValidInput<TArg10>(2048, ref pAddress))
            {
                return false;
            }
            var paramType11 = parameters[11].ParameterType;
            if (!paramType11.IsValidInput<TArg11>(4096, ref pAddress))
            {
                return false;
            }
            var paramType12 = parameters[12].ParameterType;
            if (!paramType12.IsValidInput<TArg12>(8192, ref pAddress))
            {
                return false;
            }
            if (pAddress != 0)
            {
                return false;
            }
            pAddress = method.GetFunctionPointer();
            return true;
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool SecondaryValidateStaticMethodRaw(MethodBase method, Type arg0, Type arg1, Type arg2, Type arg3, Type arg4, Type arg5, Type arg6, Type arg7, Type arg8, Type arg9, Type arg10, Type arg11, Type arg12, ref nint pAddress)
        {
            var parameters = method.GetParametersFast();
            if ((pAddress & 2) != 0)
            {
                var paramType = parameters[0].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg0))
                {
                    return false;
                }
            }
            if ((pAddress & 4) != 0)
            {
                var paramType = parameters[1].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg1))
                {
                    return false;
                }
            }
            if ((pAddress & 8) != 0)
            {
                var paramType = parameters[2].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg2))
                {
                    return false;
                }
            }
            if ((pAddress & 16) != 0)
            {
                var paramType = parameters[3].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg3))
                {
                    return false;
                }
            }
            if ((pAddress & 32) != 0)
            {
                var paramType = parameters[4].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg4))
                {
                    return false;
                }
            }
            if ((pAddress & 64) != 0)
            {
                var paramType = parameters[5].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg5))
                {
                    return false;
                }
            }
            if ((pAddress & 128) != 0)
            {
                var paramType = parameters[6].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg6))
                {
                    return false;
                }
            }
            if ((pAddress & 256) != 0)
            {
                var paramType = parameters[7].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg7))
                {
                    return false;
                }
            }
            if ((pAddress & 512) != 0)
            {
                var paramType = parameters[8].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg8))
                {
                    return false;
                }
            }
            if ((pAddress & 1024) != 0)
            {
                var paramType = parameters[9].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg9))
                {
                    return false;
                }
            }
            if ((pAddress & 2048) != 0)
            {
                var paramType = parameters[10].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg10))
                {
                    return false;
                }
            }
            if ((pAddress & 4096) != 0)
            {
                var paramType = parameters[11].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg11))
                {
                    return false;
                }
            }
            if ((pAddress & 8192) != 0)
            {
                var paramType = parameters[12].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg12))
                {
                    return false;
                }
            }
            pAddress = method.GetFunctionPointer();
            return true;
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool ValidateGenericMethodRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(ref MethodBase method)
        {
            if (!method.IsGenericMethodDefinition)
            {
                return true;
            }
            var genericArguments = method.GetGenericArgumentsFast();
            if (genericArguments.Count < 13)
            {
                return false;
            }
            uint mask = 0;
            var mi = method as MethodInfo;
            var parameters = method.GetParametersFast();
            var index0 = IndexOf(genericArguments, parameters[0].ParameterType);
            if (index0 >= 0)
            {
                mask |= 1u << index0;
            }
            var index1 = IndexOf(genericArguments, parameters[1].ParameterType);
            if (index1 >= 0)
            {
                mask |= 1u << index1;
            }
            var index2 = IndexOf(genericArguments, parameters[2].ParameterType);
            if (index2 >= 0)
            {
                mask |= 1u << index2;
            }
            var index3 = IndexOf(genericArguments, parameters[3].ParameterType);
            if (index3 >= 0)
            {
                mask |= 1u << index3;
            }
            var index4 = IndexOf(genericArguments, parameters[4].ParameterType);
            if (index4 >= 0)
            {
                mask |= 1u << index4;
            }
            var index5 = IndexOf(genericArguments, parameters[5].ParameterType);
            if (index5 >= 0)
            {
                mask |= 1u << index5;
            }
            var index6 = IndexOf(genericArguments, parameters[6].ParameterType);
            if (index6 >= 0)
            {
                mask |= 1u << index6;
            }
            var index7 = IndexOf(genericArguments, parameters[7].ParameterType);
            if (index7 >= 0)
            {
                mask |= 1u << index7;
            }
            var index8 = IndexOf(genericArguments, parameters[8].ParameterType);
            if (index8 >= 0)
            {
                mask |= 1u << index8;
            }
            var index9 = IndexOf(genericArguments, parameters[9].ParameterType);
            if (index9 >= 0)
            {
                mask |= 1u << index9;
            }
            var index10 = IndexOf(genericArguments, parameters[10].ParameterType);
            if (index10 >= 0)
            {
                mask |= 1u << index10;
            }
            var index11 = IndexOf(genericArguments, parameters[11].ParameterType);
            if (index11 >= 0)
            {
                mask |= 1u << index11;
            }
            var index12 = IndexOf(genericArguments, parameters[12].ParameterType);
            if (index12 >= 0)
            {
                mask |= 1u << index12;
            }
            if (REReflection.BitCount(mask) != genericArguments.Count)
            {
                return false;
            }
            var types = ArrayCache.GetArrayCache<Type>(genericArguments.Count);
            if (index0 >= 0)
            {
                types[index0] = typeof(TArg0);
            }
            if (index1 >= 0)
            {
                types[index1] = typeof(TArg1);
            }
            if (index2 >= 0)
            {
                types[index2] = typeof(TArg2);
            }
            if (index3 >= 0)
            {
                types[index3] = typeof(TArg3);
            }
            if (index4 >= 0)
            {
                types[index4] = typeof(TArg4);
            }
            if (index5 >= 0)
            {
                types[index5] = typeof(TArg5);
            }
            if (index6 >= 0)
            {
                types[index6] = typeof(TArg6);
            }
            if (index7 >= 0)
            {
                types[index7] = typeof(TArg7);
            }
            if (index8 >= 0)
            {
                types[index8] = typeof(TArg8);
            }
            if (index9 >= 0)
            {
                types[index9] = typeof(TArg9);
            }
            if (index10 >= 0)
            {
                types[index10] = typeof(TArg10);
            }
            if (index11 >= 0)
            {
                types[index11] = typeof(TArg11);
            }
            if (index12 >= 0)
            {
                types[index12] = typeof(TArg12);
            }
            #if ENABLE_IL2CPP
            bool isFound = false;
            var usingMethods = method.GetUsingGenericInstanceMethods();
            foreach (var usingMethod in usingMethods)
            {
                if (usingMethod.GetGenericArgumentsFast().SequenceEqual(types))
                {
                    isFound = true;
                    break;
                }
            }
            if (!isFound)
            {
                return false;
            }
            #endif
            method = mi.MakeGenericMethodFast(types);
            return true;
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool ValidateGenericReturnableMethodRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TReturn>(ref MethodBase method)
        {
            if (!method.IsGenericMethodDefinition)
            {
                return true;
            }
            var genericArguments = method.GetGenericArgumentsFast();
            if (genericArguments.Count < 14)
            {
                return false;
            }
            uint mask = 0;
            var mi = method as MethodInfo;
            var returnType = mi.ReturnType ?? typeof(void);
            var index = IndexOf(genericArguments, returnType);
            if (index >= 0)
            {
                mask |= 1u << index;
            }
            var parameters = method.GetParametersFast();
            var index0 = IndexOf(genericArguments, parameters[0].ParameterType);
            if (index0 >= 0)
            {
                mask |= 1u << index0;
            }
            var index1 = IndexOf(genericArguments, parameters[1].ParameterType);
            if (index1 >= 0)
            {
                mask |= 1u << index1;
            }
            var index2 = IndexOf(genericArguments, parameters[2].ParameterType);
            if (index2 >= 0)
            {
                mask |= 1u << index2;
            }
            var index3 = IndexOf(genericArguments, parameters[3].ParameterType);
            if (index3 >= 0)
            {
                mask |= 1u << index3;
            }
            var index4 = IndexOf(genericArguments, parameters[4].ParameterType);
            if (index4 >= 0)
            {
                mask |= 1u << index4;
            }
            var index5 = IndexOf(genericArguments, parameters[5].ParameterType);
            if (index5 >= 0)
            {
                mask |= 1u << index5;
            }
            var index6 = IndexOf(genericArguments, parameters[6].ParameterType);
            if (index6 >= 0)
            {
                mask |= 1u << index6;
            }
            var index7 = IndexOf(genericArguments, parameters[7].ParameterType);
            if (index7 >= 0)
            {
                mask |= 1u << index7;
            }
            var index8 = IndexOf(genericArguments, parameters[8].ParameterType);
            if (index8 >= 0)
            {
                mask |= 1u << index8;
            }
            var index9 = IndexOf(genericArguments, parameters[9].ParameterType);
            if (index9 >= 0)
            {
                mask |= 1u << index9;
            }
            var index10 = IndexOf(genericArguments, parameters[10].ParameterType);
            if (index10 >= 0)
            {
                mask |= 1u << index10;
            }
            var index11 = IndexOf(genericArguments, parameters[11].ParameterType);
            if (index11 >= 0)
            {
                mask |= 1u << index11;
            }
            var index12 = IndexOf(genericArguments, parameters[12].ParameterType);
            if (index12 >= 0)
            {
                mask |= 1u << index12;
            }
            if (REReflection.BitCount(mask) != genericArguments.Count)
            {
                return false;
            }
            var types = ArrayCache.GetArrayCache<Type>(genericArguments.Count);
            if (index >= 0)
            {
                types[index] = typeof(TReturn);
            }
            if (index0 >= 0)
            {
                types[index0] = typeof(TArg0);
            }
            if (index1 >= 0)
            {
                types[index1] = typeof(TArg1);
            }
            if (index2 >= 0)
            {
                types[index2] = typeof(TArg2);
            }
            if (index3 >= 0)
            {
                types[index3] = typeof(TArg3);
            }
            if (index4 >= 0)
            {
                types[index4] = typeof(TArg4);
            }
            if (index5 >= 0)
            {
                types[index5] = typeof(TArg5);
            }
            if (index6 >= 0)
            {
                types[index6] = typeof(TArg6);
            }
            if (index7 >= 0)
            {
                types[index7] = typeof(TArg7);
            }
            if (index8 >= 0)
            {
                types[index8] = typeof(TArg8);
            }
            if (index9 >= 0)
            {
                types[index9] = typeof(TArg9);
            }
            if (index10 >= 0)
            {
                types[index10] = typeof(TArg10);
            }
            if (index11 >= 0)
            {
                types[index11] = typeof(TArg11);
            }
            if (index12 >= 0)
            {
                types[index12] = typeof(TArg12);
            }
            #if ENABLE_IL2CPP
            bool isFound = false;
            var usingMethods = method.GetUsingGenericInstanceMethods();
            foreach (var usingMethod in usingMethods)
            {
                if (usingMethod.GetGenericArgumentsFast().SequenceEqual(types))
                {
                    isFound = true;
                    break;
                }
            }
            if (!isFound)
            {
                return false;
            }
            #endif
            method = mi.MakeGenericMethodFast(types);
            return true;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void InvokeInstanceFast<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(this MethodBase self, ref TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9, in TArg10 arg10, in TArg11 arg11, in TArg12 arg12, in TArg13 arg13)
        {
            bool isValid;
            nint pAddress;
            if (self.IsOverridable())
            {
                isValid = ValidateInstanceVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(self, target?.GetType(), out pAddress) ||
                          (pAddress != 0 && SecondaryValidateStaticMethod(self, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), arg11?.GetType(), arg12?.GetType(), arg13?.GetType(), ref pAddress));
            }
            else
            {
                isValid = ValidateInstanceMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(self, out pAddress) ||
                          (pAddress != 0 && SecondaryValidateInstanceMethod(self, target?.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), arg11?.GetType(), arg12?.GetType(), arg13?.GetType(), ref pAddress));
            }
            if (!isValid)
            {
                self.InvokeInstanceLowAlloc(ref target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
                return;
            }
            unsafe
            {
                if (REType.IsValueTypeFast<TTarget>())
                {
                    ((delegate*<ref TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, void>)pAddress)(ref target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
                    return;
                }
                ((delegate*<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, void>)pAddress)(target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
                return;
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void InvokeClassInstanceFast<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(this MethodBase self, TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9, in TArg10 arg10, in TArg11 arg11, in TArg12 arg12, in TArg13 arg13)
        where TTarget: class
        {
            bool isValid;
            nint pAddress;
            if (self.IsOverridable())
            {
                isValid = ValidateInstanceVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(self, target?.GetType(), out pAddress) ||
                          (pAddress != 0 && SecondaryValidateStaticMethod(self, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), arg11?.GetType(), arg12?.GetType(), arg13?.GetType(), ref pAddress));
            }
            else
            {
                isValid = ValidateInstanceMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(self, out pAddress) ||
                          (pAddress != 0 && SecondaryValidateInstanceMethod(self, target?.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), arg11?.GetType(), arg12?.GetType(), arg13?.GetType(), ref pAddress));
            }
            if (!isValid)
            {
                self.InvokeClassInstanceLowAlloc(target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
                return;
            }
            unsafe
            {
                ((delegate*<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, void>)pAddress)(target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
                return;
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void InvokeStructInstanceFast<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(this MethodBase self, ref TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9, in TArg10 arg10, in TArg11 arg11, in TArg12 arg12, in TArg13 arg13)
        where TTarget: struct
        {
            bool isValid;
            nint pAddress;
            if (self.IsOverridable())
            {
                isValid = ValidateInstanceVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(self, target.GetType(), out pAddress) ||
                          (pAddress != 0 && SecondaryValidateStaticMethod(self, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), arg11?.GetType(), arg12?.GetType(), arg13?.GetType(), ref pAddress));
            }
            else
            {
                isValid = ValidateInstanceMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(self, out pAddress) ||
                          (pAddress != 0 && SecondaryValidateInstanceMethod(self, target.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), arg11?.GetType(), arg12?.GetType(), arg13?.GetType(), ref pAddress));
            }
            if (!isValid)
            {
                self.InvokeInstanceLowAlloc(ref target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
                return;
            }
            unsafe
            {
                ((delegate*<ref TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, void>)pAddress)(ref target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
                return;
            }
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool ValidateInstanceMethodRaw<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(MethodBase method, out nint pAddress)
        {
            pAddress = 0;
            if (method.IsStatic)
            {
                return false;
            }
            if (method.IsOverridable())
            {
                return false;
            }
            var isValidGeneric = !method.IsGenericMethodDefinition || ValidateGenericMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(ref method);
            if (!isValidGeneric)
            {
                return false;
            }
            var parameters = method.GetParametersFast();
            var parameterLength = parameters.Count;
            if (parameterLength != 14)
            {
                return false;
            }
            if (method is MethodInfo mi)
            {
                var returnType = mi?.ReturnType ?? typeof(void);
                if (returnType != typeof(void))
                {
                    return false;
                }
            }
            var reflectedType = method.ReflectedType;
            if (!reflectedType.IsValidInputWithoutRef<TTarget>(1, ref pAddress))
            {
                return false;
            }
            var paramType0 = parameters[0].ParameterType;
            if (!paramType0.IsValidInput<TArg0>(2, ref pAddress))
            {
                return false;
            }
            var paramType1 = parameters[1].ParameterType;
            if (!paramType1.IsValidInput<TArg1>(4, ref pAddress))
            {
                return false;
            }
            var paramType2 = parameters[2].ParameterType;
            if (!paramType2.IsValidInput<TArg2>(8, ref pAddress))
            {
                return false;
            }
            var paramType3 = parameters[3].ParameterType;
            if (!paramType3.IsValidInput<TArg3>(16, ref pAddress))
            {
                return false;
            }
            var paramType4 = parameters[4].ParameterType;
            if (!paramType4.IsValidInput<TArg4>(32, ref pAddress))
            {
                return false;
            }
            var paramType5 = parameters[5].ParameterType;
            if (!paramType5.IsValidInput<TArg5>(64, ref pAddress))
            {
                return false;
            }
            var paramType6 = parameters[6].ParameterType;
            if (!paramType6.IsValidInput<TArg6>(128, ref pAddress))
            {
                return false;
            }
            var paramType7 = parameters[7].ParameterType;
            if (!paramType7.IsValidInput<TArg7>(256, ref pAddress))
            {
                return false;
            }
            var paramType8 = parameters[8].ParameterType;
            if (!paramType8.IsValidInput<TArg8>(512, ref pAddress))
            {
                return false;
            }
            var paramType9 = parameters[9].ParameterType;
            if (!paramType9.IsValidInput<TArg9>(1024, ref pAddress))
            {
                return false;
            }
            var paramType10 = parameters[10].ParameterType;
            if (!paramType10.IsValidInput<TArg10>(2048, ref pAddress))
            {
                return false;
            }
            var paramType11 = parameters[11].ParameterType;
            if (!paramType11.IsValidInput<TArg11>(4096, ref pAddress))
            {
                return false;
            }
            var paramType12 = parameters[12].ParameterType;
            if (!paramType12.IsValidInput<TArg12>(8192, ref pAddress))
            {
                return false;
            }
            var paramType13 = parameters[13].ParameterType;
            if (!paramType13.IsValidInput<TArg13>(16384, ref pAddress))
            {
                return false;
            }
            if (pAddress != 0)
            {
                return false;
            }
            pAddress = method.GetFunctionPointer();
            return true;
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool ValidateInstanceVirtualMethodRaw<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(MethodBase method, Type targetType, out nint pAddress)
        {
            pAddress = 0;
            if (method.IsStatic)
            {
                return false;
            }
            if (!method.IsOverridable())
            {
                return false;
            }
            var isValidGeneric = !method.IsGenericMethodDefinition || ValidateGenericMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(ref method);
            if (!isValidGeneric)
            {
                return false;
            }
            var parameters = method.GetParametersFast();
            var parameterLength = parameters.Count;
            if (parameterLength != 14)
            {
                return false;
            }
            if (method is MethodInfo mi)
            {
                var returnType = mi?.ReturnType ?? typeof(void);
                if (returnType != typeof(void))
                {
                    return false;
                }
            }
            var reflectedType = method.ReflectedType;
            if (!reflectedType.IsValidVirtualInput<TTarget>(targetType, out var isVirtualCall))
            {
                return false;
            }
            if (isVirtualCall)
            {
                ArrayCache.Types14[0] = parameters[0].ParameterType;
                ArrayCache.Types14[1] = parameters[1].ParameterType;
                ArrayCache.Types14[2] = parameters[2].ParameterType;
                ArrayCache.Types14[3] = parameters[3].ParameterType;
                ArrayCache.Types14[4] = parameters[4].ParameterType;
                ArrayCache.Types14[5] = parameters[5].ParameterType;
                ArrayCache.Types14[6] = parameters[6].ParameterType;
                ArrayCache.Types14[7] = parameters[7].ParameterType;
                ArrayCache.Types14[8] = parameters[8].ParameterType;
                ArrayCache.Types14[9] = parameters[9].ParameterType;
                ArrayCache.Types14[10] = parameters[10].ParameterType;
                ArrayCache.Types14[11] = parameters[11].ParameterType;
                ArrayCache.Types14[12] = parameters[12].ParameterType;
                ArrayCache.Types14[13] = parameters[13].ParameterType;
                method = targetType.GetInstanceMethodFullAccess(method.Name, null, ArrayCache.Types14, null);
            }
            var paramType0 = parameters[0].ParameterType;
            if (!paramType0.IsValidInput<TArg0>(2, ref pAddress))
            {
                return false;
            }
            var paramType1 = parameters[1].ParameterType;
            if (!paramType1.IsValidInput<TArg1>(4, ref pAddress))
            {
                return false;
            }
            var paramType2 = parameters[2].ParameterType;
            if (!paramType2.IsValidInput<TArg2>(8, ref pAddress))
            {
                return false;
            }
            var paramType3 = parameters[3].ParameterType;
            if (!paramType3.IsValidInput<TArg3>(16, ref pAddress))
            {
                return false;
            }
            var paramType4 = parameters[4].ParameterType;
            if (!paramType4.IsValidInput<TArg4>(32, ref pAddress))
            {
                return false;
            }
            var paramType5 = parameters[5].ParameterType;
            if (!paramType5.IsValidInput<TArg5>(64, ref pAddress))
            {
                return false;
            }
            var paramType6 = parameters[6].ParameterType;
            if (!paramType6.IsValidInput<TArg6>(128, ref pAddress))
            {
                return false;
            }
            var paramType7 = parameters[7].ParameterType;
            if (!paramType7.IsValidInput<TArg7>(256, ref pAddress))
            {
                return false;
            }
            var paramType8 = parameters[8].ParameterType;
            if (!paramType8.IsValidInput<TArg8>(512, ref pAddress))
            {
                return false;
            }
            var paramType9 = parameters[9].ParameterType;
            if (!paramType9.IsValidInput<TArg9>(1024, ref pAddress))
            {
                return false;
            }
            var paramType10 = parameters[10].ParameterType;
            if (!paramType10.IsValidInput<TArg10>(2048, ref pAddress))
            {
                return false;
            }
            var paramType11 = parameters[11].ParameterType;
            if (!paramType11.IsValidInput<TArg11>(4096, ref pAddress))
            {
                return false;
            }
            var paramType12 = parameters[12].ParameterType;
            if (!paramType12.IsValidInput<TArg12>(8192, ref pAddress))
            {
                return false;
            }
            var paramType13 = parameters[13].ParameterType;
            if (!paramType13.IsValidInput<TArg13>(16384, ref pAddress))
            {
                return false;
            }
            if (pAddress != 0)
            {
                return false;
            }
            pAddress = method.GetFunctionPointer();
            return true;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TReturn InvokeInstanceFast<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TReturn>(this MethodBase self, ref TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9, in TArg10 arg10, in TArg11 arg11, in TArg12 arg12, in TArg13 arg13)
        {
            bool isValid;
            nint pAddress;
            if (self.IsOverridable())
            {
                isValid = ValidateInstanceReturnableVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TReturn>(self, target?.GetType(), out pAddress) ||
                          (pAddress != 0 && SecondaryValidateStaticMethod(self, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), arg11?.GetType(), arg12?.GetType(), arg13?.GetType(), ref pAddress));
            }
            else
            {
                isValid = ValidateInstanceReturnableMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TReturn>(self, out pAddress) ||
                          (pAddress != 0 && SecondaryValidateInstanceMethod(self, target?.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), arg11?.GetType(), arg12?.GetType(), arg13?.GetType(), ref pAddress));
            }
            if (!isValid)
            {
                return (TReturn)self.InvokeInstanceLowAlloc(ref target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
            }
            unsafe
            {
                if (REType.IsValueTypeFast<TTarget>())
                {
                    return ((delegate*<ref TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TReturn>)pAddress)(ref target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
                }
                return ((delegate*<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TReturn>)pAddress)(target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TReturn InvokeClassInstanceFast<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TReturn>(this MethodBase self, TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9, in TArg10 arg10, in TArg11 arg11, in TArg12 arg12, in TArg13 arg13)
        where TTarget: class
        {
            bool isValid;
            nint pAddress;
            if (self.IsOverridable())
            {
                isValid = ValidateInstanceReturnableVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TReturn>(self, target?.GetType(), out pAddress) ||
                          (pAddress != 0 && SecondaryValidateStaticMethod(self, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), arg11?.GetType(), arg12?.GetType(), arg13?.GetType(), ref pAddress));
            }
            else
            {
                isValid = ValidateInstanceReturnableMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TReturn>(self, out pAddress) ||
                          (pAddress != 0 && SecondaryValidateInstanceMethod(self, target?.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), arg11?.GetType(), arg12?.GetType(), arg13?.GetType(), ref pAddress));
            }
            if (!isValid)
            {
                return (TReturn)self.InvokeClassInstanceLowAlloc(target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
            }
            unsafe
            {
                return ((delegate*<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TReturn>)pAddress)(target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TReturn InvokeStructInstanceFast<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TReturn>(this MethodBase self, ref TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9, in TArg10 arg10, in TArg11 arg11, in TArg12 arg12, in TArg13 arg13)
        where TTarget: struct
        {
            bool isValid;
            nint pAddress;
            if (self.IsOverridable())
            {
                isValid = ValidateInstanceReturnableVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TReturn>(self, target.GetType(), out pAddress) ||
                          (pAddress != 0 && SecondaryValidateStaticMethod(self, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), arg11?.GetType(), arg12?.GetType(), arg13?.GetType(), ref pAddress));
            }
            else
            {
                isValid = ValidateInstanceReturnableMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TReturn>(self, out pAddress) ||
                          (pAddress != 0 && SecondaryValidateInstanceMethod(self, target.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), arg11?.GetType(), arg12?.GetType(), arg13?.GetType(), ref pAddress));
            }
            if (!isValid)
            {
                return (TReturn)self.InvokeInstanceLowAlloc(ref target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
            }
            unsafe
            {
                return ((delegate*<ref TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TReturn>)pAddress)(ref target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static object InvokeInstanceLowAlloc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(this MethodBase self, ref TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9, in TArg10 arg10, in TArg11 arg11, in TArg12 arg12, in TArg13 arg13)
        {
            if (self.IsGenericMethodDefinition)
            {
                ValidateGenericMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(ref self);
            }
            var targetObj = REReflection.GetBoxWithoutRef(target);
            var parameters = self.GetParametersFast();
            ArrayCache.Objects14[0] = REReflection.GetBox(arg0, parameters[0], out var refArg0);
            ArrayCache.Objects14[1] = REReflection.GetBox(arg1, parameters[1], out var refArg1);
            ArrayCache.Objects14[2] = REReflection.GetBox(arg2, parameters[2], out var refArg2);
            ArrayCache.Objects14[3] = REReflection.GetBox(arg3, parameters[3], out var refArg3);
            ArrayCache.Objects14[4] = REReflection.GetBox(arg4, parameters[4], out var refArg4);
            ArrayCache.Objects14[5] = REReflection.GetBox(arg5, parameters[5], out var refArg5);
            ArrayCache.Objects14[6] = REReflection.GetBox(arg6, parameters[6], out var refArg6);
            ArrayCache.Objects14[7] = REReflection.GetBox(arg7, parameters[7], out var refArg7);
            ArrayCache.Objects14[8] = REReflection.GetBox(arg8, parameters[8], out var refArg8);
            ArrayCache.Objects14[9] = REReflection.GetBox(arg9, parameters[9], out var refArg9);
            ArrayCache.Objects14[10] = REReflection.GetBox(arg10, parameters[10], out var refArg10);
            ArrayCache.Objects14[11] = REReflection.GetBox(arg11, parameters[11], out var refArg11);
            ArrayCache.Objects14[12] = REReflection.GetBox(arg12, parameters[12], out var refArg12);
            ArrayCache.Objects14[13] = REReflection.GetBox(arg13, parameters[13], out var refArg13);
            try
            {
                return self.Invoke(targetObj, ArrayCache.Objects14);
            }
            finally
            {
                REReflection.Unbox(targetObj, out target);
                REReflection.ReturnBoxWithoutRef<TTarget>(targetObj);
                REReflection.ReturnBox<TArg0>(ArrayCache.Objects14[0], parameters[0], refArg0);
                REReflection.ReturnBox<TArg1>(ArrayCache.Objects14[1], parameters[1], refArg1);
                REReflection.ReturnBox<TArg2>(ArrayCache.Objects14[2], parameters[2], refArg2);
                REReflection.ReturnBox<TArg3>(ArrayCache.Objects14[3], parameters[3], refArg3);
                REReflection.ReturnBox<TArg4>(ArrayCache.Objects14[4], parameters[4], refArg4);
                REReflection.ReturnBox<TArg5>(ArrayCache.Objects14[5], parameters[5], refArg5);
                REReflection.ReturnBox<TArg6>(ArrayCache.Objects14[6], parameters[6], refArg6);
                REReflection.ReturnBox<TArg7>(ArrayCache.Objects14[7], parameters[7], refArg7);
                REReflection.ReturnBox<TArg8>(ArrayCache.Objects14[8], parameters[8], refArg8);
                REReflection.ReturnBox<TArg9>(ArrayCache.Objects14[9], parameters[9], refArg9);
                REReflection.ReturnBox<TArg10>(ArrayCache.Objects14[10], parameters[10], refArg10);
                REReflection.ReturnBox<TArg11>(ArrayCache.Objects14[11], parameters[11], refArg11);
                REReflection.ReturnBox<TArg12>(ArrayCache.Objects14[12], parameters[12], refArg12);
                REReflection.ReturnBox<TArg13>(ArrayCache.Objects14[13], parameters[13], refArg13);
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static object InvokeClassInstanceLowAlloc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(this MethodBase self, TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9, in TArg10 arg10, in TArg11 arg11, in TArg12 arg12, in TArg13 arg13)
        where TTarget: class
        {
            if (self.IsGenericMethodDefinition)
            {
                ValidateGenericMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(ref self);
            }
            var parameters = self.GetParametersFast();
            ArrayCache.Objects14[0] = REReflection.GetBox(arg0, parameters[0], out var refArg0);
            ArrayCache.Objects14[1] = REReflection.GetBox(arg1, parameters[1], out var refArg1);
            ArrayCache.Objects14[2] = REReflection.GetBox(arg2, parameters[2], out var refArg2);
            ArrayCache.Objects14[3] = REReflection.GetBox(arg3, parameters[3], out var refArg3);
            ArrayCache.Objects14[4] = REReflection.GetBox(arg4, parameters[4], out var refArg4);
            ArrayCache.Objects14[5] = REReflection.GetBox(arg5, parameters[5], out var refArg5);
            ArrayCache.Objects14[6] = REReflection.GetBox(arg6, parameters[6], out var refArg6);
            ArrayCache.Objects14[7] = REReflection.GetBox(arg7, parameters[7], out var refArg7);
            ArrayCache.Objects14[8] = REReflection.GetBox(arg8, parameters[8], out var refArg8);
            ArrayCache.Objects14[9] = REReflection.GetBox(arg9, parameters[9], out var refArg9);
            ArrayCache.Objects14[10] = REReflection.GetBox(arg10, parameters[10], out var refArg10);
            ArrayCache.Objects14[11] = REReflection.GetBox(arg11, parameters[11], out var refArg11);
            ArrayCache.Objects14[12] = REReflection.GetBox(arg12, parameters[12], out var refArg12);
            ArrayCache.Objects14[13] = REReflection.GetBox(arg13, parameters[13], out var refArg13);
            try
            {
                return self.Invoke(target, ArrayCache.Objects14);
            }
            finally
            {
                REReflection.ReturnBox<TArg0>(ArrayCache.Objects14[0], parameters[0], refArg0);
                REReflection.ReturnBox<TArg1>(ArrayCache.Objects14[1], parameters[1], refArg1);
                REReflection.ReturnBox<TArg2>(ArrayCache.Objects14[2], parameters[2], refArg2);
                REReflection.ReturnBox<TArg3>(ArrayCache.Objects14[3], parameters[3], refArg3);
                REReflection.ReturnBox<TArg4>(ArrayCache.Objects14[4], parameters[4], refArg4);
                REReflection.ReturnBox<TArg5>(ArrayCache.Objects14[5], parameters[5], refArg5);
                REReflection.ReturnBox<TArg6>(ArrayCache.Objects14[6], parameters[6], refArg6);
                REReflection.ReturnBox<TArg7>(ArrayCache.Objects14[7], parameters[7], refArg7);
                REReflection.ReturnBox<TArg8>(ArrayCache.Objects14[8], parameters[8], refArg8);
                REReflection.ReturnBox<TArg9>(ArrayCache.Objects14[9], parameters[9], refArg9);
                REReflection.ReturnBox<TArg10>(ArrayCache.Objects14[10], parameters[10], refArg10);
                REReflection.ReturnBox<TArg11>(ArrayCache.Objects14[11], parameters[11], refArg11);
                REReflection.ReturnBox<TArg12>(ArrayCache.Objects14[12], parameters[12], refArg12);
                REReflection.ReturnBox<TArg13>(ArrayCache.Objects14[13], parameters[13], refArg13);
            }
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool ValidateInstanceReturnableMethodRaw<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TReturn>(MethodBase method, out nint pAddress)
        {
            pAddress = 0;
            if (method.IsStatic)
            {
                return false;
            }
            if (method.IsOverridable())
            {
                return false;
            }
            var isValidGeneric = !method.IsGenericMethodDefinition || ValidateGenericReturnableMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TReturn>(ref method);
            if (!isValidGeneric)
            {
                return false;
            }
            var parameters = method.GetParametersFast();
            var parameterLength = parameters.Count;
            if (parameterLength != 14)
            {
                return false;
            }
            if (method is MethodInfo mi)
            {
                var returnType = mi?.ReturnType ?? typeof(void);
                if (!returnType.IsValidOutput<TReturn>())
                {
                    return false;
                }
            }
            var reflectedType = method.ReflectedType;
            if (!reflectedType.IsValidInputWithoutRef<TTarget>(1, ref pAddress))
            {
                return false;
            }
            var paramType0 = parameters[0].ParameterType;
            if (!paramType0.IsValidInput<TArg0>(2, ref pAddress))
            {
                return false;
            }
            var paramType1 = parameters[1].ParameterType;
            if (!paramType1.IsValidInput<TArg1>(4, ref pAddress))
            {
                return false;
            }
            var paramType2 = parameters[2].ParameterType;
            if (!paramType2.IsValidInput<TArg2>(8, ref pAddress))
            {
                return false;
            }
            var paramType3 = parameters[3].ParameterType;
            if (!paramType3.IsValidInput<TArg3>(16, ref pAddress))
            {
                return false;
            }
            var paramType4 = parameters[4].ParameterType;
            if (!paramType4.IsValidInput<TArg4>(32, ref pAddress))
            {
                return false;
            }
            var paramType5 = parameters[5].ParameterType;
            if (!paramType5.IsValidInput<TArg5>(64, ref pAddress))
            {
                return false;
            }
            var paramType6 = parameters[6].ParameterType;
            if (!paramType6.IsValidInput<TArg6>(128, ref pAddress))
            {
                return false;
            }
            var paramType7 = parameters[7].ParameterType;
            if (!paramType7.IsValidInput<TArg7>(256, ref pAddress))
            {
                return false;
            }
            var paramType8 = parameters[8].ParameterType;
            if (!paramType8.IsValidInput<TArg8>(512, ref pAddress))
            {
                return false;
            }
            var paramType9 = parameters[9].ParameterType;
            if (!paramType9.IsValidInput<TArg9>(1024, ref pAddress))
            {
                return false;
            }
            var paramType10 = parameters[10].ParameterType;
            if (!paramType10.IsValidInput<TArg10>(2048, ref pAddress))
            {
                return false;
            }
            var paramType11 = parameters[11].ParameterType;
            if (!paramType11.IsValidInput<TArg11>(4096, ref pAddress))
            {
                return false;
            }
            var paramType12 = parameters[12].ParameterType;
            if (!paramType12.IsValidInput<TArg12>(8192, ref pAddress))
            {
                return false;
            }
            var paramType13 = parameters[13].ParameterType;
            if (!paramType13.IsValidInput<TArg13>(16384, ref pAddress))
            {
                return false;
            }
            if (pAddress != 0)
            {
                return false;
            }
            pAddress = method.GetFunctionPointer();
            return true;
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool ValidateInstanceReturnableVirtualMethodRaw<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TReturn>(MethodBase method, Type targetType, out nint pAddress)
        {
            pAddress = 0;
            if (method.IsStatic)
            {
                return false;
            }
            if (!method.IsOverridable())
            {
                return false;
            }
            var isValidGeneric = !method.IsGenericMethodDefinition || ValidateGenericReturnableMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TReturn>(ref method);
            if (!isValidGeneric)
            {
                return false;
            }
            var parameters = method.GetParametersFast();
            var parameterLength = parameters.Count;
            if (parameterLength != 14)
            {
                return false;
            }
            if (method is MethodInfo mi)
            {
                var returnType = mi?.ReturnType ?? typeof(void);
                if (!returnType.IsValidOutput<TReturn>())
                {
                    return false;
                }
            }
            var reflectedType = method.ReflectedType;
            if (!reflectedType.IsValidVirtualInput<TTarget>(targetType, out var isVirtualCall))
            {
                return false;
            }
            if (isVirtualCall)
            {
                ArrayCache.Types14[0] = parameters[0].ParameterType;
                ArrayCache.Types14[1] = parameters[1].ParameterType;
                ArrayCache.Types14[2] = parameters[2].ParameterType;
                ArrayCache.Types14[3] = parameters[3].ParameterType;
                ArrayCache.Types14[4] = parameters[4].ParameterType;
                ArrayCache.Types14[5] = parameters[5].ParameterType;
                ArrayCache.Types14[6] = parameters[6].ParameterType;
                ArrayCache.Types14[7] = parameters[7].ParameterType;
                ArrayCache.Types14[8] = parameters[8].ParameterType;
                ArrayCache.Types14[9] = parameters[9].ParameterType;
                ArrayCache.Types14[10] = parameters[10].ParameterType;
                ArrayCache.Types14[11] = parameters[11].ParameterType;
                ArrayCache.Types14[12] = parameters[12].ParameterType;
                ArrayCache.Types14[13] = parameters[13].ParameterType;
                method = targetType.GetInstanceMethodFullAccess(method.Name, null, ArrayCache.Types14, null);
            }
            var paramType0 = parameters[0].ParameterType;
            if (!paramType0.IsValidInput<TArg0>(2, ref pAddress))
            {
                return false;
            }
            var paramType1 = parameters[1].ParameterType;
            if (!paramType1.IsValidInput<TArg1>(4, ref pAddress))
            {
                return false;
            }
            var paramType2 = parameters[2].ParameterType;
            if (!paramType2.IsValidInput<TArg2>(8, ref pAddress))
            {
                return false;
            }
            var paramType3 = parameters[3].ParameterType;
            if (!paramType3.IsValidInput<TArg3>(16, ref pAddress))
            {
                return false;
            }
            var paramType4 = parameters[4].ParameterType;
            if (!paramType4.IsValidInput<TArg4>(32, ref pAddress))
            {
                return false;
            }
            var paramType5 = parameters[5].ParameterType;
            if (!paramType5.IsValidInput<TArg5>(64, ref pAddress))
            {
                return false;
            }
            var paramType6 = parameters[6].ParameterType;
            if (!paramType6.IsValidInput<TArg6>(128, ref pAddress))
            {
                return false;
            }
            var paramType7 = parameters[7].ParameterType;
            if (!paramType7.IsValidInput<TArg7>(256, ref pAddress))
            {
                return false;
            }
            var paramType8 = parameters[8].ParameterType;
            if (!paramType8.IsValidInput<TArg8>(512, ref pAddress))
            {
                return false;
            }
            var paramType9 = parameters[9].ParameterType;
            if (!paramType9.IsValidInput<TArg9>(1024, ref pAddress))
            {
                return false;
            }
            var paramType10 = parameters[10].ParameterType;
            if (!paramType10.IsValidInput<TArg10>(2048, ref pAddress))
            {
                return false;
            }
            var paramType11 = parameters[11].ParameterType;
            if (!paramType11.IsValidInput<TArg11>(4096, ref pAddress))
            {
                return false;
            }
            var paramType12 = parameters[12].ParameterType;
            if (!paramType12.IsValidInput<TArg12>(8192, ref pAddress))
            {
                return false;
            }
            var paramType13 = parameters[13].ParameterType;
            if (!paramType13.IsValidInput<TArg13>(16384, ref pAddress))
            {
                return false;
            }
            if (pAddress != 0)
            {
                return false;
            }
            pAddress = method.GetFunctionPointer();
            return true;
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool SecondaryValidateInstanceMethodRaw(MethodBase method, Type target, Type arg0, Type arg1, Type arg2, Type arg3, Type arg4, Type arg5, Type arg6, Type arg7, Type arg8, Type arg9, Type arg10, Type arg11, Type arg12, Type arg13, ref nint pAddress)
        {
            if ((pAddress & 1) != 0)
            {
                var reflectedType = method.ReflectedType;
                if (!reflectedType.IsNullAssignableFromFast(target))
                {
                    return false;
                }
            }
            var parameters = method.GetParametersFast();
            if ((pAddress & 2) != 0)
            {
                var paramType = parameters[0].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg0))
                {
                    return false;
                }
            }
            if ((pAddress & 4) != 0)
            {
                var paramType = parameters[1].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg1))
                {
                    return false;
                }
            }
            if ((pAddress & 8) != 0)
            {
                var paramType = parameters[2].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg2))
                {
                    return false;
                }
            }
            if ((pAddress & 16) != 0)
            {
                var paramType = parameters[3].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg3))
                {
                    return false;
                }
            }
            if ((pAddress & 32) != 0)
            {
                var paramType = parameters[4].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg4))
                {
                    return false;
                }
            }
            if ((pAddress & 64) != 0)
            {
                var paramType = parameters[5].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg5))
                {
                    return false;
                }
            }
            if ((pAddress & 128) != 0)
            {
                var paramType = parameters[6].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg6))
                {
                    return false;
                }
            }
            if ((pAddress & 256) != 0)
            {
                var paramType = parameters[7].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg7))
                {
                    return false;
                }
            }
            if ((pAddress & 512) != 0)
            {
                var paramType = parameters[8].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg8))
                {
                    return false;
                }
            }
            if ((pAddress & 1024) != 0)
            {
                var paramType = parameters[9].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg9))
                {
                    return false;
                }
            }
            if ((pAddress & 2048) != 0)
            {
                var paramType = parameters[10].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg10))
                {
                    return false;
                }
            }
            if ((pAddress & 4096) != 0)
            {
                var paramType = parameters[11].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg11))
                {
                    return false;
                }
            }
            if ((pAddress & 8192) != 0)
            {
                var paramType = parameters[12].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg12))
                {
                    return false;
                }
            }
            if ((pAddress & 16384) != 0)
            {
                var paramType = parameters[13].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg13))
                {
                    return false;
                }
            }
            pAddress = method.GetFunctionPointer();
            return true;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void InvokeStaticFast<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(this MethodBase self, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9, in TArg10 arg10, in TArg11 arg11, in TArg12 arg12, in TArg13 arg13)
        {
            bool isValid;
            nint pAddress;
            isValid = ValidateStaticMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(self, out pAddress) ||
                      (pAddress != 0 && SecondaryValidateStaticMethod(self, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), arg11?.GetType(), arg12?.GetType(), arg13?.GetType(), ref pAddress));
            if (!isValid)
            {
                self.InvokeStaticLowAlloc(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
                return;
            }
            unsafe
            {
                ((delegate*<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, void>)pAddress)(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
                return;
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static object InvokeStaticLowAlloc<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(this MethodBase self, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9, in TArg10 arg10, in TArg11 arg11, in TArg12 arg12, in TArg13 arg13)
        {
            if (self.IsGenericMethodDefinition)
            {
                ValidateGenericMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(ref self);
            }
            var parameters = self.GetParametersFast();
            ArrayCache.Objects14[0] = REReflection.GetBox(arg0, parameters[0], out var refArg0);
            ArrayCache.Objects14[1] = REReflection.GetBox(arg1, parameters[1], out var refArg1);
            ArrayCache.Objects14[2] = REReflection.GetBox(arg2, parameters[2], out var refArg2);
            ArrayCache.Objects14[3] = REReflection.GetBox(arg3, parameters[3], out var refArg3);
            ArrayCache.Objects14[4] = REReflection.GetBox(arg4, parameters[4], out var refArg4);
            ArrayCache.Objects14[5] = REReflection.GetBox(arg5, parameters[5], out var refArg5);
            ArrayCache.Objects14[6] = REReflection.GetBox(arg6, parameters[6], out var refArg6);
            ArrayCache.Objects14[7] = REReflection.GetBox(arg7, parameters[7], out var refArg7);
            ArrayCache.Objects14[8] = REReflection.GetBox(arg8, parameters[8], out var refArg8);
            ArrayCache.Objects14[9] = REReflection.GetBox(arg9, parameters[9], out var refArg9);
            ArrayCache.Objects14[10] = REReflection.GetBox(arg10, parameters[10], out var refArg10);
            ArrayCache.Objects14[11] = REReflection.GetBox(arg11, parameters[11], out var refArg11);
            ArrayCache.Objects14[12] = REReflection.GetBox(arg12, parameters[12], out var refArg12);
            ArrayCache.Objects14[13] = REReflection.GetBox(arg13, parameters[13], out var refArg13);
            try
            {
                return self.Invoke(null, ArrayCache.Objects14);
            }
            finally
            {
                REReflection.ReturnBox<TArg0>(ArrayCache.Objects14[0], parameters[0], refArg0);
                REReflection.ReturnBox<TArg1>(ArrayCache.Objects14[1], parameters[1], refArg1);
                REReflection.ReturnBox<TArg2>(ArrayCache.Objects14[2], parameters[2], refArg2);
                REReflection.ReturnBox<TArg3>(ArrayCache.Objects14[3], parameters[3], refArg3);
                REReflection.ReturnBox<TArg4>(ArrayCache.Objects14[4], parameters[4], refArg4);
                REReflection.ReturnBox<TArg5>(ArrayCache.Objects14[5], parameters[5], refArg5);
                REReflection.ReturnBox<TArg6>(ArrayCache.Objects14[6], parameters[6], refArg6);
                REReflection.ReturnBox<TArg7>(ArrayCache.Objects14[7], parameters[7], refArg7);
                REReflection.ReturnBox<TArg8>(ArrayCache.Objects14[8], parameters[8], refArg8);
                REReflection.ReturnBox<TArg9>(ArrayCache.Objects14[9], parameters[9], refArg9);
                REReflection.ReturnBox<TArg10>(ArrayCache.Objects14[10], parameters[10], refArg10);
                REReflection.ReturnBox<TArg11>(ArrayCache.Objects14[11], parameters[11], refArg11);
                REReflection.ReturnBox<TArg12>(ArrayCache.Objects14[12], parameters[12], refArg12);
                REReflection.ReturnBox<TArg13>(ArrayCache.Objects14[13], parameters[13], refArg13);
            }
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool ValidateStaticMethodRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(MethodBase method, out nint pAddress)
        {
            pAddress = 0;
            if (!method.IsStatic)
            {
                return false;
            }
            if (method.IsOverridable())
            {
                return false;
            }
            var isValidGeneric = !method.IsGenericMethodDefinition || ValidateGenericMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(ref method);
            if (!isValidGeneric)
            {
                return false;
            }
            var parameters = method.GetParametersFast();
            var parameterLength = parameters.Count;
            if (parameterLength != 14)
            {
                return false;
            }
            if (method is MethodInfo mi)
            {
                var returnType = mi?.ReturnType ?? typeof(void);
                if (returnType != typeof(void))
                {
                    return false;
                }
            }
            var paramType0 = parameters[0].ParameterType;
            if (!paramType0.IsValidInput<TArg0>(2, ref pAddress))
            {
                return false;
            }
            var paramType1 = parameters[1].ParameterType;
            if (!paramType1.IsValidInput<TArg1>(4, ref pAddress))
            {
                return false;
            }
            var paramType2 = parameters[2].ParameterType;
            if (!paramType2.IsValidInput<TArg2>(8, ref pAddress))
            {
                return false;
            }
            var paramType3 = parameters[3].ParameterType;
            if (!paramType3.IsValidInput<TArg3>(16, ref pAddress))
            {
                return false;
            }
            var paramType4 = parameters[4].ParameterType;
            if (!paramType4.IsValidInput<TArg4>(32, ref pAddress))
            {
                return false;
            }
            var paramType5 = parameters[5].ParameterType;
            if (!paramType5.IsValidInput<TArg5>(64, ref pAddress))
            {
                return false;
            }
            var paramType6 = parameters[6].ParameterType;
            if (!paramType6.IsValidInput<TArg6>(128, ref pAddress))
            {
                return false;
            }
            var paramType7 = parameters[7].ParameterType;
            if (!paramType7.IsValidInput<TArg7>(256, ref pAddress))
            {
                return false;
            }
            var paramType8 = parameters[8].ParameterType;
            if (!paramType8.IsValidInput<TArg8>(512, ref pAddress))
            {
                return false;
            }
            var paramType9 = parameters[9].ParameterType;
            if (!paramType9.IsValidInput<TArg9>(1024, ref pAddress))
            {
                return false;
            }
            var paramType10 = parameters[10].ParameterType;
            if (!paramType10.IsValidInput<TArg10>(2048, ref pAddress))
            {
                return false;
            }
            var paramType11 = parameters[11].ParameterType;
            if (!paramType11.IsValidInput<TArg11>(4096, ref pAddress))
            {
                return false;
            }
            var paramType12 = parameters[12].ParameterType;
            if (!paramType12.IsValidInput<TArg12>(8192, ref pAddress))
            {
                return false;
            }
            var paramType13 = parameters[13].ParameterType;
            if (!paramType13.IsValidInput<TArg13>(16384, ref pAddress))
            {
                return false;
            }
            if (pAddress != 0)
            {
                return false;
            }
            pAddress = method.GetFunctionPointer();
            return true;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TReturn InvokeStaticFast<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TReturn>(this MethodBase self, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9, in TArg10 arg10, in TArg11 arg11, in TArg12 arg12, in TArg13 arg13)
        {
            bool isValid;
            nint pAddress;
            isValid = ValidateStaticReturnableMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TReturn>(self, out pAddress) ||
                      (pAddress != 0 && SecondaryValidateStaticMethod(self, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), arg11?.GetType(), arg12?.GetType(), arg13?.GetType(), ref pAddress));
            if (!isValid)
            {
                return (TReturn)self.InvokeStaticLowAlloc(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
            }
            unsafe
            {
                return ((delegate*<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TReturn>)pAddress)(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
            }
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool ValidateStaticReturnableMethodRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TReturn>(MethodBase method, out nint pAddress)
        {
            pAddress = 0;
            if (!method.IsStatic)
            {
                return false;
            }
            if (method.IsOverridable())
            {
                return false;
            }
            var isValidGeneric = !method.IsGenericMethodDefinition || ValidateGenericReturnableMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TReturn>(ref method);
            if (!isValidGeneric)
            {
                return false;
            }
            var parameters = method.GetParametersFast();
            var parameterLength = parameters.Count;
            if (parameterLength != 14)
            {
                return false;
            }
            if (method is MethodInfo mi)
            {
                var returnType = mi?.ReturnType ?? typeof(void);
                if (!returnType.IsValidOutput<TReturn>())
                {
                    return false;
                }
            }
            var paramType0 = parameters[0].ParameterType;
            if (!paramType0.IsValidInput<TArg0>(2, ref pAddress))
            {
                return false;
            }
            var paramType1 = parameters[1].ParameterType;
            if (!paramType1.IsValidInput<TArg1>(4, ref pAddress))
            {
                return false;
            }
            var paramType2 = parameters[2].ParameterType;
            if (!paramType2.IsValidInput<TArg2>(8, ref pAddress))
            {
                return false;
            }
            var paramType3 = parameters[3].ParameterType;
            if (!paramType3.IsValidInput<TArg3>(16, ref pAddress))
            {
                return false;
            }
            var paramType4 = parameters[4].ParameterType;
            if (!paramType4.IsValidInput<TArg4>(32, ref pAddress))
            {
                return false;
            }
            var paramType5 = parameters[5].ParameterType;
            if (!paramType5.IsValidInput<TArg5>(64, ref pAddress))
            {
                return false;
            }
            var paramType6 = parameters[6].ParameterType;
            if (!paramType6.IsValidInput<TArg6>(128, ref pAddress))
            {
                return false;
            }
            var paramType7 = parameters[7].ParameterType;
            if (!paramType7.IsValidInput<TArg7>(256, ref pAddress))
            {
                return false;
            }
            var paramType8 = parameters[8].ParameterType;
            if (!paramType8.IsValidInput<TArg8>(512, ref pAddress))
            {
                return false;
            }
            var paramType9 = parameters[9].ParameterType;
            if (!paramType9.IsValidInput<TArg9>(1024, ref pAddress))
            {
                return false;
            }
            var paramType10 = parameters[10].ParameterType;
            if (!paramType10.IsValidInput<TArg10>(2048, ref pAddress))
            {
                return false;
            }
            var paramType11 = parameters[11].ParameterType;
            if (!paramType11.IsValidInput<TArg11>(4096, ref pAddress))
            {
                return false;
            }
            var paramType12 = parameters[12].ParameterType;
            if (!paramType12.IsValidInput<TArg12>(8192, ref pAddress))
            {
                return false;
            }
            var paramType13 = parameters[13].ParameterType;
            if (!paramType13.IsValidInput<TArg13>(16384, ref pAddress))
            {
                return false;
            }
            if (pAddress != 0)
            {
                return false;
            }
            pAddress = method.GetFunctionPointer();
            return true;
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool SecondaryValidateStaticMethodRaw(MethodBase method, Type arg0, Type arg1, Type arg2, Type arg3, Type arg4, Type arg5, Type arg6, Type arg7, Type arg8, Type arg9, Type arg10, Type arg11, Type arg12, Type arg13, ref nint pAddress)
        {
            var parameters = method.GetParametersFast();
            if ((pAddress & 2) != 0)
            {
                var paramType = parameters[0].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg0))
                {
                    return false;
                }
            }
            if ((pAddress & 4) != 0)
            {
                var paramType = parameters[1].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg1))
                {
                    return false;
                }
            }
            if ((pAddress & 8) != 0)
            {
                var paramType = parameters[2].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg2))
                {
                    return false;
                }
            }
            if ((pAddress & 16) != 0)
            {
                var paramType = parameters[3].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg3))
                {
                    return false;
                }
            }
            if ((pAddress & 32) != 0)
            {
                var paramType = parameters[4].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg4))
                {
                    return false;
                }
            }
            if ((pAddress & 64) != 0)
            {
                var paramType = parameters[5].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg5))
                {
                    return false;
                }
            }
            if ((pAddress & 128) != 0)
            {
                var paramType = parameters[6].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg6))
                {
                    return false;
                }
            }
            if ((pAddress & 256) != 0)
            {
                var paramType = parameters[7].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg7))
                {
                    return false;
                }
            }
            if ((pAddress & 512) != 0)
            {
                var paramType = parameters[8].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg8))
                {
                    return false;
                }
            }
            if ((pAddress & 1024) != 0)
            {
                var paramType = parameters[9].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg9))
                {
                    return false;
                }
            }
            if ((pAddress & 2048) != 0)
            {
                var paramType = parameters[10].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg10))
                {
                    return false;
                }
            }
            if ((pAddress & 4096) != 0)
            {
                var paramType = parameters[11].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg11))
                {
                    return false;
                }
            }
            if ((pAddress & 8192) != 0)
            {
                var paramType = parameters[12].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg12))
                {
                    return false;
                }
            }
            if ((pAddress & 16384) != 0)
            {
                var paramType = parameters[13].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg13))
                {
                    return false;
                }
            }
            pAddress = method.GetFunctionPointer();
            return true;
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool ValidateGenericMethodRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(ref MethodBase method)
        {
            if (!method.IsGenericMethodDefinition)
            {
                return true;
            }
            var genericArguments = method.GetGenericArgumentsFast();
            if (genericArguments.Count < 14)
            {
                return false;
            }
            uint mask = 0;
            var mi = method as MethodInfo;
            var parameters = method.GetParametersFast();
            var index0 = IndexOf(genericArguments, parameters[0].ParameterType);
            if (index0 >= 0)
            {
                mask |= 1u << index0;
            }
            var index1 = IndexOf(genericArguments, parameters[1].ParameterType);
            if (index1 >= 0)
            {
                mask |= 1u << index1;
            }
            var index2 = IndexOf(genericArguments, parameters[2].ParameterType);
            if (index2 >= 0)
            {
                mask |= 1u << index2;
            }
            var index3 = IndexOf(genericArguments, parameters[3].ParameterType);
            if (index3 >= 0)
            {
                mask |= 1u << index3;
            }
            var index4 = IndexOf(genericArguments, parameters[4].ParameterType);
            if (index4 >= 0)
            {
                mask |= 1u << index4;
            }
            var index5 = IndexOf(genericArguments, parameters[5].ParameterType);
            if (index5 >= 0)
            {
                mask |= 1u << index5;
            }
            var index6 = IndexOf(genericArguments, parameters[6].ParameterType);
            if (index6 >= 0)
            {
                mask |= 1u << index6;
            }
            var index7 = IndexOf(genericArguments, parameters[7].ParameterType);
            if (index7 >= 0)
            {
                mask |= 1u << index7;
            }
            var index8 = IndexOf(genericArguments, parameters[8].ParameterType);
            if (index8 >= 0)
            {
                mask |= 1u << index8;
            }
            var index9 = IndexOf(genericArguments, parameters[9].ParameterType);
            if (index9 >= 0)
            {
                mask |= 1u << index9;
            }
            var index10 = IndexOf(genericArguments, parameters[10].ParameterType);
            if (index10 >= 0)
            {
                mask |= 1u << index10;
            }
            var index11 = IndexOf(genericArguments, parameters[11].ParameterType);
            if (index11 >= 0)
            {
                mask |= 1u << index11;
            }
            var index12 = IndexOf(genericArguments, parameters[12].ParameterType);
            if (index12 >= 0)
            {
                mask |= 1u << index12;
            }
            var index13 = IndexOf(genericArguments, parameters[13].ParameterType);
            if (index13 >= 0)
            {
                mask |= 1u << index13;
            }
            if (REReflection.BitCount(mask) != genericArguments.Count)
            {
                return false;
            }
            var types = ArrayCache.GetArrayCache<Type>(genericArguments.Count);
            if (index0 >= 0)
            {
                types[index0] = typeof(TArg0);
            }
            if (index1 >= 0)
            {
                types[index1] = typeof(TArg1);
            }
            if (index2 >= 0)
            {
                types[index2] = typeof(TArg2);
            }
            if (index3 >= 0)
            {
                types[index3] = typeof(TArg3);
            }
            if (index4 >= 0)
            {
                types[index4] = typeof(TArg4);
            }
            if (index5 >= 0)
            {
                types[index5] = typeof(TArg5);
            }
            if (index6 >= 0)
            {
                types[index6] = typeof(TArg6);
            }
            if (index7 >= 0)
            {
                types[index7] = typeof(TArg7);
            }
            if (index8 >= 0)
            {
                types[index8] = typeof(TArg8);
            }
            if (index9 >= 0)
            {
                types[index9] = typeof(TArg9);
            }
            if (index10 >= 0)
            {
                types[index10] = typeof(TArg10);
            }
            if (index11 >= 0)
            {
                types[index11] = typeof(TArg11);
            }
            if (index12 >= 0)
            {
                types[index12] = typeof(TArg12);
            }
            if (index13 >= 0)
            {
                types[index13] = typeof(TArg13);
            }
            #if ENABLE_IL2CPP
            bool isFound = false;
            var usingMethods = method.GetUsingGenericInstanceMethods();
            foreach (var usingMethod in usingMethods)
            {
                if (usingMethod.GetGenericArgumentsFast().SequenceEqual(types))
                {
                    isFound = true;
                    break;
                }
            }
            if (!isFound)
            {
                return false;
            }
            #endif
            method = mi.MakeGenericMethodFast(types);
            return true;
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool ValidateGenericReturnableMethodRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TReturn>(ref MethodBase method)
        {
            if (!method.IsGenericMethodDefinition)
            {
                return true;
            }
            var genericArguments = method.GetGenericArgumentsFast();
            if (genericArguments.Count < 15)
            {
                return false;
            }
            uint mask = 0;
            var mi = method as MethodInfo;
            var returnType = mi.ReturnType ?? typeof(void);
            var index = IndexOf(genericArguments, returnType);
            if (index >= 0)
            {
                mask |= 1u << index;
            }
            var parameters = method.GetParametersFast();
            var index0 = IndexOf(genericArguments, parameters[0].ParameterType);
            if (index0 >= 0)
            {
                mask |= 1u << index0;
            }
            var index1 = IndexOf(genericArguments, parameters[1].ParameterType);
            if (index1 >= 0)
            {
                mask |= 1u << index1;
            }
            var index2 = IndexOf(genericArguments, parameters[2].ParameterType);
            if (index2 >= 0)
            {
                mask |= 1u << index2;
            }
            var index3 = IndexOf(genericArguments, parameters[3].ParameterType);
            if (index3 >= 0)
            {
                mask |= 1u << index3;
            }
            var index4 = IndexOf(genericArguments, parameters[4].ParameterType);
            if (index4 >= 0)
            {
                mask |= 1u << index4;
            }
            var index5 = IndexOf(genericArguments, parameters[5].ParameterType);
            if (index5 >= 0)
            {
                mask |= 1u << index5;
            }
            var index6 = IndexOf(genericArguments, parameters[6].ParameterType);
            if (index6 >= 0)
            {
                mask |= 1u << index6;
            }
            var index7 = IndexOf(genericArguments, parameters[7].ParameterType);
            if (index7 >= 0)
            {
                mask |= 1u << index7;
            }
            var index8 = IndexOf(genericArguments, parameters[8].ParameterType);
            if (index8 >= 0)
            {
                mask |= 1u << index8;
            }
            var index9 = IndexOf(genericArguments, parameters[9].ParameterType);
            if (index9 >= 0)
            {
                mask |= 1u << index9;
            }
            var index10 = IndexOf(genericArguments, parameters[10].ParameterType);
            if (index10 >= 0)
            {
                mask |= 1u << index10;
            }
            var index11 = IndexOf(genericArguments, parameters[11].ParameterType);
            if (index11 >= 0)
            {
                mask |= 1u << index11;
            }
            var index12 = IndexOf(genericArguments, parameters[12].ParameterType);
            if (index12 >= 0)
            {
                mask |= 1u << index12;
            }
            var index13 = IndexOf(genericArguments, parameters[13].ParameterType);
            if (index13 >= 0)
            {
                mask |= 1u << index13;
            }
            if (REReflection.BitCount(mask) != genericArguments.Count)
            {
                return false;
            }
            var types = ArrayCache.GetArrayCache<Type>(genericArguments.Count);
            if (index >= 0)
            {
                types[index] = typeof(TReturn);
            }
            if (index0 >= 0)
            {
                types[index0] = typeof(TArg0);
            }
            if (index1 >= 0)
            {
                types[index1] = typeof(TArg1);
            }
            if (index2 >= 0)
            {
                types[index2] = typeof(TArg2);
            }
            if (index3 >= 0)
            {
                types[index3] = typeof(TArg3);
            }
            if (index4 >= 0)
            {
                types[index4] = typeof(TArg4);
            }
            if (index5 >= 0)
            {
                types[index5] = typeof(TArg5);
            }
            if (index6 >= 0)
            {
                types[index6] = typeof(TArg6);
            }
            if (index7 >= 0)
            {
                types[index7] = typeof(TArg7);
            }
            if (index8 >= 0)
            {
                types[index8] = typeof(TArg8);
            }
            if (index9 >= 0)
            {
                types[index9] = typeof(TArg9);
            }
            if (index10 >= 0)
            {
                types[index10] = typeof(TArg10);
            }
            if (index11 >= 0)
            {
                types[index11] = typeof(TArg11);
            }
            if (index12 >= 0)
            {
                types[index12] = typeof(TArg12);
            }
            if (index13 >= 0)
            {
                types[index13] = typeof(TArg13);
            }
            #if ENABLE_IL2CPP
            bool isFound = false;
            var usingMethods = method.GetUsingGenericInstanceMethods();
            foreach (var usingMethod in usingMethods)
            {
                if (usingMethod.GetGenericArgumentsFast().SequenceEqual(types))
                {
                    isFound = true;
                    break;
                }
            }
            if (!isFound)
            {
                return false;
            }
            #endif
            method = mi.MakeGenericMethodFast(types);
            return true;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void InvokeInstanceFast<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(this MethodBase self, ref TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9, in TArg10 arg10, in TArg11 arg11, in TArg12 arg12, in TArg13 arg13, in TArg14 arg14)
        {
            bool isValid;
            nint pAddress;
            if (self.IsOverridable())
            {
                isValid = ValidateInstanceVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(self, target?.GetType(), out pAddress) ||
                          (pAddress != 0 && SecondaryValidateStaticMethod(self, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), arg11?.GetType(), arg12?.GetType(), arg13?.GetType(), arg14?.GetType(), ref pAddress));
            }
            else
            {
                isValid = ValidateInstanceMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(self, out pAddress) ||
                          (pAddress != 0 && SecondaryValidateInstanceMethod(self, target?.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), arg11?.GetType(), arg12?.GetType(), arg13?.GetType(), arg14?.GetType(), ref pAddress));
            }
            if (!isValid)
            {
                self.InvokeInstanceLowAlloc(ref target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
                return;
            }
            unsafe
            {
                if (REType.IsValueTypeFast<TTarget>())
                {
                    ((delegate*<ref TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, void>)pAddress)(ref target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
                    return;
                }
                ((delegate*<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, void>)pAddress)(target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
                return;
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void InvokeClassInstanceFast<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(this MethodBase self, TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9, in TArg10 arg10, in TArg11 arg11, in TArg12 arg12, in TArg13 arg13, in TArg14 arg14)
        where TTarget: class
        {
            bool isValid;
            nint pAddress;
            if (self.IsOverridable())
            {
                isValid = ValidateInstanceVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(self, target?.GetType(), out pAddress) ||
                          (pAddress != 0 && SecondaryValidateStaticMethod(self, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), arg11?.GetType(), arg12?.GetType(), arg13?.GetType(), arg14?.GetType(), ref pAddress));
            }
            else
            {
                isValid = ValidateInstanceMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(self, out pAddress) ||
                          (pAddress != 0 && SecondaryValidateInstanceMethod(self, target?.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), arg11?.GetType(), arg12?.GetType(), arg13?.GetType(), arg14?.GetType(), ref pAddress));
            }
            if (!isValid)
            {
                self.InvokeClassInstanceLowAlloc(target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
                return;
            }
            unsafe
            {
                ((delegate*<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, void>)pAddress)(target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
                return;
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void InvokeStructInstanceFast<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(this MethodBase self, ref TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9, in TArg10 arg10, in TArg11 arg11, in TArg12 arg12, in TArg13 arg13, in TArg14 arg14)
        where TTarget: struct
        {
            bool isValid;
            nint pAddress;
            if (self.IsOverridable())
            {
                isValid = ValidateInstanceVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(self, target.GetType(), out pAddress) ||
                          (pAddress != 0 && SecondaryValidateStaticMethod(self, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), arg11?.GetType(), arg12?.GetType(), arg13?.GetType(), arg14?.GetType(), ref pAddress));
            }
            else
            {
                isValid = ValidateInstanceMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(self, out pAddress) ||
                          (pAddress != 0 && SecondaryValidateInstanceMethod(self, target.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), arg11?.GetType(), arg12?.GetType(), arg13?.GetType(), arg14?.GetType(), ref pAddress));
            }
            if (!isValid)
            {
                self.InvokeInstanceLowAlloc(ref target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
                return;
            }
            unsafe
            {
                ((delegate*<ref TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, void>)pAddress)(ref target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
                return;
            }
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool ValidateInstanceMethodRaw<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(MethodBase method, out nint pAddress)
        {
            pAddress = 0;
            if (method.IsStatic)
            {
                return false;
            }
            if (method.IsOverridable())
            {
                return false;
            }
            var isValidGeneric = !method.IsGenericMethodDefinition || ValidateGenericMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(ref method);
            if (!isValidGeneric)
            {
                return false;
            }
            var parameters = method.GetParametersFast();
            var parameterLength = parameters.Count;
            if (parameterLength != 15)
            {
                return false;
            }
            if (method is MethodInfo mi)
            {
                var returnType = mi?.ReturnType ?? typeof(void);
                if (returnType != typeof(void))
                {
                    return false;
                }
            }
            var reflectedType = method.ReflectedType;
            if (!reflectedType.IsValidInputWithoutRef<TTarget>(1, ref pAddress))
            {
                return false;
            }
            var paramType0 = parameters[0].ParameterType;
            if (!paramType0.IsValidInput<TArg0>(2, ref pAddress))
            {
                return false;
            }
            var paramType1 = parameters[1].ParameterType;
            if (!paramType1.IsValidInput<TArg1>(4, ref pAddress))
            {
                return false;
            }
            var paramType2 = parameters[2].ParameterType;
            if (!paramType2.IsValidInput<TArg2>(8, ref pAddress))
            {
                return false;
            }
            var paramType3 = parameters[3].ParameterType;
            if (!paramType3.IsValidInput<TArg3>(16, ref pAddress))
            {
                return false;
            }
            var paramType4 = parameters[4].ParameterType;
            if (!paramType4.IsValidInput<TArg4>(32, ref pAddress))
            {
                return false;
            }
            var paramType5 = parameters[5].ParameterType;
            if (!paramType5.IsValidInput<TArg5>(64, ref pAddress))
            {
                return false;
            }
            var paramType6 = parameters[6].ParameterType;
            if (!paramType6.IsValidInput<TArg6>(128, ref pAddress))
            {
                return false;
            }
            var paramType7 = parameters[7].ParameterType;
            if (!paramType7.IsValidInput<TArg7>(256, ref pAddress))
            {
                return false;
            }
            var paramType8 = parameters[8].ParameterType;
            if (!paramType8.IsValidInput<TArg8>(512, ref pAddress))
            {
                return false;
            }
            var paramType9 = parameters[9].ParameterType;
            if (!paramType9.IsValidInput<TArg9>(1024, ref pAddress))
            {
                return false;
            }
            var paramType10 = parameters[10].ParameterType;
            if (!paramType10.IsValidInput<TArg10>(2048, ref pAddress))
            {
                return false;
            }
            var paramType11 = parameters[11].ParameterType;
            if (!paramType11.IsValidInput<TArg11>(4096, ref pAddress))
            {
                return false;
            }
            var paramType12 = parameters[12].ParameterType;
            if (!paramType12.IsValidInput<TArg12>(8192, ref pAddress))
            {
                return false;
            }
            var paramType13 = parameters[13].ParameterType;
            if (!paramType13.IsValidInput<TArg13>(16384, ref pAddress))
            {
                return false;
            }
            var paramType14 = parameters[14].ParameterType;
            if (!paramType14.IsValidInput<TArg14>(32768, ref pAddress))
            {
                return false;
            }
            if (pAddress != 0)
            {
                return false;
            }
            pAddress = method.GetFunctionPointer();
            return true;
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool ValidateInstanceVirtualMethodRaw<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(MethodBase method, Type targetType, out nint pAddress)
        {
            pAddress = 0;
            if (method.IsStatic)
            {
                return false;
            }
            if (!method.IsOverridable())
            {
                return false;
            }
            var isValidGeneric = !method.IsGenericMethodDefinition || ValidateGenericMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(ref method);
            if (!isValidGeneric)
            {
                return false;
            }
            var parameters = method.GetParametersFast();
            var parameterLength = parameters.Count;
            if (parameterLength != 15)
            {
                return false;
            }
            if (method is MethodInfo mi)
            {
                var returnType = mi?.ReturnType ?? typeof(void);
                if (returnType != typeof(void))
                {
                    return false;
                }
            }
            var reflectedType = method.ReflectedType;
            if (!reflectedType.IsValidVirtualInput<TTarget>(targetType, out var isVirtualCall))
            {
                return false;
            }
            if (isVirtualCall)
            {
                ArrayCache.Types15[0] = parameters[0].ParameterType;
                ArrayCache.Types15[1] = parameters[1].ParameterType;
                ArrayCache.Types15[2] = parameters[2].ParameterType;
                ArrayCache.Types15[3] = parameters[3].ParameterType;
                ArrayCache.Types15[4] = parameters[4].ParameterType;
                ArrayCache.Types15[5] = parameters[5].ParameterType;
                ArrayCache.Types15[6] = parameters[6].ParameterType;
                ArrayCache.Types15[7] = parameters[7].ParameterType;
                ArrayCache.Types15[8] = parameters[8].ParameterType;
                ArrayCache.Types15[9] = parameters[9].ParameterType;
                ArrayCache.Types15[10] = parameters[10].ParameterType;
                ArrayCache.Types15[11] = parameters[11].ParameterType;
                ArrayCache.Types15[12] = parameters[12].ParameterType;
                ArrayCache.Types15[13] = parameters[13].ParameterType;
                ArrayCache.Types15[14] = parameters[14].ParameterType;
                method = targetType.GetInstanceMethodFullAccess(method.Name, null, ArrayCache.Types15, null);
            }
            var paramType0 = parameters[0].ParameterType;
            if (!paramType0.IsValidInput<TArg0>(2, ref pAddress))
            {
                return false;
            }
            var paramType1 = parameters[1].ParameterType;
            if (!paramType1.IsValidInput<TArg1>(4, ref pAddress))
            {
                return false;
            }
            var paramType2 = parameters[2].ParameterType;
            if (!paramType2.IsValidInput<TArg2>(8, ref pAddress))
            {
                return false;
            }
            var paramType3 = parameters[3].ParameterType;
            if (!paramType3.IsValidInput<TArg3>(16, ref pAddress))
            {
                return false;
            }
            var paramType4 = parameters[4].ParameterType;
            if (!paramType4.IsValidInput<TArg4>(32, ref pAddress))
            {
                return false;
            }
            var paramType5 = parameters[5].ParameterType;
            if (!paramType5.IsValidInput<TArg5>(64, ref pAddress))
            {
                return false;
            }
            var paramType6 = parameters[6].ParameterType;
            if (!paramType6.IsValidInput<TArg6>(128, ref pAddress))
            {
                return false;
            }
            var paramType7 = parameters[7].ParameterType;
            if (!paramType7.IsValidInput<TArg7>(256, ref pAddress))
            {
                return false;
            }
            var paramType8 = parameters[8].ParameterType;
            if (!paramType8.IsValidInput<TArg8>(512, ref pAddress))
            {
                return false;
            }
            var paramType9 = parameters[9].ParameterType;
            if (!paramType9.IsValidInput<TArg9>(1024, ref pAddress))
            {
                return false;
            }
            var paramType10 = parameters[10].ParameterType;
            if (!paramType10.IsValidInput<TArg10>(2048, ref pAddress))
            {
                return false;
            }
            var paramType11 = parameters[11].ParameterType;
            if (!paramType11.IsValidInput<TArg11>(4096, ref pAddress))
            {
                return false;
            }
            var paramType12 = parameters[12].ParameterType;
            if (!paramType12.IsValidInput<TArg12>(8192, ref pAddress))
            {
                return false;
            }
            var paramType13 = parameters[13].ParameterType;
            if (!paramType13.IsValidInput<TArg13>(16384, ref pAddress))
            {
                return false;
            }
            var paramType14 = parameters[14].ParameterType;
            if (!paramType14.IsValidInput<TArg14>(32768, ref pAddress))
            {
                return false;
            }
            if (pAddress != 0)
            {
                return false;
            }
            pAddress = method.GetFunctionPointer();
            return true;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TReturn InvokeInstanceFast<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TReturn>(this MethodBase self, ref TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9, in TArg10 arg10, in TArg11 arg11, in TArg12 arg12, in TArg13 arg13, in TArg14 arg14)
        {
            bool isValid;
            nint pAddress;
            if (self.IsOverridable())
            {
                isValid = ValidateInstanceReturnableVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TReturn>(self, target?.GetType(), out pAddress) ||
                          (pAddress != 0 && SecondaryValidateStaticMethod(self, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), arg11?.GetType(), arg12?.GetType(), arg13?.GetType(), arg14?.GetType(), ref pAddress));
            }
            else
            {
                isValid = ValidateInstanceReturnableMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TReturn>(self, out pAddress) ||
                          (pAddress != 0 && SecondaryValidateInstanceMethod(self, target?.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), arg11?.GetType(), arg12?.GetType(), arg13?.GetType(), arg14?.GetType(), ref pAddress));
            }
            if (!isValid)
            {
                return (TReturn)self.InvokeInstanceLowAlloc(ref target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
            }
            unsafe
            {
                if (REType.IsValueTypeFast<TTarget>())
                {
                    return ((delegate*<ref TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TReturn>)pAddress)(ref target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
                }
                return ((delegate*<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TReturn>)pAddress)(target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TReturn InvokeClassInstanceFast<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TReturn>(this MethodBase self, TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9, in TArg10 arg10, in TArg11 arg11, in TArg12 arg12, in TArg13 arg13, in TArg14 arg14)
        where TTarget: class
        {
            bool isValid;
            nint pAddress;
            if (self.IsOverridable())
            {
                isValid = ValidateInstanceReturnableVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TReturn>(self, target?.GetType(), out pAddress) ||
                          (pAddress != 0 && SecondaryValidateStaticMethod(self, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), arg11?.GetType(), arg12?.GetType(), arg13?.GetType(), arg14?.GetType(), ref pAddress));
            }
            else
            {
                isValid = ValidateInstanceReturnableMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TReturn>(self, out pAddress) ||
                          (pAddress != 0 && SecondaryValidateInstanceMethod(self, target?.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), arg11?.GetType(), arg12?.GetType(), arg13?.GetType(), arg14?.GetType(), ref pAddress));
            }
            if (!isValid)
            {
                return (TReturn)self.InvokeClassInstanceLowAlloc(target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
            }
            unsafe
            {
                return ((delegate*<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TReturn>)pAddress)(target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TReturn InvokeStructInstanceFast<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TReturn>(this MethodBase self, ref TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9, in TArg10 arg10, in TArg11 arg11, in TArg12 arg12, in TArg13 arg13, in TArg14 arg14)
        where TTarget: struct
        {
            bool isValid;
            nint pAddress;
            if (self.IsOverridable())
            {
                isValid = ValidateInstanceReturnableVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TReturn>(self, target.GetType(), out pAddress) ||
                          (pAddress != 0 && SecondaryValidateStaticMethod(self, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), arg11?.GetType(), arg12?.GetType(), arg13?.GetType(), arg14?.GetType(), ref pAddress));
            }
            else
            {
                isValid = ValidateInstanceReturnableMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TReturn>(self, out pAddress) ||
                          (pAddress != 0 && SecondaryValidateInstanceMethod(self, target.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), arg11?.GetType(), arg12?.GetType(), arg13?.GetType(), arg14?.GetType(), ref pAddress));
            }
            if (!isValid)
            {
                return (TReturn)self.InvokeInstanceLowAlloc(ref target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
            }
            unsafe
            {
                return ((delegate*<ref TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TReturn>)pAddress)(ref target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static object InvokeInstanceLowAlloc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(this MethodBase self, ref TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9, in TArg10 arg10, in TArg11 arg11, in TArg12 arg12, in TArg13 arg13, in TArg14 arg14)
        {
            if (self.IsGenericMethodDefinition)
            {
                ValidateGenericMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(ref self);
            }
            var targetObj = REReflection.GetBoxWithoutRef(target);
            var parameters = self.GetParametersFast();
            ArrayCache.Objects15[0] = REReflection.GetBox(arg0, parameters[0], out var refArg0);
            ArrayCache.Objects15[1] = REReflection.GetBox(arg1, parameters[1], out var refArg1);
            ArrayCache.Objects15[2] = REReflection.GetBox(arg2, parameters[2], out var refArg2);
            ArrayCache.Objects15[3] = REReflection.GetBox(arg3, parameters[3], out var refArg3);
            ArrayCache.Objects15[4] = REReflection.GetBox(arg4, parameters[4], out var refArg4);
            ArrayCache.Objects15[5] = REReflection.GetBox(arg5, parameters[5], out var refArg5);
            ArrayCache.Objects15[6] = REReflection.GetBox(arg6, parameters[6], out var refArg6);
            ArrayCache.Objects15[7] = REReflection.GetBox(arg7, parameters[7], out var refArg7);
            ArrayCache.Objects15[8] = REReflection.GetBox(arg8, parameters[8], out var refArg8);
            ArrayCache.Objects15[9] = REReflection.GetBox(arg9, parameters[9], out var refArg9);
            ArrayCache.Objects15[10] = REReflection.GetBox(arg10, parameters[10], out var refArg10);
            ArrayCache.Objects15[11] = REReflection.GetBox(arg11, parameters[11], out var refArg11);
            ArrayCache.Objects15[12] = REReflection.GetBox(arg12, parameters[12], out var refArg12);
            ArrayCache.Objects15[13] = REReflection.GetBox(arg13, parameters[13], out var refArg13);
            ArrayCache.Objects15[14] = REReflection.GetBox(arg14, parameters[14], out var refArg14);
            try
            {
                return self.Invoke(targetObj, ArrayCache.Objects15);
            }
            finally
            {
                REReflection.Unbox(targetObj, out target);
                REReflection.ReturnBoxWithoutRef<TTarget>(targetObj);
                REReflection.ReturnBox<TArg0>(ArrayCache.Objects15[0], parameters[0], refArg0);
                REReflection.ReturnBox<TArg1>(ArrayCache.Objects15[1], parameters[1], refArg1);
                REReflection.ReturnBox<TArg2>(ArrayCache.Objects15[2], parameters[2], refArg2);
                REReflection.ReturnBox<TArg3>(ArrayCache.Objects15[3], parameters[3], refArg3);
                REReflection.ReturnBox<TArg4>(ArrayCache.Objects15[4], parameters[4], refArg4);
                REReflection.ReturnBox<TArg5>(ArrayCache.Objects15[5], parameters[5], refArg5);
                REReflection.ReturnBox<TArg6>(ArrayCache.Objects15[6], parameters[6], refArg6);
                REReflection.ReturnBox<TArg7>(ArrayCache.Objects15[7], parameters[7], refArg7);
                REReflection.ReturnBox<TArg8>(ArrayCache.Objects15[8], parameters[8], refArg8);
                REReflection.ReturnBox<TArg9>(ArrayCache.Objects15[9], parameters[9], refArg9);
                REReflection.ReturnBox<TArg10>(ArrayCache.Objects15[10], parameters[10], refArg10);
                REReflection.ReturnBox<TArg11>(ArrayCache.Objects15[11], parameters[11], refArg11);
                REReflection.ReturnBox<TArg12>(ArrayCache.Objects15[12], parameters[12], refArg12);
                REReflection.ReturnBox<TArg13>(ArrayCache.Objects15[13], parameters[13], refArg13);
                REReflection.ReturnBox<TArg14>(ArrayCache.Objects15[14], parameters[14], refArg14);
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static object InvokeClassInstanceLowAlloc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(this MethodBase self, TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9, in TArg10 arg10, in TArg11 arg11, in TArg12 arg12, in TArg13 arg13, in TArg14 arg14)
        where TTarget: class
        {
            if (self.IsGenericMethodDefinition)
            {
                ValidateGenericMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(ref self);
            }
            var parameters = self.GetParametersFast();
            ArrayCache.Objects15[0] = REReflection.GetBox(arg0, parameters[0], out var refArg0);
            ArrayCache.Objects15[1] = REReflection.GetBox(arg1, parameters[1], out var refArg1);
            ArrayCache.Objects15[2] = REReflection.GetBox(arg2, parameters[2], out var refArg2);
            ArrayCache.Objects15[3] = REReflection.GetBox(arg3, parameters[3], out var refArg3);
            ArrayCache.Objects15[4] = REReflection.GetBox(arg4, parameters[4], out var refArg4);
            ArrayCache.Objects15[5] = REReflection.GetBox(arg5, parameters[5], out var refArg5);
            ArrayCache.Objects15[6] = REReflection.GetBox(arg6, parameters[6], out var refArg6);
            ArrayCache.Objects15[7] = REReflection.GetBox(arg7, parameters[7], out var refArg7);
            ArrayCache.Objects15[8] = REReflection.GetBox(arg8, parameters[8], out var refArg8);
            ArrayCache.Objects15[9] = REReflection.GetBox(arg9, parameters[9], out var refArg9);
            ArrayCache.Objects15[10] = REReflection.GetBox(arg10, parameters[10], out var refArg10);
            ArrayCache.Objects15[11] = REReflection.GetBox(arg11, parameters[11], out var refArg11);
            ArrayCache.Objects15[12] = REReflection.GetBox(arg12, parameters[12], out var refArg12);
            ArrayCache.Objects15[13] = REReflection.GetBox(arg13, parameters[13], out var refArg13);
            ArrayCache.Objects15[14] = REReflection.GetBox(arg14, parameters[14], out var refArg14);
            try
            {
                return self.Invoke(target, ArrayCache.Objects15);
            }
            finally
            {
                REReflection.ReturnBox<TArg0>(ArrayCache.Objects15[0], parameters[0], refArg0);
                REReflection.ReturnBox<TArg1>(ArrayCache.Objects15[1], parameters[1], refArg1);
                REReflection.ReturnBox<TArg2>(ArrayCache.Objects15[2], parameters[2], refArg2);
                REReflection.ReturnBox<TArg3>(ArrayCache.Objects15[3], parameters[3], refArg3);
                REReflection.ReturnBox<TArg4>(ArrayCache.Objects15[4], parameters[4], refArg4);
                REReflection.ReturnBox<TArg5>(ArrayCache.Objects15[5], parameters[5], refArg5);
                REReflection.ReturnBox<TArg6>(ArrayCache.Objects15[6], parameters[6], refArg6);
                REReflection.ReturnBox<TArg7>(ArrayCache.Objects15[7], parameters[7], refArg7);
                REReflection.ReturnBox<TArg8>(ArrayCache.Objects15[8], parameters[8], refArg8);
                REReflection.ReturnBox<TArg9>(ArrayCache.Objects15[9], parameters[9], refArg9);
                REReflection.ReturnBox<TArg10>(ArrayCache.Objects15[10], parameters[10], refArg10);
                REReflection.ReturnBox<TArg11>(ArrayCache.Objects15[11], parameters[11], refArg11);
                REReflection.ReturnBox<TArg12>(ArrayCache.Objects15[12], parameters[12], refArg12);
                REReflection.ReturnBox<TArg13>(ArrayCache.Objects15[13], parameters[13], refArg13);
                REReflection.ReturnBox<TArg14>(ArrayCache.Objects15[14], parameters[14], refArg14);
            }
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool ValidateInstanceReturnableMethodRaw<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TReturn>(MethodBase method, out nint pAddress)
        {
            pAddress = 0;
            if (method.IsStatic)
            {
                return false;
            }
            if (method.IsOverridable())
            {
                return false;
            }
            var isValidGeneric = !method.IsGenericMethodDefinition || ValidateGenericReturnableMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TReturn>(ref method);
            if (!isValidGeneric)
            {
                return false;
            }
            var parameters = method.GetParametersFast();
            var parameterLength = parameters.Count;
            if (parameterLength != 15)
            {
                return false;
            }
            if (method is MethodInfo mi)
            {
                var returnType = mi?.ReturnType ?? typeof(void);
                if (!returnType.IsValidOutput<TReturn>())
                {
                    return false;
                }
            }
            var reflectedType = method.ReflectedType;
            if (!reflectedType.IsValidInputWithoutRef<TTarget>(1, ref pAddress))
            {
                return false;
            }
            var paramType0 = parameters[0].ParameterType;
            if (!paramType0.IsValidInput<TArg0>(2, ref pAddress))
            {
                return false;
            }
            var paramType1 = parameters[1].ParameterType;
            if (!paramType1.IsValidInput<TArg1>(4, ref pAddress))
            {
                return false;
            }
            var paramType2 = parameters[2].ParameterType;
            if (!paramType2.IsValidInput<TArg2>(8, ref pAddress))
            {
                return false;
            }
            var paramType3 = parameters[3].ParameterType;
            if (!paramType3.IsValidInput<TArg3>(16, ref pAddress))
            {
                return false;
            }
            var paramType4 = parameters[4].ParameterType;
            if (!paramType4.IsValidInput<TArg4>(32, ref pAddress))
            {
                return false;
            }
            var paramType5 = parameters[5].ParameterType;
            if (!paramType5.IsValidInput<TArg5>(64, ref pAddress))
            {
                return false;
            }
            var paramType6 = parameters[6].ParameterType;
            if (!paramType6.IsValidInput<TArg6>(128, ref pAddress))
            {
                return false;
            }
            var paramType7 = parameters[7].ParameterType;
            if (!paramType7.IsValidInput<TArg7>(256, ref pAddress))
            {
                return false;
            }
            var paramType8 = parameters[8].ParameterType;
            if (!paramType8.IsValidInput<TArg8>(512, ref pAddress))
            {
                return false;
            }
            var paramType9 = parameters[9].ParameterType;
            if (!paramType9.IsValidInput<TArg9>(1024, ref pAddress))
            {
                return false;
            }
            var paramType10 = parameters[10].ParameterType;
            if (!paramType10.IsValidInput<TArg10>(2048, ref pAddress))
            {
                return false;
            }
            var paramType11 = parameters[11].ParameterType;
            if (!paramType11.IsValidInput<TArg11>(4096, ref pAddress))
            {
                return false;
            }
            var paramType12 = parameters[12].ParameterType;
            if (!paramType12.IsValidInput<TArg12>(8192, ref pAddress))
            {
                return false;
            }
            var paramType13 = parameters[13].ParameterType;
            if (!paramType13.IsValidInput<TArg13>(16384, ref pAddress))
            {
                return false;
            }
            var paramType14 = parameters[14].ParameterType;
            if (!paramType14.IsValidInput<TArg14>(32768, ref pAddress))
            {
                return false;
            }
            if (pAddress != 0)
            {
                return false;
            }
            pAddress = method.GetFunctionPointer();
            return true;
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool ValidateInstanceReturnableVirtualMethodRaw<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TReturn>(MethodBase method, Type targetType, out nint pAddress)
        {
            pAddress = 0;
            if (method.IsStatic)
            {
                return false;
            }
            if (!method.IsOverridable())
            {
                return false;
            }
            var isValidGeneric = !method.IsGenericMethodDefinition || ValidateGenericReturnableMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TReturn>(ref method);
            if (!isValidGeneric)
            {
                return false;
            }
            var parameters = method.GetParametersFast();
            var parameterLength = parameters.Count;
            if (parameterLength != 15)
            {
                return false;
            }
            if (method is MethodInfo mi)
            {
                var returnType = mi?.ReturnType ?? typeof(void);
                if (!returnType.IsValidOutput<TReturn>())
                {
                    return false;
                }
            }
            var reflectedType = method.ReflectedType;
            if (!reflectedType.IsValidVirtualInput<TTarget>(targetType, out var isVirtualCall))
            {
                return false;
            }
            if (isVirtualCall)
            {
                ArrayCache.Types15[0] = parameters[0].ParameterType;
                ArrayCache.Types15[1] = parameters[1].ParameterType;
                ArrayCache.Types15[2] = parameters[2].ParameterType;
                ArrayCache.Types15[3] = parameters[3].ParameterType;
                ArrayCache.Types15[4] = parameters[4].ParameterType;
                ArrayCache.Types15[5] = parameters[5].ParameterType;
                ArrayCache.Types15[6] = parameters[6].ParameterType;
                ArrayCache.Types15[7] = parameters[7].ParameterType;
                ArrayCache.Types15[8] = parameters[8].ParameterType;
                ArrayCache.Types15[9] = parameters[9].ParameterType;
                ArrayCache.Types15[10] = parameters[10].ParameterType;
                ArrayCache.Types15[11] = parameters[11].ParameterType;
                ArrayCache.Types15[12] = parameters[12].ParameterType;
                ArrayCache.Types15[13] = parameters[13].ParameterType;
                ArrayCache.Types15[14] = parameters[14].ParameterType;
                method = targetType.GetInstanceMethodFullAccess(method.Name, null, ArrayCache.Types15, null);
            }
            var paramType0 = parameters[0].ParameterType;
            if (!paramType0.IsValidInput<TArg0>(2, ref pAddress))
            {
                return false;
            }
            var paramType1 = parameters[1].ParameterType;
            if (!paramType1.IsValidInput<TArg1>(4, ref pAddress))
            {
                return false;
            }
            var paramType2 = parameters[2].ParameterType;
            if (!paramType2.IsValidInput<TArg2>(8, ref pAddress))
            {
                return false;
            }
            var paramType3 = parameters[3].ParameterType;
            if (!paramType3.IsValidInput<TArg3>(16, ref pAddress))
            {
                return false;
            }
            var paramType4 = parameters[4].ParameterType;
            if (!paramType4.IsValidInput<TArg4>(32, ref pAddress))
            {
                return false;
            }
            var paramType5 = parameters[5].ParameterType;
            if (!paramType5.IsValidInput<TArg5>(64, ref pAddress))
            {
                return false;
            }
            var paramType6 = parameters[6].ParameterType;
            if (!paramType6.IsValidInput<TArg6>(128, ref pAddress))
            {
                return false;
            }
            var paramType7 = parameters[7].ParameterType;
            if (!paramType7.IsValidInput<TArg7>(256, ref pAddress))
            {
                return false;
            }
            var paramType8 = parameters[8].ParameterType;
            if (!paramType8.IsValidInput<TArg8>(512, ref pAddress))
            {
                return false;
            }
            var paramType9 = parameters[9].ParameterType;
            if (!paramType9.IsValidInput<TArg9>(1024, ref pAddress))
            {
                return false;
            }
            var paramType10 = parameters[10].ParameterType;
            if (!paramType10.IsValidInput<TArg10>(2048, ref pAddress))
            {
                return false;
            }
            var paramType11 = parameters[11].ParameterType;
            if (!paramType11.IsValidInput<TArg11>(4096, ref pAddress))
            {
                return false;
            }
            var paramType12 = parameters[12].ParameterType;
            if (!paramType12.IsValidInput<TArg12>(8192, ref pAddress))
            {
                return false;
            }
            var paramType13 = parameters[13].ParameterType;
            if (!paramType13.IsValidInput<TArg13>(16384, ref pAddress))
            {
                return false;
            }
            var paramType14 = parameters[14].ParameterType;
            if (!paramType14.IsValidInput<TArg14>(32768, ref pAddress))
            {
                return false;
            }
            if (pAddress != 0)
            {
                return false;
            }
            pAddress = method.GetFunctionPointer();
            return true;
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool SecondaryValidateInstanceMethodRaw(MethodBase method, Type target, Type arg0, Type arg1, Type arg2, Type arg3, Type arg4, Type arg5, Type arg6, Type arg7, Type arg8, Type arg9, Type arg10, Type arg11, Type arg12, Type arg13, Type arg14, ref nint pAddress)
        {
            if ((pAddress & 1) != 0)
            {
                var reflectedType = method.ReflectedType;
                if (!reflectedType.IsNullAssignableFromFast(target))
                {
                    return false;
                }
            }
            var parameters = method.GetParametersFast();
            if ((pAddress & 2) != 0)
            {
                var paramType = parameters[0].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg0))
                {
                    return false;
                }
            }
            if ((pAddress & 4) != 0)
            {
                var paramType = parameters[1].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg1))
                {
                    return false;
                }
            }
            if ((pAddress & 8) != 0)
            {
                var paramType = parameters[2].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg2))
                {
                    return false;
                }
            }
            if ((pAddress & 16) != 0)
            {
                var paramType = parameters[3].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg3))
                {
                    return false;
                }
            }
            if ((pAddress & 32) != 0)
            {
                var paramType = parameters[4].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg4))
                {
                    return false;
                }
            }
            if ((pAddress & 64) != 0)
            {
                var paramType = parameters[5].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg5))
                {
                    return false;
                }
            }
            if ((pAddress & 128) != 0)
            {
                var paramType = parameters[6].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg6))
                {
                    return false;
                }
            }
            if ((pAddress & 256) != 0)
            {
                var paramType = parameters[7].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg7))
                {
                    return false;
                }
            }
            if ((pAddress & 512) != 0)
            {
                var paramType = parameters[8].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg8))
                {
                    return false;
                }
            }
            if ((pAddress & 1024) != 0)
            {
                var paramType = parameters[9].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg9))
                {
                    return false;
                }
            }
            if ((pAddress & 2048) != 0)
            {
                var paramType = parameters[10].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg10))
                {
                    return false;
                }
            }
            if ((pAddress & 4096) != 0)
            {
                var paramType = parameters[11].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg11))
                {
                    return false;
                }
            }
            if ((pAddress & 8192) != 0)
            {
                var paramType = parameters[12].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg12))
                {
                    return false;
                }
            }
            if ((pAddress & 16384) != 0)
            {
                var paramType = parameters[13].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg13))
                {
                    return false;
                }
            }
            if ((pAddress & 32768) != 0)
            {
                var paramType = parameters[14].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg14))
                {
                    return false;
                }
            }
            pAddress = method.GetFunctionPointer();
            return true;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void InvokeStaticFast<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(this MethodBase self, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9, in TArg10 arg10, in TArg11 arg11, in TArg12 arg12, in TArg13 arg13, in TArg14 arg14)
        {
            bool isValid;
            nint pAddress;
            isValid = ValidateStaticMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(self, out pAddress) ||
                      (pAddress != 0 && SecondaryValidateStaticMethod(self, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), arg11?.GetType(), arg12?.GetType(), arg13?.GetType(), arg14?.GetType(), ref pAddress));
            if (!isValid)
            {
                self.InvokeStaticLowAlloc(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
                return;
            }
            unsafe
            {
                ((delegate*<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, void>)pAddress)(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
                return;
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static object InvokeStaticLowAlloc<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(this MethodBase self, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9, in TArg10 arg10, in TArg11 arg11, in TArg12 arg12, in TArg13 arg13, in TArg14 arg14)
        {
            if (self.IsGenericMethodDefinition)
            {
                ValidateGenericMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(ref self);
            }
            var parameters = self.GetParametersFast();
            ArrayCache.Objects15[0] = REReflection.GetBox(arg0, parameters[0], out var refArg0);
            ArrayCache.Objects15[1] = REReflection.GetBox(arg1, parameters[1], out var refArg1);
            ArrayCache.Objects15[2] = REReflection.GetBox(arg2, parameters[2], out var refArg2);
            ArrayCache.Objects15[3] = REReflection.GetBox(arg3, parameters[3], out var refArg3);
            ArrayCache.Objects15[4] = REReflection.GetBox(arg4, parameters[4], out var refArg4);
            ArrayCache.Objects15[5] = REReflection.GetBox(arg5, parameters[5], out var refArg5);
            ArrayCache.Objects15[6] = REReflection.GetBox(arg6, parameters[6], out var refArg6);
            ArrayCache.Objects15[7] = REReflection.GetBox(arg7, parameters[7], out var refArg7);
            ArrayCache.Objects15[8] = REReflection.GetBox(arg8, parameters[8], out var refArg8);
            ArrayCache.Objects15[9] = REReflection.GetBox(arg9, parameters[9], out var refArg9);
            ArrayCache.Objects15[10] = REReflection.GetBox(arg10, parameters[10], out var refArg10);
            ArrayCache.Objects15[11] = REReflection.GetBox(arg11, parameters[11], out var refArg11);
            ArrayCache.Objects15[12] = REReflection.GetBox(arg12, parameters[12], out var refArg12);
            ArrayCache.Objects15[13] = REReflection.GetBox(arg13, parameters[13], out var refArg13);
            ArrayCache.Objects15[14] = REReflection.GetBox(arg14, parameters[14], out var refArg14);
            try
            {
                return self.Invoke(null, ArrayCache.Objects15);
            }
            finally
            {
                REReflection.ReturnBox<TArg0>(ArrayCache.Objects15[0], parameters[0], refArg0);
                REReflection.ReturnBox<TArg1>(ArrayCache.Objects15[1], parameters[1], refArg1);
                REReflection.ReturnBox<TArg2>(ArrayCache.Objects15[2], parameters[2], refArg2);
                REReflection.ReturnBox<TArg3>(ArrayCache.Objects15[3], parameters[3], refArg3);
                REReflection.ReturnBox<TArg4>(ArrayCache.Objects15[4], parameters[4], refArg4);
                REReflection.ReturnBox<TArg5>(ArrayCache.Objects15[5], parameters[5], refArg5);
                REReflection.ReturnBox<TArg6>(ArrayCache.Objects15[6], parameters[6], refArg6);
                REReflection.ReturnBox<TArg7>(ArrayCache.Objects15[7], parameters[7], refArg7);
                REReflection.ReturnBox<TArg8>(ArrayCache.Objects15[8], parameters[8], refArg8);
                REReflection.ReturnBox<TArg9>(ArrayCache.Objects15[9], parameters[9], refArg9);
                REReflection.ReturnBox<TArg10>(ArrayCache.Objects15[10], parameters[10], refArg10);
                REReflection.ReturnBox<TArg11>(ArrayCache.Objects15[11], parameters[11], refArg11);
                REReflection.ReturnBox<TArg12>(ArrayCache.Objects15[12], parameters[12], refArg12);
                REReflection.ReturnBox<TArg13>(ArrayCache.Objects15[13], parameters[13], refArg13);
                REReflection.ReturnBox<TArg14>(ArrayCache.Objects15[14], parameters[14], refArg14);
            }
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool ValidateStaticMethodRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(MethodBase method, out nint pAddress)
        {
            pAddress = 0;
            if (!method.IsStatic)
            {
                return false;
            }
            if (method.IsOverridable())
            {
                return false;
            }
            var isValidGeneric = !method.IsGenericMethodDefinition || ValidateGenericMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(ref method);
            if (!isValidGeneric)
            {
                return false;
            }
            var parameters = method.GetParametersFast();
            var parameterLength = parameters.Count;
            if (parameterLength != 15)
            {
                return false;
            }
            if (method is MethodInfo mi)
            {
                var returnType = mi?.ReturnType ?? typeof(void);
                if (returnType != typeof(void))
                {
                    return false;
                }
            }
            var paramType0 = parameters[0].ParameterType;
            if (!paramType0.IsValidInput<TArg0>(2, ref pAddress))
            {
                return false;
            }
            var paramType1 = parameters[1].ParameterType;
            if (!paramType1.IsValidInput<TArg1>(4, ref pAddress))
            {
                return false;
            }
            var paramType2 = parameters[2].ParameterType;
            if (!paramType2.IsValidInput<TArg2>(8, ref pAddress))
            {
                return false;
            }
            var paramType3 = parameters[3].ParameterType;
            if (!paramType3.IsValidInput<TArg3>(16, ref pAddress))
            {
                return false;
            }
            var paramType4 = parameters[4].ParameterType;
            if (!paramType4.IsValidInput<TArg4>(32, ref pAddress))
            {
                return false;
            }
            var paramType5 = parameters[5].ParameterType;
            if (!paramType5.IsValidInput<TArg5>(64, ref pAddress))
            {
                return false;
            }
            var paramType6 = parameters[6].ParameterType;
            if (!paramType6.IsValidInput<TArg6>(128, ref pAddress))
            {
                return false;
            }
            var paramType7 = parameters[7].ParameterType;
            if (!paramType7.IsValidInput<TArg7>(256, ref pAddress))
            {
                return false;
            }
            var paramType8 = parameters[8].ParameterType;
            if (!paramType8.IsValidInput<TArg8>(512, ref pAddress))
            {
                return false;
            }
            var paramType9 = parameters[9].ParameterType;
            if (!paramType9.IsValidInput<TArg9>(1024, ref pAddress))
            {
                return false;
            }
            var paramType10 = parameters[10].ParameterType;
            if (!paramType10.IsValidInput<TArg10>(2048, ref pAddress))
            {
                return false;
            }
            var paramType11 = parameters[11].ParameterType;
            if (!paramType11.IsValidInput<TArg11>(4096, ref pAddress))
            {
                return false;
            }
            var paramType12 = parameters[12].ParameterType;
            if (!paramType12.IsValidInput<TArg12>(8192, ref pAddress))
            {
                return false;
            }
            var paramType13 = parameters[13].ParameterType;
            if (!paramType13.IsValidInput<TArg13>(16384, ref pAddress))
            {
                return false;
            }
            var paramType14 = parameters[14].ParameterType;
            if (!paramType14.IsValidInput<TArg14>(32768, ref pAddress))
            {
                return false;
            }
            if (pAddress != 0)
            {
                return false;
            }
            pAddress = method.GetFunctionPointer();
            return true;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TReturn InvokeStaticFast<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TReturn>(this MethodBase self, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9, in TArg10 arg10, in TArg11 arg11, in TArg12 arg12, in TArg13 arg13, in TArg14 arg14)
        {
            bool isValid;
            nint pAddress;
            isValid = ValidateStaticReturnableMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TReturn>(self, out pAddress) ||
                      (pAddress != 0 && SecondaryValidateStaticMethod(self, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), arg11?.GetType(), arg12?.GetType(), arg13?.GetType(), arg14?.GetType(), ref pAddress));
            if (!isValid)
            {
                return (TReturn)self.InvokeStaticLowAlloc(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
            }
            unsafe
            {
                return ((delegate*<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TReturn>)pAddress)(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
            }
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool ValidateStaticReturnableMethodRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TReturn>(MethodBase method, out nint pAddress)
        {
            pAddress = 0;
            if (!method.IsStatic)
            {
                return false;
            }
            if (method.IsOverridable())
            {
                return false;
            }
            var isValidGeneric = !method.IsGenericMethodDefinition || ValidateGenericReturnableMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TReturn>(ref method);
            if (!isValidGeneric)
            {
                return false;
            }
            var parameters = method.GetParametersFast();
            var parameterLength = parameters.Count;
            if (parameterLength != 15)
            {
                return false;
            }
            if (method is MethodInfo mi)
            {
                var returnType = mi?.ReturnType ?? typeof(void);
                if (!returnType.IsValidOutput<TReturn>())
                {
                    return false;
                }
            }
            var paramType0 = parameters[0].ParameterType;
            if (!paramType0.IsValidInput<TArg0>(2, ref pAddress))
            {
                return false;
            }
            var paramType1 = parameters[1].ParameterType;
            if (!paramType1.IsValidInput<TArg1>(4, ref pAddress))
            {
                return false;
            }
            var paramType2 = parameters[2].ParameterType;
            if (!paramType2.IsValidInput<TArg2>(8, ref pAddress))
            {
                return false;
            }
            var paramType3 = parameters[3].ParameterType;
            if (!paramType3.IsValidInput<TArg3>(16, ref pAddress))
            {
                return false;
            }
            var paramType4 = parameters[4].ParameterType;
            if (!paramType4.IsValidInput<TArg4>(32, ref pAddress))
            {
                return false;
            }
            var paramType5 = parameters[5].ParameterType;
            if (!paramType5.IsValidInput<TArg5>(64, ref pAddress))
            {
                return false;
            }
            var paramType6 = parameters[6].ParameterType;
            if (!paramType6.IsValidInput<TArg6>(128, ref pAddress))
            {
                return false;
            }
            var paramType7 = parameters[7].ParameterType;
            if (!paramType7.IsValidInput<TArg7>(256, ref pAddress))
            {
                return false;
            }
            var paramType8 = parameters[8].ParameterType;
            if (!paramType8.IsValidInput<TArg8>(512, ref pAddress))
            {
                return false;
            }
            var paramType9 = parameters[9].ParameterType;
            if (!paramType9.IsValidInput<TArg9>(1024, ref pAddress))
            {
                return false;
            }
            var paramType10 = parameters[10].ParameterType;
            if (!paramType10.IsValidInput<TArg10>(2048, ref pAddress))
            {
                return false;
            }
            var paramType11 = parameters[11].ParameterType;
            if (!paramType11.IsValidInput<TArg11>(4096, ref pAddress))
            {
                return false;
            }
            var paramType12 = parameters[12].ParameterType;
            if (!paramType12.IsValidInput<TArg12>(8192, ref pAddress))
            {
                return false;
            }
            var paramType13 = parameters[13].ParameterType;
            if (!paramType13.IsValidInput<TArg13>(16384, ref pAddress))
            {
                return false;
            }
            var paramType14 = parameters[14].ParameterType;
            if (!paramType14.IsValidInput<TArg14>(32768, ref pAddress))
            {
                return false;
            }
            if (pAddress != 0)
            {
                return false;
            }
            pAddress = method.GetFunctionPointer();
            return true;
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool SecondaryValidateStaticMethodRaw(MethodBase method, Type arg0, Type arg1, Type arg2, Type arg3, Type arg4, Type arg5, Type arg6, Type arg7, Type arg8, Type arg9, Type arg10, Type arg11, Type arg12, Type arg13, Type arg14, ref nint pAddress)
        {
            var parameters = method.GetParametersFast();
            if ((pAddress & 2) != 0)
            {
                var paramType = parameters[0].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg0))
                {
                    return false;
                }
            }
            if ((pAddress & 4) != 0)
            {
                var paramType = parameters[1].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg1))
                {
                    return false;
                }
            }
            if ((pAddress & 8) != 0)
            {
                var paramType = parameters[2].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg2))
                {
                    return false;
                }
            }
            if ((pAddress & 16) != 0)
            {
                var paramType = parameters[3].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg3))
                {
                    return false;
                }
            }
            if ((pAddress & 32) != 0)
            {
                var paramType = parameters[4].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg4))
                {
                    return false;
                }
            }
            if ((pAddress & 64) != 0)
            {
                var paramType = parameters[5].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg5))
                {
                    return false;
                }
            }
            if ((pAddress & 128) != 0)
            {
                var paramType = parameters[6].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg6))
                {
                    return false;
                }
            }
            if ((pAddress & 256) != 0)
            {
                var paramType = parameters[7].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg7))
                {
                    return false;
                }
            }
            if ((pAddress & 512) != 0)
            {
                var paramType = parameters[8].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg8))
                {
                    return false;
                }
            }
            if ((pAddress & 1024) != 0)
            {
                var paramType = parameters[9].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg9))
                {
                    return false;
                }
            }
            if ((pAddress & 2048) != 0)
            {
                var paramType = parameters[10].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg10))
                {
                    return false;
                }
            }
            if ((pAddress & 4096) != 0)
            {
                var paramType = parameters[11].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg11))
                {
                    return false;
                }
            }
            if ((pAddress & 8192) != 0)
            {
                var paramType = parameters[12].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg12))
                {
                    return false;
                }
            }
            if ((pAddress & 16384) != 0)
            {
                var paramType = parameters[13].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg13))
                {
                    return false;
                }
            }
            if ((pAddress & 32768) != 0)
            {
                var paramType = parameters[14].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg14))
                {
                    return false;
                }
            }
            pAddress = method.GetFunctionPointer();
            return true;
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool ValidateGenericMethodRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(ref MethodBase method)
        {
            if (!method.IsGenericMethodDefinition)
            {
                return true;
            }
            var genericArguments = method.GetGenericArgumentsFast();
            if (genericArguments.Count < 15)
            {
                return false;
            }
            uint mask = 0;
            var mi = method as MethodInfo;
            var parameters = method.GetParametersFast();
            var index0 = IndexOf(genericArguments, parameters[0].ParameterType);
            if (index0 >= 0)
            {
                mask |= 1u << index0;
            }
            var index1 = IndexOf(genericArguments, parameters[1].ParameterType);
            if (index1 >= 0)
            {
                mask |= 1u << index1;
            }
            var index2 = IndexOf(genericArguments, parameters[2].ParameterType);
            if (index2 >= 0)
            {
                mask |= 1u << index2;
            }
            var index3 = IndexOf(genericArguments, parameters[3].ParameterType);
            if (index3 >= 0)
            {
                mask |= 1u << index3;
            }
            var index4 = IndexOf(genericArguments, parameters[4].ParameterType);
            if (index4 >= 0)
            {
                mask |= 1u << index4;
            }
            var index5 = IndexOf(genericArguments, parameters[5].ParameterType);
            if (index5 >= 0)
            {
                mask |= 1u << index5;
            }
            var index6 = IndexOf(genericArguments, parameters[6].ParameterType);
            if (index6 >= 0)
            {
                mask |= 1u << index6;
            }
            var index7 = IndexOf(genericArguments, parameters[7].ParameterType);
            if (index7 >= 0)
            {
                mask |= 1u << index7;
            }
            var index8 = IndexOf(genericArguments, parameters[8].ParameterType);
            if (index8 >= 0)
            {
                mask |= 1u << index8;
            }
            var index9 = IndexOf(genericArguments, parameters[9].ParameterType);
            if (index9 >= 0)
            {
                mask |= 1u << index9;
            }
            var index10 = IndexOf(genericArguments, parameters[10].ParameterType);
            if (index10 >= 0)
            {
                mask |= 1u << index10;
            }
            var index11 = IndexOf(genericArguments, parameters[11].ParameterType);
            if (index11 >= 0)
            {
                mask |= 1u << index11;
            }
            var index12 = IndexOf(genericArguments, parameters[12].ParameterType);
            if (index12 >= 0)
            {
                mask |= 1u << index12;
            }
            var index13 = IndexOf(genericArguments, parameters[13].ParameterType);
            if (index13 >= 0)
            {
                mask |= 1u << index13;
            }
            var index14 = IndexOf(genericArguments, parameters[14].ParameterType);
            if (index14 >= 0)
            {
                mask |= 1u << index14;
            }
            if (REReflection.BitCount(mask) != genericArguments.Count)
            {
                return false;
            }
            var types = ArrayCache.GetArrayCache<Type>(genericArguments.Count);
            if (index0 >= 0)
            {
                types[index0] = typeof(TArg0);
            }
            if (index1 >= 0)
            {
                types[index1] = typeof(TArg1);
            }
            if (index2 >= 0)
            {
                types[index2] = typeof(TArg2);
            }
            if (index3 >= 0)
            {
                types[index3] = typeof(TArg3);
            }
            if (index4 >= 0)
            {
                types[index4] = typeof(TArg4);
            }
            if (index5 >= 0)
            {
                types[index5] = typeof(TArg5);
            }
            if (index6 >= 0)
            {
                types[index6] = typeof(TArg6);
            }
            if (index7 >= 0)
            {
                types[index7] = typeof(TArg7);
            }
            if (index8 >= 0)
            {
                types[index8] = typeof(TArg8);
            }
            if (index9 >= 0)
            {
                types[index9] = typeof(TArg9);
            }
            if (index10 >= 0)
            {
                types[index10] = typeof(TArg10);
            }
            if (index11 >= 0)
            {
                types[index11] = typeof(TArg11);
            }
            if (index12 >= 0)
            {
                types[index12] = typeof(TArg12);
            }
            if (index13 >= 0)
            {
                types[index13] = typeof(TArg13);
            }
            if (index14 >= 0)
            {
                types[index14] = typeof(TArg14);
            }
            #if ENABLE_IL2CPP
            bool isFound = false;
            var usingMethods = method.GetUsingGenericInstanceMethods();
            foreach (var usingMethod in usingMethods)
            {
                if (usingMethod.GetGenericArgumentsFast().SequenceEqual(types))
                {
                    isFound = true;
                    break;
                }
            }
            if (!isFound)
            {
                return false;
            }
            #endif
            method = mi.MakeGenericMethodFast(types);
            return true;
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool ValidateGenericReturnableMethodRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TReturn>(ref MethodBase method)
        {
            if (!method.IsGenericMethodDefinition)
            {
                return true;
            }
            var genericArguments = method.GetGenericArgumentsFast();
            if (genericArguments.Count < 16)
            {
                return false;
            }
            uint mask = 0;
            var mi = method as MethodInfo;
            var returnType = mi.ReturnType ?? typeof(void);
            var index = IndexOf(genericArguments, returnType);
            if (index >= 0)
            {
                mask |= 1u << index;
            }
            var parameters = method.GetParametersFast();
            var index0 = IndexOf(genericArguments, parameters[0].ParameterType);
            if (index0 >= 0)
            {
                mask |= 1u << index0;
            }
            var index1 = IndexOf(genericArguments, parameters[1].ParameterType);
            if (index1 >= 0)
            {
                mask |= 1u << index1;
            }
            var index2 = IndexOf(genericArguments, parameters[2].ParameterType);
            if (index2 >= 0)
            {
                mask |= 1u << index2;
            }
            var index3 = IndexOf(genericArguments, parameters[3].ParameterType);
            if (index3 >= 0)
            {
                mask |= 1u << index3;
            }
            var index4 = IndexOf(genericArguments, parameters[4].ParameterType);
            if (index4 >= 0)
            {
                mask |= 1u << index4;
            }
            var index5 = IndexOf(genericArguments, parameters[5].ParameterType);
            if (index5 >= 0)
            {
                mask |= 1u << index5;
            }
            var index6 = IndexOf(genericArguments, parameters[6].ParameterType);
            if (index6 >= 0)
            {
                mask |= 1u << index6;
            }
            var index7 = IndexOf(genericArguments, parameters[7].ParameterType);
            if (index7 >= 0)
            {
                mask |= 1u << index7;
            }
            var index8 = IndexOf(genericArguments, parameters[8].ParameterType);
            if (index8 >= 0)
            {
                mask |= 1u << index8;
            }
            var index9 = IndexOf(genericArguments, parameters[9].ParameterType);
            if (index9 >= 0)
            {
                mask |= 1u << index9;
            }
            var index10 = IndexOf(genericArguments, parameters[10].ParameterType);
            if (index10 >= 0)
            {
                mask |= 1u << index10;
            }
            var index11 = IndexOf(genericArguments, parameters[11].ParameterType);
            if (index11 >= 0)
            {
                mask |= 1u << index11;
            }
            var index12 = IndexOf(genericArguments, parameters[12].ParameterType);
            if (index12 >= 0)
            {
                mask |= 1u << index12;
            }
            var index13 = IndexOf(genericArguments, parameters[13].ParameterType);
            if (index13 >= 0)
            {
                mask |= 1u << index13;
            }
            var index14 = IndexOf(genericArguments, parameters[14].ParameterType);
            if (index14 >= 0)
            {
                mask |= 1u << index14;
            }
            if (REReflection.BitCount(mask) != genericArguments.Count)
            {
                return false;
            }
            var types = ArrayCache.GetArrayCache<Type>(genericArguments.Count);
            if (index >= 0)
            {
                types[index] = typeof(TReturn);
            }
            if (index0 >= 0)
            {
                types[index0] = typeof(TArg0);
            }
            if (index1 >= 0)
            {
                types[index1] = typeof(TArg1);
            }
            if (index2 >= 0)
            {
                types[index2] = typeof(TArg2);
            }
            if (index3 >= 0)
            {
                types[index3] = typeof(TArg3);
            }
            if (index4 >= 0)
            {
                types[index4] = typeof(TArg4);
            }
            if (index5 >= 0)
            {
                types[index5] = typeof(TArg5);
            }
            if (index6 >= 0)
            {
                types[index6] = typeof(TArg6);
            }
            if (index7 >= 0)
            {
                types[index7] = typeof(TArg7);
            }
            if (index8 >= 0)
            {
                types[index8] = typeof(TArg8);
            }
            if (index9 >= 0)
            {
                types[index9] = typeof(TArg9);
            }
            if (index10 >= 0)
            {
                types[index10] = typeof(TArg10);
            }
            if (index11 >= 0)
            {
                types[index11] = typeof(TArg11);
            }
            if (index12 >= 0)
            {
                types[index12] = typeof(TArg12);
            }
            if (index13 >= 0)
            {
                types[index13] = typeof(TArg13);
            }
            if (index14 >= 0)
            {
                types[index14] = typeof(TArg14);
            }
            #if ENABLE_IL2CPP
            bool isFound = false;
            var usingMethods = method.GetUsingGenericInstanceMethods();
            foreach (var usingMethod in usingMethods)
            {
                if (usingMethod.GetGenericArgumentsFast().SequenceEqual(types))
                {
                    isFound = true;
                    break;
                }
            }
            if (!isFound)
            {
                return false;
            }
            #endif
            method = mi.MakeGenericMethodFast(types);
            return true;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void InvokeInstanceFast<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(this MethodBase self, ref TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9, in TArg10 arg10, in TArg11 arg11, in TArg12 arg12, in TArg13 arg13, in TArg14 arg14, in TArg15 arg15)
        {
            bool isValid;
            nint pAddress;
            if (self.IsOverridable())
            {
                isValid = ValidateInstanceVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(self, target?.GetType(), out pAddress) ||
                          (pAddress != 0 && SecondaryValidateStaticMethod(self, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), arg11?.GetType(), arg12?.GetType(), arg13?.GetType(), arg14?.GetType(), arg15?.GetType(), ref pAddress));
            }
            else
            {
                isValid = ValidateInstanceMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(self, out pAddress) ||
                          (pAddress != 0 && SecondaryValidateInstanceMethod(self, target?.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), arg11?.GetType(), arg12?.GetType(), arg13?.GetType(), arg14?.GetType(), arg15?.GetType(), ref pAddress));
            }
            if (!isValid)
            {
                self.InvokeInstanceLowAlloc(ref target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15);
                return;
            }
            unsafe
            {
                if (REType.IsValueTypeFast<TTarget>())
                {
                    ((delegate*<ref TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, void>)pAddress)(ref target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15);
                    return;
                }
                ((delegate*<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, void>)pAddress)(target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15);
                return;
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void InvokeClassInstanceFast<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(this MethodBase self, TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9, in TArg10 arg10, in TArg11 arg11, in TArg12 arg12, in TArg13 arg13, in TArg14 arg14, in TArg15 arg15)
        where TTarget: class
        {
            bool isValid;
            nint pAddress;
            if (self.IsOverridable())
            {
                isValid = ValidateInstanceVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(self, target?.GetType(), out pAddress) ||
                          (pAddress != 0 && SecondaryValidateStaticMethod(self, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), arg11?.GetType(), arg12?.GetType(), arg13?.GetType(), arg14?.GetType(), arg15?.GetType(), ref pAddress));
            }
            else
            {
                isValid = ValidateInstanceMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(self, out pAddress) ||
                          (pAddress != 0 && SecondaryValidateInstanceMethod(self, target?.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), arg11?.GetType(), arg12?.GetType(), arg13?.GetType(), arg14?.GetType(), arg15?.GetType(), ref pAddress));
            }
            if (!isValid)
            {
                self.InvokeClassInstanceLowAlloc(target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15);
                return;
            }
            unsafe
            {
                ((delegate*<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, void>)pAddress)(target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15);
                return;
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void InvokeStructInstanceFast<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(this MethodBase self, ref TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9, in TArg10 arg10, in TArg11 arg11, in TArg12 arg12, in TArg13 arg13, in TArg14 arg14, in TArg15 arg15)
        where TTarget: struct
        {
            bool isValid;
            nint pAddress;
            if (self.IsOverridable())
            {
                isValid = ValidateInstanceVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(self, target.GetType(), out pAddress) ||
                          (pAddress != 0 && SecondaryValidateStaticMethod(self, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), arg11?.GetType(), arg12?.GetType(), arg13?.GetType(), arg14?.GetType(), arg15?.GetType(), ref pAddress));
            }
            else
            {
                isValid = ValidateInstanceMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(self, out pAddress) ||
                          (pAddress != 0 && SecondaryValidateInstanceMethod(self, target.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), arg11?.GetType(), arg12?.GetType(), arg13?.GetType(), arg14?.GetType(), arg15?.GetType(), ref pAddress));
            }
            if (!isValid)
            {
                self.InvokeInstanceLowAlloc(ref target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15);
                return;
            }
            unsafe
            {
                ((delegate*<ref TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, void>)pAddress)(ref target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15);
                return;
            }
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool ValidateInstanceMethodRaw<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(MethodBase method, out nint pAddress)
        {
            pAddress = 0;
            if (method.IsStatic)
            {
                return false;
            }
            if (method.IsOverridable())
            {
                return false;
            }
            var isValidGeneric = !method.IsGenericMethodDefinition || ValidateGenericMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(ref method);
            if (!isValidGeneric)
            {
                return false;
            }
            var parameters = method.GetParametersFast();
            var parameterLength = parameters.Count;
            if (parameterLength != 16)
            {
                return false;
            }
            if (method is MethodInfo mi)
            {
                var returnType = mi?.ReturnType ?? typeof(void);
                if (returnType != typeof(void))
                {
                    return false;
                }
            }
            var reflectedType = method.ReflectedType;
            if (!reflectedType.IsValidInputWithoutRef<TTarget>(1, ref pAddress))
            {
                return false;
            }
            var paramType0 = parameters[0].ParameterType;
            if (!paramType0.IsValidInput<TArg0>(2, ref pAddress))
            {
                return false;
            }
            var paramType1 = parameters[1].ParameterType;
            if (!paramType1.IsValidInput<TArg1>(4, ref pAddress))
            {
                return false;
            }
            var paramType2 = parameters[2].ParameterType;
            if (!paramType2.IsValidInput<TArg2>(8, ref pAddress))
            {
                return false;
            }
            var paramType3 = parameters[3].ParameterType;
            if (!paramType3.IsValidInput<TArg3>(16, ref pAddress))
            {
                return false;
            }
            var paramType4 = parameters[4].ParameterType;
            if (!paramType4.IsValidInput<TArg4>(32, ref pAddress))
            {
                return false;
            }
            var paramType5 = parameters[5].ParameterType;
            if (!paramType5.IsValidInput<TArg5>(64, ref pAddress))
            {
                return false;
            }
            var paramType6 = parameters[6].ParameterType;
            if (!paramType6.IsValidInput<TArg6>(128, ref pAddress))
            {
                return false;
            }
            var paramType7 = parameters[7].ParameterType;
            if (!paramType7.IsValidInput<TArg7>(256, ref pAddress))
            {
                return false;
            }
            var paramType8 = parameters[8].ParameterType;
            if (!paramType8.IsValidInput<TArg8>(512, ref pAddress))
            {
                return false;
            }
            var paramType9 = parameters[9].ParameterType;
            if (!paramType9.IsValidInput<TArg9>(1024, ref pAddress))
            {
                return false;
            }
            var paramType10 = parameters[10].ParameterType;
            if (!paramType10.IsValidInput<TArg10>(2048, ref pAddress))
            {
                return false;
            }
            var paramType11 = parameters[11].ParameterType;
            if (!paramType11.IsValidInput<TArg11>(4096, ref pAddress))
            {
                return false;
            }
            var paramType12 = parameters[12].ParameterType;
            if (!paramType12.IsValidInput<TArg12>(8192, ref pAddress))
            {
                return false;
            }
            var paramType13 = parameters[13].ParameterType;
            if (!paramType13.IsValidInput<TArg13>(16384, ref pAddress))
            {
                return false;
            }
            var paramType14 = parameters[14].ParameterType;
            if (!paramType14.IsValidInput<TArg14>(32768, ref pAddress))
            {
                return false;
            }
            var paramType15 = parameters[15].ParameterType;
            if (!paramType15.IsValidInput<TArg15>(65536, ref pAddress))
            {
                return false;
            }
            if (pAddress != 0)
            {
                return false;
            }
            pAddress = method.GetFunctionPointer();
            return true;
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool ValidateInstanceVirtualMethodRaw<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(MethodBase method, Type targetType, out nint pAddress)
        {
            pAddress = 0;
            if (method.IsStatic)
            {
                return false;
            }
            if (!method.IsOverridable())
            {
                return false;
            }
            var isValidGeneric = !method.IsGenericMethodDefinition || ValidateGenericMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(ref method);
            if (!isValidGeneric)
            {
                return false;
            }
            var parameters = method.GetParametersFast();
            var parameterLength = parameters.Count;
            if (parameterLength != 16)
            {
                return false;
            }
            if (method is MethodInfo mi)
            {
                var returnType = mi?.ReturnType ?? typeof(void);
                if (returnType != typeof(void))
                {
                    return false;
                }
            }
            var reflectedType = method.ReflectedType;
            if (!reflectedType.IsValidVirtualInput<TTarget>(targetType, out var isVirtualCall))
            {
                return false;
            }
            if (isVirtualCall)
            {
                ArrayCache.Types16[0] = parameters[0].ParameterType;
                ArrayCache.Types16[1] = parameters[1].ParameterType;
                ArrayCache.Types16[2] = parameters[2].ParameterType;
                ArrayCache.Types16[3] = parameters[3].ParameterType;
                ArrayCache.Types16[4] = parameters[4].ParameterType;
                ArrayCache.Types16[5] = parameters[5].ParameterType;
                ArrayCache.Types16[6] = parameters[6].ParameterType;
                ArrayCache.Types16[7] = parameters[7].ParameterType;
                ArrayCache.Types16[8] = parameters[8].ParameterType;
                ArrayCache.Types16[9] = parameters[9].ParameterType;
                ArrayCache.Types16[10] = parameters[10].ParameterType;
                ArrayCache.Types16[11] = parameters[11].ParameterType;
                ArrayCache.Types16[12] = parameters[12].ParameterType;
                ArrayCache.Types16[13] = parameters[13].ParameterType;
                ArrayCache.Types16[14] = parameters[14].ParameterType;
                ArrayCache.Types16[15] = parameters[15].ParameterType;
                method = targetType.GetInstanceMethodFullAccess(method.Name, null, ArrayCache.Types16, null);
            }
            var paramType0 = parameters[0].ParameterType;
            if (!paramType0.IsValidInput<TArg0>(2, ref pAddress))
            {
                return false;
            }
            var paramType1 = parameters[1].ParameterType;
            if (!paramType1.IsValidInput<TArg1>(4, ref pAddress))
            {
                return false;
            }
            var paramType2 = parameters[2].ParameterType;
            if (!paramType2.IsValidInput<TArg2>(8, ref pAddress))
            {
                return false;
            }
            var paramType3 = parameters[3].ParameterType;
            if (!paramType3.IsValidInput<TArg3>(16, ref pAddress))
            {
                return false;
            }
            var paramType4 = parameters[4].ParameterType;
            if (!paramType4.IsValidInput<TArg4>(32, ref pAddress))
            {
                return false;
            }
            var paramType5 = parameters[5].ParameterType;
            if (!paramType5.IsValidInput<TArg5>(64, ref pAddress))
            {
                return false;
            }
            var paramType6 = parameters[6].ParameterType;
            if (!paramType6.IsValidInput<TArg6>(128, ref pAddress))
            {
                return false;
            }
            var paramType7 = parameters[7].ParameterType;
            if (!paramType7.IsValidInput<TArg7>(256, ref pAddress))
            {
                return false;
            }
            var paramType8 = parameters[8].ParameterType;
            if (!paramType8.IsValidInput<TArg8>(512, ref pAddress))
            {
                return false;
            }
            var paramType9 = parameters[9].ParameterType;
            if (!paramType9.IsValidInput<TArg9>(1024, ref pAddress))
            {
                return false;
            }
            var paramType10 = parameters[10].ParameterType;
            if (!paramType10.IsValidInput<TArg10>(2048, ref pAddress))
            {
                return false;
            }
            var paramType11 = parameters[11].ParameterType;
            if (!paramType11.IsValidInput<TArg11>(4096, ref pAddress))
            {
                return false;
            }
            var paramType12 = parameters[12].ParameterType;
            if (!paramType12.IsValidInput<TArg12>(8192, ref pAddress))
            {
                return false;
            }
            var paramType13 = parameters[13].ParameterType;
            if (!paramType13.IsValidInput<TArg13>(16384, ref pAddress))
            {
                return false;
            }
            var paramType14 = parameters[14].ParameterType;
            if (!paramType14.IsValidInput<TArg14>(32768, ref pAddress))
            {
                return false;
            }
            var paramType15 = parameters[15].ParameterType;
            if (!paramType15.IsValidInput<TArg15>(65536, ref pAddress))
            {
                return false;
            }
            if (pAddress != 0)
            {
                return false;
            }
            pAddress = method.GetFunctionPointer();
            return true;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TReturn InvokeInstanceFast<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, TReturn>(this MethodBase self, ref TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9, in TArg10 arg10, in TArg11 arg11, in TArg12 arg12, in TArg13 arg13, in TArg14 arg14, in TArg15 arg15)
        {
            bool isValid;
            nint pAddress;
            if (self.IsOverridable())
            {
                isValid = ValidateInstanceReturnableVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, TReturn>(self, target?.GetType(), out pAddress) ||
                          (pAddress != 0 && SecondaryValidateStaticMethod(self, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), arg11?.GetType(), arg12?.GetType(), arg13?.GetType(), arg14?.GetType(), arg15?.GetType(), ref pAddress));
            }
            else
            {
                isValid = ValidateInstanceReturnableMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, TReturn>(self, out pAddress) ||
                          (pAddress != 0 && SecondaryValidateInstanceMethod(self, target?.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), arg11?.GetType(), arg12?.GetType(), arg13?.GetType(), arg14?.GetType(), arg15?.GetType(), ref pAddress));
            }
            if (!isValid)
            {
                return (TReturn)self.InvokeInstanceLowAlloc(ref target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15);
            }
            unsafe
            {
                if (REType.IsValueTypeFast<TTarget>())
                {
                    return ((delegate*<ref TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, TReturn>)pAddress)(ref target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15);
                }
                return ((delegate*<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, TReturn>)pAddress)(target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15);
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TReturn InvokeClassInstanceFast<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, TReturn>(this MethodBase self, TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9, in TArg10 arg10, in TArg11 arg11, in TArg12 arg12, in TArg13 arg13, in TArg14 arg14, in TArg15 arg15)
        where TTarget: class
        {
            bool isValid;
            nint pAddress;
            if (self.IsOverridable())
            {
                isValid = ValidateInstanceReturnableVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, TReturn>(self, target?.GetType(), out pAddress) ||
                          (pAddress != 0 && SecondaryValidateStaticMethod(self, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), arg11?.GetType(), arg12?.GetType(), arg13?.GetType(), arg14?.GetType(), arg15?.GetType(), ref pAddress));
            }
            else
            {
                isValid = ValidateInstanceReturnableMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, TReturn>(self, out pAddress) ||
                          (pAddress != 0 && SecondaryValidateInstanceMethod(self, target?.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), arg11?.GetType(), arg12?.GetType(), arg13?.GetType(), arg14?.GetType(), arg15?.GetType(), ref pAddress));
            }
            if (!isValid)
            {
                return (TReturn)self.InvokeClassInstanceLowAlloc(target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15);
            }
            unsafe
            {
                return ((delegate*<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, TReturn>)pAddress)(target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15);
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TReturn InvokeStructInstanceFast<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, TReturn>(this MethodBase self, ref TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9, in TArg10 arg10, in TArg11 arg11, in TArg12 arg12, in TArg13 arg13, in TArg14 arg14, in TArg15 arg15)
        where TTarget: struct
        {
            bool isValid;
            nint pAddress;
            if (self.IsOverridable())
            {
                isValid = ValidateInstanceReturnableVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, TReturn>(self, target.GetType(), out pAddress) ||
                          (pAddress != 0 && SecondaryValidateStaticMethod(self, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), arg11?.GetType(), arg12?.GetType(), arg13?.GetType(), arg14?.GetType(), arg15?.GetType(), ref pAddress));
            }
            else
            {
                isValid = ValidateInstanceReturnableMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, TReturn>(self, out pAddress) ||
                          (pAddress != 0 && SecondaryValidateInstanceMethod(self, target.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), arg11?.GetType(), arg12?.GetType(), arg13?.GetType(), arg14?.GetType(), arg15?.GetType(), ref pAddress));
            }
            if (!isValid)
            {
                return (TReturn)self.InvokeInstanceLowAlloc(ref target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15);
            }
            unsafe
            {
                return ((delegate*<ref TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, TReturn>)pAddress)(ref target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15);
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static object InvokeInstanceLowAlloc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(this MethodBase self, ref TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9, in TArg10 arg10, in TArg11 arg11, in TArg12 arg12, in TArg13 arg13, in TArg14 arg14, in TArg15 arg15)
        {
            if (self.IsGenericMethodDefinition)
            {
                ValidateGenericMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(ref self);
            }
            var targetObj = REReflection.GetBoxWithoutRef(target);
            var parameters = self.GetParametersFast();
            ArrayCache.Objects16[0] = REReflection.GetBox(arg0, parameters[0], out var refArg0);
            ArrayCache.Objects16[1] = REReflection.GetBox(arg1, parameters[1], out var refArg1);
            ArrayCache.Objects16[2] = REReflection.GetBox(arg2, parameters[2], out var refArg2);
            ArrayCache.Objects16[3] = REReflection.GetBox(arg3, parameters[3], out var refArg3);
            ArrayCache.Objects16[4] = REReflection.GetBox(arg4, parameters[4], out var refArg4);
            ArrayCache.Objects16[5] = REReflection.GetBox(arg5, parameters[5], out var refArg5);
            ArrayCache.Objects16[6] = REReflection.GetBox(arg6, parameters[6], out var refArg6);
            ArrayCache.Objects16[7] = REReflection.GetBox(arg7, parameters[7], out var refArg7);
            ArrayCache.Objects16[8] = REReflection.GetBox(arg8, parameters[8], out var refArg8);
            ArrayCache.Objects16[9] = REReflection.GetBox(arg9, parameters[9], out var refArg9);
            ArrayCache.Objects16[10] = REReflection.GetBox(arg10, parameters[10], out var refArg10);
            ArrayCache.Objects16[11] = REReflection.GetBox(arg11, parameters[11], out var refArg11);
            ArrayCache.Objects16[12] = REReflection.GetBox(arg12, parameters[12], out var refArg12);
            ArrayCache.Objects16[13] = REReflection.GetBox(arg13, parameters[13], out var refArg13);
            ArrayCache.Objects16[14] = REReflection.GetBox(arg14, parameters[14], out var refArg14);
            ArrayCache.Objects16[15] = REReflection.GetBox(arg15, parameters[15], out var refArg15);
            try
            {
                return self.Invoke(targetObj, ArrayCache.Objects16);
            }
            finally
            {
                REReflection.Unbox(targetObj, out target);
                REReflection.ReturnBoxWithoutRef<TTarget>(targetObj);
                REReflection.ReturnBox<TArg0>(ArrayCache.Objects16[0], parameters[0], refArg0);
                REReflection.ReturnBox<TArg1>(ArrayCache.Objects16[1], parameters[1], refArg1);
                REReflection.ReturnBox<TArg2>(ArrayCache.Objects16[2], parameters[2], refArg2);
                REReflection.ReturnBox<TArg3>(ArrayCache.Objects16[3], parameters[3], refArg3);
                REReflection.ReturnBox<TArg4>(ArrayCache.Objects16[4], parameters[4], refArg4);
                REReflection.ReturnBox<TArg5>(ArrayCache.Objects16[5], parameters[5], refArg5);
                REReflection.ReturnBox<TArg6>(ArrayCache.Objects16[6], parameters[6], refArg6);
                REReflection.ReturnBox<TArg7>(ArrayCache.Objects16[7], parameters[7], refArg7);
                REReflection.ReturnBox<TArg8>(ArrayCache.Objects16[8], parameters[8], refArg8);
                REReflection.ReturnBox<TArg9>(ArrayCache.Objects16[9], parameters[9], refArg9);
                REReflection.ReturnBox<TArg10>(ArrayCache.Objects16[10], parameters[10], refArg10);
                REReflection.ReturnBox<TArg11>(ArrayCache.Objects16[11], parameters[11], refArg11);
                REReflection.ReturnBox<TArg12>(ArrayCache.Objects16[12], parameters[12], refArg12);
                REReflection.ReturnBox<TArg13>(ArrayCache.Objects16[13], parameters[13], refArg13);
                REReflection.ReturnBox<TArg14>(ArrayCache.Objects16[14], parameters[14], refArg14);
                REReflection.ReturnBox<TArg15>(ArrayCache.Objects16[15], parameters[15], refArg15);
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static object InvokeClassInstanceLowAlloc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(this MethodBase self, TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9, in TArg10 arg10, in TArg11 arg11, in TArg12 arg12, in TArg13 arg13, in TArg14 arg14, in TArg15 arg15)
        where TTarget: class
        {
            if (self.IsGenericMethodDefinition)
            {
                ValidateGenericMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(ref self);
            }
            var parameters = self.GetParametersFast();
            ArrayCache.Objects16[0] = REReflection.GetBox(arg0, parameters[0], out var refArg0);
            ArrayCache.Objects16[1] = REReflection.GetBox(arg1, parameters[1], out var refArg1);
            ArrayCache.Objects16[2] = REReflection.GetBox(arg2, parameters[2], out var refArg2);
            ArrayCache.Objects16[3] = REReflection.GetBox(arg3, parameters[3], out var refArg3);
            ArrayCache.Objects16[4] = REReflection.GetBox(arg4, parameters[4], out var refArg4);
            ArrayCache.Objects16[5] = REReflection.GetBox(arg5, parameters[5], out var refArg5);
            ArrayCache.Objects16[6] = REReflection.GetBox(arg6, parameters[6], out var refArg6);
            ArrayCache.Objects16[7] = REReflection.GetBox(arg7, parameters[7], out var refArg7);
            ArrayCache.Objects16[8] = REReflection.GetBox(arg8, parameters[8], out var refArg8);
            ArrayCache.Objects16[9] = REReflection.GetBox(arg9, parameters[9], out var refArg9);
            ArrayCache.Objects16[10] = REReflection.GetBox(arg10, parameters[10], out var refArg10);
            ArrayCache.Objects16[11] = REReflection.GetBox(arg11, parameters[11], out var refArg11);
            ArrayCache.Objects16[12] = REReflection.GetBox(arg12, parameters[12], out var refArg12);
            ArrayCache.Objects16[13] = REReflection.GetBox(arg13, parameters[13], out var refArg13);
            ArrayCache.Objects16[14] = REReflection.GetBox(arg14, parameters[14], out var refArg14);
            ArrayCache.Objects16[15] = REReflection.GetBox(arg15, parameters[15], out var refArg15);
            try
            {
                return self.Invoke(target, ArrayCache.Objects16);
            }
            finally
            {
                REReflection.ReturnBox<TArg0>(ArrayCache.Objects16[0], parameters[0], refArg0);
                REReflection.ReturnBox<TArg1>(ArrayCache.Objects16[1], parameters[1], refArg1);
                REReflection.ReturnBox<TArg2>(ArrayCache.Objects16[2], parameters[2], refArg2);
                REReflection.ReturnBox<TArg3>(ArrayCache.Objects16[3], parameters[3], refArg3);
                REReflection.ReturnBox<TArg4>(ArrayCache.Objects16[4], parameters[4], refArg4);
                REReflection.ReturnBox<TArg5>(ArrayCache.Objects16[5], parameters[5], refArg5);
                REReflection.ReturnBox<TArg6>(ArrayCache.Objects16[6], parameters[6], refArg6);
                REReflection.ReturnBox<TArg7>(ArrayCache.Objects16[7], parameters[7], refArg7);
                REReflection.ReturnBox<TArg8>(ArrayCache.Objects16[8], parameters[8], refArg8);
                REReflection.ReturnBox<TArg9>(ArrayCache.Objects16[9], parameters[9], refArg9);
                REReflection.ReturnBox<TArg10>(ArrayCache.Objects16[10], parameters[10], refArg10);
                REReflection.ReturnBox<TArg11>(ArrayCache.Objects16[11], parameters[11], refArg11);
                REReflection.ReturnBox<TArg12>(ArrayCache.Objects16[12], parameters[12], refArg12);
                REReflection.ReturnBox<TArg13>(ArrayCache.Objects16[13], parameters[13], refArg13);
                REReflection.ReturnBox<TArg14>(ArrayCache.Objects16[14], parameters[14], refArg14);
                REReflection.ReturnBox<TArg15>(ArrayCache.Objects16[15], parameters[15], refArg15);
            }
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool ValidateInstanceReturnableMethodRaw<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, TReturn>(MethodBase method, out nint pAddress)
        {
            pAddress = 0;
            if (method.IsStatic)
            {
                return false;
            }
            if (method.IsOverridable())
            {
                return false;
            }
            var isValidGeneric = !method.IsGenericMethodDefinition || ValidateGenericReturnableMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, TReturn>(ref method);
            if (!isValidGeneric)
            {
                return false;
            }
            var parameters = method.GetParametersFast();
            var parameterLength = parameters.Count;
            if (parameterLength != 16)
            {
                return false;
            }
            if (method is MethodInfo mi)
            {
                var returnType = mi?.ReturnType ?? typeof(void);
                if (!returnType.IsValidOutput<TReturn>())
                {
                    return false;
                }
            }
            var reflectedType = method.ReflectedType;
            if (!reflectedType.IsValidInputWithoutRef<TTarget>(1, ref pAddress))
            {
                return false;
            }
            var paramType0 = parameters[0].ParameterType;
            if (!paramType0.IsValidInput<TArg0>(2, ref pAddress))
            {
                return false;
            }
            var paramType1 = parameters[1].ParameterType;
            if (!paramType1.IsValidInput<TArg1>(4, ref pAddress))
            {
                return false;
            }
            var paramType2 = parameters[2].ParameterType;
            if (!paramType2.IsValidInput<TArg2>(8, ref pAddress))
            {
                return false;
            }
            var paramType3 = parameters[3].ParameterType;
            if (!paramType3.IsValidInput<TArg3>(16, ref pAddress))
            {
                return false;
            }
            var paramType4 = parameters[4].ParameterType;
            if (!paramType4.IsValidInput<TArg4>(32, ref pAddress))
            {
                return false;
            }
            var paramType5 = parameters[5].ParameterType;
            if (!paramType5.IsValidInput<TArg5>(64, ref pAddress))
            {
                return false;
            }
            var paramType6 = parameters[6].ParameterType;
            if (!paramType6.IsValidInput<TArg6>(128, ref pAddress))
            {
                return false;
            }
            var paramType7 = parameters[7].ParameterType;
            if (!paramType7.IsValidInput<TArg7>(256, ref pAddress))
            {
                return false;
            }
            var paramType8 = parameters[8].ParameterType;
            if (!paramType8.IsValidInput<TArg8>(512, ref pAddress))
            {
                return false;
            }
            var paramType9 = parameters[9].ParameterType;
            if (!paramType9.IsValidInput<TArg9>(1024, ref pAddress))
            {
                return false;
            }
            var paramType10 = parameters[10].ParameterType;
            if (!paramType10.IsValidInput<TArg10>(2048, ref pAddress))
            {
                return false;
            }
            var paramType11 = parameters[11].ParameterType;
            if (!paramType11.IsValidInput<TArg11>(4096, ref pAddress))
            {
                return false;
            }
            var paramType12 = parameters[12].ParameterType;
            if (!paramType12.IsValidInput<TArg12>(8192, ref pAddress))
            {
                return false;
            }
            var paramType13 = parameters[13].ParameterType;
            if (!paramType13.IsValidInput<TArg13>(16384, ref pAddress))
            {
                return false;
            }
            var paramType14 = parameters[14].ParameterType;
            if (!paramType14.IsValidInput<TArg14>(32768, ref pAddress))
            {
                return false;
            }
            var paramType15 = parameters[15].ParameterType;
            if (!paramType15.IsValidInput<TArg15>(65536, ref pAddress))
            {
                return false;
            }
            if (pAddress != 0)
            {
                return false;
            }
            pAddress = method.GetFunctionPointer();
            return true;
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool ValidateInstanceReturnableVirtualMethodRaw<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, TReturn>(MethodBase method, Type targetType, out nint pAddress)
        {
            pAddress = 0;
            if (method.IsStatic)
            {
                return false;
            }
            if (!method.IsOverridable())
            {
                return false;
            }
            var isValidGeneric = !method.IsGenericMethodDefinition || ValidateGenericReturnableMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, TReturn>(ref method);
            if (!isValidGeneric)
            {
                return false;
            }
            var parameters = method.GetParametersFast();
            var parameterLength = parameters.Count;
            if (parameterLength != 16)
            {
                return false;
            }
            if (method is MethodInfo mi)
            {
                var returnType = mi?.ReturnType ?? typeof(void);
                if (!returnType.IsValidOutput<TReturn>())
                {
                    return false;
                }
            }
            var reflectedType = method.ReflectedType;
            if (!reflectedType.IsValidVirtualInput<TTarget>(targetType, out var isVirtualCall))
            {
                return false;
            }
            if (isVirtualCall)
            {
                ArrayCache.Types16[0] = parameters[0].ParameterType;
                ArrayCache.Types16[1] = parameters[1].ParameterType;
                ArrayCache.Types16[2] = parameters[2].ParameterType;
                ArrayCache.Types16[3] = parameters[3].ParameterType;
                ArrayCache.Types16[4] = parameters[4].ParameterType;
                ArrayCache.Types16[5] = parameters[5].ParameterType;
                ArrayCache.Types16[6] = parameters[6].ParameterType;
                ArrayCache.Types16[7] = parameters[7].ParameterType;
                ArrayCache.Types16[8] = parameters[8].ParameterType;
                ArrayCache.Types16[9] = parameters[9].ParameterType;
                ArrayCache.Types16[10] = parameters[10].ParameterType;
                ArrayCache.Types16[11] = parameters[11].ParameterType;
                ArrayCache.Types16[12] = parameters[12].ParameterType;
                ArrayCache.Types16[13] = parameters[13].ParameterType;
                ArrayCache.Types16[14] = parameters[14].ParameterType;
                ArrayCache.Types16[15] = parameters[15].ParameterType;
                method = targetType.GetInstanceMethodFullAccess(method.Name, null, ArrayCache.Types16, null);
            }
            var paramType0 = parameters[0].ParameterType;
            if (!paramType0.IsValidInput<TArg0>(2, ref pAddress))
            {
                return false;
            }
            var paramType1 = parameters[1].ParameterType;
            if (!paramType1.IsValidInput<TArg1>(4, ref pAddress))
            {
                return false;
            }
            var paramType2 = parameters[2].ParameterType;
            if (!paramType2.IsValidInput<TArg2>(8, ref pAddress))
            {
                return false;
            }
            var paramType3 = parameters[3].ParameterType;
            if (!paramType3.IsValidInput<TArg3>(16, ref pAddress))
            {
                return false;
            }
            var paramType4 = parameters[4].ParameterType;
            if (!paramType4.IsValidInput<TArg4>(32, ref pAddress))
            {
                return false;
            }
            var paramType5 = parameters[5].ParameterType;
            if (!paramType5.IsValidInput<TArg5>(64, ref pAddress))
            {
                return false;
            }
            var paramType6 = parameters[6].ParameterType;
            if (!paramType6.IsValidInput<TArg6>(128, ref pAddress))
            {
                return false;
            }
            var paramType7 = parameters[7].ParameterType;
            if (!paramType7.IsValidInput<TArg7>(256, ref pAddress))
            {
                return false;
            }
            var paramType8 = parameters[8].ParameterType;
            if (!paramType8.IsValidInput<TArg8>(512, ref pAddress))
            {
                return false;
            }
            var paramType9 = parameters[9].ParameterType;
            if (!paramType9.IsValidInput<TArg9>(1024, ref pAddress))
            {
                return false;
            }
            var paramType10 = parameters[10].ParameterType;
            if (!paramType10.IsValidInput<TArg10>(2048, ref pAddress))
            {
                return false;
            }
            var paramType11 = parameters[11].ParameterType;
            if (!paramType11.IsValidInput<TArg11>(4096, ref pAddress))
            {
                return false;
            }
            var paramType12 = parameters[12].ParameterType;
            if (!paramType12.IsValidInput<TArg12>(8192, ref pAddress))
            {
                return false;
            }
            var paramType13 = parameters[13].ParameterType;
            if (!paramType13.IsValidInput<TArg13>(16384, ref pAddress))
            {
                return false;
            }
            var paramType14 = parameters[14].ParameterType;
            if (!paramType14.IsValidInput<TArg14>(32768, ref pAddress))
            {
                return false;
            }
            var paramType15 = parameters[15].ParameterType;
            if (!paramType15.IsValidInput<TArg15>(65536, ref pAddress))
            {
                return false;
            }
            if (pAddress != 0)
            {
                return false;
            }
            pAddress = method.GetFunctionPointer();
            return true;
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool SecondaryValidateInstanceMethodRaw(MethodBase method, Type target, Type arg0, Type arg1, Type arg2, Type arg3, Type arg4, Type arg5, Type arg6, Type arg7, Type arg8, Type arg9, Type arg10, Type arg11, Type arg12, Type arg13, Type arg14, Type arg15, ref nint pAddress)
        {
            if ((pAddress & 1) != 0)
            {
                var reflectedType = method.ReflectedType;
                if (!reflectedType.IsNullAssignableFromFast(target))
                {
                    return false;
                }
            }
            var parameters = method.GetParametersFast();
            if ((pAddress & 2) != 0)
            {
                var paramType = parameters[0].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg0))
                {
                    return false;
                }
            }
            if ((pAddress & 4) != 0)
            {
                var paramType = parameters[1].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg1))
                {
                    return false;
                }
            }
            if ((pAddress & 8) != 0)
            {
                var paramType = parameters[2].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg2))
                {
                    return false;
                }
            }
            if ((pAddress & 16) != 0)
            {
                var paramType = parameters[3].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg3))
                {
                    return false;
                }
            }
            if ((pAddress & 32) != 0)
            {
                var paramType = parameters[4].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg4))
                {
                    return false;
                }
            }
            if ((pAddress & 64) != 0)
            {
                var paramType = parameters[5].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg5))
                {
                    return false;
                }
            }
            if ((pAddress & 128) != 0)
            {
                var paramType = parameters[6].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg6))
                {
                    return false;
                }
            }
            if ((pAddress & 256) != 0)
            {
                var paramType = parameters[7].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg7))
                {
                    return false;
                }
            }
            if ((pAddress & 512) != 0)
            {
                var paramType = parameters[8].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg8))
                {
                    return false;
                }
            }
            if ((pAddress & 1024) != 0)
            {
                var paramType = parameters[9].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg9))
                {
                    return false;
                }
            }
            if ((pAddress & 2048) != 0)
            {
                var paramType = parameters[10].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg10))
                {
                    return false;
                }
            }
            if ((pAddress & 4096) != 0)
            {
                var paramType = parameters[11].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg11))
                {
                    return false;
                }
            }
            if ((pAddress & 8192) != 0)
            {
                var paramType = parameters[12].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg12))
                {
                    return false;
                }
            }
            if ((pAddress & 16384) != 0)
            {
                var paramType = parameters[13].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg13))
                {
                    return false;
                }
            }
            if ((pAddress & 32768) != 0)
            {
                var paramType = parameters[14].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg14))
                {
                    return false;
                }
            }
            if ((pAddress & 65536) != 0)
            {
                var paramType = parameters[15].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg15))
                {
                    return false;
                }
            }
            pAddress = method.GetFunctionPointer();
            return true;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void InvokeStaticFast<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(this MethodBase self, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9, in TArg10 arg10, in TArg11 arg11, in TArg12 arg12, in TArg13 arg13, in TArg14 arg14, in TArg15 arg15)
        {
            bool isValid;
            nint pAddress;
            isValid = ValidateStaticMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(self, out pAddress) ||
                      (pAddress != 0 && SecondaryValidateStaticMethod(self, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), arg11?.GetType(), arg12?.GetType(), arg13?.GetType(), arg14?.GetType(), arg15?.GetType(), ref pAddress));
            if (!isValid)
            {
                self.InvokeStaticLowAlloc(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15);
                return;
            }
            unsafe
            {
                ((delegate*<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, void>)pAddress)(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15);
                return;
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static object InvokeStaticLowAlloc<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(this MethodBase self, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9, in TArg10 arg10, in TArg11 arg11, in TArg12 arg12, in TArg13 arg13, in TArg14 arg14, in TArg15 arg15)
        {
            if (self.IsGenericMethodDefinition)
            {
                ValidateGenericMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(ref self);
            }
            var parameters = self.GetParametersFast();
            ArrayCache.Objects16[0] = REReflection.GetBox(arg0, parameters[0], out var refArg0);
            ArrayCache.Objects16[1] = REReflection.GetBox(arg1, parameters[1], out var refArg1);
            ArrayCache.Objects16[2] = REReflection.GetBox(arg2, parameters[2], out var refArg2);
            ArrayCache.Objects16[3] = REReflection.GetBox(arg3, parameters[3], out var refArg3);
            ArrayCache.Objects16[4] = REReflection.GetBox(arg4, parameters[4], out var refArg4);
            ArrayCache.Objects16[5] = REReflection.GetBox(arg5, parameters[5], out var refArg5);
            ArrayCache.Objects16[6] = REReflection.GetBox(arg6, parameters[6], out var refArg6);
            ArrayCache.Objects16[7] = REReflection.GetBox(arg7, parameters[7], out var refArg7);
            ArrayCache.Objects16[8] = REReflection.GetBox(arg8, parameters[8], out var refArg8);
            ArrayCache.Objects16[9] = REReflection.GetBox(arg9, parameters[9], out var refArg9);
            ArrayCache.Objects16[10] = REReflection.GetBox(arg10, parameters[10], out var refArg10);
            ArrayCache.Objects16[11] = REReflection.GetBox(arg11, parameters[11], out var refArg11);
            ArrayCache.Objects16[12] = REReflection.GetBox(arg12, parameters[12], out var refArg12);
            ArrayCache.Objects16[13] = REReflection.GetBox(arg13, parameters[13], out var refArg13);
            ArrayCache.Objects16[14] = REReflection.GetBox(arg14, parameters[14], out var refArg14);
            ArrayCache.Objects16[15] = REReflection.GetBox(arg15, parameters[15], out var refArg15);
            try
            {
                return self.Invoke(null, ArrayCache.Objects16);
            }
            finally
            {
                REReflection.ReturnBox<TArg0>(ArrayCache.Objects16[0], parameters[0], refArg0);
                REReflection.ReturnBox<TArg1>(ArrayCache.Objects16[1], parameters[1], refArg1);
                REReflection.ReturnBox<TArg2>(ArrayCache.Objects16[2], parameters[2], refArg2);
                REReflection.ReturnBox<TArg3>(ArrayCache.Objects16[3], parameters[3], refArg3);
                REReflection.ReturnBox<TArg4>(ArrayCache.Objects16[4], parameters[4], refArg4);
                REReflection.ReturnBox<TArg5>(ArrayCache.Objects16[5], parameters[5], refArg5);
                REReflection.ReturnBox<TArg6>(ArrayCache.Objects16[6], parameters[6], refArg6);
                REReflection.ReturnBox<TArg7>(ArrayCache.Objects16[7], parameters[7], refArg7);
                REReflection.ReturnBox<TArg8>(ArrayCache.Objects16[8], parameters[8], refArg8);
                REReflection.ReturnBox<TArg9>(ArrayCache.Objects16[9], parameters[9], refArg9);
                REReflection.ReturnBox<TArg10>(ArrayCache.Objects16[10], parameters[10], refArg10);
                REReflection.ReturnBox<TArg11>(ArrayCache.Objects16[11], parameters[11], refArg11);
                REReflection.ReturnBox<TArg12>(ArrayCache.Objects16[12], parameters[12], refArg12);
                REReflection.ReturnBox<TArg13>(ArrayCache.Objects16[13], parameters[13], refArg13);
                REReflection.ReturnBox<TArg14>(ArrayCache.Objects16[14], parameters[14], refArg14);
                REReflection.ReturnBox<TArg15>(ArrayCache.Objects16[15], parameters[15], refArg15);
            }
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool ValidateStaticMethodRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(MethodBase method, out nint pAddress)
        {
            pAddress = 0;
            if (!method.IsStatic)
            {
                return false;
            }
            if (method.IsOverridable())
            {
                return false;
            }
            var isValidGeneric = !method.IsGenericMethodDefinition || ValidateGenericMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(ref method);
            if (!isValidGeneric)
            {
                return false;
            }
            var parameters = method.GetParametersFast();
            var parameterLength = parameters.Count;
            if (parameterLength != 16)
            {
                return false;
            }
            if (method is MethodInfo mi)
            {
                var returnType = mi?.ReturnType ?? typeof(void);
                if (returnType != typeof(void))
                {
                    return false;
                }
            }
            var paramType0 = parameters[0].ParameterType;
            if (!paramType0.IsValidInput<TArg0>(2, ref pAddress))
            {
                return false;
            }
            var paramType1 = parameters[1].ParameterType;
            if (!paramType1.IsValidInput<TArg1>(4, ref pAddress))
            {
                return false;
            }
            var paramType2 = parameters[2].ParameterType;
            if (!paramType2.IsValidInput<TArg2>(8, ref pAddress))
            {
                return false;
            }
            var paramType3 = parameters[3].ParameterType;
            if (!paramType3.IsValidInput<TArg3>(16, ref pAddress))
            {
                return false;
            }
            var paramType4 = parameters[4].ParameterType;
            if (!paramType4.IsValidInput<TArg4>(32, ref pAddress))
            {
                return false;
            }
            var paramType5 = parameters[5].ParameterType;
            if (!paramType5.IsValidInput<TArg5>(64, ref pAddress))
            {
                return false;
            }
            var paramType6 = parameters[6].ParameterType;
            if (!paramType6.IsValidInput<TArg6>(128, ref pAddress))
            {
                return false;
            }
            var paramType7 = parameters[7].ParameterType;
            if (!paramType7.IsValidInput<TArg7>(256, ref pAddress))
            {
                return false;
            }
            var paramType8 = parameters[8].ParameterType;
            if (!paramType8.IsValidInput<TArg8>(512, ref pAddress))
            {
                return false;
            }
            var paramType9 = parameters[9].ParameterType;
            if (!paramType9.IsValidInput<TArg9>(1024, ref pAddress))
            {
                return false;
            }
            var paramType10 = parameters[10].ParameterType;
            if (!paramType10.IsValidInput<TArg10>(2048, ref pAddress))
            {
                return false;
            }
            var paramType11 = parameters[11].ParameterType;
            if (!paramType11.IsValidInput<TArg11>(4096, ref pAddress))
            {
                return false;
            }
            var paramType12 = parameters[12].ParameterType;
            if (!paramType12.IsValidInput<TArg12>(8192, ref pAddress))
            {
                return false;
            }
            var paramType13 = parameters[13].ParameterType;
            if (!paramType13.IsValidInput<TArg13>(16384, ref pAddress))
            {
                return false;
            }
            var paramType14 = parameters[14].ParameterType;
            if (!paramType14.IsValidInput<TArg14>(32768, ref pAddress))
            {
                return false;
            }
            var paramType15 = parameters[15].ParameterType;
            if (!paramType15.IsValidInput<TArg15>(65536, ref pAddress))
            {
                return false;
            }
            if (pAddress != 0)
            {
                return false;
            }
            pAddress = method.GetFunctionPointer();
            return true;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TReturn InvokeStaticFast<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, TReturn>(this MethodBase self, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9, in TArg10 arg10, in TArg11 arg11, in TArg12 arg12, in TArg13 arg13, in TArg14 arg14, in TArg15 arg15)
        {
            bool isValid;
            nint pAddress;
            isValid = ValidateStaticReturnableMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, TReturn>(self, out pAddress) ||
                      (pAddress != 0 && SecondaryValidateStaticMethod(self, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), arg11?.GetType(), arg12?.GetType(), arg13?.GetType(), arg14?.GetType(), arg15?.GetType(), ref pAddress));
            if (!isValid)
            {
                return (TReturn)self.InvokeStaticLowAlloc(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15);
            }
            unsafe
            {
                return ((delegate*<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, TReturn>)pAddress)(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15);
            }
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool ValidateStaticReturnableMethodRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, TReturn>(MethodBase method, out nint pAddress)
        {
            pAddress = 0;
            if (!method.IsStatic)
            {
                return false;
            }
            if (method.IsOverridable())
            {
                return false;
            }
            var isValidGeneric = !method.IsGenericMethodDefinition || ValidateGenericReturnableMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, TReturn>(ref method);
            if (!isValidGeneric)
            {
                return false;
            }
            var parameters = method.GetParametersFast();
            var parameterLength = parameters.Count;
            if (parameterLength != 16)
            {
                return false;
            }
            if (method is MethodInfo mi)
            {
                var returnType = mi?.ReturnType ?? typeof(void);
                if (!returnType.IsValidOutput<TReturn>())
                {
                    return false;
                }
            }
            var paramType0 = parameters[0].ParameterType;
            if (!paramType0.IsValidInput<TArg0>(2, ref pAddress))
            {
                return false;
            }
            var paramType1 = parameters[1].ParameterType;
            if (!paramType1.IsValidInput<TArg1>(4, ref pAddress))
            {
                return false;
            }
            var paramType2 = parameters[2].ParameterType;
            if (!paramType2.IsValidInput<TArg2>(8, ref pAddress))
            {
                return false;
            }
            var paramType3 = parameters[3].ParameterType;
            if (!paramType3.IsValidInput<TArg3>(16, ref pAddress))
            {
                return false;
            }
            var paramType4 = parameters[4].ParameterType;
            if (!paramType4.IsValidInput<TArg4>(32, ref pAddress))
            {
                return false;
            }
            var paramType5 = parameters[5].ParameterType;
            if (!paramType5.IsValidInput<TArg5>(64, ref pAddress))
            {
                return false;
            }
            var paramType6 = parameters[6].ParameterType;
            if (!paramType6.IsValidInput<TArg6>(128, ref pAddress))
            {
                return false;
            }
            var paramType7 = parameters[7].ParameterType;
            if (!paramType7.IsValidInput<TArg7>(256, ref pAddress))
            {
                return false;
            }
            var paramType8 = parameters[8].ParameterType;
            if (!paramType8.IsValidInput<TArg8>(512, ref pAddress))
            {
                return false;
            }
            var paramType9 = parameters[9].ParameterType;
            if (!paramType9.IsValidInput<TArg9>(1024, ref pAddress))
            {
                return false;
            }
            var paramType10 = parameters[10].ParameterType;
            if (!paramType10.IsValidInput<TArg10>(2048, ref pAddress))
            {
                return false;
            }
            var paramType11 = parameters[11].ParameterType;
            if (!paramType11.IsValidInput<TArg11>(4096, ref pAddress))
            {
                return false;
            }
            var paramType12 = parameters[12].ParameterType;
            if (!paramType12.IsValidInput<TArg12>(8192, ref pAddress))
            {
                return false;
            }
            var paramType13 = parameters[13].ParameterType;
            if (!paramType13.IsValidInput<TArg13>(16384, ref pAddress))
            {
                return false;
            }
            var paramType14 = parameters[14].ParameterType;
            if (!paramType14.IsValidInput<TArg14>(32768, ref pAddress))
            {
                return false;
            }
            var paramType15 = parameters[15].ParameterType;
            if (!paramType15.IsValidInput<TArg15>(65536, ref pAddress))
            {
                return false;
            }
            if (pAddress != 0)
            {
                return false;
            }
            pAddress = method.GetFunctionPointer();
            return true;
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool SecondaryValidateStaticMethodRaw(MethodBase method, Type arg0, Type arg1, Type arg2, Type arg3, Type arg4, Type arg5, Type arg6, Type arg7, Type arg8, Type arg9, Type arg10, Type arg11, Type arg12, Type arg13, Type arg14, Type arg15, ref nint pAddress)
        {
            var parameters = method.GetParametersFast();
            if ((pAddress & 2) != 0)
            {
                var paramType = parameters[0].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg0))
                {
                    return false;
                }
            }
            if ((pAddress & 4) != 0)
            {
                var paramType = parameters[1].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg1))
                {
                    return false;
                }
            }
            if ((pAddress & 8) != 0)
            {
                var paramType = parameters[2].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg2))
                {
                    return false;
                }
            }
            if ((pAddress & 16) != 0)
            {
                var paramType = parameters[3].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg3))
                {
                    return false;
                }
            }
            if ((pAddress & 32) != 0)
            {
                var paramType = parameters[4].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg4))
                {
                    return false;
                }
            }
            if ((pAddress & 64) != 0)
            {
                var paramType = parameters[5].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg5))
                {
                    return false;
                }
            }
            if ((pAddress & 128) != 0)
            {
                var paramType = parameters[6].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg6))
                {
                    return false;
                }
            }
            if ((pAddress & 256) != 0)
            {
                var paramType = parameters[7].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg7))
                {
                    return false;
                }
            }
            if ((pAddress & 512) != 0)
            {
                var paramType = parameters[8].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg8))
                {
                    return false;
                }
            }
            if ((pAddress & 1024) != 0)
            {
                var paramType = parameters[9].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg9))
                {
                    return false;
                }
            }
            if ((pAddress & 2048) != 0)
            {
                var paramType = parameters[10].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg10))
                {
                    return false;
                }
            }
            if ((pAddress & 4096) != 0)
            {
                var paramType = parameters[11].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg11))
                {
                    return false;
                }
            }
            if ((pAddress & 8192) != 0)
            {
                var paramType = parameters[12].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg12))
                {
                    return false;
                }
            }
            if ((pAddress & 16384) != 0)
            {
                var paramType = parameters[13].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg13))
                {
                    return false;
                }
            }
            if ((pAddress & 32768) != 0)
            {
                var paramType = parameters[14].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg14))
                {
                    return false;
                }
            }
            if ((pAddress & 65536) != 0)
            {
                var paramType = parameters[15].ParameterType;
                if (!paramType.IsNullAssignableFromFast(arg15))
                {
                    return false;
                }
            }
            pAddress = method.GetFunctionPointer();
            return true;
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool ValidateGenericMethodRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(ref MethodBase method)
        {
            if (!method.IsGenericMethodDefinition)
            {
                return true;
            }
            var genericArguments = method.GetGenericArgumentsFast();
            if (genericArguments.Count < 16)
            {
                return false;
            }
            uint mask = 0;
            var mi = method as MethodInfo;
            var parameters = method.GetParametersFast();
            var index0 = IndexOf(genericArguments, parameters[0].ParameterType);
            if (index0 >= 0)
            {
                mask |= 1u << index0;
            }
            var index1 = IndexOf(genericArguments, parameters[1].ParameterType);
            if (index1 >= 0)
            {
                mask |= 1u << index1;
            }
            var index2 = IndexOf(genericArguments, parameters[2].ParameterType);
            if (index2 >= 0)
            {
                mask |= 1u << index2;
            }
            var index3 = IndexOf(genericArguments, parameters[3].ParameterType);
            if (index3 >= 0)
            {
                mask |= 1u << index3;
            }
            var index4 = IndexOf(genericArguments, parameters[4].ParameterType);
            if (index4 >= 0)
            {
                mask |= 1u << index4;
            }
            var index5 = IndexOf(genericArguments, parameters[5].ParameterType);
            if (index5 >= 0)
            {
                mask |= 1u << index5;
            }
            var index6 = IndexOf(genericArguments, parameters[6].ParameterType);
            if (index6 >= 0)
            {
                mask |= 1u << index6;
            }
            var index7 = IndexOf(genericArguments, parameters[7].ParameterType);
            if (index7 >= 0)
            {
                mask |= 1u << index7;
            }
            var index8 = IndexOf(genericArguments, parameters[8].ParameterType);
            if (index8 >= 0)
            {
                mask |= 1u << index8;
            }
            var index9 = IndexOf(genericArguments, parameters[9].ParameterType);
            if (index9 >= 0)
            {
                mask |= 1u << index9;
            }
            var index10 = IndexOf(genericArguments, parameters[10].ParameterType);
            if (index10 >= 0)
            {
                mask |= 1u << index10;
            }
            var index11 = IndexOf(genericArguments, parameters[11].ParameterType);
            if (index11 >= 0)
            {
                mask |= 1u << index11;
            }
            var index12 = IndexOf(genericArguments, parameters[12].ParameterType);
            if (index12 >= 0)
            {
                mask |= 1u << index12;
            }
            var index13 = IndexOf(genericArguments, parameters[13].ParameterType);
            if (index13 >= 0)
            {
                mask |= 1u << index13;
            }
            var index14 = IndexOf(genericArguments, parameters[14].ParameterType);
            if (index14 >= 0)
            {
                mask |= 1u << index14;
            }
            var index15 = IndexOf(genericArguments, parameters[15].ParameterType);
            if (index15 >= 0)
            {
                mask |= 1u << index15;
            }
            if (REReflection.BitCount(mask) != genericArguments.Count)
            {
                return false;
            }
            var types = ArrayCache.GetArrayCache<Type>(genericArguments.Count);
            if (index0 >= 0)
            {
                types[index0] = typeof(TArg0);
            }
            if (index1 >= 0)
            {
                types[index1] = typeof(TArg1);
            }
            if (index2 >= 0)
            {
                types[index2] = typeof(TArg2);
            }
            if (index3 >= 0)
            {
                types[index3] = typeof(TArg3);
            }
            if (index4 >= 0)
            {
                types[index4] = typeof(TArg4);
            }
            if (index5 >= 0)
            {
                types[index5] = typeof(TArg5);
            }
            if (index6 >= 0)
            {
                types[index6] = typeof(TArg6);
            }
            if (index7 >= 0)
            {
                types[index7] = typeof(TArg7);
            }
            if (index8 >= 0)
            {
                types[index8] = typeof(TArg8);
            }
            if (index9 >= 0)
            {
                types[index9] = typeof(TArg9);
            }
            if (index10 >= 0)
            {
                types[index10] = typeof(TArg10);
            }
            if (index11 >= 0)
            {
                types[index11] = typeof(TArg11);
            }
            if (index12 >= 0)
            {
                types[index12] = typeof(TArg12);
            }
            if (index13 >= 0)
            {
                types[index13] = typeof(TArg13);
            }
            if (index14 >= 0)
            {
                types[index14] = typeof(TArg14);
            }
            if (index15 >= 0)
            {
                types[index15] = typeof(TArg15);
            }
            #if ENABLE_IL2CPP
            bool isFound = false;
            var usingMethods = method.GetUsingGenericInstanceMethods();
            foreach (var usingMethod in usingMethods)
            {
                if (usingMethod.GetGenericArgumentsFast().SequenceEqual(types))
                {
                    isFound = true;
                    break;
                }
            }
            if (!isFound)
            {
                return false;
            }
            #endif
            method = mi.MakeGenericMethodFast(types);
            return true;
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool ValidateGenericReturnableMethodRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, TReturn>(ref MethodBase method)
        {
            if (!method.IsGenericMethodDefinition)
            {
                return true;
            }
            var genericArguments = method.GetGenericArgumentsFast();
            if (genericArguments.Count < 17)
            {
                return false;
            }
            uint mask = 0;
            var mi = method as MethodInfo;
            var returnType = mi.ReturnType ?? typeof(void);
            var index = IndexOf(genericArguments, returnType);
            if (index >= 0)
            {
                mask |= 1u << index;
            }
            var parameters = method.GetParametersFast();
            var index0 = IndexOf(genericArguments, parameters[0].ParameterType);
            if (index0 >= 0)
            {
                mask |= 1u << index0;
            }
            var index1 = IndexOf(genericArguments, parameters[1].ParameterType);
            if (index1 >= 0)
            {
                mask |= 1u << index1;
            }
            var index2 = IndexOf(genericArguments, parameters[2].ParameterType);
            if (index2 >= 0)
            {
                mask |= 1u << index2;
            }
            var index3 = IndexOf(genericArguments, parameters[3].ParameterType);
            if (index3 >= 0)
            {
                mask |= 1u << index3;
            }
            var index4 = IndexOf(genericArguments, parameters[4].ParameterType);
            if (index4 >= 0)
            {
                mask |= 1u << index4;
            }
            var index5 = IndexOf(genericArguments, parameters[5].ParameterType);
            if (index5 >= 0)
            {
                mask |= 1u << index5;
            }
            var index6 = IndexOf(genericArguments, parameters[6].ParameterType);
            if (index6 >= 0)
            {
                mask |= 1u << index6;
            }
            var index7 = IndexOf(genericArguments, parameters[7].ParameterType);
            if (index7 >= 0)
            {
                mask |= 1u << index7;
            }
            var index8 = IndexOf(genericArguments, parameters[8].ParameterType);
            if (index8 >= 0)
            {
                mask |= 1u << index8;
            }
            var index9 = IndexOf(genericArguments, parameters[9].ParameterType);
            if (index9 >= 0)
            {
                mask |= 1u << index9;
            }
            var index10 = IndexOf(genericArguments, parameters[10].ParameterType);
            if (index10 >= 0)
            {
                mask |= 1u << index10;
            }
            var index11 = IndexOf(genericArguments, parameters[11].ParameterType);
            if (index11 >= 0)
            {
                mask |= 1u << index11;
            }
            var index12 = IndexOf(genericArguments, parameters[12].ParameterType);
            if (index12 >= 0)
            {
                mask |= 1u << index12;
            }
            var index13 = IndexOf(genericArguments, parameters[13].ParameterType);
            if (index13 >= 0)
            {
                mask |= 1u << index13;
            }
            var index14 = IndexOf(genericArguments, parameters[14].ParameterType);
            if (index14 >= 0)
            {
                mask |= 1u << index14;
            }
            var index15 = IndexOf(genericArguments, parameters[15].ParameterType);
            if (index15 >= 0)
            {
                mask |= 1u << index15;
            }
            if (REReflection.BitCount(mask) != genericArguments.Count)
            {
                return false;
            }
            var types = ArrayCache.GetArrayCache<Type>(genericArguments.Count);
            if (index >= 0)
            {
                types[index] = typeof(TReturn);
            }
            if (index0 >= 0)
            {
                types[index0] = typeof(TArg0);
            }
            if (index1 >= 0)
            {
                types[index1] = typeof(TArg1);
            }
            if (index2 >= 0)
            {
                types[index2] = typeof(TArg2);
            }
            if (index3 >= 0)
            {
                types[index3] = typeof(TArg3);
            }
            if (index4 >= 0)
            {
                types[index4] = typeof(TArg4);
            }
            if (index5 >= 0)
            {
                types[index5] = typeof(TArg5);
            }
            if (index6 >= 0)
            {
                types[index6] = typeof(TArg6);
            }
            if (index7 >= 0)
            {
                types[index7] = typeof(TArg7);
            }
            if (index8 >= 0)
            {
                types[index8] = typeof(TArg8);
            }
            if (index9 >= 0)
            {
                types[index9] = typeof(TArg9);
            }
            if (index10 >= 0)
            {
                types[index10] = typeof(TArg10);
            }
            if (index11 >= 0)
            {
                types[index11] = typeof(TArg11);
            }
            if (index12 >= 0)
            {
                types[index12] = typeof(TArg12);
            }
            if (index13 >= 0)
            {
                types[index13] = typeof(TArg13);
            }
            if (index14 >= 0)
            {
                types[index14] = typeof(TArg14);
            }
            if (index15 >= 0)
            {
                types[index15] = typeof(TArg15);
            }
            #if ENABLE_IL2CPP
            bool isFound = false;
            var usingMethods = method.GetUsingGenericInstanceMethods();
            foreach (var usingMethod in usingMethods)
            {
                if (usingMethod.GetGenericArgumentsFast().SequenceEqual(types))
                {
                    isFound = true;
                    break;
                }
            }
            if (!isFound)
            {
                return false;
            }
            #endif
            method = mi.MakeGenericMethodFast(types);
            return true;
        }
    }
}

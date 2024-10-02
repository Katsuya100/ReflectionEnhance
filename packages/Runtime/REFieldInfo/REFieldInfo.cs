using Katuusagi.MemoizationForUnity;
using System;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

namespace Katuusagi.ReflectionEnhance
{
    public static partial class REFieldInfo
    {
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] { "Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)" })]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool IsSerializeFieldRaw(this FieldInfo self)
        {
            var result = !self.IsStatic &&
                         !self.HasAttribute<NonSerializedAttribute>() &&
                         ((self.HasAttribute<SerializeReference>() && self.FieldType.GetElementTypeOfUnitySerialize().IsInterface) ||
                         ((self.IsPublic || self.HasAttribute<SerializeField>()) && self.FieldType.IsSerializableTypeAsField()));
            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static object GetInstanceValueLowAlloc<TTarget>(this FieldInfo self, in TTarget target)
        {
            var targetObj = REReflection.GetBoxWithoutRef(target);
            try
            {
                return self.GetValue(targetObj);
            }
            finally
            {
                REReflection.ReturnBoxWithoutRef<TTarget>(targetObj);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T GetInstanceValueFast<TTarget, T>(this FieldInfo self, ref TTarget target)
        {
            var isValid = ValidateInstanceFieldGet<TTarget, T>(self, out var pOffsetAddress) ||
                          (pOffsetAddress != 0 && SecondaryValidateInstanceFieldGet<TTarget>(self, target?.GetType(), ref pOffsetAddress));
            if (!isValid)
            {
                return (T)self.GetInstanceValueLowAlloc(target);
            }

            unsafe
            {
                nint pTarget;
                if (REType.IsValueTypeFast<TTarget>())
                {
                    pTarget = (nint)Unsafe.AsPointer(ref target);
                }
                else
                {
                    pTarget = Unsafe.As<TTarget, nint>(ref target);
                }

                void* fieldPtr = (void*)(pTarget + pOffsetAddress);
                return Unsafe.AsRef<T>(fieldPtr);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T GetClassInstanceValueFast<TTarget, T>(this FieldInfo self, TTarget target)
            where TTarget : class
        {
            var isValid = ValidateInstanceFieldGet<TTarget, T>(self, out var pOffsetAddress) ||
                          (pOffsetAddress != 0 && SecondaryValidateInstanceFieldGet<TTarget>(self, target?.GetType(), ref pOffsetAddress));
            if (!isValid)
            {
                return (T)self.GetValue(target);
            }

            unsafe
            {
                nint pTarget = Unsafe.As<TTarget, IntPtr>(ref target);
                void* fieldPtr = (void*)(pTarget + pOffsetAddress);
                return Unsafe.AsRef<T>(fieldPtr);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T GetStructInstanceValueFast<TTarget, T>(this FieldInfo self, ref TTarget target)
            where TTarget : struct
        {
            var isValid = ValidateInstanceFieldGet<TTarget, T>(self, out var pOffsetAddress) ||
                          (pOffsetAddress != 0 && SecondaryValidateInstanceFieldGet<TTarget>(self, target.GetType(), ref pOffsetAddress));
            if (!isValid)
            {
                return (T)self.GetInstanceValueLowAlloc(target);
            }

            unsafe
            {
                nint pTarget = (nint)Unsafe.AsPointer(ref target);
                void* fieldPtr = (void*)(pTarget + pOffsetAddress);
                return Unsafe.AsRef<T>(fieldPtr);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetInstanceValueLowAlloc<TTarget, T>(this FieldInfo self, ref TTarget target, in T value)
        {
            var targetObj = REReflection.GetBoxWithoutRef(target);
            var v = REReflection.GetBoxWithoutRef(value);
            try
            {
                self.SetValue(targetObj, v);
            }
            finally
            {
                REReflection.Unbox(targetObj, out target);
                REReflection.ReturnBoxWithoutRef<T>(v);
                REReflection.ReturnBoxWithoutRef<TTarget>(targetObj);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetClassInstanceValueLowAlloc<TTarget, T>(this FieldInfo self, TTarget target, in T value)
            where TTarget : class
        {
            var v = REReflection.GetBoxWithoutRef(value);
            try
            {
                self.SetValue(target, v);
            }
            finally
            {
                REReflection.ReturnBoxWithoutRef<T>(v);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetInstanceValueFast<TTarget, T>(this FieldInfo self, ref TTarget target, in T value)
        {
            var isValid = ValidateInstanceFieldSet<TTarget, T>(self, out var pOffsetAddress) ||
                          (pOffsetAddress != 0 && SecondaryValidateInstanceFieldSet<TTarget>(self, target?.GetType(), value?.GetType(), ref pOffsetAddress));
            if (!isValid)
            {
                self.SetInstanceValueLowAlloc(ref target, value);
                return;
            }

            unsafe
            {
                nint pTarget;
                if (REType.IsValueTypeFast<TTarget>())
                {
                    pTarget = (nint)Unsafe.AsPointer(ref target);
                }
                else
                {
                    pTarget = Unsafe.As<TTarget, IntPtr>(ref target);
                }

                void* fieldPtr = (void*)(pTarget + pOffsetAddress);
                Unsafe.Write(fieldPtr, value);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetClassInstanceValueFast<TTarget, T>(this FieldInfo self, TTarget target, in T value)
            where TTarget : class
        {
            var isValid = ValidateInstanceFieldSet<TTarget, T>(self, out var pOffsetAddress) ||
                          (pOffsetAddress != 0 && SecondaryValidateInstanceFieldSet<TTarget>(self, target?.GetType(), value?.GetType(), ref pOffsetAddress));
            if (!isValid)
            {
                self.SetClassInstanceValueLowAlloc(target, value);
                return;
            }

            unsafe
            {
                nint pTarget = Unsafe.As<TTarget, IntPtr>(ref target);
                void* fieldPtr = (void*)(pTarget + pOffsetAddress);
                Unsafe.Write(fieldPtr, value);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetStructInstanceValueFast<TTarget, T>(this FieldInfo self, ref TTarget target, in T value)
            where TTarget : struct
        {
            var isValid = ValidateInstanceFieldSet<TTarget, T>(self, out var pOffsetAddress) ||
                          (pOffsetAddress != 0 && SecondaryValidateInstanceFieldSet<TTarget>(self, target.GetType(), value?.GetType(), ref pOffsetAddress));
            if (!isValid)
            {
                self.SetInstanceValueLowAlloc(ref target, value);
                return;
            }

            unsafe
            {
                nint pTarget = (nint)Unsafe.AsPointer(ref target);
                void* fieldPtr = (void*)(pTarget + pOffsetAddress);
                Unsafe.Write(fieldPtr, value);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T GetStaticValueFast<T>(this FieldInfo self)
        {
            if (!ValidateStaticFieldGet<T>(self, out var pAddress))
            {
#if ENABLE_IL2CPP
                if (pAddress == -1)
                {
                    unsafe
                    {
                        T result = default;
                        Utils.IL2CPPUtils.il2cpp_field_static_get_value(self.FieldHandle.Value, Unsafe.AsPointer(ref result));
                        return result;
                    }
                }
#endif
                return (T)self.GetValue(null);
            }

            unsafe
            {
                void* fieldPtr = (void*)pAddress;
                return Unsafe.AsRef<T>(fieldPtr);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetStaticValueLowAlloc<T>(this FieldInfo self, in T value)
        {
            var v = REReflection.GetBoxWithoutRef(value);
            try
            {
                self.SetValue(null, v);
            }
            finally
            {
                REReflection.ReturnBoxWithoutRef<T>(v);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetStaticValueFast<T>(this FieldInfo self, in T value)
        {
            var isValid = ValidateStaticFieldSet<T>(self, out var pAddress) ||
                          (pAddress != -1 && pAddress != 0 && SecondaryValidateStaticFieldSet(self, value?.GetType(), ref pAddress));
            if (!isValid)
            {
#if ENABLE_IL2CPP
                if (pAddress == -1)
                {
                    unsafe
                    {
                        T v = value;
                        Utils.IL2CPPUtils.il2cpp_field_static_set_value(self.FieldHandle.Value, Unsafe.AsPointer(ref v));
                        return;
                    }
                }
#endif
                self.SetStaticValueLowAlloc(value);
                return;
            }

            unsafe
            {
                void* fieldPtr = (void*)pAddress;
                Unsafe.Write(fieldPtr, value);
            }
        }

        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool ValidateInstanceFieldGetRaw<TTarget, T>(FieldInfo field, out nint pOffsetAddress)
        {
            pOffsetAddress = 0;
            if (field.IsStatic)
            {
                return false;
            }

            var fieldType = field.FieldType;
            if (!fieldType.IsValidOutput<T>())
            {
                return false;
            }

            var reflectedType = field.ReflectedType;
            if (!reflectedType.IsValidInputWithoutRef<TTarget>(1, ref pOffsetAddress))
            {
                return false;
            }

            if (pOffsetAddress != 0)
            {
                return false;
            }

            pOffsetAddress = field.GetFieldPointerOffset();
            return true;
        }

        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool SecondaryValidateInstanceFieldGetRaw<TTarget>(FieldInfo field, Type target, ref nint pOffsetAddress)
        {
            if ((pOffsetAddress & 1) != 0)
            {
                var reflectedType = field.ReflectedType;
                if (!reflectedType.IsNullAssignableFromFast(target))
                {
                    return false;
                }
            }
            pOffsetAddress = field.GetFieldPointerOffset();
            return true;
        }

        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool ValidateInstanceFieldSetRaw<TTarget, T>(FieldInfo field, out nint pOffsetAddress)
        {
            pOffsetAddress = 0;
            if (field.IsStatic)
            {
                return false;
            }

            var reflectedType = field.ReflectedType;
            if (!reflectedType.IsValidInputWithoutRef<TTarget>(1, ref pOffsetAddress))
            {
                return false;
            }

            var fieldType = field.FieldType;
            if (!fieldType.IsValidInputWithoutRef<T>(2, ref pOffsetAddress))
            {
                return false;
            }

            if (pOffsetAddress != 0)
            {
                return false;
            }

            pOffsetAddress = field.GetFieldPointerOffset();
            return true;
        }

        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool SecondaryValidateInstanceFieldSetRaw<TTarget>(FieldInfo field, Type target, Type value, ref nint pOffsetAddress)
        {
            if ((pOffsetAddress & 1) != 0)
            {
                var reflectedType = field.ReflectedType;
                if (!reflectedType.IsNullAssignableFromFast(target))
                {
                    return false;
                }
            }
            if ((pOffsetAddress & 2) != 0)
            {
                var fieldType = field.FieldType;
                if (!fieldType.IsNullAssignableFromFast(value))
                {
                    return false;
                }
            }
            pOffsetAddress = field.GetFieldPointerOffset();
            return true;
        }
        
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool ValidateStaticFieldGetRaw<T>(FieldInfo field, out nint pAddress)
        {
            pAddress = 0;
            if (!field.IsStatic)
            {
                return false;
            }

            var fieldType = field.FieldType;
            if (!fieldType.IsValidOutput<T>())
            {
                return false;
            }

            pAddress = field.GetStaticFieldPointer();
            if (pAddress == IntPtr.Zero)
            {
                pAddress = -1;
                return false;
            }

            return true;
        }

        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool ValidateStaticFieldSetRaw<T>(FieldInfo field, out nint pAddress)
        {
            pAddress = 0;
            if (!field.IsStatic)
            {
                return false;
            }

            var fieldType = field.FieldType;
            if (!fieldType.IsValidInputWithoutRef<T>(2, ref pAddress))
            {
                return false;
            }

            if (pAddress != 0)
            {
                return false;
            }

            pAddress = field.GetStaticFieldPointer();
            if (pAddress == IntPtr.Zero)
            {
                pAddress = -1;
                return false;
            }

            return true;
        }

        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool SecondaryValidateStaticFieldSetRaw(FieldInfo field, Type value, ref nint pAddress)
        {
            if ((pAddress & 2) != 0)
            {
                var fieldType = field.FieldType;
                if (!fieldType.IsNullAssignableFromFast(value))
                {
                    return false;
                }
            }

            pAddress = field.GetStaticFieldPointer();
            if (pAddress == IntPtr.Zero)
            {
                pAddress = -1;
                return false;
            }

            return true;
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] { "Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)" })]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static nint GetFieldPointerOffsetRaw(this FieldInfo self)
        {
            return UnsafeUtility.GetFieldOffset(self);
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] { "Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)" })]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static unsafe nint GetStaticFieldPointerRaw(this FieldInfo self)
        {
            MethodInfo getPointer;
#if ENABLE_IL2CPP
            getPointer = self.ReflectedType.GetStaticMethodFullAccess($"$GetPointer_{self.Name}");
            if (getPointer == null)
            {
                return 0;
            }
#else
            var m = new DynamicMethod($"$GetPointer_{self.Name}", typeof(nint), ArrayCache.Types0, self.DeclaringType, true);
            ILGenerator cg = m.GetILGenerator();
            cg.Emit(OpCodes.Ldsflda, self);
            cg.Emit(OpCodes.Ret);
            REReflection.InitDynamicMethod(m);
            getPointer = m;
#endif
            return getPointer.InvokeStaticFast<nint>();
        }
    }
}

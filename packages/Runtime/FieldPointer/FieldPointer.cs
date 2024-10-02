using Katuusagi.ConstExpressionForUnity;
using System;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Katuusagi.ReflectionEnhance
{
    public readonly struct InstanceFieldPointer<TTarget, T>
    {
        private readonly nint _pOffsetAddress;
        private readonly nint _pGetOffsetAddress;
        private readonly nint _pSetOffsetAddress;
        private readonly bool _isValidGet;
        private readonly bool _isValidSet;
        private readonly FieldInfo _field;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public InstanceFieldPointer(FieldInfo field)
        {
            _field = field;
            _isValidGet = REFieldInfo.ValidateInstanceFieldGet<TTarget, T>(field, out _pGetOffsetAddress);
            _isValidSet = REFieldInfo.ValidateInstanceFieldSet<TTarget, T>(field, out _pSetOffsetAddress);
            if (_isValidGet)
            {
                _pOffsetAddress = _pGetOffsetAddress;
            }
            else if(_isValidSet)
            {
                _pOffsetAddress = _pSetOffsetAddress;
            }
            else
            {
                _pOffsetAddress = 0;
            }
        }

        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator InstanceFieldPointer<TTarget, T>(FieldInfo field)
        {
            return new InstanceFieldPointer<TTarget, T>(field);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public T GetValue(ref TTarget target)
        {
            bool isValid = _isValidGet;
            nint pOffsetAddress = _pGetOffsetAddress;
            if (!isValid)
            {
                isValid = pOffsetAddress != 0 && REFieldInfo.SecondaryValidateInstanceFieldGet<TTarget>(_field, target?.GetType(), ref pOffsetAddress);
                if (!isValid)
                {
                    return (T)_field.GetInstanceValueLowAlloc(target);
                }
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
        public void SetValue(ref TTarget target, in T value)
        {
            bool isValid = _isValidSet;
            nint pOffsetAddress = _pSetOffsetAddress;
            if (!isValid)
            {
                isValid = pOffsetAddress != 0 && REFieldInfo.SecondaryValidateInstanceFieldSet<TTarget>(_field, target?.GetType(), value?.GetType(), ref pOffsetAddress);
                if (!isValid)
                {
                    _field.SetInstanceValueLowAlloc(ref target, value);
                    return;
                }
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
    }

    public readonly struct ClassInstanceFieldPointer<TTarget, T>
        where TTarget : class
    {
        private readonly nint _pOffsetAddress;
        private readonly nint _pGetOffsetAddress;
        private readonly nint _pSetOffsetAddress;
        private readonly bool _isValidGet;
        private readonly bool _isValidSet;
        private readonly FieldInfo _field;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ClassInstanceFieldPointer(FieldInfo field)
        {
            _field = field;
            _isValidGet = REFieldInfo.ValidateInstanceFieldGet<TTarget, T>(field, out _pGetOffsetAddress);
            _isValidSet = REFieldInfo.ValidateInstanceFieldSet<TTarget, T>(field, out _pSetOffsetAddress);
            if (_isValidGet)
            {
                _pOffsetAddress = _pGetOffsetAddress;
            }
            else if (_isValidSet)
            {
                _pOffsetAddress = _pSetOffsetAddress;
            }
            else
            {
                _pOffsetAddress = 0;
            }
        }

        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ClassInstanceFieldPointer<TTarget, T>(FieldInfo field)
        {
            return new ClassInstanceFieldPointer<TTarget, T>(field);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public T GetValue(TTarget target)
        {
            bool isValid = _isValidGet;
            nint pOffsetAddress = _pGetOffsetAddress;
            if (!isValid)
            {
                isValid = pOffsetAddress != 0 && REFieldInfo.SecondaryValidateInstanceFieldGet<TTarget>(_field, target?.GetType(), ref pOffsetAddress);
                if (!isValid)
                {
                    return (T)_field.GetInstanceValueLowAlloc(target);
                }
            }

            unsafe
            {
                nint pTarget = Unsafe.As<TTarget, IntPtr>(ref target);
                void* fieldPtr = (void*)(pTarget + pOffsetAddress);
                return Unsafe.AsRef<T>(fieldPtr);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetValue(TTarget target, in T value)
        {
            bool isValid = _isValidSet;
            nint pOffsetAddress = _pSetOffsetAddress;
            if (!isValid)
            {
                isValid = pOffsetAddress != 0 && REFieldInfo.SecondaryValidateInstanceFieldSet<TTarget>(_field, target?.GetType(), value?.GetType(), ref pOffsetAddress);
                if (!isValid)
                {
                    _field.SetClassInstanceValueLowAlloc(target, value);
                    return;
                }
            }

            unsafe
            {
                nint pTarget = Unsafe.As<TTarget, IntPtr>(ref target);
                void* fieldPtr = (void*)(pTarget + pOffsetAddress);
                Unsafe.Write(fieldPtr, value);
            }
        }
    }

    public readonly struct StructInstanceFieldPointer<TTarget, T>
        where TTarget : struct
    {
        private readonly nint _pOffsetAddress;
        private readonly nint _pGetOffsetAddress;
        private readonly nint _pSetOffsetAddress;
        private readonly bool _isValidGet;
        private readonly bool _isValidSet;
        private readonly FieldInfo _field;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public StructInstanceFieldPointer(FieldInfo field)
        {
            _field = field;
            _isValidGet = REFieldInfo.ValidateInstanceFieldGet<TTarget, T>(field, out _pGetOffsetAddress);
            _isValidSet = REFieldInfo.ValidateInstanceFieldSet<TTarget, T>(field, out _pSetOffsetAddress);
            if (_isValidGet)
            {
                _pOffsetAddress = _pGetOffsetAddress;
            }
            else if (_isValidSet)
            {
                _pOffsetAddress = _pSetOffsetAddress;
            }
            else
            {
                _pOffsetAddress = 0;
            }
        }

        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator StructInstanceFieldPointer<TTarget, T>(FieldInfo field)
        {
            return new StructInstanceFieldPointer<TTarget, T>(field);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public T GetValue(ref TTarget target)
        {
            bool isValid = _isValidGet;
            nint pOffsetAddress = _pGetOffsetAddress;
            if (!isValid)
            {
                isValid = pOffsetAddress != 0 && REFieldInfo.SecondaryValidateInstanceFieldGet<TTarget>(_field, target.GetType(), ref pOffsetAddress);
                if (!isValid)
                {
                    return (T)_field.GetInstanceValueLowAlloc(target);
                }
            }

            unsafe
            {
                nint pTarget = (nint)Unsafe.AsPointer(ref target);
                void* fieldPtr = (void*)(pTarget + pOffsetAddress);
                return Unsafe.AsRef<T>(fieldPtr);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetValue(ref TTarget target, in T value)
        {
            bool isValid = _isValidSet;
            nint pOffsetAddress = _pSetOffsetAddress;
            if (!isValid)
            {
                isValid = pOffsetAddress != 0 && REFieldInfo.SecondaryValidateInstanceFieldSet<TTarget>(_field, target.GetType(), value?.GetType(), ref pOffsetAddress);
                if (!isValid)
                {
                    _field.SetInstanceValueLowAlloc(ref target, value);
                    return;
                }
            }

            unsafe
            {
                nint pTarget = (nint)Unsafe.AsPointer(ref target);
                void* fieldPtr = (void*)(pTarget + pOffsetAddress);
                Unsafe.Write(fieldPtr, value);
            }
        }
    }
    public readonly struct StaticFieldPointer<T>
    {
        private readonly nint _pAddress;
        private readonly nint _pGetAddress;
        private readonly nint _pSetAddress;
        private readonly bool _isValidGet;
        private readonly bool _isValidSet;
        private readonly FieldInfo _field;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public StaticFieldPointer(FieldInfo field)
        {
            _field = field;
            _isValidGet = REFieldInfo.ValidateStaticFieldGet<T>(field, out _pGetAddress);
            _isValidSet = REFieldInfo.ValidateStaticFieldSet<T>(field, out _pSetAddress);
            if (_isValidGet)
            {
                _pAddress = _pGetAddress;
            }
            else if (_isValidSet)
            {
                _pAddress = _pSetAddress;
            }
            else
            {
                _pAddress = 0;
            }
        }

        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator StaticFieldPointer<T>(FieldInfo field)
        {
            return new StaticFieldPointer<T>(field);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public T GetValue()
        {
            bool isValid = _isValidGet;
            if (!isValid)
            {
#if ENABLE_IL2CPP
                if (_pGetAddress == -1)
                {
                    unsafe
                    {
                        T result = default;
                        Utils.IL2CPPUtils.il2cpp_field_static_get_value(_field.FieldHandle.Value, Unsafe.AsPointer(ref result));
                        return result;
                    }
                }
#endif
                return (T)_field.GetValue(null);
            }

            unsafe
            {
                void* fieldPtr = (void*)_pGetAddress;
                return Unsafe.AsRef<T>(fieldPtr);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetValue(in T value)
        {
            bool isValid = _isValidSet;
            nint pAddress = _pSetAddress;
            if (!isValid)
            {
                isValid = pAddress != -1 && pAddress != 0 && REFieldInfo.SecondaryValidateStaticFieldSet(_field, value?.GetType(), ref pAddress);
                if (!isValid)
                {
#if ENABLE_IL2CPP
                    if (pAddress == -1)
                    {
                        unsafe
                        {
                            T v = value;
                            Utils.IL2CPPUtils.il2cpp_field_static_set_value(_field.FieldHandle.Value, Unsafe.AsPointer(ref v));
                            return;
                        }
                    }
#endif
                    _field.SetStaticValueLowAlloc(value);
                    return;
                }
            }

            unsafe
            {
                void* fieldPtr = (void*)pAddress;
                Unsafe.Write(fieldPtr, value);
            }
        }
    }
}

using Katuusagi.ConstExpressionForUnity;
using System;
using System.Reflection;
using System.Runtime.CompilerServices;
namespace Katuusagi.ReflectionEnhance
{
    public readonly struct InstanceMethodPointerAction<TTarget>
    {
        private readonly nint _pAddress;
        private readonly bool _isValid;
        private readonly MethodBase _method;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public InstanceMethodPointerAction(MethodBase method)
        {
            _method = method;
            if (method.IsOverridable())
            {
                _isValid = false;
                _pAddress = 0;
                return;
            }
            _isValid = REMethodBase.ValidateInstanceMethod<TTarget>(method, out _pAddress);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator InstanceMethodPointerAction<TTarget>(MethodBase method)
        {
            return new InstanceMethodPointerAction<TTarget>(method);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator InstanceMethodPointerAction<TTarget>(Action method)
        {
            return new InstanceMethodPointerAction<TTarget>(method.Method);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Invoke(ref TTarget target)
        {
            bool isValid = _isValid;
            nint pAddress = _pAddress;
            if (!isValid)
            {
                if (_method.IsOverridable())
                {
                    isValid = REMethodBase.ValidateInstanceVirtualMethod<TTarget>(_method, target?.GetType(), out pAddress);
                }
                else
                {
                    isValid = (pAddress != 0 && REMethodBase.SecondaryValidateInstanceMethod(_method, target?.GetType(), ref pAddress));
                }
                if (!isValid)
                {
                    _method.InvokeInstanceLowAlloc(ref target);
                    return;
                }
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
    }
    public readonly struct ClassInstanceMethodPointerAction<TTarget>
    where TTarget: class
    {
        private readonly nint _pAddress;
        private readonly bool _isValid;
        private readonly MethodBase _method;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ClassInstanceMethodPointerAction(MethodBase method)
        {
            _method = method;
            if (method.IsOverridable())
            {
                _isValid = false;
                _pAddress = 0;
                return;
            }
            _isValid = REMethodBase.ValidateInstanceMethod<TTarget>(method, out _pAddress);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ClassInstanceMethodPointerAction<TTarget>(MethodBase method)
        {
            return new ClassInstanceMethodPointerAction<TTarget>(method);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ClassInstanceMethodPointerAction<TTarget>(Action method)
        {
            return new ClassInstanceMethodPointerAction<TTarget>(method.Method);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Invoke(TTarget target)
        {
            bool isValid = _isValid;
            nint pAddress = _pAddress;
            if (!isValid)
            {
                if (_method.IsOverridable())
                {
                    isValid = REMethodBase.ValidateInstanceVirtualMethod<TTarget>(_method, target?.GetType(), out pAddress);
                }
                else
                {
                    isValid = (pAddress != 0 && REMethodBase.SecondaryValidateInstanceMethod(_method, target?.GetType(), ref pAddress));
                }
                if (!isValid)
                {
                    _method.InvokeClassInstanceLowAlloc(target);
                    return;
                }
            }
            unsafe
            {
                ((delegate*<TTarget, void>)pAddress)(target);
                return;
            }
        }
    }
    public readonly struct StructInstanceMethodPointerAction<TTarget>
    where TTarget: struct
    {
        private readonly nint _pAddress;
        private readonly bool _isValid;
        private readonly MethodBase _method;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public StructInstanceMethodPointerAction(MethodBase method)
        {
            _method = method;
            if (method.IsOverridable())
            {
                _isValid = false;
                _pAddress = 0;
                return;
            }
            _isValid = REMethodBase.ValidateInstanceMethod<TTarget>(method, out _pAddress);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator StructInstanceMethodPointerAction<TTarget>(MethodBase method)
        {
            return new StructInstanceMethodPointerAction<TTarget>(method);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator StructInstanceMethodPointerAction<TTarget>(Action method)
        {
            return new StructInstanceMethodPointerAction<TTarget>(method.Method);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Invoke(ref TTarget target)
        {
            bool isValid = _isValid;
            nint pAddress = _pAddress;
            if (!isValid)
            {
                if (_method.IsOverridable())
                {
                    isValid = REMethodBase.ValidateInstanceVirtualMethod<TTarget>(_method, target.GetType(), out pAddress);
                }
                else
                {
                    isValid = (pAddress != 0 && REMethodBase.SecondaryValidateInstanceMethod(_method, target.GetType(), ref pAddress));
                }
                if (!isValid)
                {
                    _method.InvokeInstanceLowAlloc(ref target);
                    return;
                }
            }
            unsafe
            {
                ((delegate*<ref TTarget, void>)pAddress)(ref target);
                return;
            }
        }
    }
    public readonly struct InstanceMethodPointerFunc<TTarget, TReturn>
    {
        private readonly nint _pAddress;
        private readonly bool _isValid;
        private readonly MethodBase _method;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public InstanceMethodPointerFunc(MethodBase method)
        {
            _method = method;
            if (method.IsOverridable())
            {
                _isValid = false;
                _pAddress = 0;
                return;
            }
            _isValid = REMethodBase.ValidateInstanceReturnableMethod<TTarget, TReturn>(method, out _pAddress);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator InstanceMethodPointerFunc<TTarget, TReturn>(MethodBase method)
        {
            return new InstanceMethodPointerFunc<TTarget, TReturn>(method);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator InstanceMethodPointerFunc<TTarget, TReturn>(Func<TReturn> method)
        {
            return new InstanceMethodPointerFunc<TTarget, TReturn>(method.Method);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TReturn Invoke(ref TTarget target)
        {
            bool isValid = _isValid;
            nint pAddress = _pAddress;
            if (!isValid)
            {
                if (_method.IsOverridable())
                {
                    isValid = REMethodBase.ValidateInstanceReturnableVirtualMethod<TTarget, TReturn>(_method, target?.GetType(), out pAddress);
                }
                else
                {
                    isValid = (pAddress != 0 && REMethodBase.SecondaryValidateInstanceMethod(_method, target?.GetType(), ref pAddress));
                }
                if (!isValid)
                {
                    return (TReturn)_method.InvokeInstanceLowAlloc(ref target);
                }
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
    }
    public readonly struct ClassInstanceMethodPointerFunc<TTarget, TReturn>
    where TTarget: class
    {
        private readonly nint _pAddress;
        private readonly bool _isValid;
        private readonly MethodBase _method;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ClassInstanceMethodPointerFunc(MethodBase method)
        {
            _method = method;
            if (method.IsOverridable())
            {
                _isValid = false;
                _pAddress = 0;
                return;
            }
            _isValid = REMethodBase.ValidateInstanceReturnableMethod<TTarget, TReturn>(method, out _pAddress);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ClassInstanceMethodPointerFunc<TTarget, TReturn>(MethodBase method)
        {
            return new ClassInstanceMethodPointerFunc<TTarget, TReturn>(method);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ClassInstanceMethodPointerFunc<TTarget, TReturn>(Func<TReturn> method)
        {
            return new ClassInstanceMethodPointerFunc<TTarget, TReturn>(method.Method);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TReturn Invoke(TTarget target)
        {
            bool isValid = _isValid;
            nint pAddress = _pAddress;
            if (!isValid)
            {
                if (_method.IsOverridable())
                {
                    isValid = REMethodBase.ValidateInstanceReturnableVirtualMethod<TTarget, TReturn>(_method, target?.GetType(), out pAddress);
                }
                else
                {
                    isValid = (pAddress != 0 && REMethodBase.SecondaryValidateInstanceMethod(_method, target?.GetType(), ref pAddress));
                }
                if (!isValid)
                {
                    return (TReturn)_method.InvokeClassInstanceLowAlloc(target);
                }
            }
            unsafe
            {
                return ((delegate*<TTarget, TReturn>)pAddress)(target);
            }
        }
    }
    public readonly struct StructInstanceMethodPointerFunc<TTarget, TReturn>
    where TTarget: struct
    {
        private readonly nint _pAddress;
        private readonly bool _isValid;
        private readonly MethodBase _method;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public StructInstanceMethodPointerFunc(MethodBase method)
        {
            _method = method;
            if (method.IsOverridable())
            {
                _isValid = false;
                _pAddress = 0;
                return;
            }
            _isValid = REMethodBase.ValidateInstanceReturnableMethod<TTarget, TReturn>(method, out _pAddress);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator StructInstanceMethodPointerFunc<TTarget, TReturn>(MethodBase method)
        {
            return new StructInstanceMethodPointerFunc<TTarget, TReturn>(method);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator StructInstanceMethodPointerFunc<TTarget, TReturn>(Func<TReturn> method)
        {
            return new StructInstanceMethodPointerFunc<TTarget, TReturn>(method.Method);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TReturn Invoke(ref TTarget target)
        {
            bool isValid = _isValid;
            nint pAddress = _pAddress;
            if (!isValid)
            {
                if (_method.IsOverridable())
                {
                    isValid = REMethodBase.ValidateInstanceReturnableVirtualMethod<TTarget, TReturn>(_method, target.GetType(), out pAddress);
                }
                else
                {
                    isValid = (pAddress != 0 && REMethodBase.SecondaryValidateInstanceMethod(_method, target.GetType(), ref pAddress));
                }
                if (!isValid)
                {
                    return (TReturn)_method.InvokeInstanceLowAlloc(ref target);
                }
            }
            unsafe
            {
                return ((delegate*<ref TTarget, TReturn>)pAddress)(ref target);
            }
        }
    }
    public readonly struct StaticMethodPointerAction
    {
        private readonly nint _pAddress;
        private readonly bool _isValid;
        private readonly MethodBase _method;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public StaticMethodPointerAction(MethodBase method)
        {
            _method = method;
            if (method.IsOverridable())
            {
                _isValid = false;
                _pAddress = 0;
                return;
            }
            _isValid = REMethodBase.ValidateStaticMethod(method, out _pAddress);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator StaticMethodPointerAction(MethodBase method)
        {
            return new StaticMethodPointerAction(method);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator StaticMethodPointerAction(Action method)
        {
            return new StaticMethodPointerAction(method.Method);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Invoke()
        {
            bool isValid = _isValid;
            nint pAddress = _pAddress;
            if (!isValid)
            {
                _method.InvokeStaticLowAlloc();
                return;
            }
            unsafe
            {
                ((delegate*<void>)pAddress)();
                return;
            }
        }
    }
    public readonly struct StaticMethodPointerFunc<TReturn>
    {
        private readonly nint _pAddress;
        private readonly bool _isValid;
        private readonly MethodBase _method;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public StaticMethodPointerFunc(MethodBase method)
        {
            _method = method;
            if (method.IsOverridable())
            {
                _isValid = false;
                _pAddress = 0;
                return;
            }
            _isValid = REMethodBase.ValidateStaticReturnableMethod<TReturn>(method, out _pAddress);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator StaticMethodPointerFunc<TReturn>(MethodBase method)
        {
            return new StaticMethodPointerFunc<TReturn>(method);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator StaticMethodPointerFunc<TReturn>(Func<TReturn> method)
        {
            return new StaticMethodPointerFunc<TReturn>(method.Method);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TReturn Invoke()
        {
            bool isValid = _isValid;
            nint pAddress = _pAddress;
            if (!isValid)
            {
                return (TReturn)_method.InvokeStaticLowAlloc();
            }
            unsafe
            {
                return ((delegate*<TReturn>)pAddress)();
            }
        }
    }
    public readonly struct InstanceMethodPointerAction<TTarget, TArg0>
    {
        private readonly nint _pAddress;
        private readonly bool _isValid;
        private readonly MethodBase _method;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public InstanceMethodPointerAction(MethodBase method)
        {
            _method = method;
            if (method.IsOverridable())
            {
                _isValid = false;
                _pAddress = 0;
                return;
            }
            _isValid = REMethodBase.ValidateInstanceMethod<TTarget, TArg0>(method, out _pAddress);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator InstanceMethodPointerAction<TTarget, TArg0>(MethodBase method)
        {
            return new InstanceMethodPointerAction<TTarget, TArg0>(method);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator InstanceMethodPointerAction<TTarget, TArg0>(Action<TArg0> method)
        {
            return new InstanceMethodPointerAction<TTarget, TArg0>(method.Method);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Invoke(ref TTarget target, in TArg0 arg0)
        {
            bool isValid = _isValid;
            nint pAddress = _pAddress;
            if (!isValid)
            {
                if (_method.IsOverridable())
                {
                    isValid = REMethodBase.ValidateInstanceVirtualMethod<TTarget, TArg0>(_method, target?.GetType(), out pAddress) ||
                              (pAddress != 0 && REMethodBase.SecondaryValidateStaticMethod(_method, arg0?.GetType(), ref pAddress));
                }
                else
                {
                    isValid = (pAddress != 0 && REMethodBase.SecondaryValidateInstanceMethod(_method, target?.GetType(), arg0?.GetType(), ref pAddress));
                }
                if (!isValid)
                {
                    _method.InvokeInstanceLowAlloc(ref target, arg0);
                    return;
                }
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
    }
    public readonly struct ClassInstanceMethodPointerAction<TTarget, TArg0>
    where TTarget: class
    {
        private readonly nint _pAddress;
        private readonly bool _isValid;
        private readonly MethodBase _method;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ClassInstanceMethodPointerAction(MethodBase method)
        {
            _method = method;
            if (method.IsOverridable())
            {
                _isValid = false;
                _pAddress = 0;
                return;
            }
            _isValid = REMethodBase.ValidateInstanceMethod<TTarget, TArg0>(method, out _pAddress);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ClassInstanceMethodPointerAction<TTarget, TArg0>(MethodBase method)
        {
            return new ClassInstanceMethodPointerAction<TTarget, TArg0>(method);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ClassInstanceMethodPointerAction<TTarget, TArg0>(Action<TArg0> method)
        {
            return new ClassInstanceMethodPointerAction<TTarget, TArg0>(method.Method);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Invoke(TTarget target, in TArg0 arg0)
        {
            bool isValid = _isValid;
            nint pAddress = _pAddress;
            if (!isValid)
            {
                if (_method.IsOverridable())
                {
                    isValid = REMethodBase.ValidateInstanceVirtualMethod<TTarget, TArg0>(_method, target?.GetType(), out pAddress) ||
                              (pAddress != 0 && REMethodBase.SecondaryValidateStaticMethod(_method, arg0?.GetType(), ref pAddress));
                }
                else
                {
                    isValid = (pAddress != 0 && REMethodBase.SecondaryValidateInstanceMethod(_method, target?.GetType(), arg0?.GetType(), ref pAddress));
                }
                if (!isValid)
                {
                    _method.InvokeClassInstanceLowAlloc(target, arg0);
                    return;
                }
            }
            unsafe
            {
                ((delegate*<TTarget, TArg0, void>)pAddress)(target, arg0);
                return;
            }
        }
    }
    public readonly struct StructInstanceMethodPointerAction<TTarget, TArg0>
    where TTarget: struct
    {
        private readonly nint _pAddress;
        private readonly bool _isValid;
        private readonly MethodBase _method;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public StructInstanceMethodPointerAction(MethodBase method)
        {
            _method = method;
            if (method.IsOverridable())
            {
                _isValid = false;
                _pAddress = 0;
                return;
            }
            _isValid = REMethodBase.ValidateInstanceMethod<TTarget, TArg0>(method, out _pAddress);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator StructInstanceMethodPointerAction<TTarget, TArg0>(MethodBase method)
        {
            return new StructInstanceMethodPointerAction<TTarget, TArg0>(method);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator StructInstanceMethodPointerAction<TTarget, TArg0>(Action<TArg0> method)
        {
            return new StructInstanceMethodPointerAction<TTarget, TArg0>(method.Method);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Invoke(ref TTarget target, in TArg0 arg0)
        {
            bool isValid = _isValid;
            nint pAddress = _pAddress;
            if (!isValid)
            {
                if (_method.IsOverridable())
                {
                    isValid = REMethodBase.ValidateInstanceVirtualMethod<TTarget, TArg0>(_method, target.GetType(), out pAddress) ||
                              (pAddress != 0 && REMethodBase.SecondaryValidateStaticMethod(_method, arg0?.GetType(), ref pAddress));
                }
                else
                {
                    isValid = (pAddress != 0 && REMethodBase.SecondaryValidateInstanceMethod(_method, target.GetType(), arg0?.GetType(), ref pAddress));
                }
                if (!isValid)
                {
                    _method.InvokeInstanceLowAlloc(ref target, arg0);
                    return;
                }
            }
            unsafe
            {
                ((delegate*<ref TTarget, TArg0, void>)pAddress)(ref target, arg0);
                return;
            }
        }
    }
    public readonly struct InstanceMethodPointerFunc<TTarget, TArg0, TReturn>
    {
        private readonly nint _pAddress;
        private readonly bool _isValid;
        private readonly MethodBase _method;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public InstanceMethodPointerFunc(MethodBase method)
        {
            _method = method;
            if (method.IsOverridable())
            {
                _isValid = false;
                _pAddress = 0;
                return;
            }
            _isValid = REMethodBase.ValidateInstanceReturnableMethod<TTarget, TArg0, TReturn>(method, out _pAddress);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator InstanceMethodPointerFunc<TTarget, TArg0, TReturn>(MethodBase method)
        {
            return new InstanceMethodPointerFunc<TTarget, TArg0, TReturn>(method);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator InstanceMethodPointerFunc<TTarget, TArg0, TReturn>(Func<TArg0, TReturn> method)
        {
            return new InstanceMethodPointerFunc<TTarget, TArg0, TReturn>(method.Method);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TReturn Invoke(ref TTarget target, in TArg0 arg0)
        {
            bool isValid = _isValid;
            nint pAddress = _pAddress;
            if (!isValid)
            {
                if (_method.IsOverridable())
                {
                    isValid = REMethodBase.ValidateInstanceReturnableVirtualMethod<TTarget, TArg0, TReturn>(_method, target?.GetType(), out pAddress) ||
                              (pAddress != 0 && REMethodBase.SecondaryValidateStaticMethod(_method, arg0?.GetType(), ref pAddress));
                }
                else
                {
                    isValid = (pAddress != 0 && REMethodBase.SecondaryValidateInstanceMethod(_method, target?.GetType(), arg0?.GetType(), ref pAddress));
                }
                if (!isValid)
                {
                    return (TReturn)_method.InvokeInstanceLowAlloc(ref target, arg0);
                }
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
    }
    public readonly struct ClassInstanceMethodPointerFunc<TTarget, TArg0, TReturn>
    where TTarget: class
    {
        private readonly nint _pAddress;
        private readonly bool _isValid;
        private readonly MethodBase _method;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ClassInstanceMethodPointerFunc(MethodBase method)
        {
            _method = method;
            if (method.IsOverridable())
            {
                _isValid = false;
                _pAddress = 0;
                return;
            }
            _isValid = REMethodBase.ValidateInstanceReturnableMethod<TTarget, TArg0, TReturn>(method, out _pAddress);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ClassInstanceMethodPointerFunc<TTarget, TArg0, TReturn>(MethodBase method)
        {
            return new ClassInstanceMethodPointerFunc<TTarget, TArg0, TReturn>(method);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ClassInstanceMethodPointerFunc<TTarget, TArg0, TReturn>(Func<TArg0, TReturn> method)
        {
            return new ClassInstanceMethodPointerFunc<TTarget, TArg0, TReturn>(method.Method);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TReturn Invoke(TTarget target, in TArg0 arg0)
        {
            bool isValid = _isValid;
            nint pAddress = _pAddress;
            if (!isValid)
            {
                if (_method.IsOverridable())
                {
                    isValid = REMethodBase.ValidateInstanceReturnableVirtualMethod<TTarget, TArg0, TReturn>(_method, target?.GetType(), out pAddress) ||
                              (pAddress != 0 && REMethodBase.SecondaryValidateStaticMethod(_method, arg0?.GetType(), ref pAddress));
                }
                else
                {
                    isValid = (pAddress != 0 && REMethodBase.SecondaryValidateInstanceMethod(_method, target?.GetType(), arg0?.GetType(), ref pAddress));
                }
                if (!isValid)
                {
                    return (TReturn)_method.InvokeClassInstanceLowAlloc(target, arg0);
                }
            }
            unsafe
            {
                return ((delegate*<TTarget, TArg0, TReturn>)pAddress)(target, arg0);
            }
        }
    }
    public readonly struct StructInstanceMethodPointerFunc<TTarget, TArg0, TReturn>
    where TTarget: struct
    {
        private readonly nint _pAddress;
        private readonly bool _isValid;
        private readonly MethodBase _method;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public StructInstanceMethodPointerFunc(MethodBase method)
        {
            _method = method;
            if (method.IsOverridable())
            {
                _isValid = false;
                _pAddress = 0;
                return;
            }
            _isValid = REMethodBase.ValidateInstanceReturnableMethod<TTarget, TArg0, TReturn>(method, out _pAddress);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator StructInstanceMethodPointerFunc<TTarget, TArg0, TReturn>(MethodBase method)
        {
            return new StructInstanceMethodPointerFunc<TTarget, TArg0, TReturn>(method);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator StructInstanceMethodPointerFunc<TTarget, TArg0, TReturn>(Func<TArg0, TReturn> method)
        {
            return new StructInstanceMethodPointerFunc<TTarget, TArg0, TReturn>(method.Method);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TReturn Invoke(ref TTarget target, in TArg0 arg0)
        {
            bool isValid = _isValid;
            nint pAddress = _pAddress;
            if (!isValid)
            {
                if (_method.IsOverridable())
                {
                    isValid = REMethodBase.ValidateInstanceReturnableVirtualMethod<TTarget, TArg0, TReturn>(_method, target.GetType(), out pAddress) ||
                              (pAddress != 0 && REMethodBase.SecondaryValidateStaticMethod(_method, arg0?.GetType(), ref pAddress));
                }
                else
                {
                    isValid = (pAddress != 0 && REMethodBase.SecondaryValidateInstanceMethod(_method, target.GetType(), arg0?.GetType(), ref pAddress));
                }
                if (!isValid)
                {
                    return (TReturn)_method.InvokeInstanceLowAlloc(ref target, arg0);
                }
            }
            unsafe
            {
                return ((delegate*<ref TTarget, TArg0, TReturn>)pAddress)(ref target, arg0);
            }
        }
    }
    public readonly struct StaticMethodPointerAction<TArg0>
    {
        private readonly nint _pAddress;
        private readonly bool _isValid;
        private readonly MethodBase _method;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public StaticMethodPointerAction(MethodBase method)
        {
            _method = method;
            if (method.IsOverridable())
            {
                _isValid = false;
                _pAddress = 0;
                return;
            }
            _isValid = REMethodBase.ValidateStaticMethod<TArg0>(method, out _pAddress);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator StaticMethodPointerAction<TArg0>(MethodBase method)
        {
            return new StaticMethodPointerAction<TArg0>(method);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator StaticMethodPointerAction<TArg0>(Action<TArg0> method)
        {
            return new StaticMethodPointerAction<TArg0>(method.Method);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Invoke(in TArg0 arg0)
        {
            bool isValid = _isValid;
            nint pAddress = _pAddress;
            if (!isValid)
            {
                isValid = (pAddress != 0 && REMethodBase.SecondaryValidateStaticMethod(_method, arg0?.GetType(), ref pAddress));
                if (!isValid)
                {
                    _method.InvokeStaticLowAlloc(arg0);
                    return;
                }
            }
            unsafe
            {
                ((delegate*<TArg0, void>)pAddress)(arg0);
                return;
            }
        }
    }
    public readonly struct StaticMethodPointerFunc<TArg0, TReturn>
    {
        private readonly nint _pAddress;
        private readonly bool _isValid;
        private readonly MethodBase _method;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public StaticMethodPointerFunc(MethodBase method)
        {
            _method = method;
            if (method.IsOverridable())
            {
                _isValid = false;
                _pAddress = 0;
                return;
            }
            _isValid = REMethodBase.ValidateStaticReturnableMethod<TArg0, TReturn>(method, out _pAddress);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator StaticMethodPointerFunc<TArg0, TReturn>(MethodBase method)
        {
            return new StaticMethodPointerFunc<TArg0, TReturn>(method);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator StaticMethodPointerFunc<TArg0, TReturn>(Func<TArg0, TReturn> method)
        {
            return new StaticMethodPointerFunc<TArg0, TReturn>(method.Method);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TReturn Invoke(in TArg0 arg0)
        {
            bool isValid = _isValid;
            nint pAddress = _pAddress;
            if (!isValid)
            {
                isValid = (pAddress != 0 && REMethodBase.SecondaryValidateStaticMethod(_method, arg0?.GetType(), ref pAddress));
                if (!isValid)
                {
                    return (TReturn)_method.InvokeStaticLowAlloc(arg0);
                }
            }
            unsafe
            {
                return ((delegate*<TArg0, TReturn>)pAddress)(arg0);
            }
        }
    }
    public readonly struct InstanceMethodPointerAction<TTarget, TArg0, TArg1>
    {
        private readonly nint _pAddress;
        private readonly bool _isValid;
        private readonly MethodBase _method;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public InstanceMethodPointerAction(MethodBase method)
        {
            _method = method;
            if (method.IsOverridable())
            {
                _isValid = false;
                _pAddress = 0;
                return;
            }
            _isValid = REMethodBase.ValidateInstanceMethod<TTarget, TArg0, TArg1>(method, out _pAddress);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator InstanceMethodPointerAction<TTarget, TArg0, TArg1>(MethodBase method)
        {
            return new InstanceMethodPointerAction<TTarget, TArg0, TArg1>(method);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator InstanceMethodPointerAction<TTarget, TArg0, TArg1>(Action<TArg0, TArg1> method)
        {
            return new InstanceMethodPointerAction<TTarget, TArg0, TArg1>(method.Method);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Invoke(ref TTarget target, in TArg0 arg0, in TArg1 arg1)
        {
            bool isValid = _isValid;
            nint pAddress = _pAddress;
            if (!isValid)
            {
                if (_method.IsOverridable())
                {
                    isValid = REMethodBase.ValidateInstanceVirtualMethod<TTarget, TArg0, TArg1>(_method, target?.GetType(), out pAddress) ||
                              (pAddress != 0 && REMethodBase.SecondaryValidateStaticMethod(_method, arg0?.GetType(), arg1?.GetType(), ref pAddress));
                }
                else
                {
                    isValid = (pAddress != 0 && REMethodBase.SecondaryValidateInstanceMethod(_method, target?.GetType(), arg0?.GetType(), arg1?.GetType(), ref pAddress));
                }
                if (!isValid)
                {
                    _method.InvokeInstanceLowAlloc(ref target, arg0, arg1);
                    return;
                }
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
    }
    public readonly struct ClassInstanceMethodPointerAction<TTarget, TArg0, TArg1>
    where TTarget: class
    {
        private readonly nint _pAddress;
        private readonly bool _isValid;
        private readonly MethodBase _method;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ClassInstanceMethodPointerAction(MethodBase method)
        {
            _method = method;
            if (method.IsOverridable())
            {
                _isValid = false;
                _pAddress = 0;
                return;
            }
            _isValid = REMethodBase.ValidateInstanceMethod<TTarget, TArg0, TArg1>(method, out _pAddress);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ClassInstanceMethodPointerAction<TTarget, TArg0, TArg1>(MethodBase method)
        {
            return new ClassInstanceMethodPointerAction<TTarget, TArg0, TArg1>(method);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ClassInstanceMethodPointerAction<TTarget, TArg0, TArg1>(Action<TArg0, TArg1> method)
        {
            return new ClassInstanceMethodPointerAction<TTarget, TArg0, TArg1>(method.Method);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Invoke(TTarget target, in TArg0 arg0, in TArg1 arg1)
        {
            bool isValid = _isValid;
            nint pAddress = _pAddress;
            if (!isValid)
            {
                if (_method.IsOverridable())
                {
                    isValid = REMethodBase.ValidateInstanceVirtualMethod<TTarget, TArg0, TArg1>(_method, target?.GetType(), out pAddress) ||
                              (pAddress != 0 && REMethodBase.SecondaryValidateStaticMethod(_method, arg0?.GetType(), arg1?.GetType(), ref pAddress));
                }
                else
                {
                    isValid = (pAddress != 0 && REMethodBase.SecondaryValidateInstanceMethod(_method, target?.GetType(), arg0?.GetType(), arg1?.GetType(), ref pAddress));
                }
                if (!isValid)
                {
                    _method.InvokeClassInstanceLowAlloc(target, arg0, arg1);
                    return;
                }
            }
            unsafe
            {
                ((delegate*<TTarget, TArg0, TArg1, void>)pAddress)(target, arg0, arg1);
                return;
            }
        }
    }
    public readonly struct StructInstanceMethodPointerAction<TTarget, TArg0, TArg1>
    where TTarget: struct
    {
        private readonly nint _pAddress;
        private readonly bool _isValid;
        private readonly MethodBase _method;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public StructInstanceMethodPointerAction(MethodBase method)
        {
            _method = method;
            if (method.IsOverridable())
            {
                _isValid = false;
                _pAddress = 0;
                return;
            }
            _isValid = REMethodBase.ValidateInstanceMethod<TTarget, TArg0, TArg1>(method, out _pAddress);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator StructInstanceMethodPointerAction<TTarget, TArg0, TArg1>(MethodBase method)
        {
            return new StructInstanceMethodPointerAction<TTarget, TArg0, TArg1>(method);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator StructInstanceMethodPointerAction<TTarget, TArg0, TArg1>(Action<TArg0, TArg1> method)
        {
            return new StructInstanceMethodPointerAction<TTarget, TArg0, TArg1>(method.Method);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Invoke(ref TTarget target, in TArg0 arg0, in TArg1 arg1)
        {
            bool isValid = _isValid;
            nint pAddress = _pAddress;
            if (!isValid)
            {
                if (_method.IsOverridable())
                {
                    isValid = REMethodBase.ValidateInstanceVirtualMethod<TTarget, TArg0, TArg1>(_method, target.GetType(), out pAddress) ||
                              (pAddress != 0 && REMethodBase.SecondaryValidateStaticMethod(_method, arg0?.GetType(), arg1?.GetType(), ref pAddress));
                }
                else
                {
                    isValid = (pAddress != 0 && REMethodBase.SecondaryValidateInstanceMethod(_method, target.GetType(), arg0?.GetType(), arg1?.GetType(), ref pAddress));
                }
                if (!isValid)
                {
                    _method.InvokeInstanceLowAlloc(ref target, arg0, arg1);
                    return;
                }
            }
            unsafe
            {
                ((delegate*<ref TTarget, TArg0, TArg1, void>)pAddress)(ref target, arg0, arg1);
                return;
            }
        }
    }
    public readonly struct InstanceMethodPointerFunc<TTarget, TArg0, TArg1, TReturn>
    {
        private readonly nint _pAddress;
        private readonly bool _isValid;
        private readonly MethodBase _method;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public InstanceMethodPointerFunc(MethodBase method)
        {
            _method = method;
            if (method.IsOverridable())
            {
                _isValid = false;
                _pAddress = 0;
                return;
            }
            _isValid = REMethodBase.ValidateInstanceReturnableMethod<TTarget, TArg0, TArg1, TReturn>(method, out _pAddress);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator InstanceMethodPointerFunc<TTarget, TArg0, TArg1, TReturn>(MethodBase method)
        {
            return new InstanceMethodPointerFunc<TTarget, TArg0, TArg1, TReturn>(method);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator InstanceMethodPointerFunc<TTarget, TArg0, TArg1, TReturn>(Func<TArg0, TArg1, TReturn> method)
        {
            return new InstanceMethodPointerFunc<TTarget, TArg0, TArg1, TReturn>(method.Method);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TReturn Invoke(ref TTarget target, in TArg0 arg0, in TArg1 arg1)
        {
            bool isValid = _isValid;
            nint pAddress = _pAddress;
            if (!isValid)
            {
                if (_method.IsOverridable())
                {
                    isValid = REMethodBase.ValidateInstanceReturnableVirtualMethod<TTarget, TArg0, TArg1, TReturn>(_method, target?.GetType(), out pAddress) ||
                              (pAddress != 0 && REMethodBase.SecondaryValidateStaticMethod(_method, arg0?.GetType(), arg1?.GetType(), ref pAddress));
                }
                else
                {
                    isValid = (pAddress != 0 && REMethodBase.SecondaryValidateInstanceMethod(_method, target?.GetType(), arg0?.GetType(), arg1?.GetType(), ref pAddress));
                }
                if (!isValid)
                {
                    return (TReturn)_method.InvokeInstanceLowAlloc(ref target, arg0, arg1);
                }
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
    }
    public readonly struct ClassInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TReturn>
    where TTarget: class
    {
        private readonly nint _pAddress;
        private readonly bool _isValid;
        private readonly MethodBase _method;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ClassInstanceMethodPointerFunc(MethodBase method)
        {
            _method = method;
            if (method.IsOverridable())
            {
                _isValid = false;
                _pAddress = 0;
                return;
            }
            _isValid = REMethodBase.ValidateInstanceReturnableMethod<TTarget, TArg0, TArg1, TReturn>(method, out _pAddress);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ClassInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TReturn>(MethodBase method)
        {
            return new ClassInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TReturn>(method);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ClassInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TReturn>(Func<TArg0, TArg1, TReturn> method)
        {
            return new ClassInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TReturn>(method.Method);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TReturn Invoke(TTarget target, in TArg0 arg0, in TArg1 arg1)
        {
            bool isValid = _isValid;
            nint pAddress = _pAddress;
            if (!isValid)
            {
                if (_method.IsOverridable())
                {
                    isValid = REMethodBase.ValidateInstanceReturnableVirtualMethod<TTarget, TArg0, TArg1, TReturn>(_method, target?.GetType(), out pAddress) ||
                              (pAddress != 0 && REMethodBase.SecondaryValidateStaticMethod(_method, arg0?.GetType(), arg1?.GetType(), ref pAddress));
                }
                else
                {
                    isValid = (pAddress != 0 && REMethodBase.SecondaryValidateInstanceMethod(_method, target?.GetType(), arg0?.GetType(), arg1?.GetType(), ref pAddress));
                }
                if (!isValid)
                {
                    return (TReturn)_method.InvokeClassInstanceLowAlloc(target, arg0, arg1);
                }
            }
            unsafe
            {
                return ((delegate*<TTarget, TArg0, TArg1, TReturn>)pAddress)(target, arg0, arg1);
            }
        }
    }
    public readonly struct StructInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TReturn>
    where TTarget: struct
    {
        private readonly nint _pAddress;
        private readonly bool _isValid;
        private readonly MethodBase _method;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public StructInstanceMethodPointerFunc(MethodBase method)
        {
            _method = method;
            if (method.IsOverridable())
            {
                _isValid = false;
                _pAddress = 0;
                return;
            }
            _isValid = REMethodBase.ValidateInstanceReturnableMethod<TTarget, TArg0, TArg1, TReturn>(method, out _pAddress);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator StructInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TReturn>(MethodBase method)
        {
            return new StructInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TReturn>(method);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator StructInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TReturn>(Func<TArg0, TArg1, TReturn> method)
        {
            return new StructInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TReturn>(method.Method);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TReturn Invoke(ref TTarget target, in TArg0 arg0, in TArg1 arg1)
        {
            bool isValid = _isValid;
            nint pAddress = _pAddress;
            if (!isValid)
            {
                if (_method.IsOverridable())
                {
                    isValid = REMethodBase.ValidateInstanceReturnableVirtualMethod<TTarget, TArg0, TArg1, TReturn>(_method, target.GetType(), out pAddress) ||
                              (pAddress != 0 && REMethodBase.SecondaryValidateStaticMethod(_method, arg0?.GetType(), arg1?.GetType(), ref pAddress));
                }
                else
                {
                    isValid = (pAddress != 0 && REMethodBase.SecondaryValidateInstanceMethod(_method, target.GetType(), arg0?.GetType(), arg1?.GetType(), ref pAddress));
                }
                if (!isValid)
                {
                    return (TReturn)_method.InvokeInstanceLowAlloc(ref target, arg0, arg1);
                }
            }
            unsafe
            {
                return ((delegate*<ref TTarget, TArg0, TArg1, TReturn>)pAddress)(ref target, arg0, arg1);
            }
        }
    }
    public readonly struct StaticMethodPointerAction<TArg0, TArg1>
    {
        private readonly nint _pAddress;
        private readonly bool _isValid;
        private readonly MethodBase _method;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public StaticMethodPointerAction(MethodBase method)
        {
            _method = method;
            if (method.IsOverridable())
            {
                _isValid = false;
                _pAddress = 0;
                return;
            }
            _isValid = REMethodBase.ValidateStaticMethod<TArg0, TArg1>(method, out _pAddress);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator StaticMethodPointerAction<TArg0, TArg1>(MethodBase method)
        {
            return new StaticMethodPointerAction<TArg0, TArg1>(method);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator StaticMethodPointerAction<TArg0, TArg1>(Action<TArg0, TArg1> method)
        {
            return new StaticMethodPointerAction<TArg0, TArg1>(method.Method);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Invoke(in TArg0 arg0, in TArg1 arg1)
        {
            bool isValid = _isValid;
            nint pAddress = _pAddress;
            if (!isValid)
            {
                isValid = (pAddress != 0 && REMethodBase.SecondaryValidateStaticMethod(_method, arg0?.GetType(), arg1?.GetType(), ref pAddress));
                if (!isValid)
                {
                    _method.InvokeStaticLowAlloc(arg0, arg1);
                    return;
                }
            }
            unsafe
            {
                ((delegate*<TArg0, TArg1, void>)pAddress)(arg0, arg1);
                return;
            }
        }
    }
    public readonly struct StaticMethodPointerFunc<TArg0, TArg1, TReturn>
    {
        private readonly nint _pAddress;
        private readonly bool _isValid;
        private readonly MethodBase _method;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public StaticMethodPointerFunc(MethodBase method)
        {
            _method = method;
            if (method.IsOverridable())
            {
                _isValid = false;
                _pAddress = 0;
                return;
            }
            _isValid = REMethodBase.ValidateStaticReturnableMethod<TArg0, TArg1, TReturn>(method, out _pAddress);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator StaticMethodPointerFunc<TArg0, TArg1, TReturn>(MethodBase method)
        {
            return new StaticMethodPointerFunc<TArg0, TArg1, TReturn>(method);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator StaticMethodPointerFunc<TArg0, TArg1, TReturn>(Func<TArg0, TArg1, TReturn> method)
        {
            return new StaticMethodPointerFunc<TArg0, TArg1, TReturn>(method.Method);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TReturn Invoke(in TArg0 arg0, in TArg1 arg1)
        {
            bool isValid = _isValid;
            nint pAddress = _pAddress;
            if (!isValid)
            {
                isValid = (pAddress != 0 && REMethodBase.SecondaryValidateStaticMethod(_method, arg0?.GetType(), arg1?.GetType(), ref pAddress));
                if (!isValid)
                {
                    return (TReturn)_method.InvokeStaticLowAlloc(arg0, arg1);
                }
            }
            unsafe
            {
                return ((delegate*<TArg0, TArg1, TReturn>)pAddress)(arg0, arg1);
            }
        }
    }
    public readonly struct InstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2>
    {
        private readonly nint _pAddress;
        private readonly bool _isValid;
        private readonly MethodBase _method;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public InstanceMethodPointerAction(MethodBase method)
        {
            _method = method;
            if (method.IsOverridable())
            {
                _isValid = false;
                _pAddress = 0;
                return;
            }
            _isValid = REMethodBase.ValidateInstanceMethod<TTarget, TArg0, TArg1, TArg2>(method, out _pAddress);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator InstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2>(MethodBase method)
        {
            return new InstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2>(method);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator InstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2>(Action<TArg0, TArg1, TArg2> method)
        {
            return new InstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2>(method.Method);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Invoke(ref TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2)
        {
            bool isValid = _isValid;
            nint pAddress = _pAddress;
            if (!isValid)
            {
                if (_method.IsOverridable())
                {
                    isValid = REMethodBase.ValidateInstanceVirtualMethod<TTarget, TArg0, TArg1, TArg2>(_method, target?.GetType(), out pAddress) ||
                              (pAddress != 0 && REMethodBase.SecondaryValidateStaticMethod(_method, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), ref pAddress));
                }
                else
                {
                    isValid = (pAddress != 0 && REMethodBase.SecondaryValidateInstanceMethod(_method, target?.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), ref pAddress));
                }
                if (!isValid)
                {
                    _method.InvokeInstanceLowAlloc(ref target, arg0, arg1, arg2);
                    return;
                }
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
    }
    public readonly struct ClassInstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2>
    where TTarget: class
    {
        private readonly nint _pAddress;
        private readonly bool _isValid;
        private readonly MethodBase _method;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ClassInstanceMethodPointerAction(MethodBase method)
        {
            _method = method;
            if (method.IsOverridable())
            {
                _isValid = false;
                _pAddress = 0;
                return;
            }
            _isValid = REMethodBase.ValidateInstanceMethod<TTarget, TArg0, TArg1, TArg2>(method, out _pAddress);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ClassInstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2>(MethodBase method)
        {
            return new ClassInstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2>(method);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ClassInstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2>(Action<TArg0, TArg1, TArg2> method)
        {
            return new ClassInstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2>(method.Method);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Invoke(TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2)
        {
            bool isValid = _isValid;
            nint pAddress = _pAddress;
            if (!isValid)
            {
                if (_method.IsOverridable())
                {
                    isValid = REMethodBase.ValidateInstanceVirtualMethod<TTarget, TArg0, TArg1, TArg2>(_method, target?.GetType(), out pAddress) ||
                              (pAddress != 0 && REMethodBase.SecondaryValidateStaticMethod(_method, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), ref pAddress));
                }
                else
                {
                    isValid = (pAddress != 0 && REMethodBase.SecondaryValidateInstanceMethod(_method, target?.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), ref pAddress));
                }
                if (!isValid)
                {
                    _method.InvokeClassInstanceLowAlloc(target, arg0, arg1, arg2);
                    return;
                }
            }
            unsafe
            {
                ((delegate*<TTarget, TArg0, TArg1, TArg2, void>)pAddress)(target, arg0, arg1, arg2);
                return;
            }
        }
    }
    public readonly struct StructInstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2>
    where TTarget: struct
    {
        private readonly nint _pAddress;
        private readonly bool _isValid;
        private readonly MethodBase _method;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public StructInstanceMethodPointerAction(MethodBase method)
        {
            _method = method;
            if (method.IsOverridable())
            {
                _isValid = false;
                _pAddress = 0;
                return;
            }
            _isValid = REMethodBase.ValidateInstanceMethod<TTarget, TArg0, TArg1, TArg2>(method, out _pAddress);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator StructInstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2>(MethodBase method)
        {
            return new StructInstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2>(method);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator StructInstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2>(Action<TArg0, TArg1, TArg2> method)
        {
            return new StructInstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2>(method.Method);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Invoke(ref TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2)
        {
            bool isValid = _isValid;
            nint pAddress = _pAddress;
            if (!isValid)
            {
                if (_method.IsOverridable())
                {
                    isValid = REMethodBase.ValidateInstanceVirtualMethod<TTarget, TArg0, TArg1, TArg2>(_method, target.GetType(), out pAddress) ||
                              (pAddress != 0 && REMethodBase.SecondaryValidateStaticMethod(_method, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), ref pAddress));
                }
                else
                {
                    isValid = (pAddress != 0 && REMethodBase.SecondaryValidateInstanceMethod(_method, target.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), ref pAddress));
                }
                if (!isValid)
                {
                    _method.InvokeInstanceLowAlloc(ref target, arg0, arg1, arg2);
                    return;
                }
            }
            unsafe
            {
                ((delegate*<ref TTarget, TArg0, TArg1, TArg2, void>)pAddress)(ref target, arg0, arg1, arg2);
                return;
            }
        }
    }
    public readonly struct InstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TReturn>
    {
        private readonly nint _pAddress;
        private readonly bool _isValid;
        private readonly MethodBase _method;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public InstanceMethodPointerFunc(MethodBase method)
        {
            _method = method;
            if (method.IsOverridable())
            {
                _isValid = false;
                _pAddress = 0;
                return;
            }
            _isValid = REMethodBase.ValidateInstanceReturnableMethod<TTarget, TArg0, TArg1, TArg2, TReturn>(method, out _pAddress);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator InstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TReturn>(MethodBase method)
        {
            return new InstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TReturn>(method);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator InstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TReturn>(Func<TArg0, TArg1, TArg2, TReturn> method)
        {
            return new InstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TReturn>(method.Method);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TReturn Invoke(ref TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2)
        {
            bool isValid = _isValid;
            nint pAddress = _pAddress;
            if (!isValid)
            {
                if (_method.IsOverridable())
                {
                    isValid = REMethodBase.ValidateInstanceReturnableVirtualMethod<TTarget, TArg0, TArg1, TArg2, TReturn>(_method, target?.GetType(), out pAddress) ||
                              (pAddress != 0 && REMethodBase.SecondaryValidateStaticMethod(_method, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), ref pAddress));
                }
                else
                {
                    isValid = (pAddress != 0 && REMethodBase.SecondaryValidateInstanceMethod(_method, target?.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), ref pAddress));
                }
                if (!isValid)
                {
                    return (TReturn)_method.InvokeInstanceLowAlloc(ref target, arg0, arg1, arg2);
                }
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
    }
    public readonly struct ClassInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TReturn>
    where TTarget: class
    {
        private readonly nint _pAddress;
        private readonly bool _isValid;
        private readonly MethodBase _method;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ClassInstanceMethodPointerFunc(MethodBase method)
        {
            _method = method;
            if (method.IsOverridable())
            {
                _isValid = false;
                _pAddress = 0;
                return;
            }
            _isValid = REMethodBase.ValidateInstanceReturnableMethod<TTarget, TArg0, TArg1, TArg2, TReturn>(method, out _pAddress);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ClassInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TReturn>(MethodBase method)
        {
            return new ClassInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TReturn>(method);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ClassInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TReturn>(Func<TArg0, TArg1, TArg2, TReturn> method)
        {
            return new ClassInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TReturn>(method.Method);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TReturn Invoke(TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2)
        {
            bool isValid = _isValid;
            nint pAddress = _pAddress;
            if (!isValid)
            {
                if (_method.IsOverridable())
                {
                    isValid = REMethodBase.ValidateInstanceReturnableVirtualMethod<TTarget, TArg0, TArg1, TArg2, TReturn>(_method, target?.GetType(), out pAddress) ||
                              (pAddress != 0 && REMethodBase.SecondaryValidateStaticMethod(_method, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), ref pAddress));
                }
                else
                {
                    isValid = (pAddress != 0 && REMethodBase.SecondaryValidateInstanceMethod(_method, target?.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), ref pAddress));
                }
                if (!isValid)
                {
                    return (TReturn)_method.InvokeClassInstanceLowAlloc(target, arg0, arg1, arg2);
                }
            }
            unsafe
            {
                return ((delegate*<TTarget, TArg0, TArg1, TArg2, TReturn>)pAddress)(target, arg0, arg1, arg2);
            }
        }
    }
    public readonly struct StructInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TReturn>
    where TTarget: struct
    {
        private readonly nint _pAddress;
        private readonly bool _isValid;
        private readonly MethodBase _method;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public StructInstanceMethodPointerFunc(MethodBase method)
        {
            _method = method;
            if (method.IsOverridable())
            {
                _isValid = false;
                _pAddress = 0;
                return;
            }
            _isValid = REMethodBase.ValidateInstanceReturnableMethod<TTarget, TArg0, TArg1, TArg2, TReturn>(method, out _pAddress);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator StructInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TReturn>(MethodBase method)
        {
            return new StructInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TReturn>(method);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator StructInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TReturn>(Func<TArg0, TArg1, TArg2, TReturn> method)
        {
            return new StructInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TReturn>(method.Method);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TReturn Invoke(ref TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2)
        {
            bool isValid = _isValid;
            nint pAddress = _pAddress;
            if (!isValid)
            {
                if (_method.IsOverridable())
                {
                    isValid = REMethodBase.ValidateInstanceReturnableVirtualMethod<TTarget, TArg0, TArg1, TArg2, TReturn>(_method, target.GetType(), out pAddress) ||
                              (pAddress != 0 && REMethodBase.SecondaryValidateStaticMethod(_method, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), ref pAddress));
                }
                else
                {
                    isValid = (pAddress != 0 && REMethodBase.SecondaryValidateInstanceMethod(_method, target.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), ref pAddress));
                }
                if (!isValid)
                {
                    return (TReturn)_method.InvokeInstanceLowAlloc(ref target, arg0, arg1, arg2);
                }
            }
            unsafe
            {
                return ((delegate*<ref TTarget, TArg0, TArg1, TArg2, TReturn>)pAddress)(ref target, arg0, arg1, arg2);
            }
        }
    }
    public readonly struct StaticMethodPointerAction<TArg0, TArg1, TArg2>
    {
        private readonly nint _pAddress;
        private readonly bool _isValid;
        private readonly MethodBase _method;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public StaticMethodPointerAction(MethodBase method)
        {
            _method = method;
            if (method.IsOverridable())
            {
                _isValid = false;
                _pAddress = 0;
                return;
            }
            _isValid = REMethodBase.ValidateStaticMethod<TArg0, TArg1, TArg2>(method, out _pAddress);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator StaticMethodPointerAction<TArg0, TArg1, TArg2>(MethodBase method)
        {
            return new StaticMethodPointerAction<TArg0, TArg1, TArg2>(method);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator StaticMethodPointerAction<TArg0, TArg1, TArg2>(Action<TArg0, TArg1, TArg2> method)
        {
            return new StaticMethodPointerAction<TArg0, TArg1, TArg2>(method.Method);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Invoke(in TArg0 arg0, in TArg1 arg1, in TArg2 arg2)
        {
            bool isValid = _isValid;
            nint pAddress = _pAddress;
            if (!isValid)
            {
                isValid = (pAddress != 0 && REMethodBase.SecondaryValidateStaticMethod(_method, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), ref pAddress));
                if (!isValid)
                {
                    _method.InvokeStaticLowAlloc(arg0, arg1, arg2);
                    return;
                }
            }
            unsafe
            {
                ((delegate*<TArg0, TArg1, TArg2, void>)pAddress)(arg0, arg1, arg2);
                return;
            }
        }
    }
    public readonly struct StaticMethodPointerFunc<TArg0, TArg1, TArg2, TReturn>
    {
        private readonly nint _pAddress;
        private readonly bool _isValid;
        private readonly MethodBase _method;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public StaticMethodPointerFunc(MethodBase method)
        {
            _method = method;
            if (method.IsOverridable())
            {
                _isValid = false;
                _pAddress = 0;
                return;
            }
            _isValid = REMethodBase.ValidateStaticReturnableMethod<TArg0, TArg1, TArg2, TReturn>(method, out _pAddress);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator StaticMethodPointerFunc<TArg0, TArg1, TArg2, TReturn>(MethodBase method)
        {
            return new StaticMethodPointerFunc<TArg0, TArg1, TArg2, TReturn>(method);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator StaticMethodPointerFunc<TArg0, TArg1, TArg2, TReturn>(Func<TArg0, TArg1, TArg2, TReturn> method)
        {
            return new StaticMethodPointerFunc<TArg0, TArg1, TArg2, TReturn>(method.Method);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TReturn Invoke(in TArg0 arg0, in TArg1 arg1, in TArg2 arg2)
        {
            bool isValid = _isValid;
            nint pAddress = _pAddress;
            if (!isValid)
            {
                isValid = (pAddress != 0 && REMethodBase.SecondaryValidateStaticMethod(_method, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), ref pAddress));
                if (!isValid)
                {
                    return (TReturn)_method.InvokeStaticLowAlloc(arg0, arg1, arg2);
                }
            }
            unsafe
            {
                return ((delegate*<TArg0, TArg1, TArg2, TReturn>)pAddress)(arg0, arg1, arg2);
            }
        }
    }
    public readonly struct InstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3>
    {
        private readonly nint _pAddress;
        private readonly bool _isValid;
        private readonly MethodBase _method;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public InstanceMethodPointerAction(MethodBase method)
        {
            _method = method;
            if (method.IsOverridable())
            {
                _isValid = false;
                _pAddress = 0;
                return;
            }
            _isValid = REMethodBase.ValidateInstanceMethod<TTarget, TArg0, TArg1, TArg2, TArg3>(method, out _pAddress);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator InstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3>(MethodBase method)
        {
            return new InstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3>(method);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator InstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3>(Action<TArg0, TArg1, TArg2, TArg3> method)
        {
            return new InstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3>(method.Method);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Invoke(ref TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3)
        {
            bool isValid = _isValid;
            nint pAddress = _pAddress;
            if (!isValid)
            {
                if (_method.IsOverridable())
                {
                    isValid = REMethodBase.ValidateInstanceVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3>(_method, target?.GetType(), out pAddress) ||
                              (pAddress != 0 && REMethodBase.SecondaryValidateStaticMethod(_method, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), ref pAddress));
                }
                else
                {
                    isValid = (pAddress != 0 && REMethodBase.SecondaryValidateInstanceMethod(_method, target?.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), ref pAddress));
                }
                if (!isValid)
                {
                    _method.InvokeInstanceLowAlloc(ref target, arg0, arg1, arg2, arg3);
                    return;
                }
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
    }
    public readonly struct ClassInstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3>
    where TTarget: class
    {
        private readonly nint _pAddress;
        private readonly bool _isValid;
        private readonly MethodBase _method;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ClassInstanceMethodPointerAction(MethodBase method)
        {
            _method = method;
            if (method.IsOverridable())
            {
                _isValid = false;
                _pAddress = 0;
                return;
            }
            _isValid = REMethodBase.ValidateInstanceMethod<TTarget, TArg0, TArg1, TArg2, TArg3>(method, out _pAddress);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ClassInstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3>(MethodBase method)
        {
            return new ClassInstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3>(method);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ClassInstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3>(Action<TArg0, TArg1, TArg2, TArg3> method)
        {
            return new ClassInstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3>(method.Method);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Invoke(TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3)
        {
            bool isValid = _isValid;
            nint pAddress = _pAddress;
            if (!isValid)
            {
                if (_method.IsOverridable())
                {
                    isValid = REMethodBase.ValidateInstanceVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3>(_method, target?.GetType(), out pAddress) ||
                              (pAddress != 0 && REMethodBase.SecondaryValidateStaticMethod(_method, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), ref pAddress));
                }
                else
                {
                    isValid = (pAddress != 0 && REMethodBase.SecondaryValidateInstanceMethod(_method, target?.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), ref pAddress));
                }
                if (!isValid)
                {
                    _method.InvokeClassInstanceLowAlloc(target, arg0, arg1, arg2, arg3);
                    return;
                }
            }
            unsafe
            {
                ((delegate*<TTarget, TArg0, TArg1, TArg2, TArg3, void>)pAddress)(target, arg0, arg1, arg2, arg3);
                return;
            }
        }
    }
    public readonly struct StructInstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3>
    where TTarget: struct
    {
        private readonly nint _pAddress;
        private readonly bool _isValid;
        private readonly MethodBase _method;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public StructInstanceMethodPointerAction(MethodBase method)
        {
            _method = method;
            if (method.IsOverridable())
            {
                _isValid = false;
                _pAddress = 0;
                return;
            }
            _isValid = REMethodBase.ValidateInstanceMethod<TTarget, TArg0, TArg1, TArg2, TArg3>(method, out _pAddress);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator StructInstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3>(MethodBase method)
        {
            return new StructInstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3>(method);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator StructInstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3>(Action<TArg0, TArg1, TArg2, TArg3> method)
        {
            return new StructInstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3>(method.Method);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Invoke(ref TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3)
        {
            bool isValid = _isValid;
            nint pAddress = _pAddress;
            if (!isValid)
            {
                if (_method.IsOverridable())
                {
                    isValid = REMethodBase.ValidateInstanceVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3>(_method, target.GetType(), out pAddress) ||
                              (pAddress != 0 && REMethodBase.SecondaryValidateStaticMethod(_method, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), ref pAddress));
                }
                else
                {
                    isValid = (pAddress != 0 && REMethodBase.SecondaryValidateInstanceMethod(_method, target.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), ref pAddress));
                }
                if (!isValid)
                {
                    _method.InvokeInstanceLowAlloc(ref target, arg0, arg1, arg2, arg3);
                    return;
                }
            }
            unsafe
            {
                ((delegate*<ref TTarget, TArg0, TArg1, TArg2, TArg3, void>)pAddress)(ref target, arg0, arg1, arg2, arg3);
                return;
            }
        }
    }
    public readonly struct InstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TReturn>
    {
        private readonly nint _pAddress;
        private readonly bool _isValid;
        private readonly MethodBase _method;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public InstanceMethodPointerFunc(MethodBase method)
        {
            _method = method;
            if (method.IsOverridable())
            {
                _isValid = false;
                _pAddress = 0;
                return;
            }
            _isValid = REMethodBase.ValidateInstanceReturnableMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TReturn>(method, out _pAddress);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator InstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TReturn>(MethodBase method)
        {
            return new InstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TReturn>(method);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator InstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TReturn>(Func<TArg0, TArg1, TArg2, TArg3, TReturn> method)
        {
            return new InstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TReturn>(method.Method);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TReturn Invoke(ref TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3)
        {
            bool isValid = _isValid;
            nint pAddress = _pAddress;
            if (!isValid)
            {
                if (_method.IsOverridable())
                {
                    isValid = REMethodBase.ValidateInstanceReturnableVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TReturn>(_method, target?.GetType(), out pAddress) ||
                              (pAddress != 0 && REMethodBase.SecondaryValidateStaticMethod(_method, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), ref pAddress));
                }
                else
                {
                    isValid = (pAddress != 0 && REMethodBase.SecondaryValidateInstanceMethod(_method, target?.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), ref pAddress));
                }
                if (!isValid)
                {
                    return (TReturn)_method.InvokeInstanceLowAlloc(ref target, arg0, arg1, arg2, arg3);
                }
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
    }
    public readonly struct ClassInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TReturn>
    where TTarget: class
    {
        private readonly nint _pAddress;
        private readonly bool _isValid;
        private readonly MethodBase _method;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ClassInstanceMethodPointerFunc(MethodBase method)
        {
            _method = method;
            if (method.IsOverridable())
            {
                _isValid = false;
                _pAddress = 0;
                return;
            }
            _isValid = REMethodBase.ValidateInstanceReturnableMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TReturn>(method, out _pAddress);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ClassInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TReturn>(MethodBase method)
        {
            return new ClassInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TReturn>(method);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ClassInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TReturn>(Func<TArg0, TArg1, TArg2, TArg3, TReturn> method)
        {
            return new ClassInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TReturn>(method.Method);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TReturn Invoke(TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3)
        {
            bool isValid = _isValid;
            nint pAddress = _pAddress;
            if (!isValid)
            {
                if (_method.IsOverridable())
                {
                    isValid = REMethodBase.ValidateInstanceReturnableVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TReturn>(_method, target?.GetType(), out pAddress) ||
                              (pAddress != 0 && REMethodBase.SecondaryValidateStaticMethod(_method, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), ref pAddress));
                }
                else
                {
                    isValid = (pAddress != 0 && REMethodBase.SecondaryValidateInstanceMethod(_method, target?.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), ref pAddress));
                }
                if (!isValid)
                {
                    return (TReturn)_method.InvokeClassInstanceLowAlloc(target, arg0, arg1, arg2, arg3);
                }
            }
            unsafe
            {
                return ((delegate*<TTarget, TArg0, TArg1, TArg2, TArg3, TReturn>)pAddress)(target, arg0, arg1, arg2, arg3);
            }
        }
    }
    public readonly struct StructInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TReturn>
    where TTarget: struct
    {
        private readonly nint _pAddress;
        private readonly bool _isValid;
        private readonly MethodBase _method;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public StructInstanceMethodPointerFunc(MethodBase method)
        {
            _method = method;
            if (method.IsOverridable())
            {
                _isValid = false;
                _pAddress = 0;
                return;
            }
            _isValid = REMethodBase.ValidateInstanceReturnableMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TReturn>(method, out _pAddress);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator StructInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TReturn>(MethodBase method)
        {
            return new StructInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TReturn>(method);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator StructInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TReturn>(Func<TArg0, TArg1, TArg2, TArg3, TReturn> method)
        {
            return new StructInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TReturn>(method.Method);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TReturn Invoke(ref TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3)
        {
            bool isValid = _isValid;
            nint pAddress = _pAddress;
            if (!isValid)
            {
                if (_method.IsOverridable())
                {
                    isValid = REMethodBase.ValidateInstanceReturnableVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TReturn>(_method, target.GetType(), out pAddress) ||
                              (pAddress != 0 && REMethodBase.SecondaryValidateStaticMethod(_method, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), ref pAddress));
                }
                else
                {
                    isValid = (pAddress != 0 && REMethodBase.SecondaryValidateInstanceMethod(_method, target.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), ref pAddress));
                }
                if (!isValid)
                {
                    return (TReturn)_method.InvokeInstanceLowAlloc(ref target, arg0, arg1, arg2, arg3);
                }
            }
            unsafe
            {
                return ((delegate*<ref TTarget, TArg0, TArg1, TArg2, TArg3, TReturn>)pAddress)(ref target, arg0, arg1, arg2, arg3);
            }
        }
    }
    public readonly struct StaticMethodPointerAction<TArg0, TArg1, TArg2, TArg3>
    {
        private readonly nint _pAddress;
        private readonly bool _isValid;
        private readonly MethodBase _method;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public StaticMethodPointerAction(MethodBase method)
        {
            _method = method;
            if (method.IsOverridable())
            {
                _isValid = false;
                _pAddress = 0;
                return;
            }
            _isValid = REMethodBase.ValidateStaticMethod<TArg0, TArg1, TArg2, TArg3>(method, out _pAddress);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator StaticMethodPointerAction<TArg0, TArg1, TArg2, TArg3>(MethodBase method)
        {
            return new StaticMethodPointerAction<TArg0, TArg1, TArg2, TArg3>(method);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator StaticMethodPointerAction<TArg0, TArg1, TArg2, TArg3>(Action<TArg0, TArg1, TArg2, TArg3> method)
        {
            return new StaticMethodPointerAction<TArg0, TArg1, TArg2, TArg3>(method.Method);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Invoke(in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3)
        {
            bool isValid = _isValid;
            nint pAddress = _pAddress;
            if (!isValid)
            {
                isValid = (pAddress != 0 && REMethodBase.SecondaryValidateStaticMethod(_method, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), ref pAddress));
                if (!isValid)
                {
                    _method.InvokeStaticLowAlloc(arg0, arg1, arg2, arg3);
                    return;
                }
            }
            unsafe
            {
                ((delegate*<TArg0, TArg1, TArg2, TArg3, void>)pAddress)(arg0, arg1, arg2, arg3);
                return;
            }
        }
    }
    public readonly struct StaticMethodPointerFunc<TArg0, TArg1, TArg2, TArg3, TReturn>
    {
        private readonly nint _pAddress;
        private readonly bool _isValid;
        private readonly MethodBase _method;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public StaticMethodPointerFunc(MethodBase method)
        {
            _method = method;
            if (method.IsOverridable())
            {
                _isValid = false;
                _pAddress = 0;
                return;
            }
            _isValid = REMethodBase.ValidateStaticReturnableMethod<TArg0, TArg1, TArg2, TArg3, TReturn>(method, out _pAddress);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator StaticMethodPointerFunc<TArg0, TArg1, TArg2, TArg3, TReturn>(MethodBase method)
        {
            return new StaticMethodPointerFunc<TArg0, TArg1, TArg2, TArg3, TReturn>(method);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator StaticMethodPointerFunc<TArg0, TArg1, TArg2, TArg3, TReturn>(Func<TArg0, TArg1, TArg2, TArg3, TReturn> method)
        {
            return new StaticMethodPointerFunc<TArg0, TArg1, TArg2, TArg3, TReturn>(method.Method);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TReturn Invoke(in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3)
        {
            bool isValid = _isValid;
            nint pAddress = _pAddress;
            if (!isValid)
            {
                isValid = (pAddress != 0 && REMethodBase.SecondaryValidateStaticMethod(_method, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), ref pAddress));
                if (!isValid)
                {
                    return (TReturn)_method.InvokeStaticLowAlloc(arg0, arg1, arg2, arg3);
                }
            }
            unsafe
            {
                return ((delegate*<TArg0, TArg1, TArg2, TArg3, TReturn>)pAddress)(arg0, arg1, arg2, arg3);
            }
        }
    }
    public readonly struct InstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4>
    {
        private readonly nint _pAddress;
        private readonly bool _isValid;
        private readonly MethodBase _method;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public InstanceMethodPointerAction(MethodBase method)
        {
            _method = method;
            if (method.IsOverridable())
            {
                _isValid = false;
                _pAddress = 0;
                return;
            }
            _isValid = REMethodBase.ValidateInstanceMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4>(method, out _pAddress);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator InstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4>(MethodBase method)
        {
            return new InstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4>(method);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator InstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4>(Action<TArg0, TArg1, TArg2, TArg3, TArg4> method)
        {
            return new InstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4>(method.Method);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Invoke(ref TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4)
        {
            bool isValid = _isValid;
            nint pAddress = _pAddress;
            if (!isValid)
            {
                if (_method.IsOverridable())
                {
                    isValid = REMethodBase.ValidateInstanceVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4>(_method, target?.GetType(), out pAddress) ||
                              (pAddress != 0 && REMethodBase.SecondaryValidateStaticMethod(_method, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), ref pAddress));
                }
                else
                {
                    isValid = (pAddress != 0 && REMethodBase.SecondaryValidateInstanceMethod(_method, target?.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), ref pAddress));
                }
                if (!isValid)
                {
                    _method.InvokeInstanceLowAlloc(ref target, arg0, arg1, arg2, arg3, arg4);
                    return;
                }
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
    }
    public readonly struct ClassInstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4>
    where TTarget: class
    {
        private readonly nint _pAddress;
        private readonly bool _isValid;
        private readonly MethodBase _method;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ClassInstanceMethodPointerAction(MethodBase method)
        {
            _method = method;
            if (method.IsOverridable())
            {
                _isValid = false;
                _pAddress = 0;
                return;
            }
            _isValid = REMethodBase.ValidateInstanceMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4>(method, out _pAddress);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ClassInstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4>(MethodBase method)
        {
            return new ClassInstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4>(method);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ClassInstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4>(Action<TArg0, TArg1, TArg2, TArg3, TArg4> method)
        {
            return new ClassInstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4>(method.Method);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Invoke(TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4)
        {
            bool isValid = _isValid;
            nint pAddress = _pAddress;
            if (!isValid)
            {
                if (_method.IsOverridable())
                {
                    isValid = REMethodBase.ValidateInstanceVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4>(_method, target?.GetType(), out pAddress) ||
                              (pAddress != 0 && REMethodBase.SecondaryValidateStaticMethod(_method, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), ref pAddress));
                }
                else
                {
                    isValid = (pAddress != 0 && REMethodBase.SecondaryValidateInstanceMethod(_method, target?.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), ref pAddress));
                }
                if (!isValid)
                {
                    _method.InvokeClassInstanceLowAlloc(target, arg0, arg1, arg2, arg3, arg4);
                    return;
                }
            }
            unsafe
            {
                ((delegate*<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, void>)pAddress)(target, arg0, arg1, arg2, arg3, arg4);
                return;
            }
        }
    }
    public readonly struct StructInstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4>
    where TTarget: struct
    {
        private readonly nint _pAddress;
        private readonly bool _isValid;
        private readonly MethodBase _method;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public StructInstanceMethodPointerAction(MethodBase method)
        {
            _method = method;
            if (method.IsOverridable())
            {
                _isValid = false;
                _pAddress = 0;
                return;
            }
            _isValid = REMethodBase.ValidateInstanceMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4>(method, out _pAddress);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator StructInstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4>(MethodBase method)
        {
            return new StructInstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4>(method);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator StructInstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4>(Action<TArg0, TArg1, TArg2, TArg3, TArg4> method)
        {
            return new StructInstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4>(method.Method);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Invoke(ref TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4)
        {
            bool isValid = _isValid;
            nint pAddress = _pAddress;
            if (!isValid)
            {
                if (_method.IsOverridable())
                {
                    isValid = REMethodBase.ValidateInstanceVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4>(_method, target.GetType(), out pAddress) ||
                              (pAddress != 0 && REMethodBase.SecondaryValidateStaticMethod(_method, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), ref pAddress));
                }
                else
                {
                    isValid = (pAddress != 0 && REMethodBase.SecondaryValidateInstanceMethod(_method, target.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), ref pAddress));
                }
                if (!isValid)
                {
                    _method.InvokeInstanceLowAlloc(ref target, arg0, arg1, arg2, arg3, arg4);
                    return;
                }
            }
            unsafe
            {
                ((delegate*<ref TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, void>)pAddress)(ref target, arg0, arg1, arg2, arg3, arg4);
                return;
            }
        }
    }
    public readonly struct InstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TReturn>
    {
        private readonly nint _pAddress;
        private readonly bool _isValid;
        private readonly MethodBase _method;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public InstanceMethodPointerFunc(MethodBase method)
        {
            _method = method;
            if (method.IsOverridable())
            {
                _isValid = false;
                _pAddress = 0;
                return;
            }
            _isValid = REMethodBase.ValidateInstanceReturnableMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TReturn>(method, out _pAddress);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator InstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TReturn>(MethodBase method)
        {
            return new InstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TReturn>(method);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator InstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TReturn>(Func<TArg0, TArg1, TArg2, TArg3, TArg4, TReturn> method)
        {
            return new InstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TReturn>(method.Method);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TReturn Invoke(ref TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4)
        {
            bool isValid = _isValid;
            nint pAddress = _pAddress;
            if (!isValid)
            {
                if (_method.IsOverridable())
                {
                    isValid = REMethodBase.ValidateInstanceReturnableVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TReturn>(_method, target?.GetType(), out pAddress) ||
                              (pAddress != 0 && REMethodBase.SecondaryValidateStaticMethod(_method, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), ref pAddress));
                }
                else
                {
                    isValid = (pAddress != 0 && REMethodBase.SecondaryValidateInstanceMethod(_method, target?.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), ref pAddress));
                }
                if (!isValid)
                {
                    return (TReturn)_method.InvokeInstanceLowAlloc(ref target, arg0, arg1, arg2, arg3, arg4);
                }
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
    }
    public readonly struct ClassInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TReturn>
    where TTarget: class
    {
        private readonly nint _pAddress;
        private readonly bool _isValid;
        private readonly MethodBase _method;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ClassInstanceMethodPointerFunc(MethodBase method)
        {
            _method = method;
            if (method.IsOverridable())
            {
                _isValid = false;
                _pAddress = 0;
                return;
            }
            _isValid = REMethodBase.ValidateInstanceReturnableMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TReturn>(method, out _pAddress);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ClassInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TReturn>(MethodBase method)
        {
            return new ClassInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TReturn>(method);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ClassInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TReturn>(Func<TArg0, TArg1, TArg2, TArg3, TArg4, TReturn> method)
        {
            return new ClassInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TReturn>(method.Method);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TReturn Invoke(TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4)
        {
            bool isValid = _isValid;
            nint pAddress = _pAddress;
            if (!isValid)
            {
                if (_method.IsOverridable())
                {
                    isValid = REMethodBase.ValidateInstanceReturnableVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TReturn>(_method, target?.GetType(), out pAddress) ||
                              (pAddress != 0 && REMethodBase.SecondaryValidateStaticMethod(_method, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), ref pAddress));
                }
                else
                {
                    isValid = (pAddress != 0 && REMethodBase.SecondaryValidateInstanceMethod(_method, target?.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), ref pAddress));
                }
                if (!isValid)
                {
                    return (TReturn)_method.InvokeClassInstanceLowAlloc(target, arg0, arg1, arg2, arg3, arg4);
                }
            }
            unsafe
            {
                return ((delegate*<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TReturn>)pAddress)(target, arg0, arg1, arg2, arg3, arg4);
            }
        }
    }
    public readonly struct StructInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TReturn>
    where TTarget: struct
    {
        private readonly nint _pAddress;
        private readonly bool _isValid;
        private readonly MethodBase _method;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public StructInstanceMethodPointerFunc(MethodBase method)
        {
            _method = method;
            if (method.IsOverridable())
            {
                _isValid = false;
                _pAddress = 0;
                return;
            }
            _isValid = REMethodBase.ValidateInstanceReturnableMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TReturn>(method, out _pAddress);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator StructInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TReturn>(MethodBase method)
        {
            return new StructInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TReturn>(method);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator StructInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TReturn>(Func<TArg0, TArg1, TArg2, TArg3, TArg4, TReturn> method)
        {
            return new StructInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TReturn>(method.Method);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TReturn Invoke(ref TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4)
        {
            bool isValid = _isValid;
            nint pAddress = _pAddress;
            if (!isValid)
            {
                if (_method.IsOverridable())
                {
                    isValid = REMethodBase.ValidateInstanceReturnableVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TReturn>(_method, target.GetType(), out pAddress) ||
                              (pAddress != 0 && REMethodBase.SecondaryValidateStaticMethod(_method, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), ref pAddress));
                }
                else
                {
                    isValid = (pAddress != 0 && REMethodBase.SecondaryValidateInstanceMethod(_method, target.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), ref pAddress));
                }
                if (!isValid)
                {
                    return (TReturn)_method.InvokeInstanceLowAlloc(ref target, arg0, arg1, arg2, arg3, arg4);
                }
            }
            unsafe
            {
                return ((delegate*<ref TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TReturn>)pAddress)(ref target, arg0, arg1, arg2, arg3, arg4);
            }
        }
    }
    public readonly struct StaticMethodPointerAction<TArg0, TArg1, TArg2, TArg3, TArg4>
    {
        private readonly nint _pAddress;
        private readonly bool _isValid;
        private readonly MethodBase _method;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public StaticMethodPointerAction(MethodBase method)
        {
            _method = method;
            if (method.IsOverridable())
            {
                _isValid = false;
                _pAddress = 0;
                return;
            }
            _isValid = REMethodBase.ValidateStaticMethod<TArg0, TArg1, TArg2, TArg3, TArg4>(method, out _pAddress);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator StaticMethodPointerAction<TArg0, TArg1, TArg2, TArg3, TArg4>(MethodBase method)
        {
            return new StaticMethodPointerAction<TArg0, TArg1, TArg2, TArg3, TArg4>(method);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator StaticMethodPointerAction<TArg0, TArg1, TArg2, TArg3, TArg4>(Action<TArg0, TArg1, TArg2, TArg3, TArg4> method)
        {
            return new StaticMethodPointerAction<TArg0, TArg1, TArg2, TArg3, TArg4>(method.Method);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Invoke(in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4)
        {
            bool isValid = _isValid;
            nint pAddress = _pAddress;
            if (!isValid)
            {
                isValid = (pAddress != 0 && REMethodBase.SecondaryValidateStaticMethod(_method, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), ref pAddress));
                if (!isValid)
                {
                    _method.InvokeStaticLowAlloc(arg0, arg1, arg2, arg3, arg4);
                    return;
                }
            }
            unsafe
            {
                ((delegate*<TArg0, TArg1, TArg2, TArg3, TArg4, void>)pAddress)(arg0, arg1, arg2, arg3, arg4);
                return;
            }
        }
    }
    public readonly struct StaticMethodPointerFunc<TArg0, TArg1, TArg2, TArg3, TArg4, TReturn>
    {
        private readonly nint _pAddress;
        private readonly bool _isValid;
        private readonly MethodBase _method;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public StaticMethodPointerFunc(MethodBase method)
        {
            _method = method;
            if (method.IsOverridable())
            {
                _isValid = false;
                _pAddress = 0;
                return;
            }
            _isValid = REMethodBase.ValidateStaticReturnableMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TReturn>(method, out _pAddress);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator StaticMethodPointerFunc<TArg0, TArg1, TArg2, TArg3, TArg4, TReturn>(MethodBase method)
        {
            return new StaticMethodPointerFunc<TArg0, TArg1, TArg2, TArg3, TArg4, TReturn>(method);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator StaticMethodPointerFunc<TArg0, TArg1, TArg2, TArg3, TArg4, TReturn>(Func<TArg0, TArg1, TArg2, TArg3, TArg4, TReturn> method)
        {
            return new StaticMethodPointerFunc<TArg0, TArg1, TArg2, TArg3, TArg4, TReturn>(method.Method);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TReturn Invoke(in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4)
        {
            bool isValid = _isValid;
            nint pAddress = _pAddress;
            if (!isValid)
            {
                isValid = (pAddress != 0 && REMethodBase.SecondaryValidateStaticMethod(_method, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), ref pAddress));
                if (!isValid)
                {
                    return (TReturn)_method.InvokeStaticLowAlloc(arg0, arg1, arg2, arg3, arg4);
                }
            }
            unsafe
            {
                return ((delegate*<TArg0, TArg1, TArg2, TArg3, TArg4, TReturn>)pAddress)(arg0, arg1, arg2, arg3, arg4);
            }
        }
    }
    public readonly struct InstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>
    {
        private readonly nint _pAddress;
        private readonly bool _isValid;
        private readonly MethodBase _method;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public InstanceMethodPointerAction(MethodBase method)
        {
            _method = method;
            if (method.IsOverridable())
            {
                _isValid = false;
                _pAddress = 0;
                return;
            }
            _isValid = REMethodBase.ValidateInstanceMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(method, out _pAddress);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator InstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(MethodBase method)
        {
            return new InstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(method);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator InstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(Action<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5> method)
        {
            return new InstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(method.Method);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Invoke(ref TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5)
        {
            bool isValid = _isValid;
            nint pAddress = _pAddress;
            if (!isValid)
            {
                if (_method.IsOverridable())
                {
                    isValid = REMethodBase.ValidateInstanceVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(_method, target?.GetType(), out pAddress) ||
                              (pAddress != 0 && REMethodBase.SecondaryValidateStaticMethod(_method, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), ref pAddress));
                }
                else
                {
                    isValid = (pAddress != 0 && REMethodBase.SecondaryValidateInstanceMethod(_method, target?.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), ref pAddress));
                }
                if (!isValid)
                {
                    _method.InvokeInstanceLowAlloc(ref target, arg0, arg1, arg2, arg3, arg4, arg5);
                    return;
                }
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
    }
    public readonly struct ClassInstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>
    where TTarget: class
    {
        private readonly nint _pAddress;
        private readonly bool _isValid;
        private readonly MethodBase _method;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ClassInstanceMethodPointerAction(MethodBase method)
        {
            _method = method;
            if (method.IsOverridable())
            {
                _isValid = false;
                _pAddress = 0;
                return;
            }
            _isValid = REMethodBase.ValidateInstanceMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(method, out _pAddress);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ClassInstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(MethodBase method)
        {
            return new ClassInstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(method);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ClassInstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(Action<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5> method)
        {
            return new ClassInstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(method.Method);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Invoke(TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5)
        {
            bool isValid = _isValid;
            nint pAddress = _pAddress;
            if (!isValid)
            {
                if (_method.IsOverridable())
                {
                    isValid = REMethodBase.ValidateInstanceVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(_method, target?.GetType(), out pAddress) ||
                              (pAddress != 0 && REMethodBase.SecondaryValidateStaticMethod(_method, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), ref pAddress));
                }
                else
                {
                    isValid = (pAddress != 0 && REMethodBase.SecondaryValidateInstanceMethod(_method, target?.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), ref pAddress));
                }
                if (!isValid)
                {
                    _method.InvokeClassInstanceLowAlloc(target, arg0, arg1, arg2, arg3, arg4, arg5);
                    return;
                }
            }
            unsafe
            {
                ((delegate*<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, void>)pAddress)(target, arg0, arg1, arg2, arg3, arg4, arg5);
                return;
            }
        }
    }
    public readonly struct StructInstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>
    where TTarget: struct
    {
        private readonly nint _pAddress;
        private readonly bool _isValid;
        private readonly MethodBase _method;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public StructInstanceMethodPointerAction(MethodBase method)
        {
            _method = method;
            if (method.IsOverridable())
            {
                _isValid = false;
                _pAddress = 0;
                return;
            }
            _isValid = REMethodBase.ValidateInstanceMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(method, out _pAddress);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator StructInstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(MethodBase method)
        {
            return new StructInstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(method);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator StructInstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(Action<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5> method)
        {
            return new StructInstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(method.Method);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Invoke(ref TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5)
        {
            bool isValid = _isValid;
            nint pAddress = _pAddress;
            if (!isValid)
            {
                if (_method.IsOverridable())
                {
                    isValid = REMethodBase.ValidateInstanceVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(_method, target.GetType(), out pAddress) ||
                              (pAddress != 0 && REMethodBase.SecondaryValidateStaticMethod(_method, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), ref pAddress));
                }
                else
                {
                    isValid = (pAddress != 0 && REMethodBase.SecondaryValidateInstanceMethod(_method, target.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), ref pAddress));
                }
                if (!isValid)
                {
                    _method.InvokeInstanceLowAlloc(ref target, arg0, arg1, arg2, arg3, arg4, arg5);
                    return;
                }
            }
            unsafe
            {
                ((delegate*<ref TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, void>)pAddress)(ref target, arg0, arg1, arg2, arg3, arg4, arg5);
                return;
            }
        }
    }
    public readonly struct InstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TReturn>
    {
        private readonly nint _pAddress;
        private readonly bool _isValid;
        private readonly MethodBase _method;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public InstanceMethodPointerFunc(MethodBase method)
        {
            _method = method;
            if (method.IsOverridable())
            {
                _isValid = false;
                _pAddress = 0;
                return;
            }
            _isValid = REMethodBase.ValidateInstanceReturnableMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TReturn>(method, out _pAddress);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator InstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TReturn>(MethodBase method)
        {
            return new InstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TReturn>(method);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator InstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TReturn>(Func<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TReturn> method)
        {
            return new InstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TReturn>(method.Method);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TReturn Invoke(ref TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5)
        {
            bool isValid = _isValid;
            nint pAddress = _pAddress;
            if (!isValid)
            {
                if (_method.IsOverridable())
                {
                    isValid = REMethodBase.ValidateInstanceReturnableVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TReturn>(_method, target?.GetType(), out pAddress) ||
                              (pAddress != 0 && REMethodBase.SecondaryValidateStaticMethod(_method, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), ref pAddress));
                }
                else
                {
                    isValid = (pAddress != 0 && REMethodBase.SecondaryValidateInstanceMethod(_method, target?.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), ref pAddress));
                }
                if (!isValid)
                {
                    return (TReturn)_method.InvokeInstanceLowAlloc(ref target, arg0, arg1, arg2, arg3, arg4, arg5);
                }
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
    }
    public readonly struct ClassInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TReturn>
    where TTarget: class
    {
        private readonly nint _pAddress;
        private readonly bool _isValid;
        private readonly MethodBase _method;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ClassInstanceMethodPointerFunc(MethodBase method)
        {
            _method = method;
            if (method.IsOverridable())
            {
                _isValid = false;
                _pAddress = 0;
                return;
            }
            _isValid = REMethodBase.ValidateInstanceReturnableMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TReturn>(method, out _pAddress);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ClassInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TReturn>(MethodBase method)
        {
            return new ClassInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TReturn>(method);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ClassInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TReturn>(Func<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TReturn> method)
        {
            return new ClassInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TReturn>(method.Method);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TReturn Invoke(TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5)
        {
            bool isValid = _isValid;
            nint pAddress = _pAddress;
            if (!isValid)
            {
                if (_method.IsOverridable())
                {
                    isValid = REMethodBase.ValidateInstanceReturnableVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TReturn>(_method, target?.GetType(), out pAddress) ||
                              (pAddress != 0 && REMethodBase.SecondaryValidateStaticMethod(_method, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), ref pAddress));
                }
                else
                {
                    isValid = (pAddress != 0 && REMethodBase.SecondaryValidateInstanceMethod(_method, target?.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), ref pAddress));
                }
                if (!isValid)
                {
                    return (TReturn)_method.InvokeClassInstanceLowAlloc(target, arg0, arg1, arg2, arg3, arg4, arg5);
                }
            }
            unsafe
            {
                return ((delegate*<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TReturn>)pAddress)(target, arg0, arg1, arg2, arg3, arg4, arg5);
            }
        }
    }
    public readonly struct StructInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TReturn>
    where TTarget: struct
    {
        private readonly nint _pAddress;
        private readonly bool _isValid;
        private readonly MethodBase _method;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public StructInstanceMethodPointerFunc(MethodBase method)
        {
            _method = method;
            if (method.IsOverridable())
            {
                _isValid = false;
                _pAddress = 0;
                return;
            }
            _isValid = REMethodBase.ValidateInstanceReturnableMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TReturn>(method, out _pAddress);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator StructInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TReturn>(MethodBase method)
        {
            return new StructInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TReturn>(method);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator StructInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TReturn>(Func<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TReturn> method)
        {
            return new StructInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TReturn>(method.Method);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TReturn Invoke(ref TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5)
        {
            bool isValid = _isValid;
            nint pAddress = _pAddress;
            if (!isValid)
            {
                if (_method.IsOverridable())
                {
                    isValid = REMethodBase.ValidateInstanceReturnableVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TReturn>(_method, target.GetType(), out pAddress) ||
                              (pAddress != 0 && REMethodBase.SecondaryValidateStaticMethod(_method, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), ref pAddress));
                }
                else
                {
                    isValid = (pAddress != 0 && REMethodBase.SecondaryValidateInstanceMethod(_method, target.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), ref pAddress));
                }
                if (!isValid)
                {
                    return (TReturn)_method.InvokeInstanceLowAlloc(ref target, arg0, arg1, arg2, arg3, arg4, arg5);
                }
            }
            unsafe
            {
                return ((delegate*<ref TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TReturn>)pAddress)(ref target, arg0, arg1, arg2, arg3, arg4, arg5);
            }
        }
    }
    public readonly struct StaticMethodPointerAction<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>
    {
        private readonly nint _pAddress;
        private readonly bool _isValid;
        private readonly MethodBase _method;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public StaticMethodPointerAction(MethodBase method)
        {
            _method = method;
            if (method.IsOverridable())
            {
                _isValid = false;
                _pAddress = 0;
                return;
            }
            _isValid = REMethodBase.ValidateStaticMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(method, out _pAddress);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator StaticMethodPointerAction<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(MethodBase method)
        {
            return new StaticMethodPointerAction<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(method);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator StaticMethodPointerAction<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(Action<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5> method)
        {
            return new StaticMethodPointerAction<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(method.Method);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Invoke(in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5)
        {
            bool isValid = _isValid;
            nint pAddress = _pAddress;
            if (!isValid)
            {
                isValid = (pAddress != 0 && REMethodBase.SecondaryValidateStaticMethod(_method, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), ref pAddress));
                if (!isValid)
                {
                    _method.InvokeStaticLowAlloc(arg0, arg1, arg2, arg3, arg4, arg5);
                    return;
                }
            }
            unsafe
            {
                ((delegate*<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, void>)pAddress)(arg0, arg1, arg2, arg3, arg4, arg5);
                return;
            }
        }
    }
    public readonly struct StaticMethodPointerFunc<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TReturn>
    {
        private readonly nint _pAddress;
        private readonly bool _isValid;
        private readonly MethodBase _method;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public StaticMethodPointerFunc(MethodBase method)
        {
            _method = method;
            if (method.IsOverridable())
            {
                _isValid = false;
                _pAddress = 0;
                return;
            }
            _isValid = REMethodBase.ValidateStaticReturnableMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TReturn>(method, out _pAddress);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator StaticMethodPointerFunc<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TReturn>(MethodBase method)
        {
            return new StaticMethodPointerFunc<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TReturn>(method);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator StaticMethodPointerFunc<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TReturn>(Func<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TReturn> method)
        {
            return new StaticMethodPointerFunc<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TReturn>(method.Method);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TReturn Invoke(in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5)
        {
            bool isValid = _isValid;
            nint pAddress = _pAddress;
            if (!isValid)
            {
                isValid = (pAddress != 0 && REMethodBase.SecondaryValidateStaticMethod(_method, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), ref pAddress));
                if (!isValid)
                {
                    return (TReturn)_method.InvokeStaticLowAlloc(arg0, arg1, arg2, arg3, arg4, arg5);
                }
            }
            unsafe
            {
                return ((delegate*<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TReturn>)pAddress)(arg0, arg1, arg2, arg3, arg4, arg5);
            }
        }
    }
    public readonly struct InstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>
    {
        private readonly nint _pAddress;
        private readonly bool _isValid;
        private readonly MethodBase _method;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public InstanceMethodPointerAction(MethodBase method)
        {
            _method = method;
            if (method.IsOverridable())
            {
                _isValid = false;
                _pAddress = 0;
                return;
            }
            _isValid = REMethodBase.ValidateInstanceMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(method, out _pAddress);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator InstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(MethodBase method)
        {
            return new InstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(method);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator InstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(Action<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6> method)
        {
            return new InstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(method.Method);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Invoke(ref TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6)
        {
            bool isValid = _isValid;
            nint pAddress = _pAddress;
            if (!isValid)
            {
                if (_method.IsOverridable())
                {
                    isValid = REMethodBase.ValidateInstanceVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(_method, target?.GetType(), out pAddress) ||
                              (pAddress != 0 && REMethodBase.SecondaryValidateStaticMethod(_method, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), ref pAddress));
                }
                else
                {
                    isValid = (pAddress != 0 && REMethodBase.SecondaryValidateInstanceMethod(_method, target?.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), ref pAddress));
                }
                if (!isValid)
                {
                    _method.InvokeInstanceLowAlloc(ref target, arg0, arg1, arg2, arg3, arg4, arg5, arg6);
                    return;
                }
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
    }
    public readonly struct ClassInstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>
    where TTarget: class
    {
        private readonly nint _pAddress;
        private readonly bool _isValid;
        private readonly MethodBase _method;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ClassInstanceMethodPointerAction(MethodBase method)
        {
            _method = method;
            if (method.IsOverridable())
            {
                _isValid = false;
                _pAddress = 0;
                return;
            }
            _isValid = REMethodBase.ValidateInstanceMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(method, out _pAddress);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ClassInstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(MethodBase method)
        {
            return new ClassInstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(method);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ClassInstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(Action<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6> method)
        {
            return new ClassInstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(method.Method);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Invoke(TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6)
        {
            bool isValid = _isValid;
            nint pAddress = _pAddress;
            if (!isValid)
            {
                if (_method.IsOverridable())
                {
                    isValid = REMethodBase.ValidateInstanceVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(_method, target?.GetType(), out pAddress) ||
                              (pAddress != 0 && REMethodBase.SecondaryValidateStaticMethod(_method, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), ref pAddress));
                }
                else
                {
                    isValid = (pAddress != 0 && REMethodBase.SecondaryValidateInstanceMethod(_method, target?.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), ref pAddress));
                }
                if (!isValid)
                {
                    _method.InvokeClassInstanceLowAlloc(target, arg0, arg1, arg2, arg3, arg4, arg5, arg6);
                    return;
                }
            }
            unsafe
            {
                ((delegate*<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, void>)pAddress)(target, arg0, arg1, arg2, arg3, arg4, arg5, arg6);
                return;
            }
        }
    }
    public readonly struct StructInstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>
    where TTarget: struct
    {
        private readonly nint _pAddress;
        private readonly bool _isValid;
        private readonly MethodBase _method;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public StructInstanceMethodPointerAction(MethodBase method)
        {
            _method = method;
            if (method.IsOverridable())
            {
                _isValid = false;
                _pAddress = 0;
                return;
            }
            _isValid = REMethodBase.ValidateInstanceMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(method, out _pAddress);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator StructInstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(MethodBase method)
        {
            return new StructInstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(method);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator StructInstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(Action<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6> method)
        {
            return new StructInstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(method.Method);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Invoke(ref TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6)
        {
            bool isValid = _isValid;
            nint pAddress = _pAddress;
            if (!isValid)
            {
                if (_method.IsOverridable())
                {
                    isValid = REMethodBase.ValidateInstanceVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(_method, target.GetType(), out pAddress) ||
                              (pAddress != 0 && REMethodBase.SecondaryValidateStaticMethod(_method, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), ref pAddress));
                }
                else
                {
                    isValid = (pAddress != 0 && REMethodBase.SecondaryValidateInstanceMethod(_method, target.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), ref pAddress));
                }
                if (!isValid)
                {
                    _method.InvokeInstanceLowAlloc(ref target, arg0, arg1, arg2, arg3, arg4, arg5, arg6);
                    return;
                }
            }
            unsafe
            {
                ((delegate*<ref TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, void>)pAddress)(ref target, arg0, arg1, arg2, arg3, arg4, arg5, arg6);
                return;
            }
        }
    }
    public readonly struct InstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TReturn>
    {
        private readonly nint _pAddress;
        private readonly bool _isValid;
        private readonly MethodBase _method;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public InstanceMethodPointerFunc(MethodBase method)
        {
            _method = method;
            if (method.IsOverridable())
            {
                _isValid = false;
                _pAddress = 0;
                return;
            }
            _isValid = REMethodBase.ValidateInstanceReturnableMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TReturn>(method, out _pAddress);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator InstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TReturn>(MethodBase method)
        {
            return new InstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TReturn>(method);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator InstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TReturn>(Func<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TReturn> method)
        {
            return new InstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TReturn>(method.Method);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TReturn Invoke(ref TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6)
        {
            bool isValid = _isValid;
            nint pAddress = _pAddress;
            if (!isValid)
            {
                if (_method.IsOverridable())
                {
                    isValid = REMethodBase.ValidateInstanceReturnableVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TReturn>(_method, target?.GetType(), out pAddress) ||
                              (pAddress != 0 && REMethodBase.SecondaryValidateStaticMethod(_method, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), ref pAddress));
                }
                else
                {
                    isValid = (pAddress != 0 && REMethodBase.SecondaryValidateInstanceMethod(_method, target?.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), ref pAddress));
                }
                if (!isValid)
                {
                    return (TReturn)_method.InvokeInstanceLowAlloc(ref target, arg0, arg1, arg2, arg3, arg4, arg5, arg6);
                }
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
    }
    public readonly struct ClassInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TReturn>
    where TTarget: class
    {
        private readonly nint _pAddress;
        private readonly bool _isValid;
        private readonly MethodBase _method;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ClassInstanceMethodPointerFunc(MethodBase method)
        {
            _method = method;
            if (method.IsOverridable())
            {
                _isValid = false;
                _pAddress = 0;
                return;
            }
            _isValid = REMethodBase.ValidateInstanceReturnableMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TReturn>(method, out _pAddress);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ClassInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TReturn>(MethodBase method)
        {
            return new ClassInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TReturn>(method);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ClassInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TReturn>(Func<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TReturn> method)
        {
            return new ClassInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TReturn>(method.Method);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TReturn Invoke(TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6)
        {
            bool isValid = _isValid;
            nint pAddress = _pAddress;
            if (!isValid)
            {
                if (_method.IsOverridable())
                {
                    isValid = REMethodBase.ValidateInstanceReturnableVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TReturn>(_method, target?.GetType(), out pAddress) ||
                              (pAddress != 0 && REMethodBase.SecondaryValidateStaticMethod(_method, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), ref pAddress));
                }
                else
                {
                    isValid = (pAddress != 0 && REMethodBase.SecondaryValidateInstanceMethod(_method, target?.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), ref pAddress));
                }
                if (!isValid)
                {
                    return (TReturn)_method.InvokeClassInstanceLowAlloc(target, arg0, arg1, arg2, arg3, arg4, arg5, arg6);
                }
            }
            unsafe
            {
                return ((delegate*<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TReturn>)pAddress)(target, arg0, arg1, arg2, arg3, arg4, arg5, arg6);
            }
        }
    }
    public readonly struct StructInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TReturn>
    where TTarget: struct
    {
        private readonly nint _pAddress;
        private readonly bool _isValid;
        private readonly MethodBase _method;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public StructInstanceMethodPointerFunc(MethodBase method)
        {
            _method = method;
            if (method.IsOverridable())
            {
                _isValid = false;
                _pAddress = 0;
                return;
            }
            _isValid = REMethodBase.ValidateInstanceReturnableMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TReturn>(method, out _pAddress);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator StructInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TReturn>(MethodBase method)
        {
            return new StructInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TReturn>(method);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator StructInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TReturn>(Func<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TReturn> method)
        {
            return new StructInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TReturn>(method.Method);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TReturn Invoke(ref TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6)
        {
            bool isValid = _isValid;
            nint pAddress = _pAddress;
            if (!isValid)
            {
                if (_method.IsOverridable())
                {
                    isValid = REMethodBase.ValidateInstanceReturnableVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TReturn>(_method, target.GetType(), out pAddress) ||
                              (pAddress != 0 && REMethodBase.SecondaryValidateStaticMethod(_method, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), ref pAddress));
                }
                else
                {
                    isValid = (pAddress != 0 && REMethodBase.SecondaryValidateInstanceMethod(_method, target.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), ref pAddress));
                }
                if (!isValid)
                {
                    return (TReturn)_method.InvokeInstanceLowAlloc(ref target, arg0, arg1, arg2, arg3, arg4, arg5, arg6);
                }
            }
            unsafe
            {
                return ((delegate*<ref TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TReturn>)pAddress)(ref target, arg0, arg1, arg2, arg3, arg4, arg5, arg6);
            }
        }
    }
    public readonly struct StaticMethodPointerAction<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>
    {
        private readonly nint _pAddress;
        private readonly bool _isValid;
        private readonly MethodBase _method;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public StaticMethodPointerAction(MethodBase method)
        {
            _method = method;
            if (method.IsOverridable())
            {
                _isValid = false;
                _pAddress = 0;
                return;
            }
            _isValid = REMethodBase.ValidateStaticMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(method, out _pAddress);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator StaticMethodPointerAction<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(MethodBase method)
        {
            return new StaticMethodPointerAction<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(method);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator StaticMethodPointerAction<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(Action<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6> method)
        {
            return new StaticMethodPointerAction<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(method.Method);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Invoke(in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6)
        {
            bool isValid = _isValid;
            nint pAddress = _pAddress;
            if (!isValid)
            {
                isValid = (pAddress != 0 && REMethodBase.SecondaryValidateStaticMethod(_method, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), ref pAddress));
                if (!isValid)
                {
                    _method.InvokeStaticLowAlloc(arg0, arg1, arg2, arg3, arg4, arg5, arg6);
                    return;
                }
            }
            unsafe
            {
                ((delegate*<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, void>)pAddress)(arg0, arg1, arg2, arg3, arg4, arg5, arg6);
                return;
            }
        }
    }
    public readonly struct StaticMethodPointerFunc<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TReturn>
    {
        private readonly nint _pAddress;
        private readonly bool _isValid;
        private readonly MethodBase _method;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public StaticMethodPointerFunc(MethodBase method)
        {
            _method = method;
            if (method.IsOverridable())
            {
                _isValid = false;
                _pAddress = 0;
                return;
            }
            _isValid = REMethodBase.ValidateStaticReturnableMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TReturn>(method, out _pAddress);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator StaticMethodPointerFunc<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TReturn>(MethodBase method)
        {
            return new StaticMethodPointerFunc<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TReturn>(method);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator StaticMethodPointerFunc<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TReturn>(Func<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TReturn> method)
        {
            return new StaticMethodPointerFunc<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TReturn>(method.Method);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TReturn Invoke(in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6)
        {
            bool isValid = _isValid;
            nint pAddress = _pAddress;
            if (!isValid)
            {
                isValid = (pAddress != 0 && REMethodBase.SecondaryValidateStaticMethod(_method, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), ref pAddress));
                if (!isValid)
                {
                    return (TReturn)_method.InvokeStaticLowAlloc(arg0, arg1, arg2, arg3, arg4, arg5, arg6);
                }
            }
            unsafe
            {
                return ((delegate*<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TReturn>)pAddress)(arg0, arg1, arg2, arg3, arg4, arg5, arg6);
            }
        }
    }
    public readonly struct InstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>
    {
        private readonly nint _pAddress;
        private readonly bool _isValid;
        private readonly MethodBase _method;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public InstanceMethodPointerAction(MethodBase method)
        {
            _method = method;
            if (method.IsOverridable())
            {
                _isValid = false;
                _pAddress = 0;
                return;
            }
            _isValid = REMethodBase.ValidateInstanceMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(method, out _pAddress);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator InstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(MethodBase method)
        {
            return new InstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(method);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator InstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(Action<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7> method)
        {
            return new InstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(method.Method);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Invoke(ref TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7)
        {
            bool isValid = _isValid;
            nint pAddress = _pAddress;
            if (!isValid)
            {
                if (_method.IsOverridable())
                {
                    isValid = REMethodBase.ValidateInstanceVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(_method, target?.GetType(), out pAddress) ||
                              (pAddress != 0 && REMethodBase.SecondaryValidateStaticMethod(_method, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), ref pAddress));
                }
                else
                {
                    isValid = (pAddress != 0 && REMethodBase.SecondaryValidateInstanceMethod(_method, target?.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), ref pAddress));
                }
                if (!isValid)
                {
                    _method.InvokeInstanceLowAlloc(ref target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
                    return;
                }
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
    }
    public readonly struct ClassInstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>
    where TTarget: class
    {
        private readonly nint _pAddress;
        private readonly bool _isValid;
        private readonly MethodBase _method;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ClassInstanceMethodPointerAction(MethodBase method)
        {
            _method = method;
            if (method.IsOverridable())
            {
                _isValid = false;
                _pAddress = 0;
                return;
            }
            _isValid = REMethodBase.ValidateInstanceMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(method, out _pAddress);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ClassInstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(MethodBase method)
        {
            return new ClassInstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(method);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ClassInstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(Action<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7> method)
        {
            return new ClassInstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(method.Method);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Invoke(TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7)
        {
            bool isValid = _isValid;
            nint pAddress = _pAddress;
            if (!isValid)
            {
                if (_method.IsOverridable())
                {
                    isValid = REMethodBase.ValidateInstanceVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(_method, target?.GetType(), out pAddress) ||
                              (pAddress != 0 && REMethodBase.SecondaryValidateStaticMethod(_method, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), ref pAddress));
                }
                else
                {
                    isValid = (pAddress != 0 && REMethodBase.SecondaryValidateInstanceMethod(_method, target?.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), ref pAddress));
                }
                if (!isValid)
                {
                    _method.InvokeClassInstanceLowAlloc(target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
                    return;
                }
            }
            unsafe
            {
                ((delegate*<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, void>)pAddress)(target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
                return;
            }
        }
    }
    public readonly struct StructInstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>
    where TTarget: struct
    {
        private readonly nint _pAddress;
        private readonly bool _isValid;
        private readonly MethodBase _method;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public StructInstanceMethodPointerAction(MethodBase method)
        {
            _method = method;
            if (method.IsOverridable())
            {
                _isValid = false;
                _pAddress = 0;
                return;
            }
            _isValid = REMethodBase.ValidateInstanceMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(method, out _pAddress);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator StructInstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(MethodBase method)
        {
            return new StructInstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(method);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator StructInstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(Action<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7> method)
        {
            return new StructInstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(method.Method);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Invoke(ref TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7)
        {
            bool isValid = _isValid;
            nint pAddress = _pAddress;
            if (!isValid)
            {
                if (_method.IsOverridable())
                {
                    isValid = REMethodBase.ValidateInstanceVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(_method, target.GetType(), out pAddress) ||
                              (pAddress != 0 && REMethodBase.SecondaryValidateStaticMethod(_method, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), ref pAddress));
                }
                else
                {
                    isValid = (pAddress != 0 && REMethodBase.SecondaryValidateInstanceMethod(_method, target.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), ref pAddress));
                }
                if (!isValid)
                {
                    _method.InvokeInstanceLowAlloc(ref target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
                    return;
                }
            }
            unsafe
            {
                ((delegate*<ref TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, void>)pAddress)(ref target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
                return;
            }
        }
    }
    public readonly struct InstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TReturn>
    {
        private readonly nint _pAddress;
        private readonly bool _isValid;
        private readonly MethodBase _method;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public InstanceMethodPointerFunc(MethodBase method)
        {
            _method = method;
            if (method.IsOverridable())
            {
                _isValid = false;
                _pAddress = 0;
                return;
            }
            _isValid = REMethodBase.ValidateInstanceReturnableMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TReturn>(method, out _pAddress);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator InstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TReturn>(MethodBase method)
        {
            return new InstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TReturn>(method);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator InstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TReturn>(Func<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TReturn> method)
        {
            return new InstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TReturn>(method.Method);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TReturn Invoke(ref TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7)
        {
            bool isValid = _isValid;
            nint pAddress = _pAddress;
            if (!isValid)
            {
                if (_method.IsOverridable())
                {
                    isValid = REMethodBase.ValidateInstanceReturnableVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TReturn>(_method, target?.GetType(), out pAddress) ||
                              (pAddress != 0 && REMethodBase.SecondaryValidateStaticMethod(_method, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), ref pAddress));
                }
                else
                {
                    isValid = (pAddress != 0 && REMethodBase.SecondaryValidateInstanceMethod(_method, target?.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), ref pAddress));
                }
                if (!isValid)
                {
                    return (TReturn)_method.InvokeInstanceLowAlloc(ref target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
                }
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
    }
    public readonly struct ClassInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TReturn>
    where TTarget: class
    {
        private readonly nint _pAddress;
        private readonly bool _isValid;
        private readonly MethodBase _method;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ClassInstanceMethodPointerFunc(MethodBase method)
        {
            _method = method;
            if (method.IsOverridable())
            {
                _isValid = false;
                _pAddress = 0;
                return;
            }
            _isValid = REMethodBase.ValidateInstanceReturnableMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TReturn>(method, out _pAddress);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ClassInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TReturn>(MethodBase method)
        {
            return new ClassInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TReturn>(method);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ClassInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TReturn>(Func<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TReturn> method)
        {
            return new ClassInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TReturn>(method.Method);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TReturn Invoke(TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7)
        {
            bool isValid = _isValid;
            nint pAddress = _pAddress;
            if (!isValid)
            {
                if (_method.IsOverridable())
                {
                    isValid = REMethodBase.ValidateInstanceReturnableVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TReturn>(_method, target?.GetType(), out pAddress) ||
                              (pAddress != 0 && REMethodBase.SecondaryValidateStaticMethod(_method, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), ref pAddress));
                }
                else
                {
                    isValid = (pAddress != 0 && REMethodBase.SecondaryValidateInstanceMethod(_method, target?.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), ref pAddress));
                }
                if (!isValid)
                {
                    return (TReturn)_method.InvokeClassInstanceLowAlloc(target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
                }
            }
            unsafe
            {
                return ((delegate*<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TReturn>)pAddress)(target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
            }
        }
    }
    public readonly struct StructInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TReturn>
    where TTarget: struct
    {
        private readonly nint _pAddress;
        private readonly bool _isValid;
        private readonly MethodBase _method;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public StructInstanceMethodPointerFunc(MethodBase method)
        {
            _method = method;
            if (method.IsOverridable())
            {
                _isValid = false;
                _pAddress = 0;
                return;
            }
            _isValid = REMethodBase.ValidateInstanceReturnableMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TReturn>(method, out _pAddress);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator StructInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TReturn>(MethodBase method)
        {
            return new StructInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TReturn>(method);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator StructInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TReturn>(Func<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TReturn> method)
        {
            return new StructInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TReturn>(method.Method);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TReturn Invoke(ref TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7)
        {
            bool isValid = _isValid;
            nint pAddress = _pAddress;
            if (!isValid)
            {
                if (_method.IsOverridable())
                {
                    isValid = REMethodBase.ValidateInstanceReturnableVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TReturn>(_method, target.GetType(), out pAddress) ||
                              (pAddress != 0 && REMethodBase.SecondaryValidateStaticMethod(_method, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), ref pAddress));
                }
                else
                {
                    isValid = (pAddress != 0 && REMethodBase.SecondaryValidateInstanceMethod(_method, target.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), ref pAddress));
                }
                if (!isValid)
                {
                    return (TReturn)_method.InvokeInstanceLowAlloc(ref target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
                }
            }
            unsafe
            {
                return ((delegate*<ref TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TReturn>)pAddress)(ref target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
            }
        }
    }
    public readonly struct StaticMethodPointerAction<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>
    {
        private readonly nint _pAddress;
        private readonly bool _isValid;
        private readonly MethodBase _method;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public StaticMethodPointerAction(MethodBase method)
        {
            _method = method;
            if (method.IsOverridable())
            {
                _isValid = false;
                _pAddress = 0;
                return;
            }
            _isValid = REMethodBase.ValidateStaticMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(method, out _pAddress);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator StaticMethodPointerAction<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(MethodBase method)
        {
            return new StaticMethodPointerAction<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(method);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator StaticMethodPointerAction<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(Action<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7> method)
        {
            return new StaticMethodPointerAction<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(method.Method);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Invoke(in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7)
        {
            bool isValid = _isValid;
            nint pAddress = _pAddress;
            if (!isValid)
            {
                isValid = (pAddress != 0 && REMethodBase.SecondaryValidateStaticMethod(_method, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), ref pAddress));
                if (!isValid)
                {
                    _method.InvokeStaticLowAlloc(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
                    return;
                }
            }
            unsafe
            {
                ((delegate*<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, void>)pAddress)(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
                return;
            }
        }
    }
    public readonly struct StaticMethodPointerFunc<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TReturn>
    {
        private readonly nint _pAddress;
        private readonly bool _isValid;
        private readonly MethodBase _method;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public StaticMethodPointerFunc(MethodBase method)
        {
            _method = method;
            if (method.IsOverridable())
            {
                _isValid = false;
                _pAddress = 0;
                return;
            }
            _isValid = REMethodBase.ValidateStaticReturnableMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TReturn>(method, out _pAddress);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator StaticMethodPointerFunc<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TReturn>(MethodBase method)
        {
            return new StaticMethodPointerFunc<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TReturn>(method);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator StaticMethodPointerFunc<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TReturn>(Func<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TReturn> method)
        {
            return new StaticMethodPointerFunc<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TReturn>(method.Method);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TReturn Invoke(in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7)
        {
            bool isValid = _isValid;
            nint pAddress = _pAddress;
            if (!isValid)
            {
                isValid = (pAddress != 0 && REMethodBase.SecondaryValidateStaticMethod(_method, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), ref pAddress));
                if (!isValid)
                {
                    return (TReturn)_method.InvokeStaticLowAlloc(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
                }
            }
            unsafe
            {
                return ((delegate*<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TReturn>)pAddress)(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
            }
        }
    }
    public readonly struct InstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>
    {
        private readonly nint _pAddress;
        private readonly bool _isValid;
        private readonly MethodBase _method;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public InstanceMethodPointerAction(MethodBase method)
        {
            _method = method;
            if (method.IsOverridable())
            {
                _isValid = false;
                _pAddress = 0;
                return;
            }
            _isValid = REMethodBase.ValidateInstanceMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(method, out _pAddress);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator InstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(MethodBase method)
        {
            return new InstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(method);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator InstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(Action<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8> method)
        {
            return new InstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(method.Method);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Invoke(ref TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8)
        {
            bool isValid = _isValid;
            nint pAddress = _pAddress;
            if (!isValid)
            {
                if (_method.IsOverridable())
                {
                    isValid = REMethodBase.ValidateInstanceVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(_method, target?.GetType(), out pAddress) ||
                              (pAddress != 0 && REMethodBase.SecondaryValidateStaticMethod(_method, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), ref pAddress));
                }
                else
                {
                    isValid = (pAddress != 0 && REMethodBase.SecondaryValidateInstanceMethod(_method, target?.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), ref pAddress));
                }
                if (!isValid)
                {
                    _method.InvokeInstanceLowAlloc(ref target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
                    return;
                }
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
    }
    public readonly struct ClassInstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>
    where TTarget: class
    {
        private readonly nint _pAddress;
        private readonly bool _isValid;
        private readonly MethodBase _method;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ClassInstanceMethodPointerAction(MethodBase method)
        {
            _method = method;
            if (method.IsOverridable())
            {
                _isValid = false;
                _pAddress = 0;
                return;
            }
            _isValid = REMethodBase.ValidateInstanceMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(method, out _pAddress);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ClassInstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(MethodBase method)
        {
            return new ClassInstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(method);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ClassInstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(Action<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8> method)
        {
            return new ClassInstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(method.Method);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Invoke(TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8)
        {
            bool isValid = _isValid;
            nint pAddress = _pAddress;
            if (!isValid)
            {
                if (_method.IsOverridable())
                {
                    isValid = REMethodBase.ValidateInstanceVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(_method, target?.GetType(), out pAddress) ||
                              (pAddress != 0 && REMethodBase.SecondaryValidateStaticMethod(_method, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), ref pAddress));
                }
                else
                {
                    isValid = (pAddress != 0 && REMethodBase.SecondaryValidateInstanceMethod(_method, target?.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), ref pAddress));
                }
                if (!isValid)
                {
                    _method.InvokeClassInstanceLowAlloc(target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
                    return;
                }
            }
            unsafe
            {
                ((delegate*<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, void>)pAddress)(target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
                return;
            }
        }
    }
    public readonly struct StructInstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>
    where TTarget: struct
    {
        private readonly nint _pAddress;
        private readonly bool _isValid;
        private readonly MethodBase _method;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public StructInstanceMethodPointerAction(MethodBase method)
        {
            _method = method;
            if (method.IsOverridable())
            {
                _isValid = false;
                _pAddress = 0;
                return;
            }
            _isValid = REMethodBase.ValidateInstanceMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(method, out _pAddress);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator StructInstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(MethodBase method)
        {
            return new StructInstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(method);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator StructInstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(Action<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8> method)
        {
            return new StructInstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(method.Method);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Invoke(ref TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8)
        {
            bool isValid = _isValid;
            nint pAddress = _pAddress;
            if (!isValid)
            {
                if (_method.IsOverridable())
                {
                    isValid = REMethodBase.ValidateInstanceVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(_method, target.GetType(), out pAddress) ||
                              (pAddress != 0 && REMethodBase.SecondaryValidateStaticMethod(_method, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), ref pAddress));
                }
                else
                {
                    isValid = (pAddress != 0 && REMethodBase.SecondaryValidateInstanceMethod(_method, target.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), ref pAddress));
                }
                if (!isValid)
                {
                    _method.InvokeInstanceLowAlloc(ref target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
                    return;
                }
            }
            unsafe
            {
                ((delegate*<ref TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, void>)pAddress)(ref target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
                return;
            }
        }
    }
    public readonly struct InstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TReturn>
    {
        private readonly nint _pAddress;
        private readonly bool _isValid;
        private readonly MethodBase _method;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public InstanceMethodPointerFunc(MethodBase method)
        {
            _method = method;
            if (method.IsOverridable())
            {
                _isValid = false;
                _pAddress = 0;
                return;
            }
            _isValid = REMethodBase.ValidateInstanceReturnableMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TReturn>(method, out _pAddress);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator InstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TReturn>(MethodBase method)
        {
            return new InstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TReturn>(method);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator InstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TReturn>(Func<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TReturn> method)
        {
            return new InstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TReturn>(method.Method);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TReturn Invoke(ref TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8)
        {
            bool isValid = _isValid;
            nint pAddress = _pAddress;
            if (!isValid)
            {
                if (_method.IsOverridable())
                {
                    isValid = REMethodBase.ValidateInstanceReturnableVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TReturn>(_method, target?.GetType(), out pAddress) ||
                              (pAddress != 0 && REMethodBase.SecondaryValidateStaticMethod(_method, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), ref pAddress));
                }
                else
                {
                    isValid = (pAddress != 0 && REMethodBase.SecondaryValidateInstanceMethod(_method, target?.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), ref pAddress));
                }
                if (!isValid)
                {
                    return (TReturn)_method.InvokeInstanceLowAlloc(ref target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
                }
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
    }
    public readonly struct ClassInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TReturn>
    where TTarget: class
    {
        private readonly nint _pAddress;
        private readonly bool _isValid;
        private readonly MethodBase _method;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ClassInstanceMethodPointerFunc(MethodBase method)
        {
            _method = method;
            if (method.IsOverridable())
            {
                _isValid = false;
                _pAddress = 0;
                return;
            }
            _isValid = REMethodBase.ValidateInstanceReturnableMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TReturn>(method, out _pAddress);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ClassInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TReturn>(MethodBase method)
        {
            return new ClassInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TReturn>(method);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ClassInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TReturn>(Func<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TReturn> method)
        {
            return new ClassInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TReturn>(method.Method);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TReturn Invoke(TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8)
        {
            bool isValid = _isValid;
            nint pAddress = _pAddress;
            if (!isValid)
            {
                if (_method.IsOverridable())
                {
                    isValid = REMethodBase.ValidateInstanceReturnableVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TReturn>(_method, target?.GetType(), out pAddress) ||
                              (pAddress != 0 && REMethodBase.SecondaryValidateStaticMethod(_method, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), ref pAddress));
                }
                else
                {
                    isValid = (pAddress != 0 && REMethodBase.SecondaryValidateInstanceMethod(_method, target?.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), ref pAddress));
                }
                if (!isValid)
                {
                    return (TReturn)_method.InvokeClassInstanceLowAlloc(target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
                }
            }
            unsafe
            {
                return ((delegate*<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TReturn>)pAddress)(target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
            }
        }
    }
    public readonly struct StructInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TReturn>
    where TTarget: struct
    {
        private readonly nint _pAddress;
        private readonly bool _isValid;
        private readonly MethodBase _method;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public StructInstanceMethodPointerFunc(MethodBase method)
        {
            _method = method;
            if (method.IsOverridable())
            {
                _isValid = false;
                _pAddress = 0;
                return;
            }
            _isValid = REMethodBase.ValidateInstanceReturnableMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TReturn>(method, out _pAddress);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator StructInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TReturn>(MethodBase method)
        {
            return new StructInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TReturn>(method);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator StructInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TReturn>(Func<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TReturn> method)
        {
            return new StructInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TReturn>(method.Method);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TReturn Invoke(ref TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8)
        {
            bool isValid = _isValid;
            nint pAddress = _pAddress;
            if (!isValid)
            {
                if (_method.IsOverridable())
                {
                    isValid = REMethodBase.ValidateInstanceReturnableVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TReturn>(_method, target.GetType(), out pAddress) ||
                              (pAddress != 0 && REMethodBase.SecondaryValidateStaticMethod(_method, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), ref pAddress));
                }
                else
                {
                    isValid = (pAddress != 0 && REMethodBase.SecondaryValidateInstanceMethod(_method, target.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), ref pAddress));
                }
                if (!isValid)
                {
                    return (TReturn)_method.InvokeInstanceLowAlloc(ref target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
                }
            }
            unsafe
            {
                return ((delegate*<ref TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TReturn>)pAddress)(ref target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
            }
        }
    }
    public readonly struct StaticMethodPointerAction<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>
    {
        private readonly nint _pAddress;
        private readonly bool _isValid;
        private readonly MethodBase _method;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public StaticMethodPointerAction(MethodBase method)
        {
            _method = method;
            if (method.IsOverridable())
            {
                _isValid = false;
                _pAddress = 0;
                return;
            }
            _isValid = REMethodBase.ValidateStaticMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(method, out _pAddress);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator StaticMethodPointerAction<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(MethodBase method)
        {
            return new StaticMethodPointerAction<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(method);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator StaticMethodPointerAction<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(Action<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8> method)
        {
            return new StaticMethodPointerAction<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(method.Method);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Invoke(in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8)
        {
            bool isValid = _isValid;
            nint pAddress = _pAddress;
            if (!isValid)
            {
                isValid = (pAddress != 0 && REMethodBase.SecondaryValidateStaticMethod(_method, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), ref pAddress));
                if (!isValid)
                {
                    _method.InvokeStaticLowAlloc(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
                    return;
                }
            }
            unsafe
            {
                ((delegate*<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, void>)pAddress)(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
                return;
            }
        }
    }
    public readonly struct StaticMethodPointerFunc<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TReturn>
    {
        private readonly nint _pAddress;
        private readonly bool _isValid;
        private readonly MethodBase _method;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public StaticMethodPointerFunc(MethodBase method)
        {
            _method = method;
            if (method.IsOverridable())
            {
                _isValid = false;
                _pAddress = 0;
                return;
            }
            _isValid = REMethodBase.ValidateStaticReturnableMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TReturn>(method, out _pAddress);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator StaticMethodPointerFunc<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TReturn>(MethodBase method)
        {
            return new StaticMethodPointerFunc<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TReturn>(method);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator StaticMethodPointerFunc<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TReturn>(Func<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TReturn> method)
        {
            return new StaticMethodPointerFunc<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TReturn>(method.Method);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TReturn Invoke(in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8)
        {
            bool isValid = _isValid;
            nint pAddress = _pAddress;
            if (!isValid)
            {
                isValid = (pAddress != 0 && REMethodBase.SecondaryValidateStaticMethod(_method, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), ref pAddress));
                if (!isValid)
                {
                    return (TReturn)_method.InvokeStaticLowAlloc(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
                }
            }
            unsafe
            {
                return ((delegate*<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TReturn>)pAddress)(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
            }
        }
    }
    public readonly struct InstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>
    {
        private readonly nint _pAddress;
        private readonly bool _isValid;
        private readonly MethodBase _method;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public InstanceMethodPointerAction(MethodBase method)
        {
            _method = method;
            if (method.IsOverridable())
            {
                _isValid = false;
                _pAddress = 0;
                return;
            }
            _isValid = REMethodBase.ValidateInstanceMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(method, out _pAddress);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator InstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(MethodBase method)
        {
            return new InstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(method);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator InstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(Action<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9> method)
        {
            return new InstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(method.Method);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Invoke(ref TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9)
        {
            bool isValid = _isValid;
            nint pAddress = _pAddress;
            if (!isValid)
            {
                if (_method.IsOverridable())
                {
                    isValid = REMethodBase.ValidateInstanceVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(_method, target?.GetType(), out pAddress) ||
                              (pAddress != 0 && REMethodBase.SecondaryValidateStaticMethod(_method, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), ref pAddress));
                }
                else
                {
                    isValid = (pAddress != 0 && REMethodBase.SecondaryValidateInstanceMethod(_method, target?.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), ref pAddress));
                }
                if (!isValid)
                {
                    _method.InvokeInstanceLowAlloc(ref target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
                    return;
                }
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
    }
    public readonly struct ClassInstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>
    where TTarget: class
    {
        private readonly nint _pAddress;
        private readonly bool _isValid;
        private readonly MethodBase _method;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ClassInstanceMethodPointerAction(MethodBase method)
        {
            _method = method;
            if (method.IsOverridable())
            {
                _isValid = false;
                _pAddress = 0;
                return;
            }
            _isValid = REMethodBase.ValidateInstanceMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(method, out _pAddress);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ClassInstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(MethodBase method)
        {
            return new ClassInstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(method);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ClassInstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(Action<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9> method)
        {
            return new ClassInstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(method.Method);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Invoke(TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9)
        {
            bool isValid = _isValid;
            nint pAddress = _pAddress;
            if (!isValid)
            {
                if (_method.IsOverridable())
                {
                    isValid = REMethodBase.ValidateInstanceVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(_method, target?.GetType(), out pAddress) ||
                              (pAddress != 0 && REMethodBase.SecondaryValidateStaticMethod(_method, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), ref pAddress));
                }
                else
                {
                    isValid = (pAddress != 0 && REMethodBase.SecondaryValidateInstanceMethod(_method, target?.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), ref pAddress));
                }
                if (!isValid)
                {
                    _method.InvokeClassInstanceLowAlloc(target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
                    return;
                }
            }
            unsafe
            {
                ((delegate*<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, void>)pAddress)(target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
                return;
            }
        }
    }
    public readonly struct StructInstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>
    where TTarget: struct
    {
        private readonly nint _pAddress;
        private readonly bool _isValid;
        private readonly MethodBase _method;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public StructInstanceMethodPointerAction(MethodBase method)
        {
            _method = method;
            if (method.IsOverridable())
            {
                _isValid = false;
                _pAddress = 0;
                return;
            }
            _isValid = REMethodBase.ValidateInstanceMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(method, out _pAddress);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator StructInstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(MethodBase method)
        {
            return new StructInstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(method);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator StructInstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(Action<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9> method)
        {
            return new StructInstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(method.Method);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Invoke(ref TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9)
        {
            bool isValid = _isValid;
            nint pAddress = _pAddress;
            if (!isValid)
            {
                if (_method.IsOverridable())
                {
                    isValid = REMethodBase.ValidateInstanceVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(_method, target.GetType(), out pAddress) ||
                              (pAddress != 0 && REMethodBase.SecondaryValidateStaticMethod(_method, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), ref pAddress));
                }
                else
                {
                    isValid = (pAddress != 0 && REMethodBase.SecondaryValidateInstanceMethod(_method, target.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), ref pAddress));
                }
                if (!isValid)
                {
                    _method.InvokeInstanceLowAlloc(ref target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
                    return;
                }
            }
            unsafe
            {
                ((delegate*<ref TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, void>)pAddress)(ref target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
                return;
            }
        }
    }
    public readonly struct InstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TReturn>
    {
        private readonly nint _pAddress;
        private readonly bool _isValid;
        private readonly MethodBase _method;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public InstanceMethodPointerFunc(MethodBase method)
        {
            _method = method;
            if (method.IsOverridable())
            {
                _isValid = false;
                _pAddress = 0;
                return;
            }
            _isValid = REMethodBase.ValidateInstanceReturnableMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TReturn>(method, out _pAddress);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator InstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TReturn>(MethodBase method)
        {
            return new InstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TReturn>(method);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator InstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TReturn>(Func<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TReturn> method)
        {
            return new InstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TReturn>(method.Method);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TReturn Invoke(ref TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9)
        {
            bool isValid = _isValid;
            nint pAddress = _pAddress;
            if (!isValid)
            {
                if (_method.IsOverridable())
                {
                    isValid = REMethodBase.ValidateInstanceReturnableVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TReturn>(_method, target?.GetType(), out pAddress) ||
                              (pAddress != 0 && REMethodBase.SecondaryValidateStaticMethod(_method, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), ref pAddress));
                }
                else
                {
                    isValid = (pAddress != 0 && REMethodBase.SecondaryValidateInstanceMethod(_method, target?.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), ref pAddress));
                }
                if (!isValid)
                {
                    return (TReturn)_method.InvokeInstanceLowAlloc(ref target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
                }
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
    }
    public readonly struct ClassInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TReturn>
    where TTarget: class
    {
        private readonly nint _pAddress;
        private readonly bool _isValid;
        private readonly MethodBase _method;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ClassInstanceMethodPointerFunc(MethodBase method)
        {
            _method = method;
            if (method.IsOverridable())
            {
                _isValid = false;
                _pAddress = 0;
                return;
            }
            _isValid = REMethodBase.ValidateInstanceReturnableMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TReturn>(method, out _pAddress);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ClassInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TReturn>(MethodBase method)
        {
            return new ClassInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TReturn>(method);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ClassInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TReturn>(Func<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TReturn> method)
        {
            return new ClassInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TReturn>(method.Method);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TReturn Invoke(TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9)
        {
            bool isValid = _isValid;
            nint pAddress = _pAddress;
            if (!isValid)
            {
                if (_method.IsOverridable())
                {
                    isValid = REMethodBase.ValidateInstanceReturnableVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TReturn>(_method, target?.GetType(), out pAddress) ||
                              (pAddress != 0 && REMethodBase.SecondaryValidateStaticMethod(_method, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), ref pAddress));
                }
                else
                {
                    isValid = (pAddress != 0 && REMethodBase.SecondaryValidateInstanceMethod(_method, target?.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), ref pAddress));
                }
                if (!isValid)
                {
                    return (TReturn)_method.InvokeClassInstanceLowAlloc(target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
                }
            }
            unsafe
            {
                return ((delegate*<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TReturn>)pAddress)(target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
            }
        }
    }
    public readonly struct StructInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TReturn>
    where TTarget: struct
    {
        private readonly nint _pAddress;
        private readonly bool _isValid;
        private readonly MethodBase _method;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public StructInstanceMethodPointerFunc(MethodBase method)
        {
            _method = method;
            if (method.IsOverridable())
            {
                _isValid = false;
                _pAddress = 0;
                return;
            }
            _isValid = REMethodBase.ValidateInstanceReturnableMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TReturn>(method, out _pAddress);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator StructInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TReturn>(MethodBase method)
        {
            return new StructInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TReturn>(method);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator StructInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TReturn>(Func<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TReturn> method)
        {
            return new StructInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TReturn>(method.Method);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TReturn Invoke(ref TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9)
        {
            bool isValid = _isValid;
            nint pAddress = _pAddress;
            if (!isValid)
            {
                if (_method.IsOverridable())
                {
                    isValid = REMethodBase.ValidateInstanceReturnableVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TReturn>(_method, target.GetType(), out pAddress) ||
                              (pAddress != 0 && REMethodBase.SecondaryValidateStaticMethod(_method, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), ref pAddress));
                }
                else
                {
                    isValid = (pAddress != 0 && REMethodBase.SecondaryValidateInstanceMethod(_method, target.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), ref pAddress));
                }
                if (!isValid)
                {
                    return (TReturn)_method.InvokeInstanceLowAlloc(ref target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
                }
            }
            unsafe
            {
                return ((delegate*<ref TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TReturn>)pAddress)(ref target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
            }
        }
    }
    public readonly struct StaticMethodPointerAction<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>
    {
        private readonly nint _pAddress;
        private readonly bool _isValid;
        private readonly MethodBase _method;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public StaticMethodPointerAction(MethodBase method)
        {
            _method = method;
            if (method.IsOverridable())
            {
                _isValid = false;
                _pAddress = 0;
                return;
            }
            _isValid = REMethodBase.ValidateStaticMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(method, out _pAddress);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator StaticMethodPointerAction<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(MethodBase method)
        {
            return new StaticMethodPointerAction<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(method);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator StaticMethodPointerAction<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(Action<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9> method)
        {
            return new StaticMethodPointerAction<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(method.Method);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Invoke(in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9)
        {
            bool isValid = _isValid;
            nint pAddress = _pAddress;
            if (!isValid)
            {
                isValid = (pAddress != 0 && REMethodBase.SecondaryValidateStaticMethod(_method, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), ref pAddress));
                if (!isValid)
                {
                    _method.InvokeStaticLowAlloc(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
                    return;
                }
            }
            unsafe
            {
                ((delegate*<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, void>)pAddress)(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
                return;
            }
        }
    }
    public readonly struct StaticMethodPointerFunc<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TReturn>
    {
        private readonly nint _pAddress;
        private readonly bool _isValid;
        private readonly MethodBase _method;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public StaticMethodPointerFunc(MethodBase method)
        {
            _method = method;
            if (method.IsOverridable())
            {
                _isValid = false;
                _pAddress = 0;
                return;
            }
            _isValid = REMethodBase.ValidateStaticReturnableMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TReturn>(method, out _pAddress);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator StaticMethodPointerFunc<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TReturn>(MethodBase method)
        {
            return new StaticMethodPointerFunc<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TReturn>(method);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator StaticMethodPointerFunc<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TReturn>(Func<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TReturn> method)
        {
            return new StaticMethodPointerFunc<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TReturn>(method.Method);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TReturn Invoke(in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9)
        {
            bool isValid = _isValid;
            nint pAddress = _pAddress;
            if (!isValid)
            {
                isValid = (pAddress != 0 && REMethodBase.SecondaryValidateStaticMethod(_method, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), ref pAddress));
                if (!isValid)
                {
                    return (TReturn)_method.InvokeStaticLowAlloc(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
                }
            }
            unsafe
            {
                return ((delegate*<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TReturn>)pAddress)(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
            }
        }
    }
    public readonly struct InstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>
    {
        private readonly nint _pAddress;
        private readonly bool _isValid;
        private readonly MethodBase _method;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public InstanceMethodPointerAction(MethodBase method)
        {
            _method = method;
            if (method.IsOverridable())
            {
                _isValid = false;
                _pAddress = 0;
                return;
            }
            _isValid = REMethodBase.ValidateInstanceMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(method, out _pAddress);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator InstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(MethodBase method)
        {
            return new InstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(method);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator InstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(Action<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10> method)
        {
            return new InstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(method.Method);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Invoke(ref TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9, in TArg10 arg10)
        {
            bool isValid = _isValid;
            nint pAddress = _pAddress;
            if (!isValid)
            {
                if (_method.IsOverridable())
                {
                    isValid = REMethodBase.ValidateInstanceVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(_method, target?.GetType(), out pAddress) ||
                              (pAddress != 0 && REMethodBase.SecondaryValidateStaticMethod(_method, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), ref pAddress));
                }
                else
                {
                    isValid = (pAddress != 0 && REMethodBase.SecondaryValidateInstanceMethod(_method, target?.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), ref pAddress));
                }
                if (!isValid)
                {
                    _method.InvokeInstanceLowAlloc(ref target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
                    return;
                }
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
    }
    public readonly struct ClassInstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>
    where TTarget: class
    {
        private readonly nint _pAddress;
        private readonly bool _isValid;
        private readonly MethodBase _method;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ClassInstanceMethodPointerAction(MethodBase method)
        {
            _method = method;
            if (method.IsOverridable())
            {
                _isValid = false;
                _pAddress = 0;
                return;
            }
            _isValid = REMethodBase.ValidateInstanceMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(method, out _pAddress);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ClassInstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(MethodBase method)
        {
            return new ClassInstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(method);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ClassInstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(Action<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10> method)
        {
            return new ClassInstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(method.Method);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Invoke(TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9, in TArg10 arg10)
        {
            bool isValid = _isValid;
            nint pAddress = _pAddress;
            if (!isValid)
            {
                if (_method.IsOverridable())
                {
                    isValid = REMethodBase.ValidateInstanceVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(_method, target?.GetType(), out pAddress) ||
                              (pAddress != 0 && REMethodBase.SecondaryValidateStaticMethod(_method, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), ref pAddress));
                }
                else
                {
                    isValid = (pAddress != 0 && REMethodBase.SecondaryValidateInstanceMethod(_method, target?.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), ref pAddress));
                }
                if (!isValid)
                {
                    _method.InvokeClassInstanceLowAlloc(target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
                    return;
                }
            }
            unsafe
            {
                ((delegate*<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, void>)pAddress)(target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
                return;
            }
        }
    }
    public readonly struct StructInstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>
    where TTarget: struct
    {
        private readonly nint _pAddress;
        private readonly bool _isValid;
        private readonly MethodBase _method;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public StructInstanceMethodPointerAction(MethodBase method)
        {
            _method = method;
            if (method.IsOverridable())
            {
                _isValid = false;
                _pAddress = 0;
                return;
            }
            _isValid = REMethodBase.ValidateInstanceMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(method, out _pAddress);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator StructInstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(MethodBase method)
        {
            return new StructInstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(method);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator StructInstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(Action<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10> method)
        {
            return new StructInstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(method.Method);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Invoke(ref TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9, in TArg10 arg10)
        {
            bool isValid = _isValid;
            nint pAddress = _pAddress;
            if (!isValid)
            {
                if (_method.IsOverridable())
                {
                    isValid = REMethodBase.ValidateInstanceVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(_method, target.GetType(), out pAddress) ||
                              (pAddress != 0 && REMethodBase.SecondaryValidateStaticMethod(_method, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), ref pAddress));
                }
                else
                {
                    isValid = (pAddress != 0 && REMethodBase.SecondaryValidateInstanceMethod(_method, target.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), ref pAddress));
                }
                if (!isValid)
                {
                    _method.InvokeInstanceLowAlloc(ref target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
                    return;
                }
            }
            unsafe
            {
                ((delegate*<ref TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, void>)pAddress)(ref target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
                return;
            }
        }
    }
    public readonly struct InstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TReturn>
    {
        private readonly nint _pAddress;
        private readonly bool _isValid;
        private readonly MethodBase _method;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public InstanceMethodPointerFunc(MethodBase method)
        {
            _method = method;
            if (method.IsOverridable())
            {
                _isValid = false;
                _pAddress = 0;
                return;
            }
            _isValid = REMethodBase.ValidateInstanceReturnableMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TReturn>(method, out _pAddress);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator InstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TReturn>(MethodBase method)
        {
            return new InstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TReturn>(method);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator InstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TReturn>(Func<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TReturn> method)
        {
            return new InstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TReturn>(method.Method);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TReturn Invoke(ref TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9, in TArg10 arg10)
        {
            bool isValid = _isValid;
            nint pAddress = _pAddress;
            if (!isValid)
            {
                if (_method.IsOverridable())
                {
                    isValid = REMethodBase.ValidateInstanceReturnableVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TReturn>(_method, target?.GetType(), out pAddress) ||
                              (pAddress != 0 && REMethodBase.SecondaryValidateStaticMethod(_method, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), ref pAddress));
                }
                else
                {
                    isValid = (pAddress != 0 && REMethodBase.SecondaryValidateInstanceMethod(_method, target?.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), ref pAddress));
                }
                if (!isValid)
                {
                    return (TReturn)_method.InvokeInstanceLowAlloc(ref target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
                }
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
    }
    public readonly struct ClassInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TReturn>
    where TTarget: class
    {
        private readonly nint _pAddress;
        private readonly bool _isValid;
        private readonly MethodBase _method;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ClassInstanceMethodPointerFunc(MethodBase method)
        {
            _method = method;
            if (method.IsOverridable())
            {
                _isValid = false;
                _pAddress = 0;
                return;
            }
            _isValid = REMethodBase.ValidateInstanceReturnableMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TReturn>(method, out _pAddress);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ClassInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TReturn>(MethodBase method)
        {
            return new ClassInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TReturn>(method);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ClassInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TReturn>(Func<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TReturn> method)
        {
            return new ClassInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TReturn>(method.Method);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TReturn Invoke(TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9, in TArg10 arg10)
        {
            bool isValid = _isValid;
            nint pAddress = _pAddress;
            if (!isValid)
            {
                if (_method.IsOverridable())
                {
                    isValid = REMethodBase.ValidateInstanceReturnableVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TReturn>(_method, target?.GetType(), out pAddress) ||
                              (pAddress != 0 && REMethodBase.SecondaryValidateStaticMethod(_method, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), ref pAddress));
                }
                else
                {
                    isValid = (pAddress != 0 && REMethodBase.SecondaryValidateInstanceMethod(_method, target?.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), ref pAddress));
                }
                if (!isValid)
                {
                    return (TReturn)_method.InvokeClassInstanceLowAlloc(target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
                }
            }
            unsafe
            {
                return ((delegate*<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TReturn>)pAddress)(target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
            }
        }
    }
    public readonly struct StructInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TReturn>
    where TTarget: struct
    {
        private readonly nint _pAddress;
        private readonly bool _isValid;
        private readonly MethodBase _method;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public StructInstanceMethodPointerFunc(MethodBase method)
        {
            _method = method;
            if (method.IsOverridable())
            {
                _isValid = false;
                _pAddress = 0;
                return;
            }
            _isValid = REMethodBase.ValidateInstanceReturnableMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TReturn>(method, out _pAddress);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator StructInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TReturn>(MethodBase method)
        {
            return new StructInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TReturn>(method);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator StructInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TReturn>(Func<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TReturn> method)
        {
            return new StructInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TReturn>(method.Method);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TReturn Invoke(ref TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9, in TArg10 arg10)
        {
            bool isValid = _isValid;
            nint pAddress = _pAddress;
            if (!isValid)
            {
                if (_method.IsOverridable())
                {
                    isValid = REMethodBase.ValidateInstanceReturnableVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TReturn>(_method, target.GetType(), out pAddress) ||
                              (pAddress != 0 && REMethodBase.SecondaryValidateStaticMethod(_method, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), ref pAddress));
                }
                else
                {
                    isValid = (pAddress != 0 && REMethodBase.SecondaryValidateInstanceMethod(_method, target.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), ref pAddress));
                }
                if (!isValid)
                {
                    return (TReturn)_method.InvokeInstanceLowAlloc(ref target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
                }
            }
            unsafe
            {
                return ((delegate*<ref TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TReturn>)pAddress)(ref target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
            }
        }
    }
    public readonly struct StaticMethodPointerAction<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>
    {
        private readonly nint _pAddress;
        private readonly bool _isValid;
        private readonly MethodBase _method;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public StaticMethodPointerAction(MethodBase method)
        {
            _method = method;
            if (method.IsOverridable())
            {
                _isValid = false;
                _pAddress = 0;
                return;
            }
            _isValid = REMethodBase.ValidateStaticMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(method, out _pAddress);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator StaticMethodPointerAction<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(MethodBase method)
        {
            return new StaticMethodPointerAction<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(method);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator StaticMethodPointerAction<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(Action<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10> method)
        {
            return new StaticMethodPointerAction<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(method.Method);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Invoke(in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9, in TArg10 arg10)
        {
            bool isValid = _isValid;
            nint pAddress = _pAddress;
            if (!isValid)
            {
                isValid = (pAddress != 0 && REMethodBase.SecondaryValidateStaticMethod(_method, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), ref pAddress));
                if (!isValid)
                {
                    _method.InvokeStaticLowAlloc(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
                    return;
                }
            }
            unsafe
            {
                ((delegate*<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, void>)pAddress)(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
                return;
            }
        }
    }
    public readonly struct StaticMethodPointerFunc<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TReturn>
    {
        private readonly nint _pAddress;
        private readonly bool _isValid;
        private readonly MethodBase _method;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public StaticMethodPointerFunc(MethodBase method)
        {
            _method = method;
            if (method.IsOverridable())
            {
                _isValid = false;
                _pAddress = 0;
                return;
            }
            _isValid = REMethodBase.ValidateStaticReturnableMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TReturn>(method, out _pAddress);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator StaticMethodPointerFunc<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TReturn>(MethodBase method)
        {
            return new StaticMethodPointerFunc<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TReturn>(method);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator StaticMethodPointerFunc<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TReturn>(Func<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TReturn> method)
        {
            return new StaticMethodPointerFunc<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TReturn>(method.Method);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TReturn Invoke(in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9, in TArg10 arg10)
        {
            bool isValid = _isValid;
            nint pAddress = _pAddress;
            if (!isValid)
            {
                isValid = (pAddress != 0 && REMethodBase.SecondaryValidateStaticMethod(_method, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), ref pAddress));
                if (!isValid)
                {
                    return (TReturn)_method.InvokeStaticLowAlloc(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
                }
            }
            unsafe
            {
                return ((delegate*<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TReturn>)pAddress)(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
            }
        }
    }
    public readonly struct InstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>
    {
        private readonly nint _pAddress;
        private readonly bool _isValid;
        private readonly MethodBase _method;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public InstanceMethodPointerAction(MethodBase method)
        {
            _method = method;
            if (method.IsOverridable())
            {
                _isValid = false;
                _pAddress = 0;
                return;
            }
            _isValid = REMethodBase.ValidateInstanceMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(method, out _pAddress);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator InstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(MethodBase method)
        {
            return new InstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(method);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator InstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(Action<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11> method)
        {
            return new InstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(method.Method);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Invoke(ref TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9, in TArg10 arg10, in TArg11 arg11)
        {
            bool isValid = _isValid;
            nint pAddress = _pAddress;
            if (!isValid)
            {
                if (_method.IsOverridable())
                {
                    isValid = REMethodBase.ValidateInstanceVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(_method, target?.GetType(), out pAddress) ||
                              (pAddress != 0 && REMethodBase.SecondaryValidateStaticMethod(_method, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), arg11?.GetType(), ref pAddress));
                }
                else
                {
                    isValid = (pAddress != 0 && REMethodBase.SecondaryValidateInstanceMethod(_method, target?.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), arg11?.GetType(), ref pAddress));
                }
                if (!isValid)
                {
                    _method.InvokeInstanceLowAlloc(ref target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
                    return;
                }
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
    }
    public readonly struct ClassInstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>
    where TTarget: class
    {
        private readonly nint _pAddress;
        private readonly bool _isValid;
        private readonly MethodBase _method;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ClassInstanceMethodPointerAction(MethodBase method)
        {
            _method = method;
            if (method.IsOverridable())
            {
                _isValid = false;
                _pAddress = 0;
                return;
            }
            _isValid = REMethodBase.ValidateInstanceMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(method, out _pAddress);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ClassInstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(MethodBase method)
        {
            return new ClassInstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(method);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ClassInstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(Action<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11> method)
        {
            return new ClassInstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(method.Method);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Invoke(TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9, in TArg10 arg10, in TArg11 arg11)
        {
            bool isValid = _isValid;
            nint pAddress = _pAddress;
            if (!isValid)
            {
                if (_method.IsOverridable())
                {
                    isValid = REMethodBase.ValidateInstanceVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(_method, target?.GetType(), out pAddress) ||
                              (pAddress != 0 && REMethodBase.SecondaryValidateStaticMethod(_method, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), arg11?.GetType(), ref pAddress));
                }
                else
                {
                    isValid = (pAddress != 0 && REMethodBase.SecondaryValidateInstanceMethod(_method, target?.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), arg11?.GetType(), ref pAddress));
                }
                if (!isValid)
                {
                    _method.InvokeClassInstanceLowAlloc(target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
                    return;
                }
            }
            unsafe
            {
                ((delegate*<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, void>)pAddress)(target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
                return;
            }
        }
    }
    public readonly struct StructInstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>
    where TTarget: struct
    {
        private readonly nint _pAddress;
        private readonly bool _isValid;
        private readonly MethodBase _method;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public StructInstanceMethodPointerAction(MethodBase method)
        {
            _method = method;
            if (method.IsOverridable())
            {
                _isValid = false;
                _pAddress = 0;
                return;
            }
            _isValid = REMethodBase.ValidateInstanceMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(method, out _pAddress);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator StructInstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(MethodBase method)
        {
            return new StructInstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(method);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator StructInstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(Action<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11> method)
        {
            return new StructInstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(method.Method);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Invoke(ref TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9, in TArg10 arg10, in TArg11 arg11)
        {
            bool isValid = _isValid;
            nint pAddress = _pAddress;
            if (!isValid)
            {
                if (_method.IsOverridable())
                {
                    isValid = REMethodBase.ValidateInstanceVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(_method, target.GetType(), out pAddress) ||
                              (pAddress != 0 && REMethodBase.SecondaryValidateStaticMethod(_method, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), arg11?.GetType(), ref pAddress));
                }
                else
                {
                    isValid = (pAddress != 0 && REMethodBase.SecondaryValidateInstanceMethod(_method, target.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), arg11?.GetType(), ref pAddress));
                }
                if (!isValid)
                {
                    _method.InvokeInstanceLowAlloc(ref target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
                    return;
                }
            }
            unsafe
            {
                ((delegate*<ref TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, void>)pAddress)(ref target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
                return;
            }
        }
    }
    public readonly struct InstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TReturn>
    {
        private readonly nint _pAddress;
        private readonly bool _isValid;
        private readonly MethodBase _method;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public InstanceMethodPointerFunc(MethodBase method)
        {
            _method = method;
            if (method.IsOverridable())
            {
                _isValid = false;
                _pAddress = 0;
                return;
            }
            _isValid = REMethodBase.ValidateInstanceReturnableMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TReturn>(method, out _pAddress);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator InstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TReturn>(MethodBase method)
        {
            return new InstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TReturn>(method);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator InstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TReturn>(Func<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TReturn> method)
        {
            return new InstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TReturn>(method.Method);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TReturn Invoke(ref TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9, in TArg10 arg10, in TArg11 arg11)
        {
            bool isValid = _isValid;
            nint pAddress = _pAddress;
            if (!isValid)
            {
                if (_method.IsOverridable())
                {
                    isValid = REMethodBase.ValidateInstanceReturnableVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TReturn>(_method, target?.GetType(), out pAddress) ||
                              (pAddress != 0 && REMethodBase.SecondaryValidateStaticMethod(_method, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), arg11?.GetType(), ref pAddress));
                }
                else
                {
                    isValid = (pAddress != 0 && REMethodBase.SecondaryValidateInstanceMethod(_method, target?.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), arg11?.GetType(), ref pAddress));
                }
                if (!isValid)
                {
                    return (TReturn)_method.InvokeInstanceLowAlloc(ref target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
                }
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
    }
    public readonly struct ClassInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TReturn>
    where TTarget: class
    {
        private readonly nint _pAddress;
        private readonly bool _isValid;
        private readonly MethodBase _method;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ClassInstanceMethodPointerFunc(MethodBase method)
        {
            _method = method;
            if (method.IsOverridable())
            {
                _isValid = false;
                _pAddress = 0;
                return;
            }
            _isValid = REMethodBase.ValidateInstanceReturnableMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TReturn>(method, out _pAddress);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ClassInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TReturn>(MethodBase method)
        {
            return new ClassInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TReturn>(method);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ClassInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TReturn>(Func<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TReturn> method)
        {
            return new ClassInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TReturn>(method.Method);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TReturn Invoke(TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9, in TArg10 arg10, in TArg11 arg11)
        {
            bool isValid = _isValid;
            nint pAddress = _pAddress;
            if (!isValid)
            {
                if (_method.IsOverridable())
                {
                    isValid = REMethodBase.ValidateInstanceReturnableVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TReturn>(_method, target?.GetType(), out pAddress) ||
                              (pAddress != 0 && REMethodBase.SecondaryValidateStaticMethod(_method, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), arg11?.GetType(), ref pAddress));
                }
                else
                {
                    isValid = (pAddress != 0 && REMethodBase.SecondaryValidateInstanceMethod(_method, target?.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), arg11?.GetType(), ref pAddress));
                }
                if (!isValid)
                {
                    return (TReturn)_method.InvokeClassInstanceLowAlloc(target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
                }
            }
            unsafe
            {
                return ((delegate*<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TReturn>)pAddress)(target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
            }
        }
    }
    public readonly struct StructInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TReturn>
    where TTarget: struct
    {
        private readonly nint _pAddress;
        private readonly bool _isValid;
        private readonly MethodBase _method;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public StructInstanceMethodPointerFunc(MethodBase method)
        {
            _method = method;
            if (method.IsOverridable())
            {
                _isValid = false;
                _pAddress = 0;
                return;
            }
            _isValid = REMethodBase.ValidateInstanceReturnableMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TReturn>(method, out _pAddress);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator StructInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TReturn>(MethodBase method)
        {
            return new StructInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TReturn>(method);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator StructInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TReturn>(Func<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TReturn> method)
        {
            return new StructInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TReturn>(method.Method);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TReturn Invoke(ref TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9, in TArg10 arg10, in TArg11 arg11)
        {
            bool isValid = _isValid;
            nint pAddress = _pAddress;
            if (!isValid)
            {
                if (_method.IsOverridable())
                {
                    isValid = REMethodBase.ValidateInstanceReturnableVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TReturn>(_method, target.GetType(), out pAddress) ||
                              (pAddress != 0 && REMethodBase.SecondaryValidateStaticMethod(_method, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), arg11?.GetType(), ref pAddress));
                }
                else
                {
                    isValid = (pAddress != 0 && REMethodBase.SecondaryValidateInstanceMethod(_method, target.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), arg11?.GetType(), ref pAddress));
                }
                if (!isValid)
                {
                    return (TReturn)_method.InvokeInstanceLowAlloc(ref target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
                }
            }
            unsafe
            {
                return ((delegate*<ref TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TReturn>)pAddress)(ref target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
            }
        }
    }
    public readonly struct StaticMethodPointerAction<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>
    {
        private readonly nint _pAddress;
        private readonly bool _isValid;
        private readonly MethodBase _method;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public StaticMethodPointerAction(MethodBase method)
        {
            _method = method;
            if (method.IsOverridable())
            {
                _isValid = false;
                _pAddress = 0;
                return;
            }
            _isValid = REMethodBase.ValidateStaticMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(method, out _pAddress);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator StaticMethodPointerAction<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(MethodBase method)
        {
            return new StaticMethodPointerAction<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(method);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator StaticMethodPointerAction<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(Action<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11> method)
        {
            return new StaticMethodPointerAction<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(method.Method);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Invoke(in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9, in TArg10 arg10, in TArg11 arg11)
        {
            bool isValid = _isValid;
            nint pAddress = _pAddress;
            if (!isValid)
            {
                isValid = (pAddress != 0 && REMethodBase.SecondaryValidateStaticMethod(_method, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), arg11?.GetType(), ref pAddress));
                if (!isValid)
                {
                    _method.InvokeStaticLowAlloc(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
                    return;
                }
            }
            unsafe
            {
                ((delegate*<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, void>)pAddress)(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
                return;
            }
        }
    }
    public readonly struct StaticMethodPointerFunc<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TReturn>
    {
        private readonly nint _pAddress;
        private readonly bool _isValid;
        private readonly MethodBase _method;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public StaticMethodPointerFunc(MethodBase method)
        {
            _method = method;
            if (method.IsOverridable())
            {
                _isValid = false;
                _pAddress = 0;
                return;
            }
            _isValid = REMethodBase.ValidateStaticReturnableMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TReturn>(method, out _pAddress);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator StaticMethodPointerFunc<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TReturn>(MethodBase method)
        {
            return new StaticMethodPointerFunc<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TReturn>(method);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator StaticMethodPointerFunc<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TReturn>(Func<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TReturn> method)
        {
            return new StaticMethodPointerFunc<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TReturn>(method.Method);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TReturn Invoke(in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9, in TArg10 arg10, in TArg11 arg11)
        {
            bool isValid = _isValid;
            nint pAddress = _pAddress;
            if (!isValid)
            {
                isValid = (pAddress != 0 && REMethodBase.SecondaryValidateStaticMethod(_method, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), arg11?.GetType(), ref pAddress));
                if (!isValid)
                {
                    return (TReturn)_method.InvokeStaticLowAlloc(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
                }
            }
            unsafe
            {
                return ((delegate*<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TReturn>)pAddress)(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
            }
        }
    }
    public readonly struct InstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>
    {
        private readonly nint _pAddress;
        private readonly bool _isValid;
        private readonly MethodBase _method;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public InstanceMethodPointerAction(MethodBase method)
        {
            _method = method;
            if (method.IsOverridable())
            {
                _isValid = false;
                _pAddress = 0;
                return;
            }
            _isValid = REMethodBase.ValidateInstanceMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(method, out _pAddress);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator InstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(MethodBase method)
        {
            return new InstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(method);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator InstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(Action<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12> method)
        {
            return new InstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(method.Method);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Invoke(ref TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9, in TArg10 arg10, in TArg11 arg11, in TArg12 arg12)
        {
            bool isValid = _isValid;
            nint pAddress = _pAddress;
            if (!isValid)
            {
                if (_method.IsOverridable())
                {
                    isValid = REMethodBase.ValidateInstanceVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(_method, target?.GetType(), out pAddress) ||
                              (pAddress != 0 && REMethodBase.SecondaryValidateStaticMethod(_method, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), arg11?.GetType(), arg12?.GetType(), ref pAddress));
                }
                else
                {
                    isValid = (pAddress != 0 && REMethodBase.SecondaryValidateInstanceMethod(_method, target?.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), arg11?.GetType(), arg12?.GetType(), ref pAddress));
                }
                if (!isValid)
                {
                    _method.InvokeInstanceLowAlloc(ref target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
                    return;
                }
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
    }
    public readonly struct ClassInstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>
    where TTarget: class
    {
        private readonly nint _pAddress;
        private readonly bool _isValid;
        private readonly MethodBase _method;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ClassInstanceMethodPointerAction(MethodBase method)
        {
            _method = method;
            if (method.IsOverridable())
            {
                _isValid = false;
                _pAddress = 0;
                return;
            }
            _isValid = REMethodBase.ValidateInstanceMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(method, out _pAddress);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ClassInstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(MethodBase method)
        {
            return new ClassInstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(method);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ClassInstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(Action<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12> method)
        {
            return new ClassInstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(method.Method);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Invoke(TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9, in TArg10 arg10, in TArg11 arg11, in TArg12 arg12)
        {
            bool isValid = _isValid;
            nint pAddress = _pAddress;
            if (!isValid)
            {
                if (_method.IsOverridable())
                {
                    isValid = REMethodBase.ValidateInstanceVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(_method, target?.GetType(), out pAddress) ||
                              (pAddress != 0 && REMethodBase.SecondaryValidateStaticMethod(_method, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), arg11?.GetType(), arg12?.GetType(), ref pAddress));
                }
                else
                {
                    isValid = (pAddress != 0 && REMethodBase.SecondaryValidateInstanceMethod(_method, target?.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), arg11?.GetType(), arg12?.GetType(), ref pAddress));
                }
                if (!isValid)
                {
                    _method.InvokeClassInstanceLowAlloc(target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
                    return;
                }
            }
            unsafe
            {
                ((delegate*<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, void>)pAddress)(target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
                return;
            }
        }
    }
    public readonly struct StructInstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>
    where TTarget: struct
    {
        private readonly nint _pAddress;
        private readonly bool _isValid;
        private readonly MethodBase _method;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public StructInstanceMethodPointerAction(MethodBase method)
        {
            _method = method;
            if (method.IsOverridable())
            {
                _isValid = false;
                _pAddress = 0;
                return;
            }
            _isValid = REMethodBase.ValidateInstanceMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(method, out _pAddress);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator StructInstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(MethodBase method)
        {
            return new StructInstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(method);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator StructInstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(Action<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12> method)
        {
            return new StructInstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(method.Method);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Invoke(ref TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9, in TArg10 arg10, in TArg11 arg11, in TArg12 arg12)
        {
            bool isValid = _isValid;
            nint pAddress = _pAddress;
            if (!isValid)
            {
                if (_method.IsOverridable())
                {
                    isValid = REMethodBase.ValidateInstanceVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(_method, target.GetType(), out pAddress) ||
                              (pAddress != 0 && REMethodBase.SecondaryValidateStaticMethod(_method, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), arg11?.GetType(), arg12?.GetType(), ref pAddress));
                }
                else
                {
                    isValid = (pAddress != 0 && REMethodBase.SecondaryValidateInstanceMethod(_method, target.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), arg11?.GetType(), arg12?.GetType(), ref pAddress));
                }
                if (!isValid)
                {
                    _method.InvokeInstanceLowAlloc(ref target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
                    return;
                }
            }
            unsafe
            {
                ((delegate*<ref TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, void>)pAddress)(ref target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
                return;
            }
        }
    }
    public readonly struct InstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TReturn>
    {
        private readonly nint _pAddress;
        private readonly bool _isValid;
        private readonly MethodBase _method;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public InstanceMethodPointerFunc(MethodBase method)
        {
            _method = method;
            if (method.IsOverridable())
            {
                _isValid = false;
                _pAddress = 0;
                return;
            }
            _isValid = REMethodBase.ValidateInstanceReturnableMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TReturn>(method, out _pAddress);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator InstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TReturn>(MethodBase method)
        {
            return new InstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TReturn>(method);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator InstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TReturn>(Func<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TReturn> method)
        {
            return new InstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TReturn>(method.Method);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TReturn Invoke(ref TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9, in TArg10 arg10, in TArg11 arg11, in TArg12 arg12)
        {
            bool isValid = _isValid;
            nint pAddress = _pAddress;
            if (!isValid)
            {
                if (_method.IsOverridable())
                {
                    isValid = REMethodBase.ValidateInstanceReturnableVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TReturn>(_method, target?.GetType(), out pAddress) ||
                              (pAddress != 0 && REMethodBase.SecondaryValidateStaticMethod(_method, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), arg11?.GetType(), arg12?.GetType(), ref pAddress));
                }
                else
                {
                    isValid = (pAddress != 0 && REMethodBase.SecondaryValidateInstanceMethod(_method, target?.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), arg11?.GetType(), arg12?.GetType(), ref pAddress));
                }
                if (!isValid)
                {
                    return (TReturn)_method.InvokeInstanceLowAlloc(ref target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
                }
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
    }
    public readonly struct ClassInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TReturn>
    where TTarget: class
    {
        private readonly nint _pAddress;
        private readonly bool _isValid;
        private readonly MethodBase _method;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ClassInstanceMethodPointerFunc(MethodBase method)
        {
            _method = method;
            if (method.IsOverridable())
            {
                _isValid = false;
                _pAddress = 0;
                return;
            }
            _isValid = REMethodBase.ValidateInstanceReturnableMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TReturn>(method, out _pAddress);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ClassInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TReturn>(MethodBase method)
        {
            return new ClassInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TReturn>(method);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ClassInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TReturn>(Func<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TReturn> method)
        {
            return new ClassInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TReturn>(method.Method);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TReturn Invoke(TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9, in TArg10 arg10, in TArg11 arg11, in TArg12 arg12)
        {
            bool isValid = _isValid;
            nint pAddress = _pAddress;
            if (!isValid)
            {
                if (_method.IsOverridable())
                {
                    isValid = REMethodBase.ValidateInstanceReturnableVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TReturn>(_method, target?.GetType(), out pAddress) ||
                              (pAddress != 0 && REMethodBase.SecondaryValidateStaticMethod(_method, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), arg11?.GetType(), arg12?.GetType(), ref pAddress));
                }
                else
                {
                    isValid = (pAddress != 0 && REMethodBase.SecondaryValidateInstanceMethod(_method, target?.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), arg11?.GetType(), arg12?.GetType(), ref pAddress));
                }
                if (!isValid)
                {
                    return (TReturn)_method.InvokeClassInstanceLowAlloc(target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
                }
            }
            unsafe
            {
                return ((delegate*<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TReturn>)pAddress)(target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
            }
        }
    }
    public readonly struct StructInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TReturn>
    where TTarget: struct
    {
        private readonly nint _pAddress;
        private readonly bool _isValid;
        private readonly MethodBase _method;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public StructInstanceMethodPointerFunc(MethodBase method)
        {
            _method = method;
            if (method.IsOverridable())
            {
                _isValid = false;
                _pAddress = 0;
                return;
            }
            _isValid = REMethodBase.ValidateInstanceReturnableMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TReturn>(method, out _pAddress);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator StructInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TReturn>(MethodBase method)
        {
            return new StructInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TReturn>(method);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator StructInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TReturn>(Func<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TReturn> method)
        {
            return new StructInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TReturn>(method.Method);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TReturn Invoke(ref TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9, in TArg10 arg10, in TArg11 arg11, in TArg12 arg12)
        {
            bool isValid = _isValid;
            nint pAddress = _pAddress;
            if (!isValid)
            {
                if (_method.IsOverridable())
                {
                    isValid = REMethodBase.ValidateInstanceReturnableVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TReturn>(_method, target.GetType(), out pAddress) ||
                              (pAddress != 0 && REMethodBase.SecondaryValidateStaticMethod(_method, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), arg11?.GetType(), arg12?.GetType(), ref pAddress));
                }
                else
                {
                    isValid = (pAddress != 0 && REMethodBase.SecondaryValidateInstanceMethod(_method, target.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), arg11?.GetType(), arg12?.GetType(), ref pAddress));
                }
                if (!isValid)
                {
                    return (TReturn)_method.InvokeInstanceLowAlloc(ref target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
                }
            }
            unsafe
            {
                return ((delegate*<ref TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TReturn>)pAddress)(ref target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
            }
        }
    }
    public readonly struct StaticMethodPointerAction<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>
    {
        private readonly nint _pAddress;
        private readonly bool _isValid;
        private readonly MethodBase _method;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public StaticMethodPointerAction(MethodBase method)
        {
            _method = method;
            if (method.IsOverridable())
            {
                _isValid = false;
                _pAddress = 0;
                return;
            }
            _isValid = REMethodBase.ValidateStaticMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(method, out _pAddress);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator StaticMethodPointerAction<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(MethodBase method)
        {
            return new StaticMethodPointerAction<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(method);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator StaticMethodPointerAction<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(Action<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12> method)
        {
            return new StaticMethodPointerAction<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(method.Method);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Invoke(in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9, in TArg10 arg10, in TArg11 arg11, in TArg12 arg12)
        {
            bool isValid = _isValid;
            nint pAddress = _pAddress;
            if (!isValid)
            {
                isValid = (pAddress != 0 && REMethodBase.SecondaryValidateStaticMethod(_method, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), arg11?.GetType(), arg12?.GetType(), ref pAddress));
                if (!isValid)
                {
                    _method.InvokeStaticLowAlloc(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
                    return;
                }
            }
            unsafe
            {
                ((delegate*<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, void>)pAddress)(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
                return;
            }
        }
    }
    public readonly struct StaticMethodPointerFunc<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TReturn>
    {
        private readonly nint _pAddress;
        private readonly bool _isValid;
        private readonly MethodBase _method;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public StaticMethodPointerFunc(MethodBase method)
        {
            _method = method;
            if (method.IsOverridable())
            {
                _isValid = false;
                _pAddress = 0;
                return;
            }
            _isValid = REMethodBase.ValidateStaticReturnableMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TReturn>(method, out _pAddress);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator StaticMethodPointerFunc<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TReturn>(MethodBase method)
        {
            return new StaticMethodPointerFunc<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TReturn>(method);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator StaticMethodPointerFunc<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TReturn>(Func<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TReturn> method)
        {
            return new StaticMethodPointerFunc<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TReturn>(method.Method);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TReturn Invoke(in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9, in TArg10 arg10, in TArg11 arg11, in TArg12 arg12)
        {
            bool isValid = _isValid;
            nint pAddress = _pAddress;
            if (!isValid)
            {
                isValid = (pAddress != 0 && REMethodBase.SecondaryValidateStaticMethod(_method, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), arg11?.GetType(), arg12?.GetType(), ref pAddress));
                if (!isValid)
                {
                    return (TReturn)_method.InvokeStaticLowAlloc(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
                }
            }
            unsafe
            {
                return ((delegate*<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TReturn>)pAddress)(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
            }
        }
    }
    public readonly struct InstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>
    {
        private readonly nint _pAddress;
        private readonly bool _isValid;
        private readonly MethodBase _method;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public InstanceMethodPointerAction(MethodBase method)
        {
            _method = method;
            if (method.IsOverridable())
            {
                _isValid = false;
                _pAddress = 0;
                return;
            }
            _isValid = REMethodBase.ValidateInstanceMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(method, out _pAddress);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator InstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(MethodBase method)
        {
            return new InstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(method);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator InstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(Action<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13> method)
        {
            return new InstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(method.Method);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Invoke(ref TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9, in TArg10 arg10, in TArg11 arg11, in TArg12 arg12, in TArg13 arg13)
        {
            bool isValid = _isValid;
            nint pAddress = _pAddress;
            if (!isValid)
            {
                if (_method.IsOverridable())
                {
                    isValid = REMethodBase.ValidateInstanceVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(_method, target?.GetType(), out pAddress) ||
                              (pAddress != 0 && REMethodBase.SecondaryValidateStaticMethod(_method, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), arg11?.GetType(), arg12?.GetType(), arg13?.GetType(), ref pAddress));
                }
                else
                {
                    isValid = (pAddress != 0 && REMethodBase.SecondaryValidateInstanceMethod(_method, target?.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), arg11?.GetType(), arg12?.GetType(), arg13?.GetType(), ref pAddress));
                }
                if (!isValid)
                {
                    _method.InvokeInstanceLowAlloc(ref target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
                    return;
                }
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
    }
    public readonly struct ClassInstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>
    where TTarget: class
    {
        private readonly nint _pAddress;
        private readonly bool _isValid;
        private readonly MethodBase _method;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ClassInstanceMethodPointerAction(MethodBase method)
        {
            _method = method;
            if (method.IsOverridable())
            {
                _isValid = false;
                _pAddress = 0;
                return;
            }
            _isValid = REMethodBase.ValidateInstanceMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(method, out _pAddress);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ClassInstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(MethodBase method)
        {
            return new ClassInstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(method);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ClassInstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(Action<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13> method)
        {
            return new ClassInstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(method.Method);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Invoke(TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9, in TArg10 arg10, in TArg11 arg11, in TArg12 arg12, in TArg13 arg13)
        {
            bool isValid = _isValid;
            nint pAddress = _pAddress;
            if (!isValid)
            {
                if (_method.IsOverridable())
                {
                    isValid = REMethodBase.ValidateInstanceVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(_method, target?.GetType(), out pAddress) ||
                              (pAddress != 0 && REMethodBase.SecondaryValidateStaticMethod(_method, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), arg11?.GetType(), arg12?.GetType(), arg13?.GetType(), ref pAddress));
                }
                else
                {
                    isValid = (pAddress != 0 && REMethodBase.SecondaryValidateInstanceMethod(_method, target?.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), arg11?.GetType(), arg12?.GetType(), arg13?.GetType(), ref pAddress));
                }
                if (!isValid)
                {
                    _method.InvokeClassInstanceLowAlloc(target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
                    return;
                }
            }
            unsafe
            {
                ((delegate*<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, void>)pAddress)(target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
                return;
            }
        }
    }
    public readonly struct StructInstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>
    where TTarget: struct
    {
        private readonly nint _pAddress;
        private readonly bool _isValid;
        private readonly MethodBase _method;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public StructInstanceMethodPointerAction(MethodBase method)
        {
            _method = method;
            if (method.IsOverridable())
            {
                _isValid = false;
                _pAddress = 0;
                return;
            }
            _isValid = REMethodBase.ValidateInstanceMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(method, out _pAddress);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator StructInstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(MethodBase method)
        {
            return new StructInstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(method);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator StructInstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(Action<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13> method)
        {
            return new StructInstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(method.Method);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Invoke(ref TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9, in TArg10 arg10, in TArg11 arg11, in TArg12 arg12, in TArg13 arg13)
        {
            bool isValid = _isValid;
            nint pAddress = _pAddress;
            if (!isValid)
            {
                if (_method.IsOverridable())
                {
                    isValid = REMethodBase.ValidateInstanceVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(_method, target.GetType(), out pAddress) ||
                              (pAddress != 0 && REMethodBase.SecondaryValidateStaticMethod(_method, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), arg11?.GetType(), arg12?.GetType(), arg13?.GetType(), ref pAddress));
                }
                else
                {
                    isValid = (pAddress != 0 && REMethodBase.SecondaryValidateInstanceMethod(_method, target.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), arg11?.GetType(), arg12?.GetType(), arg13?.GetType(), ref pAddress));
                }
                if (!isValid)
                {
                    _method.InvokeInstanceLowAlloc(ref target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
                    return;
                }
            }
            unsafe
            {
                ((delegate*<ref TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, void>)pAddress)(ref target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
                return;
            }
        }
    }
    public readonly struct InstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TReturn>
    {
        private readonly nint _pAddress;
        private readonly bool _isValid;
        private readonly MethodBase _method;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public InstanceMethodPointerFunc(MethodBase method)
        {
            _method = method;
            if (method.IsOverridable())
            {
                _isValid = false;
                _pAddress = 0;
                return;
            }
            _isValid = REMethodBase.ValidateInstanceReturnableMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TReturn>(method, out _pAddress);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator InstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TReturn>(MethodBase method)
        {
            return new InstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TReturn>(method);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator InstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TReturn>(Func<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TReturn> method)
        {
            return new InstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TReturn>(method.Method);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TReturn Invoke(ref TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9, in TArg10 arg10, in TArg11 arg11, in TArg12 arg12, in TArg13 arg13)
        {
            bool isValid = _isValid;
            nint pAddress = _pAddress;
            if (!isValid)
            {
                if (_method.IsOverridable())
                {
                    isValid = REMethodBase.ValidateInstanceReturnableVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TReturn>(_method, target?.GetType(), out pAddress) ||
                              (pAddress != 0 && REMethodBase.SecondaryValidateStaticMethod(_method, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), arg11?.GetType(), arg12?.GetType(), arg13?.GetType(), ref pAddress));
                }
                else
                {
                    isValid = (pAddress != 0 && REMethodBase.SecondaryValidateInstanceMethod(_method, target?.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), arg11?.GetType(), arg12?.GetType(), arg13?.GetType(), ref pAddress));
                }
                if (!isValid)
                {
                    return (TReturn)_method.InvokeInstanceLowAlloc(ref target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
                }
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
    }
    public readonly struct ClassInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TReturn>
    where TTarget: class
    {
        private readonly nint _pAddress;
        private readonly bool _isValid;
        private readonly MethodBase _method;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ClassInstanceMethodPointerFunc(MethodBase method)
        {
            _method = method;
            if (method.IsOverridable())
            {
                _isValid = false;
                _pAddress = 0;
                return;
            }
            _isValid = REMethodBase.ValidateInstanceReturnableMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TReturn>(method, out _pAddress);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ClassInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TReturn>(MethodBase method)
        {
            return new ClassInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TReturn>(method);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ClassInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TReturn>(Func<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TReturn> method)
        {
            return new ClassInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TReturn>(method.Method);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TReturn Invoke(TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9, in TArg10 arg10, in TArg11 arg11, in TArg12 arg12, in TArg13 arg13)
        {
            bool isValid = _isValid;
            nint pAddress = _pAddress;
            if (!isValid)
            {
                if (_method.IsOverridable())
                {
                    isValid = REMethodBase.ValidateInstanceReturnableVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TReturn>(_method, target?.GetType(), out pAddress) ||
                              (pAddress != 0 && REMethodBase.SecondaryValidateStaticMethod(_method, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), arg11?.GetType(), arg12?.GetType(), arg13?.GetType(), ref pAddress));
                }
                else
                {
                    isValid = (pAddress != 0 && REMethodBase.SecondaryValidateInstanceMethod(_method, target?.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), arg11?.GetType(), arg12?.GetType(), arg13?.GetType(), ref pAddress));
                }
                if (!isValid)
                {
                    return (TReturn)_method.InvokeClassInstanceLowAlloc(target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
                }
            }
            unsafe
            {
                return ((delegate*<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TReturn>)pAddress)(target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
            }
        }
    }
    public readonly struct StructInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TReturn>
    where TTarget: struct
    {
        private readonly nint _pAddress;
        private readonly bool _isValid;
        private readonly MethodBase _method;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public StructInstanceMethodPointerFunc(MethodBase method)
        {
            _method = method;
            if (method.IsOverridable())
            {
                _isValid = false;
                _pAddress = 0;
                return;
            }
            _isValid = REMethodBase.ValidateInstanceReturnableMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TReturn>(method, out _pAddress);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator StructInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TReturn>(MethodBase method)
        {
            return new StructInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TReturn>(method);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator StructInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TReturn>(Func<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TReturn> method)
        {
            return new StructInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TReturn>(method.Method);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TReturn Invoke(ref TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9, in TArg10 arg10, in TArg11 arg11, in TArg12 arg12, in TArg13 arg13)
        {
            bool isValid = _isValid;
            nint pAddress = _pAddress;
            if (!isValid)
            {
                if (_method.IsOverridable())
                {
                    isValid = REMethodBase.ValidateInstanceReturnableVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TReturn>(_method, target.GetType(), out pAddress) ||
                              (pAddress != 0 && REMethodBase.SecondaryValidateStaticMethod(_method, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), arg11?.GetType(), arg12?.GetType(), arg13?.GetType(), ref pAddress));
                }
                else
                {
                    isValid = (pAddress != 0 && REMethodBase.SecondaryValidateInstanceMethod(_method, target.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), arg11?.GetType(), arg12?.GetType(), arg13?.GetType(), ref pAddress));
                }
                if (!isValid)
                {
                    return (TReturn)_method.InvokeInstanceLowAlloc(ref target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
                }
            }
            unsafe
            {
                return ((delegate*<ref TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TReturn>)pAddress)(ref target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
            }
        }
    }
    public readonly struct StaticMethodPointerAction<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>
    {
        private readonly nint _pAddress;
        private readonly bool _isValid;
        private readonly MethodBase _method;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public StaticMethodPointerAction(MethodBase method)
        {
            _method = method;
            if (method.IsOverridable())
            {
                _isValid = false;
                _pAddress = 0;
                return;
            }
            _isValid = REMethodBase.ValidateStaticMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(method, out _pAddress);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator StaticMethodPointerAction<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(MethodBase method)
        {
            return new StaticMethodPointerAction<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(method);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator StaticMethodPointerAction<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(Action<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13> method)
        {
            return new StaticMethodPointerAction<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(method.Method);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Invoke(in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9, in TArg10 arg10, in TArg11 arg11, in TArg12 arg12, in TArg13 arg13)
        {
            bool isValid = _isValid;
            nint pAddress = _pAddress;
            if (!isValid)
            {
                isValid = (pAddress != 0 && REMethodBase.SecondaryValidateStaticMethod(_method, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), arg11?.GetType(), arg12?.GetType(), arg13?.GetType(), ref pAddress));
                if (!isValid)
                {
                    _method.InvokeStaticLowAlloc(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
                    return;
                }
            }
            unsafe
            {
                ((delegate*<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, void>)pAddress)(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
                return;
            }
        }
    }
    public readonly struct StaticMethodPointerFunc<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TReturn>
    {
        private readonly nint _pAddress;
        private readonly bool _isValid;
        private readonly MethodBase _method;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public StaticMethodPointerFunc(MethodBase method)
        {
            _method = method;
            if (method.IsOverridable())
            {
                _isValid = false;
                _pAddress = 0;
                return;
            }
            _isValid = REMethodBase.ValidateStaticReturnableMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TReturn>(method, out _pAddress);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator StaticMethodPointerFunc<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TReturn>(MethodBase method)
        {
            return new StaticMethodPointerFunc<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TReturn>(method);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator StaticMethodPointerFunc<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TReturn>(Func<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TReturn> method)
        {
            return new StaticMethodPointerFunc<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TReturn>(method.Method);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TReturn Invoke(in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9, in TArg10 arg10, in TArg11 arg11, in TArg12 arg12, in TArg13 arg13)
        {
            bool isValid = _isValid;
            nint pAddress = _pAddress;
            if (!isValid)
            {
                isValid = (pAddress != 0 && REMethodBase.SecondaryValidateStaticMethod(_method, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), arg11?.GetType(), arg12?.GetType(), arg13?.GetType(), ref pAddress));
                if (!isValid)
                {
                    return (TReturn)_method.InvokeStaticLowAlloc(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
                }
            }
            unsafe
            {
                return ((delegate*<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TReturn>)pAddress)(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
            }
        }
    }
    public readonly struct InstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>
    {
        private readonly nint _pAddress;
        private readonly bool _isValid;
        private readonly MethodBase _method;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public InstanceMethodPointerAction(MethodBase method)
        {
            _method = method;
            if (method.IsOverridable())
            {
                _isValid = false;
                _pAddress = 0;
                return;
            }
            _isValid = REMethodBase.ValidateInstanceMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(method, out _pAddress);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator InstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(MethodBase method)
        {
            return new InstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(method);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator InstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(Action<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14> method)
        {
            return new InstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(method.Method);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Invoke(ref TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9, in TArg10 arg10, in TArg11 arg11, in TArg12 arg12, in TArg13 arg13, in TArg14 arg14)
        {
            bool isValid = _isValid;
            nint pAddress = _pAddress;
            if (!isValid)
            {
                if (_method.IsOverridable())
                {
                    isValid = REMethodBase.ValidateInstanceVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(_method, target?.GetType(), out pAddress) ||
                              (pAddress != 0 && REMethodBase.SecondaryValidateStaticMethod(_method, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), arg11?.GetType(), arg12?.GetType(), arg13?.GetType(), arg14?.GetType(), ref pAddress));
                }
                else
                {
                    isValid = (pAddress != 0 && REMethodBase.SecondaryValidateInstanceMethod(_method, target?.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), arg11?.GetType(), arg12?.GetType(), arg13?.GetType(), arg14?.GetType(), ref pAddress));
                }
                if (!isValid)
                {
                    _method.InvokeInstanceLowAlloc(ref target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
                    return;
                }
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
    }
    public readonly struct ClassInstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>
    where TTarget: class
    {
        private readonly nint _pAddress;
        private readonly bool _isValid;
        private readonly MethodBase _method;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ClassInstanceMethodPointerAction(MethodBase method)
        {
            _method = method;
            if (method.IsOverridable())
            {
                _isValid = false;
                _pAddress = 0;
                return;
            }
            _isValid = REMethodBase.ValidateInstanceMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(method, out _pAddress);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ClassInstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(MethodBase method)
        {
            return new ClassInstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(method);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ClassInstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(Action<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14> method)
        {
            return new ClassInstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(method.Method);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Invoke(TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9, in TArg10 arg10, in TArg11 arg11, in TArg12 arg12, in TArg13 arg13, in TArg14 arg14)
        {
            bool isValid = _isValid;
            nint pAddress = _pAddress;
            if (!isValid)
            {
                if (_method.IsOverridable())
                {
                    isValid = REMethodBase.ValidateInstanceVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(_method, target?.GetType(), out pAddress) ||
                              (pAddress != 0 && REMethodBase.SecondaryValidateStaticMethod(_method, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), arg11?.GetType(), arg12?.GetType(), arg13?.GetType(), arg14?.GetType(), ref pAddress));
                }
                else
                {
                    isValid = (pAddress != 0 && REMethodBase.SecondaryValidateInstanceMethod(_method, target?.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), arg11?.GetType(), arg12?.GetType(), arg13?.GetType(), arg14?.GetType(), ref pAddress));
                }
                if (!isValid)
                {
                    _method.InvokeClassInstanceLowAlloc(target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
                    return;
                }
            }
            unsafe
            {
                ((delegate*<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, void>)pAddress)(target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
                return;
            }
        }
    }
    public readonly struct StructInstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>
    where TTarget: struct
    {
        private readonly nint _pAddress;
        private readonly bool _isValid;
        private readonly MethodBase _method;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public StructInstanceMethodPointerAction(MethodBase method)
        {
            _method = method;
            if (method.IsOverridable())
            {
                _isValid = false;
                _pAddress = 0;
                return;
            }
            _isValid = REMethodBase.ValidateInstanceMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(method, out _pAddress);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator StructInstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(MethodBase method)
        {
            return new StructInstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(method);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator StructInstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(Action<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14> method)
        {
            return new StructInstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(method.Method);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Invoke(ref TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9, in TArg10 arg10, in TArg11 arg11, in TArg12 arg12, in TArg13 arg13, in TArg14 arg14)
        {
            bool isValid = _isValid;
            nint pAddress = _pAddress;
            if (!isValid)
            {
                if (_method.IsOverridable())
                {
                    isValid = REMethodBase.ValidateInstanceVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(_method, target.GetType(), out pAddress) ||
                              (pAddress != 0 && REMethodBase.SecondaryValidateStaticMethod(_method, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), arg11?.GetType(), arg12?.GetType(), arg13?.GetType(), arg14?.GetType(), ref pAddress));
                }
                else
                {
                    isValid = (pAddress != 0 && REMethodBase.SecondaryValidateInstanceMethod(_method, target.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), arg11?.GetType(), arg12?.GetType(), arg13?.GetType(), arg14?.GetType(), ref pAddress));
                }
                if (!isValid)
                {
                    _method.InvokeInstanceLowAlloc(ref target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
                    return;
                }
            }
            unsafe
            {
                ((delegate*<ref TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, void>)pAddress)(ref target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
                return;
            }
        }
    }
    public readonly struct InstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TReturn>
    {
        private readonly nint _pAddress;
        private readonly bool _isValid;
        private readonly MethodBase _method;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public InstanceMethodPointerFunc(MethodBase method)
        {
            _method = method;
            if (method.IsOverridable())
            {
                _isValid = false;
                _pAddress = 0;
                return;
            }
            _isValid = REMethodBase.ValidateInstanceReturnableMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TReturn>(method, out _pAddress);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator InstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TReturn>(MethodBase method)
        {
            return new InstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TReturn>(method);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator InstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TReturn>(Func<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TReturn> method)
        {
            return new InstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TReturn>(method.Method);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TReturn Invoke(ref TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9, in TArg10 arg10, in TArg11 arg11, in TArg12 arg12, in TArg13 arg13, in TArg14 arg14)
        {
            bool isValid = _isValid;
            nint pAddress = _pAddress;
            if (!isValid)
            {
                if (_method.IsOverridable())
                {
                    isValid = REMethodBase.ValidateInstanceReturnableVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TReturn>(_method, target?.GetType(), out pAddress) ||
                              (pAddress != 0 && REMethodBase.SecondaryValidateStaticMethod(_method, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), arg11?.GetType(), arg12?.GetType(), arg13?.GetType(), arg14?.GetType(), ref pAddress));
                }
                else
                {
                    isValid = (pAddress != 0 && REMethodBase.SecondaryValidateInstanceMethod(_method, target?.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), arg11?.GetType(), arg12?.GetType(), arg13?.GetType(), arg14?.GetType(), ref pAddress));
                }
                if (!isValid)
                {
                    return (TReturn)_method.InvokeInstanceLowAlloc(ref target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
                }
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
    }
    public readonly struct ClassInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TReturn>
    where TTarget: class
    {
        private readonly nint _pAddress;
        private readonly bool _isValid;
        private readonly MethodBase _method;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ClassInstanceMethodPointerFunc(MethodBase method)
        {
            _method = method;
            if (method.IsOverridable())
            {
                _isValid = false;
                _pAddress = 0;
                return;
            }
            _isValid = REMethodBase.ValidateInstanceReturnableMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TReturn>(method, out _pAddress);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ClassInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TReturn>(MethodBase method)
        {
            return new ClassInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TReturn>(method);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ClassInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TReturn>(Func<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TReturn> method)
        {
            return new ClassInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TReturn>(method.Method);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TReturn Invoke(TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9, in TArg10 arg10, in TArg11 arg11, in TArg12 arg12, in TArg13 arg13, in TArg14 arg14)
        {
            bool isValid = _isValid;
            nint pAddress = _pAddress;
            if (!isValid)
            {
                if (_method.IsOverridable())
                {
                    isValid = REMethodBase.ValidateInstanceReturnableVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TReturn>(_method, target?.GetType(), out pAddress) ||
                              (pAddress != 0 && REMethodBase.SecondaryValidateStaticMethod(_method, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), arg11?.GetType(), arg12?.GetType(), arg13?.GetType(), arg14?.GetType(), ref pAddress));
                }
                else
                {
                    isValid = (pAddress != 0 && REMethodBase.SecondaryValidateInstanceMethod(_method, target?.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), arg11?.GetType(), arg12?.GetType(), arg13?.GetType(), arg14?.GetType(), ref pAddress));
                }
                if (!isValid)
                {
                    return (TReturn)_method.InvokeClassInstanceLowAlloc(target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
                }
            }
            unsafe
            {
                return ((delegate*<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TReturn>)pAddress)(target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
            }
        }
    }
    public readonly struct StructInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TReturn>
    where TTarget: struct
    {
        private readonly nint _pAddress;
        private readonly bool _isValid;
        private readonly MethodBase _method;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public StructInstanceMethodPointerFunc(MethodBase method)
        {
            _method = method;
            if (method.IsOverridable())
            {
                _isValid = false;
                _pAddress = 0;
                return;
            }
            _isValid = REMethodBase.ValidateInstanceReturnableMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TReturn>(method, out _pAddress);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator StructInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TReturn>(MethodBase method)
        {
            return new StructInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TReturn>(method);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator StructInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TReturn>(Func<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TReturn> method)
        {
            return new StructInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TReturn>(method.Method);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TReturn Invoke(ref TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9, in TArg10 arg10, in TArg11 arg11, in TArg12 arg12, in TArg13 arg13, in TArg14 arg14)
        {
            bool isValid = _isValid;
            nint pAddress = _pAddress;
            if (!isValid)
            {
                if (_method.IsOverridable())
                {
                    isValid = REMethodBase.ValidateInstanceReturnableVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TReturn>(_method, target.GetType(), out pAddress) ||
                              (pAddress != 0 && REMethodBase.SecondaryValidateStaticMethod(_method, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), arg11?.GetType(), arg12?.GetType(), arg13?.GetType(), arg14?.GetType(), ref pAddress));
                }
                else
                {
                    isValid = (pAddress != 0 && REMethodBase.SecondaryValidateInstanceMethod(_method, target.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), arg11?.GetType(), arg12?.GetType(), arg13?.GetType(), arg14?.GetType(), ref pAddress));
                }
                if (!isValid)
                {
                    return (TReturn)_method.InvokeInstanceLowAlloc(ref target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
                }
            }
            unsafe
            {
                return ((delegate*<ref TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TReturn>)pAddress)(ref target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
            }
        }
    }
    public readonly struct StaticMethodPointerAction<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>
    {
        private readonly nint _pAddress;
        private readonly bool _isValid;
        private readonly MethodBase _method;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public StaticMethodPointerAction(MethodBase method)
        {
            _method = method;
            if (method.IsOverridable())
            {
                _isValid = false;
                _pAddress = 0;
                return;
            }
            _isValid = REMethodBase.ValidateStaticMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(method, out _pAddress);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator StaticMethodPointerAction<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(MethodBase method)
        {
            return new StaticMethodPointerAction<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(method);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator StaticMethodPointerAction<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(Action<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14> method)
        {
            return new StaticMethodPointerAction<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(method.Method);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Invoke(in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9, in TArg10 arg10, in TArg11 arg11, in TArg12 arg12, in TArg13 arg13, in TArg14 arg14)
        {
            bool isValid = _isValid;
            nint pAddress = _pAddress;
            if (!isValid)
            {
                isValid = (pAddress != 0 && REMethodBase.SecondaryValidateStaticMethod(_method, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), arg11?.GetType(), arg12?.GetType(), arg13?.GetType(), arg14?.GetType(), ref pAddress));
                if (!isValid)
                {
                    _method.InvokeStaticLowAlloc(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
                    return;
                }
            }
            unsafe
            {
                ((delegate*<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, void>)pAddress)(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
                return;
            }
        }
    }
    public readonly struct StaticMethodPointerFunc<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TReturn>
    {
        private readonly nint _pAddress;
        private readonly bool _isValid;
        private readonly MethodBase _method;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public StaticMethodPointerFunc(MethodBase method)
        {
            _method = method;
            if (method.IsOverridable())
            {
                _isValid = false;
                _pAddress = 0;
                return;
            }
            _isValid = REMethodBase.ValidateStaticReturnableMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TReturn>(method, out _pAddress);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator StaticMethodPointerFunc<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TReturn>(MethodBase method)
        {
            return new StaticMethodPointerFunc<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TReturn>(method);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator StaticMethodPointerFunc<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TReturn>(Func<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TReturn> method)
        {
            return new StaticMethodPointerFunc<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TReturn>(method.Method);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TReturn Invoke(in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9, in TArg10 arg10, in TArg11 arg11, in TArg12 arg12, in TArg13 arg13, in TArg14 arg14)
        {
            bool isValid = _isValid;
            nint pAddress = _pAddress;
            if (!isValid)
            {
                isValid = (pAddress != 0 && REMethodBase.SecondaryValidateStaticMethod(_method, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), arg11?.GetType(), arg12?.GetType(), arg13?.GetType(), arg14?.GetType(), ref pAddress));
                if (!isValid)
                {
                    return (TReturn)_method.InvokeStaticLowAlloc(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
                }
            }
            unsafe
            {
                return ((delegate*<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TReturn>)pAddress)(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
            }
        }
    }
    public readonly struct InstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>
    {
        private readonly nint _pAddress;
        private readonly bool _isValid;
        private readonly MethodBase _method;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public InstanceMethodPointerAction(MethodBase method)
        {
            _method = method;
            if (method.IsOverridable())
            {
                _isValid = false;
                _pAddress = 0;
                return;
            }
            _isValid = REMethodBase.ValidateInstanceMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(method, out _pAddress);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator InstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(MethodBase method)
        {
            return new InstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(method);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator InstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(Action<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15> method)
        {
            return new InstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(method.Method);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Invoke(ref TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9, in TArg10 arg10, in TArg11 arg11, in TArg12 arg12, in TArg13 arg13, in TArg14 arg14, in TArg15 arg15)
        {
            bool isValid = _isValid;
            nint pAddress = _pAddress;
            if (!isValid)
            {
                if (_method.IsOverridable())
                {
                    isValid = REMethodBase.ValidateInstanceVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(_method, target?.GetType(), out pAddress) ||
                              (pAddress != 0 && REMethodBase.SecondaryValidateStaticMethod(_method, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), arg11?.GetType(), arg12?.GetType(), arg13?.GetType(), arg14?.GetType(), arg15?.GetType(), ref pAddress));
                }
                else
                {
                    isValid = (pAddress != 0 && REMethodBase.SecondaryValidateInstanceMethod(_method, target?.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), arg11?.GetType(), arg12?.GetType(), arg13?.GetType(), arg14?.GetType(), arg15?.GetType(), ref pAddress));
                }
                if (!isValid)
                {
                    _method.InvokeInstanceLowAlloc(ref target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15);
                    return;
                }
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
    }
    public readonly struct ClassInstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>
    where TTarget: class
    {
        private readonly nint _pAddress;
        private readonly bool _isValid;
        private readonly MethodBase _method;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ClassInstanceMethodPointerAction(MethodBase method)
        {
            _method = method;
            if (method.IsOverridable())
            {
                _isValid = false;
                _pAddress = 0;
                return;
            }
            _isValid = REMethodBase.ValidateInstanceMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(method, out _pAddress);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ClassInstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(MethodBase method)
        {
            return new ClassInstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(method);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ClassInstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(Action<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15> method)
        {
            return new ClassInstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(method.Method);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Invoke(TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9, in TArg10 arg10, in TArg11 arg11, in TArg12 arg12, in TArg13 arg13, in TArg14 arg14, in TArg15 arg15)
        {
            bool isValid = _isValid;
            nint pAddress = _pAddress;
            if (!isValid)
            {
                if (_method.IsOverridable())
                {
                    isValid = REMethodBase.ValidateInstanceVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(_method, target?.GetType(), out pAddress) ||
                              (pAddress != 0 && REMethodBase.SecondaryValidateStaticMethod(_method, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), arg11?.GetType(), arg12?.GetType(), arg13?.GetType(), arg14?.GetType(), arg15?.GetType(), ref pAddress));
                }
                else
                {
                    isValid = (pAddress != 0 && REMethodBase.SecondaryValidateInstanceMethod(_method, target?.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), arg11?.GetType(), arg12?.GetType(), arg13?.GetType(), arg14?.GetType(), arg15?.GetType(), ref pAddress));
                }
                if (!isValid)
                {
                    _method.InvokeClassInstanceLowAlloc(target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15);
                    return;
                }
            }
            unsafe
            {
                ((delegate*<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, void>)pAddress)(target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15);
                return;
            }
        }
    }
    public readonly struct StructInstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>
    where TTarget: struct
    {
        private readonly nint _pAddress;
        private readonly bool _isValid;
        private readonly MethodBase _method;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public StructInstanceMethodPointerAction(MethodBase method)
        {
            _method = method;
            if (method.IsOverridable())
            {
                _isValid = false;
                _pAddress = 0;
                return;
            }
            _isValid = REMethodBase.ValidateInstanceMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(method, out _pAddress);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator StructInstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(MethodBase method)
        {
            return new StructInstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(method);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator StructInstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(Action<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15> method)
        {
            return new StructInstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(method.Method);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Invoke(ref TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9, in TArg10 arg10, in TArg11 arg11, in TArg12 arg12, in TArg13 arg13, in TArg14 arg14, in TArg15 arg15)
        {
            bool isValid = _isValid;
            nint pAddress = _pAddress;
            if (!isValid)
            {
                if (_method.IsOverridable())
                {
                    isValid = REMethodBase.ValidateInstanceVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(_method, target.GetType(), out pAddress) ||
                              (pAddress != 0 && REMethodBase.SecondaryValidateStaticMethod(_method, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), arg11?.GetType(), arg12?.GetType(), arg13?.GetType(), arg14?.GetType(), arg15?.GetType(), ref pAddress));
                }
                else
                {
                    isValid = (pAddress != 0 && REMethodBase.SecondaryValidateInstanceMethod(_method, target.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), arg11?.GetType(), arg12?.GetType(), arg13?.GetType(), arg14?.GetType(), arg15?.GetType(), ref pAddress));
                }
                if (!isValid)
                {
                    _method.InvokeInstanceLowAlloc(ref target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15);
                    return;
                }
            }
            unsafe
            {
                ((delegate*<ref TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, void>)pAddress)(ref target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15);
                return;
            }
        }
    }
    public readonly struct InstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, TReturn>
    {
        private readonly nint _pAddress;
        private readonly bool _isValid;
        private readonly MethodBase _method;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public InstanceMethodPointerFunc(MethodBase method)
        {
            _method = method;
            if (method.IsOverridable())
            {
                _isValid = false;
                _pAddress = 0;
                return;
            }
            _isValid = REMethodBase.ValidateInstanceReturnableMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, TReturn>(method, out _pAddress);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator InstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, TReturn>(MethodBase method)
        {
            return new InstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, TReturn>(method);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator InstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, TReturn>(Func<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, TReturn> method)
        {
            return new InstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, TReturn>(method.Method);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TReturn Invoke(ref TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9, in TArg10 arg10, in TArg11 arg11, in TArg12 arg12, in TArg13 arg13, in TArg14 arg14, in TArg15 arg15)
        {
            bool isValid = _isValid;
            nint pAddress = _pAddress;
            if (!isValid)
            {
                if (_method.IsOverridable())
                {
                    isValid = REMethodBase.ValidateInstanceReturnableVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, TReturn>(_method, target?.GetType(), out pAddress) ||
                              (pAddress != 0 && REMethodBase.SecondaryValidateStaticMethod(_method, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), arg11?.GetType(), arg12?.GetType(), arg13?.GetType(), arg14?.GetType(), arg15?.GetType(), ref pAddress));
                }
                else
                {
                    isValid = (pAddress != 0 && REMethodBase.SecondaryValidateInstanceMethod(_method, target?.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), arg11?.GetType(), arg12?.GetType(), arg13?.GetType(), arg14?.GetType(), arg15?.GetType(), ref pAddress));
                }
                if (!isValid)
                {
                    return (TReturn)_method.InvokeInstanceLowAlloc(ref target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15);
                }
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
    }
    public readonly struct ClassInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, TReturn>
    where TTarget: class
    {
        private readonly nint _pAddress;
        private readonly bool _isValid;
        private readonly MethodBase _method;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ClassInstanceMethodPointerFunc(MethodBase method)
        {
            _method = method;
            if (method.IsOverridable())
            {
                _isValid = false;
                _pAddress = 0;
                return;
            }
            _isValid = REMethodBase.ValidateInstanceReturnableMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, TReturn>(method, out _pAddress);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ClassInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, TReturn>(MethodBase method)
        {
            return new ClassInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, TReturn>(method);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ClassInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, TReturn>(Func<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, TReturn> method)
        {
            return new ClassInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, TReturn>(method.Method);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TReturn Invoke(TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9, in TArg10 arg10, in TArg11 arg11, in TArg12 arg12, in TArg13 arg13, in TArg14 arg14, in TArg15 arg15)
        {
            bool isValid = _isValid;
            nint pAddress = _pAddress;
            if (!isValid)
            {
                if (_method.IsOverridable())
                {
                    isValid = REMethodBase.ValidateInstanceReturnableVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, TReturn>(_method, target?.GetType(), out pAddress) ||
                              (pAddress != 0 && REMethodBase.SecondaryValidateStaticMethod(_method, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), arg11?.GetType(), arg12?.GetType(), arg13?.GetType(), arg14?.GetType(), arg15?.GetType(), ref pAddress));
                }
                else
                {
                    isValid = (pAddress != 0 && REMethodBase.SecondaryValidateInstanceMethod(_method, target?.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), arg11?.GetType(), arg12?.GetType(), arg13?.GetType(), arg14?.GetType(), arg15?.GetType(), ref pAddress));
                }
                if (!isValid)
                {
                    return (TReturn)_method.InvokeClassInstanceLowAlloc(target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15);
                }
            }
            unsafe
            {
                return ((delegate*<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, TReturn>)pAddress)(target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15);
            }
        }
    }
    public readonly struct StructInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, TReturn>
    where TTarget: struct
    {
        private readonly nint _pAddress;
        private readonly bool _isValid;
        private readonly MethodBase _method;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public StructInstanceMethodPointerFunc(MethodBase method)
        {
            _method = method;
            if (method.IsOverridable())
            {
                _isValid = false;
                _pAddress = 0;
                return;
            }
            _isValid = REMethodBase.ValidateInstanceReturnableMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, TReturn>(method, out _pAddress);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator StructInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, TReturn>(MethodBase method)
        {
            return new StructInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, TReturn>(method);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator StructInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, TReturn>(Func<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, TReturn> method)
        {
            return new StructInstanceMethodPointerFunc<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, TReturn>(method.Method);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TReturn Invoke(ref TTarget target, in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9, in TArg10 arg10, in TArg11 arg11, in TArg12 arg12, in TArg13 arg13, in TArg14 arg14, in TArg15 arg15)
        {
            bool isValid = _isValid;
            nint pAddress = _pAddress;
            if (!isValid)
            {
                if (_method.IsOverridable())
                {
                    isValid = REMethodBase.ValidateInstanceReturnableVirtualMethod<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, TReturn>(_method, target.GetType(), out pAddress) ||
                              (pAddress != 0 && REMethodBase.SecondaryValidateStaticMethod(_method, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), arg11?.GetType(), arg12?.GetType(), arg13?.GetType(), arg14?.GetType(), arg15?.GetType(), ref pAddress));
                }
                else
                {
                    isValid = (pAddress != 0 && REMethodBase.SecondaryValidateInstanceMethod(_method, target.GetType(), arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), arg11?.GetType(), arg12?.GetType(), arg13?.GetType(), arg14?.GetType(), arg15?.GetType(), ref pAddress));
                }
                if (!isValid)
                {
                    return (TReturn)_method.InvokeInstanceLowAlloc(ref target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15);
                }
            }
            unsafe
            {
                return ((delegate*<ref TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, TReturn>)pAddress)(ref target, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15);
            }
        }
    }
    public readonly struct StaticMethodPointerAction<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>
    {
        private readonly nint _pAddress;
        private readonly bool _isValid;
        private readonly MethodBase _method;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public StaticMethodPointerAction(MethodBase method)
        {
            _method = method;
            if (method.IsOverridable())
            {
                _isValid = false;
                _pAddress = 0;
                return;
            }
            _isValid = REMethodBase.ValidateStaticMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(method, out _pAddress);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator StaticMethodPointerAction<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(MethodBase method)
        {
            return new StaticMethodPointerAction<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(method);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator StaticMethodPointerAction<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(Action<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15> method)
        {
            return new StaticMethodPointerAction<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(method.Method);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Invoke(in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9, in TArg10 arg10, in TArg11 arg11, in TArg12 arg12, in TArg13 arg13, in TArg14 arg14, in TArg15 arg15)
        {
            bool isValid = _isValid;
            nint pAddress = _pAddress;
            if (!isValid)
            {
                isValid = (pAddress != 0 && REMethodBase.SecondaryValidateStaticMethod(_method, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), arg11?.GetType(), arg12?.GetType(), arg13?.GetType(), arg14?.GetType(), arg15?.GetType(), ref pAddress));
                if (!isValid)
                {
                    _method.InvokeStaticLowAlloc(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15);
                    return;
                }
            }
            unsafe
            {
                ((delegate*<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, void>)pAddress)(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15);
                return;
            }
        }
    }
    public readonly struct StaticMethodPointerFunc<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, TReturn>
    {
        private readonly nint _pAddress;
        private readonly bool _isValid;
        private readonly MethodBase _method;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public StaticMethodPointerFunc(MethodBase method)
        {
            _method = method;
            if (method.IsOverridable())
            {
                _isValid = false;
                _pAddress = 0;
                return;
            }
            _isValid = REMethodBase.ValidateStaticReturnableMethod<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, TReturn>(method, out _pAddress);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator StaticMethodPointerFunc<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, TReturn>(MethodBase method)
        {
            return new StaticMethodPointerFunc<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, TReturn>(method);
        }
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator StaticMethodPointerFunc<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, TReturn>(Func<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, TReturn> method)
        {
            return new StaticMethodPointerFunc<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, TReturn>(method.Method);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TReturn Invoke(in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9, in TArg10 arg10, in TArg11 arg11, in TArg12 arg12, in TArg13 arg13, in TArg14 arg14, in TArg15 arg15)
        {
            bool isValid = _isValid;
            nint pAddress = _pAddress;
            if (!isValid)
            {
                isValid = (pAddress != 0 && REMethodBase.SecondaryValidateStaticMethod(_method, arg0?.GetType(), arg1?.GetType(), arg2?.GetType(), arg3?.GetType(), arg4?.GetType(), arg5?.GetType(), arg6?.GetType(), arg7?.GetType(), arg8?.GetType(), arg9?.GetType(), arg10?.GetType(), arg11?.GetType(), arg12?.GetType(), arg13?.GetType(), arg14?.GetType(), arg15?.GetType(), ref pAddress));
                if (!isValid)
                {
                    return (TReturn)_method.InvokeStaticLowAlloc(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15);
                }
            }
            unsafe
            {
                return ((delegate*<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, TReturn>)pAddress)(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15);
            }
        }
    }
}

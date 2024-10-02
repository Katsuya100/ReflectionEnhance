using Katuusagi.MemoizationForUnity;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Linq;
namespace Katuusagi.ReflectionEnhance
{
    public static partial class REConstructorInfo
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TTarget InvokeInstanceFast<TTarget>(this ConstructorInfo self)
        {
            var result = TryGetCreateInstanceMethodPointer<TTarget>(self, out var method);
            if (result == CreateInstanceResult.Success)
            {
                return method.Invoke();
            }
            #if ENABLE_IL2CPP
            if (result == CreateInstanceResult.DirectCall)
            {
                var instance = New<TTarget>();
                var action = Unsafe.As<StaticMethodPointerFunc<TTarget>, InstanceMethodPointerAction<TTarget>>(ref method);
                action.Invoke(ref instance);
                return instance;
            }
            #endif
            return (TTarget)self.InvokeInstanceLowAlloc();
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static object InvokeInstanceLowAlloc(this ConstructorInfo self)
        {
            try
            {
                return self.Invoke(ArrayCache.Objects0);
            }
            finally
            {
            }
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static CreateInstanceResult TryGetCreateInstanceMethodPointerRaw<TTarget>(ConstructorInfo ctor, out StaticMethodPointerFunc<TTarget> result)
        {
            if (ctor.IsStatic)
            {
                result = default;
                return CreateInstanceResult.Fallback;
            }
            MethodInfo createInstance;
            #if ENABLE_IL2CPP
            if (typeof(TTarget) != ctor.ReflectedType)
            {
                result = default;
                return CreateInstanceResult.Fallback;
            }
            createInstance = ctor.ReflectedType.GetStaticMethodFullAccess("$CreateInstance", null, ctor.GetParameterTypes().ToArray(), null);
            if (createInstance == null)
            {
                InstanceMethodPointerAction<TTarget> action = ctor;
                result = Unsafe.As<InstanceMethodPointerAction<TTarget>, StaticMethodPointerFunc<TTarget>>(ref action);
                return CreateInstanceResult.DirectCall;
            }
            #else
            var m = new DynamicMethod("$CreateInstance", ctor.ReflectedType, ctor.GetParameterTypes().ToArray(), ctor.ReflectedType, true);
            var cg = m.GetILGenerator();
            if (REType.IsValueTypeFast<TTarget>())
            {
                cg.DeclareLocal(typeof(TTarget));
                cg.Emit(OpCodes.Ldloca_S, 0);
                cg.Emit(OpCodes.Initobj, typeof(TTarget));
                cg.Emit(OpCodes.Ldloc_0);
            }
            else
            {
                cg.Emit(OpCodes.Newobj, ctor);
            }
            cg.Emit(OpCodes.Ret);
            REReflection.InitDynamicMethod(m);
            createInstance = m;
            #endif
            result = createInstance;
            return CreateInstanceResult.Success;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TTarget InvokeInstanceFast<TTarget, TArg0>(this ConstructorInfo self, TArg0 arg0)
        {
            var result = TryGetCreateInstanceMethodPointer<TTarget, TArg0>(self, out var method);
            if (result == CreateInstanceResult.Success)
            {
                return method.Invoke(arg0);
            }
            #if ENABLE_IL2CPP
            if (result == CreateInstanceResult.DirectCall)
            {
                var instance = New<TTarget>();
                var action = Unsafe.As<StaticMethodPointerFunc<TArg0, TTarget>, InstanceMethodPointerAction<TTarget, TArg0>>(ref method);
                action.Invoke(ref instance, arg0);
                return instance;
            }
            #endif
            return (TTarget)self.InvokeInstanceLowAlloc(arg0);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static object InvokeInstanceLowAlloc<TArg0>(this ConstructorInfo self, TArg0 arg0)
        {
            var parameters = self.GetParametersFast();
            ArrayCache.Objects1[0] = REReflection.GetBox(arg0, parameters[0], out var refArg0);
            try
            {
                return self.Invoke(ArrayCache.Objects1);
            }
            finally
            {
                REReflection.ReturnBox<TArg0>(ArrayCache.Objects1[0], parameters[0], refArg0);
            }
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static CreateInstanceResult TryGetCreateInstanceMethodPointerRaw<TTarget, TArg0>(ConstructorInfo ctor, out StaticMethodPointerFunc<TArg0, TTarget> result)
        {
            if (ctor.IsStatic)
            {
                result = default;
                return CreateInstanceResult.Fallback;
            }
            MethodInfo createInstance;
            #if ENABLE_IL2CPP
            if (typeof(TTarget) != ctor.ReflectedType)
            {
                result = default;
                return CreateInstanceResult.Fallback;
            }
            createInstance = ctor.ReflectedType.GetStaticMethodFullAccess("$CreateInstance", null, ctor.GetParameterTypes().ToArray(), null);
            if (createInstance == null)
            {
                InstanceMethodPointerAction<TTarget, TArg0> action = ctor;
                result = Unsafe.As<InstanceMethodPointerAction<TTarget, TArg0>, StaticMethodPointerFunc<TArg0, TTarget>>(ref action);
                return CreateInstanceResult.DirectCall;
            }
            #else
            var m = new DynamicMethod("$CreateInstance", ctor.ReflectedType, ctor.GetParameterTypes().ToArray(), ctor.ReflectedType, true);
            var cg = m.GetILGenerator();
            cg.Emit(OpCodes.Ldarg_0);
            cg.Emit(OpCodes.Newobj, ctor);
            cg.Emit(OpCodes.Ret);
            REReflection.InitDynamicMethod(m);
            createInstance = m;
            #endif
            result = createInstance;
            return CreateInstanceResult.Success;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TTarget InvokeInstanceFast<TTarget, TArg0, TArg1>(this ConstructorInfo self, TArg0 arg0, TArg1 arg1)
        {
            var result = TryGetCreateInstanceMethodPointer<TTarget, TArg0, TArg1>(self, out var method);
            if (result == CreateInstanceResult.Success)
            {
                return method.Invoke(arg0, arg1);
            }
            #if ENABLE_IL2CPP
            if (result == CreateInstanceResult.DirectCall)
            {
                var instance = New<TTarget>();
                var action = Unsafe.As<StaticMethodPointerFunc<TArg0, TArg1, TTarget>, InstanceMethodPointerAction<TTarget, TArg0, TArg1>>(ref method);
                action.Invoke(ref instance, arg0, arg1);
                return instance;
            }
            #endif
            return (TTarget)self.InvokeInstanceLowAlloc(arg0, arg1);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static object InvokeInstanceLowAlloc<TArg0, TArg1>(this ConstructorInfo self, TArg0 arg0, TArg1 arg1)
        {
            var parameters = self.GetParametersFast();
            ArrayCache.Objects2[0] = REReflection.GetBox(arg0, parameters[0], out var refArg0);
            ArrayCache.Objects2[1] = REReflection.GetBox(arg1, parameters[1], out var refArg1);
            try
            {
                return self.Invoke(ArrayCache.Objects2);
            }
            finally
            {
                REReflection.ReturnBox<TArg0>(ArrayCache.Objects2[0], parameters[0], refArg0);
                REReflection.ReturnBox<TArg1>(ArrayCache.Objects2[1], parameters[1], refArg1);
            }
        }
        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static CreateInstanceResult TryGetCreateInstanceMethodPointerRaw<TTarget, TArg0, TArg1>(ConstructorInfo ctor, out StaticMethodPointerFunc<TArg0, TArg1, TTarget> result)
        {
            if (ctor.IsStatic)
            {
                result = default;
                return CreateInstanceResult.Fallback;
            }
            MethodInfo createInstance;
            #if ENABLE_IL2CPP
            if (typeof(TTarget) != ctor.ReflectedType)
            {
                result = default;
                return CreateInstanceResult.Fallback;
            }
            createInstance = ctor.ReflectedType.GetStaticMethodFullAccess("$CreateInstance", null, ctor.GetParameterTypes().ToArray(), null);
            if (createInstance == null)
            {
                InstanceMethodPointerAction<TTarget, TArg0, TArg1> action = ctor;
                result = Unsafe.As<InstanceMethodPointerAction<TTarget, TArg0, TArg1>, StaticMethodPointerFunc<TArg0, TArg1, TTarget>>(ref action);
                return CreateInstanceResult.DirectCall;
            }
            #else
            var m = new DynamicMethod("$CreateInstance", ctor.ReflectedType, ctor.GetParameterTypes().ToArray(), ctor.ReflectedType, true);
            var cg = m.GetILGenerator();
            cg.Emit(OpCodes.Ldarg_0);
            cg.Emit(OpCodes.Ldarg_1);
            cg.Emit(OpCodes.Newobj, ctor);
            cg.Emit(OpCodes.Ret);
            REReflection.InitDynamicMethod(m);
            createInstance = m;
            #endif
            result = createInstance;
            return CreateInstanceResult.Success;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TTarget InvokeInstanceFast<TTarget, TArg0, TArg1, TArg2>(this ConstructorInfo self, TArg0 arg0, TArg1 arg1, TArg2 arg2)
        {
            var result = TryGetCreateInstanceMethodPointer<TTarget, TArg0, TArg1, TArg2>(self, out var method);
            if (result == CreateInstanceResult.Success)
            {
                return method.Invoke(arg0, arg1, arg2);
            }
            #if ENABLE_IL2CPP
            if (result == CreateInstanceResult.DirectCall)
            {
                var instance = New<TTarget>();
                var action = Unsafe.As<StaticMethodPointerFunc<TArg0, TArg1, TArg2, TTarget>, InstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2>>(ref method);
                action.Invoke(ref instance, arg0, arg1, arg2);
                return instance;
            }
            #endif
            return (TTarget)self.InvokeInstanceLowAlloc(arg0, arg1, arg2);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static object InvokeInstanceLowAlloc<TArg0, TArg1, TArg2>(this ConstructorInfo self, TArg0 arg0, TArg1 arg1, TArg2 arg2)
        {
            var parameters = self.GetParametersFast();
            ArrayCache.Objects3[0] = REReflection.GetBox(arg0, parameters[0], out var refArg0);
            ArrayCache.Objects3[1] = REReflection.GetBox(arg1, parameters[1], out var refArg1);
            ArrayCache.Objects3[2] = REReflection.GetBox(arg2, parameters[2], out var refArg2);
            try
            {
                return self.Invoke(ArrayCache.Objects3);
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
        private static CreateInstanceResult TryGetCreateInstanceMethodPointerRaw<TTarget, TArg0, TArg1, TArg2>(ConstructorInfo ctor, out StaticMethodPointerFunc<TArg0, TArg1, TArg2, TTarget> result)
        {
            if (ctor.IsStatic)
            {
                result = default;
                return CreateInstanceResult.Fallback;
            }
            MethodInfo createInstance;
            #if ENABLE_IL2CPP
            if (typeof(TTarget) != ctor.ReflectedType)
            {
                result = default;
                return CreateInstanceResult.Fallback;
            }
            createInstance = ctor.ReflectedType.GetStaticMethodFullAccess("$CreateInstance", null, ctor.GetParameterTypes().ToArray(), null);
            if (createInstance == null)
            {
                InstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2> action = ctor;
                result = Unsafe.As<InstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2>, StaticMethodPointerFunc<TArg0, TArg1, TArg2, TTarget>>(ref action);
                return CreateInstanceResult.DirectCall;
            }
            #else
            var m = new DynamicMethod("$CreateInstance", ctor.ReflectedType, ctor.GetParameterTypes().ToArray(), ctor.ReflectedType, true);
            var cg = m.GetILGenerator();
            cg.Emit(OpCodes.Ldarg_0);
            cg.Emit(OpCodes.Ldarg_1);
            cg.Emit(OpCodes.Ldarg_2);
            cg.Emit(OpCodes.Newobj, ctor);
            cg.Emit(OpCodes.Ret);
            REReflection.InitDynamicMethod(m);
            createInstance = m;
            #endif
            result = createInstance;
            return CreateInstanceResult.Success;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TTarget InvokeInstanceFast<TTarget, TArg0, TArg1, TArg2, TArg3>(this ConstructorInfo self, TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3)
        {
            var result = TryGetCreateInstanceMethodPointer<TTarget, TArg0, TArg1, TArg2, TArg3>(self, out var method);
            if (result == CreateInstanceResult.Success)
            {
                return method.Invoke(arg0, arg1, arg2, arg3);
            }
            #if ENABLE_IL2CPP
            if (result == CreateInstanceResult.DirectCall)
            {
                var instance = New<TTarget>();
                var action = Unsafe.As<StaticMethodPointerFunc<TArg0, TArg1, TArg2, TArg3, TTarget>, InstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3>>(ref method);
                action.Invoke(ref instance, arg0, arg1, arg2, arg3);
                return instance;
            }
            #endif
            return (TTarget)self.InvokeInstanceLowAlloc(arg0, arg1, arg2, arg3);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static object InvokeInstanceLowAlloc<TArg0, TArg1, TArg2, TArg3>(this ConstructorInfo self, TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3)
        {
            var parameters = self.GetParametersFast();
            ArrayCache.Objects4[0] = REReflection.GetBox(arg0, parameters[0], out var refArg0);
            ArrayCache.Objects4[1] = REReflection.GetBox(arg1, parameters[1], out var refArg1);
            ArrayCache.Objects4[2] = REReflection.GetBox(arg2, parameters[2], out var refArg2);
            ArrayCache.Objects4[3] = REReflection.GetBox(arg3, parameters[3], out var refArg3);
            try
            {
                return self.Invoke(ArrayCache.Objects4);
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
        private static CreateInstanceResult TryGetCreateInstanceMethodPointerRaw<TTarget, TArg0, TArg1, TArg2, TArg3>(ConstructorInfo ctor, out StaticMethodPointerFunc<TArg0, TArg1, TArg2, TArg3, TTarget> result)
        {
            if (ctor.IsStatic)
            {
                result = default;
                return CreateInstanceResult.Fallback;
            }
            MethodInfo createInstance;
            #if ENABLE_IL2CPP
            if (typeof(TTarget) != ctor.ReflectedType)
            {
                result = default;
                return CreateInstanceResult.Fallback;
            }
            createInstance = ctor.ReflectedType.GetStaticMethodFullAccess("$CreateInstance", null, ctor.GetParameterTypes().ToArray(), null);
            if (createInstance == null)
            {
                InstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3> action = ctor;
                result = Unsafe.As<InstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3>, StaticMethodPointerFunc<TArg0, TArg1, TArg2, TArg3, TTarget>>(ref action);
                return CreateInstanceResult.DirectCall;
            }
            #else
            var m = new DynamicMethod("$CreateInstance", ctor.ReflectedType, ctor.GetParameterTypes().ToArray(), ctor.ReflectedType, true);
            var cg = m.GetILGenerator();
            cg.Emit(OpCodes.Ldarg_0);
            cg.Emit(OpCodes.Ldarg_1);
            cg.Emit(OpCodes.Ldarg_2);
            cg.Emit(OpCodes.Ldarg_3);
            cg.Emit(OpCodes.Newobj, ctor);
            cg.Emit(OpCodes.Ret);
            REReflection.InitDynamicMethod(m);
            createInstance = m;
            #endif
            result = createInstance;
            return CreateInstanceResult.Success;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TTarget InvokeInstanceFast<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4>(this ConstructorInfo self, TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4)
        {
            var result = TryGetCreateInstanceMethodPointer<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4>(self, out var method);
            if (result == CreateInstanceResult.Success)
            {
                return method.Invoke(arg0, arg1, arg2, arg3, arg4);
            }
            #if ENABLE_IL2CPP
            if (result == CreateInstanceResult.DirectCall)
            {
                var instance = New<TTarget>();
                var action = Unsafe.As<StaticMethodPointerFunc<TArg0, TArg1, TArg2, TArg3, TArg4, TTarget>, InstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4>>(ref method);
                action.Invoke(ref instance, arg0, arg1, arg2, arg3, arg4);
                return instance;
            }
            #endif
            return (TTarget)self.InvokeInstanceLowAlloc(arg0, arg1, arg2, arg3, arg4);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static object InvokeInstanceLowAlloc<TArg0, TArg1, TArg2, TArg3, TArg4>(this ConstructorInfo self, TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4)
        {
            var parameters = self.GetParametersFast();
            ArrayCache.Objects5[0] = REReflection.GetBox(arg0, parameters[0], out var refArg0);
            ArrayCache.Objects5[1] = REReflection.GetBox(arg1, parameters[1], out var refArg1);
            ArrayCache.Objects5[2] = REReflection.GetBox(arg2, parameters[2], out var refArg2);
            ArrayCache.Objects5[3] = REReflection.GetBox(arg3, parameters[3], out var refArg3);
            ArrayCache.Objects5[4] = REReflection.GetBox(arg4, parameters[4], out var refArg4);
            try
            {
                return self.Invoke(ArrayCache.Objects5);
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
        private static CreateInstanceResult TryGetCreateInstanceMethodPointerRaw<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4>(ConstructorInfo ctor, out StaticMethodPointerFunc<TArg0, TArg1, TArg2, TArg3, TArg4, TTarget> result)
        {
            if (ctor.IsStatic)
            {
                result = default;
                return CreateInstanceResult.Fallback;
            }
            MethodInfo createInstance;
            #if ENABLE_IL2CPP
            if (typeof(TTarget) != ctor.ReflectedType)
            {
                result = default;
                return CreateInstanceResult.Fallback;
            }
            createInstance = ctor.ReflectedType.GetStaticMethodFullAccess("$CreateInstance", null, ctor.GetParameterTypes().ToArray(), null);
            if (createInstance == null)
            {
                InstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4> action = ctor;
                result = Unsafe.As<InstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4>, StaticMethodPointerFunc<TArg0, TArg1, TArg2, TArg3, TArg4, TTarget>>(ref action);
                return CreateInstanceResult.DirectCall;
            }
            #else
            var m = new DynamicMethod("$CreateInstance", ctor.ReflectedType, ctor.GetParameterTypes().ToArray(), ctor.ReflectedType, true);
            var cg = m.GetILGenerator();
            cg.Emit(OpCodes.Ldarg_0);
            cg.Emit(OpCodes.Ldarg_1);
            cg.Emit(OpCodes.Ldarg_2);
            cg.Emit(OpCodes.Ldarg_3);
            cg.Emit(OpCodes.Ldarg_S, 4);
            cg.Emit(OpCodes.Newobj, ctor);
            cg.Emit(OpCodes.Ret);
            REReflection.InitDynamicMethod(m);
            createInstance = m;
            #endif
            result = createInstance;
            return CreateInstanceResult.Success;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TTarget InvokeInstanceFast<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(this ConstructorInfo self, TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5)
        {
            var result = TryGetCreateInstanceMethodPointer<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(self, out var method);
            if (result == CreateInstanceResult.Success)
            {
                return method.Invoke(arg0, arg1, arg2, arg3, arg4, arg5);
            }
            #if ENABLE_IL2CPP
            if (result == CreateInstanceResult.DirectCall)
            {
                var instance = New<TTarget>();
                var action = Unsafe.As<StaticMethodPointerFunc<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TTarget>, InstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>>(ref method);
                action.Invoke(ref instance, arg0, arg1, arg2, arg3, arg4, arg5);
                return instance;
            }
            #endif
            return (TTarget)self.InvokeInstanceLowAlloc(arg0, arg1, arg2, arg3, arg4, arg5);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static object InvokeInstanceLowAlloc<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(this ConstructorInfo self, TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5)
        {
            var parameters = self.GetParametersFast();
            ArrayCache.Objects6[0] = REReflection.GetBox(arg0, parameters[0], out var refArg0);
            ArrayCache.Objects6[1] = REReflection.GetBox(arg1, parameters[1], out var refArg1);
            ArrayCache.Objects6[2] = REReflection.GetBox(arg2, parameters[2], out var refArg2);
            ArrayCache.Objects6[3] = REReflection.GetBox(arg3, parameters[3], out var refArg3);
            ArrayCache.Objects6[4] = REReflection.GetBox(arg4, parameters[4], out var refArg4);
            ArrayCache.Objects6[5] = REReflection.GetBox(arg5, parameters[5], out var refArg5);
            try
            {
                return self.Invoke(ArrayCache.Objects6);
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
        private static CreateInstanceResult TryGetCreateInstanceMethodPointerRaw<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(ConstructorInfo ctor, out StaticMethodPointerFunc<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TTarget> result)
        {
            if (ctor.IsStatic)
            {
                result = default;
                return CreateInstanceResult.Fallback;
            }
            MethodInfo createInstance;
            #if ENABLE_IL2CPP
            if (typeof(TTarget) != ctor.ReflectedType)
            {
                result = default;
                return CreateInstanceResult.Fallback;
            }
            createInstance = ctor.ReflectedType.GetStaticMethodFullAccess("$CreateInstance", null, ctor.GetParameterTypes().ToArray(), null);
            if (createInstance == null)
            {
                InstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5> action = ctor;
                result = Unsafe.As<InstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>, StaticMethodPointerFunc<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TTarget>>(ref action);
                return CreateInstanceResult.DirectCall;
            }
            #else
            var m = new DynamicMethod("$CreateInstance", ctor.ReflectedType, ctor.GetParameterTypes().ToArray(), ctor.ReflectedType, true);
            var cg = m.GetILGenerator();
            cg.Emit(OpCodes.Ldarg_0);
            cg.Emit(OpCodes.Ldarg_1);
            cg.Emit(OpCodes.Ldarg_2);
            cg.Emit(OpCodes.Ldarg_3);
            cg.Emit(OpCodes.Ldarg_S, 4);
            cg.Emit(OpCodes.Ldarg_S, 5);
            cg.Emit(OpCodes.Newobj, ctor);
            cg.Emit(OpCodes.Ret);
            REReflection.InitDynamicMethod(m);
            createInstance = m;
            #endif
            result = createInstance;
            return CreateInstanceResult.Success;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TTarget InvokeInstanceFast<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(this ConstructorInfo self, TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6)
        {
            var result = TryGetCreateInstanceMethodPointer<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(self, out var method);
            if (result == CreateInstanceResult.Success)
            {
                return method.Invoke(arg0, arg1, arg2, arg3, arg4, arg5, arg6);
            }
            #if ENABLE_IL2CPP
            if (result == CreateInstanceResult.DirectCall)
            {
                var instance = New<TTarget>();
                var action = Unsafe.As<StaticMethodPointerFunc<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TTarget>, InstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>>(ref method);
                action.Invoke(ref instance, arg0, arg1, arg2, arg3, arg4, arg5, arg6);
                return instance;
            }
            #endif
            return (TTarget)self.InvokeInstanceLowAlloc(arg0, arg1, arg2, arg3, arg4, arg5, arg6);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static object InvokeInstanceLowAlloc<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(this ConstructorInfo self, TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6)
        {
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
                return self.Invoke(ArrayCache.Objects7);
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
        private static CreateInstanceResult TryGetCreateInstanceMethodPointerRaw<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(ConstructorInfo ctor, out StaticMethodPointerFunc<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TTarget> result)
        {
            if (ctor.IsStatic)
            {
                result = default;
                return CreateInstanceResult.Fallback;
            }
            MethodInfo createInstance;
            #if ENABLE_IL2CPP
            if (typeof(TTarget) != ctor.ReflectedType)
            {
                result = default;
                return CreateInstanceResult.Fallback;
            }
            createInstance = ctor.ReflectedType.GetStaticMethodFullAccess("$CreateInstance", null, ctor.GetParameterTypes().ToArray(), null);
            if (createInstance == null)
            {
                InstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6> action = ctor;
                result = Unsafe.As<InstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>, StaticMethodPointerFunc<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TTarget>>(ref action);
                return CreateInstanceResult.DirectCall;
            }
            #else
            var m = new DynamicMethod("$CreateInstance", ctor.ReflectedType, ctor.GetParameterTypes().ToArray(), ctor.ReflectedType, true);
            var cg = m.GetILGenerator();
            cg.Emit(OpCodes.Ldarg_0);
            cg.Emit(OpCodes.Ldarg_1);
            cg.Emit(OpCodes.Ldarg_2);
            cg.Emit(OpCodes.Ldarg_3);
            cg.Emit(OpCodes.Ldarg_S, 4);
            cg.Emit(OpCodes.Ldarg_S, 5);
            cg.Emit(OpCodes.Ldarg_S, 6);
            cg.Emit(OpCodes.Newobj, ctor);
            cg.Emit(OpCodes.Ret);
            REReflection.InitDynamicMethod(m);
            createInstance = m;
            #endif
            result = createInstance;
            return CreateInstanceResult.Success;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TTarget InvokeInstanceFast<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(this ConstructorInfo self, TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7)
        {
            var result = TryGetCreateInstanceMethodPointer<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(self, out var method);
            if (result == CreateInstanceResult.Success)
            {
                return method.Invoke(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
            }
            #if ENABLE_IL2CPP
            if (result == CreateInstanceResult.DirectCall)
            {
                var instance = New<TTarget>();
                var action = Unsafe.As<StaticMethodPointerFunc<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TTarget>, InstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>>(ref method);
                action.Invoke(ref instance, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
                return instance;
            }
            #endif
            return (TTarget)self.InvokeInstanceLowAlloc(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static object InvokeInstanceLowAlloc<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(this ConstructorInfo self, TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7)
        {
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
                return self.Invoke(ArrayCache.Objects8);
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
        private static CreateInstanceResult TryGetCreateInstanceMethodPointerRaw<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(ConstructorInfo ctor, out StaticMethodPointerFunc<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TTarget> result)
        {
            if (ctor.IsStatic)
            {
                result = default;
                return CreateInstanceResult.Fallback;
            }
            MethodInfo createInstance;
            #if ENABLE_IL2CPP
            if (typeof(TTarget) != ctor.ReflectedType)
            {
                result = default;
                return CreateInstanceResult.Fallback;
            }
            createInstance = ctor.ReflectedType.GetStaticMethodFullAccess("$CreateInstance", null, ctor.GetParameterTypes().ToArray(), null);
            if (createInstance == null)
            {
                InstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7> action = ctor;
                result = Unsafe.As<InstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>, StaticMethodPointerFunc<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TTarget>>(ref action);
                return CreateInstanceResult.DirectCall;
            }
            #else
            var m = new DynamicMethod("$CreateInstance", ctor.ReflectedType, ctor.GetParameterTypes().ToArray(), ctor.ReflectedType, true);
            var cg = m.GetILGenerator();
            cg.Emit(OpCodes.Ldarg_0);
            cg.Emit(OpCodes.Ldarg_1);
            cg.Emit(OpCodes.Ldarg_2);
            cg.Emit(OpCodes.Ldarg_3);
            cg.Emit(OpCodes.Ldarg_S, 4);
            cg.Emit(OpCodes.Ldarg_S, 5);
            cg.Emit(OpCodes.Ldarg_S, 6);
            cg.Emit(OpCodes.Ldarg_S, 7);
            cg.Emit(OpCodes.Newobj, ctor);
            cg.Emit(OpCodes.Ret);
            REReflection.InitDynamicMethod(m);
            createInstance = m;
            #endif
            result = createInstance;
            return CreateInstanceResult.Success;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TTarget InvokeInstanceFast<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(this ConstructorInfo self, TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8)
        {
            var result = TryGetCreateInstanceMethodPointer<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(self, out var method);
            if (result == CreateInstanceResult.Success)
            {
                return method.Invoke(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
            }
            #if ENABLE_IL2CPP
            if (result == CreateInstanceResult.DirectCall)
            {
                var instance = New<TTarget>();
                var action = Unsafe.As<StaticMethodPointerFunc<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TTarget>, InstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>>(ref method);
                action.Invoke(ref instance, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
                return instance;
            }
            #endif
            return (TTarget)self.InvokeInstanceLowAlloc(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static object InvokeInstanceLowAlloc<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(this ConstructorInfo self, TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8)
        {
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
                return self.Invoke(ArrayCache.Objects9);
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
        private static CreateInstanceResult TryGetCreateInstanceMethodPointerRaw<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(ConstructorInfo ctor, out StaticMethodPointerFunc<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TTarget> result)
        {
            if (ctor.IsStatic)
            {
                result = default;
                return CreateInstanceResult.Fallback;
            }
            MethodInfo createInstance;
            #if ENABLE_IL2CPP
            if (typeof(TTarget) != ctor.ReflectedType)
            {
                result = default;
                return CreateInstanceResult.Fallback;
            }
            createInstance = ctor.ReflectedType.GetStaticMethodFullAccess("$CreateInstance", null, ctor.GetParameterTypes().ToArray(), null);
            if (createInstance == null)
            {
                InstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8> action = ctor;
                result = Unsafe.As<InstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>, StaticMethodPointerFunc<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TTarget>>(ref action);
                return CreateInstanceResult.DirectCall;
            }
            #else
            var m = new DynamicMethod("$CreateInstance", ctor.ReflectedType, ctor.GetParameterTypes().ToArray(), ctor.ReflectedType, true);
            var cg = m.GetILGenerator();
            cg.Emit(OpCodes.Ldarg_0);
            cg.Emit(OpCodes.Ldarg_1);
            cg.Emit(OpCodes.Ldarg_2);
            cg.Emit(OpCodes.Ldarg_3);
            cg.Emit(OpCodes.Ldarg_S, 4);
            cg.Emit(OpCodes.Ldarg_S, 5);
            cg.Emit(OpCodes.Ldarg_S, 6);
            cg.Emit(OpCodes.Ldarg_S, 7);
            cg.Emit(OpCodes.Ldarg_S, 8);
            cg.Emit(OpCodes.Newobj, ctor);
            cg.Emit(OpCodes.Ret);
            REReflection.InitDynamicMethod(m);
            createInstance = m;
            #endif
            result = createInstance;
            return CreateInstanceResult.Success;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TTarget InvokeInstanceFast<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(this ConstructorInfo self, TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9)
        {
            var result = TryGetCreateInstanceMethodPointer<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(self, out var method);
            if (result == CreateInstanceResult.Success)
            {
                return method.Invoke(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
            }
            #if ENABLE_IL2CPP
            if (result == CreateInstanceResult.DirectCall)
            {
                var instance = New<TTarget>();
                var action = Unsafe.As<StaticMethodPointerFunc<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TTarget>, InstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>>(ref method);
                action.Invoke(ref instance, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
                return instance;
            }
            #endif
            return (TTarget)self.InvokeInstanceLowAlloc(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static object InvokeInstanceLowAlloc<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(this ConstructorInfo self, TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9)
        {
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
                return self.Invoke(ArrayCache.Objects10);
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
        private static CreateInstanceResult TryGetCreateInstanceMethodPointerRaw<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(ConstructorInfo ctor, out StaticMethodPointerFunc<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TTarget> result)
        {
            if (ctor.IsStatic)
            {
                result = default;
                return CreateInstanceResult.Fallback;
            }
            MethodInfo createInstance;
            #if ENABLE_IL2CPP
            if (typeof(TTarget) != ctor.ReflectedType)
            {
                result = default;
                return CreateInstanceResult.Fallback;
            }
            createInstance = ctor.ReflectedType.GetStaticMethodFullAccess("$CreateInstance", null, ctor.GetParameterTypes().ToArray(), null);
            if (createInstance == null)
            {
                InstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9> action = ctor;
                result = Unsafe.As<InstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>, StaticMethodPointerFunc<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TTarget>>(ref action);
                return CreateInstanceResult.DirectCall;
            }
            #else
            var m = new DynamicMethod("$CreateInstance", ctor.ReflectedType, ctor.GetParameterTypes().ToArray(), ctor.ReflectedType, true);
            var cg = m.GetILGenerator();
            cg.Emit(OpCodes.Ldarg_0);
            cg.Emit(OpCodes.Ldarg_1);
            cg.Emit(OpCodes.Ldarg_2);
            cg.Emit(OpCodes.Ldarg_3);
            cg.Emit(OpCodes.Ldarg_S, 4);
            cg.Emit(OpCodes.Ldarg_S, 5);
            cg.Emit(OpCodes.Ldarg_S, 6);
            cg.Emit(OpCodes.Ldarg_S, 7);
            cg.Emit(OpCodes.Ldarg_S, 8);
            cg.Emit(OpCodes.Ldarg_S, 9);
            cg.Emit(OpCodes.Newobj, ctor);
            cg.Emit(OpCodes.Ret);
            REReflection.InitDynamicMethod(m);
            createInstance = m;
            #endif
            result = createInstance;
            return CreateInstanceResult.Success;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TTarget InvokeInstanceFast<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(this ConstructorInfo self, TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, TArg10 arg10)
        {
            var result = TryGetCreateInstanceMethodPointer<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(self, out var method);
            if (result == CreateInstanceResult.Success)
            {
                return method.Invoke(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
            }
            #if ENABLE_IL2CPP
            if (result == CreateInstanceResult.DirectCall)
            {
                var instance = New<TTarget>();
                var action = Unsafe.As<StaticMethodPointerFunc<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TTarget>, InstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>>(ref method);
                action.Invoke(ref instance, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
                return instance;
            }
            #endif
            return (TTarget)self.InvokeInstanceLowAlloc(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static object InvokeInstanceLowAlloc<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(this ConstructorInfo self, TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, TArg10 arg10)
        {
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
                return self.Invoke(ArrayCache.Objects11);
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
        private static CreateInstanceResult TryGetCreateInstanceMethodPointerRaw<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(ConstructorInfo ctor, out StaticMethodPointerFunc<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TTarget> result)
        {
            if (ctor.IsStatic)
            {
                result = default;
                return CreateInstanceResult.Fallback;
            }
            MethodInfo createInstance;
            #if ENABLE_IL2CPP
            if (typeof(TTarget) != ctor.ReflectedType)
            {
                result = default;
                return CreateInstanceResult.Fallback;
            }
            createInstance = ctor.ReflectedType.GetStaticMethodFullAccess("$CreateInstance", null, ctor.GetParameterTypes().ToArray(), null);
            if (createInstance == null)
            {
                InstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10> action = ctor;
                result = Unsafe.As<InstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>, StaticMethodPointerFunc<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TTarget>>(ref action);
                return CreateInstanceResult.DirectCall;
            }
            #else
            var m = new DynamicMethod("$CreateInstance", ctor.ReflectedType, ctor.GetParameterTypes().ToArray(), ctor.ReflectedType, true);
            var cg = m.GetILGenerator();
            cg.Emit(OpCodes.Ldarg_0);
            cg.Emit(OpCodes.Ldarg_1);
            cg.Emit(OpCodes.Ldarg_2);
            cg.Emit(OpCodes.Ldarg_3);
            cg.Emit(OpCodes.Ldarg_S, 4);
            cg.Emit(OpCodes.Ldarg_S, 5);
            cg.Emit(OpCodes.Ldarg_S, 6);
            cg.Emit(OpCodes.Ldarg_S, 7);
            cg.Emit(OpCodes.Ldarg_S, 8);
            cg.Emit(OpCodes.Ldarg_S, 9);
            cg.Emit(OpCodes.Ldarg_S, 10);
            cg.Emit(OpCodes.Newobj, ctor);
            cg.Emit(OpCodes.Ret);
            REReflection.InitDynamicMethod(m);
            createInstance = m;
            #endif
            result = createInstance;
            return CreateInstanceResult.Success;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TTarget InvokeInstanceFast<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(this ConstructorInfo self, TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, TArg10 arg10, TArg11 arg11)
        {
            var result = TryGetCreateInstanceMethodPointer<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(self, out var method);
            if (result == CreateInstanceResult.Success)
            {
                return method.Invoke(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
            }
            #if ENABLE_IL2CPP
            if (result == CreateInstanceResult.DirectCall)
            {
                var instance = New<TTarget>();
                var action = Unsafe.As<StaticMethodPointerFunc<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TTarget>, InstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>>(ref method);
                action.Invoke(ref instance, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
                return instance;
            }
            #endif
            return (TTarget)self.InvokeInstanceLowAlloc(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static object InvokeInstanceLowAlloc<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(this ConstructorInfo self, TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, TArg10 arg10, TArg11 arg11)
        {
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
                return self.Invoke(ArrayCache.Objects12);
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
        private static CreateInstanceResult TryGetCreateInstanceMethodPointerRaw<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(ConstructorInfo ctor, out StaticMethodPointerFunc<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TTarget> result)
        {
            if (ctor.IsStatic)
            {
                result = default;
                return CreateInstanceResult.Fallback;
            }
            MethodInfo createInstance;
            #if ENABLE_IL2CPP
            if (typeof(TTarget) != ctor.ReflectedType)
            {
                result = default;
                return CreateInstanceResult.Fallback;
            }
            createInstance = ctor.ReflectedType.GetStaticMethodFullAccess("$CreateInstance", null, ctor.GetParameterTypes().ToArray(), null);
            if (createInstance == null)
            {
                InstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11> action = ctor;
                result = Unsafe.As<InstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>, StaticMethodPointerFunc<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TTarget>>(ref action);
                return CreateInstanceResult.DirectCall;
            }
            #else
            var m = new DynamicMethod("$CreateInstance", ctor.ReflectedType, ctor.GetParameterTypes().ToArray(), ctor.ReflectedType, true);
            var cg = m.GetILGenerator();
            cg.Emit(OpCodes.Ldarg_0);
            cg.Emit(OpCodes.Ldarg_1);
            cg.Emit(OpCodes.Ldarg_2);
            cg.Emit(OpCodes.Ldarg_3);
            cg.Emit(OpCodes.Ldarg_S, 4);
            cg.Emit(OpCodes.Ldarg_S, 5);
            cg.Emit(OpCodes.Ldarg_S, 6);
            cg.Emit(OpCodes.Ldarg_S, 7);
            cg.Emit(OpCodes.Ldarg_S, 8);
            cg.Emit(OpCodes.Ldarg_S, 9);
            cg.Emit(OpCodes.Ldarg_S, 10);
            cg.Emit(OpCodes.Ldarg_S, 11);
            cg.Emit(OpCodes.Newobj, ctor);
            cg.Emit(OpCodes.Ret);
            REReflection.InitDynamicMethod(m);
            createInstance = m;
            #endif
            result = createInstance;
            return CreateInstanceResult.Success;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TTarget InvokeInstanceFast<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(this ConstructorInfo self, TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, TArg10 arg10, TArg11 arg11, TArg12 arg12)
        {
            var result = TryGetCreateInstanceMethodPointer<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(self, out var method);
            if (result == CreateInstanceResult.Success)
            {
                return method.Invoke(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
            }
            #if ENABLE_IL2CPP
            if (result == CreateInstanceResult.DirectCall)
            {
                var instance = New<TTarget>();
                var action = Unsafe.As<StaticMethodPointerFunc<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TTarget>, InstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>>(ref method);
                action.Invoke(ref instance, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
                return instance;
            }
            #endif
            return (TTarget)self.InvokeInstanceLowAlloc(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static object InvokeInstanceLowAlloc<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(this ConstructorInfo self, TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, TArg10 arg10, TArg11 arg11, TArg12 arg12)
        {
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
                return self.Invoke(ArrayCache.Objects13);
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
        private static CreateInstanceResult TryGetCreateInstanceMethodPointerRaw<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(ConstructorInfo ctor, out StaticMethodPointerFunc<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TTarget> result)
        {
            if (ctor.IsStatic)
            {
                result = default;
                return CreateInstanceResult.Fallback;
            }
            MethodInfo createInstance;
            #if ENABLE_IL2CPP
            if (typeof(TTarget) != ctor.ReflectedType)
            {
                result = default;
                return CreateInstanceResult.Fallback;
            }
            createInstance = ctor.ReflectedType.GetStaticMethodFullAccess("$CreateInstance", null, ctor.GetParameterTypes().ToArray(), null);
            if (createInstance == null)
            {
                InstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12> action = ctor;
                result = Unsafe.As<InstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>, StaticMethodPointerFunc<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TTarget>>(ref action);
                return CreateInstanceResult.DirectCall;
            }
            #else
            var m = new DynamicMethod("$CreateInstance", ctor.ReflectedType, ctor.GetParameterTypes().ToArray(), ctor.ReflectedType, true);
            var cg = m.GetILGenerator();
            cg.Emit(OpCodes.Ldarg_0);
            cg.Emit(OpCodes.Ldarg_1);
            cg.Emit(OpCodes.Ldarg_2);
            cg.Emit(OpCodes.Ldarg_3);
            cg.Emit(OpCodes.Ldarg_S, 4);
            cg.Emit(OpCodes.Ldarg_S, 5);
            cg.Emit(OpCodes.Ldarg_S, 6);
            cg.Emit(OpCodes.Ldarg_S, 7);
            cg.Emit(OpCodes.Ldarg_S, 8);
            cg.Emit(OpCodes.Ldarg_S, 9);
            cg.Emit(OpCodes.Ldarg_S, 10);
            cg.Emit(OpCodes.Ldarg_S, 11);
            cg.Emit(OpCodes.Ldarg_S, 12);
            cg.Emit(OpCodes.Newobj, ctor);
            cg.Emit(OpCodes.Ret);
            REReflection.InitDynamicMethod(m);
            createInstance = m;
            #endif
            result = createInstance;
            return CreateInstanceResult.Success;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TTarget InvokeInstanceFast<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(this ConstructorInfo self, TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, TArg10 arg10, TArg11 arg11, TArg12 arg12, TArg13 arg13)
        {
            var result = TryGetCreateInstanceMethodPointer<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(self, out var method);
            if (result == CreateInstanceResult.Success)
            {
                return method.Invoke(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
            }
            #if ENABLE_IL2CPP
            if (result == CreateInstanceResult.DirectCall)
            {
                var instance = New<TTarget>();
                var action = Unsafe.As<StaticMethodPointerFunc<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TTarget>, InstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>>(ref method);
                action.Invoke(ref instance, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
                return instance;
            }
            #endif
            return (TTarget)self.InvokeInstanceLowAlloc(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static object InvokeInstanceLowAlloc<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(this ConstructorInfo self, TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, TArg10 arg10, TArg11 arg11, TArg12 arg12, TArg13 arg13)
        {
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
                return self.Invoke(ArrayCache.Objects14);
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
        private static CreateInstanceResult TryGetCreateInstanceMethodPointerRaw<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(ConstructorInfo ctor, out StaticMethodPointerFunc<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TTarget> result)
        {
            if (ctor.IsStatic)
            {
                result = default;
                return CreateInstanceResult.Fallback;
            }
            MethodInfo createInstance;
            #if ENABLE_IL2CPP
            if (typeof(TTarget) != ctor.ReflectedType)
            {
                result = default;
                return CreateInstanceResult.Fallback;
            }
            createInstance = ctor.ReflectedType.GetStaticMethodFullAccess("$CreateInstance", null, ctor.GetParameterTypes().ToArray(), null);
            if (createInstance == null)
            {
                InstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13> action = ctor;
                result = Unsafe.As<InstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>, StaticMethodPointerFunc<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TTarget>>(ref action);
                return CreateInstanceResult.DirectCall;
            }
            #else
            var m = new DynamicMethod("$CreateInstance", ctor.ReflectedType, ctor.GetParameterTypes().ToArray(), ctor.ReflectedType, true);
            var cg = m.GetILGenerator();
            cg.Emit(OpCodes.Ldarg_0);
            cg.Emit(OpCodes.Ldarg_1);
            cg.Emit(OpCodes.Ldarg_2);
            cg.Emit(OpCodes.Ldarg_3);
            cg.Emit(OpCodes.Ldarg_S, 4);
            cg.Emit(OpCodes.Ldarg_S, 5);
            cg.Emit(OpCodes.Ldarg_S, 6);
            cg.Emit(OpCodes.Ldarg_S, 7);
            cg.Emit(OpCodes.Ldarg_S, 8);
            cg.Emit(OpCodes.Ldarg_S, 9);
            cg.Emit(OpCodes.Ldarg_S, 10);
            cg.Emit(OpCodes.Ldarg_S, 11);
            cg.Emit(OpCodes.Ldarg_S, 12);
            cg.Emit(OpCodes.Ldarg_S, 13);
            cg.Emit(OpCodes.Newobj, ctor);
            cg.Emit(OpCodes.Ret);
            REReflection.InitDynamicMethod(m);
            createInstance = m;
            #endif
            result = createInstance;
            return CreateInstanceResult.Success;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TTarget InvokeInstanceFast<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(this ConstructorInfo self, TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, TArg10 arg10, TArg11 arg11, TArg12 arg12, TArg13 arg13, TArg14 arg14)
        {
            var result = TryGetCreateInstanceMethodPointer<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(self, out var method);
            if (result == CreateInstanceResult.Success)
            {
                return method.Invoke(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
            }
            #if ENABLE_IL2CPP
            if (result == CreateInstanceResult.DirectCall)
            {
                var instance = New<TTarget>();
                var action = Unsafe.As<StaticMethodPointerFunc<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TTarget>, InstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>>(ref method);
                action.Invoke(ref instance, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
                return instance;
            }
            #endif
            return (TTarget)self.InvokeInstanceLowAlloc(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static object InvokeInstanceLowAlloc<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(this ConstructorInfo self, TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, TArg10 arg10, TArg11 arg11, TArg12 arg12, TArg13 arg13, TArg14 arg14)
        {
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
                return self.Invoke(ArrayCache.Objects15);
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
        private static CreateInstanceResult TryGetCreateInstanceMethodPointerRaw<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(ConstructorInfo ctor, out StaticMethodPointerFunc<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TTarget> result)
        {
            if (ctor.IsStatic)
            {
                result = default;
                return CreateInstanceResult.Fallback;
            }
            MethodInfo createInstance;
            #if ENABLE_IL2CPP
            if (typeof(TTarget) != ctor.ReflectedType)
            {
                result = default;
                return CreateInstanceResult.Fallback;
            }
            createInstance = ctor.ReflectedType.GetStaticMethodFullAccess("$CreateInstance", null, ctor.GetParameterTypes().ToArray(), null);
            if (createInstance == null)
            {
                InstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14> action = ctor;
                result = Unsafe.As<InstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>, StaticMethodPointerFunc<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TTarget>>(ref action);
                return CreateInstanceResult.DirectCall;
            }
            #else
            var m = new DynamicMethod("$CreateInstance", ctor.ReflectedType, ctor.GetParameterTypes().ToArray(), ctor.ReflectedType, true);
            var cg = m.GetILGenerator();
            cg.Emit(OpCodes.Ldarg_0);
            cg.Emit(OpCodes.Ldarg_1);
            cg.Emit(OpCodes.Ldarg_2);
            cg.Emit(OpCodes.Ldarg_3);
            cg.Emit(OpCodes.Ldarg_S, 4);
            cg.Emit(OpCodes.Ldarg_S, 5);
            cg.Emit(OpCodes.Ldarg_S, 6);
            cg.Emit(OpCodes.Ldarg_S, 7);
            cg.Emit(OpCodes.Ldarg_S, 8);
            cg.Emit(OpCodes.Ldarg_S, 9);
            cg.Emit(OpCodes.Ldarg_S, 10);
            cg.Emit(OpCodes.Ldarg_S, 11);
            cg.Emit(OpCodes.Ldarg_S, 12);
            cg.Emit(OpCodes.Ldarg_S, 13);
            cg.Emit(OpCodes.Ldarg_S, 14);
            cg.Emit(OpCodes.Newobj, ctor);
            cg.Emit(OpCodes.Ret);
            REReflection.InitDynamicMethod(m);
            createInstance = m;
            #endif
            result = createInstance;
            return CreateInstanceResult.Success;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TTarget InvokeInstanceFast<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(this ConstructorInfo self, TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, TArg10 arg10, TArg11 arg11, TArg12 arg12, TArg13 arg13, TArg14 arg14, TArg15 arg15)
        {
            var result = TryGetCreateInstanceMethodPointer<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(self, out var method);
            if (result == CreateInstanceResult.Success)
            {
                return method.Invoke(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15);
            }
            #if ENABLE_IL2CPP
            if (result == CreateInstanceResult.DirectCall)
            {
                var instance = New<TTarget>();
                var action = Unsafe.As<StaticMethodPointerFunc<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, TTarget>, InstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>>(ref method);
                action.Invoke(ref instance, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15);
                return instance;
            }
            #endif
            return (TTarget)self.InvokeInstanceLowAlloc(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static object InvokeInstanceLowAlloc<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(this ConstructorInfo self, TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, TArg10 arg10, TArg11 arg11, TArg12 arg12, TArg13 arg13, TArg14 arg14, TArg15 arg15)
        {
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
                return self.Invoke(ArrayCache.Objects16);
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
        private static CreateInstanceResult TryGetCreateInstanceMethodPointerRaw<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(ConstructorInfo ctor, out StaticMethodPointerFunc<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, TTarget> result)
        {
            if (ctor.IsStatic)
            {
                result = default;
                return CreateInstanceResult.Fallback;
            }
            MethodInfo createInstance;
            #if ENABLE_IL2CPP
            if (typeof(TTarget) != ctor.ReflectedType)
            {
                result = default;
                return CreateInstanceResult.Fallback;
            }
            createInstance = ctor.ReflectedType.GetStaticMethodFullAccess("$CreateInstance", null, ctor.GetParameterTypes().ToArray(), null);
            if (createInstance == null)
            {
                InstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15> action = ctor;
                result = Unsafe.As<InstanceMethodPointerAction<TTarget, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>, StaticMethodPointerFunc<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, TTarget>>(ref action);
                return CreateInstanceResult.DirectCall;
            }
            #else
            var m = new DynamicMethod("$CreateInstance", ctor.ReflectedType, ctor.GetParameterTypes().ToArray(), ctor.ReflectedType, true);
            var cg = m.GetILGenerator();
            cg.Emit(OpCodes.Ldarg_0);
            cg.Emit(OpCodes.Ldarg_1);
            cg.Emit(OpCodes.Ldarg_2);
            cg.Emit(OpCodes.Ldarg_3);
            cg.Emit(OpCodes.Ldarg_S, 4);
            cg.Emit(OpCodes.Ldarg_S, 5);
            cg.Emit(OpCodes.Ldarg_S, 6);
            cg.Emit(OpCodes.Ldarg_S, 7);
            cg.Emit(OpCodes.Ldarg_S, 8);
            cg.Emit(OpCodes.Ldarg_S, 9);
            cg.Emit(OpCodes.Ldarg_S, 10);
            cg.Emit(OpCodes.Ldarg_S, 11);
            cg.Emit(OpCodes.Ldarg_S, 12);
            cg.Emit(OpCodes.Ldarg_S, 13);
            cg.Emit(OpCodes.Ldarg_S, 14);
            cg.Emit(OpCodes.Ldarg_S, 15);
            cg.Emit(OpCodes.Newobj, ctor);
            cg.Emit(OpCodes.Ret);
            REReflection.InitDynamicMethod(m);
            createInstance = m;
            #endif
            result = createInstance;
            return CreateInstanceResult.Success;
        }
    }
}

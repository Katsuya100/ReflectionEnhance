using Katuusagi.Pool;
using Katuusagi.ReflectionEnhance.Utils;
using System;
using System.Runtime.CompilerServices;
namespace Katuusagi.ReflectionEnhance
{
    public static partial class REType
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T CreateInstance<T, TArg0>(TArg0 arg0)
        {
            var ctor = GetInstanceConstructorFullAccess<T, TArg0>();
            if (ctor == null)
            {
                ArrayCache.Objects1[0] = arg0;
                return (T)Activator.CreateInstance(typeof(T), REReflection.FullAccessInstanceLookUp, SubstitutionBinder.Default, ArrayCache.Objects1, null);
            }
            return ctor.InvokeInstanceFast<T, TArg0>(arg0);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static object CreateInstance<TArg0>(this Type self, TArg0 arg0)
        {
            var ctor = self.GetInstanceConstructorFullAccess<TArg0>();
            if (ctor == null)
            {
                ArrayCache.Objects1[0] = arg0;
                return Activator.CreateInstance(self, REReflection.FullAccessInstanceLookUp, SubstitutionBinder.Default, ArrayCache.Objects1, null);
            }
            return ctor.InvokeInstanceFast<object, TArg0>(arg0);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T CreateInstance<T, TArg0, TArg1>(TArg0 arg0, TArg1 arg1)
        {
            var ctor = GetInstanceConstructorFullAccess<T, TArg0, TArg1>();
            if (ctor == null)
            {
                ArrayCache.Objects2[0] = arg0;
                ArrayCache.Objects2[1] = arg1;
                return (T)Activator.CreateInstance(typeof(T), REReflection.FullAccessInstanceLookUp, SubstitutionBinder.Default, ArrayCache.Objects2, null);
            }
            return ctor.InvokeInstanceFast<T, TArg0, TArg1>(arg0, arg1);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static object CreateInstance<TArg0, TArg1>(this Type self, TArg0 arg0, TArg1 arg1)
        {
            var ctor = self.GetInstanceConstructorFullAccess<TArg0, TArg1>();
            if (ctor == null)
            {
                ArrayCache.Objects2[0] = arg0;
                ArrayCache.Objects2[1] = arg1;
                return Activator.CreateInstance(self, REReflection.FullAccessInstanceLookUp, SubstitutionBinder.Default, ArrayCache.Objects2, null);
            }
            return ctor.InvokeInstanceFast<object, TArg0, TArg1>(arg0, arg1);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T CreateInstance<T, TArg0, TArg1, TArg2>(TArg0 arg0, TArg1 arg1, TArg2 arg2)
        {
            var ctor = GetInstanceConstructorFullAccess<T, TArg0, TArg1, TArg2>();
            if (ctor == null)
            {
                ArrayCache.Objects3[0] = arg0;
                ArrayCache.Objects3[1] = arg1;
                ArrayCache.Objects3[2] = arg2;
                return (T)Activator.CreateInstance(typeof(T), REReflection.FullAccessInstanceLookUp, SubstitutionBinder.Default, ArrayCache.Objects3, null);
            }
            return ctor.InvokeInstanceFast<T, TArg0, TArg1, TArg2>(arg0, arg1, arg2);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static object CreateInstance<TArg0, TArg1, TArg2>(this Type self, TArg0 arg0, TArg1 arg1, TArg2 arg2)
        {
            var ctor = self.GetInstanceConstructorFullAccess<TArg0, TArg1, TArg2>();
            if (ctor == null)
            {
                ArrayCache.Objects3[0] = arg0;
                ArrayCache.Objects3[1] = arg1;
                ArrayCache.Objects3[2] = arg2;
                return Activator.CreateInstance(self, REReflection.FullAccessInstanceLookUp, SubstitutionBinder.Default, ArrayCache.Objects3, null);
            }
            return ctor.InvokeInstanceFast<object, TArg0, TArg1, TArg2>(arg0, arg1, arg2);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T CreateInstance<T, TArg0, TArg1, TArg2, TArg3>(TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3)
        {
            var ctor = GetInstanceConstructorFullAccess<T, TArg0, TArg1, TArg2, TArg3>();
            if (ctor == null)
            {
                ArrayCache.Objects4[0] = arg0;
                ArrayCache.Objects4[1] = arg1;
                ArrayCache.Objects4[2] = arg2;
                ArrayCache.Objects4[3] = arg3;
                return (T)Activator.CreateInstance(typeof(T), REReflection.FullAccessInstanceLookUp, SubstitutionBinder.Default, ArrayCache.Objects4, null);
            }
            return ctor.InvokeInstanceFast<T, TArg0, TArg1, TArg2, TArg3>(arg0, arg1, arg2, arg3);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static object CreateInstance<TArg0, TArg1, TArg2, TArg3>(this Type self, TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3)
        {
            var ctor = self.GetInstanceConstructorFullAccess<TArg0, TArg1, TArg2, TArg3>();
            if (ctor == null)
            {
                ArrayCache.Objects4[0] = arg0;
                ArrayCache.Objects4[1] = arg1;
                ArrayCache.Objects4[2] = arg2;
                ArrayCache.Objects4[3] = arg3;
                return Activator.CreateInstance(self, REReflection.FullAccessInstanceLookUp, SubstitutionBinder.Default, ArrayCache.Objects4, null);
            }
            return ctor.InvokeInstanceFast<object, TArg0, TArg1, TArg2, TArg3>(arg0, arg1, arg2, arg3);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T CreateInstance<T, TArg0, TArg1, TArg2, TArg3, TArg4>(TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4)
        {
            var ctor = GetInstanceConstructorFullAccess<T, TArg0, TArg1, TArg2, TArg3, TArg4>();
            if (ctor == null)
            {
                ArrayCache.Objects5[0] = arg0;
                ArrayCache.Objects5[1] = arg1;
                ArrayCache.Objects5[2] = arg2;
                ArrayCache.Objects5[3] = arg3;
                ArrayCache.Objects5[4] = arg4;
                return (T)Activator.CreateInstance(typeof(T), REReflection.FullAccessInstanceLookUp, SubstitutionBinder.Default, ArrayCache.Objects5, null);
            }
            return ctor.InvokeInstanceFast<T, TArg0, TArg1, TArg2, TArg3, TArg4>(arg0, arg1, arg2, arg3, arg4);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static object CreateInstance<TArg0, TArg1, TArg2, TArg3, TArg4>(this Type self, TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4)
        {
            var ctor = self.GetInstanceConstructorFullAccess<TArg0, TArg1, TArg2, TArg3, TArg4>();
            if (ctor == null)
            {
                ArrayCache.Objects5[0] = arg0;
                ArrayCache.Objects5[1] = arg1;
                ArrayCache.Objects5[2] = arg2;
                ArrayCache.Objects5[3] = arg3;
                ArrayCache.Objects5[4] = arg4;
                return Activator.CreateInstance(self, REReflection.FullAccessInstanceLookUp, SubstitutionBinder.Default, ArrayCache.Objects5, null);
            }
            return ctor.InvokeInstanceFast<object, TArg0, TArg1, TArg2, TArg3, TArg4>(arg0, arg1, arg2, arg3, arg4);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T CreateInstance<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5)
        {
            var ctor = GetInstanceConstructorFullAccess<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>();
            if (ctor == null)
            {
                ArrayCache.Objects6[0] = arg0;
                ArrayCache.Objects6[1] = arg1;
                ArrayCache.Objects6[2] = arg2;
                ArrayCache.Objects6[3] = arg3;
                ArrayCache.Objects6[4] = arg4;
                ArrayCache.Objects6[5] = arg5;
                return (T)Activator.CreateInstance(typeof(T), REReflection.FullAccessInstanceLookUp, SubstitutionBinder.Default, ArrayCache.Objects6, null);
            }
            return ctor.InvokeInstanceFast<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(arg0, arg1, arg2, arg3, arg4, arg5);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static object CreateInstance<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(this Type self, TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5)
        {
            var ctor = self.GetInstanceConstructorFullAccess<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>();
            if (ctor == null)
            {
                ArrayCache.Objects6[0] = arg0;
                ArrayCache.Objects6[1] = arg1;
                ArrayCache.Objects6[2] = arg2;
                ArrayCache.Objects6[3] = arg3;
                ArrayCache.Objects6[4] = arg4;
                ArrayCache.Objects6[5] = arg5;
                return Activator.CreateInstance(self, REReflection.FullAccessInstanceLookUp, SubstitutionBinder.Default, ArrayCache.Objects6, null);
            }
            return ctor.InvokeInstanceFast<object, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(arg0, arg1, arg2, arg3, arg4, arg5);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T CreateInstance<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6)
        {
            var ctor = GetInstanceConstructorFullAccess<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>();
            if (ctor == null)
            {
                ArrayCache.Objects7[0] = arg0;
                ArrayCache.Objects7[1] = arg1;
                ArrayCache.Objects7[2] = arg2;
                ArrayCache.Objects7[3] = arg3;
                ArrayCache.Objects7[4] = arg4;
                ArrayCache.Objects7[5] = arg5;
                ArrayCache.Objects7[6] = arg6;
                return (T)Activator.CreateInstance(typeof(T), REReflection.FullAccessInstanceLookUp, SubstitutionBinder.Default, ArrayCache.Objects7, null);
            }
            return ctor.InvokeInstanceFast<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(arg0, arg1, arg2, arg3, arg4, arg5, arg6);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static object CreateInstance<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(this Type self, TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6)
        {
            var ctor = self.GetInstanceConstructorFullAccess<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>();
            if (ctor == null)
            {
                ArrayCache.Objects7[0] = arg0;
                ArrayCache.Objects7[1] = arg1;
                ArrayCache.Objects7[2] = arg2;
                ArrayCache.Objects7[3] = arg3;
                ArrayCache.Objects7[4] = arg4;
                ArrayCache.Objects7[5] = arg5;
                ArrayCache.Objects7[6] = arg6;
                return Activator.CreateInstance(self, REReflection.FullAccessInstanceLookUp, SubstitutionBinder.Default, ArrayCache.Objects7, null);
            }
            return ctor.InvokeInstanceFast<object, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(arg0, arg1, arg2, arg3, arg4, arg5, arg6);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T CreateInstance<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7)
        {
            var ctor = GetInstanceConstructorFullAccess<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>();
            if (ctor == null)
            {
                ArrayCache.Objects8[0] = arg0;
                ArrayCache.Objects8[1] = arg1;
                ArrayCache.Objects8[2] = arg2;
                ArrayCache.Objects8[3] = arg3;
                ArrayCache.Objects8[4] = arg4;
                ArrayCache.Objects8[5] = arg5;
                ArrayCache.Objects8[6] = arg6;
                ArrayCache.Objects8[7] = arg7;
                return (T)Activator.CreateInstance(typeof(T), REReflection.FullAccessInstanceLookUp, SubstitutionBinder.Default, ArrayCache.Objects8, null);
            }
            return ctor.InvokeInstanceFast<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static object CreateInstance<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(this Type self, TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7)
        {
            var ctor = self.GetInstanceConstructorFullAccess<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>();
            if (ctor == null)
            {
                ArrayCache.Objects8[0] = arg0;
                ArrayCache.Objects8[1] = arg1;
                ArrayCache.Objects8[2] = arg2;
                ArrayCache.Objects8[3] = arg3;
                ArrayCache.Objects8[4] = arg4;
                ArrayCache.Objects8[5] = arg5;
                ArrayCache.Objects8[6] = arg6;
                ArrayCache.Objects8[7] = arg7;
                return Activator.CreateInstance(self, REReflection.FullAccessInstanceLookUp, SubstitutionBinder.Default, ArrayCache.Objects8, null);
            }
            return ctor.InvokeInstanceFast<object, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T CreateInstance<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8)
        {
            var ctor = GetInstanceConstructorFullAccess<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>();
            if (ctor == null)
            {
                ArrayCache.Objects9[0] = arg0;
                ArrayCache.Objects9[1] = arg1;
                ArrayCache.Objects9[2] = arg2;
                ArrayCache.Objects9[3] = arg3;
                ArrayCache.Objects9[4] = arg4;
                ArrayCache.Objects9[5] = arg5;
                ArrayCache.Objects9[6] = arg6;
                ArrayCache.Objects9[7] = arg7;
                ArrayCache.Objects9[8] = arg8;
                return (T)Activator.CreateInstance(typeof(T), REReflection.FullAccessInstanceLookUp, SubstitutionBinder.Default, ArrayCache.Objects9, null);
            }
            return ctor.InvokeInstanceFast<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static object CreateInstance<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(this Type self, TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8)
        {
            var ctor = self.GetInstanceConstructorFullAccess<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>();
            if (ctor == null)
            {
                ArrayCache.Objects9[0] = arg0;
                ArrayCache.Objects9[1] = arg1;
                ArrayCache.Objects9[2] = arg2;
                ArrayCache.Objects9[3] = arg3;
                ArrayCache.Objects9[4] = arg4;
                ArrayCache.Objects9[5] = arg5;
                ArrayCache.Objects9[6] = arg6;
                ArrayCache.Objects9[7] = arg7;
                ArrayCache.Objects9[8] = arg8;
                return Activator.CreateInstance(self, REReflection.FullAccessInstanceLookUp, SubstitutionBinder.Default, ArrayCache.Objects9, null);
            }
            return ctor.InvokeInstanceFast<object, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T CreateInstance<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9)
        {
            var ctor = GetInstanceConstructorFullAccess<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>();
            if (ctor == null)
            {
                ArrayCache.Objects10[0] = arg0;
                ArrayCache.Objects10[1] = arg1;
                ArrayCache.Objects10[2] = arg2;
                ArrayCache.Objects10[3] = arg3;
                ArrayCache.Objects10[4] = arg4;
                ArrayCache.Objects10[5] = arg5;
                ArrayCache.Objects10[6] = arg6;
                ArrayCache.Objects10[7] = arg7;
                ArrayCache.Objects10[8] = arg8;
                ArrayCache.Objects10[9] = arg9;
                return (T)Activator.CreateInstance(typeof(T), REReflection.FullAccessInstanceLookUp, SubstitutionBinder.Default, ArrayCache.Objects10, null);
            }
            return ctor.InvokeInstanceFast<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static object CreateInstance<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(this Type self, TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9)
        {
            var ctor = self.GetInstanceConstructorFullAccess<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>();
            if (ctor == null)
            {
                ArrayCache.Objects10[0] = arg0;
                ArrayCache.Objects10[1] = arg1;
                ArrayCache.Objects10[2] = arg2;
                ArrayCache.Objects10[3] = arg3;
                ArrayCache.Objects10[4] = arg4;
                ArrayCache.Objects10[5] = arg5;
                ArrayCache.Objects10[6] = arg6;
                ArrayCache.Objects10[7] = arg7;
                ArrayCache.Objects10[8] = arg8;
                ArrayCache.Objects10[9] = arg9;
                return Activator.CreateInstance(self, REReflection.FullAccessInstanceLookUp, SubstitutionBinder.Default, ArrayCache.Objects10, null);
            }
            return ctor.InvokeInstanceFast<object, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T CreateInstance<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, TArg10 arg10)
        {
            var ctor = GetInstanceConstructorFullAccess<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>();
            if (ctor == null)
            {
                ArrayCache.Objects11[0] = arg0;
                ArrayCache.Objects11[1] = arg1;
                ArrayCache.Objects11[2] = arg2;
                ArrayCache.Objects11[3] = arg3;
                ArrayCache.Objects11[4] = arg4;
                ArrayCache.Objects11[5] = arg5;
                ArrayCache.Objects11[6] = arg6;
                ArrayCache.Objects11[7] = arg7;
                ArrayCache.Objects11[8] = arg8;
                ArrayCache.Objects11[9] = arg9;
                ArrayCache.Objects11[10] = arg10;
                return (T)Activator.CreateInstance(typeof(T), REReflection.FullAccessInstanceLookUp, SubstitutionBinder.Default, ArrayCache.Objects11, null);
            }
            return ctor.InvokeInstanceFast<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static object CreateInstance<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(this Type self, TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, TArg10 arg10)
        {
            var ctor = self.GetInstanceConstructorFullAccess<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>();
            if (ctor == null)
            {
                ArrayCache.Objects11[0] = arg0;
                ArrayCache.Objects11[1] = arg1;
                ArrayCache.Objects11[2] = arg2;
                ArrayCache.Objects11[3] = arg3;
                ArrayCache.Objects11[4] = arg4;
                ArrayCache.Objects11[5] = arg5;
                ArrayCache.Objects11[6] = arg6;
                ArrayCache.Objects11[7] = arg7;
                ArrayCache.Objects11[8] = arg8;
                ArrayCache.Objects11[9] = arg9;
                ArrayCache.Objects11[10] = arg10;
                return Activator.CreateInstance(self, REReflection.FullAccessInstanceLookUp, SubstitutionBinder.Default, ArrayCache.Objects11, null);
            }
            return ctor.InvokeInstanceFast<object, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T CreateInstance<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, TArg10 arg10, TArg11 arg11)
        {
            var ctor = GetInstanceConstructorFullAccess<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>();
            if (ctor == null)
            {
                ArrayCache.Objects12[0] = arg0;
                ArrayCache.Objects12[1] = arg1;
                ArrayCache.Objects12[2] = arg2;
                ArrayCache.Objects12[3] = arg3;
                ArrayCache.Objects12[4] = arg4;
                ArrayCache.Objects12[5] = arg5;
                ArrayCache.Objects12[6] = arg6;
                ArrayCache.Objects12[7] = arg7;
                ArrayCache.Objects12[8] = arg8;
                ArrayCache.Objects12[9] = arg9;
                ArrayCache.Objects12[10] = arg10;
                ArrayCache.Objects12[11] = arg11;
                return (T)Activator.CreateInstance(typeof(T), REReflection.FullAccessInstanceLookUp, SubstitutionBinder.Default, ArrayCache.Objects12, null);
            }
            return ctor.InvokeInstanceFast<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static object CreateInstance<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(this Type self, TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, TArg10 arg10, TArg11 arg11)
        {
            var ctor = self.GetInstanceConstructorFullAccess<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>();
            if (ctor == null)
            {
                ArrayCache.Objects12[0] = arg0;
                ArrayCache.Objects12[1] = arg1;
                ArrayCache.Objects12[2] = arg2;
                ArrayCache.Objects12[3] = arg3;
                ArrayCache.Objects12[4] = arg4;
                ArrayCache.Objects12[5] = arg5;
                ArrayCache.Objects12[6] = arg6;
                ArrayCache.Objects12[7] = arg7;
                ArrayCache.Objects12[8] = arg8;
                ArrayCache.Objects12[9] = arg9;
                ArrayCache.Objects12[10] = arg10;
                ArrayCache.Objects12[11] = arg11;
                return Activator.CreateInstance(self, REReflection.FullAccessInstanceLookUp, SubstitutionBinder.Default, ArrayCache.Objects12, null);
            }
            return ctor.InvokeInstanceFast<object, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T CreateInstance<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, TArg10 arg10, TArg11 arg11, TArg12 arg12)
        {
            var ctor = GetInstanceConstructorFullAccess<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>();
            if (ctor == null)
            {
                ArrayCache.Objects13[0] = arg0;
                ArrayCache.Objects13[1] = arg1;
                ArrayCache.Objects13[2] = arg2;
                ArrayCache.Objects13[3] = arg3;
                ArrayCache.Objects13[4] = arg4;
                ArrayCache.Objects13[5] = arg5;
                ArrayCache.Objects13[6] = arg6;
                ArrayCache.Objects13[7] = arg7;
                ArrayCache.Objects13[8] = arg8;
                ArrayCache.Objects13[9] = arg9;
                ArrayCache.Objects13[10] = arg10;
                ArrayCache.Objects13[11] = arg11;
                ArrayCache.Objects13[12] = arg12;
                return (T)Activator.CreateInstance(typeof(T), REReflection.FullAccessInstanceLookUp, SubstitutionBinder.Default, ArrayCache.Objects13, null);
            }
            return ctor.InvokeInstanceFast<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static object CreateInstance<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(this Type self, TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, TArg10 arg10, TArg11 arg11, TArg12 arg12)
        {
            var ctor = self.GetInstanceConstructorFullAccess<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>();
            if (ctor == null)
            {
                ArrayCache.Objects13[0] = arg0;
                ArrayCache.Objects13[1] = arg1;
                ArrayCache.Objects13[2] = arg2;
                ArrayCache.Objects13[3] = arg3;
                ArrayCache.Objects13[4] = arg4;
                ArrayCache.Objects13[5] = arg5;
                ArrayCache.Objects13[6] = arg6;
                ArrayCache.Objects13[7] = arg7;
                ArrayCache.Objects13[8] = arg8;
                ArrayCache.Objects13[9] = arg9;
                ArrayCache.Objects13[10] = arg10;
                ArrayCache.Objects13[11] = arg11;
                ArrayCache.Objects13[12] = arg12;
                return Activator.CreateInstance(self, REReflection.FullAccessInstanceLookUp, SubstitutionBinder.Default, ArrayCache.Objects13, null);
            }
            return ctor.InvokeInstanceFast<object, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T CreateInstance<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, TArg10 arg10, TArg11 arg11, TArg12 arg12, TArg13 arg13)
        {
            var ctor = GetInstanceConstructorFullAccess<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>();
            if (ctor == null)
            {
                ArrayCache.Objects14[0] = arg0;
                ArrayCache.Objects14[1] = arg1;
                ArrayCache.Objects14[2] = arg2;
                ArrayCache.Objects14[3] = arg3;
                ArrayCache.Objects14[4] = arg4;
                ArrayCache.Objects14[5] = arg5;
                ArrayCache.Objects14[6] = arg6;
                ArrayCache.Objects14[7] = arg7;
                ArrayCache.Objects14[8] = arg8;
                ArrayCache.Objects14[9] = arg9;
                ArrayCache.Objects14[10] = arg10;
                ArrayCache.Objects14[11] = arg11;
                ArrayCache.Objects14[12] = arg12;
                ArrayCache.Objects14[13] = arg13;
                return (T)Activator.CreateInstance(typeof(T), REReflection.FullAccessInstanceLookUp, SubstitutionBinder.Default, ArrayCache.Objects14, null);
            }
            return ctor.InvokeInstanceFast<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static object CreateInstance<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(this Type self, TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, TArg10 arg10, TArg11 arg11, TArg12 arg12, TArg13 arg13)
        {
            var ctor = self.GetInstanceConstructorFullAccess<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>();
            if (ctor == null)
            {
                ArrayCache.Objects14[0] = arg0;
                ArrayCache.Objects14[1] = arg1;
                ArrayCache.Objects14[2] = arg2;
                ArrayCache.Objects14[3] = arg3;
                ArrayCache.Objects14[4] = arg4;
                ArrayCache.Objects14[5] = arg5;
                ArrayCache.Objects14[6] = arg6;
                ArrayCache.Objects14[7] = arg7;
                ArrayCache.Objects14[8] = arg8;
                ArrayCache.Objects14[9] = arg9;
                ArrayCache.Objects14[10] = arg10;
                ArrayCache.Objects14[11] = arg11;
                ArrayCache.Objects14[12] = arg12;
                ArrayCache.Objects14[13] = arg13;
                return Activator.CreateInstance(self, REReflection.FullAccessInstanceLookUp, SubstitutionBinder.Default, ArrayCache.Objects14, null);
            }
            return ctor.InvokeInstanceFast<object, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T CreateInstance<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, TArg10 arg10, TArg11 arg11, TArg12 arg12, TArg13 arg13, TArg14 arg14)
        {
            var ctor = GetInstanceConstructorFullAccess<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>();
            if (ctor == null)
            {
                ArrayCache.Objects15[0] = arg0;
                ArrayCache.Objects15[1] = arg1;
                ArrayCache.Objects15[2] = arg2;
                ArrayCache.Objects15[3] = arg3;
                ArrayCache.Objects15[4] = arg4;
                ArrayCache.Objects15[5] = arg5;
                ArrayCache.Objects15[6] = arg6;
                ArrayCache.Objects15[7] = arg7;
                ArrayCache.Objects15[8] = arg8;
                ArrayCache.Objects15[9] = arg9;
                ArrayCache.Objects15[10] = arg10;
                ArrayCache.Objects15[11] = arg11;
                ArrayCache.Objects15[12] = arg12;
                ArrayCache.Objects15[13] = arg13;
                ArrayCache.Objects15[14] = arg14;
                return (T)Activator.CreateInstance(typeof(T), REReflection.FullAccessInstanceLookUp, SubstitutionBinder.Default, ArrayCache.Objects15, null);
            }
            return ctor.InvokeInstanceFast<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static object CreateInstance<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(this Type self, TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, TArg10 arg10, TArg11 arg11, TArg12 arg12, TArg13 arg13, TArg14 arg14)
        {
            var ctor = self.GetInstanceConstructorFullAccess<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>();
            if (ctor == null)
            {
                ArrayCache.Objects15[0] = arg0;
                ArrayCache.Objects15[1] = arg1;
                ArrayCache.Objects15[2] = arg2;
                ArrayCache.Objects15[3] = arg3;
                ArrayCache.Objects15[4] = arg4;
                ArrayCache.Objects15[5] = arg5;
                ArrayCache.Objects15[6] = arg6;
                ArrayCache.Objects15[7] = arg7;
                ArrayCache.Objects15[8] = arg8;
                ArrayCache.Objects15[9] = arg9;
                ArrayCache.Objects15[10] = arg10;
                ArrayCache.Objects15[11] = arg11;
                ArrayCache.Objects15[12] = arg12;
                ArrayCache.Objects15[13] = arg13;
                ArrayCache.Objects15[14] = arg14;
                return Activator.CreateInstance(self, REReflection.FullAccessInstanceLookUp, SubstitutionBinder.Default, ArrayCache.Objects15, null);
            }
            return ctor.InvokeInstanceFast<object, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T CreateInstance<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, TArg10 arg10, TArg11 arg11, TArg12 arg12, TArg13 arg13, TArg14 arg14, TArg15 arg15)
        {
            var ctor = GetInstanceConstructorFullAccess<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>();
            if (ctor == null)
            {
                ArrayCache.Objects16[0] = arg0;
                ArrayCache.Objects16[1] = arg1;
                ArrayCache.Objects16[2] = arg2;
                ArrayCache.Objects16[3] = arg3;
                ArrayCache.Objects16[4] = arg4;
                ArrayCache.Objects16[5] = arg5;
                ArrayCache.Objects16[6] = arg6;
                ArrayCache.Objects16[7] = arg7;
                ArrayCache.Objects16[8] = arg8;
                ArrayCache.Objects16[9] = arg9;
                ArrayCache.Objects16[10] = arg10;
                ArrayCache.Objects16[11] = arg11;
                ArrayCache.Objects16[12] = arg12;
                ArrayCache.Objects16[13] = arg13;
                ArrayCache.Objects16[14] = arg14;
                ArrayCache.Objects16[15] = arg15;
                return (T)Activator.CreateInstance(typeof(T), REReflection.FullAccessInstanceLookUp, SubstitutionBinder.Default, ArrayCache.Objects16, null);
            }
            return ctor.InvokeInstanceFast<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static object CreateInstance<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(this Type self, TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, TArg10 arg10, TArg11 arg11, TArg12 arg12, TArg13 arg13, TArg14 arg14, TArg15 arg15)
        {
            var ctor = self.GetInstanceConstructorFullAccess<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>();
            if (ctor == null)
            {
                ArrayCache.Objects16[0] = arg0;
                ArrayCache.Objects16[1] = arg1;
                ArrayCache.Objects16[2] = arg2;
                ArrayCache.Objects16[3] = arg3;
                ArrayCache.Objects16[4] = arg4;
                ArrayCache.Objects16[5] = arg5;
                ArrayCache.Objects16[6] = arg6;
                ArrayCache.Objects16[7] = arg7;
                ArrayCache.Objects16[8] = arg8;
                ArrayCache.Objects16[9] = arg9;
                ArrayCache.Objects16[10] = arg10;
                ArrayCache.Objects16[11] = arg11;
                ArrayCache.Objects16[12] = arg12;
                ArrayCache.Objects16[13] = arg13;
                ArrayCache.Objects16[14] = arg14;
                ArrayCache.Objects16[15] = arg15;
                return Activator.CreateInstance(self, REReflection.FullAccessInstanceLookUp, SubstitutionBinder.Default, ArrayCache.Objects16, null);
            }
            return ctor.InvokeInstanceFast<object, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15);
        }
    }
}

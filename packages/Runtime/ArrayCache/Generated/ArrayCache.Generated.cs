using System;
using System.Reflection;
using System.Runtime.CompilerServices;
namespace Katuusagi.ReflectionEnhance
{
    internal static partial class ArrayCache
    {
        [ThreadStatic]
        private static Type[] _types0;
        [ThreadStatic]
        private static object[] _objects0;
        [ThreadStatic]
        private static int[] _ints0;
        [ThreadStatic]
        private static ParameterInfo[] _defaultParameters0;
        [ThreadStatic]
        private static Type[] _types1;
        [ThreadStatic]
        private static object[] _objects1;
        [ThreadStatic]
        private static int[] _ints1;
        [ThreadStatic]
        private static ParameterInfo[] _defaultParameters1;
        [ThreadStatic]
        private static Type[] _types2;
        [ThreadStatic]
        private static object[] _objects2;
        [ThreadStatic]
        private static int[] _ints2;
        [ThreadStatic]
        private static ParameterInfo[] _defaultParameters2;
        [ThreadStatic]
        private static Type[] _types3;
        [ThreadStatic]
        private static object[] _objects3;
        [ThreadStatic]
        private static int[] _ints3;
        [ThreadStatic]
        private static ParameterInfo[] _defaultParameters3;
        [ThreadStatic]
        private static Type[] _types4;
        [ThreadStatic]
        private static object[] _objects4;
        [ThreadStatic]
        private static int[] _ints4;
        [ThreadStatic]
        private static ParameterInfo[] _defaultParameters4;
        [ThreadStatic]
        private static Type[] _types5;
        [ThreadStatic]
        private static object[] _objects5;
        [ThreadStatic]
        private static int[] _ints5;
        [ThreadStatic]
        private static ParameterInfo[] _defaultParameters5;
        [ThreadStatic]
        private static Type[] _types6;
        [ThreadStatic]
        private static object[] _objects6;
        [ThreadStatic]
        private static int[] _ints6;
        [ThreadStatic]
        private static ParameterInfo[] _defaultParameters6;
        [ThreadStatic]
        private static Type[] _types7;
        [ThreadStatic]
        private static object[] _objects7;
        [ThreadStatic]
        private static int[] _ints7;
        [ThreadStatic]
        private static ParameterInfo[] _defaultParameters7;
        [ThreadStatic]
        private static Type[] _types8;
        [ThreadStatic]
        private static object[] _objects8;
        [ThreadStatic]
        private static int[] _ints8;
        [ThreadStatic]
        private static ParameterInfo[] _defaultParameters8;
        [ThreadStatic]
        private static Type[] _types9;
        [ThreadStatic]
        private static object[] _objects9;
        [ThreadStatic]
        private static int[] _ints9;
        [ThreadStatic]
        private static ParameterInfo[] _defaultParameters9;
        [ThreadStatic]
        private static Type[] _types10;
        [ThreadStatic]
        private static object[] _objects10;
        [ThreadStatic]
        private static int[] _ints10;
        [ThreadStatic]
        private static ParameterInfo[] _defaultParameters10;
        [ThreadStatic]
        private static Type[] _types11;
        [ThreadStatic]
        private static object[] _objects11;
        [ThreadStatic]
        private static int[] _ints11;
        [ThreadStatic]
        private static ParameterInfo[] _defaultParameters11;
        [ThreadStatic]
        private static Type[] _types12;
        [ThreadStatic]
        private static object[] _objects12;
        [ThreadStatic]
        private static int[] _ints12;
        [ThreadStatic]
        private static ParameterInfo[] _defaultParameters12;
        [ThreadStatic]
        private static Type[] _types13;
        [ThreadStatic]
        private static object[] _objects13;
        [ThreadStatic]
        private static int[] _ints13;
        [ThreadStatic]
        private static ParameterInfo[] _defaultParameters13;
        [ThreadStatic]
        private static Type[] _types14;
        [ThreadStatic]
        private static object[] _objects14;
        [ThreadStatic]
        private static int[] _ints14;
        [ThreadStatic]
        private static ParameterInfo[] _defaultParameters14;
        [ThreadStatic]
        private static Type[] _types15;
        [ThreadStatic]
        private static object[] _objects15;
        [ThreadStatic]
        private static int[] _ints15;
        [ThreadStatic]
        private static ParameterInfo[] _defaultParameters15;
        [ThreadStatic]
        private static Type[] _types16;
        [ThreadStatic]
        private static object[] _objects16;
        [ThreadStatic]
        private static int[] _ints16;
        [ThreadStatic]
        private static ParameterInfo[] _defaultParameters16;
        internal static Type[] Types0
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (_types0 == null)
                {
                    _types0 = GetArrayCache<Type>(0);
                }
                return _types0;
            }
        }
        internal static object[] Objects0
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (_objects0 == null)
                {
                    _objects0 = GetArrayCache<object>(0);
                }
                return _objects0;
            }
        }
        internal static int[] Ints0
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (_ints0 == null)
                {
                    _ints0 = GetArrayCache<int>(0);
                }
                return _ints0;
            }
        }
        internal static ParameterInfo[] DefaultParameters0
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (_defaultParameters0 == null)
                {
                    _defaultParameters0 = GetDefaultArrayCache<ParameterInfo>(0);
                }
                return _defaultParameters0;
            }
        }
        internal static Type[] Types1
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (_types1 == null)
                {
                    _types1 = GetArrayCache<Type>(1);
                }
                return _types1;
            }
        }
        internal static object[] Objects1
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (_objects1 == null)
                {
                    _objects1 = GetArrayCache<object>(1);
                }
                return _objects1;
            }
        }
        internal static int[] Ints1
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (_ints1 == null)
                {
                    _ints1 = GetArrayCache<int>(1);
                }
                return _ints1;
            }
        }
        internal static ParameterInfo[] DefaultParameters1
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (_defaultParameters1 == null)
                {
                    _defaultParameters1 = GetDefaultArrayCache<ParameterInfo>(1);
                }
                return _defaultParameters1;
            }
        }
        internal static Type[] Types2
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (_types2 == null)
                {
                    _types2 = GetArrayCache<Type>(2);
                }
                return _types2;
            }
        }
        internal static object[] Objects2
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (_objects2 == null)
                {
                    _objects2 = GetArrayCache<object>(2);
                }
                return _objects2;
            }
        }
        internal static int[] Ints2
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (_ints2 == null)
                {
                    _ints2 = GetArrayCache<int>(2);
                }
                return _ints2;
            }
        }
        internal static ParameterInfo[] DefaultParameters2
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (_defaultParameters2 == null)
                {
                    _defaultParameters2 = GetDefaultArrayCache<ParameterInfo>(2);
                }
                return _defaultParameters2;
            }
        }
        internal static Type[] Types3
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (_types3 == null)
                {
                    _types3 = GetArrayCache<Type>(3);
                }
                return _types3;
            }
        }
        internal static object[] Objects3
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (_objects3 == null)
                {
                    _objects3 = GetArrayCache<object>(3);
                }
                return _objects3;
            }
        }
        internal static int[] Ints3
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (_ints3 == null)
                {
                    _ints3 = GetArrayCache<int>(3);
                }
                return _ints3;
            }
        }
        internal static ParameterInfo[] DefaultParameters3
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (_defaultParameters3 == null)
                {
                    _defaultParameters3 = GetDefaultArrayCache<ParameterInfo>(3);
                }
                return _defaultParameters3;
            }
        }
        internal static Type[] Types4
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (_types4 == null)
                {
                    _types4 = GetArrayCache<Type>(4);
                }
                return _types4;
            }
        }
        internal static object[] Objects4
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (_objects4 == null)
                {
                    _objects4 = GetArrayCache<object>(4);
                }
                return _objects4;
            }
        }
        internal static int[] Ints4
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (_ints4 == null)
                {
                    _ints4 = GetArrayCache<int>(4);
                }
                return _ints4;
            }
        }
        internal static ParameterInfo[] DefaultParameters4
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (_defaultParameters4 == null)
                {
                    _defaultParameters4 = GetDefaultArrayCache<ParameterInfo>(4);
                }
                return _defaultParameters4;
            }
        }
        internal static Type[] Types5
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (_types5 == null)
                {
                    _types5 = GetArrayCache<Type>(5);
                }
                return _types5;
            }
        }
        internal static object[] Objects5
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (_objects5 == null)
                {
                    _objects5 = GetArrayCache<object>(5);
                }
                return _objects5;
            }
        }
        internal static int[] Ints5
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (_ints5 == null)
                {
                    _ints5 = GetArrayCache<int>(5);
                }
                return _ints5;
            }
        }
        internal static ParameterInfo[] DefaultParameters5
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (_defaultParameters5 == null)
                {
                    _defaultParameters5 = GetDefaultArrayCache<ParameterInfo>(5);
                }
                return _defaultParameters5;
            }
        }
        internal static Type[] Types6
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (_types6 == null)
                {
                    _types6 = GetArrayCache<Type>(6);
                }
                return _types6;
            }
        }
        internal static object[] Objects6
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (_objects6 == null)
                {
                    _objects6 = GetArrayCache<object>(6);
                }
                return _objects6;
            }
        }
        internal static int[] Ints6
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (_ints6 == null)
                {
                    _ints6 = GetArrayCache<int>(6);
                }
                return _ints6;
            }
        }
        internal static ParameterInfo[] DefaultParameters6
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (_defaultParameters6 == null)
                {
                    _defaultParameters6 = GetDefaultArrayCache<ParameterInfo>(6);
                }
                return _defaultParameters6;
            }
        }
        internal static Type[] Types7
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (_types7 == null)
                {
                    _types7 = GetArrayCache<Type>(7);
                }
                return _types7;
            }
        }
        internal static object[] Objects7
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (_objects7 == null)
                {
                    _objects7 = GetArrayCache<object>(7);
                }
                return _objects7;
            }
        }
        internal static int[] Ints7
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (_ints7 == null)
                {
                    _ints7 = GetArrayCache<int>(7);
                }
                return _ints7;
            }
        }
        internal static ParameterInfo[] DefaultParameters7
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (_defaultParameters7 == null)
                {
                    _defaultParameters7 = GetDefaultArrayCache<ParameterInfo>(7);
                }
                return _defaultParameters7;
            }
        }
        internal static Type[] Types8
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (_types8 == null)
                {
                    _types8 = GetArrayCache<Type>(8);
                }
                return _types8;
            }
        }
        internal static object[] Objects8
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (_objects8 == null)
                {
                    _objects8 = GetArrayCache<object>(8);
                }
                return _objects8;
            }
        }
        internal static int[] Ints8
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (_ints8 == null)
                {
                    _ints8 = GetArrayCache<int>(8);
                }
                return _ints8;
            }
        }
        internal static ParameterInfo[] DefaultParameters8
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (_defaultParameters8 == null)
                {
                    _defaultParameters8 = GetDefaultArrayCache<ParameterInfo>(8);
                }
                return _defaultParameters8;
            }
        }
        internal static Type[] Types9
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (_types9 == null)
                {
                    _types9 = GetArrayCache<Type>(9);
                }
                return _types9;
            }
        }
        internal static object[] Objects9
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (_objects9 == null)
                {
                    _objects9 = GetArrayCache<object>(9);
                }
                return _objects9;
            }
        }
        internal static int[] Ints9
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (_ints9 == null)
                {
                    _ints9 = GetArrayCache<int>(9);
                }
                return _ints9;
            }
        }
        internal static ParameterInfo[] DefaultParameters9
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (_defaultParameters9 == null)
                {
                    _defaultParameters9 = GetDefaultArrayCache<ParameterInfo>(9);
                }
                return _defaultParameters9;
            }
        }
        internal static Type[] Types10
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (_types10 == null)
                {
                    _types10 = GetArrayCache<Type>(10);
                }
                return _types10;
            }
        }
        internal static object[] Objects10
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (_objects10 == null)
                {
                    _objects10 = GetArrayCache<object>(10);
                }
                return _objects10;
            }
        }
        internal static int[] Ints10
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (_ints10 == null)
                {
                    _ints10 = GetArrayCache<int>(10);
                }
                return _ints10;
            }
        }
        internal static ParameterInfo[] DefaultParameters10
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (_defaultParameters10 == null)
                {
                    _defaultParameters10 = GetDefaultArrayCache<ParameterInfo>(10);
                }
                return _defaultParameters10;
            }
        }
        internal static Type[] Types11
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (_types11 == null)
                {
                    _types11 = GetArrayCache<Type>(11);
                }
                return _types11;
            }
        }
        internal static object[] Objects11
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (_objects11 == null)
                {
                    _objects11 = GetArrayCache<object>(11);
                }
                return _objects11;
            }
        }
        internal static int[] Ints11
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (_ints11 == null)
                {
                    _ints11 = GetArrayCache<int>(11);
                }
                return _ints11;
            }
        }
        internal static ParameterInfo[] DefaultParameters11
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (_defaultParameters11 == null)
                {
                    _defaultParameters11 = GetDefaultArrayCache<ParameterInfo>(11);
                }
                return _defaultParameters11;
            }
        }
        internal static Type[] Types12
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (_types12 == null)
                {
                    _types12 = GetArrayCache<Type>(12);
                }
                return _types12;
            }
        }
        internal static object[] Objects12
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (_objects12 == null)
                {
                    _objects12 = GetArrayCache<object>(12);
                }
                return _objects12;
            }
        }
        internal static int[] Ints12
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (_ints12 == null)
                {
                    _ints12 = GetArrayCache<int>(12);
                }
                return _ints12;
            }
        }
        internal static ParameterInfo[] DefaultParameters12
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (_defaultParameters12 == null)
                {
                    _defaultParameters12 = GetDefaultArrayCache<ParameterInfo>(12);
                }
                return _defaultParameters12;
            }
        }
        internal static Type[] Types13
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (_types13 == null)
                {
                    _types13 = GetArrayCache<Type>(13);
                }
                return _types13;
            }
        }
        internal static object[] Objects13
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (_objects13 == null)
                {
                    _objects13 = GetArrayCache<object>(13);
                }
                return _objects13;
            }
        }
        internal static int[] Ints13
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (_ints13 == null)
                {
                    _ints13 = GetArrayCache<int>(13);
                }
                return _ints13;
            }
        }
        internal static ParameterInfo[] DefaultParameters13
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (_defaultParameters13 == null)
                {
                    _defaultParameters13 = GetDefaultArrayCache<ParameterInfo>(13);
                }
                return _defaultParameters13;
            }
        }
        internal static Type[] Types14
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (_types14 == null)
                {
                    _types14 = GetArrayCache<Type>(14);
                }
                return _types14;
            }
        }
        internal static object[] Objects14
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (_objects14 == null)
                {
                    _objects14 = GetArrayCache<object>(14);
                }
                return _objects14;
            }
        }
        internal static int[] Ints14
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (_ints14 == null)
                {
                    _ints14 = GetArrayCache<int>(14);
                }
                return _ints14;
            }
        }
        internal static ParameterInfo[] DefaultParameters14
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (_defaultParameters14 == null)
                {
                    _defaultParameters14 = GetDefaultArrayCache<ParameterInfo>(14);
                }
                return _defaultParameters14;
            }
        }
        internal static Type[] Types15
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (_types15 == null)
                {
                    _types15 = GetArrayCache<Type>(15);
                }
                return _types15;
            }
        }
        internal static object[] Objects15
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (_objects15 == null)
                {
                    _objects15 = GetArrayCache<object>(15);
                }
                return _objects15;
            }
        }
        internal static int[] Ints15
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (_ints15 == null)
                {
                    _ints15 = GetArrayCache<int>(15);
                }
                return _ints15;
            }
        }
        internal static ParameterInfo[] DefaultParameters15
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (_defaultParameters15 == null)
                {
                    _defaultParameters15 = GetDefaultArrayCache<ParameterInfo>(15);
                }
                return _defaultParameters15;
            }
        }
        internal static Type[] Types16
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (_types16 == null)
                {
                    _types16 = GetArrayCache<Type>(16);
                }
                return _types16;
            }
        }
        internal static object[] Objects16
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (_objects16 == null)
                {
                    _objects16 = GetArrayCache<object>(16);
                }
                return _objects16;
            }
        }
        internal static int[] Ints16
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (_ints16 == null)
                {
                    _ints16 = GetArrayCache<int>(16);
                }
                return _ints16;
            }
        }
        internal static ParameterInfo[] DefaultParameters16
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (_defaultParameters16 == null)
                {
                    _defaultParameters16 = GetDefaultArrayCache<ParameterInfo>(16);
                }
                return _defaultParameters16;
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Type[] MakeTypeArray()
        {
            return Types0;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Type[] MakeTypeArray<TArg0>()
        {
            Types1[0] = typeof(TArg0);
            return Types1;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Type[] MakeTypeArray(Type type0)
        {
            Types1[0] = type0;
            return Types1;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Type[] MakeTypeArray<TArg0, TArg1>()
        {
            Types2[0] = typeof(TArg0);
            Types2[1] = typeof(TArg1);
            return Types2;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Type[] MakeTypeArray(Type type0, Type type1)
        {
            Types2[0] = type0;
            Types2[1] = type1;
            return Types2;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Type[] MakeTypeArray<TArg0, TArg1, TArg2>()
        {
            Types3[0] = typeof(TArg0);
            Types3[1] = typeof(TArg1);
            Types3[2] = typeof(TArg2);
            return Types3;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Type[] MakeTypeArray(Type type0, Type type1, Type type2)
        {
            Types3[0] = type0;
            Types3[1] = type1;
            Types3[2] = type2;
            return Types3;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Type[] MakeTypeArray<TArg0, TArg1, TArg2, TArg3>()
        {
            Types4[0] = typeof(TArg0);
            Types4[1] = typeof(TArg1);
            Types4[2] = typeof(TArg2);
            Types4[3] = typeof(TArg3);
            return Types4;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Type[] MakeTypeArray(Type type0, Type type1, Type type2, Type type3)
        {
            Types4[0] = type0;
            Types4[1] = type1;
            Types4[2] = type2;
            Types4[3] = type3;
            return Types4;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Type[] MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>()
        {
            Types5[0] = typeof(TArg0);
            Types5[1] = typeof(TArg1);
            Types5[2] = typeof(TArg2);
            Types5[3] = typeof(TArg3);
            Types5[4] = typeof(TArg4);
            return Types5;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Type[] MakeTypeArray(Type type0, Type type1, Type type2, Type type3, Type type4)
        {
            Types5[0] = type0;
            Types5[1] = type1;
            Types5[2] = type2;
            Types5[3] = type3;
            Types5[4] = type4;
            return Types5;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Type[] MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>()
        {
            Types6[0] = typeof(TArg0);
            Types6[1] = typeof(TArg1);
            Types6[2] = typeof(TArg2);
            Types6[3] = typeof(TArg3);
            Types6[4] = typeof(TArg4);
            Types6[5] = typeof(TArg5);
            return Types6;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Type[] MakeTypeArray(Type type0, Type type1, Type type2, Type type3, Type type4, Type type5)
        {
            Types6[0] = type0;
            Types6[1] = type1;
            Types6[2] = type2;
            Types6[3] = type3;
            Types6[4] = type4;
            Types6[5] = type5;
            return Types6;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Type[] MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>()
        {
            Types7[0] = typeof(TArg0);
            Types7[1] = typeof(TArg1);
            Types7[2] = typeof(TArg2);
            Types7[3] = typeof(TArg3);
            Types7[4] = typeof(TArg4);
            Types7[5] = typeof(TArg5);
            Types7[6] = typeof(TArg6);
            return Types7;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Type[] MakeTypeArray(Type type0, Type type1, Type type2, Type type3, Type type4, Type type5, Type type6)
        {
            Types7[0] = type0;
            Types7[1] = type1;
            Types7[2] = type2;
            Types7[3] = type3;
            Types7[4] = type4;
            Types7[5] = type5;
            Types7[6] = type6;
            return Types7;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Type[] MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>()
        {
            Types8[0] = typeof(TArg0);
            Types8[1] = typeof(TArg1);
            Types8[2] = typeof(TArg2);
            Types8[3] = typeof(TArg3);
            Types8[4] = typeof(TArg4);
            Types8[5] = typeof(TArg5);
            Types8[6] = typeof(TArg6);
            Types8[7] = typeof(TArg7);
            return Types8;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Type[] MakeTypeArray(Type type0, Type type1, Type type2, Type type3, Type type4, Type type5, Type type6, Type type7)
        {
            Types8[0] = type0;
            Types8[1] = type1;
            Types8[2] = type2;
            Types8[3] = type3;
            Types8[4] = type4;
            Types8[5] = type5;
            Types8[6] = type6;
            Types8[7] = type7;
            return Types8;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Type[] MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>()
        {
            Types9[0] = typeof(TArg0);
            Types9[1] = typeof(TArg1);
            Types9[2] = typeof(TArg2);
            Types9[3] = typeof(TArg3);
            Types9[4] = typeof(TArg4);
            Types9[5] = typeof(TArg5);
            Types9[6] = typeof(TArg6);
            Types9[7] = typeof(TArg7);
            Types9[8] = typeof(TArg8);
            return Types9;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Type[] MakeTypeArray(Type type0, Type type1, Type type2, Type type3, Type type4, Type type5, Type type6, Type type7, Type type8)
        {
            Types9[0] = type0;
            Types9[1] = type1;
            Types9[2] = type2;
            Types9[3] = type3;
            Types9[4] = type4;
            Types9[5] = type5;
            Types9[6] = type6;
            Types9[7] = type7;
            Types9[8] = type8;
            return Types9;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Type[] MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>()
        {
            Types10[0] = typeof(TArg0);
            Types10[1] = typeof(TArg1);
            Types10[2] = typeof(TArg2);
            Types10[3] = typeof(TArg3);
            Types10[4] = typeof(TArg4);
            Types10[5] = typeof(TArg5);
            Types10[6] = typeof(TArg6);
            Types10[7] = typeof(TArg7);
            Types10[8] = typeof(TArg8);
            Types10[9] = typeof(TArg9);
            return Types10;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Type[] MakeTypeArray(Type type0, Type type1, Type type2, Type type3, Type type4, Type type5, Type type6, Type type7, Type type8, Type type9)
        {
            Types10[0] = type0;
            Types10[1] = type1;
            Types10[2] = type2;
            Types10[3] = type3;
            Types10[4] = type4;
            Types10[5] = type5;
            Types10[6] = type6;
            Types10[7] = type7;
            Types10[8] = type8;
            Types10[9] = type9;
            return Types10;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Type[] MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>()
        {
            Types11[0] = typeof(TArg0);
            Types11[1] = typeof(TArg1);
            Types11[2] = typeof(TArg2);
            Types11[3] = typeof(TArg3);
            Types11[4] = typeof(TArg4);
            Types11[5] = typeof(TArg5);
            Types11[6] = typeof(TArg6);
            Types11[7] = typeof(TArg7);
            Types11[8] = typeof(TArg8);
            Types11[9] = typeof(TArg9);
            Types11[10] = typeof(TArg10);
            return Types11;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Type[] MakeTypeArray(Type type0, Type type1, Type type2, Type type3, Type type4, Type type5, Type type6, Type type7, Type type8, Type type9, Type type10)
        {
            Types11[0] = type0;
            Types11[1] = type1;
            Types11[2] = type2;
            Types11[3] = type3;
            Types11[4] = type4;
            Types11[5] = type5;
            Types11[6] = type6;
            Types11[7] = type7;
            Types11[8] = type8;
            Types11[9] = type9;
            Types11[10] = type10;
            return Types11;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Type[] MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>()
        {
            Types12[0] = typeof(TArg0);
            Types12[1] = typeof(TArg1);
            Types12[2] = typeof(TArg2);
            Types12[3] = typeof(TArg3);
            Types12[4] = typeof(TArg4);
            Types12[5] = typeof(TArg5);
            Types12[6] = typeof(TArg6);
            Types12[7] = typeof(TArg7);
            Types12[8] = typeof(TArg8);
            Types12[9] = typeof(TArg9);
            Types12[10] = typeof(TArg10);
            Types12[11] = typeof(TArg11);
            return Types12;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Type[] MakeTypeArray(Type type0, Type type1, Type type2, Type type3, Type type4, Type type5, Type type6, Type type7, Type type8, Type type9, Type type10, Type type11)
        {
            Types12[0] = type0;
            Types12[1] = type1;
            Types12[2] = type2;
            Types12[3] = type3;
            Types12[4] = type4;
            Types12[5] = type5;
            Types12[6] = type6;
            Types12[7] = type7;
            Types12[8] = type8;
            Types12[9] = type9;
            Types12[10] = type10;
            Types12[11] = type11;
            return Types12;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Type[] MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>()
        {
            Types13[0] = typeof(TArg0);
            Types13[1] = typeof(TArg1);
            Types13[2] = typeof(TArg2);
            Types13[3] = typeof(TArg3);
            Types13[4] = typeof(TArg4);
            Types13[5] = typeof(TArg5);
            Types13[6] = typeof(TArg6);
            Types13[7] = typeof(TArg7);
            Types13[8] = typeof(TArg8);
            Types13[9] = typeof(TArg9);
            Types13[10] = typeof(TArg10);
            Types13[11] = typeof(TArg11);
            Types13[12] = typeof(TArg12);
            return Types13;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Type[] MakeTypeArray(Type type0, Type type1, Type type2, Type type3, Type type4, Type type5, Type type6, Type type7, Type type8, Type type9, Type type10, Type type11, Type type12)
        {
            Types13[0] = type0;
            Types13[1] = type1;
            Types13[2] = type2;
            Types13[3] = type3;
            Types13[4] = type4;
            Types13[5] = type5;
            Types13[6] = type6;
            Types13[7] = type7;
            Types13[8] = type8;
            Types13[9] = type9;
            Types13[10] = type10;
            Types13[11] = type11;
            Types13[12] = type12;
            return Types13;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Type[] MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>()
        {
            Types14[0] = typeof(TArg0);
            Types14[1] = typeof(TArg1);
            Types14[2] = typeof(TArg2);
            Types14[3] = typeof(TArg3);
            Types14[4] = typeof(TArg4);
            Types14[5] = typeof(TArg5);
            Types14[6] = typeof(TArg6);
            Types14[7] = typeof(TArg7);
            Types14[8] = typeof(TArg8);
            Types14[9] = typeof(TArg9);
            Types14[10] = typeof(TArg10);
            Types14[11] = typeof(TArg11);
            Types14[12] = typeof(TArg12);
            Types14[13] = typeof(TArg13);
            return Types14;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Type[] MakeTypeArray(Type type0, Type type1, Type type2, Type type3, Type type4, Type type5, Type type6, Type type7, Type type8, Type type9, Type type10, Type type11, Type type12, Type type13)
        {
            Types14[0] = type0;
            Types14[1] = type1;
            Types14[2] = type2;
            Types14[3] = type3;
            Types14[4] = type4;
            Types14[5] = type5;
            Types14[6] = type6;
            Types14[7] = type7;
            Types14[8] = type8;
            Types14[9] = type9;
            Types14[10] = type10;
            Types14[11] = type11;
            Types14[12] = type12;
            Types14[13] = type13;
            return Types14;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Type[] MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>()
        {
            Types15[0] = typeof(TArg0);
            Types15[1] = typeof(TArg1);
            Types15[2] = typeof(TArg2);
            Types15[3] = typeof(TArg3);
            Types15[4] = typeof(TArg4);
            Types15[5] = typeof(TArg5);
            Types15[6] = typeof(TArg6);
            Types15[7] = typeof(TArg7);
            Types15[8] = typeof(TArg8);
            Types15[9] = typeof(TArg9);
            Types15[10] = typeof(TArg10);
            Types15[11] = typeof(TArg11);
            Types15[12] = typeof(TArg12);
            Types15[13] = typeof(TArg13);
            Types15[14] = typeof(TArg14);
            return Types15;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Type[] MakeTypeArray(Type type0, Type type1, Type type2, Type type3, Type type4, Type type5, Type type6, Type type7, Type type8, Type type9, Type type10, Type type11, Type type12, Type type13, Type type14)
        {
            Types15[0] = type0;
            Types15[1] = type1;
            Types15[2] = type2;
            Types15[3] = type3;
            Types15[4] = type4;
            Types15[5] = type5;
            Types15[6] = type6;
            Types15[7] = type7;
            Types15[8] = type8;
            Types15[9] = type9;
            Types15[10] = type10;
            Types15[11] = type11;
            Types15[12] = type12;
            Types15[13] = type13;
            Types15[14] = type14;
            return Types15;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Type[] MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>()
        {
            Types16[0] = typeof(TArg0);
            Types16[1] = typeof(TArg1);
            Types16[2] = typeof(TArg2);
            Types16[3] = typeof(TArg3);
            Types16[4] = typeof(TArg4);
            Types16[5] = typeof(TArg5);
            Types16[6] = typeof(TArg6);
            Types16[7] = typeof(TArg7);
            Types16[8] = typeof(TArg8);
            Types16[9] = typeof(TArg9);
            Types16[10] = typeof(TArg10);
            Types16[11] = typeof(TArg11);
            Types16[12] = typeof(TArg12);
            Types16[13] = typeof(TArg13);
            Types16[14] = typeof(TArg14);
            Types16[15] = typeof(TArg15);
            return Types16;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Type[] MakeTypeArray(Type type0, Type type1, Type type2, Type type3, Type type4, Type type5, Type type6, Type type7, Type type8, Type type9, Type type10, Type type11, Type type12, Type type13, Type type14, Type type15)
        {
            Types16[0] = type0;
            Types16[1] = type1;
            Types16[2] = type2;
            Types16[3] = type3;
            Types16[4] = type4;
            Types16[5] = type5;
            Types16[6] = type6;
            Types16[7] = type7;
            Types16[8] = type8;
            Types16[9] = type9;
            Types16[10] = type10;
            Types16[11] = type11;
            Types16[12] = type12;
            Types16[13] = type13;
            Types16[14] = type14;
            Types16[15] = type15;
            return Types16;
        }
    }
}

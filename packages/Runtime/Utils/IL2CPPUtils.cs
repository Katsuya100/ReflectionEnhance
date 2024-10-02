#if ENABLE_IL2CPP
using System;
using System.Runtime.InteropServices;

namespace Katuusagi.ReflectionEnhance.Utils
{
    internal static class IL2CPPUtils
    {
        [DllImport("__Internal", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static unsafe extern void il2cpp_field_static_get_value(IntPtr field, void* value);

        [DllImport("__Internal", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static unsafe extern void il2cpp_field_static_set_value(IntPtr field, void* value);

        [DllImport("__Internal", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static unsafe extern void* il2cpp_object_new(IntPtr klass);
        
        [DllImport("__Internal", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr il2cpp_class_from_il2cpp_type(IntPtr type);
    }
}
#endif

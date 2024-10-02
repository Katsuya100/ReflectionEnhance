namespace Katuusagi.ReflectionEnhance
{
    public static partial class REConstructorInfo
    {
        private enum CreateInstanceResult : byte
        {
            Success,
            DirectCall,
            Fallback,
        }

#if ENABLE_IL2CPP
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        private static unsafe T New<T>()
        {
            if (REType.IsValueTypeFast<T>())
            {
                return default;
            }
            
            var klass = Utils.IL2CPPUtils.il2cpp_class_from_il2cpp_type(typeof(T).TypeHandle.Value);
            var ptr = (nint)Utils.IL2CPPUtils.il2cpp_object_new(klass);
            return System.Runtime.CompilerServices.Unsafe.As<nint, T>(ref ptr);
        }
#endif
    }
}

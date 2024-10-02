using Katuusagi.Pool;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Katuusagi.ReflectionEnhance
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public readonly struct PointerLike<T> : IAddressLike
    {
        private readonly nint _pAddress;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal unsafe PointerLike(ref T value)
        {
            _pAddress = (nint)Unsafe.AsPointer(ref value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe ref T As()
        {
            return ref Unsafe.AsRef<T>((void*)_pAddress);
        }

        object IAddressLike.AsBoxed()
        {
            return ThreadStaticBoxingPool<T>.Get(As());
        }

        void IAddressLike.ReturnBox(object value)
        {
            ThreadStaticBoxingPool<T>.Unbox(value, out As());
            ThreadStaticBoxingPool<T>.Return(value);
        }
    }

    public static class PointerLike
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static PointerLike<T> As<T>(ref T value)
        {
            return new PointerLike<T>(ref value);
        }
    }
}

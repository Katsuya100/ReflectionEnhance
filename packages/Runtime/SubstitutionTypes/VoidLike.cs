using System.Runtime.InteropServices;

namespace Katuusagi.ReflectionEnhance
{
    [StructLayout(LayoutKind.Sequential, Size = 1)]
    public readonly struct VoidLike : ISubstitution
    {
    }
}
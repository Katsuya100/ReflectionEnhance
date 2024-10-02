using Katuusagi.GenericEnhance;

namespace Katuusagi.ReflectionEnhance
{
    public readonly struct GenericTypeParameterLike<T> : ISubstitution
        where T : struct, ITypeFormula<ulong>
    {
        public static readonly int Position = (int)TypeFormula.GetValue<T, ulong>();
    }
}
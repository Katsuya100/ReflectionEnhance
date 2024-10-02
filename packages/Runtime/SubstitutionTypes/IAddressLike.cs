namespace Katuusagi.ReflectionEnhance
{
    internal interface IAddressLike : ISubstitution
    {
        object AsBoxed();
        void ReturnBox(object value);
    }
}

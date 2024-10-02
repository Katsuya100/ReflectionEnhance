using Katuusagi.ILPostProcessorCommon.Editor;
using Mono.Cecil;
using System.Collections.Generic;
using System.Linq;

namespace Katuusagi.ReflectionEnhance.Editor
{
    public class SubstitutionTypeReferenceComparer: IEqualityComparer<TypeReference>
    {
        public static readonly SubstitutionTypeReferenceComparer Default = new SubstitutionTypeReferenceComparer();

        public bool Equals(TypeReference x, TypeReference y)
        {
            var xIsSub = SubstitutionUtils.IsSubstitution(x);
            var yIsSub = SubstitutionUtils.IsSubstitution(y);
            if (!xIsSub && !yIsSub)
            {
                if (x is GenericInstanceType xGen &&
                    y is GenericInstanceType yGen)
                {
                    if (!xGen.ElementType.Is(yGen.ElementType))
                    {
                        return false;
                    }

                    return xGen.GenericArguments.SequenceEqual(yGen.GenericArguments, this);
                }

                if (x is ByReferenceType xByRef &&
                    y is ByReferenceType yByRef)
                {
                    return Equals(xByRef.ElementType, yByRef.ElementType);
                }

                if (x is PointerType xPointer &&
                    y is PointerType yPointer)
                {
                    return Equals(xPointer.ElementType, yPointer.ElementType);
                }

                if (x is ArrayType xArray &&
                    y is ArrayType yArray)
                {
                    if (xArray.Rank != yArray.Rank)
                    {
                        return false;
                    }

                    if (xArray.IsVector != yArray.IsVector)
                    {
                        return false;
                    }

                    return Equals(xArray.ElementType, yArray.ElementType);
                }

                if (x is FunctionPointerType xFp &&
                    y is FunctionPointerType yFp)
                {
                    if (!Equals(xFp.ReturnType, yFp.ReturnType))
                    {
                        return false;
                    }

                    return xFp.Parameters.Select(v => v.ParameterType).SequenceEqual(yFp.Parameters.Select(v => v.ParameterType), this);
                }

                if (x is RequiredModifierType xReq &&
                    y is RequiredModifierType yReq)
                {
                    if (!Equals(xReq.ModifierType, yReq.ModifierType))
                    {
                        return false;
                    }

                    return Equals(xReq.ElementType, yReq.ElementType);
                }

                if (x is OptionalModifierType xOpt &&
                    y is OptionalModifierType yOpt)
                {
                    if (!Equals(xOpt.ModifierType, yOpt.ModifierType))
                    {
                        return false;
                    }

                    return Equals(xOpt.ElementType, yOpt.ElementType);
                }

                if (x is PinnedType xPinned &&
                    y is PinnedType yPinned)
                {
                    return Equals(xPinned.ElementType, yPinned.ElementType);
                }

                if (x is SentinelType xSent &&
                    y is SentinelType ySent)
                {
                    return Equals(xSent.ElementType, ySent.ElementType);
                }

                return x.Is(y);
            }

            var xPosition = SubstitutionUtils.GetGenericTypeParameterPosition(x);
            var yPosition = SubstitutionUtils.GetGenericTypeParameterPosition(y);
            if (xPosition >= 0 && yPosition >= 0)
            {
                return xPosition == yPosition;
            }

            xPosition = SubstitutionUtils.GetGenericMethodParameterPosition(x);
            yPosition = SubstitutionUtils.GetGenericMethodParameterPosition(y);
            if (xPosition >= 0 && yPosition >= 0)
            {
                return xPosition == yPosition;
            }

            var xReplaced = SubstitutionUtils.ReplaceSub(x);
            var yReplaced = SubstitutionUtils.ReplaceSub(y);
            return xReplaced.Is(yReplaced);
        }

        public int GetHashCode(TypeReference obj)
        {
            return 0;
        }
    }
}

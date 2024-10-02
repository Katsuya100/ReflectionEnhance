using Katuusagi.ILPostProcessorCommon.Editor;
using Mono.Cecil;
using Mono.Cecil.Rocks;
using System.Linq;
using System.Text.RegularExpressions;
using static UnityEngine.Networking.UnityWebRequest;

namespace Katuusagi.ReflectionEnhance.Editor
{
    public static class SubstitutionUtils
    {
        public static readonly SubstitutionTypeReferenceComparer Default = new SubstitutionTypeReferenceComparer();
        private static readonly Regex Integer = new Regex("(?<=(^_))n?\\d+(?=($))");

        public static bool IsSubstitution(TypeReference typeRef)
        {
            if (typeRef == null ||
                typeRef.IsArray ||
                typeRef.IsByReference ||
                typeRef.IsPointer ||
                typeRef.IsFunctionPointer ||
                typeRef.IsSentinel ||
                typeRef.IsRequiredModifier ||
                typeRef.IsOptionalModifier)
            {
                return false;
            }

            var type = typeRef.Resolve();
            if (type == null)
            {
                return false;
            }

            return type.Interfaces.Any(v => v.InterfaceType.FullName == "Katuusagi.ReflectionEnhance.ISubstitution");
        }

        public static TypeReference ReplaceSub(TypeReference typeRef)
        {
            if (IsByRefLike(typeRef))
            {
                var refType = typeRef as GenericInstanceType;
                var element = refType.GenericArguments[0];
                element = ReplaceSub(element);
                return element.MakeByReferenceType();
            }

            if (IsPointerLike(typeRef))
            {
                var refType = typeRef as GenericInstanceType;
                var element = refType.GenericArguments[0];
                element = ReplaceSub(element);
                return element.MakePointerType();
            }

            if (IsVoidLike(typeRef))
            {
                return typeRef.Module.TypeSystem.Void;
            }

            return typeRef;
        }

        public static bool IsByRefLike(TypeReference typeRef)
        {
            if (typeRef == null)
            {
                return false;
            }

            if (typeRef is GenericInstanceType genType)
            {
                typeRef = genType.ElementType;
            }

            if (!typeRef.IsGenericDefinition())
            {
                return false;
            }

            var result = typeRef.FullName == "Katuusagi.ReflectionEnhance.ByRefLike`1";
            return result;
        }

        public static bool IsPointerLike(TypeReference typeRef)
        {
            if (typeRef == null)
            {
                return false;
            }

            if (typeRef is GenericInstanceType genType)
            {
                typeRef = genType.ElementType;
            }

            if (!typeRef.IsGenericDefinition())
            {
                return false;
            }

            var result = typeRef.FullName == "Katuusagi.ReflectionEnhance.PointerLike`1";
            return result;
        }

        public static bool IsVoidLike(TypeReference typeRef)
        {
            if (typeRef == null)
            {
                return false;
            }

            var result = typeRef.FullName == "Katuusagi.ReflectionEnhance.VoidLike";
            return result;
        }

        public static int GetGenericTypeParameterPosition(TypeReference typeRef)
        {
            if (typeRef is GenericParameter genParam)
            {
                if (genParam.Owner is TypeReference)
                {
                    return genParam.Position;
                }

                return -1;
            }

            if (IsGenericTypeParameterLike(typeRef))
            {
                var genType = typeRef as GenericInstanceType;
                var match = Integer.Match(genType.GenericArguments[0].Name);
                if (match.Success)
                {
                    var valueStr = match.Value;
                    valueStr = valueStr.Replace("n", "-");
                    if (valueStr[0] == '-')
                    {
                        return (int)long.Parse(valueStr);
                    }

                    return (int)ulong.Parse(valueStr);
                }
            }

            return -1;
        }

        public static int GetGenericMethodParameterPosition(TypeReference typeRef)
        {
            if (typeRef is GenericParameter genParam)
            {
                if (genParam.Owner is MethodReference)
                {
                    return genParam.Position;
                }

                return -1;
            }

            if (IsGenericMethodParameterLike(typeRef))
            {
                var genType = typeRef as GenericInstanceType;
                var match = Integer.Match(genType.GenericArguments[0].Name);
                if (match.Success)
                {
                    var valueStr = match.Value;
                    valueStr = valueStr.Replace("n", "-");
                    if (valueStr[0] == '-')
                    {
                        return (int)long.Parse(valueStr);
                    }

                    return (int)ulong.Parse(valueStr);
                }
            }

            return -1;
        }

        public static bool IsGenericTypeParameterLike(TypeReference typeRef)
        {
            if (typeRef == null || !typeRef.IsGenericInstance)
            {
                return false;
            }

            return typeRef.Resolve().FullName == "Katuusagi.ReflectionEnhance.GenericTypeParameterLike`1";
        }

        private static bool IsGenericMethodParameterLike(TypeReference typeRef)
        {
            if (typeRef == null || !typeRef.IsGenericInstance)
            {
                return false;
            }

            return typeRef.Resolve().FullName == "Katuusagi.ReflectionEnhance.GenericMethodParameterLike`1";
        }

    }
}

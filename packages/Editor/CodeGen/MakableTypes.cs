using Katuusagi.ILPostProcessorCommon.Editor;
using Mono.Cecil;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Katuusagi.ReflectionEnhance.Editor
{
    public class MakableTypes
    {
        public HashSet<TypeReference> GenericInstanceTypes { get; private set; } = new HashSet<TypeReference>(TypeReferenceComparer.Default);
        public HashSet<TypeReference> ArrayTypes { get; private set; } = new HashSet<TypeReference>(TypeReferenceComparer.Default);
        public HashSet<TypeReference> PointerTypes { get; private set; } = new HashSet<TypeReference>(TypeReferenceComparer.Default);
        public HashSet<TypeReference> ByRefTypes { get; private set; } = new HashSet<TypeReference>(TypeReferenceComparer.Default);
        public HashSet<TypeReference> PinnedTypes { get; private set; } = new HashSet<TypeReference>(TypeReferenceComparer.Default);
        public HashSet<TypeReference> SentinelTypes { get; private set; } = new HashSet<TypeReference>(TypeReferenceComparer.Default);
        public HashSet<TypeReference> RequiredModifierTypes { get; private set; } = new HashSet<TypeReference>(TypeReferenceComparer.Default);
        public HashSet<TypeReference> OptionalModifierTypes { get; private set; } = new HashSet<TypeReference>(TypeReferenceComparer.Default);
        public HashSet<TypeReference> FunctionPointerTypes { get; private set; } = new HashSet<TypeReference>(TypeReferenceComparer.Default);
        public HashSet<TypeReference> IgnoredTypes { get; private set; } = new HashSet<TypeReference>(TypeReferenceComparer.Default);
        public HashSet<MethodReference> GenericInstanceMethods { get; private set; } = new HashSet<MethodReference>(MethodReferenceComparer.Default);
        public HashSet<MethodReference> OtherMethods { get; private set; } = new HashSet<MethodReference>(MethodReferenceComparer.Default);
        public HashSet<MethodReference> IgnoredMethods { get; private set; } = new HashSet<MethodReference>(MethodReferenceComparer.Default);

        private List<Func<TypeReference, bool>> _ignoreTypeChecks = new List<Func<TypeReference, bool>>();
        private List<Func<MethodReference, bool>> _ignoreMethodChecks = new List<Func<MethodReference, bool>>();

        public void RegisterIgnoreTypeCheck(Func<TypeReference, bool> check)
        {
            _ignoreTypeChecks.Add(check);
        }

        public void RegisterIgnoreMethodCheck(Func<MethodReference, bool> check)
        {
            _ignoreMethodChecks.Add(check);
        }

        public bool Add(TypeReference type)
        {
            if (type.ContainsGenericParameter)
            {
                ILPPUtils.LogWarning("REFLECTIONENHANCE5501", "ReflectionEnhance failed.", $"An unknown type containing a non-replaceable GenericParameter detected.", type);
                return false;
            }

            if (type.IsGenericParameter)
            {
                ILPPUtils.LogWarning("REFLECTIONENHANCE5502", "ReflectionEnhance failed.", $"Non-replaceable GenericParameter detected.", type);
                return false;
            }

            if (_ignoreTypeChecks.Any(v => v.Invoke(type)))
            {
                return IgnoredTypes.Add(type);
            }

            if (type.IsGenericInstance)
            {
                return GenericInstanceTypes.Add(type);
            }

            if (type.IsArray)
            {
                return ArrayTypes.Add(type);
            }

            if (type.IsPointer)
            {
                return PointerTypes.Add(type);
            }

            if (type.IsByReference)
            {
                return ByRefTypes.Add(type);
            }

            if (type.IsPinned)
            {
                return PinnedTypes.Add(type);
            }

            if (type.IsSentinel)
            {
                return SentinelTypes.Add(type);
            }

            if (type.IsRequiredModifier)
            {
                return RequiredModifierTypes.Add(type);
            }

            if (type.IsOptionalModifier)
            {
                return OptionalModifierTypes.Add(type);
            }

            if (type.IsFunctionPointer)
            {
                return FunctionPointerTypes.Add(type);
            }

            return false;
        }

        public bool Add(MethodReference method)
        {
            if (method.GetGenericArguments().Any(v => v.ContainsGenericParameter) ||
                method.DeclaringType.ContainsGenericParameter)
            {
                ILPPUtils.LogWarning("REFLECTIONENHANCE5503", "ReflectionEnhance failed.", $"An unknown method containing a non-replaceable GenericParameter detected.", method);
            }

            if (_ignoreMethodChecks.Any(v => v.Invoke(method)))
            {
                return IgnoredMethods.Add(method);
            }

            if (method.IsGenericInstance)
            {
                return GenericInstanceMethods.Add(method);
            }

            return OtherMethods.Add(method);
        }
    }
}

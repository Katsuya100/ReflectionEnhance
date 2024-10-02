using Katuusagi.MemoizationForUnity;
using System.Linq;
using System.Runtime.CompilerServices;
namespace Katuusagi.ReflectionEnhance
{
    public static partial class REAssembly
    {
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static global::Katuusagi.ILPostProcessorCommon.ReadOnlyArray<global::System.Reflection.TypeInfo> GetDefinedTypesFastRaw(this global::System.Reflection.Assembly self)
        {
            return self.DefinedTypes.ToArray();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static global::Katuusagi.ILPostProcessorCommon.ReadOnlyArray<global::System.Reflection.CustomAttributeData> GetCustomAttributesFastRaw(this global::System.Reflection.Assembly self)
        {
            return self.CustomAttributes.ToArray();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static global::Katuusagi.ILPostProcessorCommon.ReadOnlyArray<global::System.Object> GetCustomAttributesFastRaw(this global::System.Reflection.Assembly self, global::System.Boolean inherit)
        {
            return self.GetCustomAttributes(inherit);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static global::Katuusagi.ILPostProcessorCommon.ReadOnlyArray<global::System.Object> GetCustomAttributesFastRaw(this global::System.Reflection.Assembly self, global::System.Type attributeType, global::System.Boolean inherit)
        {
            return self.GetCustomAttributes(attributeType, inherit);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static global::Katuusagi.ILPostProcessorCommon.ReadOnlyArray<global::System.IO.FileStream> GetFilesFastRaw(this global::System.Reflection.Assembly self)
        {
            return self.GetFiles();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static global::Katuusagi.ILPostProcessorCommon.ReadOnlyArray<global::System.IO.FileStream> GetFilesFastRaw(this global::System.Reflection.Assembly self, global::System.Boolean getResourceModules)
        {
            return self.GetFiles(getResourceModules);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static global::Katuusagi.ILPostProcessorCommon.ReadOnlyArray<global::System.Type> GetExportedTypesFastRaw(this global::System.Reflection.Assembly self)
        {
            return self.GetExportedTypes();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static global::Katuusagi.ILPostProcessorCommon.ReadOnlyArray<global::System.Reflection.Module> GetLoadedModulesFastRaw(this global::System.Reflection.Assembly self)
        {
            return self.GetLoadedModules();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static global::Katuusagi.ILPostProcessorCommon.ReadOnlyArray<global::System.Reflection.Module> GetModulesFastRaw(this global::System.Reflection.Assembly self)
        {
            return self.GetModules();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static global::Katuusagi.ILPostProcessorCommon.ReadOnlyArray<global::System.String> GetManifestResourceNamesFastRaw(this global::System.Reflection.Assembly self)
        {
            return self.GetManifestResourceNames();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static global::Katuusagi.ILPostProcessorCommon.ReadOnlyArray<global::System.Reflection.CustomAttributeData> GetCustomAttributesDataFastRaw(this global::System.Reflection.Assembly self)
        {
            return self.GetCustomAttributesData().ToArray();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static global::Katuusagi.ILPostProcessorCommon.ReadOnlyArray<global::System.Reflection.AssemblyName> GetReferencedAssembliesFastRaw(this global::System.Reflection.Assembly self)
        {
            return self.GetReferencedAssemblies();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static global::Katuusagi.ILPostProcessorCommon.ReadOnlyArray<global::System.Reflection.Module> GetModulesFastRaw(this global::System.Reflection.Assembly self, global::System.Boolean getResourceModules)
        {
            return self.GetModules(getResourceModules);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static global::Katuusagi.ILPostProcessorCommon.ReadOnlyArray<global::System.Reflection.Module> GetLoadedModulesFastRaw(this global::System.Reflection.Assembly self, global::System.Boolean getResourceModules)
        {
            return self.GetLoadedModules(getResourceModules);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static global::Katuusagi.ILPostProcessorCommon.ReadOnlyArray<global::System.Type> GetForwardedTypesFastRaw(this global::System.Reflection.Assembly self)
        {
            return self.GetForwardedTypes();
        }
    }
}

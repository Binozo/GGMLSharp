using System.Runtime.InteropServices;

namespace GGMLSharp
{
    internal unsafe class NativeVulkan : Native
    {
		public new const string DllName = "ggml-vulkan";

        #region ggml-vulkan.h

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public extern static SafeGGmlBackend ggml_backend_vk_init(int device);

        #endregion

    }
}


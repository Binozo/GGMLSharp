using System;
using System.Runtime.InteropServices;
using static GGMLSharp.InternalStructs;

namespace GGMLSharp
{
    public unsafe class SafeGGmlBackend : SafeGGmlHandleBase
    {
        private ggml_backend* ggml_backend => (ggml_backend*)handle;

        public SafeGGmlBackend()
        {
            this.handle = IntPtr.Zero;
        }

        public SafeGGmlBackendBufferType GetDefaultBufferType()
        {
            return Native.ggml_backend_get_default_buffer_type(this);
        }

        public static SafeGGmlBackend CpuInit()
        {
            return NativeCpu.ggml_backend_cpu_init();
        }

        public static SafeGGmlBackend CudaInit(int index = 0)
        {
            if (!HasCuda)
            {
                throw new NotSupportedException("Cuda not supported");
            }
            return NativeCuda.ggml_backend_cuda_init(index);
        }

        public static SafeGGmlBackend VulkanInit(int index = 0)
        {
            if (!HasVulkan)
            {
                throw new NotSupportedException("Vulkan not supported");
            }
            return NativeVulkan.ggml_backend_vk_init(index);
        }

        public static bool HasCuda => HasLibrary("ggml-cuda");

        public static bool HasVulkan => HasLibrary("ggml-vulkan");

        private static bool HasLibrary(string libraryName)
        {
            if (NativeLibrary.TryLoad(libraryName, out IntPtr handle))
            {
                NativeLibrary.Free(handle);
                return true;
            }

            return false;
        }

        public void Free()
        {
            Native.ggml_backend_free(this);
        }
    }
}

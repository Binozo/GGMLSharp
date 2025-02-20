using System.Runtime.InteropServices;

namespace GGMLSharp
{
    internal unsafe class NativeCuda : Native
    {
		public new const string DllName = "ggml-cuda";

        #region ggml-cuda.h

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public extern static SafeGGmlBackend ggml_backend_cuda_init(int device);

        #endregion

    }
}


using System.Runtime.InteropServices;

using static GGMLSharp.InternalStructs;

using int32_t = System.Int32;
namespace GGMLSharp
{
    internal unsafe class NativeCpu : Native
    {
		public new const string DllName = "ggml-cpu";
        
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public extern static SafeGGmlBackend ggml_backend_cpu_init();

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public extern static bool ggml_backend_is_cpu(SafeGGmlBackend backend);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public extern static void ggml_backend_cpu_set_n_threads(SafeGGmlBackend backend_cpu, int n_threads);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public extern static void ggml_backend_cpu_set_abort_callback(SafeGGmlBackend backend_cpu, ggml_abort_callback abort_callback, void* abort_callback_data);
        
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public extern static int32_t ggml_get_i32_1d(SafeGGmlTensor tensor, int i);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public extern static void ggml_set_i32_1d(SafeGGmlTensor tensor, int i, int32_t value);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public extern static int32_t ggml_get_i32_nd(SafeGGmlTensor tensor, int i0, int i1, int i2, int i3);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public extern static void ggml_set_i32_nd(SafeGGmlTensor tensor, int i0, int i1, int i2, int i3, int32_t value);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public extern static float ggml_get_f32_1d(SafeGGmlTensor tensor, int i);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public extern static void ggml_set_f32_1d(SafeGGmlTensor tensor, int i, float value);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public extern static float ggml_get_f32_nd(SafeGGmlTensor tensor, int i0, int i1, int i2, int i3);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public extern static void ggml_set_f32_nd(SafeGGmlTensor tensor, int i0, int i1, int i2, int i3, float value);
        
        // ggml_graph_plan() has to be called before ggml_graph_compute()
        // when plan.work_size > 0, caller must allocate memory for plan.work_data
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public extern static ggml_cplan ggml_graph_plan(SafeGGmlGraph cgraph, int n_threads /*= GGML_DEFAULT_N_THREADS*/);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public extern static ggml_status ggml_graph_compute(SafeGGmlGraph cgraph, ggml_cplan* cplan);
        // same as ggml_graph_compute() but the work data is allocated as a part of the context
        // note: the drawback of this API is that you must have ensured that the context has enough memory for the work data
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public extern static ggml_status ggml_graph_compute_with_ctx(SafeGGmlContext ctx, SafeGGmlGraph cgraph, int n_threads);

    }
}


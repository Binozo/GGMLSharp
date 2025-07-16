using System;
using System.Linq;

namespace GGMLSharp
{
    public class ModelVRAMEstimator
    {
        public ulong EstimateVRAMUsage(string modelPath)
        {
            using (SafeGGmlContext ggmlContext = new SafeGGmlContext(IntPtr.Zero))
            using (SafeGGufContext ggufContext = SafeGGufContext.InitFromFile(modelPath, ggmlContext, true))
            {
                ulong totalSize = 0;
                SafeGGufTensorInfo[] tensorInfos = ggufContext.GGufTensorInfos;

                foreach (var tensorInfo in tensorInfos)
                {
                    totalSize += GetTensorSize(tensorInfo);
                }

                return totalSize;
            }
        }

        private ulong GetTensorSize(SafeGGufTensorInfo tensorInfo)
        {
            ulong nelements = (ulong)tensorInfo.Shape.Aggregate(1L, (a, b) => a * b);
            Structs.GGmlType type = tensorInfo.Type;
            ulong typeSize = Native.ggml_type_size(type);
            ulong tensorOverhead = Native.ggml_tensor_overhead();

            ulong tensorSize = (nelements * typeSize) / Native.ggml_blck_size(type) + tensorOverhead;
            return tensorSize;
        }
    }
}

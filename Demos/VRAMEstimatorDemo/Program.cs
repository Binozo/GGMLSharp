using GGMLSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VRAMEstimatorDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                Console.WriteLine("Usage: VRAMEstimatorDemo.exe <model_path>");
                return;
            }

            string modelPath = args[0];
            ModelVRAMEstimator estimator = new ModelVRAMEstimator();
            ulong estimatedVram = estimator.EstimateVRAMUsage(modelPath);

            Console.WriteLine($"Estimated VRAM usage for {modelPath}: {estimatedVram} bytes");
            Console.WriteLine($"Estimated VRAM usage for {modelPath}: {estimatedVram / 1024 / 1024} MB");
        }
    }
}

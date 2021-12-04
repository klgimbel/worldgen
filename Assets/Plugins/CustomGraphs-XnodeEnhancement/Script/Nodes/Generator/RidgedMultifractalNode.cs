using LibNoise;
using LibNoise.Generator;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NoiseGraph
{
    [CreateNodeMenu("NoiseGraph/Generator/RidgedMultifractal")]
    public class RidgedMultifractalNode : Graph.Branch<SerializableModuleBase>
    {
        [Input(ShowBackingValue.Always, ConnectionType.Override, TypeConstraint.Strict)]
        public double frequency;
        [Input(ShowBackingValue.Always, ConnectionType.Override, TypeConstraint.Strict)]
        public double lacunarity;
        [Input(ShowBackingValue.Always, ConnectionType.Override, TypeConstraint.Strict)]
        public int Octaves;
        [Input(ShowBackingValue.Always, ConnectionType.Override, TypeConstraint.Strict)]
        public int Seed;
        [Input(ShowBackingValue.Always, ConnectionType.Override, TypeConstraint.Strict)]
        public QualityMode Quality;

        [Output(ShowBackingValue.Always, ConnectionType.Multiple, TypeConstraint.Strict)]
        public ModuleBase GeneratorOutput;

        public void Awake()
        {
            AddDynamicOutput(
                typeof(SerializableModuleBase),
                ConnectionType.Multiple,
                TypeConstraint.Strict,
                "Output");
        }

        public override object Run()
        {
            // if editing the graph -> we stick to current variables
            if (Application.isEditor && !Application.isPlaying)
            {
                return new RidgedMultifractal(
                    frequency,
                    lacunarity,
                    Octaves,
                    Seed,
                    (QualityMode)Quality);
            }
            return new RidgedMultifractal(
                GetInputValue<double>("frequency", frequency),
                GetInputValue<double>("lacunarity", lacunarity),
                GetInputValue<int>("Octaves", Octaves),
                GetInputValue<int>("Seed", Seed),
                GetInputValue<QualityMode>("frequency", (QualityMode)Quality));
        }
    }
}
using LibNoise.Operator;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NoiseGraph
{
    [CreateNodeMenu("NoiseGraph/Modifier/ScaleBias")]
    public class ScaleBiasNode : LibnoiseNode
    {
        [Input(ShowBackingValue.Always, ConnectionType.Override, TypeConstraint.Strict)]
        public SerializableModuleBase Input;
        [Input(ShowBackingValue.Always, ConnectionType.Override, TypeConstraint.Strict)]
        public double Bias;
        [Input(ShowBackingValue.Always, ConnectionType.Override, TypeConstraint.Strict)]
        public double Scale;

        public override object Run()
        {
            ScaleBias bias = new ScaleBias(
                GetInputValue<SerializableModuleBase>("Input", Input));

            bias.Scale = GetInputValue<double>("Scale", Scale);
            bias.Bias = GetInputValue<double>("Bias", Bias);

            return bias;
        }
    }
}
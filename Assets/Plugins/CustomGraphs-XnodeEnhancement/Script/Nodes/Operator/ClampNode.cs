using LibNoise.Operator;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static XNode.Node;

namespace NoiseGraph
{
    [CreateNodeMenu("NoiseGraph/Modifier/Clamp")]
    public class ClampNode : LibnoiseNode
    {
        [Input(ShowBackingValue.Always, ConnectionType.Override, TypeConstraint.Strict)]
        public SerializableModuleBase Input;

        [Input(ShowBackingValue.Always, ConnectionType.Override, TypeConstraint.Strict)]
        public double Minimum;

        [Input(ShowBackingValue.Always, ConnectionType.Override, TypeConstraint.Strict)]
        public double Maximum;

        public override object Run()
        {
            Clamp clamp = new Clamp(
                GetInputValue<SerializableModuleBase>(
                    "Input",
                    Input));

            clamp.Maximum =
                GetInputValue<double>(
                    "Minimum",
                    Minimum);
            clamp.Maximum =
                GetInputValue<double>(
                    "Maximum",
                    Maximum);

            return clamp;
        }
    }
}
using LibNoise.Operator;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NoiseGraph
{
    [CreateNodeMenu("NoiseGraph/Transformer/Rotate")]
    public class RotateNode : LibnoiseNode
    {
        [Input(ShowBackingValue.Always, ConnectionType.Override, TypeConstraint.Strict)]
        public SerializableModuleBase Controller;

        [Input(ShowBackingValue.Always, ConnectionType.Override, TypeConstraint.Strict)]
        public double XAngle;

        [Input(ShowBackingValue.Always, ConnectionType.Override, TypeConstraint.Strict)]
        public double YAngle;

        [Input(ShowBackingValue.Always, ConnectionType.Override, TypeConstraint.Strict)]
        public double ZAngle;

        public override object Run()
        {
            return new Rotate(
                GetInputValue<double>("XAngle", XAngle),
                GetInputValue<double>("YAngle", YAngle),
                GetInputValue<double>("ZAngle", ZAngle),
                GetInputValue<SerializableModuleBase>("Controller", Controller));
        }
    }
}
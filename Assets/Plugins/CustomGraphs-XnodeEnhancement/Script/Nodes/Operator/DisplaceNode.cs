using LibNoise.Operator;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NoiseGraph
{
    [CreateNodeMenu("NoiseGraph/Transformer/Displace")]
    public class DisplaceNode : LibnoiseNode
    {
        [Input(ShowBackingValue.Always, ConnectionType.Override, TypeConstraint.Strict)]
        public SerializableModuleBase Source;

        [Input(ShowBackingValue.Always, ConnectionType.Override, TypeConstraint.Strict)]
        public SerializableModuleBase ControllerA;

        [Input(ShowBackingValue.Always, ConnectionType.Override, TypeConstraint.Strict)]
        public SerializableModuleBase ControllerB;

        [Input(ShowBackingValue.Always, ConnectionType.Override, TypeConstraint.Strict)]
        public SerializableModuleBase ControllerC;

        public override object Run()
        {
            return new Displace(
                GetInputValue<SerializableModuleBase>("Source", Source),
                GetInputValue<SerializableModuleBase>("ControllerA", ControllerA),
                GetInputValue<SerializableModuleBase>("ControllerB", ControllerB),
                GetInputValue<SerializableModuleBase>("ControllerC", ControllerC));
        }
    }
}
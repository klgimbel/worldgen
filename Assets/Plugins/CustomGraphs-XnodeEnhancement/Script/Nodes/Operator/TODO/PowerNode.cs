using UnityEngine;
using LibNoise.Operator;

namespace NoiseGraph
{
    [CreateNodeMenu("NoiseGraph/Combiner/Power")]
    public class PowerNode : LibnoiseNode
    {
        [Input(ShowBackingValue.Always, ConnectionType.Override, TypeConstraint.Strict)]
        public SerializableModuleBase SourceA;

        [Input(ShowBackingValue.Always, ConnectionType.Override, TypeConstraint.Strict)]
        public SerializableModuleBase SourceB;

        public override object Run()
        {
            Power power = new Power(
                GetInputValue<SerializableModuleBase>("SourceA", SourceA),
                GetInputValue<SerializableModuleBase>("SourceB", SourceB));

            return power;
        }
    }
}
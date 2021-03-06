using UnityEngine;
using LibNoise.Operator;

namespace NoiseGraph
{
    [CreateNodeMenu("NoiseGraph/Combiner/Max")]
    public class MaxNode : LibnoiseNode
    {
        [Input(ShowBackingValue.Always, ConnectionType.Override, TypeConstraint.Strict)]
        public SerializableModuleBase SourceA;

        [Input(ShowBackingValue.Always, ConnectionType.Override, TypeConstraint.Strict)]
        public SerializableModuleBase SourceB;

        public override object Run()
        {
            Max max = new Max(
                GetInputValue<SerializableModuleBase>("SourceA", SourceA),
                GetInputValue<SerializableModuleBase>("SourceB", SourceB));

            return max;
        }
    }
}
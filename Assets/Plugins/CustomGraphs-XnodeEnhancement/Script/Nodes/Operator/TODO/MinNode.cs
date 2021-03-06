using UnityEngine;
using LibNoise.Operator;

namespace NoiseGraph
{
    [CreateNodeMenu("NoiseGraph/Combiner/Min")]
    public class MinNode : LibnoiseNode
    {
        [Input(ShowBackingValue.Always, ConnectionType.Override, TypeConstraint.Strict)]
        public SerializableModuleBase SourceA;

        [Input(ShowBackingValue.Always, ConnectionType.Override, TypeConstraint.Strict)]
        public SerializableModuleBase SourceB;

        public override object Run()
        {
            Min min = new Min(
                GetInputValue<SerializableModuleBase>("SourceA", SourceA),
                GetInputValue<SerializableModuleBase>("SourceB", SourceB));

            return min;
        }
    }
}
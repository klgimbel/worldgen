using UnityEngine;
using LibNoise.Operator;

namespace NoiseGraph
{
    [CreateNodeMenu("NoiseGraph/Combiner/Multiply")]
    public class MultiplyNode : LibnoiseNode
    {
        [Input(ShowBackingValue.Always, ConnectionType.Override, TypeConstraint.Strict)]
        public SerializableModuleBase SourceA;

        [Input(ShowBackingValue.Always, ConnectionType.Override, TypeConstraint.Strict)]
        public SerializableModuleBase SourceB;

        public override object Run()
        {
            Multiply multiply = new Multiply(
                GetInputValue<SerializableModuleBase>("SourceA", SourceA),
                GetInputValue<SerializableModuleBase>("SourceB", SourceB));

            return multiply;
        }
    }
}
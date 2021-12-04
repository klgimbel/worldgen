using LibNoise.Operator;
using UnityEngine;

namespace NoiseGraph
{
    [CreateNodeMenu("NoiseGraph/Selector/Blend")]
    public class BlendNode : LibnoiseNode
    {
        [Input(ShowBackingValue.Always, ConnectionType.Override, TypeConstraint.Strict)]
        public SerializableModuleBase SourceA;

        [Input(ShowBackingValue.Always, ConnectionType.Override, TypeConstraint.Strict)]
        public SerializableModuleBase SourceB;

        [Input(ShowBackingValue.Always, ConnectionType.Override, TypeConstraint.Strict)]
        public SerializableModuleBase Controller;

        public override object Run()
        {
            return new Blend(
                GetInputValue<SerializableModuleBase>("SourceA", SourceA),
                GetInputValue<SerializableModuleBase>("SourceB", SourceB),
                GetInputValue<SerializableModuleBase>("Controller", Controller));
        }
    }
}
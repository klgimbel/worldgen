using NoiseGraph;

namespace WorldGen
{
    [System.Serializable]
    [CreateNodeMenu("NoiseGraph/Modifier/Discard")]
    public class DiscardNode : LibnoiseNode
    {
        [Input(ShowBackingValue.Always, ConnectionType.Override, TypeConstraint.Strict)]
        public SerializableModuleBase input;

        [Input(ShowBackingValue.Always, ConnectionType.Override, TypeConstraint.Strict)]
        public DiscardType discardType = DiscardType.Below;
        [Input(ShowBackingValue.Always, ConnectionType.Override, TypeConstraint.Strict)]
        public DiscardValue discardValue = DiscardValue.Custom;
        [Input(ShowBackingValue.Always, ConnectionType.Override, TypeConstraint.Strict)]
        public double customDiscardValue = 0;
        [Input(ShowBackingValue.Always, ConnectionType.Override, TypeConstraint.Strict)]
        public double threshold = 0.5;
    
        public override object Run()
        {
            return new Discard(
                GetInputValue(nameof(input),input),
                GetInputValue(nameof(threshold),threshold),
                GetInputValue(nameof(discardType), discardType),
                GetInputValue(nameof(discardValue),discardValue),
                GetInputValue(nameof(customDiscardValue),customDiscardValue)
            );
        }
    }
}


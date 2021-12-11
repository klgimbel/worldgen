using NoiseGraph;

namespace WorldGen
{
    [System.Serializable]
    [CreateNodeMenu("NoiseGraph/Modifier/Grow")]
    public class GrowNode : LibnoiseNode
    {
        [Input(ShowBackingValue.Always, ConnectionType.Override, TypeConstraint.Strict)]
        public SerializableModuleBase input;

        [Input(ShowBackingValue.Always, ConnectionType.Override, TypeConstraint.Strict)]
        public double width = 0.5;
        [Input(ShowBackingValue.Always, ConnectionType.Override, TypeConstraint.Strict)]
        public double sampleRate = 0.5;
        [Input(ShowBackingValue.Always, ConnectionType.Override, TypeConstraint.Strict)]
        public double threshold = 0.5;
        [Input(ShowBackingValue.Always, ConnectionType.Override, TypeConstraint.Strict)]
        public double pass = 0.5;
        [Input(ShowBackingValue.Always, ConnectionType.Override, TypeConstraint.Strict)]
        public double fail = 0.5;
    
        public override object Run()
        {
            return new Grow(
                GetInputValue(nameof(input),input),
                GetInputValue(nameof(width),width),
                GetInputValue(nameof(sampleRate), sampleRate),
                GetInputValue(nameof(threshold),threshold),
                GetInputValue(nameof(pass),pass),
                GetInputValue(nameof(fail),fail)
            );
        }
    }
}


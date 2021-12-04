using System;
using WorldGen;

namespace NoiseGraph
{
    [Serializable]
    public class RootModuleBase : Graph.Root//<SerializableModuleBase>
    {
        [Input(ShowBackingValue.Never, ConnectionType.Multiple, TypeConstraint.Strict)]
        public WorldGenOutput Input;

        public override object Run()
        {
           return GetInputValues(
                nameof(Input),
                Input);
        }
    }
}
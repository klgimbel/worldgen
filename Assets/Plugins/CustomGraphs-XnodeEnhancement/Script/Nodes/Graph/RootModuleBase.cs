using System;
using System.Collections.Generic;
using System.Linq;

namespace NoiseGraph
{
    [Serializable]
    public class RootModuleBase : Graph.Root//<SerializableModuleBase>
    {
        [Input(ShowBackingValue.Never, ConnectionType.Multiple, TypeConstraint.Strict)]
        public SerializableModuleBase Input;

        public override object Run()
        {
           return GetInputValues(
                nameof(Input),
                Input);
        }
    }
}
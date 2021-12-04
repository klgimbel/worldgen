using LibNoise.Operator;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NoiseGraph
{
    [CreateNodeMenu("NoiseGraph/Modifier/Terrace")]
    public class TerraceNode : LibnoiseNode
    {
        [Input(ShowBackingValue.Always, ConnectionType.Override, TypeConstraint.Strict)]
        public SerializableModuleBase Input;

        [Input(dynamicPortList = true)]
        public List<double> Terrace = new List<double>();

        public override object Run()
        {
            if (Terrace.Count == 0)
            {
                return GetInputValue<SerializableModuleBase>("Input", Input);
            }

            Terrace terr = new Terrace(
                GetInputValue<SerializableModuleBase>("Input", Input));

            for (int i = 0; i < Terrace.Count; i++)
            {
                terr.Add
                    (GetInputValue<double>(
                        "Terrace " + i.ToString(),
                        Terrace[i]));
            }

            return terr;
        }
    }
}
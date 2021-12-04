using Graph;
using System.Linq;
using UnityEngine;

namespace NoiseGraph
{
    [CreateAssetMenu]
    public class LibnoiseGraph : DefaultGraph
    {
        public RootModuleBase Root;

        public SerializableModuleBase GetGenerator(GenericDictionary newgd = null)
        {
            if (newgd != null)
            {
                gd = newgd;
            }

            var gen = (SerializableModuleBase) Root.GetValue(Root.Ports.First());
            return gen;
        }
    }
}
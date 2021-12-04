using Graph;
using System.Linq;
using UnityEngine;
using WorldGen;

namespace NoiseGraph
{
    [CreateAssetMenu]
    public class LibnoiseGraph : DefaultGraph
    {
        public RootModuleBase Root;

        public WorldGenOutput[] GetGenerators(GenericDictionary newgd = null)
        {
            if (newgd != null)
            {
                gd = newgd;
            }

            var gen = Root.GetInputValues<WorldGenOutput>(Root.Ports.First().fieldName);
            return gen;
        }
    }
}
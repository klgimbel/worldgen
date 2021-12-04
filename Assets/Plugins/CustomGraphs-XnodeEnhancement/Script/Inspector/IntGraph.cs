using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Graph
{
    [CreateAssetMenu]
    public class IntGraph : DefaultGraph
    {
        public RootInt Root;

        public int Run(GenericDictionary newgd = null)
        {
            if (newgd != null)
            {
                gd = newgd;
            }

            return (int)Root.GetValue(Root.Ports.First());
        }
    }
}
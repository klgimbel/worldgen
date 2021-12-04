using System.Collections;
using System.Collections.Generic;
using Graph;
using UnityEngine;
using XNode;

namespace BT.StandardLeaves
{
    public class SubGraph : Leaf<Object>
    {
        public Graph.IntGraph TargetGraph;

        protected GenericDictionary Gd = new GenericDictionary();
        
        public override object Run()
        {
            TargetGraph.gd = Gd;
            return TargetGraph.Root.Run();//GetValue( Root.Ports.First());
        }
    }
}
using Graph;
using UnityEngine;

namespace WorldGen
{
    public class WorldGenNode : NodeBase
    {
        [Input(ShowBackingValue.Never, ConnectionType.Override, TypeConstraint.Strict)]
        public SerializableModuleBase _generator;

        
        public bool _useHeight;
        public float _threshold;
        public GameObject _prefab;
    
        [Output(ShowBackingValue.Never, ConnectionType.Override, TypeConstraint.Strict)]
        public WorldGenOutput _output;

        public override object Run()
        {
            _generator = GetInputValue(nameof(_generator), _generator);
            return new WorldGenOutput
                {generator = _generator, prefab = _prefab, threshold = _threshold, useHeight = _useHeight};
        }
    }
}
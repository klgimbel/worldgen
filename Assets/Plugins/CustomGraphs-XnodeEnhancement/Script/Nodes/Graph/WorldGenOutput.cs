using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace NoiseGraph
{
    [Serializable]
    public class WorldGenOutput
    {
        public SerializableModuleBase _generator;
        public bool _useHeight;
        public float _threshold;
        public GameObject _prefab;

        public GameObject Run(Vector3 coordinate)
        {
            var val = _generator.GetValue(coordinate);
            if (val < _threshold) return null;
            var obj = Object.Instantiate(_prefab);
            if (_useHeight) coordinate.y = (float)val;
            obj.transform.position = coordinate;
            return obj;
        }
    }
}
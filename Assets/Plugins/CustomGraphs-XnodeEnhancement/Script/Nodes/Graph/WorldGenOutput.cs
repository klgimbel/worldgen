using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace WorldGen
{
    [Serializable]
    public class WorldGenOutput
    {
        public SerializableModuleBase generator;
        public bool useHeight;
        public float threshold;
        public GameObject prefab;

        public GameObject Run(Vector3 coordinate)
        {
            var val = generator.GetValue(coordinate);
            if (val <= threshold) return null;
            var obj = Object.Instantiate(prefab);
            if (useHeight) coordinate.y = (float)val;
            obj.transform.position = coordinate;
            return obj;
        }
    }
}
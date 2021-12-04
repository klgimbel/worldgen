using System.Collections;
using System.Collections.Generic;
using NoiseGraph;
using Sirenix.OdinInspector;
using UnityEngine;

public class TestGrid : MonoBehaviour
{
    [SerializeField] private LibnoiseGraph worldGenGraph;
    [SerializeField] private int size;

    [Button]
    private void Generate()
    {
        Clear();
        var generators = worldGenGraph.GetGenerators();
        for (float i = 0; i < size; i++)
        {
            for (float j = 0; j < size; j++)
            {
                foreach (var generator in generators)
                {
                    var res = generator.Run(new Vector3(i, 0, j));
                    if (res) res.transform.parent = transform;
                }
            }
        }
    }

    [Button]
    private void Clear()
    {
        while (transform.childCount > 0)
        {
            var obj = transform.GetChild(0);
            if (Application.isEditor && !Application.isPlaying)
            {
                DestroyImmediate(obj.gameObject);
            }
            else Destroy(obj.gameObject); 
        }
    }
}

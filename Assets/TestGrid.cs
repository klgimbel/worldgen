using System.Collections;
using System.Collections.Generic;
using NoiseGraph;
using Sirenix.OdinInspector;
using UnityEngine;

public class TestGrid : MonoBehaviour
{
    [SerializeField] private LibnoiseGraph worldGenGraph;
    [SerializeField] private int size;
    
    private List<GameObject> boxes = new List<GameObject>();

    [Button]
    private void Generate()
    {
        foreach (var box in boxes)
        {
            if (Application.isEditor && !Application.isPlaying)
            {
                DestroyImmediate(box);
            }
            else Destroy(box);
        }
        boxes.Clear();
        var generator = worldGenGraph.GetGenerator();
        for (double i = 0; i < size; i++)
        {
            for (double j = 0; j < size; j++)
            {
                var val = 0;//generator.GetValue(j*0.1f, i*0.1f, 0);
                if (val <= 0) continue;
                var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cube.transform.SetParent(transform);
                cube.transform.localPosition = new Vector3((float)j, (float)val,(float)i);
                boxes.Add(cube);
            }
        }
    }
}

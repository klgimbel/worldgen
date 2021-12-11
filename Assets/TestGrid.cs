using System;
using System.Collections.Generic;
using System.Linq;
using NoiseGraph;
using Sirenix.OdinInspector;
using UnityEngine;
using WorldGen;

public class TestGrid : MonoBehaviour
{
    [SerializeField] private LibnoiseGraph worldGenGraph;
    [SerializeField] private int _chunkSize;
    [SerializeField] private int viewDistance;
    [SerializeField] private Transform player;

    private Vector2Int playerChunk;
    
    private Dictionary<Vector2Int, GameObject> chunks = new Dictionary<Vector2Int, GameObject>();
    
    private Dictionary<Vector2Int, GameObject> activeChunks = new Dictionary<Vector2Int, GameObject>();
    
    private Dictionary<Vector2Int, GameObject> inactiveChunks = new Dictionary<Vector2Int, GameObject>();

    private WorldGenOutput[] generators;
    
    private void Awake()
    { 
        generators = worldGenGraph.GetGenerators();
        Clear();
    }

    private void Update()
    {
        UpdatePlayerChunk();
        for (int i = playerChunk.x-viewDistance; i <= playerChunk.x+viewDistance; i++)
        {
            for (int j = playerChunk.y-viewDistance; j <= playerChunk.y+viewDistance; j++)
            {
                GenerateOrShowChunk(new Vector2Int(i,j));
            }
        }
        var hideList = activeChunks.Keys
            .Where(chunk => 
                Math.Abs(chunk.x - playerChunk.x) > viewDistance || 
                Math.Abs(chunk.y - playerChunk.y) > viewDistance)
            .ToList();
        foreach (var coord in hideList)
        {
            HideChunk(coord);
        }
    }

    private Vector2Int UpdatePlayerChunk() => playerChunk = new Vector2Int(Mathf.RoundToInt(player.position.x / _chunkSize),
        Mathf.RoundToInt(player.position.z / _chunkSize));

    private void GenerateOrShowChunk(Vector2Int coordinate)
    {
        if (chunks.TryGetValue(coordinate, out var chunk))
        {
            ShowChunk(coordinate);
        }
        else
        {
            chunk = GenerateFromTo(coordinate * _chunkSize, (coordinate + Vector2Int.one) * _chunkSize);
            chunks.Add(coordinate, chunk);
            activeChunks.Add(coordinate, chunk);
        }
    }

    private void HideChunk(Vector2Int coordinate)
    {
        if (!activeChunks.TryGetValue(coordinate, out var activeChunk)) return;
        Debug.Log("Hiding " + coordinate + " Player: " + playerChunk);
        activeChunk.SetActive(false);
        activeChunks.Remove(coordinate);
        inactiveChunks.Add(coordinate, activeChunk);
    }

    private void ShowChunk(Vector2Int coordinate)
    {
        if (!inactiveChunks.TryGetValue(coordinate, out var inactiveChunk)) return;
        Debug.Log("Showing " + coordinate + " Player: " + playerChunk);
        inactiveChunk.SetActive(true);
        inactiveChunks.Remove(coordinate);
        activeChunks.Add(coordinate, inactiveChunk);
    }
    
    [Button]
    private void Generate(Vector2Int from, Vector2Int to)
    {
        generators = worldGenGraph.GetGenerators();
        GenerateFromTo(from, to);
    }
    
    private GameObject GenerateFromTo(Vector2Int from, Vector2Int to)
    {
        var parent = new GameObject();
        parent.transform.position = new Vector3(from.x, 0, from.y);
        parent.name = $"{from} - {to}";
        parent.transform.parent = transform;
        for (float i = from.x; i < to.x; i++)
        {
            for (float j = from.y; j < to.y; j++)
            {
                foreach (var generator in generators)
                {
                    var res = generator.Run(new Vector3(i, 0, j));
                    if (!res) continue;
                    res.transform.parent = parent.transform;
                }
            }
        }
        return parent;
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

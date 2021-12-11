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
    
    private Dictionary<Vector2Int, List<GameObject>> chunks = new Dictionary<Vector2Int, List<GameObject>>();
    
    private Dictionary<Vector2Int, List<GameObject>> activeChunks = new Dictionary<Vector2Int, List<GameObject>>();
    
    private Dictionary<Vector2Int, List<GameObject>> inactiveChunks = new Dictionary<Vector2Int, List<GameObject>>();

    private WorldGenOutput[] generators;
    
    private void Awake()
    { 
        generators = worldGenGraph.GetGenerators();
        Clear();
    }

    private void Update()
    {
        playerChunk = GetPlayerChunk();
        
        for (int i = playerChunk.x-viewDistance; i < playerChunk.x+viewDistance; i++)
        {
            for (int j = playerChunk.y-viewDistance; j < playerChunk.y+viewDistance; j++)
            {
                GenerateChunk(playerChunk + new Vector2Int(i,j));
            }
        }
        var hideList = new List<Vector2Int>();
        foreach (var chunk in activeChunks)
        {
            if (Math.Abs(chunk.Key.x - playerChunk.x) > viewDistance ||
                Math.Abs(chunk.Key.y - playerChunk.y) > viewDistance)
            {
                hideList.Add(chunk.Key);
            }
        }
        foreach (var coord in hideList)
        {
            HideChunk(coord);
        }
    }

    private Vector2Int GetPlayerChunk() => new Vector2Int(Mathf.RoundToInt(player.position.x / _chunkSize),
        Mathf.RoundToInt(player.position.z / _chunkSize));

    private void GenerateChunk(Vector2Int coordinate)
    {
        if (chunks.TryGetValue(coordinate, out var list))
        {
            ShowChunk(coordinate);
        }
        else
        {
            list = GenerateList(coordinate * _chunkSize, (coordinate + Vector2Int.one) * _chunkSize);
            chunks.Add(coordinate, list);
            activeChunks.Add(coordinate, list);
        }
    }

    private void HideChunk(Vector2Int coordinate)
    {
        if (!activeChunks.TryGetValue(coordinate, out var activeList)) return;
        Debug.Log("Hiding " + coordinate);
        
        foreach (var obj in activeList)
        {
            obj.SetActive(false);
        }

        activeChunks.Remove(coordinate);
        inactiveChunks.Add(coordinate, activeList);
    }

    private void ShowChunk(Vector2Int coordinate)
    {
        if (!inactiveChunks.TryGetValue(coordinate, out var inactiveList)) return;
        Debug.Log("Showing " + coordinate);
        
        foreach (var obj in inactiveList)
        {
            obj.SetActive(true);
        }

        inactiveChunks.Remove(coordinate);
        activeChunks.Add(coordinate, inactiveList);
    }
    
    [Button]
    private void Generate(Vector2Int from, Vector2Int to)
    {
        generators = worldGenGraph.GetGenerators();
        GenerateList(from, to);
    }
    
    private List<GameObject> GenerateList(Vector2Int from, Vector2Int to)
    {
        var list = new List<GameObject>();
        for (float i = from.x; i < to.x; i++)
        {
            for (float j = from.y; j < to.y; j++)
            {
                foreach (var generator in generators)
                {
                    var res = generator.Run(new Vector3(i, 0, j));
                    if (!res) continue;
                    res.transform.parent = transform;
                    list.Add(res);
                }
            }
        }
        return list;
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

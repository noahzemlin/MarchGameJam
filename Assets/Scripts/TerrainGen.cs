using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using Random = System.Random;

public class TerrainGen : MonoBehaviour
{
    public int width = 256;
    public float scale = 0.1f;
    public float height = 5f;
    
    [Range(0,1)]
    public float chanceOfPlatform = 0.2f;

    public GameObject groundPrefab;
    
    [ReadOnly(true)]
    public int seed;
    
    private void Awake()
    {
        //Use current time since epoch to generate seed for world
        DateTime epochStart = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        seed = (int) (DateTime.UtcNow - epochStart).TotalSeconds % 100000;
        
        //Create upper level
        for (int i = -width/2; i < width/2; i+=5)
        {
            float pos = (seed + i * scale);
            float sample = Mathf.PerlinNoise(pos, 0);
            if (sample < chanceOfPlatform)
            {
                GameObject cube = Instantiate(groundPrefab, new Vector3(i, Mathf.PerlinNoise(pos, 0) * (1/chanceOfPlatform) + height),
                    Quaternion.identity);
                cube.transform.SetParent(this.transform);
            }
        }
        
        //Spawn Dragonballs
        
        //Spawn Enemies
    }
    
}

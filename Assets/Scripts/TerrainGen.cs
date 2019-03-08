using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using Random = System.Random;

public class TerrainGen : MonoBehaviour
{
    public int width = 512;
    public float scale = 0.1f;
    public float height = 5f;
    
    [Range(0,1)]
    public float chanceOfPlatform = 0.55f;

    public GameObject groundPrefab;
    public GameObject dragonballPrefab;
    public GameObject enemyPrefab;
    
    [ReadOnly(true)]
    public int seed;

    private Random random = new Random();

    public float getRandomX()
    {
        float xpos = UnityEngine.Random.Range(50, width/2);
        xpos *= UnityEngine.Random.value > 0.5 ? 1 : -1;
        return xpos;
    }
    
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
        
        for (int i=1; i<=7; i++)
        {
            //shake up the randomizer
            float xpos = getRandomX();

            RaycastHit2D hit = Physics2D.Raycast(new Vector2(xpos, 100), Vector2.down);

            GameObject ball = Instantiate(dragonballPrefab, new Vector3(xpos, hit.point.y + 2,1), Quaternion.identity);
            ball.GetComponent<Dragonball>().stars = i;
        }

        //Spawn Enemies

        for (int i = 1; i <= random.Next(25,30); i++)
        {
            float xpos = getRandomX();

            RaycastHit2D hit = Physics2D.Raycast(new Vector2(xpos, 100), Vector2.down);

            GameObject enemy = Instantiate(enemyPrefab, new Vector3(xpos, hit.point.y + 2, 1), Quaternion.identity);
        }
    }
    
}

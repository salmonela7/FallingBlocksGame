using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using Random = UnityEngine.Random;

public class BlockSpawner : MonoBehaviour
{

    public List<GameObject> blocks;
    Vector2 screenHalfSizeWorldUnits;
    public Vector2 secondsBetweenSpawnsMinMax;
    float nextSpawnTime;
    void Start()
    {
        screenHalfSizeWorldUnits = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawnTime)
        {
            float secondsBetweenSpawns = Mathf.Lerp(secondsBetweenSpawnsMinMax.y, secondsBetweenSpawnsMinMax.x, Difficulty.GetDifficultyPercent());
        nextSpawnTime = Time.time + secondsBetweenSpawns;
            float randomSize = Random.Range(0.5f, 3.5f);
            Vector2 spawnPosition = new Vector2(Random.Range(-screenHalfSizeWorldUnits.x, screenHalfSizeWorldUnits.x), screenHalfSizeWorldUnits.y +randomSize);
            Vector3 spawnRotation = new Vector3(0, 0, Random.Range(-15, 15));
            var random = new System.Random();
            int index = random.Next(blocks.Count);
            blocks[index].transform.localScale = Vector3.one * randomSize;
            Instantiate(blocks[index], spawnPosition, Quaternion.Euler(spawnRotation));
        }
    }
}

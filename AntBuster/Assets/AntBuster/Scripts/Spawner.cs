using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] 
    private const int SPAWNED_ANT_NUMBER = 6;

    [SerializeField] 
    private GameObject antPrefabs;

    private GameObject[] spawnedAntArray;

    private float spawnTime = 1.0f;

    private float timeAfterSpawn;



    private void Awake()
    {
        spawnedAntArray = new GameObject[SPAWNED_ANT_NUMBER];
    }

    private void Start()
    {
        SpawnAnt_First();
    }

    private void FixedUpdate()
    {
        timeAfterSpawn += Time.deltaTime;
        if (timeAfterSpawn >= spawnTime) 
        {
            SpawnAnt();
            timeAfterSpawn = 0;
        }
    }

    private void SpawnAnt_First() 
    {
        for (int i = 0; i < SPAWNED_ANT_NUMBER; i++)
        {
            spawnedAntArray[i] = Instantiate(antPrefabs, transform.position, Quaternion.identity);
            timeAfterSpawn = 0;
        }
    }

    private void SpawnAnt() 
    {
        for (int i = 0; i < SPAWNED_ANT_NUMBER; i++) 
        {
            if (spawnedAntArray[i] == null || spawnedAntArray[i] == default)
            {
                Instantiate(antPrefabs, transform.position, Quaternion.identity);
            }
        }
    }
}

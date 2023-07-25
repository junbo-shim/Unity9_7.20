using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] 
    private const int SPAWNED_ANT_NUMBER = 6;

    [SerializeField] 
    private GameObject antPrefabs;

    //private int antPoolSize;

    //private Queue<GameObject> antPool;

    private GameObject[] spawnedAntArray;

    private float spawnTime = 1.0f;

    private float timeAfterSpawn;


    //public Spawner(int antPoolSize_) 
    //{
    //    this.antPoolSize = antPoolSize_;
    //    antPool = new Queue<GameObject>();

    //    for(int i = 0; i < antPoolSize_; i++)
    //    {
    //        GameObject ant = Instantiate(antPrefabs, transform.position, Quaternion.identity);
    //        antPool.Enqueue(ant);
    //        ant.SetActive(false);
    //    }
    //}





    private void Awake()
    {
        //Spawner antPool = new Spawner(SPAWNED_ANT_NUMBER);

        //for(int i = 0; i < SPAWNED_ANT_NUMBER; i++) 
        //{
        //    timeAfterSpawn += Time.deltaTime;
        //    if (timeAfterSpawn >= spawnTime)
        //    {
        //        antPool.GetAntFromPool();
        //        timeAfterSpawn = 0;
        //    }
        //}
        
        spawnedAntArray = new GameObject[SPAWNED_ANT_NUMBER];

        SpawnAnt_First();
    }

    private void FixedUpdate()
    {
        #region Legacy
        timeAfterSpawn += Time.deltaTime;
        if (timeAfterSpawn >= spawnTime)
        {
            SpawnAnt();
            timeAfterSpawn = 0;
        }
        #endregion
    }





    //public GameObject GetAntFromPool() 
    //{
    //    if (antPool.Count > 0) 
    //    {
    //        GameObject ant = antPool.Dequeue();
    //        ant.SetActive(true);
    //        return ant;
    //    }
    //    else 
    //    {
    //        GameObject ant = new GameObject();
    //        return ant;
    //    }

    //}

    //public void ReturnAntToPool(GameObject ant) 
    //{
    //    antPool.Enqueue(ant);
    //    ant.SetActive(false);
    //}





    #region Legacy
    private void SpawnAnt_First()
    {
        for (int i = 0; i < SPAWNED_ANT_NUMBER; i++)
        {
            spawnedAntArray[i] = Instantiate(antPrefabs, transform.position, Quaternion.identity);
        }
    }

    private void SpawnAnt()
    {
        for (int i = 0; i < SPAWNED_ANT_NUMBER; i++)
        {
            if (spawnedAntArray[i] == null || spawnedAntArray[i] == default)
            {
                spawnedAntArray[i] = Instantiate(antPrefabs, transform.position, Quaternion.identity);
            }
        }
    }
    #endregion
}

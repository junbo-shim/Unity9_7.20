using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameManager gameManager;
    private Vector3 spawnerPos;

    public const int SPAWNED_ANT_NUMBER = 6;
    public GameObject antPrefabs;

    private Ant ant;


    //private int antPoolSize;

    //private Queue<GameObject> antPool;

    private GameObject[] spawnedAntArray;

    private float spawnTime = 1.0f;

    private float timeAfterSpawn;

    public int antSpawnCount { get; private set; } = default;


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

    public Spawner() 
    {

    }


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

        GetPosition();


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

    private void GetPosition()
    {
        Vector3 spawnerPos = new Vector3((gameManager.GetMapWidth() * 0.5f) * (-0.9f), (gameManager.GetMapLength() * 0.5f) * 0.8f, 0f);
        //Debug.Log(gameManager.GetMapWidth());
        Debug.Log(spawnerPos);
        transform.position = spawnerPos;
    }


    #region Legacy
    private void SpawnAnt_First()
    {
        //Vector3 mousePos = Vector3.zero;
        //Vector3 gap = new Vector3(0, 0, 10f);
        //mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) + gap;
        //Vector3 spawnPos = new Vector3(transform.position.x, transform.position.y, 0f);

        for (int i = 0; i < SPAWNED_ANT_NUMBER; i++)
        {
            spawnedAntArray[i] = Instantiate(antPrefabs, transform.position, Quaternion.identity);
        }
    }

    private void SpawnAnt()
    {
        //Vector3 mousePos = Vector3.zero;
        //Vector3 gap = new Vector3(0, 0, 10f);
        //mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) + gap;
        //Vector3 spawnPos = new Vector3(transform.position.x, transform.position.y, mousePos.z);

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

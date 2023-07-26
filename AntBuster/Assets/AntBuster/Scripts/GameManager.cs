using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public float mapWidth;
    public float mapLength;


    public GameManager() 
    {

    }


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("씬에 두 개 이상의 게임 매니저가 존재합니다");
            Destroy(gameObject);
        }

        GetMapLength();
        Debug.Log(mapLength);
        GetMapWidth();
        Debug.Log(mapWidth);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float GetMapLength() 
    {
        float halfLength = Camera.main.orthographicSize;
        //Debug.LogFormat("{0}", halfLength);

        mapLength = halfLength * 2;
        //Debug.LogFormat("{0}", mapLength);

        return mapLength;
    }

    public float GetMapWidth()
    {
        float halfLength = Camera.main.orthographicSize;
        float halfWidth = halfLength * Camera.main.aspect;
        //Debug.LogFormat("{0}", halfWidth);

        mapWidth = halfWidth * 2;
        //Debug.LogFormat("{0}", mapWidth);

        return mapWidth;
    }
}

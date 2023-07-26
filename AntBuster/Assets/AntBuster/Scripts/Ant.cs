using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Ant : MonoBehaviour
{
    public GameManager gameManager;

    //public Spawner spawner;
    public int antFirstLevel = 1;
    //public int antfirstMAXHP { get; private set; } = 2;
    public int antHP { get; private set; }

    private float antMoveSpeed = 1.5f;

    private Rigidbody2D antRigid;
    public Pizza pizza;
    public Vector3 antDestination { get; private set; }

    private float randomDirectionX;
    private float randomDirectionY;

    private int antMoveChance;
    private float antMoveRate;
    private float antMoveRate_Min = 0.5f;
    private float antMoveRate_Max = 3f;
    private float timeAfterMove;







    private void Awake()
    {
        antRigid = GetComponent<Rigidbody2D>();
        antHP = antFirstLevel;
        antDestination = pizza.transform.position;
        antMoveRate = Random.Range(antMoveRate_Min, antMoveRate_Max);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (antHP <= 0)
        {
            Die_Ant();
        }
    }

    private void FixedUpdate()
    {
        DoNotGoBeyondMap();
        timeAfterMove += Time.deltaTime;
        if (timeAfterMove >= antMoveRate)
        {
            GoToDestination();
            timeAfterMove = 0;
        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject bullet = collision.gameObject;

        if (collision.transform.tag == "Bullet" && antHP > 0)
        {
            antHP -= bullet.GetComponent<Bullet>().Tower.towerDMG;
            Debug.LogFormat("탄환에 맞음, 맞은 데미지 : {0}", bullet.GetComponent<Bullet>().Tower.towerDMG);
            //Debug.Log(bullet.GetComponent<Bullet>().Tower.towerDMG);
            Debug.LogFormat("남은 체력 : {0}", antHP);
        }
    }

    private void GoToDestination() 
    {
        randomDirectionX = Random.Range(-1f, 1f);
        randomDirectionY = Random.Range(-1f, 1f);
        antMoveChance = Random.Range(0, 100);

        if (31 <= antMoveChance && antMoveChance <= 70) 
        {
            Vector3 targetDirection = antDestination - transform.position;
            transform.up = targetDirection.normalized;

            antRigid.velocity = targetDirection.normalized * antMoveSpeed;
        }
        else 
        {
            antRigid.velocity = new Vector3(randomDirectionX, randomDirectionY, 0f) * antMoveSpeed;
        }
    }

    private void DoNotGoBeyondMap() 
    {
        if ((gameManager.GetMapWidth() * 0.5) <= transform.position.x) 
        {
            transform.position = new Vector3((gameManager.GetMapWidth() * 0.5f), transform.position.y, 0f);
        }
        else if (transform.position.x <= -(gameManager.GetMapWidth() * 0.5)) 
        {
            transform.position = new Vector3(-(gameManager.GetMapWidth() * 0.5f), transform.position.y, 0f);
        }
        else if ((gameManager.GetMapLength() * 0.5) <= transform.position.y) 
        {
            transform.position = new Vector3(transform.position.x, (gameManager.GetMapLength() * 0.5f), 0f);
        }
        else if (transform.position.y <= -(gameManager.GetMapLength() * 0.5)) 
        {
            transform.position = new Vector3(transform.position.x, -(gameManager.GetMapLength() * 0.5f), 0f);
        }
    }

    private void Die_Ant() 
    {
        Destroy(gameObject);   
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Ant : MonoBehaviour
{
    public int antFirstLevel { get; private set; } = 1;
    public int antfirstMAXHP { get; private set; } = 2;
    private int antHP;

    private float antMoveSpeed = 1.5f;

    private Rigidbody2D antRigid;
    private Vector2 antDestination;

    private float randomDirectionX;
    private float randomDirectionY;

    private int antMoveChance;
    private float antMoveRate = 0.5f;
    private float timeAfterMove;

    //public GameObject Tower;






    private void Awake()
    {
        antRigid = GetComponent<Rigidbody2D>();
        antHP = antfirstMAXHP;
        antDestination = new Vector2(8.0f, -4.0f);
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

        if (36 <= antMoveChance && antMoveChance <= 70) 
        {
            Vector2 targetDirection = antDestination - (Vector2)transform.position;
            transform.up = targetDirection.normalized;

            antRigid.velocity = targetDirection.normalized * antMoveSpeed;
        }
        else 
        {
            antRigid.velocity = new Vector2(randomDirectionX, randomDirectionY) * antMoveSpeed;
        }
    }

    private void Die_Ant() 
    {
        Destroy(gameObject);   
    }
}

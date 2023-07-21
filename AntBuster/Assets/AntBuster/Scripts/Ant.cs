using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Ant : MonoBehaviour
{
    private int antFirstLevel = 1;
    private float antfirstMAXHP = 2.0f;
    private float antfirstHP;

    [SerializeField] 
    private float antMoveSpeed = 3.0f;

    private Rigidbody2D antRigid;
    private Vector2 antDestination;

    private float randomDirectionX;
    private float randomDirectionY;

    private int antMoveChance;
    private float antMoveRate = 0.5f;
    private float timeAfterMove;

    [SerializeField]
    private GameObject Tower;


    private void Awake()
    {
        antRigid = GetComponent<Rigidbody2D>();
        //antfirstHP = antfirstMAXHP;
        antDestination = new Vector2(8.0f, -4.0f);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
        //if () 
        //{

        //}
        //else
        //{

        //}
    }



    private void GoToDestination() 
    {
        randomDirectionX = Random.Range(-1f, 1f);
        randomDirectionY = Random.Range(-1f, 1f);
        antMoveChance = Random.Range(0, 100);

        if (31 <= antMoveChance && antMoveChance <= 70) 
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

    private void GetHitAnt() 
    {

    }

    private void DieAnt() 
    {
        Destroy(gameObject);   
    }

}

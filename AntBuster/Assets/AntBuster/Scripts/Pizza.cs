using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pizza : MonoBehaviour
{
    public GameManager gameManager;

    public Pizza()
    {

    }

    private void Awake()
    {
        GetPosition();
    }

    private void GetPosition() 
    {
        Vector3 pizzaPos = new Vector3((gameManager.GetMapWidth() * 0.5f) * 0.9f, (gameManager.GetMapLength() * 0.5f) * (-0.6f), 0f);
        //Debug.Log(gameManager.GetMapWidth());
        Debug.Log(pizzaPos);
        transform.position = pizzaPos;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerRigid;

    public float maxMoveSpeed = 4.0f;



    // Start is called before the first frame update
    void Start()
    {
        playerRigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Stop();
    }

    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        float horizonMove = Input.GetAxisRaw("Horizontal");

        playerRigid.AddForce(Vector2.right * horizonMove, ForceMode2D.Impulse);

        if (playerRigid.velocity.x > maxMoveSpeed)
        {
            playerRigid.velocity = new Vector2(maxMoveSpeed, playerRigid.velocity.y);
        }
        else if (playerRigid.velocity.x < maxMoveSpeed *(-1))
        {
            playerRigid.velocity = new Vector2(maxMoveSpeed *(-1), playerRigid.velocity.y);
        }

        float verticalMove = Input.GetAxisRaw("Vertical");

        playerRigid.AddForce(Vector2.up * verticalMove, ForceMode2D.Impulse);

        if (playerRigid.velocity.y > maxMoveSpeed)
        {
            playerRigid.velocity = new Vector2(playerRigid.velocity.x, maxMoveSpeed);
        }
        else if (playerRigid.velocity.y < maxMoveSpeed *(-1))
        {
            playerRigid.velocity = new Vector2(playerRigid.velocity.x, maxMoveSpeed *(-1));
        }
    }

    private void Stop()
    {
        if (Input.GetButtonUp("Horizontal"))
        {
            playerRigid.velocity = new Vector2(0, playerRigid.velocity.y);
        }
        else if (Input.GetButtonUp("Vertical"))
        {
            playerRigid.velocity = new Vector2(playerRigid.velocity.x, 0);
        }
    }


    private void MoveHorizon()
    {
        float horizonMove = Input.GetAxisRaw("Horizontal");

        playerRigid.AddForce(Vector2.right * horizonMove, ForceMode2D.Impulse);

        if (playerRigid.velocity.x > maxMoveSpeed)
        {
            playerRigid.velocity = new Vector2(maxMoveSpeed, playerRigid.velocity.y);
        }
        else if (playerRigid.velocity.x < maxMoveSpeed *(-1))
        {
            playerRigid.velocity = new Vector2(maxMoveSpeed *(-1), playerRigid.velocity.y);
        }
    }
    private void MoveVertical()
    {
        float verticalMove = Input.GetAxisRaw("Vertical");

        playerRigid.AddForce(Vector2.up * verticalMove, ForceMode2D.Impulse);

        if (playerRigid.velocity.y > maxMoveSpeed)
        {
            playerRigid.velocity = new Vector2(playerRigid.velocity.x, maxMoveSpeed);
        }
        else if (playerRigid.velocity.y < maxMoveSpeed *(-1))
        {
            playerRigid.velocity = new Vector2(playerRigid.velocity.x, maxMoveSpeed *(-1));
        }
    }
}

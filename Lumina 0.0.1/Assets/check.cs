using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class check : MonoBehaviour
{

    Controller Player;

    void Start()
    {
        Player = GetComponent<Controller>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            Player.isGrounded = false;
        }
    }


    void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            Player.isGrounded = true;
        }
    }
}

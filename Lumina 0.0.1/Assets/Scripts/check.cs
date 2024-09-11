using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class check : MonoBehaviour
{

    Controller player2;

    void Start()
    {
        player2 = GetComponent<Controller>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            player2.isGrounded = false;
        }
    }


    void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            player2.isGrounded = true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    private Rigidbody2D triangulo;
    public bool isGrounded;

    void Start()
    {
        triangulo = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        HorizontalMove();
        Jump();
        Input.GetAxis("Jump");
    }
    void HorizontalMove()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * speed;
    }
    void Jump()
    {
        if(Input.GetButtonUp("Jump") && !isGrounded)
        {
            triangulo.AddForce(new Vector2(0f, jumpForce * Input.GetAxis("Jump")), ForceMode2D.Impulse);
        }
    }
}
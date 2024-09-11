using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player2 : MonoBehaviour
{
    private float h;
    [SerializeField] private float Speed;
    [SerializeField] private float Pulo;
    public bool isGrounded;
    Rigidbody2D Player;
    [SerializeField] private Transform checkChão;
    [SerializeField] private LayerMask Chão;

    void Awake() 
    {
        Player = GetComponent<Rigidbody2D>();    
    }

    void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        HorizontalMove();
        Jump();
        Input.GetAxis("Jump");
        isGrounded = Physics2D.OverlapBox(checkChão.position, new Vector2(0.1130587f, 0.0290508f), 0, Chão);
        Flip();
    }

    void HorizontalMove()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * Speed;
    }
    void Jump()
    {
        if(Input.GetButtonUp("Jump") && !isGrounded)
        {
            Player.AddForce(new Vector2(0f, Pulo * Input.GetAxis("Jump")), ForceMode2D.Impulse);
        }
    }
    
    void Flip()
    {
        if (h < -0.1f) transform.localScale = new Vector3(-1, 1, 1);
        if (h > 0.1f) transform.localScale = new Vector3(1, 1, 1);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
        }
        if(other.CompareTag("Save"))
        {
            Destroy(other.gameObject);
        }
        if(other.CompareTag("Finish"))
        {
            PlayerPrefs.DeleteKey("HasSave");
            SceneManager.LoadScene("SampleScene");
        }
    }
}

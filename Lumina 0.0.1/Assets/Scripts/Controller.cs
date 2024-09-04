using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Reporting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    private Rigidbody2D player;
    public bool isGrounded;

    void Start()
    {
        player = GetComponent<Rigidbody2D>();
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
            player.AddForce(new Vector2(0f, jumpForce * Input.GetAxis("Jump")), ForceMode2D.Impulse);
        }
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
            SceneManager.LoadScene("lumina 0.0.3");
        }

    }
}
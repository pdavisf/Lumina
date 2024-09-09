using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEditor.Build.Reporting;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    private Rigidbody2D player;
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
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
            SceneManager.LoadScene("SampleScene");
        }
    }
}
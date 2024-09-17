using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.Collections;
using UnityEditor.Build.Reporting;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    private Rigidbody2D player;
    private SpriteRenderer sprite;
    private bool pulando;
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private Transform chão;
    [SerializeField] private float detector;
    [SerializeField] public LayerMask groundLayer;

    void Start()
    {
        player = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        HorizontalMove();

        Vector3 individuo = transform.localScale;
        if(Input.GetAxis("Horizontal") < 0)
        {
            individuo.x = -3;
        }
        if(Input.GetAxis("Horizontal") > 0)
        {
            individuo.x = 3;
        }
        transform.localScale = individuo;

        Jump();

        if(this.pulando)
        {
            if(Input.GetKey(KeyCode.Space));
        }
    }
    void HorizontalMove()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * speed;
    }
    void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Collider2D collider = Physics2D.OverlapCircle(this.chão.position, this.detector, this.groundLayer);
            if(collider != null)
            {
                Vector2 força = new Vector2(0, this.jumpForce);
                this.player.AddForce(força, ForceMode2D.Impulse);
            }
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(this.chão.position, this.detector);
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
            SceneManager.LoadScene("Fase2");
        }
        if(other.CompareTag("Fase3"))
        {
            SceneManager.LoadScene("Fase3");
        }
        if(other.CompareTag("Fase4"))
        {
            SceneManager.LoadScene("Fase4");
        }
        if(other.CompareTag("Fase5"))
        {
            SceneManager.LoadScene("Fase5");
        }
    }
}
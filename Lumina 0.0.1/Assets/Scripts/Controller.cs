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
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    public bool isGrounded;
    public Transform Chão;
    public float footOffest = 0.4f;
    public float groundDistance = 0.1f;
    public LayerMask groundLayer;
    public Vector3 wallOffset;
    public float wallRadius;

    void Start()
    {
        player = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        HorizontalMove();
        Jump();
        Input.GetAxis("Jump");
        PhysicsCheck();
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

    void PhysicsCheck()
    {
        RaycastHit2D leftFoot = Raycast(Chão.position + new Vector3(-footOffest, 0), Vector2.down, groundDistance, groundLayer);
        RaycastHit2D rightFoot = Raycast(Chão.position + new Vector3(footOffest, 0), Vector2.down, groundDistance, groundLayer);
        
        if(leftFoot || rightFoot)
        {
            isGrounded = true;
        }
    }

    public RaycastHit2D Raycast(Vector2 origin, Vector2 rayDirection, float length, LayerMask mask, bool drawRay = true)
    {

        RaycastHit2D hit = Physics2D.Raycast(origin, rayDirection, length, mask);

        if (drawRay)
        {
            Color color = hit ? Color.red : Color.green;
            Debug.DrawRay(origin, rayDirection * length, color);
        }
        return hit;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(transform.position + new Vector3(wallOffset.x, 0), wallRadius);
        Gizmos.DrawWireSphere(transform.position + new Vector3(-wallOffset.x, 0), wallRadius);
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
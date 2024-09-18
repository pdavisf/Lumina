using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Example1 : MonoBehaviour
{
    public Texture2D tex;

    void Awake()
    {
        SpriteRenderer sr = gameObject.AddComponent<SpriteRenderer>() as SpriteRenderer;
        transform.position = new Vector3(0.0f, 2.5f, 0.0f);

        Sprite sp = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100.0f);
        sr.sprite = sp;

        gameObject.AddComponent<BoxCollider2D>();

        Rigidbody2D rb = gameObject.AddComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Dynamic;
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        gameObject.transform.Translate(moveHorizontal * 0.05f, moveVertical * 0.25f, 0.0f);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        print("collision");
        if (collision.transform.tag == "Projectile")
        {
            print("Collision with Projectile");
            public class Inimigo : MonoBehaviour
    {
        public int MaxHealth;
        public float speed;
        public ParticleSystem system;
        private int currentHealth;

        // Start is called before the first frame update
        public void Start()
        {
            currentHealth = MaxHealth;
        }

        // Update is called once per frame
        private void Update()
        {
            Move();
            Shoot();
        }

        private void Move()
        {
            float direction = Input.GetAxis("Horizontal");
            transform.position += Vector3.right * direction * speed * Time.deltaTime;
        }


    }
}
}
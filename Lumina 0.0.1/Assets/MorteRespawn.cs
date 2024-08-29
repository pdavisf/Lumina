using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MorteRespawn : MonoBehaviour
{
    private Vector2 startPos;
    [SerializeField] private Transform Player;

    void Start() 
    {
        startPos = Player.position;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            Player.position = startPos;
            print("Começa denovo kkk!");
        }
    }
}

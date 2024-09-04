using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MorteRespawn : MonoBehaviour
{
    [SerializeField] private Transform Player;
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            SceneManager.LoadScene("lumina 0.0.3");
            print("Começa denovo kkk!");
        }
    }
}

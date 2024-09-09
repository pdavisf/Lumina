using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
public class Star : MonoBehaviour
{
    public int Pontos;

    void Start()
    {
        Pontos = 0;
    }
    
    void OnTriggerEnter2D(Collider2D stars)
    {
        if(stars.CompareTag("Coin")==true)
        {
            Pontos = Pontos + 1;
            Destroy(stars.gameObject);
        }
    }
}

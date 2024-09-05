using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentEnemy : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private Transform Enemy;
    
    public GameObject inicio, fim;
    
    private Vector2 nextPos;
    void Start()
    {
        nextPos = fim.transform.position;
    }
   void Update()
    {
        ZigZag();
    }

    void ZigZag()
    {
        if(Enemy.position == inicio.transform.position)
        {
            nextPos = fim.transform.position;
        }
        if(Enemy.position == fim.transform.position)
        {
            nextPos = inicio.transform.position;
        }
        transform.position = Vector2.MoveTowards(Enemy.position, nextPos, moveSpeed*Time.deltaTime);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Savepoint : MonoBehaviour
{
    [SerializeField] private Transform player;

    private void Start() 
    {
        LoadGame(player);    
    }


   private void OnTriggerEnter2D(Collider2D other)
   {
        if(other.CompareTag("Player"))
        {
            SaveGame (other.transform.position);
        }
   }
   void SaveGame(Vector3 position)
   {
    PlayerPrefs.SetInt("HasSave", 0);
    PlayerPrefs.SetFloat("PosX", position.x);
    PlayerPrefs.SetFloat("PosY", position.y);
    PlayerPrefs.SetFloat("PosZ", position.z);
    PlayerPrefs.Save();
    Debug.Log("Jogo salvo no ponto de salvamento");
   }
   public void LoadGame(Transform playerTransform)
   {
    if(PlayerPrefs.HasKey("HasSave"))
    {
        float x = PlayerPrefs.GetFloat("PosX");
        float y = PlayerPrefs.GetFloat("PosY");
        float z = PlayerPrefs.GetFloat("PosZ");
        playerTransform.position = new Vector3(x, y, z);
        Debug.Log("Jogo carregado");
    }
    else
    {
        Debug.LogWarning("Nenhum dado de salvamento");
    }
   }
}

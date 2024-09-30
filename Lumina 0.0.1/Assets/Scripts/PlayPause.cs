using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayPause : MonoBehaviour
{
    private bool jogopausado = false;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            pausado();
        }
    }

    void pausado()
    {
        jogopausado = !jogopausado;
        if(jogopausado)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }
}

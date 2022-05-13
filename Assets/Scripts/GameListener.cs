using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameListener : MonoBehaviour
{

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameManager.instance.isPaused)
            {
                GameManager.instance.Resume();
            }
            else
            {
                GameManager.instance.Pause();
            }
        }    
    }
}

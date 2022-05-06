using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
    public static MainMenu instance;

    void Awake()
    {
        instance = this;
    }

    public void Play()
    {
        SceneManager.LoadScene("Game");
    }

    public void Garage()
    {
        SceneManager.LoadScene("Garage");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
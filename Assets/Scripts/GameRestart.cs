using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameRestart : MonoBehaviour
{
    // Make an instance of this class
    public static GameRestart instance;
    public GameObject pauseMenu;

    void Awake()
    {
        instance = this;
    }

    public void RestartGame()
    {
        pauseMenu.SetActive(false);
        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

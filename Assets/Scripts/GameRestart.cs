using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameRestart : MonoBehaviour
{
    // Make an instance of this class
    public static GameRestart instance;
    public GameObject endMenu;

    void Awake()
    {
        instance = this;
    }

    public void RestartGame()
    {
        Debug.Log("Restarting game...");
        endMenu.SetActive(false);
        Time.timeScale = 1f;
        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        TimeHandler.instance.StartTimer();
    }
}

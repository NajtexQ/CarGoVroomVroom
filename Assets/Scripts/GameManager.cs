using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    public GameObject pauseMenu;
    public GameObject endMenu;

    public TextMeshProUGUI timeText;

    public bool isPaused = false;

    void Awake()
    {
        instance = this;
    }
    
    void Start()
    {
        Time.timeScale = 1f;
        Countdown.instance.StartCountdown();
    }


    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void EndGame()
    {
        TimeHandler.instance.StopTimer();
        Time.timeScale = 0f;
        endMenu.SetActive(true);

        int allLaps = CheckpointsManager.instance.numberLaps;
        float time = TimeHandler.instance.endTime;

        timeText.text = "You finished " + allLaps + " laps in " + time + " seconds!";
    }
}

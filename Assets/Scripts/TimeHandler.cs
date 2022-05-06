using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeHandler : MonoBehaviour
{
    public static TimeHandler instance;
    public TextMeshProUGUI timeText;
    float startTime;
    
    public float endTime;
    public string timeString;

    bool isStarted;

    void Awake()
    {
        instance = this;
    }
    public void StartTimer()
    {
        // Get current time
        isStarted = true;
        startTime = Time.time;
    }

    public void StopTimer()
    {
        // Get current time
        isStarted = false;
        // TODO: Easy fix, but not the best solution
        endTime = Time.time - startTime;
        timeString = timeText.text;
        Debug.Log("Time2: " + timeString);
    }

    public void UpdateTimer()
    {
        // Update the time text
        if (isStarted)
        {
            timeText.text = (Time.time - startTime).ToString("0.00");
        }
        else
        {
            timeText.text = endTime.ToString("0.00");
        }
    }

    void Update()
    {
        UpdateTimer();
    }
}
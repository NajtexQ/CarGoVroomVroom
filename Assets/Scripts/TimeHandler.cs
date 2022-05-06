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
        endTime = Time.time - startTime;
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
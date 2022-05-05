using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Newtonsoft.Json;

public class Countdown : MonoBehaviour
{

    public static Countdown instance;

    public TextMeshProUGUI countdownText;

    public float countdownTime = 3f;

    float currentCountdownTime;

    string countdownString;

    void Awake()
    {
        instance = this;
    }

    public void StartCountdown()
    {
        StartCoroutine(CountdownRoutine());
    }

    IEnumerator CountdownRoutine()
    {

        Debug.Log("Countdown started");
        yield return new WaitForSeconds(0.1f);
        Time.timeScale = 0f;

        yield return new WaitForSecondsRealtime(0.5f);

        Debug.Log("Real Time");

        currentCountdownTime = countdownTime;

        Debug.Log("Countdown started");

        while (currentCountdownTime >= 1)
        {
            countdownText.text = currentCountdownTime.ToString("0");
            currentCountdownTime -= Time.unscaledDeltaTime;
            yield return null;
        }

        Debug.Log("Countdown finished");

        yield return new WaitForSecondsRealtime(0.5f);

        countdownText.text = "GO!";
        Time.timeScale = 1f;
        yield return new WaitForSeconds(1f);
        countdownText.text = "";
    }

}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weather : MonoBehaviour
{

    public static Weather instance;
    public GameObject rain;
    string selectedWeather;

    string defaultWeather = "Clear";

    void Awake()
    {
        instance = this;

        selectedWeather = PlayerPrefs.GetString("weather") == "" ? defaultWeather : PlayerPrefs.GetString("weather");
    }

    void Start()
    {
        ChangeWeather(selectedWeather);
    }

    public void ChangeWeather(string weather)
    {
        switch (weather)
        {
            case "Rain":
                // Render settings environment
                RenderSettings.fog = true;
                RenderSettings.fogMode = FogMode.Linear;
                RenderSettings.fogColor = new Color32(155, 192, 255, 255);
                RenderSettings.fogStartDistance = 0;
                RenderSettings.fogEndDistance = 100;
                break;
            case "Clear":
                RenderSettings.fog = false;
                break;
        }

        if (weather != "Clear")
        {
            SetWeatherParticles(weather);
        }
    }

    public void SetWeatherParticles(string weather)
    {
        GameObject weatherParticles = Instantiate(rain, transform);
    }

}
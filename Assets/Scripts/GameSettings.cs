using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class GameSettings : MonoBehaviour
{
    
    [Header("Game Settings")]
    public GameObject numberOfLapsObject;
    public GameObject weatherObject;
    public GameObject timeOfDayObject;

    // TextMeshPro dropdown
    public TMP_Dropdown numberOfLapsDropdown;
    public TMP_Dropdown weatherDropdown;
    public TMP_Dropdown timeOfDayDropdown;

    void Start()
    {
        // Get dropdown component
        numberOfLapsDropdown = numberOfLapsObject.GetComponent<TMP_Dropdown>();
        Debug.Log(numberOfLapsDropdown.options[numberOfLapsDropdown.value].text);

        weatherDropdown = weatherObject.GetComponent<TMP_Dropdown>();
        Debug.Log(weatherDropdown.options[weatherDropdown.value].text);

        timeOfDayDropdown = timeOfDayObject.GetComponent<TMP_Dropdown>();
        Debug.Log(timeOfDayDropdown.options[timeOfDayDropdown.value].text);
    }

    public void SaveSettings()
    {

        int numberOfLaps = int.Parse(numberOfLapsDropdown.options[numberOfLapsDropdown.value].text);
        PlayerPrefs.SetInt("numberOfLaps", numberOfLaps);

        string weather = weatherDropdown.options[weatherDropdown.value].text;
        PlayerPrefs.SetString("weather", weather);

        string timeOfDay = timeOfDayDropdown.options[timeOfDayDropdown.value].text;
        PlayerPrefs.SetString("timeOfDay", timeOfDay);
    }
}

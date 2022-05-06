using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class GameSettings : MonoBehaviour
{
    
    [Header("Game Settings")]
    public GameObject numberOfLapsObject;

    // TextMeshPro dropdown
    public TMP_Dropdown numberOfLapsDropdown;

    void Start()
    {
        // Get dropdown component
        numberOfLapsDropdown = numberOfLapsObject.GetComponent<TMP_Dropdown>();
        Debug.Log(numberOfLapsDropdown.options[numberOfLapsDropdown.value].text);
    }

    public void SaveSettings()
    {
        // Convert to int

        int numberOfLaps = int.Parse(numberOfLapsDropdown.options[numberOfLapsDropdown.value].text);
        PlayerPrefs.SetInt("numberOfLaps", numberOfLaps);
    }
}

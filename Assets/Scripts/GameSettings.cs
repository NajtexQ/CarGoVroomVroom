using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameSettings : MonoBehaviour
{
    
    [Header("Game Settings")]
    public GameObject numberOfLapsObject;

    void Start()
    {
        // Get dropdown component
        Dropdown numberOfLapsDropdown = numberOfLapsObject.GetComponent<Dropdown>();
    }

    public void SaveSettings()
    {
        PlayerPrefs.SetInt("numberOfLaps", numberOfLapsDropdown.value);
    }
}

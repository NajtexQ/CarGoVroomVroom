using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeOfDay : MonoBehaviour
{

    public static TimeOfDay instance;

    public Light sun;

    public string timeOfDay;

    // Dictionary of string and rotation
    public Dictionary<string, Quaternion> rotations = new Dictionary<string, Quaternion>() {
        { "afternoon", Quaternion.Euler(new Vector3(50, -30, 0)) },
        { "evening", Quaternion.Euler(new Vector3(0, -30, 0)) },
        { "morning", Quaternion.Euler(new Vector3(170, -30, 0)) },
        { "night", Quaternion.Euler(new Vector3(-30, -30, 0)) }
    };

    void Awake()
    {
        instance = this;
    }


    public void SetTimeOfDay()
    {

        timeOfDay = PlayerPrefs.GetString("timeOfDay").ToLower();

        sun.transform.rotation = rotations[timeOfDay];

    }
}
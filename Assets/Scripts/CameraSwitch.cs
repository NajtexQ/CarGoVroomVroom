using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public static CameraSwitch instance;

    public GameObject camera1;
    public GameObject camera2;

    void Awake()
    {
        instance = this;
    }

    public void SwitchCamera()
    {
        if (camera1.activeSelf)
        {
            camera1.SetActive(false);
            camera2.SetActive(true);
        }
        else
        {
            camera1.SetActive(true);
            camera2.SetActive(false);
        }
    }
}

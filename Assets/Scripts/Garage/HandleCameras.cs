using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleCameras : MonoBehaviour
{

    public static HandleCameras instance;

    public GameObject cameraParent;

    public GameObject[] cameras;

    public int currentCameraIndex;

    void Awake()
    {
        instance = this;

        // Loop through all children of cameraParent and set them to cameras array
        cameras = new GameObject[cameraParent.transform.childCount];

        for (int i = 0; i < cameraParent.transform.childCount; i++)
        {
            cameras[i] = cameraParent.transform.GetChild(i).gameObject;
        }

        // Set all cameras to inactive except the first one
        for (int i = 1; i < cameras.Length; i++)
        {

            cameras[i].SetActive(false);
        }
    }

    public void EnableCameraByName(string cameraName)
    {
        // Loop through all cameras and enable the one with the same name as the parameter
        for (int i = 0; i < cameras.Length; i++)
        {
            if (cameras[i].name == cameraName)
            {
                cameras[i].SetActive(true);
                currentCameraIndex = i;
            }
            else
            {
                cameras[i].SetActive(false);
            }
        }
    }

    public void NextCamera()
    {
        cameras[currentCameraIndex].SetActive(false);
        currentCameraIndex++;
        if (currentCameraIndex >= cameras.Length)
        {
            currentCameraIndex = 0;
        }
        cameras[currentCameraIndex].SetActive(true);
    }

    public void PreviousCamera()
    {
        cameras[currentCameraIndex].SetActive(false);
        currentCameraIndex--;
        if (currentCameraIndex < 0)
        {
            currentCameraIndex = cameras.Length - 1;
        }
        cameras[currentCameraIndex].SetActive(true);
    }
}

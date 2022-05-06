using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapSelection : MonoBehaviour
{

    public void MapSelect(string map)
    {
        SaveTrackName(map);
        SceneManager.LoadScene("Game");

    }

    public void SaveTrackName(string trackName)
    {
        PlayerPrefs.SetString("trackName", trackName);

    }
    
}
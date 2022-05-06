using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackRenderer : MonoBehaviour
{
    
    public static TrackRenderer instance;

    string name = "Track01";

    void Awake()
    {
        instance = this;

        PlayerPrefs.SetString("trackName", name);

        string trackName = PlayerPrefs.GetString("trackName");

        LoadTrack(trackName);
    }

    public void LoadTrack(string trackName)
    {
        string trackPath = "Tracks/" + trackName;
        
        GameObject track = (GameObject)Resources.Load(trackPath, typeof(GameObject));
        track = Instantiate(track, new Vector3(0, 0, 0), Quaternion.identity);

    }
}

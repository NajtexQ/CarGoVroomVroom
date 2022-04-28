using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackRenderer : MonoBehaviour
{
    
    public static TrackRenderer instance;

    void Awake()
    {
        instance = this;
    }

    public void LoadTrack(string trackName)
    {
        string trackPath = "Tracks/" + trackName;
        
        GameObject track = (GameObject)Resources.Load(trackPath, typeof(GameObject));
        track = Instantiate(track, transform.position, transform.rotation);

    }
}

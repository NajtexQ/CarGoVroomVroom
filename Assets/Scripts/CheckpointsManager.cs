using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointsManager : MonoBehaviour
{
    public int numberLaps;
    public int defaultNumberLaps = 3;
    public List<GameObject> checkpoints;

    List<Collider> colliders = new List<Collider>();

    //int currentCheckpoint = 0;

    public int currentLap = 0;

    int checkpointCount = 0;

    public static CheckpointsManager instance;

    void Awake()
    {
        instance = this;

        int selectedLaps = PlayerPrefs.GetInt("numberOfLaps", defaultNumberLaps);
        
        numberLaps = selectedLaps > 0 ? selectedLaps : defaultNumberLaps;

        foreach (GameObject checkpoint in checkpoints)
        {
            var col = checkpoint.GetComponent<Collider>();
            colliders.Add(col);
        }
        foreach (Collider collider in colliders)
        {
            collider.enabled = false;
        }
        colliders[0].enabled = true;
    }

    void Start()
    {
        // Loop through all checkpoints and assign "CheckpointTrigger" script to each one
        foreach (GameObject checkpoint in checkpoints)
        {
            checkpoint.AddComponent<CheckpointTrigger>();
            checkpoint.GetComponent<CheckpointTrigger>().cpindex = checkpointCount;
            checkpointCount++;
        }

        Debug.Log(checkpoints);
    }


    public void CheckpointReached(int checkpoint)
    {
        //if (checkpoint == 0 && currentLap == 0) {
        //    TimeHandler.instance.StartTimer();
        //}
        colliders[checkpoint].enabled = false;

        if (checkpoint + 1 == colliders.Count)
        {

            if (currentLap + 1 >= numberLaps)
            {
                GameManager.instance.EndGame();
            }

            else
            {
                colliders[0].enabled = true;
                currentLap++;
            }
        }
        else
        {
            colliders[checkpoint + 1].enabled = true;
        }

    }

}

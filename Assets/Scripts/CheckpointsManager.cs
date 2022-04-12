using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointsManager : MonoBehaviour
{
    public int numberLaps = 3;
    public List<GameObject> checkpoints;

    List<Collider> colliders = new List<Collider>();

    public GameObject pauseMenu;

    //int currentCheckpoint = 0;

    int currentLap = 0;

    int checkpointCount = 0;

    // Create instance of this class
    public static CheckpointsManager instance;

    void Awake()
    {
        instance = this;

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
        colliders[checkpoint].enabled = false;
        
        if (checkpoint+1 >= colliders.Count) {
            currentLap++;
            Debug.Log("Lap " + currentLap + " reached");
        }
        else {
            colliders[checkpoint+1].enabled = true;
        }

        if (currentLap >= numberLaps) {
            // TODO: End game
            Debug.Log("Game ended");
            pauseMenu.SetActive(true);
        }

    }


}

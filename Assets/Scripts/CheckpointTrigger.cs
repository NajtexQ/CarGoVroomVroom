using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointTrigger : MonoBehaviour
{
    public int cpindex;

    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Checkpoint " + cpindex + " reached");

        if (other.tag == "Player")
        {
            CheckpointsManager.instance.CheckpointReached(cpindex);
            Debug.Log("Checkpoint " + cpindex + " reached");
        }
    }
}

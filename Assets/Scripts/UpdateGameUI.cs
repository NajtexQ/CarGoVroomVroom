using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateGameUI : MonoBehaviour
{
    public TextMeshProUGUI lapText;
    void Update()
    {
        // Update the laps text
        lapText.text = CheckpointsManager.instance.currentLap+1 + "/" + CheckpointsManager.instance.numberLaps;
    }
}

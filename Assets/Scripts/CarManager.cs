using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarManager : MonoBehaviour
{
    public GameObject carParts;

    void Awake() {

    }

    void Start()
    {
        Debug.Log("CarManager Start");
        
        // Load car body
        LoadCarPart("Prefabs/Body/Black_Body");
        // Load exhaust
        LoadCarPart("Prefabs/Exhaust/Exhaust_2");
        // Load engine
        LoadCarPart("Prefabs/Engine_Intake_Top/Black_Engine_Intake_top_1");
        // Load helmet
        LoadCarPart("Prefabs/Helmets/Helmet_9_Devil");
        // Load suspension
        LoadCarPart("Prefabs/Suspensions/Suspension_2_White");
        // Load rear wing
        LoadCarPart("Prefabs/Wing_Rear/Gray_Rear_Wing_5");
        // Load front wing
        LoadCarPart("Prefabs/Wing_Front/Black_Front_Wing_5");

    }

    void LoadCarPart(string bodyName) {

        GameObject carBody = (GameObject)Resources.Load(bodyName, typeof(GameObject));
        carBody = Instantiate(carBody, new Vector3 (-15, 0.5f, 0), transform.rotation);
        carBody.transform.parent = carParts.transform;
    }
}

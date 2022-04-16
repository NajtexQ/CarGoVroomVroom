using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class CarManager : MonoBehaviour
{
    public GameObject carParts;

    Vector3 carPartsPosition = new Vector3(-15, 0.5f, 0);
    
    Dictionary<string, string> carPartsPaths = new Dictionary<string, string>()
    {
        {"body", "Prefabs/Body/"},
        {"exhaust", "Prefabs/Exhaust/"},
        {"engineTop", "Prefabs/Engine_Intake_Top/"},
        {"helmet", "Prefabs/Helmets/"},
        {"suspension", "Prefabs/Suspensions/"},
        {"wingRear", "Prefabs/Wing_Rear/"},
        {"wingFront", "Prefabs/Wing_Front/"},
        {"wheels", "Prefabs/Wheels/"},
    };

    Dictionary<string, string> defaultCarParts = new Dictionary<string, string>()
    {
        {"body", "Black_Body"},
        {"exhaust", "Exhaust_2"},
        {"engineTop", "Black_Engine_Intake_top_1"},
        {"helmet", "Helmet_9_Devil"},
        {"suspension", "Suspension_2_White"},
        {"wingRear", "Gray_Rear_Wing_5"},
        {"wingFront", "Black_Front_Wing_5"},
        {"wheel", "Wheel_A"},
    }; 

    void Awake()
    {
        //PlayerPrefs.SetString("carParts", JsonConvert.SerializeObject(defaultCarParts));

        // Convert default car parts to string
        string defaultCarPartsString = JsonConvert.SerializeObject(defaultCarParts);
        Debug.Log(defaultCarPartsString);


        //string loadCarParts = JsonConvert.DeserializeObject<Dictionary<string, string>>(PlayerPrefs.GetString("carParts")).ToString();

        //Debug.Log(loadCarParts);
        

        // Load car body
        LoadCarPart("Prefabs/Body/Black_Body", carPartsPosition);
        // Load exhaust
        LoadCarPart("Prefabs/Exhaust/Exhaust_2", carPartsPosition);
        // Load engine
        LoadCarPart("Prefabs/Engine_Intake_Top/Black_Engine_Intake_top_1", carPartsPosition);
        // Load helmet
        LoadCarPart("Prefabs/Helmets/Helmet_9_Devil", carPartsPosition);
        // Load suspension
        LoadCarPart("Prefabs/Suspensions/Suspension_2_White", carPartsPosition);
        // Load rear wing
        LoadCarPart("Prefabs/Wing_Rear/Gray_Rear_Wing_5", carPartsPosition);
        // Load front wing
        LoadCarPart("Prefabs/Wing_Front/Black_Front_Wing_5", carPartsPosition);
        // Load wheels
        LoadCarPart("Prefabs/Wheels/Wheel_A", carPartsPosition);
    }

    void Start()
    {

    }

    void LoadCarPart(string bodyName, Vector3 carPosition) {

        GameObject carBody = (GameObject)Resources.Load(""+bodyName, typeof(GameObject));
        carBody = Instantiate(carBody, carPosition, transform.rotation);
        carBody.transform.parent = carParts.transform;
    }
}
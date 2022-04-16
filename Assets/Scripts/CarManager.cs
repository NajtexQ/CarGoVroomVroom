using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class CarManager : MonoBehaviour
{
    public GameObject carParts;

    Vector3 carPartsPosition = new Vector3(-15, 0.5f, 0);

    public Dictionary<string, string> selectedCarParts;
    
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
        {"wheels", "Wheel_A"},
    };

    Dictionary<string, string> testCarParts = new Dictionary<string, string>()
    {
        {"body", ""},
        {"exhaust", "Exhaust_2"},
        {"engineTop", "Black_Engine_Intake_top_1"},
        {"helmet", "Helmet_9_Devil"},
        {"suspension", "Suspension_2_White"},
        {"wingRear", "Gray_Rear_Wing_5"},
        {"wingFront", "Black_Front_Wing_5"},
        {"wheels", "Wheel_A"},
    }; 

    void Awake()
    {
        // Convert default car parts to json
        string json = JsonConvert.SerializeObject(testCarParts);
        PlayerPrefs.SetString("selectedCarParts", json);

        // Get selected car parts from player prefs
        string json2 = PlayerPrefs.GetString("selectedCarParts");
        selectedCarParts = JsonConvert.DeserializeObject<Dictionary<string, string>>(json2);

        LoadFullCar();
    }

    void Start()
    {

    }

    void LoadCarPart(string carPath, Vector3 carPosition) {

        GameObject carBody = (GameObject)Resources.Load(carPath, typeof(GameObject));
        carBody = Instantiate(carBody, carPosition, transform.rotation);
        carBody.transform.parent = carParts.transform;
    }

    string CarPathConverter(string carPart) {
        return carPartsPaths[carPart] + selectedCarParts[carPart];
    }

    void LoadFullCar() {

        // Loop through carPathsParts and debugLog key
        foreach (KeyValuePair<string, string> carPart in carPartsPaths)
        {
            if (selectedCarParts.ContainsKey(carPart.Key) && selectedCarParts[carPart.Key] != "")
            {
                LoadCarPart(CarPathConverter(carPart.Key), carPartsPosition);
            }
            else
            {
                LoadCarPart(carPartsPaths[carPart.Key] + defaultCarParts[carPart.Key], carPartsPosition);
            }
        }

    } 
}
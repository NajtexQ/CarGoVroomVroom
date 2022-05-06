using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class CarManager : MonoBehaviour
{
    public static CarManager instance;

    public GameObject carParts;

    Vector3 carPartsPosition = new Vector3(-15, 0.5f, 0);

    public Dictionary<string, string> selectedCarParts;
    
    public static Dictionary<string, string> carPartsPaths = new Dictionary<string, string>()
    {
        {"body", "CarParts/Body/"},
        {"exhaust", "CarParts/Exhaust/"},
        {"engineTop", "CarParts/Engine_Intake_Top/"},
        {"helmet", "CarParts/Helmets/"},
        {"suspension", "CarParts/Suspensions/"},
        {"wingRear", "CarParts/Wing_Rear/"},
        {"wingFront", "CarParts/Wing_Front/"},
        {"wheels", "CarParts/Wheels/"},
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

    public Dictionary<string, string> testCarParts = new Dictionary<string, string>()
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

    void Awake()
    {
        instance = this;

        // Get selected car parts from player prefs
        string json2 = PlayerPrefs.GetString("selectedCarParts");
        selectedCarParts = JsonConvert.DeserializeObject<Dictionary<string, string>>(json2);

        // If there are no selected car parts, set default car parts
        if (selectedCarParts == null)
        {
            selectedCarParts = defaultCarParts;

            // Save default car parts to player prefs
            string json = JsonConvert.SerializeObject(selectedCarParts);
            PlayerPrefs.SetString("selectedCarParts", json);

        }

        LoadFullCar();

    }

    void Start()
    {

    }

    void SaveCarParts(Dictionary<string, string> carParts)
    {
        // Convert car parts to json
        string json = JsonConvert.SerializeObject(carParts);
        PlayerPrefs.SetString("selectedCarParts", json);
    }

    void LoadCarPart(string carPath, Vector3 carPosition) {

        GameObject carBody = (GameObject)Resources.Load(carPath, typeof(GameObject));
        carBody = Instantiate(carBody, carPosition, transform.rotation);
        carBody.transform.parent = carParts.transform;
        carBody.tag = "Player";
    }

    string CarPathConverter(string carPart) {
        return carPartsPaths[carPart] + selectedCarParts[carPart];
    }

    public void LoadFullCar() {

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
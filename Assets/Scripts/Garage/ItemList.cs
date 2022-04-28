using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Newtonsoft.Json;

public class ItemList : MonoBehaviour
{ 
    Dictionary<string, string> selectedCarParts;
    
    public Dictionary<string, string> allItems = new Dictionary<string, string>()
    {
        {"body", "Body"},
        {"exhaust", "Exhaust"},
        {"engineTop", "Engine Top"},
        {"helmet", "Helmet"},
        {"suspension", "Suspension"},
        {"wingRear", "Wing Rear"},
        {"wingFront", "Wing Front"},
        {"wheels", "Wheels"},
    };
    
    void Awake()
    {
        // Get selected car parts from player prefs
        string json = PlayerPrefs.GetString("selectedCarParts");
        selectedCarParts = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);

        Debug.Log("selectedCarParts: " + selectedCarParts["body"]);

        LoadAllItems();
    }

    void LoadItem(string itemName, string itemKey)
    {
        string itemPath = "UI/Garage/ListItem";

        Debug.Log("Loading item: " + itemName);
        
        GameObject item = (GameObject)Resources.Load(itemPath, typeof(GameObject));
        item = Instantiate(item, transform.position, transform.rotation);

        // Set parent to item list
        item.transform.SetParent(transform);

        // Get child Text component
        TextMeshProUGUI itemText = item.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        itemText.text = itemName;

        // Get second child text component
        TextMeshProUGUI itemText2 = item.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        itemText2.text = selectedCarParts[itemKey];
    }

    void LoadAllItems() 
    {
        foreach (KeyValuePair<string, string> item in allItems)
        {
            LoadItem(item.Value, item.Key);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class GarageManager : MonoBehaviour
{

    public TextMeshProUGUI categoryName;
    public TextMeshProUGUI itemName;
    public EventSystem eventSystem;
    public GameObject partsList;

    void Awake()
    {
        string[] bodyParts = PartArray("Body");
        string[] exhaustParts = PartArray("Exhaust");
        string[] engineParts = PartArray("Engine_Intake_Top");
        string[] helmetsParts = PartArray("Helmets");
        string[] wheelsParts = PartArray("Wheels");
        string[] suspensionsParts = PartArray("Suspensions");
        string[] wingRearParts = PartArray("Wing_Rear");
        string[] wingFrontParts = PartArray("Wing_Front");

    }
    
    void Start()
    {
        // Get first game object in parts list
        GameObject firstItem = partsList.transform.GetChild(0).gameObject;

        // Set first item as selected
        eventSystem.SetSelectedGameObject(firstItem);

        categoryName.text = firstItem.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text;

        itemName.text = firstItem.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text;

        CarManager.instance.LoadFullCar();
    }

    void Update()
    {
        // Check which item is selected
        if (eventSystem.currentSelectedGameObject != null)
        {
            // Check if item is part of the parts list
            if (eventSystem.currentSelectedGameObject.transform.parent.name == "PartsList")
            {
                categoryName.text = eventSystem.currentSelectedGameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text;

                itemName.text = eventSystem.currentSelectedGameObject.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text;
            }
        }
    }

    public string[] PartArray(string name) {
        GameObject[] bodyParts = Resources.LoadAll<GameObject>("CarParts/" + name + "/");
        string[] partArray = new string[bodyParts.Length];

        for (int i = 0; i < bodyParts.Length; i++) {
            partArray[i] = bodyParts[i].name;
        }

        return partArray;
    }

    public void UpdateCar() {

        string partName = itemName.text;
        
        // Delete old car part and load new one
        GameObject oldPart = GameObject.Find(partName + "(Clone)");
        Destroy(oldPart);

        GameObject newPart = Instantiate(Resources.Load<GameObject>("CarParts/Body/" + partName));
        newPart.name = partName;
        newPart.transform.SetParent(GameObject.Find("Car").transform);
        newPart.transform.localPosition = Vector3.zero;
        newPart.transform.localRotation = Quaternion.identity;
    }


    public void ChangeCategory(GameObject item)
    {
        // Set selected item as selected
        eventSystem.SetSelectedGameObject(item);

        // Set category name
        categoryName.text = item.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text;

        // Set item name
        itemName.text = item.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text;
    }
}

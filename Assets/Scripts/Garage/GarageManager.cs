using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using Newtonsoft.Json;

public class GarageManager : MonoBehaviour
{

    public TextMeshProUGUI categoryName;
    public TextMeshProUGUI itemName;
    public EventSystem eventSystem;
    public GameObject partsList;

    public GameObject selectBtn;
    public Text selectBtnText;

    Dictionary<string, string> selectedCarParts;

    public Dictionary<string, string[]> allPartsList = new Dictionary<string, string[]>();

    string currentSelectedCategory;

    void Awake()
    {

        LoadSelectedCar();

        allPartsList.Add("body", PartArray("Body"));
        allPartsList.Add("exhaust", PartArray("Exhaust"));
        allPartsList.Add("engineTop", PartArray("Engine_Intake_Top"));
        allPartsList.Add("helmet", PartArray("Helmets"));
        allPartsList.Add("suspension", PartArray("Suspensions"));
        allPartsList.Add("wingRear", PartArray("Wing_Rear"));
        allPartsList.Add("wingFront", PartArray("Wing_Front"));
        allPartsList.Add("wheels", PartArray("Wheels"));
        
    }
    
    void Start()
    {
        // Get first game object in parts list
        GameObject firstItem = partsList.transform.GetChild(0).gameObject;

        // Set first item as selected
        eventSystem.SetSelectedGameObject(firstItem);

        categoryName.text = firstItem.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text;

        selectBtn.GetComponent<Button>().interactable = false;
        selectBtnText.text = "Selected";
    }

    void Update()
    {
        // Check which item is selected
        if (eventSystem.currentSelectedGameObject != null)
        {
            // Check if item is part of the parts list
            if (eventSystem.currentSelectedGameObject.transform.parent.name == "PartsList")
            {

                string currentSelectedItem = eventSystem.currentSelectedGameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text;

                if (currentSelectedItem != currentSelectedCategory)
                {
                    CarManager.instance.UpdateFullCar();

                    categoryName.text = eventSystem.currentSelectedGameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text;

                    currentSelectedCategory = categoryName.text;

                    itemName.text = GetCurrentItem();

                    CheckSelectBtn(itemName.text);

                    HandleCameras.instance.EnableCameraByName(currentSelectedCategory);
                }
            }
        }
    }

    public void NextItem()
    {

        Debug.Log("NextItem");

        // Get key from ItemList.allItems by value
        string key = "";
        foreach (KeyValuePair<string, string> item in ItemList.allItems)
        {
            if (item.Value == currentSelectedCategory)
            {
                key = item.Key;
            }
        }

        Debug.Log("Key: " + key);

        // Get an array of items from dictionary allPartsList by key
        string[] items = allPartsList[key];

        string oldItem = itemName.text;

        // Get index of current selected item
        int index = 0;
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] == itemName.text)
            {
                index = i;
            }
        }

        Debug.Log("Index: " + index);

        if (index == items.Length - 1)
        {
            index = 0;
        }
        else
        {
            index++;
        }

        string newItem = items[index];

        Debug.Log("NewItem: " + newItem);

        string categoryId = "";

        foreach (KeyValuePair<string, string> item in ItemList.allItems)
        {
            if (item.Value == currentSelectedCategory)
            {
                categoryId = item.Key;
            }
        }

        CarManager.instance.UpdateCarPart(oldItem, newItem, categoryId);

        UpdateItem(newItem);

        CheckSelectBtn(newItem);

    }

    public void PreviousItem()
    {
        
        Debug.Log("PrevItem");

        // Get key from ItemList.allItems by value
        string key = "";
        foreach (KeyValuePair<string, string> item in ItemList.allItems)
        {
            if (item.Value == currentSelectedCategory)
            {
                key = item.Key;
            }
        }

        Debug.Log("Key: " + key);

        // Get an array of items from dictionary allPartsList by key
        string[] items = allPartsList[key];
        
        string oldItem = itemName.text;

        // Get index of current selected item
        int index = 0;
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] == itemName.text)
            {
                index = i;
            }
        }

        Debug.Log("Index: " + index);

        if (index == 0)
        {
            index = items.Length - 1;
        }
        else
        {
            index--;
        }

        string newItem = items[index];

        Debug.Log("NewItem: " + newItem);

        string categoryId = "";

        foreach (KeyValuePair<string, string> item in ItemList.allItems)
        {
            if (item.Value == currentSelectedCategory)
            {
                categoryId = item.Key;
            }
        }

        CarManager.instance.UpdateCarPart(oldItem, newItem, categoryId);

        UpdateItem(newItem);

        CheckSelectBtn(newItem);
    }

    void UpdateItem(string item)    
    {
        itemName.text = item;
    }

    public void CheckSelectBtn(string item)
    {
        if (selectedCarParts.ContainsValue(item))
        {
            selectBtn.GetComponent<Button>().interactable = false;
            selectBtnText.text = "Selected";
        }
        else
        {
            selectBtn.GetComponent<Button>().interactable = true;
            selectBtnText.text = "Select";
        }
    }

    public string[] PartArray(string name)
    {
        GameObject[] bodyParts = Resources.LoadAll<GameObject>("CarParts/" + name + "/");
        string[] partArray = new string[bodyParts.Length];

        for (int i = 0; i < bodyParts.Length; i++) {
            partArray[i] = bodyParts[i].name;
        }

        return partArray;
    }

    public void ChangeCategory(GameObject item)
    {
        // Set selected item as selected
        eventSystem.SetSelectedGameObject(item);

        // Set category name
        categoryName.text = item.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text;

    }

    public void SelectItem()
    {
        string key = "";
        foreach (KeyValuePair<string, string> item in ItemList.allItems)
        {
            if (item.Value == currentSelectedCategory)
            {
                key = item.Key;
            }
        }

        selectedCarParts[key] = itemName.text;

        CheckSelectBtn(itemName.text);

        SaveSelectedCar();
        LoadSelectedCar();
        
    }

    public string GetCurrentItem()
    {
        string key = "";
        foreach (KeyValuePair<string, string> item in ItemList.allItems)
        {
            if (item.Value == currentSelectedCategory)
            {
                key = item.Key;
            }
        }

        Debug.Log("Key: " + key);
        Debug.Log("Item: " + selectedCarParts[key]);

        return selectedCarParts[key];
    }

    public string ReplaceUnderScoreWithSpace(string name)
    {
        return name.Replace("_", " ");
    }

    public void LoadSelectedCar()
    {
        string json = PlayerPrefs.GetString("selectedCarParts");
        selectedCarParts = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
    }

    public void SaveSelectedCar()
    {
        string json = JsonConvert.SerializeObject(selectedCarParts);
        PlayerPrefs.SetString("selectedCarParts", json);
    }
}
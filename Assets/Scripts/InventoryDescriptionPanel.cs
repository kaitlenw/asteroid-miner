using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryDescriptionPanel : MonoBehaviour
{
    void OnEnable()
    {
        GetComponent<Text>().text = 
        $"Inventory\n\nTotal number of Items: {Inventory.instance.Count()}\nCurrent Capacity: {Inventory.instance.inventoryCapacity}";
    }
}

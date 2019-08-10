using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Item item;
    public Image icon;
    public Text itemCount;

    public Text description;
    private Inventory inventory;

    void Start()
    {
        inventory = Inventory.instance;
    }
    void OnEnable()
    {
        icon.sprite = item.image;
        icon.enabled = true;
        itemCount.text = Inventory.instance.inventory[item.id] + "";
        itemCount.enabled = true;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        description.text = item.itemName + "\n\n" + item.description + "\nSelling Price: " + item.sellingPrice;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // Debug.Log("Mouse exit");
        description.text = $"Inventory\n\nTotal number of Items: {inventory.Count()}\nCurrent Capacity: {inventory.inventoryCapacity}";
    }
}

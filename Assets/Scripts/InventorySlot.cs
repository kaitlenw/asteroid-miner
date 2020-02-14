using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class InventorySlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Item item;
    public Image icon;
    public Text itemCount;

    public GameObject description;
    private Inventory inventory;

    private TMP_Text descText;

    void Start()
    {
        inventory = Inventory.instance;
        descText = description.transform.Find("DescriptionText").gameObject.GetComponent<TMP_Text>();
        descText.text = $"Inventory\n\nTotal number of Items: {inventory.Count()}\nCurrent Capacity: {inventory.InventoryCapacity}";
    }
    void OnEnable()
    {
        icon.sprite = item.image;
        icon.enabled = true;
        itemCount.text = Inventory.instance.inventory[item.id] + "";
        itemCount.enabled = true;
        descText.text = $"Inventory\n\nTotal number of Items: {inventory.Count()}\nCurrent Capacity: {inventory.InventoryCapacity}";
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        descText.text = item.itemName + "\n\n" + item.description + "\nSelling Price: " + item.sellingPrice;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        descText.text = $"Inventory\n\nTotal number of Items: {inventory.Count()}\nCurrent Capacity: {inventory.InventoryCapacity}";
    }
}

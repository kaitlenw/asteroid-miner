using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ShopSlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public Item item;
    public Image icon;
    public Image glow;
    public Text itemCount;

    public Text description;
    private Inventory inventory;

    private bool selectedForSale;

    void Start()
    {
        inventory = Inventory.instance;
        selectedForSale = false;
        glow.enabled = false;
    }
    void OnEnable()
    {
        icon.sprite = item.image;
        icon.enabled = true;
        itemCount.text = inventory.inventory[item.id] + "";
        itemCount.enabled = true;
        selectedForSale = false;
        glow.enabled = false;
        description.text = inventory.GetSalesSummary();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        description.text = item.itemName + "\n\n" + item.description + "\nSelling Price: " + item.sellingPrice;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (inventory.inventory[item.id] > 0)
        {
            selectedForSale = !selectedForSale;
            glow.enabled = selectedForSale;
            if (selectedForSale)
            {
                inventory.sellingList[item.id] = item;
            }
            else
            {
                inventory.sellingList[item.id] = null;
            }
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        description.text = inventory.GetSalesSummary();
    }
}

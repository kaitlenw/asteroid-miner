using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class ShopSlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public Item item;
    public Image icon;
    public Image glow;
    public Text itemCount;

    public GameObject description;
    public Inventory inventory;

    private TMP_Text descText;
    private bool selectedForSale;

    void Awake()
    {
        inventory = Inventory.instance;
        selectedForSale = false;
        glow.enabled = false;
        descText = description.transform.Find("DescriptionText").gameObject.GetComponent<TMP_Text>();
    }
    void OnEnable()
    {
        Reset();
    }

    public void Reset()
    {
        icon.sprite = item.image;
        icon.enabled = true;
        itemCount.text = inventory.inventory[item.id] + "";
        itemCount.enabled = true;
        selectedForSale = false;
        glow.enabled = false;
        descText.text = inventory.GetSalesSummary();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        descText.text = item.itemName + "\n\n" + item.description + "\nSelling Price: " + item.sellingPrice;
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
        descText.text = inventory.GetSalesSummary();
    }
}

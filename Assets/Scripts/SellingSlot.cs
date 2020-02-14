using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SellingSlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public Item item;
    public Image icon;
    public Image glow;
    public Text itemCount;
    public Inventory inventory;

    private bool isMouseOver;

    void Awake()
    {
        inventory = Inventory.instance;
        glow.enabled = false;
    }
    void OnEnable()
    {
        Reset();
    }

    void Update()
    {
        glow.enabled = isMouseOver;
    }
    public void Reset()
    {
        icon.sprite = item.image;
        icon.enabled = true;
        itemCount.text = inventory.inventory[item.id] + "";
        itemCount.enabled = true;
        glow.enabled = false;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (inventory.inventory[item.id] > 0)
        {
            inventory.SellItem(item);
            Reset();
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isMouseOver = true;
        glow.enabled = true;

    }
    public void OnPointerExit(PointerEventData eventData)
    {
        isMouseOver = false;
        glow.enabled = false;
    }
}

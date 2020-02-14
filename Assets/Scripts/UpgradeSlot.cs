using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UpgradeSlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public Upgrade upgrade;
    public Image icon;
    public Image glow;
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
        icon.sprite = upgrade.image;
        icon.enabled = true;
        glow.enabled = false;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        inventory.BuyUpgradeItem(this.upgrade);
        Debug.Log("Buy Upgrade: " + upgrade.upgradeName);
        Reset();
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

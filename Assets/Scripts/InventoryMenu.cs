using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryMenu : MonoBehaviour
{
    public static bool isInventoryShowing;
    public static bool isShopShowing;
    public GameObject inventoryUI;
    public GameObject shopUI;
    public GameObject moneyUI;
    private Inventory inventory;
    public Player player;

    void Start()
    {
        inventory = player.inventory;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isInventoryShowing)
            {
                Resume();
            }
            else if (!isShopShowing)
            {
                PauseAndShowInventory();
            }
        }
        // else if (Input.GetKeyDown(KeyCode.M))
        // {
        //     inventory.ResetSellingList();
        //     if (isShopShowing)
        //     {
        //         Resume();
        //     }
        //     else if (!isInventoryShowing)
        //     {
        //         PauseAndShowShop();
        //     }
        // }
    }

    public void Resume()
    {
        inventoryUI.SetActive(false);
        shopUI.SetActive(false);
        moneyUI.SetActive(false);
        Time.timeScale = 1;
        isInventoryShowing = false;
        isShopShowing = false;
    }

    public void RefuelShip()
    {
        int missingFuel = player.GetMissingFuel();
        if (missingFuel > inventory.money)
        {
            missingFuel = inventory.money;
        }
        inventory.money -= missingFuel;
        player.currentFuel += missingFuel;
    }

    void PauseAndShowInventory()
    {
        inventoryUI.SetActive(true);
        ShowMoneyPanel();
        Time.timeScale = 0;
        isInventoryShowing = true;
    }
    public void PauseAndShowShop()
    {
        inventory.ResetSellingList();
        shopUI.SetActive(true);
        ShowMoneyPanel();
        Time.timeScale = 0;
        isShopShowing = true;
    }

    private void ShowMoneyPanel()
    {
        moneyUI.transform.Find("MoneyText").gameObject.GetComponent<TMP_Text>().text = "" + inventory.money;
        moneyUI.SetActive(true);
    }

    public void OnGUI()
    {
        if (isShopShowing)
        {
            ShopSlot[] slots = (ShopSlot[]) FindObjectsOfType<ShopSlot>();
            foreach (ShopSlot slot in slots)
            {
                slot.Reset();
            }
        }
        ShowMoneyPanel();
    }
}

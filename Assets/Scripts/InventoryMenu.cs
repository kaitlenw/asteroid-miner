using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryMenu : MonoBehaviour
{
    public static bool isInventoryShowing;
    public static bool isShopShowing;
    public GameObject inventoryUI;
    public GameObject shopUI;
    public Inventory inventory;

    void Start()
    {
        inventory = Inventory.instance;
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
        Time.timeScale = 1;
        isInventoryShowing = false;
        isShopShowing = false;
    }

    public void SellItems()
    {
        inventory.SellSelectedItems();
        Debug.Log(inventory.money);
    }

    void PauseAndShowInventory()
    {
        inventoryUI.SetActive(true);
        Time.timeScale = 0;
        isInventoryShowing = true;
    }
    public void PauseAndShowShop()
    {
        shopUI.SetActive(true);
        Time.timeScale = 0;
        isShopShowing = true;
    }
}

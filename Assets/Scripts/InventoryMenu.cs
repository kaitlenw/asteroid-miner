using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryMenu : MonoBehaviour
{
    public static bool isInventoryShowing;
    public GameObject inventoryUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isInventoryShowing)
            {
                Resume();
            }
            else
            {
                PauseAndShowInventory();
            }
        }
    }

    void Resume()
    {
        inventoryUI.SetActive(false);
        Time.timeScale = 1;
        isInventoryShowing = false;
    }

    void PauseAndShowInventory()
    {
        inventoryUI.SetActive(true);
        Time.timeScale = 0;
        isInventoryShowing = true;
    }
}

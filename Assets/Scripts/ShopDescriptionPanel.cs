using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopDescriptionPanel : MonoBehaviour
{
    void OnEnable()
    {
        GetComponent<Text>().text = 
        Inventory.instance.GetSalesSummary();
    }
}

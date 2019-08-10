using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class WorldItem  : MonoBehaviour
{
    void OnTriggerEnter2D (Collider2D collider)
    {
        if (collider.gameObject.GetComponent<Inventory>().AddItem(gameObject.tag))
        {
            // GameObject matObj = collider.gameObject;
            // matObj.GetComponent<Collider2D>().enabled = false;
            Destroy(gameObject);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Planet : MonoBehaviour
{
    private float defaultBounceValue;
    public float dragValue = 1.0f;

    private Canvas ui;
    void Start()
    {
        ui = GameObject.Find("UIManager").GetComponent<Canvas>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            defaultBounceValue = collision.sharedMaterial.bounciness;
            collision.gameObject.GetComponent<Collider2D>().sharedMaterial.bounciness = 0.0f;
            collision.gameObject.GetComponent<Rigidbody2D>().drag = dragValue;

        }
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.P) && collision.gameObject.tag == "Player")
        {
            Debug.Log("PLANET");
            ui.GetComponent<InventoryMenu>().PauseAndShowShop();


        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Collider2D>().sharedMaterial.bounciness = defaultBounceValue;
            collision.gameObject.GetComponent<Rigidbody2D>().drag = 0.0f;
        }
    }
}

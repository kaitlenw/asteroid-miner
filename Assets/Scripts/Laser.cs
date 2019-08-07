using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 2.5f;
    private Rigidbody2D r2d;
    void Start()
    {
        r2d = (Rigidbody2D)GetComponent("Rigidbody2D");
    }

    void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime;
    }

    void OnBecameInvisible() 
    {
        // Destroy the bullet 
        Destroy(gameObject);
    } 
}

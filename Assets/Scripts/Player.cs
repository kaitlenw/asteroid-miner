using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed = 5f;
    public float turnSpeed = 2.5f;

    // Update is called once per frame
    void Update ()
    {

    }

    void FixedUpdate ()
    {
        float x = Input.GetAxis ("Horizontal");
        float y = Input.GetAxis ("Vertical");

        Vector2 moveVec = new Vector2 (x, y) * speed;
        GetComponent<Rigidbody2D> ().AddForce (moveVec);

        if (moveVec != Vector2.zero)
        {
            transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (Vector3.forward, moveVec), Time.fixedDeltaTime * turnSpeed);
        }
    }
}
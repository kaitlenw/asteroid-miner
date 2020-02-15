using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D r2d;
    public Rigidbody2D laser;
    public SpriteRenderer shield;
    public GameObject thrusters;
    public float speed = 5f;
    public float turnSpeed = 2.5f;
    public float projSpeed = 2.5f;
    
    public float bounce = 0.5f;

    private float xDir;
    private float yDir;

    void Start()
    {
        r2d = GetComponent<Rigidbody2D>();
        GetComponent<Collider2D>().sharedMaterial.bounciness = bounce;
        InvokeRepeating("SetDirection", 2.0f, 0.3f);
    }

    void FixedUpdate()
    {
        if (xDir + yDir != 0)
        {
            thrusters.SetActive(true);
        }
        else
        {
            thrusters.SetActive(false);
        }

        Vector2 moveVec = new Vector2(xDir, yDir) * speed;
        r2d.AddForce(moveVec);

        if (moveVec != Vector2.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.forward, moveVec), Time.fixedDeltaTime * turnSpeed);
        }
        // Check to see if Space is pressed
        if (Input.GetKeyDown("space"))
        {
            // Instantiate an laser
            Rigidbody2D laserInstance = Instantiate(laser, transform.position, transform.rotation);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Asteroid")
        {
            // audioSource.PlayOneShot(hitMeteor);
            shield.enabled = true;
            Invoke("HideShield", 0.2f);
        }
    }
    void HideShield()
    {
        shield.enabled = false;
    }

    private void SetDirection()
    {
        xDir = Random.Range(-1.0f, 1.0f);
        yDir = Random.Range(-1.0f, 1.0f);
    }
    
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D r2d;
    public Rigidbody2D laser;
    public SpriteRenderer shield;
    public float speed = 5f;
    public float turnSpeed = 2.5f;
    public float projSpeed = 2.5f;

    public AudioClip shootLaser;
    public AudioClip hitMeteor;
    private AudioSource audioSource; 

    void Start ()
    {
        audioSource = GetComponent<AudioSource>();
        r2d = GetComponent<Rigidbody2D> ();
        
    }

    void FixedUpdate ()
    {
        float x = Input.GetAxis ("Horizontal");
        float y = Input.GetAxis ("Vertical");

        Vector2 moveVec = new Vector2 (x, y) * speed;
        r2d.AddForce (moveVec);

        if (moveVec != Vector2.zero)
        {
            transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (Vector3.forward, moveVec), Time.fixedDeltaTime * turnSpeed);
        }
        // Check to see if Space is pressed
        if(Input.GetKeyDown("space"))
        {
            // Instantiate an laser
            Rigidbody2D laserInstance = Instantiate(laser, transform.position, transform.rotation);
            audioSource.PlayOneShot(shootLaser, 0.7f);
        }
    }

    void OnCollisionEnter2D()
    {
            audioSource.PlayOneShot(hitMeteor);
            shield.enabled = true;
            Invoke("HideShield", 0.2f);
    }

    void HideShield()
    {
        shield.enabled = false;
    }
}
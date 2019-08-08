using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D laser;
    public float speed = 5f;
    public float turnSpeed = 2.5f;
    public float projSpeed = 2.5f;

    public AudioClip shootLaser;
    private AudioSource audioSource; 

    void Start ()
    {
        audioSource = GetComponent<AudioSource>();
        
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
        // Check to see if Space is pressed
        if(Input.GetKeyDown("space"))
        {
            // Instantiate an laser
            Rigidbody2D laserInstance = Instantiate(laser, transform.position, transform.rotation);
            audioSource.PlayOneShot(shootLaser, 0.7F);
        }
    }
}
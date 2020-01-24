using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Rigidbody2D r2d;
    public Rigidbody2D laser;
    public SpriteRenderer shield;
    public GameObject thrusters;
    public float speed = 5f;
    public float turnSpeed = 2.5f;
    public float projSpeed = 2.5f;

    // max fuel capacity
    public int maxFuel = 1000;

    // current fuel
    public int currentFuel = 1000;
    
    // how much fuel is used each time the thrusters are engaged
    private int fuelUsage = 1;

    // max amount of shields
    public float maxShields = 1000.0f;
    // current amount of shield
    public float shields = 1000.0f;
    // how much shield is lost each time damage is taken
    private float shieldDamage = 0.2f;
    public Slider fuelSlider;
    public Slider shieldSlider;

    public AudioClip shootLaser;
    public AudioClip hitMeteor;
    private AudioSource audioSource;
    public Inventory inventory;

    public float bounce = 0.5f;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        r2d = GetComponent<Rigidbody2D>();
        inventory = Inventory.instance;
        GetComponent<Collider2D>().sharedMaterial.bounciness = bounce;

        // assumption that fuel is full to begin with
        fuelSlider.maxValue = maxFuel;
        fuelSlider.value = currentFuel;

        // asumption that shields are full to begin with
        shieldSlider.maxValue = maxShields;
        shieldSlider.value = shields;

    }

    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        if (x + y != 0)
        {
            currentFuel -= fuelUsage;
            thrusters.SetActive(true);
        }
        else
        {
            thrusters.SetActive(false);
        }

        Vector2 moveVec = new Vector2(x, y) * speed;
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
            audioSource.PlayOneShot(shootLaser, 0.7f);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Asteroid")
        {
            audioSource.PlayOneShot(hitMeteor);
            shield.enabled = true;
            shields -= shieldDamage;
            Invoke("HideShield", 0.2f);
        }
    }
    void HideShield()
    {
        shield.enabled = false;
    }
    public int GetMissingFuel()
    {
        return maxFuel - currentFuel;
    }
    void OnGUI()
    {
        fuelSlider.value = currentFuel;
        shieldSlider.value = shields;
    }
}
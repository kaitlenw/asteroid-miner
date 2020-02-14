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

    // starting max fuel capacity
    public int startMaxFuel = 1000;

    public int MaxFuel
    {
        get
        {
            return startMaxFuel + inventory.GetFuelUpgrade();
        }
    }

    // amount of fuel that has been used by the player
    public int UsedFuel
    {
        get;
        set;
    } = 0;
    
    // how much fuel is used each time the thrusters are engaged
    private int fuelUsage = 1;

    // starting max amount of shields
    public float startMaxShields = 1000.0f;

    public float MaxShields
    {
        get
        {
            return startMaxShields + inventory.GetShieldUpgrade();
        }
    }
    // amount of damage that the player has taken
    public float lostShields = 0.0f;
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

        UpdateStatusDisplay();
    }

    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        if (x + y != 0)
        {
            UsedFuel += fuelUsage;
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
            lostShields += shieldDamage;
            Invoke("HideShield", 0.2f);
        }
    }
    void HideShield()
    {
        shield.enabled = false;
    }
    public int GetCurrentFuel()
    {
        return MaxFuel - UsedFuel;
    }

    public float GetCurrentShields()
    {
        return MaxShields - lostShields;
    }
    void OnGUI()
    {
        UpdateStatusDisplay();
    }

    private void UpdateStatusDisplay()
    {
        fuelSlider.maxValue = MaxFuel;
        shieldSlider.maxValue = MaxShields;

        fuelSlider.value = GetCurrentFuel();
        shieldSlider.value = GetCurrentShields();
    }
}
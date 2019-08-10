using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{

    public SpriteRenderer explosion;
    private AudioSource audioSource;
    public AudioClip explodeAsteroid;

    public Rigidbody2D material;

    public float explosionDuration;
    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Laser")
        {
            GetComponent<SpriteRenderer>().enabled = false;
            explosion.enabled = true;
            gameObject.GetComponent<Collider2D>().enabled = false;
            Destroy(collision.gameObject);
            audioSource.PlayOneShot(explodeAsteroid, 0.7f);
            if (material != null)
            {
                Invoke("CreateMaterial", explosionDuration);
            }
            else
            {
                Destroy(gameObject, explosionDuration);
            }
        }
    }
    void CreateMaterial()
    {
        Instantiate(material, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}

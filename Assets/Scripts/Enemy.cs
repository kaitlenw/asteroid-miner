using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D r2d;
    public Rigidbody2D laser;
    public SpriteRenderer shield;
    public GameObject thrusters;
    public float speed = 2f;
    public float turnSpeed = 2.5f;
    public float projSpeed = 2.5f;
    
    public float bounce = 0.5f;

    private float xDir;
    private float yDir;

    public Transform target;

    private Collider2D enemyCollider;

    private float radius = 2.0f;

    public float strength = 5.0f;

    void Start()
    {
        r2d = GetComponent<Rigidbody2D>();
        enemyCollider = GetComponent<Collider2D>();
        enemyCollider.sharedMaterial.bounciness = bounce;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere (transform.position, radius);

    }
    void FixedUpdate()
    {
        Vector3 targetDirection = (target.position - transform.position);
        if (Vector3.Dot(targetDirection, transform.forward) >= 0.9)
        {
            targetDirection = Vector3.zero;
        }
        enemyCollider.enabled = false;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radius);
        enemyCollider.enabled = true;
        if ((colliders.Length > 0))
        {
            Vector3 force = new Vector3();
            // We use anti-gravity to simulate obstacle avoidance for the enemy AI
            // The player does not provide an antigravity force against the enemy
            // Lasers do not provide an antigravity force against the enemy--make the game easier by not having the enemy avoid bullets 
            foreach (Collider2D collider in colliders)
            {
                if (collider.tag != "Player" && collider.tag != "Laser")
                {
                    Vector3 direction = collider.transform.position - transform.position;
                    float distance = Vector3.Distance(transform.position, collider.transform.position);
                    force += -direction * (strength/Mathf.Pow(distance, 2));
                    try 
                    {
                        LineRenderer lineRenderer = collider.gameObject.GetComponent<LineRenderer>();
                        lineRenderer.SetVertexCount(2);
                        lineRenderer.SetPosition(0, collider.transform.position);
                        lineRenderer.SetPosition(1, force * 20 + collider.transform.position);

                    }
                    catch (MissingComponentException)
                    {
                    }
                }
            }
            targetDirection += force;
        }

        r2d.AddForce(targetDirection * speed);
        if (targetDirection != Vector3.zero)
        {
            thrusters.SetActive(true);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.forward, targetDirection), Time.fixedDeltaTime * turnSpeed);
        }
        else
        {
            thrusters.SetActive(false);
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
    
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float bulletSpeed = 5f;
    public int maxRicochetCount = 2; // Maximum number of times the bullet can ricochet
    public float interpolationFactor = 0.5f; // Controls the smoothness of interpolation

    private Rigidbody2D rb;
    private int ricochetCount = 0;
    private bool isColliding = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        rb.velocity = transform.up * bulletSpeed;
        ricochetCount = 0;
        isColliding = false;
    }

    private void FixedUpdate()
    {
        if (isColliding)
        {
            // Interpolate the bullet position based on the interpolationFactor
            Vector2 interpolatedPosition = rb.position + rb.velocity * Time.fixedDeltaTime * interpolationFactor;
            rb.MovePosition(interpolatedPosition);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (ricochetCount < maxRicochetCount)
        {
            // Calculate the reflection direction
            Vector2 incomingVelocity = rb.velocity.normalized;
            Vector2 normal = collision.contacts[0].normal;
            Vector2 reflection = CalculateReflection(incomingVelocity, normal).normalized;
            rb.velocity = reflection * bulletSpeed;
            ricochetCount++;
            isColliding = true;
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isColliding = false;
    }

    private Vector2 CalculateReflection(Vector2 incoming, Vector2 normal)
    {
        // Reflect the incoming velocity smoothly
        return Vector2.Reflect(incoming, normal) * (1f - interpolationFactor) - rb.velocity * interpolationFactor;
    }
}



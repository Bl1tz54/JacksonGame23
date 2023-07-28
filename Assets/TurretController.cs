using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bulletSpeed = 5f;
    public float rotationSpeed = 100f;
    public float shootInterval = 1f;

    private Transform barrel;

    private void Start()
    {
        barrel = transform.Find("Barrel");
        InvokeRepeating("Shoot", shootInterval, shootInterval);
    }

    private void Update()
    {
        // Rotate the turret body
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }

    private void Shoot()
    {
        // Instantiate a bullet
        GameObject bullet = Instantiate(bulletPrefab, barrel.position, barrel.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = barrel.up * bulletSpeed;
    }
}


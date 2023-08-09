using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public class BulletLifetime : MonoBehaviour
    {
        public float lifetime = 4f; // The time in seconds before the bullet is destroyed

        private void Start()
        {
            // Start a coroutine to destroy the bullet after the specified lifetime
            StartCoroutine(DestroyAfterLifetime());
        }

        private IEnumerator DestroyAfterLifetime()
        {
            // Wait for the specified lifetime duration
            yield return new WaitForSeconds(lifetime);

            // Destroy the bullet game object
            Destroy(gameObject);
        }
    }

}



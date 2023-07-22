using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectiles : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;

    private Vector2 initialDirection; // Store the initial direction towards the player
    [SerializeField] private float projectilesSpeed = 5f;
    [SerializeField] private int projectilesDamage = 1;

    private void FixedUpdate()
    {
        // Move the projectile in the initial direction without any further changes
        rb.velocity = initialDirection * projectilesSpeed;
    }

    public void SetInitialDirection(Vector2 direction)
    {
        // Set the initial direction towards the player when the projectile is instantiated
        initialDirection = direction.normalized;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collision is with the player
        if (collision.gameObject.CompareTag("Player"))
        {
            // If it's the player, apply damage
            collision.gameObject.GetComponent<PlayerAttributes>().TakeDamage(projectilesDamage);
        }

        // Destroy the projectile regardless of the collision
        Destroy(gameObject);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectiles : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    private Vector2 initialDirection;
    [SerializeField] private float projectilesSpeed = 5f;
    [SerializeField] private int projectilesDamage = 1;

    private void FixedUpdate()
    {
        rb.velocity = initialDirection * projectilesSpeed;
    }

    public void SetInitialDirection(Vector2 direction)
    {
        initialDirection = direction.normalized;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerSkill playerSkill = other.gameObject.GetComponent<PlayerSkill>();
            if (playerSkill != null && !playerSkill.IsInvincible())
            {
                other.gameObject.GetComponent<PlayerAttributes>().TakeDamage(projectilesDamage);
            }
            Destroy(gameObject);
        }
    }
}
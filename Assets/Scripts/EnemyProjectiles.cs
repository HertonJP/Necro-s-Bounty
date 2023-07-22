using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectiles : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;

    private Transform target;

    [SerializeField] private float projectilesSpeed = 5f;
    [SerializeField] private int projectilesDamage = 1;

    
    
    public void SetTarget(Transform target)
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            this.target = player.transform;
        }
    }
    private void FixedUpdate()
    {
        if (!target)
        {
            return;
        }
        Vector2 direction = (target.position - transform.position).normalized;

        rb.velocity = direction * projectilesSpeed;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
       // other.gameObject.GetComponent<enemyHealth>().TakeDamage(projectilesDamage);
        Destroy(gameObject);
    }
}

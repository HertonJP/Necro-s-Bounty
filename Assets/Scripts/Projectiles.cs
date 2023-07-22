using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectiles : MonoBehaviour
{
    [SerializeField] public int projectilesDamage = 5;

    public string enemyTag = "Enemy"; 

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag(enemyTag))
        {
            
            collision.gameObject.GetComponent<Enemy>().TakeDamage(projectilesDamage);
        }

        
        Destroy(this.gameObject);
    }
}
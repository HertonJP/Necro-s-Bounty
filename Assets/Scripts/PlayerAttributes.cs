using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttributes : MonoBehaviour
{
    [SerializeField] public int playerHP = 100;
    [SerializeField] public float auraRange = 2f;

    private const string CorpseTag = "Corpse";

    public void TakeDamage(int damage)
    {
        playerHP -= damage;
        if (playerHP <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, auraRange);
    }
}
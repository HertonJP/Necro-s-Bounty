using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttributes : MonoBehaviour
{
    [SerializeField] public int playerHP = 100;
    [SerializeField] private float auraRange = 2f;

    private const string CorpseTag = "Corpse";

    private void Update()
    {
        // Check for corpses within the aura range
        Collider2D[] corpsesInRange = Physics2D.OverlapCircleAll(transform.position, auraRange, LayerMask.GetMask(CorpseTag));
        foreach (Collider2D corpseCollider in corpsesInRange)
        {
            if (corpseCollider.CompareTag(CorpseTag))
            {
                // Increase player's health and destroy the corpse
                playerHP += 5;
                Destroy(corpseCollider.gameObject);
            }
        }
    }

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
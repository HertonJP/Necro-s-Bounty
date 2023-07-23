using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttributes : MonoBehaviour
{
    [SerializeField] public int playerHP = 100;
    [SerializeField] public float auraRange = 2f;

    public GameObject gameOverPanel;

    private const string CorpseTag = "Corpse";

    public void TakeDamage(int damage)
    {
        playerHP -= damage;
        if (playerHP <= 0)
        {
            playerHP = 0; 
            Time.timeScale = 0f; 


            if (gameOverPanel != null)
            {
                gameOverPanel.SetActive(true);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, auraRange);
    }
}
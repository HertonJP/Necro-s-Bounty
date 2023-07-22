using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PlayerAttributes : MonoBehaviour
{
    [SerializeField] public int playerHP = 100;
    [SerializeField] private float auraRange = 2f;


    public void TakeDamage(int damage)
    {
        playerHP -= damage;
        if (playerHP <= 0 )
        {       
            Destroy(gameObject);
        }
    }




    private void OnDrawGizmosSelected()
    {
        Handles.color = Color.cyan;
        Handles.DrawWireDisc(transform.position, transform.forward, auraRange);
    }
}

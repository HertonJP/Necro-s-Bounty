using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PlayerAttributes : MonoBehaviour
{
    [SerializeField] public float moveSpeed = 5f;
    [SerializeField] public int damage = 10;
    [SerializeField] private float auraRange = 2f;






    private void OnDrawGizmosSelected()
    {
        Handles.color = Color.cyan;
        Handles.DrawWireDisc(transform.position, transform.forward, auraRange);
    }
}

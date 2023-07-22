using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Enemy : MonoBehaviour
{
    [SerializeField] private LayerMask heroMask;
    [SerializeField] private GameObject projectilesPrefab;
    [SerializeField] private Transform firingPoint;

    [SerializeField] private float targetingRange = 3f;
    [SerializeField] private float attackSpeed = 1f;

    private Transform target;
    private float timeUntilFire;


    private void Update()
    {
        if (target == null)
        {
            FindTarget();
            return;
        }

        if (!inRange())
        {
            target = null;
        }
        else
        {
            timeUntilFire += Time.deltaTime;
        }
        if (timeUntilFire >= 1f / attackSpeed)
        {
            Attack();
            timeUntilFire = 0f;
        }
    }

    private void Attack()
    {
        GameObject projectilesObj = Instantiate(projectilesPrefab, firingPoint.position, Quaternion.identity);
        EnemyProjectiles projectilesScript = projectilesObj.GetComponent<EnemyProjectiles>();
        projectilesScript.SetTarget(target);
        Debug.Log("Attack");
    }

    private bool inRange()
    {
        return Vector2.Distance(target.position, transform.position) <= targetingRange;
    }

    private void FindTarget()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, targetingRange, (Vector2)transform.position, 0f, enemyMask);
        if (hits.Length > 0)
        {
            target = hits[0].transform;
        }
    }


    private void OnDrawGizmosSelected()
    {
        Handles.color = Color.cyan;
        Handles.DrawWireDisc(transform.position, transform.forward, targetingRange);
    }
}

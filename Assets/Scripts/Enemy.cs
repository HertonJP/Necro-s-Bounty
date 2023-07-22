using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Enemy : MonoBehaviour
{
    [SerializeField] private LayerMask playerMask;
    [SerializeField] private GameObject projectilesPrefab;
    [SerializeField] private Transform firingPoint;
    [SerializeField] public int initialEnemyHP = 20;
    public int enemyHP;
    private bool isDestroyed = false;

    [SerializeField] private float targetingRange = 3f;
    [SerializeField] public float initialAttackSpeed = 1f;
    public float attackSpeed;

    private Transform target;
    private float timeUntilFire;

    private void Start()
    {
        enemyHP = initialEnemyHP;
        attackSpeed = initialAttackSpeed;
      
    }
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

        // Calculate the direction towards the player
        Vector2 directionToPlayer = target.transform.position - firingPoint.position;

        // Set the target and initial direction for the EnemyProjectiles
        EnemyProjectiles projectilesScript = projectilesObj.GetComponent<EnemyProjectiles>();
        projectilesScript.SetInitialDirection(directionToPlayer);
    }

    private bool inRange()
    {
        return Vector2.Distance(target.position, transform.position) <= targetingRange;
    }

    private void FindTarget()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, targetingRange, (Vector2)transform.position, 0f, playerMask);
        if (hits.Length > 0)
        {
            target = hits[0].transform;
        }
    }
    
    public void TakeDamage(int damage)
    {
        enemyHP -= damage;
        if (enemyHP <= 0 && !isDestroyed)
        {
            Spawner.onEnemyDestroy.Invoke();
            isDestroyed = true;
            Destroy(gameObject);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Handles.color = Color.cyan;
        Handles.DrawWireDisc(transform.position, transform.forward, targetingRange);
    }
}

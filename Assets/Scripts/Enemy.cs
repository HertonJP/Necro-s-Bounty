using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private LayerMask playerMask;
    [SerializeField] private GameObject projectilesPrefab;
    [SerializeField] private Transform firingPoint;
    [SerializeField] public int initialEnemyHP = 20;
    public int enemyHP;
    private bool isDestroyed = false;
    private bool isDead = false;

    [SerializeField] private float targetingRange = 3f;
    [SerializeField] public float initialAttackSpeed = 1f;
    public float attackSpeed;

    [SerializeField] private Sprite corpseSprite;
    private SpriteRenderer spriteRenderer;

    private Transform target;
    private float timeUntilFire;

    private void Start()
    {
        enemyHP = initialEnemyHP;
        attackSpeed = initialAttackSpeed;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (isDead)
            return;

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

        Vector2 directionToPlayer = target.transform.position - firingPoint.position;

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
        if (isDead)
            return;

        enemyHP -= damage;
        if (enemyHP <= 0 && !isDestroyed)
        {
            isDestroyed = true;
            StopAttackingAndFollowing();
            StartCoroutine(DestroyAfterDelay());
        }
    }

    private void StopAttackingAndFollowing()
    {
        isDead = true;
        target = null;

        AI aiComponent = GetComponent<AI>();
        if (aiComponent != null)
        {
            aiComponent.enabled = false;
        }

        spriteRenderer.sprite = corpseSprite;

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = Vector2.zero;
            rb.bodyType = RigidbodyType2D.Static;
        }
        gameObject.layer = LayerMask.NameToLayer("Corpse");
    }

    private IEnumerator DestroyAfterDelay()
    {
        yield return new WaitForSeconds(1f);
        gameObject.tag = "Corpse";
        yield return new WaitForSeconds(20f);
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, targetingRange);
    }
}
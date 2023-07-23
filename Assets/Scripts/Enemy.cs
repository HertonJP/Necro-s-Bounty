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
    private Animator animator;

    [SerializeField] private float targetingRange = 3f;
    [SerializeField] public float initialAttackSpeed = 1f;
    public float attackSpeed;

    [SerializeField] private Sprite corpseSprite;
    private SpriteRenderer spriteRenderer;

    private Transform target;
    private float timeUntilFire;

    private void Start()
    {
        animator = GetComponent<Animator>();
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
        float distanceToTarget = Vector2.Distance(target.position, transform.position);
        animator.SetBool("inRange", distanceToTarget <= targetingRange);

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
            animator.SetTrigger("isAttack");
            timeUntilFire = 0f;
        }
    }

    public void Attack()
    {
        if (target == null)
        {
            return;
        }
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
            animator.enabled = false;
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
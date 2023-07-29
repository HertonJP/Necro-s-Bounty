using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkill : MonoBehaviour
{
    public bool isInvincible = false;
    private PlayerAttributes playerAttributes;
    private SpriteRenderer playerSpriteRenderer;
    private LayerMask enemyLayer;
    private int originalLayer;

    private void Start()
    {
        playerAttributes = GetComponent<PlayerAttributes>();
        playerSpriteRenderer = GetComponent<SpriteRenderer>();
        enemyLayer = LayerMask.GetMask("Enemy");
        originalLayer = gameObject.layer;
    }

    private void Update()
    {
        if (!Time.timeScale.Equals(0f))
        {
            if (Input.GetMouseButtonDown(1) && !isInvincible && playerAttributes.playerHP >= 30)
            {
                StartCoroutine(ActivateSkill());
            }
        }
            
    }

    private IEnumerator ActivateSkill()
    {
        isInvincible = true;
        Physics2D.IgnoreLayerCollision(gameObject.layer, LayerMask.NameToLayer("Enemy"), true);
        playerAttributes.playerHP -= 30;
        playerSpriteRenderer.color = new Color(1f, 1f, 1f, 0.5f);
        yield return new WaitForSeconds(3f);
        playerSpriteRenderer.color = Color.white;
        Physics2D.IgnoreLayerCollision(gameObject.layer, LayerMask.NameToLayer("Enemy"), false);
        isInvincible = false;
    }

    public bool IsInvincible()
    {
        return isInvincible;
    }
}
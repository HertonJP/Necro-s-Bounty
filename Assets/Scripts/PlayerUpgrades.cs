using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerUpgrades : MonoBehaviour
{
    [SerializeField] private PlayerShooting playerShooting;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private PlayerAttributes playerAttributes;
    [SerializeField] private Projectiles projectiles;

    public TextMeshProUGUI attackUpgradeText;
    public TextMeshProUGUI movementSpeedUpgradeText;
    public TextMeshProUGUI attackUpgradeCostText;
    public TextMeshProUGUI movementSpeedUpgradeCostText;


    private int attackUpgradeLevel = 0;
    private int movementSpeedUpgradeLevel = 0;

    private int attackUpgradeCost = 150;
    private int movementSpeedUpgradeCost = 150;

    private void Start()
    {
        UpdateUpgradeTexts();
    }

    public void UpgradeAttack()
    {
        if (CanAffordUpgrade(attackUpgradeCost))
        {
            projectiles.projectilesDamage++;
            playerAttributes.playerHP -= attackUpgradeCost;
            attackUpgradeLevel++;
            attackUpgradeCost += 50;
            UpdateUpgradeTexts();
        }
    }

    public void UpgradeMovementSpeed()
    {
        if (CanAffordUpgrade(movementSpeedUpgradeCost))
        {
            playerMovement.movementSpeed += 0.5f;
            playerAttributes.playerHP -= movementSpeedUpgradeCost;
            movementSpeedUpgradeLevel++;
            movementSpeedUpgradeCost += 50;
            UpdateUpgradeTexts();
        }
    }

    

    private bool CanAffordUpgrade(int upgradeCost)
    {
        return playerAttributes.playerHP >= upgradeCost;
    }

    private void UpdateUpgradeTexts()
    {
        attackUpgradeText.text = "Level " + attackUpgradeLevel;
        attackUpgradeCostText.text = " " + attackUpgradeCost;
        movementSpeedUpgradeText.text = "Level " + movementSpeedUpgradeLevel;
        movementSpeedUpgradeCostText.text = " " + movementSpeedUpgradeCost;
    }
}
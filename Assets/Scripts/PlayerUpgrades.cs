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
    public TextMeshProUGUI projectilesUpgradeText;
    public TextMeshProUGUI attackUpgradeCostText;
    public TextMeshProUGUI movementSpeedUpgradeCostText;
    public TextMeshProUGUI projectilesUpgradeCostText;



    private int attackUpgradeLevel = 0;
    private int movementSpeedUpgradeLevel = 0;
    private int projectilesUpgradeLevel = 0;

    private int attackUpgradeCost = 100;
    private int movementSpeedUpgradeCost = 100;
    private int projectilesUpgradeCost = 200;
    

    private void Start()
    {
        UpdateUpgradeTexts();
    }

    public void UpgradeAttack()
    {
        if (CanAffordUpgrade(attackUpgradeCost))
        {
            projectiles.projectilesDamage += 2;
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

    public void UpgradeProjectiles()
    {
        if(projectilesUpgradeLevel <= 4 && CanAffordUpgrade(projectilesUpgradeCost))
        {
            playerShooting.fire1Cooldown -= 0.1f;
            playerAttributes.playerHP -= projectilesUpgradeCost;
            projectilesUpgradeLevel++;
            projectilesUpgradeCost += 100;
            UpdateUpgradeTexts();
        }
        else
        {
            projectilesUpgradeText.text = "MAX";
            projectilesUpgradeCostText.text = "0";
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
        projectilesUpgradeText.text = "Level " + projectilesUpgradeLevel;
        projectilesUpgradeCostText.text = " " + projectilesUpgradeCost;
    }
}
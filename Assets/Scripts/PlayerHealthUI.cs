using UnityEngine;
using TMPro;

public class PlayerHealthUI : MonoBehaviour
{
    [SerializeField] private PlayerAttributes playerAttributes;
    private TextMeshProUGUI healthText;

    private void Start()
    {
        healthText = GameObject.Find("HP Value Text").GetComponent<TextMeshProUGUI>();

        if (healthText == null)
        {
            Debug.LogError("TextMeshProUGUI component not found! Make sure the name matches.");
        }

        if (playerAttributes == null)
        {
            Debug.LogError("PlayerAttributes reference not set on PlayerHealthUI script!");
        }
    }

    private void Update()
    {
        healthText.text = "Blood: " + playerAttributes.playerHP.ToString();
    }
}
using UnityEngine;

public class AuraRangeIndicator : MonoBehaviour
{
    [SerializeField] private PlayerAttributes playerAttributes;
    private PolygonCollider2D polygonCollider;

    private void Start()
    {
        polygonCollider = GetComponent<PolygonCollider2D>();
        if (polygonCollider == null)
        {
            Debug.LogError("PolygonCollider2D component not found on AuraRangeDetector script!");
        }
        if (playerAttributes == null)
        {
            Debug.LogError("PlayerAttributes reference not set on AuraRangeDetector script!");
        }
    }

    private void Update()
    {
        Collider2D[] results = new Collider2D[10];

        int numColliders = polygonCollider.OverlapCollider(new ContactFilter2D().NoFilter(), results);

        for (int i = 0; i < numColliders; i++)
        {
            Collider2D collider = results[i];
            if (collider.CompareTag("Corpse"))
            {
                playerAttributes.playerHP += 10;
                Destroy(collider.gameObject);
            }
        }
    }
}
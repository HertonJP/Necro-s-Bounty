using UnityEngine;

public class AI : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private Rigidbody2D rb;

    private Transform target; // Reference to the player's Transform

    private void Start()
    {
        // Find the player's GameObject using a tag (assuming the player has a "Player" tag)
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        // Get the player's Transform component
        if (player != null)
        {
            target = player.transform;
        }
        else
        {
            Debug.LogError("Player not found! Make sure the player has a 'Player' tag.");
        }
    }

    private void FixedUpdate()
    {
        if (target != null)
        {
            Vector2 direction = (target.position - transform.position).normalized;
            rb.velocity = direction * speed;
        }
    }
}
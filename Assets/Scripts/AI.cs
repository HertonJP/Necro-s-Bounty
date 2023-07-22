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
            // Calculate the direction vector from AI to the target
            Vector2 direction = (target.position - transform.position).normalized;

            // Move the AI towards the target
            rb.velocity = direction * speed;

            // Flip the AI based on the target's direction
            if (direction.x > 0 && !IsFacingRight())
            {
                Flip();
            }
            else if (direction.x < 0 && IsFacingRight())
            {
                Flip();
            }
        }
    }

    private bool IsFacingRight()
    {
        return transform.localScale.x > 0;
    }

    private void Flip()
    {
        Vector3 newScale = transform.localScale;
        newScale.x *= -1;
        transform.localScale = newScale;
    }
}
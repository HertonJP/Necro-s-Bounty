using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject projectilesPrefab;
    public Transform firingPoint;

    public float shootingSpeed = 10f;

    private void Update()
    {
       
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f; 

        
        Vector2 shootingDirection = (mousePosition - firingPoint.position).normalized;

        
        GameObject projectile = Instantiate(projectilesPrefab, firingPoint.position, Quaternion.identity);

        
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();

        
        rb.velocity = shootingDirection * shootingSpeed;

        
    }
}
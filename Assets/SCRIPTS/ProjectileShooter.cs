using UnityEngine;

public class ProjectileShooter : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float projectileSpeed = 10f;
    public float fireRate = 0.5f;
    public float projectileLifetime = 5f; // Lifetime of the projectile in seconds
    private float nextFireTime = 0f;

    void Update()
    {
        // Check if the screen is touched
        if (Input.GetMouseButtonDown(0) && Time.time > nextFireTime)
        {
            // Set the shoot direction to be upward along the Y-axis
            Vector2 shootDirection = Vector2.up;

            // Instantiate a new projectile
            GameObject newProjectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

            // Access the Rigidbody2D component of the projectile
            Rigidbody2D projectileRigidbody = newProjectile.GetComponent<Rigidbody2D>();

            // Set the velocity of the projectile based on the shoot direction and speed
            projectileRigidbody.velocity = shootDirection * projectileSpeed;

            // Destroy the projectile after a certain lifetime
            Destroy(newProjectile, projectileLifetime);

            // Set the next fire time
            nextFireTime = Time.time + fireRate;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("ENEMIES"))
        {
            // Destroy the enemy and the projectile
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}

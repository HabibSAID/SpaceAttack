using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 1;
    public int scoreValue = 10;
    public GameObject explosionPrefab;
    public float lifespan = 10f; // Set the lifespan for the enemy in seconds

    private float timeSinceSpawn;

    private void Start()
    {
        // Record the time when the enemy is spawned
        timeSinceSpawn = Time.time;
    }

    void Update()
    {
        // Check if the enemy has exceeded its lifespan
        if (Time.time - timeSinceSpawn > lifespan)
        {
            Destroy(gameObject);
            return; // Exit the update function to avoid further processing
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PROJECTILE"))
        {
            health--;

            if (health <= 0)
            {
                GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);

                ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
                if (scoreManager != null)
                {
                    scoreManager.AddScore(scoreValue);
                }

                Destroy(gameObject);
            }

            Destroy(other.gameObject);
        }
    }
}

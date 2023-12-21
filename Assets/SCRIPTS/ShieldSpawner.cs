using UnityEngine;

public class ShieldSpawner : MonoBehaviour
{
    public GameObject ShieldPrefab;     // The shield prefab to spawn
    public float spawnRate = 60f;       // Time interval between shield spawns (changed to 60 seconds)
    public float minXSpawn = -5f;       // Minimum X-axis position for shield spawn
    public float maxXSpawn = 5f;        // Maximum X-axis position for shield spawn
    public float delayTime = 180f;      // Delay time before the first shield spawn (3 minutes)

    private float nextSpawnTime = 0f;   // Time when the next shield will spawn

    void Update()
    {
        // Check if it's time to spawn a shield and if the delay time has passed
        if (Time.time > nextSpawnTime && Time.timeSinceLevelLoad > delayTime)
        {
            // Generate a random X-axis position within the specified range
            float spawnXPosition = Random.Range(minXSpawn, maxXSpawn);

            // Create a Vector2 position for the shield spawn
            Vector2 spawnPosition = new Vector2(spawnXPosition, transform.position.y);

            // Instantiate the shield prefab at the specified position
            Instantiate(ShieldPrefab, spawnPosition, Quaternion.identity);

            // Update the next spawn time to be 60 seconds from now
            nextSpawnTime = Time.time + spawnRate;
        }
    }
}

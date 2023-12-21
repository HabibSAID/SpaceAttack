using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnRate = 2f;
    public float minXSpawn = -5f;
    public float maxXSpawn = 5f;
    public float delayTime = 180f; // 3 minutes

    private float nextSpawnTime = 0f;

    void Update()
    {
        if (Time.time > nextSpawnTime && Time.timeSinceLevelLoad > delayTime)
        {
            float spawnXPosition = Random.Range(minXSpawn, maxXSpawn);
            Vector2 spawnPosition = new Vector2(spawnXPosition, transform.position.y);

            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

            nextSpawnTime = Time.time + spawnRate;
        }
    }
}

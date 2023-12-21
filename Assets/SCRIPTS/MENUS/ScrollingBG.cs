using UnityEngine;

public class ScrollingBG : MonoBehaviour
{
    public float scrollSpeed = 2.0f;
    public float respawnPosition = -20f;

    // Get the starting position of the background
    private Vector2 startingPosition;

    private void Start()
    {
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Get the current position of the background
        Vector2 position = transform.position;

        // Calculate the new position of the background
        position.y -= scrollSpeed * Time.deltaTime;

        // Set the new position of the background
        transform.position = position;

        // Check if the background has gone off screen
        if (transform.position.y < respawnPosition)
        {
            // Move the background back up to its starting position
            transform.position = startingPosition;
        }
    }

    public void SetScrollSpeed(float speed)
    {
        scrollSpeed = speed;
    }
}

using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float tiltSpeed = 5f;  // Adjust the tilt speed as needed
    public float minX = -5f;      // Minimum X position
    public float maxX = 5f;       // Maximum X position
    public GameObject explosionPrefab;  // Prefab to instantiate on player destruction
    public GameObject shieldPrefab;     // Prefab for the shield power-up
    public GameObject shieldHalo;       // Shield halo decoration
    public float invincibilityDuration = 15f;  // Duration of invincibility in seconds
    public AudioClip shieldPickupSound;    // Sound effect when shield is picked up
    public Slider invincibilitySlider;     // Reference to the invincibility timer slider

    private bool isInvincible = false;
    private float invincibilityTimer = 0f;
    private AudioSource audioSource;

    void Start()
    {
        // Make sure the shield halo is initially disabled
        if (shieldHalo != null)
        {
            shieldHalo.SetActive(false);
        }

        // Get the AudioSource component or add one if not present
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Set the initial value of the slider
        if (invincibilitySlider != null)
        {
            invincibilitySlider.value = 1f;
            invincibilitySlider.gameObject.SetActive(false); // Initially hide the slider
        }
    }

    void Update()
    {
        // Check and update invincibility status
        if (isInvincible)
        {
            invincibilityTimer -= Time.deltaTime;

            // Update the slider value based on the remaining invincibility time
            if (invincibilitySlider != null)
            {
                invincibilitySlider.value = invincibilityTimer / invincibilityDuration;
            }

            if (invincibilityTimer <= 0f)
            {
                // Invincibility timer is over, return to normal state
                isInvincible = false;

                // Re-enable collisions with enemies
                EnableEnemyCollisions();

                // Disable shield halo decoration
                if (shieldHalo != null)
                {
                    shieldHalo.SetActive(false);
                }

                // Hide the slider
                if (invincibilitySlider != null)
                {
                    invincibilitySlider.gameObject.SetActive(false);
                }
            }
        }

        // Get tilt input from device
        float tiltInput = Input.acceleration.x;

        // Calculate movement based on tilt input
        Vector3 tiltMovement = new Vector3(tiltInput, 0f, 0f);

        // Update player position based on tilt input
        transform.position += tiltMovement * tiltSpeed * Time.deltaTime;

        // Clamp player's X position between minX and maxX
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minX, maxX), transform.position.y, transform.position.z);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the player collides with a shield power-up
        if (other.CompareTag("SHIELD"))
        {
            // Activate shield power-up
            ActivateShield();

            // Play shield pickup sound
            if (audioSource != null && shieldPickupSound != null)
            {
                audioSource.PlayOneShot(shieldPickupSound);
            }

            // Destroy the shield power-up
            Destroy(other.gameObject);
        }

        // Check if the player collides with an object tagged as "ENEMIES"
        if (other.CompareTag("ENEMIES"))
        {
            // Check if the player is invincible
            if (!isInvincible)
            {
                // Player is not invincible, handle collision normally

                // Instantiate explosion prefab at player's position
                Instantiate(explosionPrefab, transform.position, Quaternion.identity);

                // Destroy the player
                Destroy(gameObject);

                // Destroy the enemy
                Destroy(other.gameObject);
            }
            else
            {
                // Player is invincible, ignore the collision
            }
        }
    }

    void ActivateShield()
    {
        // Activate invincibility
        isInvincible = true;

        // Set the invincibility timer
        invincibilityTimer = invincibilityDuration;

        // Disable collisions with enemies during the invincibility period
        DisableEnemyCollisions();

        // Enable shield halo decoration
        if (shieldHalo != null)
        {
            shieldHalo.SetActive(true);
        }

        // Show the slider
        if (invincibilitySlider != null)
        {
            invincibilitySlider.gameObject.SetActive(true);
        }
    }

    void DisableEnemyCollisions()
    {
        // Ignore collisions between the player and enemies layers
        Physics2D.IgnoreLayerCollision(gameObject.layer, LayerMask.NameToLayer("Enemy"), true);
    }

    void EnableEnemyCollisions()
    {
        // Enable collisions between the player and enemies layers
        Physics2D.IgnoreLayerCollision(gameObject.layer, LayerMask.NameToLayer("Enemy"), false);
    }
}
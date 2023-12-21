using UnityEngine;

public class SimpleCharacterController : MonoBehaviour
{
    public float speed = 5f; // Adjust this value to control the movement speed.

    void Update()
    {
        // Get the horizontal input (left and right arrow keys, A and D keys, or joystick)
        float horizontalInput = Input.GetAxis("Horizontal");

        // Calculate the movement vector
        Vector3 movement = new Vector3(horizontalInput, 0f, 0f) * speed * Time.deltaTime;

        // Move the character
        transform.Translate(movement);
    }
}

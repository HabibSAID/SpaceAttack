using UnityEngine;

public class RotateShield : MonoBehaviour
{

    public float movementSpeed = 3f;

    void Update()
    {

        transform.Rotate(0, movementSpeed, 0);
    }
}

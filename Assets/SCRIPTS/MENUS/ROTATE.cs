using UnityEngine;
using System.Collections;
using static LeanTween;

public class ROTATE : MonoBehaviour
{
     public Transform backgroundTransform;
    public float rotationSpeed = 90f;

    private void Start()
    {
        StartTween();
    }

    private void StartTween()
    {
        // Rotate the background continuously around the Z-axis
        rotateAround(backgroundTransform.gameObject, Vector3.forward, 360f, rotationSpeed)
            .setEase(LeanTweenType.linear)
            .setLoopClamp();
    }
}

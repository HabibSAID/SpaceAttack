using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using static LeanTween;

public class UIMoveExample : MonoBehaviour
{
    public RectTransform targetRectTransform;
    public Vector2 targetPosition;
    public float duration = 1f;

    private void Start()
    {
        // Start the tween when the script is initialized or as desired
        StartTween();
    }

    private void StartTween()
    {
        // Tween the position of the RectTransform
        move(targetRectTransform, targetPosition, duration)
            .setEase(LeanTweenType.easeOutQuad);
            
    }

}

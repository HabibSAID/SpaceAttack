using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using static LeanTween;

public class UIScale : MonoBehaviour
{
    public RectTransform targetRectTransform;
    public Vector3 targetScale;
    public Vector2 targetSizeDelta;
    public float duration = 1f;

    private void Start()
    {
        StartTween();
    }

    private void StartTween()
    {
        // Store the initial scale of the RectTransform
        Vector3 initialScale = targetRectTransform.localScale;

        // Set the initial scale to zero
        targetRectTransform.localScale = Vector3.zero;

        // Store the initial sizeDelta of the RectTransform
        Vector2 initialSizeDelta = targetRectTransform.sizeDelta;

        // Set the initial sizeDelta to zero
        targetRectTransform.sizeDelta = Vector2.zero;

        // Tween the scale of the RectTransform to the target scale without a bounce effect
        scale(targetRectTransform, targetScale, duration)
            .setEase(LeanTweenType.easeOutQuad); // Change the easing type to easeOutQuad for a smooth scaling effect

        // Tween the sizeDelta of the RectTransform to the target sizeDelta without a bounce effect
        size(targetRectTransform, targetSizeDelta, duration)
            .setEase(LeanTweenType.easeOutQuad) // Change the easing type to easeOutQuad for a smooth scaling effect
            .setOnComplete(TweenComplete);
    }

    private void TweenComplete()
    {
        Debug.Log("Tween complete!");
    }
}

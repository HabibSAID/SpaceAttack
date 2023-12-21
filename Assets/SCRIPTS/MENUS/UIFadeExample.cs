using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using static LeanTween;

public class UIFadeExample : MonoBehaviour
{
    public Graphic targetElement; // Change the type to the appropriate UI element type
    public float targetAlpha;
    public float duration = 1f;

    private void Start()
    {
        StartTween();
    }

    private void StartTween()
    {
        // Tween the alpha value of the UI element
        alpha(targetElement.rectTransform, targetAlpha, duration)
            .setEase(LeanTweenType.easeInOutSine)
            .setOnComplete(TweenComplete);
    }

    private void TweenComplete()
    {
        Debug.Log("Tween complete!");
    }
}

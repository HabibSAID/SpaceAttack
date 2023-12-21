using UnityEngine;
using UnityEngine.UI;

public class OutlineGlow : MonoBehaviour
{
    public float fadeDuration = 1f;   // Time it takes for the outline to fade in/out
    public float minAlpha = 0f;       // Minimum alpha value when faded out
    public float maxAlpha = 1f;       // Maximum alpha value when faded in

    private Outline outline;
    private float currentAlpha = 1f;
    private bool isFadingOut = false;

    private void Start()
    {
        // Get the Outline component attached to the same GameObject
        outline = GetComponent<Outline>();
    }

    private void Update()
    {
        // Calculate the new alpha value
        if (isFadingOut)
            currentAlpha -= Time.deltaTime / fadeDuration;
        else
            currentAlpha += Time.deltaTime / fadeDuration;

        // Switch fade direction if alpha reaches the limits
        if (currentAlpha <= minAlpha)
        {
            currentAlpha = minAlpha;
            isFadingOut = false;
        }
        else if (currentAlpha >= maxAlpha)
        {
            currentAlpha = maxAlpha;
            isFadingOut = true;
        }

        // Apply the new alpha value to the outline component
        outline.effectColor = new Color(outline.effectColor.r, outline.effectColor.g, outline.effectColor.b, currentAlpha);
    }
}

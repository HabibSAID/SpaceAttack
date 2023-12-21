using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ImageOpacityChanger : MonoBehaviour
{
    public float delay = 1f;    // Delay before starting the fade-in effect
    public float duration = 1f; // Duration of the fade-in effect
    public Image image;         // Reference to the Image component

    IEnumerator Start()
    {
        yield return new WaitForSeconds(delay);

        Color startColor = image.color;
        Color endColor = new Color(startColor.r, startColor.g, startColor.b, 1f);

        float elapsedTime = 0f;
        while (elapsedTime < duration)
        {
            float alpha = Mathf.Lerp(0f, 1f, elapsedTime / duration);
            image.color = Color.Lerp(startColor, endColor, alpha);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        image.color = endColor; // Ensure the final color is set
    }
}

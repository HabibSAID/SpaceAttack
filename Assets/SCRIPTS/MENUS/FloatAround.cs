using UnityEngine;

public class FloatAround : MonoBehaviour
{
    public float floatSpeed = 2f;

    private RectTransform rectTransform;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        // Float the image around
        FloatImage();
    }

    void FloatImage()
    {
        Vector2 newPosition = rectTransform.anchoredPosition;

        // Update the position based on a simple floating behavior
        newPosition.x += Mathf.Sin(Time.time * floatSpeed) * Time.deltaTime * 50f;
        newPosition.y += Mathf.Cos(Time.time * floatSpeed) * Time.deltaTime * 50f;

        rectTransform.anchoredPosition = newPosition;
    }
}

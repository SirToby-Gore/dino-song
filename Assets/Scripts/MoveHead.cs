using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed = 100f;
    public Vector2 direction = Vector2.right;

    private RectTransform rectTransform;
    private bool isMoving = false;

    // Original start position
    private Vector2 originalPosition;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();

        // Save the original position at the very start
        originalPosition = rectTransform.anchoredPosition;
    }

    void Update()
    {
        if (isMoving)
        {
            rectTransform.anchoredPosition += direction * speed * Time.deltaTime;
        }
    }

    // Call this when the Go button is pressed
    public void StartMoving()
    {
        // Reset to original start position every time
        rectTransform.anchoredPosition = originalPosition;

        // Begin moving
        isMoving = true;
    }

    public void StopMoving()
    {
        isMoving = false;
    }
}
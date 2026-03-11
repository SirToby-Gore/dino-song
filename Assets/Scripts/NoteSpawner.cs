using UnityEngine;
using System.Collections;

public class NoteGrabber : MonoBehaviour
{
    public Vector2 originalScale;
    public float scalarValue;
    public bool isBeingDragged;
    void Start() // Runs once at the start of the program.
    {
        originalScale = new Vector2(transform.localScale.x, transform.localScale.y);
        scalarValue = 1.25f;
        isBeingDragged = false;
    }

    void Update() // Runs repeatedly throughout each frame of the program.
    {
        
    }

    void OnMouseOver() // Called when the mouse hovers over the object. In this case, over a note.
    {
        transform.localScale =  originalScale * scalarValue;
    }

    void OnMouseDown()
    {
        isBeingDragged = true;
    }

    void OnMouseDrag()
    {
        float dragMousePosX = Input.mousePosition.x;
        float dragMousePosY = Input.mousePosition.y;
        Vector3 currentPosition = new Vector3(dragMousePosX, dragMousePosY, -0.01f);
        transform.position = currentPosition;
    }

    void OnMouseUp()
    {
        isBeingDragged = false;
    }

    void OnMouseExit() // Called when the mouse stops hovering over an object.
    {
        transform.localScale = originalScale;
    }
}

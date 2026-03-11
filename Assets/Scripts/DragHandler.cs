using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class DragHandler: MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Canvas canvas;

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private void Awake() 
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag (PointerEventData eventData) 
    {
        Debug.Log("Drag Initiated.");
        canvasGroup.blocksRaycasts = false;
        canvasGroup.alpha = .6f;
    }

    public void OnDrag(PointerEventData eventData) 
    {
        Debug.Log("Dragging...");
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag (PointerEventData eventData) 
    {
        Debug.Log("Drag Ended!");
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1f;
    }

    public void OnPointerDown(PointerEventData eventData) 
    {
        Debug.Log("Pointer Down!");
    }
}

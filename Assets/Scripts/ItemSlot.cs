using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    private Transform objPositionWorld;
    private void Awake()
    {
        objPositionWorld = gameObject.transform.position;
    }

    public void OnDrop(PointerEventData eventData) 
    {
        Debug.Log("Dropped!");
        if (eventData.pointerDrag != null) 
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
        }
    }
}

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragAndDropNotes : MonoBehaviour,
    IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerClickHandler
{
    public GameObject dragPrefab;

    public bool isOriginal = true;

    private GameObject dragInstance;
    private RectTransform dragRect;
    private Canvas canvas;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        canvas = GetComponentInParent<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        dragInstance = Instantiate(dragPrefab, canvas.transform);
        dragRect = dragInstance.GetComponent<RectTransform>();

        dragInstance.GetComponent<Image>().sprite =
            GetComponent<Image>().sprite;

        // mark the new object as NOT original
        DragAndDropNotes newScript = dragInstance.GetComponent<DragAndDropNotes>();
        newScript.isOriginal = false;

        UpdatePosition(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        UpdatePosition(eventData);
    }

    void UpdatePosition(PointerEventData eventData)
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvas.transform as RectTransform,
            eventData.position,
            canvas.worldCamera,
            out Vector2 pos);

        dragRect.localPosition = pos;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!isOriginal && eventData.clickCount == 2)
        {
            Destroy(gameObject);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        dragInstance = null;
    }
}
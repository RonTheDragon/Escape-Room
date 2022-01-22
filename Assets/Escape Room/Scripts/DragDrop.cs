using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
{
    InventorySystem IS;
    Canvas canvas;
    RectTransform rectTransform;
    CanvasGroup canvasGroup;
    [HideInInspector]
    public RectTransform InSlot;
    [HideInInspector]
    public string Name;

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = false;
        canvasGroup.alpha = .6f;
        IS.Using = Name;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1;
        rectTransform.anchoredPosition = InSlot.anchoredPosition;
        StartCoroutine(RemoveFromUsing());
    }

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }
    // Start is called before the first frame update
    void Start()
    {
        canvas = transform.parent.GetComponent<Canvas>();
        IS = Camera.main.gameObject.GetComponent<InventorySystem>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            if (InSlot != null)
            {
                InSlot.GetComponent<ItemSlot>().OnDrop(eventData);
            }
        }
    }

    IEnumerator RemoveFromUsing()
    {
        yield return null; 
        IS.Using = string.Empty;
    }
}

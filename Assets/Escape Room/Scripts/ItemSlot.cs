using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour , IDropHandler
{
    public RectTransform HeldItem;

    public void OnDrop(PointerEventData eventData)
    {
       if (eventData.pointerDrag != null)
        {
           
            if (HeldItem!= eventData.pointerDrag.GetComponent<RectTransform>()) //if held item isnt what already held
            {
                DragDrop DD = eventData.pointerDrag.GetComponent<DragDrop>(); //gets Item
                if (DD.InSlot != null)
                {
                    if (HeldItem == null)
                    {
                        DD.InSlot.GetComponent<ItemSlot>().HeldItem = null; //makes Item Original slot empty
                    }
                    else
                    {
                        DD.InSlot.GetComponent<ItemSlot>().HeldItem = HeldItem; //makes the Item Original slot be filled with my old item
                        HeldItem.GetComponent<DragDrop>().InSlot = DD.InSlot.GetComponent<RectTransform>(); // makes my old item replace owner 
                        HeldItem.GetComponent<RectTransform>().anchoredPosition = DD.InSlot.GetComponent<RectTransform>().anchoredPosition;
                    }
                }
                DD.InSlot = GetComponent<RectTransform>(); //Telling The Item I hold it
                HeldItem = eventData.pointerDrag.GetComponent<RectTransform>(); //Telling myself what I hold
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

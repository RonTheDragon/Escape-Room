using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    public ItemSlot[] InventorySlots;
    public string Using;
    public GameObject AnItem;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddToInventory(Item i)
    {
        foreach(ItemSlot s in InventorySlots)
        {
            if (s.HeldItem == null)
            {
                DragDrop dd = Instantiate(AnItem, s.transform.position, s.transform.rotation, s.transform.parent).GetComponent<DragDrop>();
                dd.Name = i.TheName;
                dd.InSlot = s.GetComponent<RectTransform>();
                s.HeldItem = dd.GetComponent<RectTransform>();
                dd.GetComponent<RectTransform>().anchoredPosition = s.GetComponent<RectTransform>().anchoredPosition;
                break;
            }
        }
        Debug.Log($"{i.TheName} Was Added To The Inventory");
    }

    public void RemoveFromInventory(string Name)
    {
        
        foreach (ItemSlot s in InventorySlots)
        {
            if (s.HeldItem != null)
            {
               if ( s.HeldItem.GetComponent<DragDrop>().Name==Name)
                {
                    Debug.Log($"{Name} Was Removed From The Inventory");
                    Destroy(s.HeldItem.gameObject);
                    s.HeldItem = null;
                    return;
                }
            }
        }
                Debug.LogWarning($"{Name} Cant Be Found In Inventory");
    }

    public bool CheckIfInInventory(string Name)
    {
        
        foreach (ItemSlot s in InventorySlots)
        {
            if (s.HeldItem != null)
            {
                if (s.HeldItem.GetComponent<DragDrop>().Name == Name)
                {
                    return true;
                }
            }
        }
        Debug.Log("You Dont Have The Correct Item To Use This");
        return false;
    }

    public bool CheckIfUsing(string Name)
    {
        if (Name == Using) return true;
        else return false;
    }
}
public interface Item
{
    string TheName { get; set; }
    Sprite sprite { get; set; }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    public List<Item> Items = new List<Item>();
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
        Items.Add(i);
        Debug.Log($"{i.TheName} Was Added To The Inventory");
    }

    public void RemoveFromInventory(string Name)
    {
        foreach (Item i in Items)
        {
            if (i.TheName == Name)
            {
                Debug.Log($"{i.TheName} Was Removed From The Inventory");
                Items.Remove(i);
                return;
            }
        }       
        Debug.LogWarning($"{Name} Cant Be Found In Inventory");
    }

    public bool CheckIfInInventory(string Name)
    {
        foreach(Item i in Items)
        {
            if (i.TheName == Name)
            {
                return true;
            }
        }
        Debug.Log("You Dont Have The Correct Item To Use This");
        return false;
    }
}
public interface Item
{
    string TheName { get; set; }
}

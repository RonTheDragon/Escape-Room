using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glass : Intractable
{
    InventorySystem IS;
    public bool isDestroy;
    public override void Use()
    {
        if(IS.CheckIfUsing("Hammer"))
        {
            if(isDestroy)
            {
                IS.RemoveFromInventory("Hammer");
            }
            Destroy(gameObject);
        }
    }

    void Start()
    {
        IS = Camera.main.gameObject.GetComponent<InventorySystem>();
    }

    
    void Update()
    {
        
    }

    
}

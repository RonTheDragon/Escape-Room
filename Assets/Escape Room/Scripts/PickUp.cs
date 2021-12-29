using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : Intractable , Item
{
    InventorySystem IS;
    public string TheName { get; set; }
    public string Name = "Key";

    // Start is called before the first frame update
    void Start()
    {
        IS = Camera.main.gameObject.GetComponent<InventorySystem>();

        if (Name == string.Empty)
            TheName = "Key";
        else TheName = Name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Use()
    {
        IS.AddToInventory(this);
        Destroy(gameObject);
    }
}

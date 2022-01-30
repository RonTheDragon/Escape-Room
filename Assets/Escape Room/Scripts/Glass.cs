using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glass : Intractable
{
    InventorySystem IS;
    public bool isDestroy;
    AudioManager audio;

    void Start()
    {
        audio = GetComponent<AudioManager>();
        IS = Camera.main.gameObject.GetComponent<InventorySystem>();
    }


    void Update()
    {

    }
    public override void Use()
    {

        if(IS.CheckIfUsing("Hammer"))
        {
            audio.PlaySound(Sound.Activation.Custom, "Break");
            if(isDestroy)
            {
                IS.RemoveFromInventory("Hammer");
                
            }
            Destroy(gameObject);
        }
    }



    
}

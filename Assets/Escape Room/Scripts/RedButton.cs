using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedButton : Intractable
{
    public GameObject lasers;
    public override void Use()
    {
        MapManagement.LasersOff = true;
        Destroy(lasers);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

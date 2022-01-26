using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bricks : Intractable
{
    public char value;
    public override void Use()
    {
        Debug.Log(value);
        transform.parent.GetComponent<BricksManager>().BrickPressed(value);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

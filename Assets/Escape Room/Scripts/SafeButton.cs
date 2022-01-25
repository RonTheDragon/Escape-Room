using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeButton : Intractable
{
    TheSafe Safe;
    public char Value;

    public override void Use()
    {
        Safe.ButtonPressed(Value);
    }

    // Start is called before the first frame update
    void Start()
    {
        Safe = transform.parent.parent.GetComponent<TheSafe>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

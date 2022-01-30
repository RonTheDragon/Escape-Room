using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : Intractable
{
    public GameObject youWin;
    public override void Use()
    {
        youWin.SetActive(true);
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

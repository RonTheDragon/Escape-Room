using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Openable : Intractable
{
    bool open;
    Animator Anim;
    AudioManager audio;
   // public GameObject[] Contant;

    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();
        ShowContact(false);
        audio = GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Use()
    {
        open = !open;
        audio.PlaySound(Sound.Activation.Custom, "Open");
        if (open)
        {          
            Debug.Log("Cabinet Opened");
            
            ShowContact(true);
        }
        else
        {
            Debug.Log("Cabinet Closed");
            ShowContact(false);
        }
    }

    void ShowContact(bool Show)
    {
        Anim.SetBool("Open", Show);
        /*
        foreach (GameObject g in Contant)
        {
            g.SetActive(Show);
        }*/
    }
}

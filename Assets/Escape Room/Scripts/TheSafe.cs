using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TheSafe : MonoBehaviour
{

    public Text text;
    public string Code;
    Animator anim;
    char[] N = new char[4];
    bool Open;
    int slot;

    // Start is called before the first frame update
    void Start()
    {
        WrongCode();
        anim = GetComponent<Animator>();
        text.text = GetCode();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonPressed(char Num)
    {
        if (!Open)
        {
            N[slot] = Num;
            slot++;
            if (slot > 3) CheckCode();           
            text.text = GetCode();
            
        }
    }

    void CheckCode()
    {
        if (Code == GetCode())
        {
            Open = true;
            anim.SetBool("Open",true);
        }
        else WrongCode();
    }

    void WrongCode()
    {
        slot = 0;
        for (int i = 0; i < N.Length; i++)
        {
            N[i] = 'X';
        }
    }

    string GetCode()
    {
        return $"{N[0]}{N[1]}{N[2]}{N[3]}";
    }
}

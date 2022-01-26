using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BricksManager : MonoBehaviour
{
    char[] N = new char[5];
    public string Code;
    bool Open;
    int slot;
    public Animator anim;
    public void BrickPressed(char Num)
    {
        if(Num == 'G')
        {
            slot = 0;
        }
        if (!Open)
        {
            N[slot] = Num;
            slot++;
            if (slot > 4) CheckCode();           
        }
    }

    void CheckCode()
    {
        if (Code == GetCode())
        {
            Open = true;
            anim.SetBool("Open", true);
            MapManagement.ThirdDoorOpen = true;
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
        return $"{N[0]}{N[1]}{N[2]}{N[3]}{N[4]}";
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

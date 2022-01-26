using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MapManagement
{
    public static bool FirstDoorOpen = false;
    public static bool SecondDoorOpen = false;
    public static bool ThirdDoorOpen = false;
    public static bool LasersOff = false;
    public static GameObject Player;
    public static GameObject[] Buttons = new GameObject[3];
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CurrentLocation currentLocation;
    Camera TheCamera;
    public GameObject[] buttons = new GameObject[3];
    AudioManager audio;
    // Start is called before the first frame update
    void Start()
    {
        TheCamera = Camera.main;
        MapManagement.Player = gameObject;
        MapManagement.Buttons = buttons;
        currentLocation = new CurrentLocation(new StartPosition());
        currentLocation.CheckButtons();
        audio = GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        { // if left button pressed...
            Ray ray = TheCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Intractable ClickedObject = hit.collider.gameObject.GetComponent<Intractable>();
                if (ClickedObject != null)
                {
                    ClickedObject.Use();
                }
            }
            currentLocation.CheckButtons();
        }
       
    }

    public void PressRight()
    {
        currentLocation.PressedRight();
        audio.PlaySound(Sound.Activation.Custom, "Move");
    }
    public void PressLeft()
    {
        currentLocation.PressedLeft();
        audio.PlaySound(Sound.Activation.Custom, "Move");
    }
    public void PressForward()
    {
        currentLocation.PressedForward();
        audio.PlaySound(Sound.Activation.Custom, "Move");
    }
}

public class CurrentLocation
{
    private Location location;

    public CurrentLocation(Location MoveTo)
    {
        location = MoveTo;
    }

    public void PressedRight()
    {
        location.TurnRight();
    }

    public void PressedLeft()
    {
        location.TurnLeft();
    }

    public void PressedForward()
    {
        location.GoForward();
    }

    public void CheckButtons()
    {
        location.TestButtons();
    }

    public Location Current
    {
        get { return location; }
        set { location = value; }
    }
}


public abstract class Location
{
    public abstract bool TurnRight(bool Move = true);

    public abstract bool TurnLeft(bool Move = true);

    public abstract bool GoForward(bool Move = true);

    public Location()
    {
        TestButtons();
    }

    public void TestButtons()
    {
        MapManagement.Buttons[0].SetActive(TurnRight(false));
        MapManagement.Buttons[1].SetActive(TurnLeft(false));
        MapManagement.Buttons[2].SetActive(GoForward(false));
    }
}

public class StartPosition : Location
{
    public StartPosition()
    {
        Debug.Log("Standing in Start Looking Forward");
        MapManagement.Player.transform.localRotation = Quaternion.Euler(0, 0, 0);
        MapManagement.Player.transform.position = new Vector3(0, 0, -10);
    }

    public override bool TurnRight(bool Move)
    {
        if (Move)
        {
            CameraController.currentLocation.Current = new StartRight();
        }
        return true;
    }

    public override bool TurnLeft(bool Move)
    {
        if (Move)
        {
            CameraController.currentLocation.Current = new StartLeft();
        }
        return true;
    }

    public override bool GoForward(bool Move)
    {
        if (MapManagement.FirstDoorOpen)
        {
            if (Move)
            {
                CameraController.currentLocation.Current = new Position2Forward();
            }
            return true;
        }
        else
        {
            return false;
        }
    }
}
public class StartRight : Location
{

    public StartRight()
    {
        Debug.Log("Standing in Start Looking Right");
        MapManagement.Player.transform.localRotation = Quaternion.Euler(0, 90, 0);
        MapManagement.Player.transform.position = new Vector3(0, 0, -10);
    }

    public override bool TurnRight(bool Move)
    {
        if (Move)
        {
            CameraController.currentLocation.Current = new StartBack();
        }
        return true;
    }

    public override bool TurnLeft(bool Move)
    {
        if (Move)
        {
            CameraController.currentLocation.Current = new StartPosition();
        }
        return true;
    }

    public override bool GoForward(bool Move)
    {
        return false;
    }
}
public class StartLeft : Location
{
    public StartLeft()
    {
        Debug.Log("Standing in Start Looking Left");
        MapManagement.Player.transform.localRotation = Quaternion.Euler(0, -90, 0);
        MapManagement.Player.transform.position = new Vector3(0, 0, -10);
    }

    public override bool TurnRight(bool Move)
    {
        if (Move)
        {
            CameraController.currentLocation.Current = new StartPosition();
        }
        return true;
    }

    public override bool TurnLeft(bool Move)
    {
        if (Move)
        {
            CameraController.currentLocation.Current = new StartBack();
        }
        return true;
    }

    public override bool GoForward(bool Move)
    {
        return false;
    }
}
public class StartBack : Location
{
    public StartBack()
    {
        Debug.Log("Standing in Start Looking at the back");
        MapManagement.Player.transform.localRotation = Quaternion.Euler(0, 180, 0);
        MapManagement.Player.transform.position = new Vector3(0, 0, -10);
    }

    public override bool TurnRight(bool Move)
    {
        if (Move)
        {
            CameraController.currentLocation.Current = new StartLeft();
        }
        return true;
    }

    public override bool TurnLeft(bool Move)
    {
        if (Move)
        {
            CameraController.currentLocation.Current = new StartRight();
        }
        return true;
    }

    public override bool GoForward(bool Move)
    {
        return false;
    }
}
public class Position2Forward : Location
{
    public Position2Forward()
    {
        Debug.Log("You Escaped!");        
        MapManagement.Player.transform.localRotation = Quaternion.Euler(0, 0, 0);
        MapManagement.Player.transform.position = new Vector3(0, 0, 0);
    }

    public override bool TurnRight(bool Move)
    {
        if (Move)
        {
            CameraController.currentLocation.Current = new Position2Right();
        }
        return true;
    }

    public override bool TurnLeft(bool Move)
    {
        if(Move)
        {
            CameraController.currentLocation.Current = new Position2Left();
        }
        return true;
    }

    public override bool GoForward(bool Move)
    {
        return false;
    }
}

public class Position2Left : Location
{
    public Position2Left()
    {       
        MapManagement.Player.transform.localRotation = Quaternion.Euler(0, -90, 0);
        MapManagement.Player.transform.position = new Vector3(0, 0, 0);
    }

    public override bool TurnRight(bool Move)
    {
        if (Move)
        {
            CameraController.currentLocation.Current = new Position2Forward();
        }
        return true;
    }

    public override bool TurnLeft(bool Move)
    {
        if (Move)
        {
            CameraController.currentLocation.Current = new Position2Back();
        }
        return true;
    }

    public override bool GoForward(bool Move)
    {
        if (MapManagement.LasersOff)
        {
            if (Move)
            {
                CameraController.currentLocation.Current = new Position4Forward();
            }
            return true;
        }
        else
        {
            return false;
        }
    }
}

public class Position2Right : Location
{
    public Position2Right()
    {
        MapManagement.Player.transform.localRotation = Quaternion.Euler(0, 90, 0);
        MapManagement.Player.transform.position = new Vector3(0, 0, 0);
    }

    public override bool TurnRight(bool Move)
    {
        if (Move)
        {
            CameraController.currentLocation.Current = new Position2Back();
        }
        return true;
    }

    public override bool TurnLeft(bool Move)
    {  
        if (Move)
        {
            CameraController.currentLocation.Current = new Position2Forward();
        }
        return true;
    }

    public override bool GoForward(bool Move)
    {
        if (MapManagement.SecondDoorOpen)
        {
            if (Move)
            {
                CameraController.currentLocation.Current = new Position3Forward();
            }
            return true;
        }
        else
        {
            return false;
        }
    }
}

public class Position2Back : Location
{
    public Position2Back()
    {
        MapManagement.Player.transform.localRotation = Quaternion.Euler(0, 180, 0);
        MapManagement.Player.transform.position = new Vector3(0, 0, 0);
    }

    public override bool TurnRight(bool Move)
    {
        if (Move)
        {
            CameraController.currentLocation.Current = new Position2Left();
        }
        return true;
    }

    public override bool TurnLeft(bool Move)
    {
        if (Move)
        {
            CameraController.currentLocation.Current = new Position2Right();
        }
        return true;
    }

    public override bool GoForward(bool Move)
    {
        if (Move)
        {
            CameraController.currentLocation.Current = new StartBack();
        }
        return true;
    }
}

public class Position3Forward : Location
{
    public Position3Forward()
    {       
        MapManagement.Player.transform.localRotation = Quaternion.Euler(0, 90, 0);
        MapManagement.Player.transform.position = new Vector3(11, 0, 1);
    }

    public override bool TurnRight(bool Move)
    {
        if (Move)
        {
            CameraController.currentLocation.Current = new Position3Right();
        }
        return true;
    }

    public override bool TurnLeft(bool Move)
    {
        if(Move)
        {
            CameraController.currentLocation.Current = new Position3Left();
        }
        return true;
    }

    public override bool GoForward(bool Move)
    {

        return false;
    }
}

public class Position3Left : Location
{
    public Position3Left()
    {       
        MapManagement.Player.transform.localRotation = Quaternion.Euler(0, 0, 0);
        MapManagement.Player.transform.position = new Vector3(11, 0, 1);
    }

    public override bool TurnRight(bool Move)
    {
        if (Move)
        {
            CameraController.currentLocation.Current = new Position3Forward();
        }
        return true;
    }

    public override bool TurnLeft(bool Move)
    {
        if (Move)
        {
            CameraController.currentLocation.Current = new Position3Back();
        }
        return true;
    }

    public override bool GoForward(bool Move)
    {
        return false;
    }
}

public class Position3Right : Location
{
    public Position3Right()
    {
        MapManagement.Player.transform.localRotation = Quaternion.Euler(0, 180, 0);
        MapManagement.Player.transform.position = new Vector3(11, 0, 1);
    }

    public override bool TurnRight(bool Move)
    {
        if (Move)
        {
            CameraController.currentLocation.Current = new Position3Back();
        }
        return true;
    }

    public override bool TurnLeft(bool Move)
    {  
        if (Move)
        {
            CameraController.currentLocation.Current = new Position3Forward();
        }
        return true;
    }

    public override bool GoForward(bool Move)
    {
        return false;
    }
}

public class Position3Back : Location
{
    public Position3Back()
    {
        MapManagement.Player.transform.localRotation = Quaternion.Euler(0, -90, 0);
        MapManagement.Player.transform.position = new Vector3(11, 0, 1);
    }

    public override bool TurnRight(bool Move)
    {
        if (Move)
        {
            CameraController.currentLocation.Current = new Position3Left();
        }
        return true;
    }

    public override bool TurnLeft(bool Move)
    {
        if (Move)
        {
            CameraController.currentLocation.Current = new Position3Right();
        }
        return true;
    }

    public override bool GoForward(bool Move)
    {
        if (Move)
        {
            CameraController.currentLocation.Current = new Position2Left();
        }
        return true;
    }
}

public class Position4Forward : Location
{
    public Position4Forward()
    {
        MapManagement.Player.transform.localRotation = Quaternion.Euler(0, -90, 0);
        MapManagement.Player.transform.position = new Vector3(-10, 0, 0.1f);
    }

    public override bool TurnRight(bool Move)
    {
        if (Move)
        {
            CameraController.currentLocation.Current = new Position4Right();
        }
        return true;
    }

    public override bool TurnLeft(bool Move)
    {
        if (Move)
        {
            CameraController.currentLocation.Current = new Position4Left();
        }
        return true;
    }

    public override bool GoForward(bool Move)
    {
        return false;
    }
}

public class Position4Left : Location
{
    public Position4Left()
    {
        MapManagement.Player.transform.localRotation = Quaternion.Euler(0, 180, 0);
        MapManagement.Player.transform.position = new Vector3(-10, 0, 0.1f);
    }

    public override bool TurnRight(bool Move)
    {
        if (Move)
        {
            CameraController.currentLocation.Current = new Position4Forward();
        }
        return true;
    }

    public override bool TurnLeft(bool Move)
    {
        if (Move)
        {
            CameraController.currentLocation.Current = new Position4Back();
        }
        return true;
    }

    public override bool GoForward(bool Move)
    {
        return false;
    }
}

public class Position4Right : Location
{
    public Position4Right()
    {
        MapManagement.Player.transform.localRotation = Quaternion.Euler(0, 0, 0);
        MapManagement.Player.transform.position = new Vector3(-10, 0, 0.1f);
    }

    public override bool TurnRight(bool Move)
    {
        if (Move)
        {
            CameraController.currentLocation.Current = new Position4Back();
        }
        return true;
    }

    public override bool TurnLeft(bool Move)
    {
        if (Move)
        {
            CameraController.currentLocation.Current = new Position4Forward();
        }
        return true;
    }

    public override bool GoForward(bool Move)
    {
        if (MapManagement.ThirdDoorOpen)
        {
            if (Move)
            {
                CameraController.currentLocation.Current = new Position5Forward();
            }
            return true;
        }
        else
        {
            return false;
        }
    }
}

public class Position4Back : Location
{
    public Position4Back()
    {
        MapManagement.Player.transform.localRotation = Quaternion.Euler(0, 90, 0);
        MapManagement.Player.transform.position = new Vector3(-10, 0, 0.1f);
    }

    public override bool TurnRight(bool Move)
    {
        if (Move)
        {
            CameraController.currentLocation.Current = new Position4Left();
        }
        return true;
    }

    public override bool TurnLeft(bool Move)
    {
        if (Move)
        {
            CameraController.currentLocation.Current = new Position4Right();
        }
        return true;
    }

    public override bool GoForward(bool Move)
    {
        if (Move)
        {
            CameraController.currentLocation.Current = new Position2Right();
        }
        return true;
    }
}

public class Position5Forward : Location
{
    public Position5Forward()
    {
        MapManagement.Player.transform.localRotation = Quaternion.Euler(0, 0, 0);
        MapManagement.Player.transform.position = new Vector3(-10, 0, 8);
    }

    public override bool TurnRight(bool Move)
    {
        if (Move)
        {
            CameraController.currentLocation.Current = new Position5Right();
        }
        return true;
    }

    public override bool TurnLeft(bool Move)
    {
        if (Move)
        {
            CameraController.currentLocation.Current = new Position5Left();
        }
        return true;
    }

    public override bool GoForward(bool Move)
    {
        return false;
    }
}

public class Position5Left : Location
{
    public Position5Left()
    {
        MapManagement.Player.transform.localRotation = Quaternion.Euler(0, -90, 0);
        MapManagement.Player.transform.position = new Vector3(-10, 0, 8);
    }

    public override bool TurnRight(bool Move)
    {
        if (Move)
        {
            CameraController.currentLocation.Current = new Position5Forward();
        }
        return true;
    }

    public override bool TurnLeft(bool Move)
    {
        if (Move)
        {
            CameraController.currentLocation.Current = new Position5Back();
        }
        return true;
    }

    public override bool GoForward(bool Move)
    {
        return false;
    }
}

public class Position5Right : Location
{
    public Position5Right()
    {
        MapManagement.Player.transform.localRotation = Quaternion.Euler(0, 90, 0);
        MapManagement.Player.transform.position = new Vector3(-10, 0, 8);
    }

    public override bool TurnRight(bool Move)
    {
        if (Move)
        {
            CameraController.currentLocation.Current = new Position5Back();
        }
        return true;
    }

    public override bool TurnLeft(bool Move)
    {
        if (Move)
        {
            CameraController.currentLocation.Current = new Position5Forward();
        }
        return true;
    }

    public override bool GoForward(bool Move)
    {
        return false;
    }
}

public class Position5Back : Location
{
    public Position5Back()
    {
        MapManagement.Player.transform.localRotation = Quaternion.Euler(0, 180, 0);
        MapManagement.Player.transform.position = new Vector3(-10, 0, 8);
    }

    public override bool TurnRight(bool Move)
    {
        if (Move)
        {
            CameraController.currentLocation.Current = new Position5Left();
        }
        return true;
    }

    public override bool TurnLeft(bool Move)
    {
        if (Move)
        {
            CameraController.currentLocation.Current = new Position5Right();
        }
        return true;
    }

    public override bool GoForward(bool Move)
    {
        if (Move)
        {
            CameraController.currentLocation.Current = new Position4Left();
        }
        return true;
    }
}


//public class SafeRoom : Location
//{
//    public SafeRoom()
//    {
//        MapManagement.Player.transform.localRotation = Quaternion.Euler(0, 0, 0);
//        MapManagement.Player.transform.position = new Vector3(-10, 0, 8);
//    }

//    public override bool TurnRight(bool Move)
//    {
//        return false;
//    }

//    public override bool TurnLeft(bool Move)
//    {
//        return false;
//    }

//    public override bool GoForward(bool Move)
//    {
//        //DELETE THIS
//        if (Move)
//        {
//            CameraController.currentLocation.Current = new Position2Forward();
//        }
//        return true;
//    }
//}

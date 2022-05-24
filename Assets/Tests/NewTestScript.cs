using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

public class NewTestScript
{
    // A Test behaves as an ordinary method
    [Test]
    public void NewTestScriptSimplePasses()
    {
        // Use the Assert class to test conditions
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator WasTheDoorOpened()
    {
        SceneManager.LoadScene(0);
        //yield return null;
        yield return new WaitForSeconds(2);
        GameObject Door = GameObject.Find("TheDoor");
 
        Assert.IsNotNull(Door);
        
        Vector3 Pos1 = Door.transform.position;
        
        Debug.Log(Pos1);
        yield return new WaitForSeconds(7);
        Vector3 Pos2 = Door.transform.position;
       
        Debug.Log(Pos2);
        Assert.IsFalse(Pos1 == Pos2);
      

    }

    [UnityTest]
    public IEnumerator IsPlayerLeftRoom()
    {
        SceneManager.LoadScene(0);
        //yield return null;
        yield return new WaitForSeconds(2);
       
        GameObject Player = GameObject.Find("Player");
   
        Assert.IsNotNull(Player);
    
        Vector3 PPos1 = Player.transform.position;

        yield return new WaitForSeconds(7);
        
        Vector3 PPos2 = Player.transform.position;
  
     
        Assert.IsFalse(PPos1 == PPos2);

    }

    [UnityTest]
    public IEnumerator WasKeyTaken()
    {
        SceneManager.LoadScene(0);
        //yield return null;
        yield return new WaitForSeconds(2);
        GameObject Key = GameObject.Find("FirstKey");

        Assert.IsNotNull(Key);

        
        
        yield return new WaitForSeconds(7);
        Key = GameObject.Find("FirstKey");
        Assert.IsNull(Key);
        //Assert.IsTrue(Key.activeSelf==false);


    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;
using UnityEngine.TestTools;

public class controlTest
{
    GameObject go;
    private carcontrol5 car;

    [SetUp]
    public void setup()
    {
        Vector3 vector3 = new Vector3(0, 2, 5);
        Quaternion rotate = new Quaternion(0, 0, 0, 0);
        go = MonoBehaviour.Instantiate(Resources.Load<GameObject>("test1"), vector3, rotate);
    }  

    [UnityTest]
    public IEnumerator GoStraightTest()
    {
        car = go.GetComponent<carcontrol5>();
        Vector3 pos = car.transform.position;
        int haha = car.Move(true, false, false, false);
        yield return new WaitForSeconds(1.0f);
        Assert.Greater(haha, (int)pos.z);
        
    }

    [UnityTest]
    public IEnumerator GoBacktTest()
    {
        car = go.GetComponent<carcontrol5>();
        Vector3 pos = car.transform.position;
        int haha = car.Move(false, true, false, false);
        yield return new WaitForSeconds(1.0f);
        Assert.Less(haha, (int)pos.z);

    }
}

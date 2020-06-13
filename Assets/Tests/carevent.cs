using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class carevent
{
    public static void ResetCar(GameObject gameObject, Vector3 Position)
    {
        GameObject.Destroy(gameObject);
        Debug.Log("1");
        GameObject newG = GameObject.Instantiate(gameObject, Position, Quaternion.Euler(0, 0, 0));
        Debug.Log("2");
        newG.GetComponent<carcontrol5>().enabled = true;
        newG.transform.GetChild(1).GetComponentInChildren<Camera>().enabled = true;
    }

    //建立list
    static List<GameObject> vehicle = new List<GameObject>();
    
    public static void addlist(GameObject name)
    {
        vehicle.Add(name);
    }

    public static List<GameObject> GetList()
    {
        return vehicle;
    }

    public static GameObject[] ll = new GameObject[10];
    static int index = 0;
    public static void AddCarToArray(GameObject gg)
    {
        Debug.Log(index);
        ll[index] = gg;
        Debug.Log(ll[0].name);
        index++;
    }
    public static GameObject[] getll()
    {
        return ll;
    }

    //選賽車
    static GameObject target;
    public static void setTarget(GameObject car)
    {
        target = car;
    }
    public  static GameObject getTarget()
    {
        target.transform.GetChild(1).transform.GetComponent<Camera>().enabled = true;
        return target;
    }
    
    
}

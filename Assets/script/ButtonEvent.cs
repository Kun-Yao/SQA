using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonEvent : MonoBehaviour
{
    GameObject carcamera;
    GameObject car;

    private void Start()
    {
        carcamera = GameObject.Find("CarCamera");
    }
    
    public void transScene(int index)
    {
        SceneManager.LoadScene(index);
        Debug.Log(SceneManager.GetActiveScene().name + carevent.ll[0]);
    }

    public void button1()
    {
        Debug.Log("按鈕一");
        car = GameObject.Find("test1");
        carcamera.transform.position = new Vector3(car.transform.position.x, car.transform.position.y+2, car.transform.position.z-8);
        carevent.setTarget(car);
    }
    public void button2()
    {
        Debug.Log("按鈕二");
        car = GameObject.Find("test2");
        carcamera.transform.position = new Vector3(car.transform.position.x, car.transform.position.y + 2, car.transform.position.z - 8);
    }

    public void SaveCar(GameObject third)
    {
        car = GameObject.Find("Engine");
        if(car == null)
        {
            Debug.Log("null");
        }
        car.AddComponent<Rigidbody>().useGravity = false;
        car.AddComponent<BoxCollider>();
        GameObject t = Instantiate(third);
        t.transform.SetParent(car.transform);
        t.name = "third";
        car.AddComponent<Button>();
        car.AddComponent<carcontrol5>().enabled = false;
        carevent.AddCarToArray(car);
        Debug.Log(carevent.ll[0]);
        //選好賽車再啟動所有component
    }


}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class carcontrol5 : MonoBehaviour
{
    //GameObject dashBoard;
    MeshRenderer[] tires;

    int direction = 0;
    float maxspeed = 300;
    Vector3 checkPoint;
    float maxForce = 0;
    private bool up = false;
    bool down = false;
    bool left = false;
    bool right = false;

    // Start is called before the first frame update
    void Start()
    {
        tires = transform.GetChild(0).GetComponentsInChildren<MeshRenderer>();
        //dashBoard = GameObject.Find("Text");

        checkPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //if (transform.GetComponent<Rigidbody>().velocity.magnitude >= 0 || transform.GetComponent<Rigidbody>().velocity.magnitude <= maxspeed)
        //{
        //    dashBoard.GetComponent<Text>().text = (transform.GetComponent<Rigidbody>().velocity.magnitude).ToString("0");
        //}

        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("break");
            carevent.ResetCar(this.gameObject, checkPoint);
            Debug.Log(gameObject.name);
        }
        
    }



    public int Move(bool up, bool down, bool left, bool right)
    {
        
        //移動
        if (up)
        {
            direction = 1;
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1);
            if (transform.GetComponent<Rigidbody>().velocity.magnitude < maxspeed)
            {
                maxForce = 15000;
                for (int i = 0; i < 4; i++)
                {
                    tires[i].transform.Rotate(25 * transform.GetComponent<Rigidbody>().velocity.magnitude, 0, 0);
                }
            }
            else
            {
                transform.GetComponent<Rigidbody>().velocity = transform.forward * direction * maxspeed;
            }
        }
        else if (down)
        {
            direction = -1;
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1);
            if (transform.GetComponent<Rigidbody>().velocity.magnitude < maxspeed)
            {
                maxForce = -15000;
                for (int i = 0; i < 4; i++)
                {
                    tires[i].transform.Rotate(-25 * transform.GetComponent<Rigidbody>().velocity.magnitude, 0, 0);
                }
            }
            else
            {
                transform.GetComponent<Rigidbody>().velocity = transform.forward * direction * maxspeed;
            }
        }
        else
        {
            direction = 0;
            transform.GetComponent<Rigidbody>().velocity *= 0.93f;
            maxForce = 0;
        }
        transform.GetComponent<Rigidbody>().AddForce(transform.forward * maxForce);
        //轉彎
        if (Input.GetKey(KeyCode.RightArrow))
        {
            //Debug.Log("右轉");
            transform.Rotate(0, 0.75f * direction, 0);

            //Debug.Log(transform.rotation.y);
            for (int i = 0; i < 2; i++)
            {
                tires[i].transform.localRotation = Quaternion.Euler(0, 25, 0);
            }
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            //Debug.Log("左轉");
            transform.Rotate(0, -0.75f * direction, 0);

            //Debug.Log(transform.rotation.y);
            //transform.Rotate(0, -1.5f * direction, 0);
            for (int i = 0; i < 2; i++)
            {
                tires[i].transform.localRotation = Quaternion.Euler(0, -25, 0);
            }
        }
        else
        {
            for (int i = 0; i < 2; i++)
            {
                tires[i].transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
        }
        return (int)transform.position.z;
        
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {

            if (Mathf.Abs(transform.rotation.x) > 45 || Mathf.Abs(transform.rotation.z) > 45 || Input.GetKey(KeyCode.R))
            {
                Debug.Log("break");
                carevent.ResetCar(this.gameObject, checkPoint);
                Debug.Log(gameObject.name);
            }
            else
            {
                transform.GetComponent<Rigidbody>().mass = 200;
                //Move();
            }
                
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            Debug.Log("123");
            direction = 0;
            transform.GetComponent<Rigidbody>().velocity *= 0.93f;
            transform.GetComponent<Rigidbody>().mass = Mathf.Infinity;
            maxForce = 0;
        }
    }

    public void haha()
    {
        if (Input.GetKey(KeyCode.UpArrow))
            Move(true, false, false, false);
        else
            Move(false, false, false, false);
        //if (Input.GetKey(KeyCode.DownArrow))
        //    return 2;
        //else
        //    return 0;
    }

}

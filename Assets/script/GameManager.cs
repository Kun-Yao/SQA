﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static GameManager instance;
    
    void Awake () {

        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else if (this != instance) {
            Destroy(gameObject);
        } 
    }     
}

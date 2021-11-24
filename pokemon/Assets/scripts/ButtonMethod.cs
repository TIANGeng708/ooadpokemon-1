﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMethod : MonoBehaviour
{
    public GameObject go;

    public void InitialAppear()
    {
        go.GetComponent<DataBase>().Read();
        go.GetComponent<DataBase>().Appear1();
        Invoke("SecondAppear",8f);
    }

    public void SecondAppear()
    {
        go.GetComponent<DataBase>().Appear2();
    }

    public void Hit()
    {
        go.GetComponent<DataBase>().Hit();
    }

    public void Special()
    {
        go.GetComponent<DataBase>().Special();
    }

    public void Buff()
    {
        go.GetComponent<DataBase>().Buff();
    }
    
    public void Debuff()
    {
        go.GetComponent<DataBase>().Debuff();
    }
}
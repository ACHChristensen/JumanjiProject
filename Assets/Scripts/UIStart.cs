using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIStart : MonoBehaviour
{
    GameObject startUI;
    void Start()
    {
       startUI = GameObject.FindGameObjectWithTag("StartUI");
    }

    public void DestroyStartMenu()
    {
        Destroy(startUI);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

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

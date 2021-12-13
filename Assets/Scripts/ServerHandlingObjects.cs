using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class ServerHandlingObjects : MonoBehaviour
{
    public GameObject controllerUI;
    void Start()
    {
        if (!NetworkClient.localPlayer.isClient)
        {
            Destroy(controllerUI);
        }
    }

    private void Update()
    {
        NetworkManager.singleton.OnStopClient();
        Destroy(this.gameObject);
    }
}

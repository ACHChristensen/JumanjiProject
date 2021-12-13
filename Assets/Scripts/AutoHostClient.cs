using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class AutoHostClient : MonoBehaviour
{
    [SerializeField] private NetworkManager networkManager;
    [SerializeField] private GameObject theGame;
    public void JoinLocalClient()
    {
        networkManager.networkAddress = "localhost";
        networkManager.StartClient();
    }
    public void JoinLocalServer()
    {
        networkManager.networkAddress = "localhost";
        networkManager.StartServer();
        Instantiate(theGame, theGame.transform);
    }
}

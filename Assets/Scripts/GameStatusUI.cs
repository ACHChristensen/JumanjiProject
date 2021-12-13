using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStatusUI : MonoBehaviour
{
    public GameObject endLine;
    public static string status;

    void Start()
    {
        status = "";
    }

    private void Update()
    {
        SetGameStatus(status);
    }

    public void SetGameStatus(string gameStatusWord)
    {

        if(gameStatusWord.Equals("won"))
        {
           this.GetComponent<Text>().text = "VICTORY!";
        }
        else if(gameStatusWord.Equals("lost")) { 

             this.GetComponent<Text>().text = "GAME OVER";
        }else
        {    this.GetComponent<Text>().text = "";
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            status = "won";
        }
    }

}

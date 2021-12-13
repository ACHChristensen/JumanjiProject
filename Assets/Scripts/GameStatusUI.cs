using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStatusUI : MonoBehaviour
{
    private GameObject statusGame;
    public static string status;

    void Start()
    {
        statusGame = GameObject.FindGameObjectWithTag("GameStatus"); 
        status = "";
    }

    private void Update()
    {
        SetGameStatus(status);
    }

    public void SetGameStatus(string gameStatusWord)
    {
        
        if(gameStatusWord.Equals("won") )
        {
            statusGame.GetComponent<Text>().color = Color.Lerp(Color.gray, Color.green, 0.5f); 
                statusGame.GetComponent<Text>().text = "VICTORY!";
        }
        else if(gameStatusWord.Equals("lost")) {

                statusGame.GetComponent<Text>().text = "GAME OVER";
        }else
        {
                statusGame.GetComponent<Text>().text = "";
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

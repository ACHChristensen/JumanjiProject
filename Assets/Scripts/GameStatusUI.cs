using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameStatusUI : MonoBehaviour
{
    private GameObject statusGame;
    public static string status;
    private float timer;
    private float offsetTime = 5f;
    private int coins;
    private GameObject player;


    void Start()
    {
        statusGame = GameObject.FindGameObjectWithTag("GameStatus"); 
        status = "";
        timer = 0f;
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
                statusGame.GetComponent<Text>().text = "VICTORY - "+ coins +" points!";
            WaitBeforeReset();
        }
        else if(gameStatusWord.Equals("lost")) {

                statusGame.GetComponent<Text>().text = "GAME OVER";
            WaitBeforeReset();
                
        }else
        {
                statusGame.GetComponent<Text>().text = "";
        }
      
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag.Equals("Player"))
        {   
            player = other.gameObject;
            coins = player.GetComponent<PlayerAttachmentsHandler>().getAmountOfCoint();
            status = "won";
        }
    }


    private void WaitBeforeReset()
    {
            timer += Time.deltaTime;
            if (timer > offsetTime)
            {
                timer = 0f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void SetCoins(int coins)
    {
        this.coins = coins;
    }


public void SetWordStatus(string statusWord)
    {
        status = statusWord;
    }
}

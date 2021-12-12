using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStatusUI : MonoBehaviour
{
    public GameObject endLine;

    void Start()
    {
        SetGameStatus("");
    }

    public enum GameStatus
    {
        gameOver,
        inGame,
        wonGame
    }


    public void SetGameStatus(string gameStatusWord)
    {
        GameStatus gameStatus = new GameStatus();

        if(gameStatusWord.Equals("won"))
        {
            gameStatus = GameStatus.wonGame;
        }
        else if(gameStatusWord.Equals("lost")) { 
            gameStatus = GameStatus.gameOver; 
        }else
        {
            gameStatus = GameStatus.inGame;
        }

        switch (gameStatus)
        {
            case GameStatus.gameOver:
                this.GetComponent<Text>().text = "GAME OVER";
                return;

            case GameStatus.wonGame:
                this.GetComponent<Text>().text = "VICTORY!";
                return;
            default:
                this.GetComponent<Text>().text = "";
                return;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            SetGameStatus("won");
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class HealthController : MonoBehaviour
{
    
    public int healthPoints;
    [SerializeField] private Image[] hearts;
    [SerializeField] private Text gameStatus;
    private int hpTemp;
    private List<Image> heartsToCount;
    public PlayerInput playerInput;

    void Start()
    {
        healthPoints = 10;
        gameStatus.text = "";
        hpTemp = healthPoints;
        heartsToCount = new List<Image>();
        foreach (Image heart in hearts)
        {
            heartsToCount.Add(heart);   
        }
    }


    void Update()
    {
        if(healthPoints < hpTemp)
        {
            UpdateHealth();
            hpTemp=healthPoints;
        } 
        if (healthPoints == 0)
        {
            gameStatus.text = "GAME OVER!";
        }
    }

    private void UpdateHealth()
    {
        if (healthPoints%2 == 0)
        {
            for (int i = 0; i < hearts.Length; i++) { 
                if (hearts[i].enabled == false)
                {
                    continue;
                }
                if (hearts[i].color.Equals(Color.gray)) 
                { 
                    hearts[i].enabled = false;
                    break;
                }else if(!hearts[i].color.Equals( Color.gray))
                {
                    continue;
                }
               
            }
        }
        else
        { 
            for (int i = 0;i < hearts.Length; i++)
            {
                if (!hearts[i].enabled)
                {
                    continue ;
                }
                hearts[i].color = Color.gray;
                break;
            }
            
        }
    }

    public void SetHP(int HP)
    {
        healthPoints = HP;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    
    public int healthPoints;
    [SerializeField] private Image[] hearts;
    [SerializeField] private Text gameStatus;
    private int hpTemp;
    private List<Image> heartsToCount;

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
        if (healthPoints == 0)
        {
            gameStatus.text = "GAME OVER!";
        }
        else if(healthPoints < hpTemp)
        {
            UpdateHealth();
            hpTemp--;
        }
        
        
        Debug.Log(message: "Health: " + healthPoints);
    }

    private void UpdateHealth()
    {
        Debug.Log(message: "Kasper " + healthPoints);
        Debug.Log(message: "bublu: " + (healthPoints % 2));
        if (healthPoints%2 == 0)
        {
            for (int i = 0; i < hearts.Length; i++)
            {   Debug.Log(message: hearts[i].name + " HERE!");
                if (hearts[i].color.Equals(Color.gray)) 
                { 
                    hearts[i].enabled = false;
                    break;
                }else if(!hearts[i].color.Equals( Color.gray))
                {
                    i++;
                }
                Debug.Log(message: hearts[i].name + " Equally heart ");
                
            }
        }
        else
        { 
            for (int i = 0;i < hearts.Length; i++)
            {
                if (!hearts[i].enabled)
                {
                    i++;
                }
                hearts[i].color = Color.gray;
                Debug.Log(message: hearts[i].name + " black hearts ");
                break;
            }
            
        }
    }

    public void SetHP(int HP)
    {
        healthPoints = HP;
    }

}

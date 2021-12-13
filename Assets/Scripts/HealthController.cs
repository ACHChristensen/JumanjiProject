using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    
    private int healthPoints;
    [SerializeField] private Image[] hearts;
    [SerializeField] private Text gameStatus;
    private int hpTemp;
    private bool lifeGained;
    private PlayerAttachmentsHandler playerAttachmentsHandler;
    private static HealthController hpController = null;

    void Awake()
    {
      
        if (hpController == null)
        {
            hpController = this;
        }else if (hpController != this)
        {
            Destroy(hpController);
        }
    
    }

    void Start()
    {
        playerAttachmentsHandler = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAttachmentsHandler>();
        healthPoints = 10;
        hpTemp = healthPoints;
    }


    void Update()
    {
        
        if(healthPoints < hpTemp)
        {  
            LoseHealth();
            hpTemp = healthPoints;
        } 
        if (healthPoints == 0)
        {
            GameStatusUI.status = "lost";
        }
        lifeGained = playerAttachmentsHandler.GetLifeGained();
        if (lifeGained && healthPoints < 10)
        {
            SetHP(GetHP() + 1); 
            hpTemp = healthPoints;
            IncreaseHealth();
            playerAttachmentsHandler.SetLifeGained(false);
        }
    }

    private void LoseHealth()
    {Debug.Log(healthPoints);

        if (healthPoints % 2 != 0)
        {
            OddNumberLife();
        } else
        {
            EvenNumberLife();
        }
        /*if (healthPoints%2 == 0)
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
                else if (lifeGained && !hearts[i].enabled)
                {
                    hearts[i].enabled = true;
                    Physics.SyncTransforms();
                    playerAttachmentsHandler.SetLifeGained(false); 
                    break;
                }else if (lifeGained)
                {
                    hearts[i - 1].enabled = true;
                    Physics.SyncTransforms();
                    playerAttachmentsHandler.SetLifeGained(false);
                    break;
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
                else if (lifeGained)
                {
                    hearts[i-1].color = Color.gray;
                    playerAttachmentsHandler.SetLifeGained(false);
                    break;
                }
                hearts[i].color = Color.gray;
                break;
            }
            
        }*/
    }

    private void EvenNumberLife()
    {
        hearts[hearts.Length - (healthPoints / 2)-1].enabled = false;
    }
    private void OddNumberLife()
    {
        hearts[hearts.Length - (healthPoints / 2)-1].color = Color.gray;
    }

    private void IncreaseHealth()
    {
        if (healthPoints % 2 != 0)
        {
            OddNumberLifeAdd();
        }
        else
        {
            EvenNumberLifeAdd();
        }
    }

    private void EvenNumberLifeAdd()
    {
        hearts[hearts.Length - (healthPoints / 2)].color = Color.white;
    }
    private void OddNumberLifeAdd()
    {
        hearts[hearts.Length - (healthPoints / 2) - 1].enabled = true;
        hearts[hearts.Length - (healthPoints / 2) - 1].color = Color.gray;
    }

    public void SetHP(int HP)
    {
        healthPoints = HP;
    }

    public int GetHP()
    {
        return healthPoints;
    }
}

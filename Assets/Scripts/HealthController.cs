using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    
    private int healthPoints;
    [SerializeField] private Image[] hearts;
    [SerializeField] private Text gameStatus;
    private GameStatusUI gameStatusController;
    private int hpTemp;
    private List<Image> heartsToCount;

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
        healthPoints = 10;
        gameStatusController = gameStatus.GetComponent<GameStatusUI>();
        hpTemp = healthPoints;
       /* heartsToCount = new List<Image>();
        foreach (Image heart in hearts)
        {
            heartsToCount.Add(heart);   
        }
       */
    }


    void Update()
    {
        
        if(healthPoints < hpTemp)
        {  Debug.Log(healthPoints);
            UpdateHealth();
            hpTemp = healthPoints;
        } 
        if (healthPoints == 0)
        {
            GameStatusUI.status = "lost";
        }
    }

    private void UpdateHealth()
    {
        Debug.Log(message: "To update HP...");
        if (healthPoints%2 == 0)
        {
            Debug.Log(message: "Even");
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
            Debug.Log(message: "Odd");
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

    public int GetHP()
    {
        return healthPoints;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpController : MonoBehaviour
{
    public static float rotation = 90f;
    public static bool done;
    public List<GameObject> powerUps;
    private float timer = 0f;
    private float offsetTime = 3f;
    private GameObject player;

    private void Start()
    {
        done = false;   
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        foreach (GameObject powerUp in powerUps)
        {
            
            Respawn(powerUp);
        }
    }

    public void Respawn(GameObject powerUP)
    {
        if (!powerUP.activeSelf)
        {
            Debug.Log(powerUP.name);
            timer += Time.deltaTime;
            if (timer > offsetTime)
            {
                timer = 0f;
                powerUP.SetActive(true);
                if (!powerUP.tag.Equals("Life"))
                { 
                    powerUP.GetComponent<PowerUPSpeed>().AfterAbility(player);
                }
                
            }

        }
    }

    public static void SetActiveFalse(GameObject power)
    {
        power.SetActive(false);
    }

    public static void Rotate(GameObject powerUp)
    {
        powerUp.transform.Rotate(0, 0, rotation * Time.deltaTime);
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpController : MonoBehaviour
{
    public static float rotation = 90f;
    public static bool done = false;
    public List<GameObject> powerUps;
    private float timer = 0f;
    private float offsetTime = 2f;

    private void Update()
    {
        for (int i = 0; i < powerUps.Count; i++)
        { 
            
            if (!powerUps[i].activeSelf)
             {
                timer += Time.deltaTime;
                if (timer > offsetTime)
                {
                    timer = 0f;
                    powerUps[i].SetActive(true);
                    done = true;   
                }
                
            }
        }
    }

    public static void Rotate(GameObject powerUp)
    {
        powerUp.transform.Rotate(0, 0, rotation * Time.deltaTime);
    }
    
}

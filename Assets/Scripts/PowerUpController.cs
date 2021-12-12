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

    private void Start()
    {
        done = false;   
    }

    private void Update()
    {
        foreach (GameObject powerUp in powerUps)
        {
            
            Respawn(powerUp);
        }
    }

    private void Respawn(GameObject powerUP)
    {
        if (!powerUP.activeSelf)
        {
            Debug.Log(powerUP.name);
            timer += Time.deltaTime;
            if (timer > offsetTime)
            {
                timer = 0f;
                powerUP.SetActive(true);
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

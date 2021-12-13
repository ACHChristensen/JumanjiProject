using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttachmentsHandler : MonoBehaviour
{
    private int amountCoints;
    public bool lifeGained;
    private GameObject life;

    void Start()
    {
        lifeGained = false;
        amountCoints = 0;
    }

    public int getAmountOfCoint()
    {
        return amountCoints;
    }

    public void plusOneCoin() { 
        amountCoints++;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(message: "hej");
        if (other.gameObject.tag.Equals("Life")){
            lifeGained = true;
            Debug.Log(message: "nu er den: " + lifeGained);
            life = other.gameObject;
            other.gameObject.SetActive(false);
            other.gameObject.GetComponent<PowerUpController>().Respawn(life);
            Physics.SyncTransforms();

        }
    }

    public void SetLifeGained(bool lifeGained)
    {
        this.lifeGained = lifeGained;
    }
    public bool GetLifeGained()
    {
        return this.lifeGained;
    }

    public int GetAmountOfCoins()
    {
        return amountCoints;
    }
}

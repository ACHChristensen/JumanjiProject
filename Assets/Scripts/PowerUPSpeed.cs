using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUPSpeed : MonoBehaviour
{
    float oldSpeed;
    float newSpeed;
    private GameObject player;
    //private bool done;
    public bool powerUp;

    void Update()
    {
        PowerUpController.Rotate(this.gameObject);
        /*done = PowerUpController.done;
        if (!done)
        {
        }
        else if (done)
        {
            AfterAbility();
            done = false;
        }*/
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {   player = other.gameObject;
            oldSpeed = player.GetComponent<PlayerMovement>().GetSpeed();
            if (powerUp) { 
            newSpeed = 300f;
            }
            else if(!powerUp)
            {
                newSpeed = 75f;
            }
            Ability(player);
            PowerUpController.SetActiveFalse(this.gameObject);
        }
    }

    public void Ability(GameObject player)
    {   
        player.GetComponent<PlayerMovement>().SetSpeed(newSpeed);   
    }

    public void AfterAbility(GameObject player)
    {   
        player.GetComponent<PlayerMovement>().SetSpeed(oldSpeed);
        Physics.SyncTransforms();
    }

}

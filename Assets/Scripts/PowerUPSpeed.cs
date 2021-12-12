using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUPSpeed : MonoBehaviour
{
    float oldSpeed;
    float newSpeed;
    private GameObject player;
    private bool done;

    void Update()
    {
        PowerUpController.Rotate(this.gameObject);
        this.done = PowerUpController.done;
        if (done)
        {
            AfterAbility();
            done = false;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {   player = other.gameObject;
            oldSpeed = player.GetComponent<PlayerMovement>().GetSpeed();
            newSpeed = 300f;
            Ability(other.gameObject);
        }
    }

    public void Ability(GameObject player)
    {   
        player.GetComponent<PlayerMovement>().SetSpeed(newSpeed);
        this.gameObject.SetActive(false);   
    }

    public void AfterAbility()
    {
        player.GetComponent<PlayerMovement>().SetSpeed(oldSpeed);
        Physics.SyncTransforms();
    }

}

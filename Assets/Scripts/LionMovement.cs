using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LionMovement : MonoBehaviour
{
    private CharacterController controller;
    private float moveSpeed = 0.04f; //TODO - Make speed faster over time 
    private bool inRange;
    public GameObject player;
    public float distance;
    public GameObject health;
    private HealthController healthController;
    private int count;
    private GameObject track;
    private bool onTrack;

    void Start()
    {
        transform.position = new Vector3(-20, 0, -150);
        controller = GetComponent<CharacterController>();
        healthController = health.GetComponent<HealthController>();
        inRange = false; 
        onTrack = false;
        count = 0;
    }

    void Update()
    {   
        Vector3 playerPosition = player.transform.position;
        this.distance = Vector3.Distance(gameObject.transform.position, playerPosition);

        if (!inRange && !onTrack)
        {
            controller.Move(Vector3.forward * moveSpeed);
        }
        else if (!inRange) {
            gameObject.transform.position = Vector3.MoveTowards(controller.transform.position, track.transform.position, moveSpeed);
        }
        else

        { gameObject.transform.position = Vector3.MoveTowards(controller.transform.position, playerPosition, moveSpeed);

        }
        if (this.distance < 1)
        {
            count++;
            if(count == 1 && healthController.healthPoints>0) 
            { 
                    healthController.SetHP(healthController.healthPoints - 1);
                    StartCoroutine(DamageWaiter());
            }
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag.Equals("Player"))
        {
            onTrack = false;
            inRange = true;
        }
        else if (other.gameObject.tag.Equals("FieldTrack"))
        {
            
            track = other.gameObject;
            onTrack = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            inRange = false;
        }
        if (other.gameObject.tag.Equals("FieldTrack"))
        {
            onTrack = false;
        }
    }

    private IEnumerator DamageWaiter()
    {   
        yield return new WaitForSeconds(2);
        count = 0;
    }

}

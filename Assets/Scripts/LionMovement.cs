using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LionMovement : MonoBehaviour
{
    private CharacterController controller;
    private float moveSpeed = 0.01f; //TODO - Make speed faster over time 
    private bool inRange;
    public float distance;
    public GameObject health;
    private HealthController healthController;
    private int count;
    private GameObject track;
    private GameObject player;
    private NavMeshAgent navM;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        gameObject.transform.position = new Vector3 (-40, 0, -1);
        controller = GetComponent<CharacterController>();
        healthController = health.GetComponent<HealthController>();
        inRange = false; 
        count = 0;
        navM = GetComponent<NavMeshAgent>(); 
    }


    void FixedUpdate()
    {   
        Vector3 playerPosition = player.transform.position;
        distance = Vector3.Distance(gameObject.transform.position, playerPosition);
        //if (track.name==null) {
        //navM.Move(Vector3.back*Time.deltaTime);
        navM.SetDestination(playerPosition);
        /*}
        else
        { */
           // gameObject.transform.position = Vector3.MoveTowards(controller.transform.position, track.transform.position, moveSpeed);
        /*
        }*/
        if (distance < 1f)
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
        /*if (other.gameObject.tag.Equals("FieldTrack") && !inRange)
        {
            track = other.gameObject;
        }*/
       if (other.gameObject.tag.Equals("Player"))
        { 
            //track.GetComponent<Collider>().enabled=false;
            inRange = true;

        } 
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            inRange = false;
            //track.name = null;
            //track.GetComponent<Collider>().enabled = true;
        }
    }

    private IEnumerator DamageWaiter()
    {   
        yield return new WaitForSeconds(2);
        count = 0;
    }

}

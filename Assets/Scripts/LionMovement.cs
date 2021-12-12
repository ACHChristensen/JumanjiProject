using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LionMovement : MonoBehaviour
{
    private float moveSpeed; 
    public float distance;
    public GameObject health;
    private HealthController healthController;
    private int count;
    private int countSpeed;
    private GameObject player;
    public NavMeshAgent navM;
    private float gravity = -3f;

    void Start()
    {
        navM = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        navM.transform.position = new Vector3(-40,-3,2);
        navM.transform.rotation = Quaternion.Euler(0f, 90f, 0f);
  
        healthController = health.GetComponent<HealthController>();
        count = 0;
        moveSpeed = 5f;
        
    }


    void FixedUpdate()
    {   
        if(navM)
        {
            if (navM.hasPath)
            {
                navM.acceleration = (navM.remainingDistance < 4f) ? moveSpeed : 1f;
            }
        }
        Vector3 playerPosition = player.transform.position;
        distance = Vector3.Distance(navM.transform.position, playerPosition);
        
        playerPosition.y += gravity * Time.deltaTime;
            navM.SetDestination(playerPosition);
        
        Vector3 deltaPosition = new Vector3(playerPosition.x - navM.transform.position.x, 0.0f, playerPosition.z - navM.transform.position.z);
        Quaternion rotation = Quaternion.LookRotation(deltaPosition);
        navM.transform.rotation = rotation;   
        if (distance < 2f)
        { 
            count++;
            
            if (count == 1 && healthController.GetHP() > 0)
            {
                healthController.SetHP(healthController.GetHP() - 1);
                
                StartCoroutine(DamageWaiter());
            }
        }

            if (Time.realtimeSinceStartup>60f && countSpeed == 0)
            {
                moveSpeed = moveSpeed + 0.5f;
                countSpeed++;
            }
            else if (Time.realtimeSinceStartup > 90f && countSpeed == 1)
            {
                moveSpeed = moveSpeed + 2f;
                countSpeed++;
            }

        navM.speed = moveSpeed;
        
    }

    private IEnumerator DamageWaiter()
    {   
        yield return new WaitForSeconds(3);
        count = 0;
    }

}

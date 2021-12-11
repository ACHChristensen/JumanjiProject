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
        player = GameObject.FindGameObjectWithTag("Player");
        gameObject.transform.position = new Vector3 (-40, 0, -1);
        gameObject.transform.rotation = Quaternion.Euler(0,90,0);
        healthController = health.GetComponent<HealthController>();
        count = 0;
        navM = GetComponent<NavMeshAgent>();
        moveSpeed = 3f;
    }


    void FixedUpdate()
    {   
        Vector3 playerPosition = player.transform.position;
        distance = Vector3.Distance(gameObject.transform.position, playerPosition);
        playerPosition.y += gravity * Time.deltaTime;
        navM.SetDestination(playerPosition);
        
        Vector3 deltaPosition = new Vector3(playerPosition.x - gameObject.transform.position.x, 0.0f, playerPosition.z - gameObject.transform.position.z);
        Quaternion rotation = Quaternion.LookRotation(deltaPosition);
        gameObject.transform.rotation = rotation;   
        if (distance < 2f)
        {
            count++;
            if (count == 1 && healthController.healthPoints > 0)
            {
                healthController.SetHP(healthController.healthPoints - 1);
                StartCoroutine(DamageWaiter());
            }
        }

            if (Time.realtimeSinceStartup>30f && countSpeed == 0)
            {
                moveSpeed = moveSpeed + 2f;
                countSpeed++;
            }
            if (Time.realtimeSinceStartup > 90f && countSpeed == 1)
            {
                moveSpeed = moveSpeed + 2f;
                countSpeed++;
            }

        navM.speed = moveSpeed;
    }

    private IEnumerator DamageWaiter()
    {   
        yield return new WaitForSeconds(2);
        count = 0;
    }

}

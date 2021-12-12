using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LionAnimationHandler : MonoBehaviour
{
    private Animator lionAnimator;
    private float horizontalAxis;
    private float verticalAxis;
    private LionMovement lionMovement;
    private NavMeshAgent navMeshAgent;
    public bool roarTime;

    void Start()
    {
        lionMovement = gameObject.GetComponent<LionMovement>();
        lionAnimator = gameObject.GetComponent<Animator>();
        navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
        horizontalAxis = 0;
        verticalAxis = 0;
        roarTime = false;
    }

    void Update()
    { 
        horizontalAxis = lionMovement.navM.velocity.x;
        verticalAxis =  lionMovement.navM.velocity.z;

        lionAnimator.SetFloat("horienzontal", horizontalAxis);
        lionAnimator.SetFloat("vertical", verticalAxis);

        if (navMeshAgent.acceleration <= 1f)
        {
            lionAnimator.SetTrigger("distanceClose");
            roarTime = true;            
        } else 
        {
            roarTime = false;
        }

    }
}

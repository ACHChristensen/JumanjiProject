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
    private int count;

    void Start()
    {
        lionMovement = gameObject.GetComponent<LionMovement>();
        lionAnimator = gameObject.GetComponent<Animator>();
        navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
        horizontalAxis = 0;
        verticalAxis = 0;
        count = 0;
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
            count++;
            
        } else if(count == 1 && navMeshAgent.acceleration > 1f)
        {
            lionAnimator.SetTrigger("noLongerClose");
            count--;
        }

    }
}

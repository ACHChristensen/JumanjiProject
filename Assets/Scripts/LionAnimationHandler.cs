using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LionAnimationHandler : MonoBehaviour
{
    private Animator lionAnimator;
    private float horizontalAxis;
    private float verticalAxis;
    private LionMovement lionMovement;

    void Start()
    {
        lionMovement = gameObject.GetComponent<LionMovement>();
        lionAnimator = gameObject.GetComponent<Animator>();
        horizontalAxis = 0;
        verticalAxis = 0;
    }

    void Update()
    {
        horizontalAxis = lionMovement.navM.velocity.x;
        verticalAxis =  lionMovement.navM.velocity.z;

        lionAnimator.SetFloat("horienzontal", horizontalAxis);
        lionAnimator.SetFloat("vertical", verticalAxis);
    }
}

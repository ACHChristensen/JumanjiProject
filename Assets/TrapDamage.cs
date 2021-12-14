using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapDamage : MonoBehaviour
{
    private GameObject health;
    private HealthController healthController;
    private SphereCollider trigger;

    private void Start()
    {
        trigger = gameObject.AddComponent<SphereCollider>();
        trigger.isTrigger = true;
        trigger.radius = 2f;
        health = GameObject.FindGameObjectWithTag("HP");
        healthController = health.GetComponent<HealthController>();
    }

    private void OnTriggerEnter(Collider col)
    {
        Debug.Log(message: "Her");
        if (col.gameObject.tag.Equals("Player"))
        {
           healthController.SetHP(healthController.GetHP()-1);
        }
    }

}

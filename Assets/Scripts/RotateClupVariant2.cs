using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateClupVariant2 : MonoBehaviour
{
    private float rotation = 60f;
    private Vector3 around;

    private void Start()
    {
        around = new Vector3(transform.position.x, transform.position.y+ 11 , transform.position.z);
    }

    void Update()
    {
        transform.RotateAround(around, Vector3.forward, rotation * Time.deltaTime);
    }
}

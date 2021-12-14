using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateClub : MonoBehaviour
{
    private float rotation = 30f;
    private Vector3 around;

    private void Start()
    {
        around = Vector3.zero ;
    }

    void Update()
    {
        transform.RotateAround(around, Vector3.right,rotation * Time.deltaTime);
    }
}

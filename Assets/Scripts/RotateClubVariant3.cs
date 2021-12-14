using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateClubVariant3 : MonoBehaviour
{
    private float rotation = 60f;
    private Vector3 around;

    private void Start()
    {
        around = new Vector3(transform.position.x, transform.position.y+3.5f, transform.position.z);
    }

    void Update()
    {
        transform.RotateAround(around, Vector3.left, rotation * Time.deltaTime);
    }
}

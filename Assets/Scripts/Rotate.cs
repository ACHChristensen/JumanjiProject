using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{

    private float rotation = 20f;
    
    void Update()
    {
        transform.Rotate(0, rotation * Time.deltaTime, 0);
    }
}

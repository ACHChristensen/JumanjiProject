using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUPSpeed : MonoBehaviour
{
    private float rotation = 90f;


    void Update()
    {
        transform.Rotate(0, 0, rotation * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            StartCoroutine(SpeedHandler(other.gameObject));
        }
    }

    public IEnumerator SpeedHandler(GameObject player)
    {   
        float oldSpeed = player.GetComponent<PlayerMovement>().GetSpeed();
        player.GetComponent<PlayerMovement>().SetSpeed(300f);
        this.gameObject.SetActive(false);
        yield return new WaitForSeconds(4);
        player.GetComponent<PlayerMovement>().SetSpeed(oldSpeed);
        this.gameObject.SetActive(true);

    }
}

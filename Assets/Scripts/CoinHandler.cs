using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinHandler : MonoBehaviour
{
    private float rotation = 90f;
    private bool coinAchieved;
    
    void Update()
    {
        transform.Rotate(0, 0, rotation * Time.deltaTime);
        if (coinAchieved) {
            StartCoroutine(CoinSpawnWait());
        }
        coinAchieved = false;   
    }

    private void OnTriggerEnter(Collider other)
    {
        //TODO - Handling in wrong spawning coins/keys

        /*if (other.gameObject != null)
        {
            Destroy(gameObject);
            return;
        }*/
    }

    private void OnTriggerExit(Collider other)
    {
        
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerAttachmentsHandler>().plusOneCoin();
            coinAchieved=true;
        }
    }

    private IEnumerator CoinSpawnWait()
    {
       gameObject.SetActive(false);
       yield return new WaitForSecondsRealtime(5);
       gameObject.SetActive(true);
    }

}

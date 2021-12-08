using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinHandler : MonoBehaviour
{
    private bool coinAchieved;
    public GameObject coin;
    private Coin coinScript;
    
    void Update()
    {
        coinScript = coin.GetComponent<Coin>();
        coinAchieved = coinScript.coinAchieved;
        //coin.transform.Rotate(0, 0, rotation * Time.deltaTime);
        if (coinAchieved) {
            StartCoroutine(CoinSpawnWait());
        }
          
    }

    

    /*private void OnTriggerExit(Collider other)
    {
        
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerAttachmentsHandler>().plusOneCoin();
            coinAchieved=true;
        }
    }*/

    private IEnumerator CoinSpawnWait()
    {
       coin.SetActive(false);
       yield return new WaitForSeconds(3);
       coin.SetActive(true);
        coinScript.SetCoinAchieved(false);
    }

}

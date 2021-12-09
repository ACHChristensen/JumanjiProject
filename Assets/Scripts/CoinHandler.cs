using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinHandler : MonoBehaviour
{
    private bool coinAchieved;
    public GameObject coinPrefab;
    public List<Collider> colliders;
    private List<GameObject> coins;

    private void Start()
    {

        int amount;
        coins = new List<GameObject>();
        foreach (var collider in colliders) 
        {
            amount = 50;
            if (collider.gameObject.name.Equals("TrackSphere"))
            {
                amount = 10;
            }
            /* Vector3 size = collider.transform.localScale;*/
           
            for (int i = 0; i < amount; i++)
            {
                GameObject coin= Instantiate(coinPrefab);
                coin.transform.position = GetRandomPointInCollider(collider);
                coins.Add(coin);
            }
        }
    }

    private Vector3 GetRandomPointInCollider(Collider collider)
    { 
        Vector3 position = collider.transform.localPosition;
        Bounds size = collider.bounds;
        
        Vector3 randomPointInCollider = new Vector3(Random.Range(collider.bounds.min.x, size.max.x) , -4 + position.y, Random.Range(size.min.z, size.max.z) );
       
        return randomPointInCollider;
    
    }

    /*void Update()
    {   foreach (GameObject coin in coins) { 
        coinAchieved = coin.GetComponent<Coin>().GetCoinAchieved();
        if (coinAchieved) {
            StartCoroutine(CoinSpawnWait(coin));
        }
         }
    }*/


    public IEnumerator CoinSpawnWait(GameObject coin)
    {   //coin.gameObject.GetComponent<Collider>().enabled = false;
       coin.SetActive(false);
       yield return new WaitForSeconds(6);
       //coin.GetComponent<Coin>().SetCoinAchieved(false);
        //coin.gameObject.GetComponent<Collider>().enabled = true;
        coin.SetActive(true);
        
    }

}

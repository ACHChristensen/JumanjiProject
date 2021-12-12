using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinHandler : MonoBehaviour
{
    public GameObject coinPrefab;
    public List<Collider> colliders;
    private List<GameObject> coins;
    private float timer = 0f;
    private float offsetTime = 4f;
    public static bool done = false;

    private void Start()
    {

        int amount;
        coins = new List<GameObject>();
        foreach (var collider in colliders) 
        {
            amount = 50;
            if (collider.gameObject.tag.Equals("TrackSphere"))
            {
                amount = 15;
            }
            
            for (int i = 0; i < amount; i++)
            {
                GameObject coin= Instantiate(coinPrefab);
                coin.transform.position = GetRandomPointInCollider(collider);
                coins.Add(coin);
            }
        }
    }

    private void Update()
    {
        foreach (GameObject coin in coins)
        {
            Respawn(coin);
        }
    }

    private void Respawn(GameObject coin) { 
        if (!coin.activeSelf)
        {
            timer += Time.deltaTime;
            if (timer > offsetTime)
            {
                timer = 0f;
                coin.SetActive(true);
                done = true;   
            }
                
        }
    }
    private Vector3 GetRandomPointInCollider(Collider collider)
    { 
        Vector3 position = collider.transform.localPosition;
        Bounds size = collider.bounds;
        
        Vector3 randomPointInCollider = new Vector3(Random.Range(collider.bounds.min.x, size.max.x) , Random.Range(collider.bounds.min.y, size.max.y-1), Random.Range(size.min.z, size.max.z) );
       
        return randomPointInCollider;
    
    }


    /*void Update()
    {   foreach (GameObject coin in coins) { 
        coinAchieved = coin.GetComponent<Coin>().GetCoinAchieved();
        if (coinAchieved) {
            StartCoroutine(CoinSpawnWait(coin));
        }
         }
    }
*/

    public void CoinSpawnWait(GameObject coin)
    {   //coin.gameObject.GetComponent<Collider>().enabled = false;
       coin.SetActive(false);
      /* yield return new WaitForSeconds(6);
       //coin.GetComponent<Coin>().SetCoinAchieved(false);
        //coin.gameObject.GetComponent<Collider>().enabled = true;
        coin.SetActive(true);
        */
    }

}

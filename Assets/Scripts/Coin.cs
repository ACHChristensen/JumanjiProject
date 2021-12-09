using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private bool coinAchieved;
    private float rotation = 90f;
    public CoinHandler coinHandler;
    void Start()
    {
        coinHandler = GameObject.Find("CoinHandler").GetComponent<CoinHandler>();
        coinAchieved = false;
    }

    void Update()
    {
        transform.Rotate(0, 0, rotation * Time.deltaTime);
        
    }

    private void OnTriggerStay(Collider other)
    {
        
        
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag.Equals("Player") /*&& !coinAchieved*/)
        {
            other.gameObject.GetComponent<PlayerAttachmentsHandler>().plusOneCoin();
            StartCoroutine(coinHandler.CoinSpawnWait(this.gameObject));
            //coinAchieved = true;
        }
        /*if (other.gameObject.layer.Equals("Terrain") || other.gameObject.tag.Equals("Wooden"))
        {
            Destroy(gameObject);
        }*/
       
    }

    public void SetCoinAchieved(bool achieved)
    {
        this.coinAchieved = achieved;
    }

    public bool GetCoinAchieved()
    {
       return this.coinAchieved;
    }
}

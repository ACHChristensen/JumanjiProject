using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public bool coinAchieved;
    private float rotation = 90f;
    void Start()
    {
        coinAchieved = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, rotation * Time.deltaTime);
        
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
            coinAchieved = true;
        }
       
    }

    public void SetCoinAchieved(bool achieved)
    {
        this.coinAchieved = achieved;
    }
}

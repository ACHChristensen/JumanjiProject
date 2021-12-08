using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ServerUIHandling : MonoBehaviour
{
    public GameObject lion;
    private Text distanceFromLion;
    private float lionDistance;
    [SerializeField] private GameObject player;
    private PlayerAttachmentsHandler playerItems;
    private Text amountCoints;
    [SerializeField] private GameObject cointCounter;
    public GameObject stick;
    public GameObject jumpButton;
    public GameObject barUI;
    public GameObject coinLogo;
    private Color whiteTransparent;
    void Start()
    {
        distanceFromLion = GetComponentInChildren<Text>();
        playerItems = player.GetComponent<PlayerAttachmentsHandler>();
        amountCoints = cointCounter.GetComponent<Text>();   
    }

    void FixedUpdate()
    {
        LionDistance();
        CointsManagement();
        coinLogo.transform.Rotate(Vector3.down * 50 * Time.deltaTime, Space.World); 
    }

    private void CointsManagement()
    {
        amountCoints.text = "x " + playerItems.getAmountOfCoint();
    }

    private void LionDistance()
    {
        lionDistance = (lion.GetComponent<LionMovement>().distance)/3;
        if((int)lionDistance == 0 )
        {
            distanceFromLion.text = "Lion: <" + (int)lionDistance + " m";
        }
        else { 
        distanceFromLion.text = "Lion: "+ (int)lionDistance +" m";
        }
        if (lionDistance <= 5)
        {
            distanceFromLion.color = Color.red;
            barUI.GetComponent<RawImage>().color = Color.Lerp(distanceFromLion.color, Color.clear, 0.5f);
        }
        else if (lionDistance <= 20)
        {   
            distanceFromLion.color = Color.yellow;
            barUI.GetComponent<RawImage>().color = Color.Lerp(distanceFromLion.color, Color.clear, 0.5f);
        }
        else
        {
            distanceFromLion.color = Color.white;
            whiteTransparent = distanceFromLion.color ;
            whiteTransparent.a = 0.3f;
            barUI.GetComponent<RawImage>().color = whiteTransparent;
        }

        ClientUpdate(distanceFromLion.color);
        
    }

    private void ClientUpdate(Color color)
    {
        stick.GetComponent<Image>().color = color;

        jumpButton.GetComponent<Image>().color = color;
    }
}

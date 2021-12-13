using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ServerUIHandling : MonoBehaviour
{
    public GameObject lionPrefab;
    private GameObject lion;
    public Text distanceFromLion;
    private float lionDistance;
    private float startDistance;
    [SerializeField] private GameObject player;
    private PlayerAttachmentsHandler playerItems;
    private Text amountCoints;
    [SerializeField] private GameObject cointCounter;
    public GameObject stick;
    public GameObject jumpButton;
    public GameObject barUI;
    public GameObject coinLogo;
    private Color whiteTransparent;
    private bool lionSpawned;
    [SerializeField] private GameObject lionUIHandler;
    [SerializeField] private GameObject startPoint;
    void Start()
    {
        distanceFromLion = lionUIHandler.GetComponentInChildren<Text>();
        playerItems = player.GetComponent<PlayerAttachmentsHandler>();
        amountCoints = cointCounter.GetComponent<Text>();
        lionSpawned = false;
        lionUIHandler.SetActive(false);
    }

    void FixedUpdate()
    {
        
        startDistance = Vector3.Distance(startPoint.transform.position, player.transform.position);
       
        if (startDistance > 12 && !lionSpawned) {
            lion = Instantiate<GameObject>(lionPrefab,startPoint.transform);
            lionSpawned=true;
        }
        else if (lionSpawned) {
            lionUIHandler.SetActive(true);
            LionDistance();
        }
        CointsManagement();
        coinLogo.transform.Rotate(Vector3.down * 50 * Time.deltaTime, Space.World); 
    }

    private void CointsManagement()
    {
        amountCoints.text = "x " + playerItems.getAmountOfCoint();
    }

    private void LionDistance()
    {
        lionDistance = (lion.GetComponent<LionMovement>().distance);
        if((int)lionDistance == 0 )
        {
            distanceFromLion.text = "<" + (int)lionDistance + " m";
        }
        else { 
        distanceFromLion.text =  + (int)lionDistance +" m";
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

        ClientUIUpdate(distanceFromLion.color);
        
    }

    private void ClientUIUpdate(Color color)
    {
        stick.GetComponent<Image>().color = color;

        jumpButton.GetComponent<Image>().color = color;
    }
}

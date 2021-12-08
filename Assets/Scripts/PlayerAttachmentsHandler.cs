using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttachmentsHandler : MonoBehaviour
{
    private int amountCoints;
    
    void Start()
    {
        amountCoints = 0;
    }

    public int getAmountOfCoint()
    {
        return amountCoints;
    }

    public void plusOneCoin() { 
        amountCoints++;
    }
}

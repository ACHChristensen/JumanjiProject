using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundHandler : MonoBehaviour
{
    [SerializeField] private AudioClip music;
    [SerializeField] private bool muted;
    [SerializeField] private AudioSource lionRawl;
    [SerializeField] private GameObject UIHandler;
    private Text LionUI;

    void Start()
    {
        muted = true;
        LionUI = UIHandler.GetComponent<ServerUIHandling>().distanceFromLion;
    }

    void FixedUpdate()
    {   
        if(LionUI.color.Equals(Color.red))
        {
            if (!lionRawl.isPlaying)
            {
                //lionRawl.mute = false;
                //lionRawl.Play();
            }
        } else
        {
            lionRawl.mute=true;
        }
    }

    public void SetMutedState(bool muted)
    {
        this.muted = muted; 
    }
}

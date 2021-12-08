using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundHandler : MonoBehaviour
{
    [SerializeField] private AudioClip soundPlayer;
    [SerializeField] private bool muted;
    [SerializeField] private AudioClip lionRawl;
    [SerializeField] private ServerUIHandling LionUI;
    private AudioSource sound;

    // Start is called before the first frame update
    void Start()
    {
        muted = true;
        
        LionUI = new ServerUIHandling();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(LionUI.distanceFromLion.text.Equals(Color.red))
        {
            sound = new AudioSource();
            sound.clip = lionRawl;
            if (!sound.isPlaying)
            {
                sound.Play();
            }
        }
    }

    public void SetMutedState(bool muted)
    {
        this.muted = muted; 
    }
}

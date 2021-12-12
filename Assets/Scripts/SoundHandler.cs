using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundHandler : MonoBehaviour
{
    [SerializeField] private AudioClip music;
    [SerializeField] private bool muted;
    [SerializeField] private AudioSource lionRawl;
    [SerializeField] private GameObject lion;
    private LionAnimationHandler lionAnimator;

    void Start()
    {
        muted = true;
        lionAnimator = lion.GetComponent<LionAnimationHandler>();
      
    }

    void FixedUpdate()
    {
        if (lionAnimator.roarTime)
        {
            if (!lionRawl.isPlaying)
            {
                lionRawl.mute = false;
                lionRawl.Play();
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

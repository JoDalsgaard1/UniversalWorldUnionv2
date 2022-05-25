using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] private AudioClip[] leftClips;
    [SerializeField] private AudioClip[] rightClips;
    private bool lastPlayedClipLeft = false;


    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Step(AnimationEvent animationEvent)
    {
        if (animationEvent.animatorClipInfo.weight > 0.5)
        {
            if (lastPlayedClipLeft == false)
            {
                AudioClip clip = GetRandomLeftClip();
                audioSource.PlayOneShot(clip);
                lastPlayedClipLeft = true;
                Debug.Log("played left clip");
            }
            if (lastPlayedClipLeft == true)
            {
                AudioClip clip = GetRandomRightClip();
                audioSource.PlayOneShot(clip);
                lastPlayedClipLeft = false;
                Debug.Log("played right clip");
            }
            
        }
    }
    
    private AudioClip GetRandomLeftClip()
    {
        return leftClips[UnityEngine.Random.Range(0, leftClips.Length)];
    }
    private AudioClip GetRandomRightClip()
    {
        return rightClips[UnityEngine.Random.Range(0, rightClips.Length)];
    }
}

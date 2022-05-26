using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSoundsHandler : MonoBehaviour
{
    [SerializeField] private AudioClip[] turnOnClips;
    [SerializeField] private AudioClip[] turnOffClips;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void TurnOn()
    {
        AudioClip clip = GetRandomOnClip();
        audioSource.PlayOneShot(clip);
    }

    public void TurnOff()
    {
        AudioClip clip = GetRandomOffClip();
        audioSource.PlayOneShot(clip);
    }

    private AudioClip GetRandomOnClip()
    {
        return turnOnClips[UnityEngine.Random.Range(0, turnOnClips.Length)];
    }

    private AudioClip GetRandomOffClip()
    {
        return turnOffClips[UnityEngine.Random.Range(0, turnOffClips.Length)];
    }
}

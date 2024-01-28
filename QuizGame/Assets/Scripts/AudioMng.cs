using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMng : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip correctSound;
    [SerializeField] private AudioClip WrongSound;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>(); // Gets the AudioSource compennet in the object
    }

    public void PlayCorrectSoundEfect() 
    {
        audioSource.PlayOneShot(correctSound);
    }

    public void PlayWrongtSoundEfect()
    {
        audioSource.PlayOneShot(WrongSound);
    }
}

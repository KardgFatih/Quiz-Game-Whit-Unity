using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AudioMng : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip correctSound;
    [SerializeField] private AudioClip WrongSound;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundScript : MonoBehaviour
{
    public AudioSource audioSource;
    public void playSound(AudioClip sound)
    {
        audioSource.PlayOneShot(sound, 1f);
    }
}

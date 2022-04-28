using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioClip music;
    static AudioSource audioSrc;

    void Start()
    {
        music = Resources.Load<AudioClip>("");

        audioSrc = GetComponent<AudioSource>();
    }

    public static void PlaySound()
    {
        audioSrc.PlayOneShot(music);
    }
}

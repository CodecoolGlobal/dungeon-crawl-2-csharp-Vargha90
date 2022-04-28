using System.Collections;
using System.Collections.Generic;
using DungeonCrawl.Core;
using UnityEditor;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioClip level1, level2, stoneStep, grassStep, hitSkeleton, hitSpider, deathSkeleton, deathSpider, birds, river;
    static AudioSource audioSrc;

    void Start()
    {
        level1 = Resources.Load<AudioClip>("level1_background");
        level2 = Resources.Load<AudioClip>("level2_background");
        stoneStep = Resources.Load<AudioClip>("step_stone");
        grassStep = Resources.Load<AudioClip>("step_grass");
        hitSkeleton = Resources.Load<AudioClip>("hit_skeleton");
        deathSkeleton = Resources.Load<AudioClip>("death_skeleton");
        hitSpider = Resources.Load<AudioClip>("hit_spider");
        deathSpider = Resources.Load<AudioClip>("death_spider");
        birds = Resources.Load<AudioClip>("birds");
        river = Resources.Load<AudioClip>("river");

        audioSrc = GetComponent<AudioSource>();
    }

    public static void StopBGMusic()
    {
        audioSrc.Stop();
    }

    public static void PlayBGM(string sound)
    {
        switch (sound)
        {
            case "level_1":
                audioSrc.PlayOneShot(level1);
                break;
            case "level_2":
                audioSrc.PlayOneShot(level2);
                break;
        }
        
    }

    public static void PlayAmbiante(string sound)
    {
        switch (sound)
        {
            case "birds":
                audioSrc.PlayOneShot(birds);
                break;
            case "river":
                audioSrc.PlayOneShot(river);
                break;
        }

    }

    public static void PlayStepSound()
    {
        if (MapLoader.MapId == 1)
        {
            audioSrc.PlayOneShot(stoneStep);
        }
        else if (MapLoader.MapId == 2)
        {
            audioSrc.PlayOneShot(grassStep);
        }
    }

    public static void PlayHitSound(string enemyType)
    {
        switch (enemyType)
        {
            case "skeleton":
                audioSrc.PlayOneShot(hitSkeleton);
                break;
            case "spider":
                audioSrc.PlayOneShot(hitSpider);
                break;
        }
    }

    public static void PlayDeathSound(string enemyType)
    {
        switch (enemyType)
        {
            case "skeleton":
                audioSrc.PlayOneShot(deathSkeleton);
                break;
            case "spider":
                audioSrc.PlayOneShot(deathSpider);
                break;
        }
    }
}

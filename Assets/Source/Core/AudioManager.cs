using System.Collections;
using System.Collections.Generic;
using DungeonCrawl.Core;
using UnityEditor;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioClip level1, level2, stoneStep, grassStep, hitSkeleton, hitSpider, deathSkeleton, deathSpider, birds, river, wrongWay, collect, transfer, deathPlayer, kefka, game_over;
    static AudioSource audioSrc;
    public static AudioManager Singleton;

    public void Awake()
    {
        if (Singleton != null)
        {
            Destroy(this);
            return;
        }

        Singleton = this;

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
        wrongWay = Resources.Load<AudioClip>("wrong_way");
        collect = Resources.Load<AudioClip>("pick_up");
        transfer = Resources.Load<AudioClip>("transfer");
        deathPlayer = Resources.Load<AudioClip>("death_player");
        kefka = Resources.Load<AudioClip>("kefka_laugh");
        game_over = Resources.Load<AudioClip>("game_over");

        audioSrc = GetComponent<AudioSource>();
    }

    public void StopBGMusic()
    {
        audioSrc.Stop();
    }

    public void PlayBGM(string sound)
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

    public void PlayAmbiante(string sound)
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

    public void PlayStepSound(string floorType)
    {
        if (floorType == "stone")
        {
            audioSrc.PlayOneShot(stoneStep);
        }
        else if (floorType == "grass")
        {
            audioSrc.PlayOneShot(grassStep);
        }
    }

    public void PlayActionSound(string actionType)
    {
        switch (actionType)
        {
            case "collect":
                audioSrc.PlayOneShot(collect);
                break;
            case "transfer":
                audioSrc.PlayOneShot(transfer);
                break;
        }
    }

    public void PlayHitSound(string enemyType)
    {
        switch (enemyType)
        {
            case "skeleton":
                audioSrc.PlayOneShot(hitSkeleton);
                break;
            case "spider":
                audioSrc.PlayOneShot(hitSpider);
                break;
            case "boss":
                audioSrc.PlayOneShot(kefka);
                break;
        }
    }

    public void PlayDeathSound(string enemyType)
    {
        switch (enemyType)
        {
            case "skeleton":
                audioSrc.PlayOneShot(deathSkeleton);
                break;
            case "spider":
                audioSrc.PlayOneShot(deathSpider);
                break;
            case "player":
                audioSrc.PlayOneShot(deathPlayer);
                break;
            case "game_over":
                Debug.Log("here");
                audioSrc.PlayOneShot(game_over);
                break;
        }
    }

    public void PlayVocal(string say)
    {
        switch (say)
        {
            case "no":
                audioSrc.PlayOneShot(wrongWay);
                break;
        }
    }


}

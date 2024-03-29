﻿using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Assets.Source.Actors.Characters;
using Assets.Source.Actors.Static;
using Assets.Source.Core;
using DungeonCrawl.Core;
using UnityEngine;

namespace DungeonCrawl.Actors.Characters
{
    public class Player : Character
    {
        public bool timerRunning = true;
        private float countdown = 20;
        public static int getZ = -2;
        public override char Symbol => 'p';
        public override int DefaultSpriteId => 24;
        public override string DefaultName => "Player";

        protected override void Awake()
        {
            base.Awake();
            SetHealth(100);
            InvokeRepeating(nameof(Movement), 0.09f, 0.09f);
        }

        protected override void OnUpdate()
        {
            if (MapLoader.MapId == 2 && timerRunning)
            {
                countdown -= Time.smoothDeltaTime;
                if (countdown <= 0)
                {
                    this.OnDeath("DEAD HAHAHAHAHA");
                    timerRunning = false;
                }
            }
            else if (MapLoader.MapId == 1)
            {
                countdown = 10;
                timerRunning = true;
            }
        }


        protected void Movement()
        {
            UserInterface.Singleton.SetText("Health: " + Health.ToString(), UserInterface.TextPosition.TopLeft);
            if (Input.GetKey(KeyCode.W))
            {
                // Move up
                TryMove(Direction.Up);
                CameraController.Singleton.Position = this.Position;
                //Debug.Log(Position);
            }

            if (Input.GetKey(KeyCode.S))
            {
                // Move down
                TryMove(Direction.Down);
                CameraController.Singleton.Position = this.Position;
                //Debug.Log(Position);
            }

            if (Input.GetKey(KeyCode.A))
            {
                // Move left
                TryMove(Direction.Left);
                CameraController.Singleton.Position = this.Position;
                //Debug.Log(Position);
            }

            if (Input.GetKey(KeyCode.D))
            {
                // Move right
                TryMove(Direction.Right);
                CameraController.Singleton.Position = this.Position;
                //Debug.Log(Position);
            }

            if (Input.GetKey(KeyCode.E))
            {
                // Pick up or interact
                Item item = ActorManager.Singleton.GetActorAt<Item>((Position.x, Position.y, -1));
                if (item != null)
                {
                    AudioManager.Singleton.PlayActionSound("collect");
                    ActorManager.Singleton.DestroyActor(item);
                }
            }

            if (Input.GetKey(KeyCode.K))
            {
                HandleJson.GetEachActor();
            }

            if (Input.GetKey(KeyCode.L))
            {
                HandleJson.ReadFromJson();
            }
        }

        public override bool OnCollision(Actor anotherActor)
        {
            if (anotherActor is Skeleton)
            {
                SetStrength(2);
                ApplyDamage(Strength);
            }
            else if (anotherActor is Spider)
            {
                SetStrength(5);
                ApplyDamage(Strength);
            }
            else if (anotherActor is Boss)
            {
                anotherActor.transform.localScale = new Vector2(1f, 1f);
                anotherActor.transform.localPosition = new Vector2(21f, -23f);

                ////Debug.Log("YOU CAN'T KILL ME FOOL!");
            }
            return false;
        }

        protected override void OnDeath()
        {
            AudioManager.Singleton.PlayDeathSound("player");
            UserInterface.Singleton.SetText("Health: 0", UserInterface.TextPosition.TopLeft);
            UserInterface.Singleton.SetText("YOU DIED...", UserInterface.TextPosition.MiddleCenter);
            Debug.Log("Oh no, I'm dead!");
        }

        protected override void OnDeath(string deathMessage)
        {
            SetHealth(0);
            UserInterface.Singleton.SetText(deathMessage, UserInterface.TextPosition.MiddleCenter);
            ActorManager.Singleton.DestroyActor(this);
            AudioManager.Singleton.StopBGMusic();
            AudioManager.Singleton.PlayDeathSound("game_over");
            Debug.Log("Oh no, the Boss killed me :(");
        }
    }
}

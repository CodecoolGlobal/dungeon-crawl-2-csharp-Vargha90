﻿using Assets.Source.Actors.Characters;
using Assets.Source.Actors.Static;
using Assets.Source.Core;
using DungeonCrawl.Core;
using UnityEngine;

namespace DungeonCrawl.Actors.Characters
{
    public class Player : Character
    {
        protected override void Awake()
        {
            base.Awake();
            SetHealth(100);
        }

        protected override void OnUpdate(float deltaTime)
        {
            UserInterface.Singleton.SetText("Health: " + Health.ToString(), UserInterface.TextPosition.TopLeft);
            if (Input.GetKeyDown(KeyCode.W))
            {
                // Move up
                TryMove(Direction.Up);
                CameraController.Singleton.Position = this.Position;
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                // Move down
                TryMove(Direction.Down);
                CameraController.Singleton.Position = this.Position;
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                // Move left
                TryMove(Direction.Left);
                CameraController.Singleton.Position = this.Position;
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                // Move right
                TryMove(Direction.Right);
                CameraController.Singleton.Position = this.Position;
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                // Pick up or interact
                Item item = ActorManager.Singleton.GetActorAt<Item>(Position);
                if (item != null)
                {
                    ActorManager.Singleton.DestroyActor(item);
                }
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
            return false;
        }

        protected override void OnDeath()
        {
            UserInterface.Singleton.SetText("Health: 0", UserInterface.TextPosition.TopLeft);
            UserInterface.Singleton.SetText("YOU DIED...", UserInterface.TextPosition.MiddleCenter);
            Debug.Log("Oh no, I'm dead!");
        }

        //public void SetPosition((int x, int y) position)
        //{
        //    PlayerPosition = position;
        //}

        public override int DefaultSpriteId => 24;
        public override string DefaultName => "Player";
    }
}

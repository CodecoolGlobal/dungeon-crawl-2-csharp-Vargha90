using Assets.Source.Actors.Characters;
using Assets.Source.Actors.Static;
using Assets.Source.Core;
using DungeonCrawl.Core;
using UnityEngine;

namespace DungeonCrawl.Actors.Characters
{
    public class Player : Character
    {
        public static int getZ = -2;
        public override int DefaultSpriteId => 24;
        public override string DefaultName => "Player";

        protected override void Awake()
        {
            base.Awake();
            SetHealth(100);
        }

        protected override void OnUpdate(float deltaTime)
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

            if (Input.GetKeyDown(KeyCode.E))
            {
                // Pick up or interact
                Item item = ActorManager.Singleton.GetActorAt<Item>((Position.x, Position.y, -1));
                if (item != null)
                {
                    AudioManager.PlayActionSound("collect");
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
            AudioManager.PlayDeathSound("player");
            UserInterface.Singleton.SetText("Health: 0", UserInterface.TextPosition.TopLeft);
            UserInterface.Singleton.SetText("YOU DIED...", UserInterface.TextPosition.MiddleCenter);
            Debug.Log("Oh no, I'm dead!");
        }
    }
}

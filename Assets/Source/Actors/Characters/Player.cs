using Assets.Source.Actors.Static;
using DungeonCrawl.Core;
using UnityEngine;

namespace DungeonCrawl.Actors.Characters
{
    public class Player : Character
    {
        //private (int x, int y) PlayerPosition;

        protected override void OnUpdate(float deltaTime)
        {
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

            //if (Input.GetKeyDown(KeyCode.E))
            //{
            //    // Pick up or interact
            //    Item item = ActorManager.Singleton.GetActorAt<Item>(Position);
            //    PlayerPosition = item.Position;
            //    if (item != null)
            //    {
            //        Debug.Log(item.DefaultName);
            //        ActorManager.Singleton.DestroyActor(item);
            //    }
            //}
        }

        public override bool OnCollision(Actor anotherActor)
        {
            return false;
        }

        protected override void OnDeath()
        {
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

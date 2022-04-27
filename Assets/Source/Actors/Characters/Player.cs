using Assets.Source.Actors.Static;
using Assets.Source.Core;
using DungeonCrawl.Core;
using UnityEngine;

namespace DungeonCrawl.Actors.Characters
{
    public class Player : Character
    {
        protected override void OnUpdate(float deltaTime)
        {
            UserInterface.Singleton.SetText("Health: " + Health.ToString(), UserInterface.TextPosition.TopLeft);
            if (Input.GetKeyDown(KeyCode.W))
            {
                // Move up
                TryMove(Direction.Up);
                Debug.Log(Health);
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                // Move down
                TryMove(Direction.Down);
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                // Move left
                TryMove(Direction.Left);
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                // Move right
                TryMove(Direction.Right);
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                // Pick up or interact
                Item item = ActorManager.Singleton.GetActorAt<Item>(Position);
                if (item != null)
                {
                    Debug.Log(item.DefaultName);
                    ActorManager.Singleton.DestroyActor(item);
                }
            }
        }

        public override bool OnCollision(Actor anotherActor)
        {
            if (anotherActor is Skeleton)
            {
                ApplyDamage(2);
            }
            return false;
        }

        protected override void OnDeath()
        {
            Debug.Log("Oh no, I'm dead!");
        }

        public override int DefaultSpriteId => 24;
        public override string DefaultName => "Player";
    }
}

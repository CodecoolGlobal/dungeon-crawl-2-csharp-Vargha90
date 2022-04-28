using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using DungeonCrawl.Core;
using UnityEngine;

namespace DungeonCrawl.Actors.Characters
{
    public class Skeleton : Character
    {
        public static int getZ = -1;
        protected override void Awake()
        {
            base.Awake();
            SetHealth(30);
            SetStrength(5);
        }

        protected override void OnUpdate(float deltaTime)
        {
            if (Input.GetKeyDown(KeyCode.W) ||
                Input.GetKeyDown(KeyCode.S) ||
                Input.GetKeyDown(KeyCode.A) ||
                Input.GetKeyDown(KeyCode.D) ||
                Input.GetKeyDown(KeyCode.E))
            {
                (int x, int y, int z) playerPosition = GetPlayerPosition(GetCoordinatesAroundSkeleton());
                if (playerPosition != (Position.x, Position.y, Position.z))
                {
                    var playerActor = ActorManager.Singleton.GetActorAt(playerPosition);
                    playerActor.OnCollision(this);
                }
            }
        }

        private List<(int x, int y, int z)> GetCoordinatesAroundSkeleton()
        {
            List<(int x, int y, int z)> aroundSkeleton = new List<(int x, int y, int z)>();
            (int x, int y, int z) skeletonPosition = (Position.x, Position.y, Position.z);

            aroundSkeleton.Add((skeletonPosition.x + 1, skeletonPosition.y, skeletonPosition.z));
            aroundSkeleton.Add((skeletonPosition.x - 1, skeletonPosition.y, skeletonPosition.z));
            aroundSkeleton.Add((skeletonPosition.x, skeletonPosition.y + 1, skeletonPosition.z));
            aroundSkeleton.Add((skeletonPosition.x, skeletonPosition.y - 1, skeletonPosition.z));

            return aroundSkeleton;
        }

        private (int x, int y, int z) GetPlayerPosition(List<(int x, int y, int z)> aroundSkeleton)
        {
            foreach (var position in aroundSkeleton)
            {
                if (ActorManager.Singleton.GetActorAt(position) is Player)
                {
                    return position;
                }
            }

            return (Position.x, Position.y, Position.z);
        }

        public override bool OnCollision(Actor anotherActor)
        {
            ApplyDamage(Strength);
            return false;
        }

        protected override void OnDeath()
        {
            Debug.Log("Well, I was already dead anyway...");
        }

        public override int DefaultSpriteId => 316;
        public override string DefaultName => "Skeleton";
    }
}

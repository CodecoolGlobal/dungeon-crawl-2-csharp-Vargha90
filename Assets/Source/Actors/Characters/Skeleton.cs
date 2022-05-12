using System.Collections.Generic;
using DungeonCrawl.Core;
using UnityEngine;

namespace DungeonCrawl.Actors.Characters
{
    public class Skeleton : Character
    {
        public static int getZ = -2;
        public override int DefaultSpriteId => 316;
        public override string DefaultName => "Skeleton";
        protected override void Awake()
        {
            base.Awake();
            SetHealth(30);
            SetStrength(5);
            InvokeRepeating(nameof(Attack), 0.2f, 0.2f);
        }

        

        protected void Attack()
        {
            (int x, int y, int z) playerPosition = GetPlayerPosition(GetSurroundingCoordinates());
            if (playerPosition != (Position.x, Position.y, Position.z))
            {
                var playerActor = ActorManager.Singleton.GetActorAt(playerPosition);
                playerActor.OnCollision(this);
            }
        }

        //private List<(int x, int y, int z)> GetCoordinatesAroundSkeleton()
        //{
        //    List<(int x, int y, int z)> aroundSkeleton = new List<(int x, int y, int z)>();
        //    (int x, int y, int z) skeletonPosition = (Position.x, Position.y, Position.z);

        //    aroundSkeleton.Add((skeletonPosition.x + 1, skeletonPosition.y, skeletonPosition.z));
        //    aroundSkeleton.Add((skeletonPosition.x - 1, skeletonPosition.y, skeletonPosition.z));
        //    aroundSkeleton.Add((skeletonPosition.x, skeletonPosition.y + 1, skeletonPosition.z));
        //    aroundSkeleton.Add((skeletonPosition.x, skeletonPosition.y - 1, skeletonPosition.z));

        //    return aroundSkeleton;
        //}

        //private (int x, int y, int z) GetPlayerPosition(List<(int x, int y, int z)> aroundSkeleton)
        //{
        //    foreach (var position in aroundSkeleton)
        //    {
        //        if (ActorManager.Singleton.GetActorAt(position) is Player)
        //        {
        //            return position;
        //        }
        //    }

        //    return (Position.x, Position.y, Position.z);
        //}

        public override bool OnCollision(Actor anotherActor)
        {
            ApplyDamage(Strength);
            AudioManager.PlayHitSound("skeleton");
            return false;
        }

        protected override void OnDeath()
        {
            AudioManager.PlayDeathSound("skeleton");
            Debug.Log("Well, I was already dead anyway...");
        }

        
    }
}

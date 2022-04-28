using System;
using System.Collections.Generic;
using DungeonCrawl;
using DungeonCrawl.Actors;
using DungeonCrawl.Actors.Characters;
using DungeonCrawl.Actors.Static;
using DungeonCrawl.Core;
using UnityEngine;
using Random = System.Random;

namespace Assets.Source.Actors.Characters
{
    internal class Spider : Character
    {
        public static int getZ = -1;
        protected override void Awake()
        {
            base.Awake();
            SetHealth(50);
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
                GetDirectionToMove();
            }
        }

        private void GetDirectionToMove()
        {
            Random random = new Random();
            Array values = Enum.GetValues(typeof(Direction));

            (int x, int y, int z) spiderPosition = (Position.x, Position.y, Position.z);
            List<(int x, int y, int z)> aroundSpider = GetCoordinatesAroundSpider(spiderPosition, 2);
            (int x, int y, int z) playerPosition = GetPlayerPosition(aroundSpider);

            if (spiderPosition == playerPosition)
            {
                Direction randomDirection = (Direction)values.GetValue(random.Next(values.Length));
                TryMove(randomDirection);
            }
            else
            {
                if (spiderPosition.x < playerPosition.x)
                {
                    TryMove(Direction.Right);
                }
                else if (spiderPosition.x > playerPosition.x)
                {
                    TryMove(Direction.Left);
                }
                else if (spiderPosition.y < playerPosition.y)
                {
                    TryMove(Direction.Up);
                }
                else if (spiderPosition.y > playerPosition.y)
                {
                    TryMove(Direction.Down);
                }
            }
        }

        protected override void TryMove(Direction direction)
        {
            (int x, int y, int z) vector = direction.ToVector();
            (int x, int y, int z) targetPosition = (Position.x + vector.x, Position.y + vector.y, Position.z);
            var actorAtTargetPosition = ActorManager.Singleton.GetActorAt(targetPosition);

            if (actorAtTargetPosition is Wall ||
                actorAtTargetPosition is Skeleton)
            {
                Position = Position;
            }
            else if (actorAtTargetPosition is Player)
            {
                //OnCollision(actorAtTargetPosition);
                actorAtTargetPosition.OnCollision(this);
            }
            else
            {
                Position = targetPosition;
            }
        }

        private (int x, int y, int z) GetPlayerPosition(List<(int x, int y, int z)> aroundSpider)
        {
            foreach (var position in aroundSpider)
            {
                if (ActorManager.Singleton.GetActorAt(position) is Player)
                {
                    return position;
                }
            }

            return (Position.x, Position.y, Position.z);
        }

        private List<(int x, int y, int z)> GetCoordinatesAroundSpider((int x, int y, int z) spiderPosition, int rangeToCheck)
        {
            List<(int x, int y, int z)> aroundSpider = new List<(int x, int y, int z)>();
            List<int> xCoordinates = new List<int> {spiderPosition.x};
            List<int> yCoordinates = new List<int> {spiderPosition.y};

            for (int i = 1; i <= rangeToCheck; i++)
            {
                xCoordinates.Add(spiderPosition.x + i);
                xCoordinates.Add(spiderPosition.x - i);
                yCoordinates.Add(spiderPosition.y + i);
                yCoordinates.Add(spiderPosition.y - i);
            }

            foreach (int xCoordinate in xCoordinates)
            {
                foreach (int yCoordinate in yCoordinates)
                {
                    aroundSpider.Add((xCoordinate, yCoordinate,Position.z));
                }
            }

            aroundSpider.Remove((spiderPosition.x, spiderPosition.y, spiderPosition.z));

            return aroundSpider;
        }

        public override bool OnCollision(Actor anotherActor)
        {
            AudioManager.PlayHitSound("spider");
            ApplyDamage(Strength);
            return false;
        }

        protected override void OnDeath()
        {
            AudioManager.PlayDeathSound("spider");
            Debug.Log("Well, I was already dead anyway...");
        }

        public override int DefaultSpriteId => 267;
        public override string DefaultName => "Spider";
    }
}

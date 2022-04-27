using System;
using System.Collections.Generic;
using DungeonCrawl;
using DungeonCrawl.Actors;
using DungeonCrawl.Actors.Characters;
using DungeonCrawl.Core;
using UnityEngine;
using Random = System.Random;

namespace Assets.Source.Actors.Characters
{
    internal class Spider : Character
    {
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

            (int x, int y) spiderPosition = (Position.x, Position.y);
            List<(int x, int y)> aroundSpider = GetCoordinatesAroundSpider(spiderPosition, 2);
            (int x, int y) playerPosition = GetPlayerPosition(aroundSpider);

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
            (int x, int y) vector = direction.ToVector();
            (int x, int y) targetPosition = (Position.x + vector.x, Position.y + vector.y);

            var actorAtTargetPosition = ActorManager.Singleton.GetActorAt(targetPosition);

            if (actorAtTargetPosition == null)
            {
                Position = targetPosition;
            }

        }

        private (int x, int y) GetPlayerPosition(List<(int x, int y)> aroundSpider)
        {
            foreach (var position in aroundSpider)
            {
                if (ActorManager.Singleton.GetActorAt(position) is Player)
                {
                    return position;
                }
            }

            return (Position.x, Position.y);
        }

        private List<(int x, int y)> GetCoordinatesAroundSpider((int x, int y) spiderPosition, int rangeToCheck)
        {
            List<(int x, int y)> aroundSpider = new List<(int x, int y)>();
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
                    aroundSpider.Add((xCoordinate, yCoordinate));
                }
            }

            aroundSpider.Remove((spiderPosition.x, spiderPosition.y));

            return aroundSpider;
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

        public override int DefaultSpriteId => 267;
        public override string DefaultName => "Spider";
    }
}

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
                TryMove(GetRandomDirection());
            }
        }

        private Direction GetRandomDirection()
        {
            Random random = new Random();
            Array values = Enum.GetValues(typeof(Direction));
            Direction randomDirection = (Direction)values.GetValue(random.Next(values.Length));
            return randomDirection;
        }

        protected override void TryMove(Direction direction)
        {
            (int x, int y) vector = direction.ToVector();
            (int x, int y) targetPosition = (Position.x + vector.x, Position.y + vector.y);
            (int x, int y) spiderPosition = (Position.x, Position.y);

            var  aroundSpider = GetCoordinatesAroundSpider(spiderPosition, 2);
            bool isPlayerAroundMe = CheckIfPlayerInRange(aroundSpider);

            Debug.Log(isPlayerAroundMe);

            var actorAtTargetPosition = ActorManager.Singleton.GetActorAt(targetPosition);
            var self = ActorManager.Singleton.GetActorAt(spiderPosition);
        }

        private bool CheckIfPlayerInRange(List<(int x, int y)> aroundSpider)
        {
            foreach (var position in aroundSpider)
            {
                if (ActorManager.Singleton.GetActorAt(position) is Player)
                {
                    return true;
                }
            }

            return false;
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

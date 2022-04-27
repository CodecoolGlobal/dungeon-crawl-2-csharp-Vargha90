using System;
using DungeonCrawl;
using DungeonCrawl.Actors;
using DungeonCrawl.Actors.Characters;
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
            Direction randomDirection = (Direction) values.GetValue(random.Next(values.Length));
            return randomDirection;
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

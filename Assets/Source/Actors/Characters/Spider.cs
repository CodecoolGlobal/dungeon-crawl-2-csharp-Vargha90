using System;
using DungeonCrawl.Actors;
using DungeonCrawl.Actors.Characters;
using UnityEngine;

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

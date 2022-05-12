using Assets.Source.Core;
using DungeonCrawl.Actors;
using DungeonCrawl.Actors.Characters;
using UnityEngine;

namespace Assets.Source.Actors.Characters
{
    internal class Boss : Character
    {
        public static int getZ = -2;
        // 707 for targetPlayer && 708 for PlayerDead
        public override int DefaultSpriteId => 706;

        public override string DefaultName => "Boss";

        protected override void OnDeath()
        {
            UserInterface.Singleton.SetText("Noooo, you can't kill me!", UserInterface.TextPosition.MiddleCenter);
        }

        private void Start()
        {
            var sprite = GetComponent<SpriteRenderer>();
            sprite.color = Color.red;
        }

        public override bool OnCollision(Actor anotherActor)
        {
            if (anotherActor == this)
            {
                transform.localScale = new Vector2(2f, 2f);
            }
            transform.localScale = new Vector2(1f, 1f);
            return false;
        }
    }
}

using Assets.Source.Core;
using DungeonCrawl;
using DungeonCrawl.Actors;
using DungeonCrawl.Actors.Characters;
using DungeonCrawl.Core;
using UnityEngine;


namespace Assets.Source.Actors.Characters
{
    internal class Boss : Character
    {
        public static int getZ = -2;
        // 707 for targetPlayer && 708 for PlayerDead
        public override char Symbol => 'b';
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
            transform.localScale = new Vector2(15f, 15f);
            transform.position = new Vector2(Utilities.random.Next(18, 28), Utilities.random.Next(-28, -18));
            Debug.Log("HAHAHA");
            return false;
        }

        protected void Attack()
        {
            (int x, int y, int z) playerPosition = GetPlayerPosition(GetSurroundingCoordinates());
            //Debug.Log(playerPosition);
            if (playerPosition != (Position.x, Position.y, Position.z))
            {
                var playerActor = ActorManager.Singleton.GetActorAt(playerPosition);
                playerActor.OnCollision(this);
            }
        }

        protected override void OnUpdate()
        {
            Attack();
        }
    }
}

using DungeonCrawl.Core;
using System.Collections.Generic;

namespace DungeonCrawl.Actors.Characters
{
    public abstract class Character : Actor
    {
        public int Health { get; private set; }
        public int Strength { get; private set; }

        protected void SetStrength(int strength)
        {
            Strength = strength;
        }

        protected void SetHealth(int health)
        {
            Health = health;
        }

        public void ApplyDamage(int damage)
        {
            Health -= damage;

            if (Health <= 0)
            {
                // Die
                OnDeath();

                ActorManager.Singleton.DestroyActor(this);
            }
        }

        protected abstract void OnDeath();
        protected virtual void OnDeath(string deathMessage) => System.Console.WriteLine("nope");

        /// <summary>
        ///     All characters are drawn "above" floor etc
        /// </summary>
        public override int Z => -2;

        protected virtual List<(int x, int y, int z)> GetSurroundingCoordinates()
        {
            List<(int x, int y, int z)> aroundActor = new List<(int x, int y, int z)>();
            (int x, int y, int z) actorPosition = (Position.x, Position.y, Position.z);

            aroundActor.Add((actorPosition.x + 1, actorPosition.y, actorPosition.z));
            aroundActor.Add((actorPosition.x - 1, actorPosition.y, actorPosition.z));
            aroundActor.Add((actorPosition.x, actorPosition.y + 1, actorPosition.z));
            aroundActor.Add((actorPosition.x, actorPosition.y - 1, actorPosition.z));

            return aroundActor;
        }

        protected virtual (int x, int y, int z) GetPlayerPosition(List<(int x, int y, int z)> aroundEnemy)
        {
            foreach (var position in aroundEnemy)
            {
                if (ActorManager.Singleton.GetActorAt(position) is Player)
                {
                    return position;
                }
            }

            return (Position.x, Position.y, Position.z);
        }

    }
}

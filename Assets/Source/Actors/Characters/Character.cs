using DungeonCrawl.Core;

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

    }
}

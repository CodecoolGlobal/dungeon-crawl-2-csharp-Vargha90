using DungeonCrawl.Actors;

namespace Assets.Source.Actors.Static
{
    internal class River : Actor
    {
        public override int DefaultSpriteId => 247;

        public override string DefaultName => "River";

        public static int getZ = -2;

        public override bool OnCollision(Actor anotherActor)
        {
            return false;
        }
    }
}

using DungeonCrawl.Actors;

namespace Assets.Source.Actors.Static
{
    internal class Tree : Actor
    {
        public override int DefaultSpriteId => 52;

        public override char Symbol => '+';

        public override string DefaultName => "Tree";

        public static int getZ = -2;
        public override bool OnCollision(Actor anotherActor)
        {
            return false;
        }
    }
}

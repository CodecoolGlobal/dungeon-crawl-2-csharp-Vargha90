using DungeonCrawl.Actors;

namespace Assets.Source.Actors.Static
{
    internal class Tree : Actor
    {
        public override int DefaultSpriteId => 52;

        public override string DefaultName => "Tree";

        public override bool Detectable => false;

        public static int getZ = -1;
    }
}

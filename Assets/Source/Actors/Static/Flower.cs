using DungeonCrawl.Actors;

namespace Assets.Source.Actors.Static
{
    internal class Flower : Actor
    {
        public static int getZ = 0;
        public override int DefaultSpriteId => 667;

        public override string DefaultName => "Flower";

        public override bool Detectable => true;
    }
}

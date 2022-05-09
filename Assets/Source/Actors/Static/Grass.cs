using DungeonCrawl.Actors;

namespace Assets.Source.Actors.Static
{
    internal class Grass : Actor
    {
        public static int getZ = 0;
        public override int DefaultSpriteId => 546;

        public override string DefaultName => "Grass";

        public override bool Detectable => true;
    }
}

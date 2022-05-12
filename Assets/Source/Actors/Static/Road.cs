using DungeonCrawl.Actors;

namespace Assets.Source.Actors.Static
{
    internal class Road : Actor
    {
        public static int getZ = 0;

        public override char Symbol => '|';
        public override int DefaultSpriteId => 533;

        public override string DefaultName => "Road";

        public override bool Detectable => true;
    }
}

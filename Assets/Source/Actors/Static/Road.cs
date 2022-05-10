using DungeonCrawl.Actors;

namespace Assets.Source.Actors.Static
{
    internal class Road : Actor
    {
        public override int DefaultSpriteId => 533;

        public override string DefaultName => "Road";

        public override bool Detectable => false;
    }
}

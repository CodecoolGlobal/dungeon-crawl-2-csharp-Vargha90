using DungeonCrawl.Actors;

namespace Assets.Source.Actors.Static
{
    internal class Bridge : Actor
    {
        public override int DefaultSpriteId => 684;

        public override string DefaultName => "Bridge";

        public override bool Detectable => false;
    }
}

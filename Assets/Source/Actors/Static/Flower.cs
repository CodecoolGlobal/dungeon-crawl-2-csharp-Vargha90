using DungeonCrawl.Actors;

namespace Assets.Source.Actors.Static
{
    internal class Flower : Actor
    {
        public override int DefaultSpriteId => 667;

        public override string DefaultName => "Flower";

        public override bool Detectable => false;
    }
}

using DungeonCrawl.Actors;

namespace Assets.Source.Actors.Static
{
    internal class Grass : Actor
    {
        public override int DefaultSpriteId => 546;

        public override string DefaultName => "Grass";

        public override bool Detectable => false;
    }
}

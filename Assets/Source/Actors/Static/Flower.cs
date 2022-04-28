using DungeonCrawl.Actors;

namespace Assets.Source.Actors.Static
{
    internal class Flower : Actor
    {
        public override int DefaultSpriteId => throw new System.NotImplementedException();

        public override string DefaultName => "Flower";

        public override bool Detectable => false;
    }
}

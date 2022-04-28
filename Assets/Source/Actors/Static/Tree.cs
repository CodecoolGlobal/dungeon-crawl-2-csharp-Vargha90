using DungeonCrawl.Actors;

namespace Assets.Source.Actors.Static
{
    internal class Tree : Actor
    {
        public override int DefaultSpriteId => throw new System.NotImplementedException();

        public override string DefaultName => "Tree";

        public override bool Detectable => false;
    }
}

using DungeonCrawl.Actors;
using System;

namespace Assets.Source.Actors.Static
{
    internal class Grass : Actor
    {
        public override int DefaultSpriteId => throw new NotImplementedException();

        public override string DefaultName => "Grass";

        public override bool Detectable => false;
    }
}

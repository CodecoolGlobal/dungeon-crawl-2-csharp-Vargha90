using DungeonCrawl.Actors;
using System;

namespace Assets.Source.Actors.Static
{
    internal class Bridge : Actor
    {
        public override int DefaultSpriteId => throw new NotImplementedException();

        public override string DefaultName => "Bridge";

        public override bool Detectable => false;
    }
}

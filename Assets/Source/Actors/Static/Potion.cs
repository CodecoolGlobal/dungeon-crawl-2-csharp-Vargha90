using System;
using DungeonCrawl.Actors;

namespace Assets.Source.Actors.Static
{
    internal class Potion : Actor
    {
        public override int DefaultSpriteId => 945;

        public override string DefaultName => "Chunk of Meat";

        public override int Z => -1;
    }
}

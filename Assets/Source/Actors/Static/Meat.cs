﻿using DungeonCrawl.Actors;

namespace Assets.Source.Actors.Static
{
    public sealed class Meat : Item
    {
        public override int DefaultSpriteId => 945;

        public override char Symbol => 'm';

        public override string DefaultName => "Chunk of Meat";

        public static int getZ = -1;

    }
}

﻿using DungeonCrawl.Actors;

namespace Assets.Source.Actors.Static
{
    internal class Gate : Actor
    {
        public static int getZ = -2;
        public override char Symbol => '&';
        public override int DefaultSpriteId => 540;
        public override string DefaultName => "Gate";
    }
}

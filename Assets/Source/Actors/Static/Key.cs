using DungeonCrawl.Actors;

namespace Assets.Source.Actors.Static
{
    public sealed class Key : Item
    {
        public override int DefaultSpriteId => 559;

        public override char Symbol => 'k';

        public override string DefaultName => "Key";

        public static int getZ = -1;
    }
}

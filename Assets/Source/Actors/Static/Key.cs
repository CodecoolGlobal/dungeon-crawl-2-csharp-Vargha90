using DungeonCrawl.Actors;

namespace Assets.Source.Actors.Static
{
    public sealed class Key : Item
    {
        public override int DefaultSpriteId => 559;

        public override string DefaultName => "Key";

        public override string Description => "For closed doors. Or open ones. Depends on your intentions I guess.";
        public static int getZ = -1;
    }
}

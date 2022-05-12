using DungeonCrawl.Actors;

namespace Assets.Source.Actors.Static
{
    internal class Stairs : Actor
    {
        public static int getZ = -2;
        public override char Symbol => 'g';
        public override int DefaultSpriteId => 289;
        public override string DefaultName => "Stairs";
    }
}

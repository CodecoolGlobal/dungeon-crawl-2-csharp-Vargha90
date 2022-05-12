using DungeonCrawl.Actors;

namespace Assets.Source.Actors.Static
{
    public sealed class Meat : Item
    {
        public override int DefaultSpriteId => 945;

        public override string DefaultName => "Chunk of Meat";

        public override string Description => "Boar? Lamb? Beef? Who knows? But it's fresh!";

        public static int getZ = -1;
    }
}

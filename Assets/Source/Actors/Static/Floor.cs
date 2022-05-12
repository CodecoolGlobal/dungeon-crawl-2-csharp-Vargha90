namespace DungeonCrawl.Actors.Static
{
    public class Floor : Actor
    {
        public static int getZ = 0;

        public override char Symbol => '.';
        public override int DefaultSpriteId => 1;
        public override string DefaultName => "Floor";

        public override bool Detectable => true;
    }
}

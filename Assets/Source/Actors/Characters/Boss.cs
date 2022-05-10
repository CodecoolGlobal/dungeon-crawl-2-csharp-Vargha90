using Assets.Source.Core;
using DungeonCrawl.Actors.Characters;

namespace Assets.Source.Actors.Characters
{
    internal class Boss : Character
    {
        public static int getZ = -1;
        // 707 for targetPlayer && 708 for PlayerDead
        public override int DefaultSpriteId => 706;

        public override string DefaultName => "Boss";

        protected override void OnDeath()
        {
            UserInterface.Singleton.SetText("Noooo, you can't kill me!", UserInterface.TextPosition.MiddleCenter);
        }
    }
}

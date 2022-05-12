using DungeonCrawl.Actors;
using UnityEngine;

namespace Assets.Source.Actors.Static
{
    internal class Grass : Actor
    {
        SpriteRenderer sprite;

        public static int getZ = 0;

        public override char Symbol => '.';
        public override int DefaultSpriteId => 546;

        public override string DefaultName => "Grass";

        public override bool Detectable => true;

        private void Start()
        {
            sprite = GetComponent<SpriteRenderer>();
            sprite.color = new Color (0, 0.4433962f, 0.1089446f, 1);
        }

    }
}

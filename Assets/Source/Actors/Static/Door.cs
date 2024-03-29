﻿using DungeonCrawl.Actors;
using DungeonCrawl.Actors.Characters;

namespace Assets.Source.Actors.Static
{
    internal class Door : Actor
    {
        private bool _open = false;

        public bool Open { get { return _open; } private set { _open = value; } }

        public override int DefaultSpriteId => 438;

        public override string DefaultName => "Door";

        public override int Z => -1;

        public override char Symbol => 'd';

        public override bool OnCollision(Actor anotherActor)
        {
            if (anotherActor.GetType() == typeof(Player))
            {
                OpenDoor();
            }
            return _open;
        }

        public void OpenDoor()
        {
            SetSprite(440);
            _open = true;
        }
    }
}

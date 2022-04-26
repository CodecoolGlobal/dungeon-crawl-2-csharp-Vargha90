using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonCrawl.Actors;
using DungeonCrawl.Actors.Static;

namespace Assets.Source.Actors.Static
{
    internal class Door : Actor
    {
        public override int DefaultSpriteId => 441;

        public override string DefaultName => "Door";

        public override int Z => -1;
    }
}

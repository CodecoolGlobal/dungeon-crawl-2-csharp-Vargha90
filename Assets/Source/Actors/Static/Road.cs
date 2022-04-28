using DungeonCrawl.Actors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Source.Actors.Static
{
    internal class Road : Actor
    {
        public override int DefaultSpriteId => throw new NotImplementedException();

        public override string DefaultName => "Road";

        public override bool Detectable => false;
    }
}

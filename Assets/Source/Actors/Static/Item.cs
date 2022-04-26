using System;
using DungeonCrawl.Actors;

namespace Assets.Source.Actors.Static
{
    public abstract class Item : Actor
    {
        public virtual int Quantity => 1;
    }
}

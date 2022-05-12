using System;
using UnityEngine;
using DungeonCrawl.Actors;

namespace Assets.Source.Actors.Static
{
    public abstract class Item : Actor
    {
        public virtual int Quantity => 1;

        public virtual string Description => "item";

        public StashedItem CreateStashedItemObject()
        {
            StashedItem newItem = ScriptableObject.CreateInstance<StashedItem>();
            newItem.SpriteID = this.DefaultSpriteId;
            newItem.Name = this.DefaultName;
            newItem.Description = this.Description;

            return newItem;
        }
    }
}

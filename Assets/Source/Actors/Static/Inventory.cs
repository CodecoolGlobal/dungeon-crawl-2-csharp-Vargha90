using UnityEngine;
using DungeonCrawl.Core;
using DungeonCrawl.Actors.Characters;
using System.Linq;
using System;
using System.Collections.Generic;
using Assets.Source.Core;

namespace Assets.Source.Actors.Static
{
    public class Inventory : ScriptableObject
    {
        public HashSet<Slot> AllSlots = new();
        public Player Owner;
        public int SlotLimit = 15;


        public void AddItem(Item item)
        {
            Slot newSlot = new();
            StashedItem stashedItem = item.CreateStashedItemObject();
            newSlot.StashItem(stashedItem);
            AllSlots.Add(newSlot);
            ActorManager.Singleton.DestroyActor(item);
            foreach (Slot slot in AllSlots)
            {
                Debug.Log(slot.item.Name);
            }
        }
    }

    [Serializable]
    public class Slot
    {
        public StashedItem item;
        public int quantity;

        public void StashItem(StashedItem pickedUpItem)
        {
            item = pickedUpItem;
            quantity += 1;
        }
    }
}

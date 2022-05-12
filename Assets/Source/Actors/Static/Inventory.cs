using UnityEngine;
using DungeonCrawl.Core;
using DungeonCrawl.Actors.Characters;
using System.Linq;
using System;
using System.Collections.Generic;

namespace Assets.Source.Actors.Static
{
    public class Inventory : ScriptableObject
    {
        public HashSet<Slot> _allSlots = new();
        public Player _owner;
        public int _slotLimit = 15;


        public void AddItem(Item item)
        {
            Slot newSlot = new();
            newSlot.StashItem(item);
            _allSlots.Add(newSlot);
            ActorManager.Singleton.DestroyActor(item);
            foreach (Slot slot in _allSlots)
            {
                Debug.Log(slot.item.DefaultName);
            }
        }
    }

    [Serializable]
    public class Slot
    {
        [SerializeField] public Item item;
        [SerializeField] public int quantity;

        public void StashItem(Item pickedUpItem)
        {
            item = pickedUpItem;
            quantity += 1;
        }
    }
}

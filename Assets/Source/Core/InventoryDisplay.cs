using Assets.Source.Actors.Static;
using DungeonCrawl.Actors.Characters;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Source.Core
{
    public class InventoryDisplay : MonoBehaviour
    {
        private Inventory _inventory;

        public void Awake()
        {

        }

        public void Update()
        {
            if (Input.GetKeyUp(KeyCode.Alpha5))
            {
                GameObject playerObject = GameObject.Find("Player");
                _inventory = playerObject.GetComponent<Player>().InventoryObject;
                DisplayAllItems();
            }
        }
        public void DisplayAllItems()
        {
            foreach (Slot slot in _inventory.AllSlots)
                Debug.Log(slot.item.Name);
        }
    }
}

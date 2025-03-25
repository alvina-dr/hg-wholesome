using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;
using static PlayerInventory;

public class PlayerInventory : MonoBehaviour
{
    [ReadOnly]
    public List<ItemEntry> ItemDataList = new();

    public void AddItem(ItemEntry itemEntry)
    {
        ItemEntry _inventoryEntry = ItemDataList.Find(x => x.Item == itemEntry.Item);
        if (_inventoryEntry != null) 
        {
            _inventoryEntry.Number += itemEntry.Number;
        }
        else
        {
            ItemDataList.Add(itemEntry);
        }
    }

    public void RemoveItem(ItemEntry itemEntry)
    {
        ItemEntry _inventoryEntry = ItemDataList.Find(x => x.Item == itemEntry.Item);
        if (_inventoryEntry != null)
        {
            _inventoryEntry.Number -= itemEntry.Number;
        }
        else
        {
            Debug.LogError("trying to delete something the player does not have");
        }
    }

    public bool HasItem(ItemEntry itemEntry)
    {
        ItemEntry _inventoryEntry = ItemDataList.Find(x => x.Item == itemEntry.Item);
        if (_inventoryEntry != null)
        {
            return _inventoryEntry.Number >= itemEntry.Number;
        }
        else return false;
    }

    [System.Serializable]
    public class ItemEntry
    {
        public ItemData Item;
        public int Number;

        public ItemEntry(ItemData item, int number)
        {
            Item = item;
            Number = number;
        }
    }
}

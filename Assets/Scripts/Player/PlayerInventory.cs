using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;
using static PlayerInventory;

public class PlayerInventory : MonoBehaviour
{
    [ReadOnly]
    public List<ItemEntry> ItemEntryList = new();
    public int Money;

    public void AddItem(ItemEntry itemEntry)
    {
        ItemEntry _inventoryEntry = ItemEntryList.Find(x => x.Item == itemEntry.Item);
        if (_inventoryEntry != null) 
        {
            _inventoryEntry.Number += itemEntry.Number;
        }
        else
        {
            ItemEntryList.Add(itemEntry);
        }
    }

    public void RemoveItem(ItemEntry itemEntry)
    {
        ItemEntry _inventoryEntry = ItemEntryList.Find(x => x.Item == itemEntry.Item);
        if (_inventoryEntry != null)
        {
            _inventoryEntry.Number -= itemEntry.Number;

            if (_inventoryEntry.Number <= 0)
            {
                ItemEntryList.Remove(_inventoryEntry);
            }
        }
        else
        {
            Debug.LogError("trying to delete something the player does not have");
        }
    }

    public void AddMoney(int money)
    {
        Money += money; 
        GameManager.Instance.UIManager.MoneyText.SetTextValue(Money.ToString());
    }

    public void RemoveMoney(int money)
    {
        Money -= money;
        GameManager.Instance.UIManager.MoneyText.SetTextValue(Money.ToString());
    }

    public bool HasItem(ItemEntry itemEntry)
    {
        ItemEntry _inventoryEntry = ItemEntryList.Find(x => x.Item == itemEntry.Item);
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

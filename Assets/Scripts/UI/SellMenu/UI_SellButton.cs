using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_SellButton : MonoBehaviour
{
    public bool ToSell;
    public PlayerInventory.ItemEntry ItemEntry;
    [SerializeField] private List<GameObject> _sellingGOList;
    [SerializeField] private TextMeshProUGUI _number;
    [SerializeField] private Image _itemImage;

    public void ChangeSellMode()
    {
        ToSell = !ToSell;

        UpdateVisual();
    }

    public void SetupVisual(PlayerInventory.ItemEntry itemEntry)
    {
        ItemEntry = itemEntry;
        _number.text = itemEntry.Number.ToString();
        _itemImage.sprite = itemEntry.Item.ItemSprite;
        UpdateVisual();
    }

    public void UpdateVisual()
    {
        if (ToSell)
        {
            for (int i = 0; i < _sellingGOList.Count; i++)
            {
                _sellingGOList[i].SetActive(true);
            }
        }
        else
        {
            for (int i = 0; i < _sellingGOList.Count; i++)
            {
                _sellingGOList[i].SetActive(false);
            }
        }
    }
}

using System.Collections.Generic;
using UnityEngine;

public class UI_SellMenu : MonoBehaviour
{
    private List<UI_SellButton> _sellButtonList = new();
    [SerializeField] private UI_SellButton _sellButtonPrefab;
    [SerializeField] private Transform _gridLayout;

    public void UpdateVisual()
    {
        for (int i = 0; i < _sellButtonList.Count; i++)
        {
            Destroy(_sellButtonList[i].gameObject);
        }

        _sellButtonList.Clear();

        for (int i = 0; i < GameManager.Instance.Player.PlayerInventory.ItemEntryList.Count; i++)
        {
            UI_SellButton sellButton = Instantiate(_sellButtonPrefab , _gridLayout);
            sellButton.SetupVisual(GameManager.Instance.Player.PlayerInventory.ItemEntryList[i]);
            _sellButtonList.Add(sellButton);
        }
    }

    public void Open()
    {
        UpdateVisual();
        gameObject.SetActive(true);

    }

    public void Close()
    {
        gameObject.SetActive(false);
    }

    public void Sell()
    {
        List<UI_SellButton> buttonToSellList = _sellButtonList.FindAll(x => x.ToSell);

        if (buttonToSellList.Count == 0) return;

        for (int i = 0; i < buttonToSellList.Count; i++)
        {
            GameManager.Instance.Player.PlayerInventory.RemoveItem(buttonToSellList[i].ItemEntry);
        }

        gameObject.SetActive(false);
    }
}

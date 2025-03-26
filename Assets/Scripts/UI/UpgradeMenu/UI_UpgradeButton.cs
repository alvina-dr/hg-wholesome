using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UI_UpgradeButton : MonoBehaviour
{
    public int UpgradeIndex;
    public List<Upgrade> UpgradeList = new();

    public void BuyUpgrade()
    {
        if (GameManager.Instance.Player.PlayerInventory.Money < UpgradeList[UpgradeIndex].Cost) return;

        GameManager.Instance.Player.PlayerInventory.RemoveMoney(UpgradeList[UpgradeIndex].Cost);
        UpgradeIndex++;
    }

    [System.Serializable]
    public class Upgrade
    {
        public UnityEvent UpgradeEvent;
        public int Cost;
    }
}

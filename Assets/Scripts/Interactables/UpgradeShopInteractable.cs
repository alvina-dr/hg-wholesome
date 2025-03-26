using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UpgradeShopInteractable : Interactable
{
    public override void Interact()
    {
        base.Interact();
        GameManager.Instance.UIManager.UpgradeMenu.Open();
    }

    public List<UnityEvent> UpgradeList = new();

    public void UpgradeSlotNumber()
    {

    }
}

using UnityEngine;

public class ShopInteractable : Interactable
{
    public override void Interact()
    {
        base.Interact();
        GameManager.Instance.UIManager.SellMenu.Open();
    }
}

using UnityEngine;

public class Buyable : Interactable
{
    public GameObject CollectableToActivate;
    public int Price;

    public override void Interact()
    {
        base.Interact();
        Debug.Log("interact with SIGN");

        if (GameManager.Instance.Player.PlayerInventory.Money >= Price)
        {
            gameObject.SetActive(false);
            CollectableToActivate.SetActive(true);
            GameManager.Instance.UIManager.TextPopperManager.PopText("-" + Price.ToString(), Camera.main.WorldToScreenPoint(transform.position));
            GameManager.Instance.UIManager.PriceText.gameObject.SetActive(false);
            GameManager.Instance.Player.PlayerInventory.RemoveMoney(Price);

        }
    }
}

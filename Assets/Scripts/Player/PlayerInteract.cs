using Sirenix.OdinInspector;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [ReadOnly]
    public Interactable CurrentInteractable;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Interactable interactable))
        {
            CurrentInteractable = interactable;
            GameManager.Instance.UIManager.CallToACtionShowAnimation.Show();
            GameManager.Instance.UIManager.CallToActionFollow.SetTransformToFollow(CurrentInteractable.transform);

            if (interactable.TryGetComponent(out Buyable buyable))
            {
                GameManager.Instance.UIManager.PriceText.gameObject.SetActive(true);
                if (buyable.Price > GameManager.Instance.Player.PlayerInventory.Money)
                {
                    GameManager.Instance.UIManager.PriceText.SetTextValue(buyable.Price.ToString(), true, Color.red);
                }
                else
                {
                    GameManager.Instance.UIManager.PriceText.SetTextValue(buyable.Price.ToString(), true, Color.green);
                }
            }
            else
            {
                GameManager.Instance.UIManager.PriceText.gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Interactable interactable))
        {
            if (CurrentInteractable == interactable)
            {
                CurrentInteractable = null;
                GameManager.Instance.UIManager.CallToACtionShowAnimation.Hide(() =>
                {
                    GameManager.Instance.UIManager.CallToActionFollow.StopFollowing();
                    GameManager.Instance.UIManager.PriceText.gameObject.SetActive(false);
                });
            }
        }
    }

    public void Interact()
    {
        if (CurrentInteractable != null)
        {
            CurrentInteractable.Interact();
        }
    }
}

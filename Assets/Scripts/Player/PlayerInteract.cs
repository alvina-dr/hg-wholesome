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

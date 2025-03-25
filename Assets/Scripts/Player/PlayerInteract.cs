using Sirenix.OdinInspector;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [ReadOnly]
    public Collectable CurrentInteractable;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Collectable collectable))
        {
            CurrentInteractable = collectable;
            GameManager.Instance.UIManager.CallToACtionShowAnimation.Show();
            GameManager.Instance.UIManager.CallToActionFollow.SetTransformToFollow(CurrentInteractable.transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Collectable collectable))
        {
            if (CurrentInteractable == collectable)
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
            CurrentInteractable.CollectItem();
        }
    }
}

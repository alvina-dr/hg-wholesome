using UnityEngine;

public class Buyable : Interactable
{
    public GameObject CollectableToActivate;

    public override void Interact()
    {
        base.Interact();
        Debug.Log("interact with SIGN");

        //check for enough money before
        gameObject.SetActive(false);
        CollectableToActivate.SetActive(true);
    }
}

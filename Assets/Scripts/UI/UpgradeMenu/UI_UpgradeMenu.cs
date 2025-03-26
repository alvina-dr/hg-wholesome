using UnityEngine;

public class UI_UpgradeMenu : MonoBehaviour
{
    public void Open()
    {
        gameObject.SetActive(true);
        GameManager.Instance.Player.CanMove = false;
    }

    public void Close()
    {
        gameObject.SetActive(false);
        GameManager.Instance.Player.CanMove = true;
    }
}

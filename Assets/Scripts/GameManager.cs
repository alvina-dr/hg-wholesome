using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton
    public static GameManager Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    #endregion

    public Player Player;
    public Material DamageMaterial;
    public Drop DropPrefab;
    public UIManager UIManager;
    public CinemachineShake CinemachineShake;

    private void Start()
    {
        UIManager.MoneyText.SetTextValue("0", false);
    }
}

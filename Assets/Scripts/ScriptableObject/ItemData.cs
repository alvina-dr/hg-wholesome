using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "Scriptable Objects/ItemData")]
public class ItemData : ScriptableObject
{
    public GameObject ItemPrefab;
    public Sprite ItemSprite;
    public int Price;
    public int MaxStack;
}

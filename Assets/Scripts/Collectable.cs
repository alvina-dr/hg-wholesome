using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField] private ItemData _itemCollectable;
    [SerializeField] private List<ItemSpot> _spotList = new();
    [SerializeField] private float _frequency;

    private void Start()
    {
        for (int i = 0; i < _spotList.Count; i++)
        {
            SpawnItem(_spotList[i]);
        }

        StartCoroutine(WaitSpawnItem());
    }

    public void CollectItem()
    {
        ItemSpot itemSpot = _spotList.Find(x => x.isFull);

        if (itemSpot != null)
        {
            itemSpot.isFull = false;
            Sequence pop = DOTween.Sequence();
            pop.Append(itemSpot.transform.DOScale(1.3f, .1f));
            pop.Append(itemSpot.transform.DOScale(0f, .05f));
            pop.AppendCallback(() =>
            {
                Destroy(itemSpot.transform.GetChild(0).gameObject);
                itemSpot.transform.localScale = Vector3.one;
            });

            GameManager.Instance.Player.PlayerInventory.AddItem(new PlayerInventory.ItemEntry(_itemCollectable, 1));
        }
    }

    public IEnumerator WaitSpawnItem()
    {
        yield return new WaitForSeconds(_frequency);

        List<ItemSpot> itemSpotList = _spotList.FindAll(x => !x.isFull);

        if (itemSpotList.Count > 0)
        {
            SpawnItem(itemSpotList[Random.Range(0, itemSpotList.Count)]);
        }

        StartCoroutine(WaitSpawnItem());
    }

    public void SpawnItem(ItemSpot itemSpot)
    {
        GameObject go = Instantiate(_itemCollectable.ItemPrefab);
        go.transform.SetParent(itemSpot.transform);
        go.transform.position = itemSpot.transform.position;
        itemSpot.isFull = true;
    }

    [System.Serializable]
    public class ItemSpot
    {
        public Transform transform;
        public bool isFull;
    }
}

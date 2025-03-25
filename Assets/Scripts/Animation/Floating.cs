using UnityEngine;
using DG.Tweening;

public class Floating : MonoBehaviour
{
    [SerializeField] private float _height;
    [SerializeField] private float _duration;
    [SerializeField] private bool _randomDelay;

    void Start()
    {
        float _originalHeight = transform.localPosition.y;

        if (_randomDelay)
        {
            float random = Random.Range(0.0f, _duration);
            transform.DOLocalMoveY(transform.localPosition.y + (_height * random / _duration), 0); //teleporting to random going up stage
            transform.DOLocalMoveY(transform.localPosition.y + _height, _duration - random).OnComplete(() => //finishing going up
            {
                transform.DOLocalMoveY(_originalHeight, _duration).OnComplete(() => //going back down
                {
                    //setting forever loop
                    transform.DOLocalMoveY(_originalHeight + _height, _duration).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);
                });
            });
        }
        else
        {
            transform.DOLocalMoveY(_originalHeight + _height, _duration).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);
        }
    }
}

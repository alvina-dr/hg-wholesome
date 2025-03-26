using DG.Tweening;
using UnityEngine;

public class Anim_Moving : MonoBehaviour
{
    [SerializeField] private Vector3 _direction;
    [SerializeField] private float _duration;
    [SerializeField] private LoopType _loopType;
    [SerializeField] private Ease _ease;

    void Start()
    {
        StartMovement();
    }

    public void StartMovement()
    {
        transform.DOMove(transform.position + _direction, _duration).SetLoops(-1, _loopType).SetEase(_ease);
    }
}

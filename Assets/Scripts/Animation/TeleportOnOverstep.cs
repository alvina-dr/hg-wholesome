using DG.Tweening;
using UnityEngine;

public class TeleportOnOverstep : MonoBehaviour
{
    [SerializeField] private float _xOverstepPosition;
    [SerializeField] private float _xPosition;

    void Update()
    {
        if (transform.position.x > _xOverstepPosition)
        {
            transform.DOKill();
            transform.position = new Vector3(_xPosition, transform.position.y, transform.position.z);
            if (TryGetComponent(out Anim_Moving anim))
            {
                anim.StartMovement();
            }
        }
    }
}

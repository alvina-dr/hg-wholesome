using UnityEngine;

public class UI_FollowTransform : MonoBehaviour
{
    private Transform _transformToFollow;
    [SerializeField]
    private Vector3 _offset;

    private void Update()
    {
        if (_transformToFollow == null) return;

        Vector3 screenPosition = Camera.main.WorldToScreenPoint(_transformToFollow.position);
        transform.position = screenPosition + _offset;
    }

    public void SetTransformToFollow(Transform transformToFollow)
    {
        _transformToFollow = transformToFollow;
    }

    public void StopFollowing()
    {
        _transformToFollow = null;
    }
}

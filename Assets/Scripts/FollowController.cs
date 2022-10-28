using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowController : MonoBehaviour
{
    [SerializeField] private Transform _target;
    private Vector3 _offset;

    private void Start()
    {
        _offset = _target.position - transform.position;
    }

    private void FixedUpdate()
    {
        var position = -_offset + _target.position;
        var currentPosition = Vector3.Lerp(transform.position, position, .5f);
        currentPosition.z = transform.position.z;

        transform.position = currentPosition;
    }
}

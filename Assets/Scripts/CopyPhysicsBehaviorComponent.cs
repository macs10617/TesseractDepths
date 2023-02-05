using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyPhysicsBehaviorComponent : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private bool _copyX;
    [SerializeField] private bool _copyY;
    [SerializeField] private bool _copyZ;
    private Vector3 _targetOffset;

    private void Awake()
    {
        _targetOffset = (transform.position - _target.position);
    }

    private void FixedUpdate()
    {
        float x = _copyX ? _target.transform.position.x + _targetOffset.x : transform.position.x;
        float y = _copyY ? _target.transform.position.y + _targetOffset.y : transform.position.y;
        float z = _copyZ ? _target.transform.position.z + _targetOffset.z : transform.position.z;
        transform.position = new Vector3(x, y, z);
    }
}
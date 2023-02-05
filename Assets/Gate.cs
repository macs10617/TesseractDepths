using System;
using UnityEngine;

public class Gate : MonoBehaviour
{
    [SerializeField] private Vector3 _openedPos;
    [SerializeField] private float _moveSpeed;
    private Vector3 _closedPos;
    private Vector3 _currentPos;

    private void Start()
    {
        _closedPos = transform.localPosition;
        _currentPos = _closedPos;

        _openedPos = new Vector3(_closedPos.x, _closedPos.y, _openedPos.z);
    }

    public void SwitchGateStatus(bool opened)
    {
        _currentPos = opened ? _openedPos : _closedPos;
    }

    private void Update()
    {
        transform.localPosition = Vector3.Lerp(transform.localPosition, _currentPos, _moveSpeed * Time.deltaTime);
    }
}
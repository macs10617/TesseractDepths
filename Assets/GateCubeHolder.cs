using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateCubeHolder : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private GateTrigger _gateTrigger;
    [SerializeField] private List<Gate> _gates;
    [SerializeField] private Transform _movableLeft;
    [SerializeField] private Transform _movableRight;
    [SerializeField] private float _movableMoveDistance;
    private bool _opened;
    private Vector3 _startPosLeft;
    private Vector3 _startPosRight;

    private void Awake()
    {
        _gateTrigger.StatusChanged += SwitchGatesStatus;
        if (_movableLeft)
            _startPosLeft = _movableLeft.transform.localPosition;
        if (_movableRight)
            _startPosRight = _movableRight.transform.localPosition;
    }

    private void SwitchGatesStatus(bool status)
    {
        _opened = status;
        if (status) OpenGates();
        else CloseGates();
    }

    private void OpenGates()
    {
        _gates.ForEach(x => x.SwitchGateStatus(true));
    }

    private void CloseGates()
    {
        _gates.ForEach(x => x.SwitchGateStatus(false));
    }

    private void Update()
    {
        if (_movableLeft)
            _movableLeft.transform.localPosition = Vector3.Lerp(_movableLeft.transform.localPosition,
                !_opened ? _startPosLeft : _startPosLeft + new Vector3(_movableMoveDistance, 0, 0),
                _moveSpeed * Time.deltaTime);

        if (_movableRight)
            _movableRight.transform.localPosition = Vector3.Lerp(_movableRight.transform.localPosition,
                !_opened ? _startPosRight : _startPosRight - new Vector3(_movableMoveDistance, 0, 0),
                _moveSpeed * Time.deltaTime);
    }
}
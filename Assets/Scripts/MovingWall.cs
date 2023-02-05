using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingWall : MonoBehaviour
{
    [SerializeField] private Vector3 _desiredMoveValue;
    [SerializeField] private int _iterations;
    [SerializeField] private float _moveSpeed;
    private Vector3 _targetPos;
    private int _currentIteration;

    private void Start()
    {
        _currentIteration = 0;
        _targetPos = transform.position;
    }

    public void Move()
    {
        if (_currentIteration >= _iterations) return;

        _currentIteration++;

        float div = (_iterations - _currentIteration + 1);

        if (div == 0) div = 1;

        Vector3 newMoveValue = _desiredMoveValue / div;

        newMoveValue = new Vector3(
            Mathf.Round(newMoveValue.x * 100f) / 100f,
            Mathf.Round(newMoveValue.y * 100f) / 100f,
            Mathf.Round(newMoveValue.z * 100f) / 100f);
        _targetPos = transform.position + newMoveValue;
    }

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, _targetPos, _moveSpeed * Time.deltaTime);
    }
}
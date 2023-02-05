using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class MovementComponent : MonoBehaviour
{
    [SerializeField] private LayerMask _groundLayer;

    [SerializeField] private CharacterController _characterController;
    [SerializeField] private Transform _groundChecker;

    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _jumpHeight;
    [SerializeField] private float _groundDistance;

    private const float GRAVITY = -9.81f;

    private bool _isGrounded;
    private Vector3 _velocity;

    void Update()
    {
        if (!InputManager.Instance.IsInputEnabled(MyInputType.Move)) return;
        
        Move();
    }

    void Move()
    {
        _isGrounded = Physics.CheckSphere(_groundChecker.position, _groundDistance, _groundLayer);

        if (_isGrounded && _velocity.y < 0)
        {
            _velocity.y = -2f;
        }

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");


        Vector3 moveDirection = transform.right * horizontal + transform.forward * vertical;

        _characterController.Move(moveDirection * (_moveSpeed * Time.deltaTime));

        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            _velocity.y = Mathf.Sqrt(_jumpHeight * -2f * GRAVITY);
        }

        _velocity.y += GRAVITY * Time.deltaTime;

        _characterController.Move(_velocity * Time.deltaTime);
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggableObject : MonoBehaviour
{
    public bool CanDrag => _canDrag;
    [SerializeField] private AudioClip _hitClip;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private bool _canRotate;
    [SerializeField] private bool _canInvertGravity;
    [SerializeField] private bool _canDrag;
    [SerializeField] private bool _oneTimeActivation;
    [SerializeField] private float _force = 1f;

    [SerializeField] private GameEventTrigger _gameEventTrigger;
    private int _gravityScale = 1;

    private AudioSource _audioSource;

    private void Awake()
    {
        if (!_canRotate)
        {
            _rigidbody.freezeRotation = true;
        }

        _audioSource = GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        _rigidbody.AddForce(Physics.gravity * (_gravityScale * _force), ForceMode.Acceleration);
    }

    public void InvertGravity()
    {
        if (!_canInvertGravity) return;
        _gravityScale = _gravityScale == 1 ? -1 : 1;

        if (_oneTimeActivation) _canInvertGravity = false;

        if (_gameEventTrigger != null)
            _gameEventTrigger.Raise();
    }

    public void SetVelocity(Vector3 velocity)
    {
        _rigidbody.velocity = velocity;
    }

    public void SetRotation(Vector3 rotation)
    {
        if (!_canRotate) return;
        _rigidbody.rotation = Quaternion.Euler(_rigidbody.rotation.eulerAngles + rotation);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (Time.realtimeSinceStartup < 5 || _hitClip == null) return;
        float audioLevel = collision.relativeVelocity.magnitude / 12.5f;
        _audioSource.PlayOneShot(_hitClip, audioLevel);
    }
}
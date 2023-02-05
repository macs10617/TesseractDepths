using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportEventListener : MonoBehaviour
{
    [SerializeField] private Transform _playerAttachTarget;
    [SerializeField] private Transform _teleportSubject;
    [SerializeField] private Transform _teleportToPosition;
    private Transform _playerTransform;
    private CharacterController _characterController;
    public void Teleport()
    {
        _characterController = FindObjectOfType<CharacterController>();
        _playerTransform = _characterController.transform;
        _characterController.enabled = false;
        _playerTransform.SetParent(_playerAttachTarget);

        _teleportSubject.transform.position = _teleportToPosition.transform.position;
        _characterController.enabled = true;
    }
}

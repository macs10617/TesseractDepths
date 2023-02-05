using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchStateTrigger : MonoBehaviour
{
    [SerializeField] private List<GameObject> _objectsToEnable;
    [SerializeField] private List<GameObject> _objectsToDisable;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        foreach (var go in _objectsToEnable)
        {
            go.SetActive(true);
        }

        foreach (var go in _objectsToDisable)
        {
            go.SetActive(false);
        }
    }
}
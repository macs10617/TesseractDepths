using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectLayersManager : MonoBehaviour
{
    [SerializeField] private LayerMask _mask;
    [SerializeField] private List<GameObject> _targets;

    public void ChangeLayer()
    {
        foreach (var go in _targets)
        {
            go.layer = _mask;
        }
    }
}
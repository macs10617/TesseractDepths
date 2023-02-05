using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveLastCeiling : MonoBehaviour
{
    [SerializeField] private GameObject _ceiling;

    private void OnEnable()
    {
        _ceiling.SetActive(false);
    }
}
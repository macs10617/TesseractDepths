using System;
using UnityEngine;

public class GravityCubeHolder : MonoBehaviour
{
    [SerializeField] private GameObject _cubePreview;
    [SerializeField] private GameObject _cube;
    private bool _eventTriggered;

    public void ActivateCube()
    {
        _eventTriggered = true;
        OnEnable();
    }

    private void OnEnable()
    {
        _cubePreview.SetActive(!_eventTriggered);
        _cube.SetActive(_eventTriggered);
    }
}
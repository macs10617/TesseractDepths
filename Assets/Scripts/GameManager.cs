using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private SimpleFade _fade;
    [SerializeField] private InputManager _inputManager;

    private void Awake()
    {
        _fade.FadeEnd += StartGame;
        _inputManager.Initialize();
    }

    private void StartGame()
    {
        InputManager.Instance.EnableAllInputs();
    }
}
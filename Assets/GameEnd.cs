using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameEnd : MonoBehaviour
{
    [SerializeField] private Transform _playerTpPos;
    [SerializeField] private Transform _player;
    [SerializeField] private Image _fadeImage;
    [SerializeField] private float _fadeDuration;
    private float _elapsed;


    public void ShowEnd()
    {
        _fadeImage.gameObject.SetActive(true);

        InputManager.Instance.BlockAllInputs();

        FadeIn();
    }

    void FadeIn()
    {
        StartCoroutine(FadeInRoutine());
    }

    private IEnumerator FadeInRoutine()
    {
        _elapsed = 0f;

        while (_elapsed < _fadeDuration)
        {
            _elapsed += Time.deltaTime;
            _fadeImage.color = Color.Lerp(Color.clear, Color.black, _elapsed / _fadeDuration);
            yield return null;
        }

        _player.position = _playerTpPos.position;
        _player.rotation = _playerTpPos.rotation;

        _elapsed = 0f;

        while (_elapsed < _fadeDuration)
        {
            _elapsed += Time.deltaTime;
            _fadeImage.color = Color.Lerp(Color.black, Color.clear, _elapsed / _fadeDuration);
            yield return null;
        }

        _fadeImage.gameObject.SetActive(false);
        InputManager.Instance.EnableAllInputs();
    }
}
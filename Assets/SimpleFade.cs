using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimpleFade : MonoBehaviour
{
    public Action FadeEnd;
    [SerializeField] private Image _fadeImage;
    [SerializeField] private float _fadeDuration;
    private float _elapsed;

    void Start()
    {
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
            _fadeImage.color = Color.Lerp(Color.black, Color.clear, _elapsed / _fadeDuration);
            yield return null;
        }

        FadeEnd?.Invoke();
        _fadeImage.gameObject.SetActive(false);
    }
}
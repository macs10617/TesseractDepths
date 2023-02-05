using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OutroManager : MonoBehaviour
{
    [SerializeField] private List<string> _outroTexts;
    [SerializeField] private Animator _outroAnimator;
    [SerializeField] private TextMeshProUGUI _outroText;

    private int _index;

    [ContextMenu("Show Outro")]
    private void ShowOutro_TEST()
    {
        ShowOutro();
    }

    public void ShowOutro()
    {
        _index = 0;
        _outroAnimator.SetTrigger("Start");
        _outroText.text = String.Empty;
    }

    public void ShowNextText()
    {
        if (_index == _outroTexts.Count)
        {
            ShowText(String.Empty);
            _outroAnimator.SetTrigger("End");
            return;
        }

        ShowText(_outroTexts[_index]);

        _outroAnimator.SetTrigger("ShowNext");

        _index++;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _outroAnimator.SetTrigger("Skip");
            ShowNextText();
        }
    }

    public void ShowText(string text)
    {
        _outroText.text = text;
    }
}
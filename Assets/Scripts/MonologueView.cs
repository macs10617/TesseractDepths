using System.Collections;
using TMPro;
using UnityEngine;

public class MonologueView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _monologueText;
    [SerializeField] private float _showTextDelay;
    private string _textToShow;

    public void SetText(string text)
    {
        _textToShow = text;
    }

    public void Show()
    {
        StartCoroutine(ShowMonologueTextRoutine());
    }

    private IEnumerator ShowMonologueTextRoutine()
    {
        _monologueText.text = "";
        for (int i = 0; i < _textToShow.Length; i++)
        {
            _monologueText.text += _textToShow[i];
            yield return new WaitForSeconds(_showTextDelay);
        }
    }
}
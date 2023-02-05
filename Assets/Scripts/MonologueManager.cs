using System.Collections.Generic;
using UnityEngine;

public class MonologueManager : MonoBehaviour
{
    [SerializeField] private List<string> _phrases;
    [SerializeField] private MonologueView _monologueView;
    
    [ContextMenu("Show Final Player Phrase")]
    void ShowFinalPhrase_TEST()
    {
        ShowPhrase(_phrases[0]);
    }

    void ShowPhrase(string phrase)
    {
        _monologueView.SetText(phrase);
        _monologueView.Show();
    }

    void ShowHint()
    {
    }
}
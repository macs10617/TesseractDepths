using System;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance => _instance;
    private static InputManager _instance;

    private Dictionary<MyInputType, bool> _inputStatusDictionary;

    public void Initialize()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
        }


        _inputStatusDictionary = new Dictionary<MyInputType, bool>();

        foreach (MyInputType input in Enum.GetValues(typeof(MyInputType)))
        {
            _inputStatusDictionary.Add(input, true);
        }

        BlockAllInputs();
    }

    public bool IsInputEnabled(MyInputType inputType)
    {
        return _inputStatusDictionary[inputType];
    }

    public void UnblockInput(MyInputType inputType)
    {
        _inputStatusDictionary[inputType] = true;
    }

    public void BlockInput(MyInputType inputType)
    {
        _inputStatusDictionary[inputType] = false;
    }

    public void BlockAllInputs()
    {
        foreach (MyInputType input in Enum.GetValues(typeof(MyInputType)))
        {
            _inputStatusDictionary[input] = false;
        }
    }

    public void EnableAllInputs()
    {
        foreach (MyInputType input in Enum.GetValues(typeof(MyInputType)))
        {
            _inputStatusDictionary[input] = true;
        }
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class LiftRoomController : MonoBehaviour
{
    [SerializeField] private List<GameEvent> _eventsToOpenFirstFloor;
    [SerializeField] private List<GameEvent> _eventsToOpenSecondFloor;

    private Dictionary<string, bool> _firstGameEventRaisedDict;
    private Dictionary<string, bool> _secondGameEventRaisedDict;
    private GameEventListener _gameEventListener;

    private void Start()
    {
        _gameEventListener = gameObject.AddComponent<GameEventListener>();

        _firstGameEventRaisedDict = new Dictionary<string, bool>();

        foreach (var gameEvent in _eventsToOpenFirstFloor)
        {
            _firstGameEventRaisedDict.Add(gameEvent.name, false);
            _gameEventListener.Register(gameEvent);
            _gameEventListener.Response.AddListener((() => EventRaised(_firstGameEventRaisedDict, gameEvent.name, 1)));
        }

        _secondGameEventRaisedDict = new Dictionary<string, bool>();

        foreach (var gameEvent in _eventsToOpenSecondFloor)
        {
            _secondGameEventRaisedDict.Add(gameEvent.name, false);
            _gameEventListener.Register(gameEvent);
            _gameEventListener.Response.AddListener((() => EventRaised(_secondGameEventRaisedDict, gameEvent.name, 2)));
        }
    }

    private void EventRaised(Dictionary<string, bool> dict, string eventName, int floor)
    {
        if (dict.ContainsKey(eventName))
        {
            dict[eventName] = true;
            CheckIfCanOpen(dict, floor);
        }
    }

    private void CheckIfCanOpen(Dictionary<string, bool> dict, int floor)
    {
        if (dict.All(x => x.Value))
        {
            if (floor == 1) OpenFirstFloor();
            else OpenSecondFloor();
        }
    }

    private void OpenFirstFloor()
    {
    }

    private void OpenSecondFloor()
    {
    }
}
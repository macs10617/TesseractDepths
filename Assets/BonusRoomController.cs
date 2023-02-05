using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BonusRoomController : MonoBehaviour
{
    [SerializeField] private List<GameEvent> _eventsToOpenBonusRoom;

    private Dictionary<string, bool> _bonusRoomDict;
    [SerializeField] private GameObject _bonusRoomEnableGroup;
    [SerializeField] private GameObject _doors;

    private void Start()
    {
        _bonusRoomEnableGroup.SetActive(false);

        _bonusRoomDict = new Dictionary<string, bool>();

        foreach (var gameEvent in _eventsToOpenBonusRoom)
        {
            GameEventListener gameEventListener = gameObject.AddComponent<GameEventListener>();

            _bonusRoomDict.Add(gameEvent.name, false);
            gameEventListener.Register(gameEvent);
            gameEventListener.Response.AddListener((() => EventRaised(_bonusRoomDict, gameEvent.name)));
        }
    }

    private void EventRaised(Dictionary<string, bool> dict, string eventName)
    {
        if (dict.ContainsKey(eventName))
        {
            dict[eventName] = true;
            CheckIfCanOpen(dict);
        }
    }

    private void CheckIfCanOpen(Dictionary<string, bool> dict)
    {
        if (dict.ToList().FindAll(x => x.Value).Count >= _bonusRoomDict.Keys.Count - 1)
        {
            OpenBonusRoom();
        }
    }

    private void OpenBonusRoom()
    {
        _bonusRoomEnableGroup.SetActive(true);
        _doors.SetActive(false);
    }
}
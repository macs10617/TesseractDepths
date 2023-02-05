using System.Collections.Generic;
using UnityEngine;

public class StartRoom : Level
{
    public Transform StartPoint => _startPoint;
    [SerializeField] protected Transform _startPoint;
    [SerializeField] private Animator _mainDoorAnimator;
    [SerializeField] private GameEventListener _mainDoorListener;
    [SerializeField] private GameEventTrigger _mainDoorTrigger;
    [SerializeField] private GameEventTrigger _bonusDoorTrigger;
    [SerializeField] private List<GameItem> _gameItems;

    public void OpenMainDoor()
    {
        _mainDoorAnimator.SetTrigger("Open");
    }

    public void SetMainDoorEvent(GameEvent gameEvent)
    {
        _mainDoorTrigger.Event = gameEvent;
        _mainDoorListener.Register(gameEvent);
    }

    public void SetBonusDoorEvent(GameEvent gameEvent)
    {
        _bonusDoorTrigger.Event = gameEvent;
    }

    public void AcquireItem(GameItem gameItem)
    {
        gameItem.SetOnStand();
    }
}

public class BonusRoom : Level
{
    [SerializeField] private GameEventTrigger _mainDoorTrigger;
    [SerializeField] private GameEventTrigger _bonusDoorTrigger;
    [SerializeField] private List<GameItem> _gameItems;

    public void SetMainDoorEvent(GameEvent gameEvent)
    {
        _mainDoorTrigger.Event = gameEvent;
    }

    public void SetBonusDoorEvent(GameEvent gameEvent)
    {
        _bonusDoorTrigger.Event = gameEvent;
    }

    public void AcquireItem(GameItem gameItem)
    {
        gameItem.SetOnStand();
    }
}

public class GameItemStand : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;

    public void SetItemOnStand(Transform gameItem)
    {
        gameItem.transform.position = _spawnPoint.transform.position;
    }
}

public class GameItem : MonoBehaviour
{
    [SerializeField] private GameItemStand _stand;

    public void SetOnStand()
    {
        _stand.SetItemOnStand(transform);
    }
}
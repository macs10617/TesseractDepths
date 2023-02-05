using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private StartRoom _startRoom;
    [SerializeField] private BonusRoom _bonusRoom;

    [SerializeField] private List<Level> _levels;

    private Level _currentLevel;

    public void Initialize()
    {
        ChangeCurrentLevel(_levels[0]);
    }

    public void SetNextLevel()
    {
        ChangeCurrentLevel(GetNextLevel());
    }

    public StartRoom GetStartLevel() => _startRoom;
    public Level GetCurrentLevel() => _currentLevel;

    public Level GetNextLevel()
    {
        return _levels[_levels.IndexOf(_currentLevel)];
    }

    public void ChangeCurrentLevel(Level level)
    {
        _currentLevel = level;

        _startRoom.SetMainDoorEvent(_currentLevel.Event);
        _startRoom.OpenMainDoor();
        level.SetLevelSpawnPosRot();
    }
}
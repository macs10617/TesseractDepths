using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FibonacciBoxPuzzle : MonoBehaviour
{
    [SerializeField] private List<BoxTrigger> _boxesToComplete;
    [SerializeField] private List<BoxTrigger> _boxesToGetBonus;
    [SerializeField] private MovingWall _movingWall;
    [SerializeField] private MovingWall _bonusMovingWall;
    private void Start()
    {
        foreach (var box in _boxesToComplete)
        {
            box.Triggered += CheckCompleted;
        }

        foreach (var box in _boxesToGetBonus)
        {
            box.Triggered += CheckBonus;
        }

        _boxesToComplete.ForEach(x => x.gameObject.SetActive(false));
        _boxesToComplete.ForEach(x => x.gameObject.SetActive(true));
        _boxesToGetBonus.ForEach(x => x.gameObject.SetActive(false));
        _boxesToGetBonus.ForEach(x => x.gameObject.SetActive(true));
    }

    private void CheckCompleted()
    {
        if (_boxesToComplete.All(x => x.HaveTarget))
        {
            Complete();
        }
    }

    private void Complete()
    {
        _movingWall.Move();
    }

    private void CheckBonus()
    {
        if (_boxesToGetBonus.All(x => x.HaveTarget))
        {
            GetBonus();
        }
    }

    private void GetBonus()
    {
        _bonusMovingWall.Move();
    }
}
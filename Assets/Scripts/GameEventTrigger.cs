using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventTrigger : MonoBehaviour
{
    public bool _playerOnly;
    public bool _destroyable;
    public GameEvent Event;

    private void OnTriggerEnter(Collider other)
    {
        if (_playerOnly)
        {
            if (other.CompareTag("Player"))
            {
                Raise();
            }
        }
        else if (other.CompareTag("Player") || other.CompareTag("GrabObject"))
            Raise();
    }

    public void Raise()
    {
        Event.Raise();

        if (_destroyable)
        {
            AudioManager.Instance.PlaySoundEffect("Collect");
            Destroy(gameObject);
        }
    }
}
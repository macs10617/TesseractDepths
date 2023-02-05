using System;
using UnityEngine;

public class BoxTrigger : MonoBehaviour
{
    public bool HaveTarget;
    public Action Triggered;

    private void OnTriggerEnter(Collider other)
    {
        HaveTarget = true;
        Triggered?.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        HaveTarget = false;
    }
}
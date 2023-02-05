using System;
using UnityEngine;

public class GateTrigger : MonoBehaviour
{
    public Action<bool> StatusChanged;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out DraggableObject draggableObject))
        {
            StatusChanged?.Invoke(true);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out DraggableObject draggableObject))
        {
            StatusChanged?.Invoke(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out DraggableObject draggableObject))
        {
            StatusChanged?.Invoke(false);
        }
    }
}
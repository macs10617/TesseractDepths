using System.Collections.Generic;
using UnityEngine;

public class ChangeLayersTrigger : MonoBehaviour
{
    [SerializeField] private int _layerToChange;
    [SerializeField] private List<GameObject> _objectsToChangeLayer;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        foreach (var go in _objectsToChangeLayer)
        {
            IterateChildren(go);
        }
    }

    void IterateChildren(GameObject parent)
    {
        foreach (Transform child in parent.transform)
        {
            var go = child.gameObject;
            
            if (go.layer != _layerToChange)
                go.layer = _layerToChange;

            IterateChildren(go);
        }
    }
}
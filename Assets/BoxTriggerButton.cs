using System;
using System.Collections;
using UnityEngine;

public class BoxTriggerButton : MonoBehaviour
{
    [SerializeField] private DraggableObject _draggableObject;
    private Transform _movingChild;

    private void Awake()
    {
        if (transform.childCount > 0)
            _movingChild = transform.GetChild(0);
    }

    private void OnMouseDown()
    {
        AudioManager.Instance.PlaySoundEffect("ButtonClick");
        _draggableObject.InvertGravity();
        StartCoroutine(ClickAnimRoutine());
    }

    IEnumerator ClickAnimRoutine()
    {
        float elapsed = 0;

        while (elapsed < 0.25f)
        {
            _movingChild.transform.position += Vector3.left * (Time.deltaTime * 0.2f);
            elapsed += Time.deltaTime;
            yield return null;
        }

        elapsed = 0;
        
        while (elapsed < 0.25f)
        {
            _movingChild.transform.position -= Vector3.left * (Time.deltaTime * 0.2f);
            elapsed += Time.deltaTime;
            yield return null;
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCameraComponent : MonoBehaviour
{
    [SerializeField] private Transform _target;
    void Update()
    {
        transform.position = _target.transform.position;
    }
}

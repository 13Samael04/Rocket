using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMover : MonoBehaviour
{
    [SerializeField] private Vector3 _movePosition;
    [SerializeField][Range(0, 1)] private float _moveProgress;
    [SerializeField] private float _moveSpeed;

    private Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.position;
    }

    private void Update()
    {
        _moveProgress = Mathf.PingPong(Time.time * _moveSpeed, 1);
        Vector3 offset = _movePosition * _moveProgress;
        transform.position = startPosition + offset;
    }
}

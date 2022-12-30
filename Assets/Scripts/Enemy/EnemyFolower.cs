using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Enemy))]

public class EnemyFolower : MonoBehaviour
{
    public List<Waypoint> _referenceWaypoints;

    [SerializeField] private Transform _target;
    [SerializeField] private float _speed;

    private Transform _enemyOfMove;
    private Rigidbody _rigidbody;
    private Enemy _enemy;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _enemyOfMove = GetComponent<Transform>();
    }
    private void FixedUpdate()
    {
        Ray ray = new Ray(_enemyOfMove.transform.position, _target.position - transform.position);
        Physics.Raycast(ray, out RaycastHit hit);
        Vector3 nowTarget;

        if (hit.transform.gameObject == _target.gameObject || _referenceWaypoints.Count == 0)
        {
            nowTarget = _target.position;
        }
        else
        {
            nowTarget = _referenceWaypoints[0].transform.position;
        }

        _enemyOfMove.transform.position = Vector3.MoveTowards(_enemyOfMove.transform.position, nowTarget, Time.deltaTime * _speed);
    }
}

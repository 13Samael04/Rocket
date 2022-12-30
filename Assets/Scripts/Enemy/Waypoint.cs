using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    private int _indexOfRemove = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<EnemyFolower>(out EnemyFolower enemyFolower))
        {
            enemyFolower._referenceWaypoints.Remove(enemyFolower._referenceWaypoints[_indexOfRemove]);
            Destroy(gameObject);
        }
    }
}

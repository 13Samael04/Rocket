using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public event UnityAction Died;
    public event UnityAction Finished;

    [SerializeField] protected int FuelCount;

    protected bool IsDied = false;

    private void Start()
    {
        Time.timeScale = 1;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent<Obstacles>(out Obstacles obstacles) || collision.gameObject.TryGetComponent<Enemy>(out Enemy enemy))
        {
            IsDied = true;
            Died?.Invoke();
        }
        if(collision.gameObject.TryGetComponent<Finish>(out Finish finish))
        {
            Finished?.Invoke();
        }
    }
}

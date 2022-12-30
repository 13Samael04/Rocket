using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent (typeof(CapsuleCollider))]

public class PlayerMovable : Player
{
    public event UnityAction Flew;
    public event UnityAction EngineShutDown;

    [SerializeField] private float _speed;
    [SerializeField] private float _speedRotation;
    [SerializeField] private int _useFuel;
    [SerializeField] private ParticleSystem _flyParticleSystem;

    private Rigidbody _rigidbody;

    public int Fuel { get; private set; }

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        Fuel = FuelCount;
        _rigidbody.freezeRotation = true;
    }

    private void Update()
    {
        Fly();
        Rotation();
    }

    private void Fly()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if(FuelCount > 0 && IsDied == false)
            {
                _rigidbody.AddForce(transform.up * _speed * Time.deltaTime);
                _flyParticleSystem.Play();
                BurnFuel();
                Flew?.Invoke();
            }
        }
        else 
        {
            _flyParticleSystem.Stop();
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            EngineShutDown?.Invoke();
        }
    }

    private void Rotation()
    {
        float rotation = Input.GetAxis("Horizontal") * -_speedRotation * Time.deltaTime;
        transform.Rotate(0, 0, rotation);
    }

    private void BurnFuel()
    {
        FuelCount -= _useFuel;
        Fuel = FuelCount;
    }
}

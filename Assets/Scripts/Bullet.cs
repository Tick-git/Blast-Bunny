using System;
using UnityEngine;
using HealthSystem;

public class Bullet : MonoBehaviour
{
    Rigidbody _rigidbody;
    
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        _rigidbody.linearVelocity = new Vector3(-10, 0, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<Health>().TakeDamage(1);
    }

    private void FixedUpdate()
    {
        if(_rigidbody.position.x < 0)
            _rigidbody.linearVelocity = new Vector3(10, 0, 0);
        
        if(_rigidbody.position.x > 10)
            _rigidbody.linearVelocity = new Vector3(-10, 0, 0);
    }
}

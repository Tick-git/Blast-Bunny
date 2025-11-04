using System;
using UnityEngine;
using HealthSystem;


// TODO: Bullet needs to be despawned
public class Bullet : MonoBehaviour
{
    Rigidbody _rigidbody;
    float _timeFlying;
    
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<Health>()?.TakeDamage(1);
        
        if (other.gameObject.TryGetComponent<IUnpierceable>(out var unpierceable))
            StopFlying();
    }
    
    private void Update()
    {
        _timeFlying += Time.deltaTime;
        
        if(_timeFlying >= 5f)
            StopFlying();
    }

    public void StartFlying(Vector3 direction)
    {
        _rigidbody.linearVelocity = direction * 10;
        _timeFlying = 0;
    }
    
    private void StopFlying()
    {
        Destroy(gameObject);
    }
}

internal interface IUnpierceable { }

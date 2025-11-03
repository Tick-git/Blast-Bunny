using System;
using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] float _moveSpeed = 0.125f;
        
        InputSystem_Actions _inputActions;
        Rigidbody _rigidbody;
        Vector3 _velocity;
        
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _inputActions = new InputSystem_Actions();
        }
        
        private void OnEnable() => _inputActions.Player.Enable();

        private void OnDisable() => _inputActions.Player.Disable();

        private void Update()
        {
            Vector2 moveDirection = _inputActions.Player.Move.ReadValue<Vector2>();
            _velocity = new Vector3(moveDirection.x, 0, moveDirection.y) * _moveSpeed;
        }
        
        private void FixedUpdate()
        {
            _rigidbody.Move(transform.position + _velocity, _rigidbody.rotation);
        }
    }
}

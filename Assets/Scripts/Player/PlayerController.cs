using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] float _moveSpeed = 0.125f;
        
        InputSystem_Actions _inputActions;
        Rigidbody _rigidbody;
        Vector3 _velocity;
        Weapon _weapon;
        Camera _camera;
        
        Plane _plane;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _inputActions = new InputSystem_Actions();
            _weapon = GetComponentInChildren<Weapon>();
            _camera = Camera.main;
            _plane = new Plane(Vector3.up, Vector3.zero);
        }
        
        private void OnEnable() => _inputActions.Player.Enable();

        private void OnDisable() => _inputActions.Player.Disable();

        // TODO: Why do I need an offset of -1.5f to the world pos
        private void Update()
        {
            Vector2 moveDirection = _inputActions.Player.Move.ReadValue<Vector2>();
            if (_inputActions.Player.Attack.WasPressedThisFrame())
            {
                Ray ray = _camera.ScreenPointToRay(Mouse.current.position.ReadValue());
                if (_plane.Raycast(ray, out float enter))
                {
                    Vector3 worldPos = ray.GetPoint(enter);
                    Vector3 v1 = new Vector3(worldPos.x, 0, worldPos.z - 1.5f);
                    Vector3 v2 = new Vector3(_weapon.transform.position.x, 0, _weapon.transform.position.z);
                    _weapon.Attack((v1 - v2).normalized);
                }
            }
            _velocity = new Vector3(moveDirection.x, 0, moveDirection.y) * _moveSpeed;
        }
        

        
        private void FixedUpdate()
        {
            _rigidbody.Move(transform.position + _velocity, _rigidbody.rotation);
        }
    }
}

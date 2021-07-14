using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementBehaviour : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private Vector3 _moveDirection;
    private Vector3 _velocity;
    private Vector3 _inputDirection;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        //Gets a reference to the rigid body attached to the player
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void OnMove(InputValue movementValue)
    {
        _inputDirection = movementValue.Get<Vector2>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 moveDirectionX = transform.right * _inputDirection.x;
        Vector3 moveDirectionZ = transform.forward * _inputDirection.y;

        _moveDirection = moveDirectionX + moveDirectionZ;
        _moveDirection.Normalize();

        _velocity = _moveDirection * speed;

        _rigidbody.MovePosition(transform.position + _velocity * Time.deltaTime);
    }
}

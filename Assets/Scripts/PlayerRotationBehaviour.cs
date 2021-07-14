using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerRotationBehaviour : MonoBehaviour
{
    public Transform cameraTransform;
    public float sensitivity;
    public float minY;
    public float maxY;

    private float _rotationX;
    private float _rotationY;
    private Vector2 _lookDirection;

    public void OnLook(InputValue lookValue)
    {
        _lookDirection = lookValue.Get<Vector2>();
    }

    // Update is called once per frame
    void Update()
    {
        //Find how much to rotate based on the mouse direction
        _rotationX = _rotationX + _lookDirection.y * sensitivity * Time.deltaTime;
        _rotationY = _rotationY + _lookDirection.x * sensitivity * Time.deltaTime;
        _rotationX = Mathf.Clamp(_rotationX, minY, maxY);

        //Rotate the player and the camera to face the mouse
        transform.localEulerAngles = new Vector3(0, _rotationY, 0);
        cameraTransform.localEulerAngles = new Vector3(-_rotationX, 0, 0);
    }
}

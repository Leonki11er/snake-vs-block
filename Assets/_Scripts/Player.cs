using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector3 _previousMousePosition;
    [SerializeField]
    private Transform snakeHead;
    [SerializeField]
    private float _sensitivity;
    private Rigidbody _rigidbody;
    public float speed;

    public float GameSpeed;

    private void Awake()
    {
        _rigidbody = snakeHead.GetComponent<Rigidbody>();
    }

    void Update()
    {
        MouseMove();
    }

    private void MouseMove()
    {
        float xSpeed = 0;
        if (Input.GetMouseButton(0))
        {
            Vector3 delta = Input.mousePosition - _previousMousePosition;
            xSpeed = delta.x * _sensitivity;
        }
        _previousMousePosition = Input.mousePosition;
        _rigidbody.velocity = new Vector3(xSpeed, 0, speed);
    }

    public void StopMoving()
    {
        _rigidbody.velocity = new Vector3(0, 0, 0);
    }
}

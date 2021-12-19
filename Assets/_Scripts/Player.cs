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
        _rigidbody.velocity = new Vector3(0, 0, speed);
    }

    private void MouseMove()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 delta = Input.mousePosition - _previousMousePosition;
            snakeHead.transform.position = snakeHead.transform.position + new Vector3(delta.x * _sensitivity, 0,  0);

            if (snakeHead.transform.position.x <= -2.34) snakeHead.transform.position = new Vector3(-2.34f, 0.7f, snakeHead.transform.position.z);
            if (snakeHead.transform.position.x >= 2.34) snakeHead.transform.position = new Vector3(2.34f, 0.7f, snakeHead.transform.position.z);
        }
        _previousMousePosition = Input.mousePosition;
    }
}

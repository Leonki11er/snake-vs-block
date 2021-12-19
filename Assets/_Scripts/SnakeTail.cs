using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeTail : MonoBehaviour   
{
    private int _segmentOrder;
    private Transform _head;
    private SnakeHead _snakeHead;
    public Vector3 Velocity;
    public float overTime;
    public float zOffset;

    private void Awake()
    {
        _head = GameObject.FindGameObjectWithTag("Head").gameObject.transform;
        _snakeHead = _head.GetComponent<SnakeHead>();
        for (int i = 0; i < _snakeHead.TailParts.Count; i++)
        {
            if (gameObject == _snakeHead.TailParts[i].gameObject) _segmentOrder = i;
        }
    }


    void Update()
    {
        Velocity = _snakeHead.Velocity;
        overTime = _snakeHead.overTime;
        zOffset = _snakeHead.zOffset;

        if (_segmentOrder == 0)
        {
            transform.position = Vector3.SmoothDamp(transform.position, _head.position+new Vector3(0,0,-zOffset), ref Velocity, overTime);
            transform.LookAt(_head.position);
        }
        else
        {
            transform.position = Vector3.SmoothDamp(transform.position, _snakeHead.TailParts[_segmentOrder - 1].gameObject.transform.position + new Vector3(0, 0,- zOffset), ref Velocity, overTime);
            transform.LookAt(_head.position);
        }

        //if (_segmentOrder == 0)
        //{
        //    transform.position = Vector3.SmoothDamp(transform.position, new Vector3(_head.position.x, transform.position.y, transform.position.z), ref Velocity, overTime);
        //    transform.LookAt(_head.position);
        //}
        //else
        //{
        //    transform.position = Vector3.SmoothDamp(transform.position, new Vector3(_snakeHead.TailParts[_segmentOrder - 1].gameObject.transform.position.x, transform.position.y, transform.position.z), ref Velocity, overTime);
        //    transform.LookAt(_head.position);
        //}

    }
}

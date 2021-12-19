using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Transform Snake;
    public float Offset;
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, Snake.position.z-Offset);
    }
}

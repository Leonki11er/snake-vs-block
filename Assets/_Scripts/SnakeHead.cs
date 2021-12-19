using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SnakeHead : MonoBehaviour
{
    public List<Transform> TailParts = new List<Transform>();

    public Vector3 Velocity;
    public float overTime;
    public Text TailLength;
    public GameObject TailPrefab;
    public float zOffset;

    public float Mindistance = 0.25f;



    private float distance;
    private Transform currentSegment;
    private Transform prevSegment;
    public GameObject prefTail;
    public float currentSpeed;

    private void Awake()
    {
        TailLength.text = "0";
    }

    private void Update()
    {
        MoveTail();
    }

    public void MoveTail()
    {
        for (int i = 1; i < TailParts.Count; i++)
        {
            currentSegment = TailParts[i];
            prevSegment = TailParts[i - 1];
            distance = Vector3.Distance(prevSegment.position, currentSegment.position);
            Vector3 newposition = prevSegment.position;
            float T = Time.deltaTime * distance / Mindistance * currentSpeed;
            if (T > 0.5f) T = 0.5f;
            currentSegment.position = Vector3.Slerp(currentSegment.position, newposition, T);
            currentSegment.rotation = Quaternion.Slerp(currentSegment.rotation, prevSegment.rotation, T);

        }
    }

    public void TailIncrement(int segmentCount)
    {

    }

}

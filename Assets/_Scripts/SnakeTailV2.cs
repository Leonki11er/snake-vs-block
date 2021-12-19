using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SnakeTailV2 : MonoBehaviour
{
    public Transform SnakeHead;
    public float CircleDiameter;
    public Transform TailPref;
    public Text TailLength;
    public int SnakeLength;
    public int StartLength;


    private List<Transform> snakeCircles = new List<Transform>();
    private List<Vector3> positions = new List<Vector3>();

    private void Awake()
    {
        SnakeLength = 0;
        TailLength.text = SnakeLength.ToString();
        positions.Add(SnakeHead.position);

        TailsAdd(StartLength);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            TailAdd();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            TailRemove();
        }

        float distance = (SnakeHead.position - positions[0]).magnitude;

        if (distance > CircleDiameter)
        {
            Vector3 direction = (SnakeHead.position - positions[0]).normalized;

            positions.Insert(0, positions[0] + direction * CircleDiameter);
            positions.RemoveAt(positions.Count - 1);

            distance -= CircleDiameter;
        }

        for (int i = 0; i < snakeCircles.Count; i++)
        {
            snakeCircles[i].position = Vector3.Lerp(positions[i + 1], positions[i], distance / CircleDiameter);
        }
    }

    public void Die()
    {
        throw new NotImplementedException();
    }

    public void TailsAdd(int tailcount)
    {
        SnakeLength += tailcount;
        TailLength.text = SnakeLength.ToString();
        for (int i = 0; i < tailcount; i++)
        {
            TailAdd();
        }
    }

    public void TailAdd()
    {
        Transform circle = Instantiate(TailPref, positions[positions.Count - 1], Quaternion.identity, transform);
        snakeCircles.Add(circle);
        positions.Add(circle.position);
    }

    public void TailsRemove(int tailcount)
    {
        SnakeLength -= tailcount;
        TailLength.text = SnakeLength.ToString();
        for (int i = 0; i < tailcount; i++)
        {
            TailRemove();
        }
    }

    public void TailRemove()
    {
        if (snakeCircles.Count == 0) return;
        Destroy(snakeCircles[0].gameObject);
        snakeCircles.RemoveAt(0);
        positions.RemoveAt(1);
        SnakeLength--;
        TailLength.text = SnakeLength.ToString();
    }
}

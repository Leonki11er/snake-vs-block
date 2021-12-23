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
    public GameObject SnakeBrake;
    public ParticleSystem SBPS;
    public GameStatement Game_Statement;
    public int RoadsPassed;
    public Rigidbody rb;
    public AudioSource Audio_Source;
    public AudioClip Eat;
    
    private List<Transform> snakeCircles = new List<Transform>();
    private List<Vector3> positions = new List<Vector3>();

    private void Awake()
    {
        SBPS = SnakeBrake.GetComponent<ParticleSystem>();
        RoadsPassed = 0;
        SnakeLength = 0;
        TailLength.text = SnakeLength.ToString();
        positions.Add(SnakeHead.position);
        if(Game_Statement.Snake_Length == 0) TailsAdd(4);
        TailsAdd(Game_Statement.Snake_Length);
    }

    private void Update()
    {
        
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
        
        rb.velocity = new Vector3(0, 0, 0);
        Game_Statement.OnPlayerDied();
    }

    public void Won()
    {
        rb.velocity = new Vector3(0, 0, 0);
        Game_Statement.SetSnakeLength(SnakeLength);
        Game_Statement.OnPlayerReachFinish();
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
        Audio_Source.Play();
        Game_Statement.ScoreIncrement();
        Destroy(snakeCircles[0].gameObject);
        snakeCircles.RemoveAt(0);
        positions.RemoveAt(0);
        SnakeLength--;
        TailLength.text = SnakeLength.ToString();
        SBPS.Play();
    }

    public void EatSound()
    {
        Audio_Source.PlayOneShot(Eat);
    }

    public bool PassRoad()
    {
        RoadsPassed++;
        if (RoadsPassed > Game_Statement.LevelLength) return true;
        return false;
    }
}

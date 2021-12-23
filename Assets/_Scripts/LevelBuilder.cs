using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBuilder : MonoBehaviour
{
    public GameObject RoadStart;
    public GameObject RoadPart;
    public GameObject RoadFinish;
    public float Zoffset;
    public float Yoffset;
    public int RoadLength;

    private void Awake()
    {
        GenerateLevel();
    }

    public void GenerateLevel()
    {
        for(int i = 0; i <= RoadLength; i++)
        {
            if (i == 0)
            {
                GameObject roadstart = Instantiate(RoadStart, new Vector3(transform.position.x, transform.position.y + Yoffset, transform.position.z + Zoffset * i), Quaternion.identity);
                continue;
            }
            if (i == RoadLength)
            {
                GameObject roadfinish = Instantiate(RoadFinish, new Vector3(transform.position.x, transform.position.y + Yoffset, transform.position.z + Zoffset * i), Quaternion.identity);
                continue;
            }


            GameObject roadpart = Instantiate(RoadPart, new Vector3(transform.position.x, transform.position.y + Yoffset, transform.position.z + Zoffset*i), Quaternion.identity);
            roadpart.TryGetComponent(out RoadPart _roadpart);
            _roadpart.SpawnBlockLines();
            _roadpart.SpawnWalls();
            _roadpart.SpawnEggs();
        }
        //GameObject roadpart = Instantiate(RoadPart, new Vector3(transform.position.x, transform.position.y, transform.position.z + Zoffset), Quaternion.identity);
        //roadpart.TryGetComponent(out RoadPart _roadpart);
        //_roadpart.SpawnBlockLines();
        //_roadpart.SpawnWalls();
        //_roadpart.SpawnEggs();d
    }

}

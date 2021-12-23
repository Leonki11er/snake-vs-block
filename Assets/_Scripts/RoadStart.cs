using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadStart : MonoBehaviour
{
    public GameObject Road_Part;
    public GameObject Egg;
    public float Zoffset;

    public float Yoffset; 

    private void Awake()
    {
        SpawnEggs();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!other.TryGetComponent(out SnakeTailV2 snakeTailV2)) return;
        GameObject roadpart = Instantiate(Road_Part, new Vector3(transform.position.x, transform.position.y, transform.position.z + Zoffset), Quaternion.identity);
        roadpart.TryGetComponent(out RoadPart _roadpart);
        _roadpart.SpawnBlockLines();
        _roadpart.SpawnWalls();
        _roadpart.SpawnEggs();
    }
    public void SpawnEggs()
    {
        for (int i = 1; i < 5; i++)
        {
            int randomfactor = Random.Range(0, 100);
            if (randomfactor < 30)
            {
                float offset = i * 4 - 7;
                SpawnEgg(offset);
            }
        }
    }

    public void SpawnEgg(float zpos)
    {
        int randomX = Random.Range(-2, 3);
        GameObject egg = Instantiate(Egg, new Vector3(transform.position.x + randomX, transform.position.y + Yoffset, transform.position.z + zpos), Quaternion.identity);
        egg.TryGetComponent(out Egg _egg);
        int randomMass = Random.Range(2, 10);
        _egg.SetMass(randomMass);
    }
}

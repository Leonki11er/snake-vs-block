using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadPart : MonoBehaviour
{
    public GameObject Road_Part;
    public GameObject Block;
    public GameObject Egg;
    public float Yoffset;
    public GameObject[] WallPool;
    public float Zoffset;
    private void OnTriggerEnter(Collider other)
    {
        if (!other.TryGetComponent(out SnakeTailV2 snakeTailV2)) return;
        GameObject roadpart = Instantiate(Road_Part, new Vector3(transform.position.x, transform.position.y, transform.position.z + Zoffset), Quaternion.identity);
        roadpart.TryGetComponent(out RoadPart _roadpart);
        _roadpart.SpawnBlockLines();
        _roadpart.SpawnWalls();
        _roadpart.SpawnEggs();
    }

    public void SpawnBlockLines()
    {
        for (int i = 0; i < 5; i++)
        {
            float offset = i * 4 - 9;
            SpawnBlockLine(offset);
        }
    }

    public void SpawnBlockLine(float zpos)
    {
        List<GameObject> blockTemp =new List<GameObject>();
        for (int i = 0; i < 5; i++)
        {
            int randomfactor = Random.Range(0, 100); 
            if (randomfactor > 30)
            {
                GameObject block = Instantiate(Block, new Vector3(transform.position.x + (i - 2), transform.position.y + Yoffset, transform.position.z + zpos), Quaternion.identity);
                block.TryGetComponent(out Block _block);
                int randomMass = Random.Range(2, 100);
                _block.SetMass(randomMass);
                blockTemp.Add(block);
                if (blockTemp.Count > 4)
                {
                    int randomblock = Random.Range(0, 5);
                    blockTemp[randomblock].TryGetComponent(out Block tempBlock);
                    int randommass = Random.Range(2, 14);
                    tempBlock.SetMass(randommass);
                }
            }
        }
    }
    
    public void SpawnWalls()
    {
        for (int i = 0; i < 5; i++)
        {
            float offset = i * 4 - 7;
            SpawnWall(offset);
        }
    }

    public void SpawnWall(float zpos)
    {
        for (int i = 0; i < 4; i++)
        {
            int randomfactor = Random.Range(0, 100);
            if (randomfactor > 80)
            {
                int randomwall = Random.Range(0, 6);
                GameObject wall = Instantiate(WallPool[randomwall], new Vector3(transform.position.x + (i - 1.5f), transform.position.y, transform.position.z + zpos), Quaternion.identity);
               
            }
        }
    }

    public void SpawnEggs()
    {
        for (int i = 0; i < 5; i++)
        {
            int randomfactor = Random.Range(0, 100);
            if (randomfactor > 30)
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

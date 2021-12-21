using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadPart : MonoBehaviour
{
    public GameObject Road_Part;
    public GameObject Block;
    public GameObject Egg;
    public float Yoffset;
    //public float Zpos;


    public float Zoffset;
    private void OnTriggerEnter(Collider other)
    {
        if (!other.TryGetComponent(out SnakeTailV2 snakeTailV2)) return;
        GameObject roadpart = Instantiate(Road_Part, new Vector3(transform.position.x, transform.position.y, transform.position.z + Zoffset), Quaternion.identity);
        roadpart.TryGetComponent(out RoadPart _roadpart);
        _roadpart.SpawnLines();
    }

    public void SpawnLines()
    {
        Debug.Log("SpawnLines");
        for (int i = 0; i < 5; i++)
        {
            float offset = i * 4 - 9;
            SpawnLine(offset);
        }
    }

    public void SpawnLine(float Zpos)
    {
        for (int i = 0; i < 5; i++)
        {
            int randomfactor = Random.Range(0, 100); 
            if (randomfactor > 30)
            {
                GameObject block = Instantiate(Block, new Vector3(transform.position.x + (i - 2), transform.position.y + Yoffset, transform.position.z + Zpos), Quaternion.identity);
                block.TryGetComponent(out Block _block);
                int randomMass = Random.Range(2, 100);
                _block.SetMass(randomMass);
            }
            
        }
    }
    
}

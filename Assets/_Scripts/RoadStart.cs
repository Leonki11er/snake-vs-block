using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadStart : MonoBehaviour
{
    public GameObject Road_Part;
    public float Zoffset;
    private void OnTriggerEnter(Collider other)
    {
        if (!other.TryGetComponent(out SnakeTailV2 snakeTailV2)) return;
        GameObject roadpart = Instantiate(Road_Part, new Vector3(transform.position.x, transform.position.y, transform.position.z + Zoffset), Quaternion.identity);
        roadpart.TryGetComponent(out RoadPart _roadpart);
        _roadpart.SpawnLines();
    }
}

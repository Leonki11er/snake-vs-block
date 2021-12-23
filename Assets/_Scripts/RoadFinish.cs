using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadFinish : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!other.TryGetComponent(out SnakeTailV2 snakeTailV2)) return;
        snakeTailV2.Won();
    }
}

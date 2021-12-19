using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Egg : MonoBehaviour
{
    public int EggMass;
    [SerializeField]
    private Text _eggMass;

    private void Awake()
    {
        _eggMass.text = EggMass.ToString();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.collider.TryGetComponent(out SnakeTailV2 snakeTailV2)) return;
        snakeTailV2.TailsAdd(EggMass);
        Destroy(gameObject);
    }

}

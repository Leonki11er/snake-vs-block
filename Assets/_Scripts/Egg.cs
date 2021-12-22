using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Egg : MonoBehaviour
{
    public int EggMass;
    [SerializeField]
    private Text _eggMass;

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.collider.TryGetComponent(out SnakeTailV2 snakeTailV2)) return;
        snakeTailV2.TailsAdd(EggMass);
        Destroy(gameObject);
    }

    public void SetMass(int mass)
    {
        EggMass = mass;
        _eggMass.text = EggMass.ToString();
    }


}

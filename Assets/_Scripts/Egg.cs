using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Egg : MonoBehaviour
{
    public int EggMass;
    [SerializeField]
    private Text _eggMass;
    public GameObject EggPS;

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.collider.TryGetComponent(out SnakeTailV2 snakeTailV2)) return;
        snakeTailV2.TailsAdd(EggMass);
        snakeTailV2.EatSound();
        GameObject egg = Instantiate(EggPS, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    public void SetMass(int mass)
    {
        EggMass = mass;
        _eggMass.text = EggMass.ToString();
    }


}

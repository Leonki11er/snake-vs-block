using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Block : MonoBehaviour
{
    public int BlockMass;
    [SerializeField]
    private Text _blockMass;
    private Material _material;

    private void Awake()
    {
        var renderer = GetComponent<MeshRenderer>();
        _material = Instantiate(renderer.sharedMaterial);
        renderer.material = _material;
    }

    private void OnCollisionStay(Collision collision)
    {

        if (!collision.collider.TryGetComponent(out SnakeTailV2 snakeTailV2)) return;
        Vector3 normal = collision.contacts[0].normal.normalized;
        float dot = Vector3.Dot(normal, Vector3.forward);
        if (dot <= 0.8f) return;
        
        if (snakeTailV2.SnakeLength == 0)
        {
            snakeTailV2.Die();
            return;
        }
            
        StartCoroutine(DamageTake(snakeTailV2));
    }

    public void SetMass(int mass) 
    {
        float blockmass = mass / 100f;
        _material.SetFloat("_blockmass", blockmass);
        BlockMass = mass;
        _blockMass.text = BlockMass.ToString();

    }


    private IEnumerator DamageTake(SnakeTailV2 snakeTailV2)
    {

        BlockMass--;
        _blockMass.text = BlockMass.ToString();
        float blockmass = BlockMass / 100f;
        _material.SetFloat("_blockmass", blockmass);

        snakeTailV2.TailRemove();
        if(BlockMass<=0) Destroy(gameObject);
        yield return new WaitForSeconds(0.8f);

    }
}

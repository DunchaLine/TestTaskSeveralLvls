using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class ChangeColor : ActivateCubesOnStart
{
    void Start()
    {
        SpecificationsCube(gameObject);
    }
    public override void SpecificationsCube(GameObject go)
    {
        Debug.Log("material: " + materials[Random.Range(0, materials.Length)]);
        go.GetComponent<MeshRenderer>().material = materials[Random.Range(0, materials.Length)];
    }
}

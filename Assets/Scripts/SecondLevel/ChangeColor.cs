using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]

public class ChangeColor : CubeSpawner
{

    void Start()
    {
        SettingCube(gameObject);
    }

    public override void SettingCube(GameObject go)
    {
        Debug.Log("material: " + Materials[Random.Range(0, Materials.Length)]);
        go.GetComponent<MeshRenderer>().material = Materials[Random.Range(0, Materials.Length)];
    }
}

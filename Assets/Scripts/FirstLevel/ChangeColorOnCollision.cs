using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorOnCollision : MonoBehaviour
{
    private Material _ownMaterial;
    private Material _otherCubeMaterial;
    private Material _tmp;
    void Start()
    {
        _ownMaterial = GetComponent<MeshRenderer>().material;
    }

    //Если куб соприкасается с другим кубом, то меняем местами цвета у них
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Cube"))
        {
            _otherCubeMaterial = other.gameObject.GetComponent<MeshRenderer>().material;
            _tmp = _ownMaterial;
            _ownMaterial = _otherCubeMaterial;
            other.gameObject.GetComponent<MeshRenderer>().material = _tmp;
        }
    }
}

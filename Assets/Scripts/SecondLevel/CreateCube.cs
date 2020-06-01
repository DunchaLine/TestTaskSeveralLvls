using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCube : UI
{
    public GameObject prefab;
    private Vector3 _position;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("City"))
                    InstantiateCube(hit);
            }
        }
    }

    void InstantiateCube(RaycastHit hit)
    {
        _position = base._cam2DView.isActiveAndEnabled ? 
            new Vector3(hit.point.x, .1f, hit.point.z) : hit.point;
        Instantiate(prefab, _position, Quaternion.identity);
    }
}

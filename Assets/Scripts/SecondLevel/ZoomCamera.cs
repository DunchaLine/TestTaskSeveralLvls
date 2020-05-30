using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomCamera : MonoBehaviour
{
    private float _wheelSpeed = 10f;
    private float _scroll;
    void Start()
    {
        
    }

    void Update()
    {
        _scroll = Input.GetAxis("Mouse ScrollWheel");
        if (_scroll != 0)
        {
            transform.position += transform.forward * _wheelSpeed * _scroll;
        }
    }
}

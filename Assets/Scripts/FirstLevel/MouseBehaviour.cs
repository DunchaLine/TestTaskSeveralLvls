using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseBehaviour : MonoBehaviour
{
    private Vector3 _objPosition;
    private Vector3 _mousePosition;
    private Vector3 _direction;
    private Rigidbody _rb;
    void Start()
    {
        _objPosition = transform.position;
        _rb = GetComponent<Rigidbody>();
    }
    //Если ПКМ на кубе, то отключаем объект
    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (gameObject.CompareTag("Cube"))
            {
                gameObject.SetActive(false);
            }            
        }
    }

    //Если зажата ЛКМ, то двигаем объект куда движется мышка
    void OnMouseDrag()
    {
        RaycastHit _hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out _hit))
        {
            var _newPos = _hit.point;
            _rb.MovePosition(new Vector3(_hit.point.x, .4f, _hit.point.z));
        }
    }
}

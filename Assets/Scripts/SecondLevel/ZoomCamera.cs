using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomCamera : MainForCamera
{
    protected Camera _mainCamera;
    private float _wheelSpeed = 10f;
    private float _target;
    private float _scroll;
    private Vector3 _mousePositionOnClick;
    private Vector3 _currMousePosition;
    private Vector3 _positionToMove;
    private Vector3 _startPosition;

    public void Awake()
    {
        _startPosition = transform.position;
        _mainCamera = Camera.main;
        _target = _mainCamera.orthographicSize;
    }

    void Update()
    {
        if (_mainCamera.isActiveAndEnabled)
        {
            _scroll = Input.GetAxis("Mouse ScrollWheel");
            if (_scroll != 0)
            {
                Zoom();
            }
            //при первом нажатии на ПКМ запоминаем позицию мышки
            if (Input.GetMouseButtonDown(1))
            {
                _mousePositionOnClick = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f);
                _mousePositionOnClick = Camera.main.ScreenToWorldPoint(_mousePositionOnClick);
            } 
            //если ПКМ зажата, то передаем позицию мышки во время нажатия и вызываем метод перемещения камеры
            if (Input.GetMouseButton(1))
            {
                TranslateCamera(_mousePositionOnClick);
            }
        }
        
    }

    //Зум камеры с ограничением в 2-10
    void Zoom()
    {
        _target = Mathf.Clamp(-_scroll * 100, 2f, 10f);
        _mainCamera.orthographicSize = Mathf.Lerp(_mainCamera.orthographicSize, _target, Time.deltaTime * _wheelSpeed);
    }
    //Перемещение камеры
    public override void TranslateCamera(Vector3 pos)
    {
        _currMousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f);
        _currMousePosition = Camera.main.ScreenToWorldPoint(_currMousePosition);
        _positionToMove = _mousePositionOnClick - _currMousePosition;
        transform.position += _positionToMove * .1f;
    }  
}

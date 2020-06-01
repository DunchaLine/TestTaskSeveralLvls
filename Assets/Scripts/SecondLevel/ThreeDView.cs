using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreeDView : MainForCamera
{
    public Transform objToLook;
    private Camera _cam;
    private int _speed;
    private float _startTime, _distance;
    private Vector3 _positionToTeleport;
    private bool _isStart;
    private Vector3 _relativePos;
    private Quaternion _rotation;
    void Start()
    {
        _isStart = true;
        _positionToTeleport = new Vector3(-9f, .2f, 0f);
        _startTime = Time.time;
        _speed = 1;
        _cam = Camera.main;
    }
    void Update()
    {
        TranslateCamera(_positionToTeleport, _isStart);
    }

    //На старте плавно перемещаем камеру в режим 3д, после чего каждый фрейм следим за объектом
    public override void TranslateCamera(Vector3 vector, bool isStart)
    {
        if (_isStart)
        {
            RotationCamera();
            _distance = Vector3.Distance(transform.position, _positionToTeleport);
            float _differenceTime = (Time.time - _startTime) * _speed;
            float _partOfDistance = _differenceTime / _distance;
            transform.position = Vector3.Lerp(transform.position, _positionToTeleport, _partOfDistance);
            if (transform.position == _positionToTeleport)
            {
                _isStart = false;
                Debug.Log(_isStart);
            }
        }
        else
        {
            RotationCamera();
        }
    }
    //поворот камеры за объектом
    private void RotationCamera()
    {
        _relativePos = objToLook.position - transform.position;
        _rotation = Quaternion.LookRotation(_relativePos, Vector3.up);
        transform.rotation = _rotation;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class Controller : ThreeDView
{
    public CinemachineVirtualCamera cam3D;
    private bool _start3DView;
    private CharacterController _characterController;
    private float _characterSpeed = 3f;
    private float _characterRotation = 5f;
    private Vector3 _posToTp;
    private float _timeOnStart;
    private float _horizontal, _vertical;

    void Start()
    {
        cam3D.GetComponent<CinemachineVirtualCamera>();
        _posToTp = base._positionToTeleport;
        Debug.Log("_posToTp: " + _posToTp);
        _start3DView = true;
        _timeOnStart = Time.time;
        _characterController = GetComponent<CharacterController>();
    }
    void FixedUpdate()
    {
        if (base.threeDCamera.isActiveAndEnabled)
        {
            //Отслеживаем перемещение игрока при помощи CharacterController
            Vector3 _direction = new Vector3(Input.GetAxis("Vertical"), 0f, -Input.GetAxis("Horizontal"));
            //получаем вектор куда смотрит объект
            _direction = transform.TransformDirection(_direction);
            //двигаемся в направлении этого вектора
            _characterController.Move(new Vector3(_direction.x, 0f, _direction.z) * _characterSpeed * Time.fixedDeltaTime);
            //при включении камеры 3д вида получаем координаты куда должна "прилететь камера", и плавно туда перемещаемся 
            TranslateCamera(_posToTp, _start3DView);
            //Если зажата ПКМ - игрок может осмотреться
            if (Input.GetMouseButton(1))
            {
                _horizontal += Input.GetAxis("Mouse X") * _characterRotation;
                _vertical += Input.GetAxis("Mouse Y") * _characterRotation;
                transform.eulerAngles = new Vector3(0f, _horizontal, _vertical);
            }
        }
        
    }

    public override void TranslateCamera(Vector3 posToTp, bool start)
    {
        if (start)
        {
            float _distance = Vector3.Distance(transform.position, posToTp);
            float _differenceTime = 1.4f;
            float _partOfDistance = _differenceTime / _distance;
            transform.position = Vector3.Lerp(transform.position, posToTp, _partOfDistance);
            base.TranslateCamera(cam3D);
            if (transform.position == posToTp)
            {
                _start3DView = false;
                return;
            }
        }
    }
}

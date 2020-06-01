using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ThreeDView : MainForCamera
{
    public Camera threeDCamera;
    public CinemachineVirtualCamera vcam;
    protected Vector3 _positionToTeleport;
    public void Awake()
    {
        vcam = GetComponent<CinemachineVirtualCamera>();
        _positionToTeleport = new Vector3(-8.2f, .6f, 0f);
    }
    public override void TranslateCamera(CinemachineVirtualCamera _tmpCam)
    {
        _tmpCam.GetComponent<CinemachineVirtualCamera>();
        var _transposer = _tmpCam.GetCinemachineComponent<CinemachineTransposer>();
        _transposer.m_FollowOffset = new Vector3(-.2f, .08f, 0f);
    }
}

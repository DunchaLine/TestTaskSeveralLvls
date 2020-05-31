using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : ZoomCamera
{
    private Camera _cam;
    void Start()
    {
        _cam = base._mainCamera;
    }
    public void ThreeDView()
    {
        if (base._mainCamera.orthographic == true)
        {
            base._mainCamera.orthographic = false;
        }
        else
        {
            base._mainCamera.orthographic = true;
        }
    }
}

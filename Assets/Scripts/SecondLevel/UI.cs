﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class UI : MonoBehaviour
{
    public GameObject ground;
    public Camera _cam2DView;
    public Camera _cam3DView;
    //Меняем вид камеры
    public void ThreeDView()
    {
        if (_cam2DView.isActiveAndEnabled)
        {
            _cam2DView.gameObject.SetActive(false);
            _cam3DView.gameObject.SetActive(true);
        }
        else
        {
            _cam3DView.gameObject.SetActive(false);
            _cam2DView.gameObject.SetActive(true);
        }
    }

    public void MenuButton()
    {
        SceneManager.LoadScene(0);
    }
}

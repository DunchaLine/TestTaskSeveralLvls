using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour
{
    public Dropdown list;
    void Start()
    {
        list.GetComponent<Dropdown>();
    }
    public void ExitButton()
    {
        Application.Quit();
    }
    public void LoadButton()
    {
        SceneManager.LoadScene(list.value + 1);
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_FirstLevel : MonoBehaviour
{
    /// <summary>
    /// При нажатии на кнопку рестарта
    /// </summary>
    public void Restart()
    {
        SceneManager.LoadScene(1);
    }

    /// <summary>
    /// При нажатии на кнопку выхода в меню
    /// </summary>
    public void MenuButton()
    {
        SceneManager.LoadScene(0);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{

    public void CambiarEscena()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 0f;
    }


    public void RegresarEscena()
    {
        SceneManager.LoadScene(0);
    }

    public void Exit()
    {
        Application.Quit();
    }
}

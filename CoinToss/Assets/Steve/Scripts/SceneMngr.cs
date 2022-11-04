using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMngr : MonoBehaviour
{
    public void LoadMain()
    {
        SceneManager.LoadScene("Main_S", LoadSceneMode.Single);
    }

    public void LoadStart()
    {
        SceneManager.LoadScene("Start_S", LoadSceneMode.Single);
    }
    public void LoadEnd()
    {
        SceneManager.LoadScene("End_S", LoadSceneMode.Single);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}

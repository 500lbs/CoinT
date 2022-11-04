using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMngr : MonoBehaviour
{
    public void LoadStart()
    {
        SceneManager.LoadScene("Start_Nov4", LoadSceneMode.Single);
    }
    public void LoadMain()
    {
        SceneManager.LoadScene("Main_Nov4", LoadSceneMode.Single);
    }
    public void LoadEnd()
    {
        SceneManager.LoadScene("End_Nov4", LoadSceneMode.Single);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}

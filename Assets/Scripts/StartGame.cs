using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{

    private string nextSceneName = "towerdefense";

    public void LoadNextScene()
    {
        SceneManager.LoadScene(nextSceneName);
    }

}

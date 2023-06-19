using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class SceneChanger : MonoBehaviour
{
    public VideoPlayer VP;
    
    public void Update()
    {
        if (VP != null)
        {
            checkOver(1);
        }
        
    }

    //play this every frame until done
    private void checkOver(int index)
    {
        long playerCurrentFrame = VP.GetComponent<VideoPlayer>().frame;
        long playerFrameCount = Convert.ToInt64(VP.GetComponent<VideoPlayer>().frameCount);
        Debug.Log(playerCurrentFrame + " current frame");
        Debug.Log("Max frame: " +playerFrameCount);

        if (playerCurrentFrame < (playerFrameCount - 1))
        {
            Debug.Log("VIDEO IS PLAYING");
        }
        else
        {
            Debug.Log("VIDEO IS OVER");
            ChangeScene(index);
            
        }
    }
    public void ChangeScene(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void Restart()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}

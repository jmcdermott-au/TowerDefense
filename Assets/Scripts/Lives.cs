using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Lives : MonoBehaviour
{
    public int lives = 10;
    public TextMeshProUGUI livesRemainingText;
    public GameObject GameOverScreen;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        livesRemainingText.text = $"{lives} Summoners Alive";
        GameOverScreen.SetActive(false);
    }

    public void UpdateLives()
    {
        livesRemainingText.text = $"{lives} Summoners Alive";
        if (lives <= 0)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        GameOverScreen.SetActive(true);
    }

}


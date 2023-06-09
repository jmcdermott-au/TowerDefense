using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;

    private float timeBetweenEnemys = 0.5f;

    public Transform spawnPoint;

    public float timeBetweenWaves = 5f;
    //seconds between each wave
    private float countdown = 2f;
    //initial countdown

    private int waveIndex = 1;

    public Text waveCountDownText;

    private void Update()
    {
     if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;

        waveCountDownText.text = Mathf.Round(countdown).ToString();
        //mathf Round will count  to whole number before we display
    }

    IEnumerator SpawnWave()
    {
        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(timeBetweenEnemys);
        }

        Debug.Log($"Wave No. {waveIndex}");
        waveIndex++;

    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }


}

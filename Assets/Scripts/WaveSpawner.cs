using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{


    //this is an array that will contain all of the enemies to be spawned in a given wave. 
    //to make a new wave, create a new scene with a new instance of this script on something.
    //then, in the inspector, you can edit this array to add/remove enemies from it. Drag enemy prefabs into that array.
    public Transform[] enemiesInWave;


    //the prefab being spawned
    public Transform enemyPrefab;

    //time between enemies for the coroutine
    private float timeBetweenEnemys = 0.5f;

    //spawnpoint transform (this can be used to make a wave come out of two places, probably.)
    public Transform spawnPoint;

    //the time between waves, self explanitory
    public float timeBetweenWaves = 5f;
    //seconds between each wave
    private float countdown = 2f;
    //initial countdown

    //what wave you're up to 
    private int waveIndex = 1;

    //the text displaying the wave
    public Text waveCountDownText;

    private void Update()
    {

        //if the countdown is done, start the coroutine to start the wave
     if (countdown <= 0f)
        {
            //start coroutine
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves; //reset countdown
        }

     //every frame, but adjusted for frames, subtract the countdown
        countdown -= Time.deltaTime;
        //update the countdown from whole number to whole number
        waveCountDownText.text = Mathf.Round(countdown).ToString();
        //mathf Round will count  to whole number before we display
    }


    //this is where spawning the whole wave happens
    IEnumerator SpawnWave()
    {

        for (int i = 0; i < enemiesInWave.Length; i++)
        {
            SpawnEnemy(enemiesInWave[i]);
            yield return new WaitForSeconds(timeBetweenEnemys);
        }
        


        ////foreach in the wave index, spawn an enemy
        //for (int i = 0; i < waveIndex; i++)
        //{
        //    SpawnEnemy(enemyPrefab);
        //    //spawn an enemy, then wait timeBetweenEnemies to spawn another
        //    yield return new WaitForSeconds(timeBetweenEnemys);
        //}
        ////debug the wave index, then increment index
        //Debug.Log($"Wave No. {waveIndex}");
        //waveIndex++;
        
    }


    //the way i want this to work, is create an array with a buncha prefabs in it, 
    //Transform[] EnemiesInWave;
    //foreach Transform in EnemiesInWave;
        //SpawnEnemy(the enemy being spawned, like using an index in the array)
        //wait


    //spawn an enemy using instantiate a prefab

    //russel, I'm changing this method to take an argument, which is going to be the type of enemy being used
        //so SpawnEnemy(Transform), just so i can get this to spawn different enemies, shit like that.
    void SpawnEnemy(Transform enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
        Debug.Log("Spawned " + enemy); //logging in the console the enemy spawned
        //theoretically rn it should spawn five enemies
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{

    //the code for this should be:
    // if readyToSpawnWave = true
        //if waveSpawned = false
            //if countdown <= 0
                //spawn Wave CurrentWave
                //waveSpawned = true
            //countdown--
    //if All enemies are dead
    //waveindex++, readyToSpawnWave = false, waveSpawned = false
    
    //if waveIndex > Lastwave
    //WinLevel();




    [System.Serializable]
    public class Wave //wave contains an array, of enemies
    {
        public Transform[] enemiesInWave;
    }

    #region WaveEnd
    public GameObject winDisplay;

    /// <summary>
    /// Sets timescale to 0, and sets gameobject winDisplay to be active.
    /// Use this when the player has beaten all waves in a level.
    /// </summary>
    public void WinLevel()
    {
        Time.timeScale = 0f;
        winDisplay.SetActive(true);
    }

    #endregion

    #region Attributes

    //an array that contains the waves in a level
    public Wave[] waves;
    
    //the index of the wave we are on
    public int currentWaveIndex = 0;

    //enemies currently alive
    public GameObject[] enemiesAlive;

    //has the current wave spawned
    public bool waveSpawned = false;
    
    //are we ready to spawn the next wave
    public bool readyToSpawnWave = false;

    //the prefab being spawned
    public Transform enemyPrefab;

    //time between enemies for the coroutine
    private float timeBetweenEnemys = 0.5f;

    //spawnpoint transform (this can be used to make a wave come out of two places, probably.)
    public Transform spawnPoint;

    //the time between waves, self explanitory
    public float timeBetweenWaves = 5f;
    //seconds between each wave
    private float countdown =5f;
   

    //the text displaying the wave
    public Text waveCountDownText;
    
    /// <summary>
    /// If all enemies are dead, return true.
    /// </summary>
    /// <returns></returns>
    public bool AllEnemiesdead()
    {

        enemiesAlive = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemiesAlive.Length == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }



    #endregion

    #region Unity Methods
    public void Awake()
    {
        //not ready to spawn wave
        readyToSpawnWave = false;
        //havent spawned the wave
        waveSpawned = false;
        
    }

    
    private void Update()
    {
        
        

        //if ready to spawn the wave
        if (readyToSpawnWave)
        {

            //and the wave has not spawned
            if (waveSpawned == false)
            {
                
                //if the countdown is done, start the wave
                if (countdown <= 0f)
                {
                    //Spawn the wave
                    StartCoroutine(SpawnWave());
                    waveSpawned = true;
                    waveCountDownText.text = ""; //set countdown text to nothing
                    
                }

                //decrement countdown
                countdown -= Time.deltaTime;
                //update the countdown
                waveCountDownText.text = Mathf.Round(countdown).ToString();

               
            }

            //if the player has finished that wave
            if (waveSpawned & AllEnemiesdead())
            {
                //if that was the last wave
                if (currentWaveIndex == waves.Length -1)
                {
                    WinLevel();
                    return;
                }
                //move on to next wave
                currentWaveIndex++;
                //wave is not ready to spawn
                readyToSpawnWave = false;
                countdown = timeBetweenWaves;
                
            }
        }
        if (!readyToSpawnWave)
        {
            waveCountDownText.text = "ready to spawn wave";
            waveSpawned = false;
        }

        
    }
    #endregion

    #region Spawning
    /// <summary>
    /// Sets ReadyToSpawn to be true.
    /// </summary>
    public void ReadyToSpawn()
    {
        readyToSpawnWave = true;
    }
    
    /// <summary>
    /// Spawns the Wave at currentWaveIndex in Waves[].
    /// </summary>
    /// <returns></returns>
    IEnumerator SpawnWave()
    {

        //if all waves completed, win level
        if (currentWaveIndex > waves.Length)
        {
            Debug.Log("All waves completed");
            WinLevel();
        }
        else //if all waves have not been completed
        {
            //currentWave is the wave being spawned
            Wave currentWave = waves[currentWaveIndex];

            //spawn the enemies in that wave
            for (int i = 0; i < currentWave.enemiesInWave.Length; i++)
            {
                SpawnEnemy(currentWave.enemiesInWave[i]);
                yield return new WaitForSeconds(timeBetweenEnemys);
            }
        }

    }

    /// <summary>
    /// Instantiates an enemy prefab at the spawnpoint.
    /// </summary>
    /// <param name="enemy"></param>
    void SpawnEnemy(Transform enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
        Debug.Log("Spawned " + enemy); 
    }

    #endregion

    
}

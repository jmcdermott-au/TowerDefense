using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

   

    private Lives livesScript;

    [Header("IMMUNITIES")]
    public bool immunity1;
    public bool immunity2;
    public bool immunity3;
    [Space(20)]

    [Header("Attributes")]
    public float speed = 10f;

    public int health = 100;

    private Transform target;

    private int waypointIndex = 0;

    public int moneyGained = 25;

    public GameObject impactEffect;



   

    private void Start()
    {
        
        GameObject gameManager = GameObject.Find("GameManager");
        livesScript = gameManager.GetComponent<Lives>();
        
        target = WayPoints.points[0];
    }

    public void TakeDamage(int ammount)
    {
        health -= ammount;

        if (health <= 0)
        {
            Die();

        }
    }


    /// <summary>
    /// Adds Currency, destroys gameObject
    /// </summary>
    void Die()
    {
        //increase money
        Currency.money += moneyGained;

        //enemy death particles
        if (impactEffect != null)
        {
            GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(effectIns, 2f);
        }

        Destroy(gameObject);
    }



    //from what i understand, each set of waypoints is the same for each wave, so it'd take quite a bit of effort to separate them.
    //so currently its impossible to create multiple lanes
    private void Update()
    {
        Vector3 dir = target.position - transform.position;
        //this will give us direction vector
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        //Translate move transform in the direction
        //Normalize will keep a fixed speed, deltatime will keep the speed consistant irrelevant of framerate
        //moving in worldspace

        if(Vector3.Distance(transform.position, target.position) < 0.4f)
            //if we are within 0.2f of target then close enough and we should change
        {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint()
    {
        if (waypointIndex >= WayPoints.points.Length -1)
        {
            livesScript.lives -= 1; // Increment the lives variable in the Lives script
            livesScript.UpdateLives(); // Call the UpdateLives() method
            
            Destroy(gameObject);
            return;
        }
        waypointIndex++;
        target = WayPoints.points[waypointIndex];
        //change point index to +1
    }

}

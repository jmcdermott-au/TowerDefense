using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float speed = 10f;

    public int health = 100;

    private Transform target;

    private int waypointIndex = 0;

    public int moneyGained = 25;

    private void Start()
    {
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

    void Die()
    {
        Currency.money += moneyGained;
        Destroy(gameObject);
    }

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
            Destroy(gameObject);
            return;
        }
        waypointIndex++;
        target = WayPoints.points[waypointIndex];
        //change point index to +1
    }

}

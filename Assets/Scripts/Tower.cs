using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{

    private Transform target;

    [Header("Attributes")]
    //would be useful if i could add damage to this
    public float range = 15f;
    public float fireRate = 1f;
    private float fireCooldown = 0f;
    //these overrite the default values of the bullet
    public int damage = 30;
    public float bulletSpeed = 70f;

    [Header("Unity Fields")]
    public string enemyTag = "Enemy";

    public Transform partToRotate;
    public float turnSpeed = 10f;

    public GameObject bulletPrefab;
    public Transform firePoint;
        

    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.1f);
        //this will run the method every 0.1seconds, rather than update to save fps, can be slower for more fps
    }

    void Update()
    {
        if (target == null)
        {
            return; //no target, do nothing
        }

        //Target lock on
        Vector3 dir = target.position - transform.position;
        // when going from A to B you need end (B) - (A)
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        //Lerp is smooth transition
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 90f);

        //if ready to fire
        if (fireCooldown <= 0f)
        {
            //call shoot method, reset cooldown based upon firerate
            Shoot();
            fireCooldown = 1f/ fireRate;
        }
        //count down cooldown
        fireCooldown -= Time.deltaTime;
        
    }

    void Shoot()
    {
        Debug.Log("Shoot");
        GameObject bulletGameObject = (GameObject) Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        //create bullet, at firepoint, in direction of firepoint
        Bullet bullet = bulletGameObject.GetComponent<Bullet>();

        //this is probably where i can overrite the bullet stats
        //let me try here
        bullet.speed = bulletSpeed;
        bullet.damage = damage;
        bullet.immunitySelfPrefab = bulletPrefab;

        //if bullet got a target
        if (bullet != null)
        {
            bullet.Seek(target);
        }

    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies) 
        { 
            float distanceToEnemy = Vector3.Distance (transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
                //check if current enemy is closer than previous enemies
            {
                shortestDistance = distanceToEnemy;
                //update shortest distance to this distance
                nearestEnemy = enemy;
                //set nearest enemy to this enemy
            }
        }
        if (nearestEnemy != null&& shortestDistance <= range) 
            //if nearest enemy exists and within range
        { 
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}

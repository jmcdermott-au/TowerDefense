using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;

    public float speed = 70f;
    public GameObject impactEffect;

    public float explosionRadius = 0f;

    public int damage = 30;

    public void Seek (Transform _target)
    {
        target = _target;
    }

    void Update()
    {

        //if the target is destroyed then destroy our bullet to.
        if (target == null) 
        {
            Destroy(gameObject);
            return;
        }

        //direction = final destinaion - start position
        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;


        //direction magnitude gives the length of this vector, it is distance from bullet to target
        //distance this frame tells us how far we will move this frame 
        // if the enemy is 8meteres away but we move 10meteres closer then we go through it/ hit it
        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            
            return;
        }

        //normalise gives constant speed
        transform.Translate (dir.normalized * distanceThisFrame, Space.World);

    }

    void HitTarget()
    {
        //add particle effect with current object transforms
        GameObject effectIns = (GameObject) Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectIns, 2f);
        //destroy the particle after 2seconds, to avoid performance issues.
        if (explosionRadius > 0f) 
        {
            Explode();
        }
        else
        {
            Damage(target);
        }

        //add dammage here
        Destroy (gameObject);
        //destory our bullet
    }

    void Explode()
    {
        //this will create an sphere and check all colliders inside this sphere and create an array of objects
        Collider[] objectsHit = Physics.OverlapSphere(transform.position, explosionRadius);
        //check each object we have hit in the array
        foreach (Collider collider in objectsHit)
        {
            //if the object has enemy tag then we run damage function
            if(collider.tag == "Enemy")
            {
                Damage(collider.transform);
            }
        }

        
    }

    void Damage (Transform enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();

        if (e != null)
        {
            e.TakeDamage(damage);
        }
    }

}

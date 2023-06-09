using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    [Header("IMMUNITIES")]
    public bool bulletImmunity1;
    public bool bulletImmunity2;
    public bool bulletImmunity3;
    [Space(20)]

    //it would be pretty useful if these attributes could be overriden / modified by the tower itself
    private Transform target;
    



    [Space(20)]
    [Header("Attributes")] 
    
    //THESE ARE ALL DEFAULTS, CHANGE THESE USING TOWER
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

       
        if (ImmunityCheck(e)) //does immunity check
        {
            
            //checking for enemy
            if (e != null)
            {
                e.TakeDamage(damage);
            }
        }
    }


    //check each immunity the enemy has that is true, if the bullet's respective immunity is also true, return false
    //else return true

    //the way i have done this is pretty shit.
    public bool ImmunityCheck(Enemy enemy)
    {
        if (enemy.immunity1 & bulletImmunity1 == true)
        {
            return false;
        }

        if (enemy.immunity2 & bulletImmunity2 == true)
        {
            return false;
        }
        
        if (enemy.immunity3 & bulletImmunity3 == true)
        {
            return false;
        }

        return true;
    }
}

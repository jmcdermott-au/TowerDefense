using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordDetect : MonoBehaviour
{
    public float cooldownTime = 5f;
    private float timer = 0f;
    private float detectionDistance = 6.5f;
    private string enemyTag = "Enemy";
    [SerializeField] private Animator animator;
    public SwordDamage swordDamage;

    // Start is called before the first frame update
    void Start()
    {
        timer = cooldownTime;
        InvokeRepeating("DetectEnemy", 0f, 0.1f);
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
    }


    private void DetectEnemy()
    {
        Debug.Log("Detect");
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy <= detectionDistance && timer <= 0)
            {
                Swing();
            }
        }
    }

    public void Swing()
    {
        Debug.Log("Swing");
        animator.SetTrigger("Spin");
        swordDamage.Swing();
        timer = cooldownTime;
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionDistance);
    }


}

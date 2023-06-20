using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordDamage : MonoBehaviour
{
    [SerializeField] private Collider swordCollider;
    public bool isSwinging = false;

    public int damage = 100;

    private void Start()
    {
        swordCollider = GetComponent<Collider>();
        swordCollider.isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("trigger enter");
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Enemy Tag Found");

            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
                Debug.Log("HIT");
            }
        }
    }

    public void Swing()
    {
        isSwinging = true;
        StartCoroutine(EndSwing());
    }

    private IEnumerator EndSwing()
    {
        yield return new WaitForSeconds(0.4f);
        isSwinging = false;
    }
}
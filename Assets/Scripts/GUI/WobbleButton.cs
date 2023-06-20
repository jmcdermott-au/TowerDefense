using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WobbleButton : MonoBehaviour
{

    public Animator animator;
    public TurretBlueprint SpawningThing;

    [Header("Wobble")]
    //public Transform guiTransform;
    //public bool rotating;
    //public float rotation;
    //public float rotationMax = 2f;
    //public float rotationMin = -2f;
    //public float lerp = 0.5f;

    

    [Header("Selected")]
    public BuildManager buildManager;
    public bool buttonSelected()
    {
        if (buildManager.turretToBuild == SpawningThing)
        {
            return true;
        }
        else 
        {
            return false;
        }
    }
    
     
    public void Awake()
    {
        GameObject gameManager = GameObject.Find("GameManager");
        //guiTransform = transform;
        buildManager = gameManager.GetComponent<BuildManager>();
        animator = gameObject.GetComponent<Animator>();

    }
    public void Update()
    {
        //rotating = buttonSelected();
        animator.SetBool("IsButtonSelected", buttonSelected());
        //THIS IS FOR WOBBLE
        //if (rotating)
        //{

        //    rotation = Mathf.Lerp(rotationMin, rotationMax, lerp);
        //    lerp += 0.7f * Time.deltaTime;

        //    //lerp reset
        //    if (lerp > 1.0f)
        //    {
        //        float temp = rotationMax;
        //        rotationMax = rotationMin;
        //        rotationMin = temp;
        //        lerp = 0.0f;
        //    }
        //    Vector3 amongus = new Vector3(0, 0, rotation);
        //    guiTransform.eulerAngles = amongus;
        //}
        //else
        //{
        //    ResetRot(); //i dont like this running every frame, but whatever    
        //}

    }

    //public void ResetRot()
    //{
    //    guiTransform.eulerAngles = Vector3.zero;
    //    lerp = 0.5f;
    //}

    //public void StopStartRot(bool flip)
    //{
    //    rotating = flip;
    //}
    




}

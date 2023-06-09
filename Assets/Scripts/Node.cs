using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{

    public Color hoverColor;
    private Color startColor;

    private Renderer rend;

    [Header("Optional")]
    public  GameObject turret;

    public Vector3 positionOffset;
    //add height to our turret

   

    BuildManager buildManager;

    void Start()
    {
        rend = GetComponent<Renderer>();    
        startColor = rend.material.color;
        //get original color from renderer

        buildManager = BuildManager.instance;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    private void OnMouseDown()
    {

        if (EventSystem.current.IsPointerOverGameObject())
            return;

        //if we have no turret selected then clicking will do nothing
        if (!buildManager.CanBuild)
            return;
        

        if (turret != null)
        {
            Debug.Log("Can't build right now");
            return;
        }

        buildManager.BuildTurretOn(this);

    }

    void OnMouseEnter()
    {

        //This will check if the pointer is over an eventsystem object (ie buttons) and thus wont build accidentally
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        //if we have no turret selected return, otherwise highlight cell
        if (!buildManager.CanBuild)
            return;

        GetComponent<Renderer>().material.color = hoverColor;
        //change color when mouseover to hovercolor
    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
        //revert to original color
    }

}

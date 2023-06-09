using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint standardTurret;
    public TurretBlueprint standardTurret2;

    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }



    //J- these methods call SelectTurretToBuildwith a param
    //instead of creating a new method for each turret, this should be one method with a changing param. The challenge is wrangling unity's buttons with the parameters
    //i think these should be replaced by making the buttons call SelectTurretToBuild directly, and changing its param for each, will try that out.

    //i understand why these shenanigans are happening

    //this sucks but its slightly better than creating one for each new turret type
    //for some reason this refuses to work
    //public void SelectTurret(TurretBlueprint turret) 
    //{
    //    Debug.Log("Selected Turret: " + turret);
    //    buildManager.SelectTurretToBuild(turret);
    //}

    //public void SelectStandardTurret()
    //{
    //    Debug.Log("Standard Turret Selected");
    //    buildManager.SelectTurretToBuild(standardTurret);
    //}

    //public void SelectStandardTurret2()
    //{
    //    Debug.Log("Selected Turret no.2");
    //    buildManager.SelectTurretToBuild(standardTurret2);
    //}

}

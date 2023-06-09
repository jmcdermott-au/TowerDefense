using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{

    public static BuildManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("More than one Buildmanager in scene");
        }
            instance = this;
        
    }
    //this is a singleton

    public GameObject standardTurretPrefab;
    public GameObject standardTurretPrefab2;

   

    private TurretBlueprint turretToBuild;

    public bool CanBuild { get { return turretToBuild != null; } }
    //check if turret to build is not equal to null, if true we can build

    public void BuildTurretOn(Node node)
    {
        if (Currency.money < turretToBuild.cost)
        {
            Debug.Log("Not Enough Money");
            return;
        }
        Currency.money -= turretToBuild.cost;

       GameObject turret = (GameObject) Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;
    }

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;

    }

}

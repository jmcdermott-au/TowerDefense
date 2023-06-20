using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    //public GameObject buttonBadness;


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


    [SerializeField]
    public TurretBlueprint turretToBuild; //TEMP MAKING PUBLIC

    public bool CanBuild { get { return turretToBuild != null; } }
    //check if turret to build is not equal to null, if true we can build

    public void BuildTurretOn(Node node)
    {
        //checks if you have enough money
        if (Currency.money < turretToBuild.cost)
        {
            Debug.Log("Not Enough Money");
            return;
            //if you dont have enough money, log ^
        }
        //if you have enough money, subtract the currency
        Currency.money -= turretToBuild.cost;
        Debug.Log(Currency.money);
        //creates a turret on the selected node
       GameObject turret = (GameObject) Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;
        // J- I don't know what this line does ^
    }


    /// <summary>
    /// Chooses which turret to build based off of TurretBlueprint
    /// </summary>
    /// <param name="turret"></param>
    /// 
    //why cant i put this on A button? thats the question
    //we really should just run this directly instead of whatever is going on in Shop, because its just a repeat of code, which sucks
    public void SelectTurretToBuild(GameObject turret)
    {
        turretToBuild = turret.GetComponent<TurretBlueprint>();
       
    }

}

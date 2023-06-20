using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Turret Blueprint
//contains a gameobject that is a prefab
//contains a cost
//the prefab that these are meant to contain are ones that have the Tower script on them.

//to create a new Tower, make a new GameObject with Tower on it, and change the stats of the tower from that script.
//Then, to make the buttons work, create an empty gameobject with this script on it, and put the tower prefab on the prefab variable
//set a cost,
//create a prefab, that is the empty gameobject with this script on it
//then make the buttons call SelectTurretToBuild with the blueprint prefab you just made.
public class TurretBlueprint:MonoBehaviour 
{
    public GameObject prefab;
    public int cost;
    

}
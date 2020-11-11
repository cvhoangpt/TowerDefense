

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.Log("More than one BM in scene </?>");
            return;
        }
        instance = this;

    }

    public GameObject buildEffect;


    //Defintion for turretBlueprint
    private TurretBlueprint turretToBuild;

    //check whether we choose missle or turret or not
    public bool CanBuild { get { return turretToBuild != null; } }
    //Check whether has money or not when set node
    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }


    //Build turrettobuild on a node
    public void BuildTurretOn(Node node)
    {
        if(PlayerStats.Money < turretToBuild.cost)
        {
            Debug.Log("Not enough money!");
            return;

        }

        PlayerStats.Money -= turretToBuild.cost;
        GameObject turret = (GameObject) Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;

        GameObject effect = (GameObject) Instantiate(buildEffect, node.GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        Debug.Log("Turret build! Money left : " + PlayerStats.Money);
    }
    

    
    // Create new function Select Turret to build

    public void SelectTurretToBuild (TurretBlueprint turret)
    {
        turretToBuild = turret;
    }

}

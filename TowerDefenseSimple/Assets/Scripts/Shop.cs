using UnityEngine;

public class Shop : MonoBehaviour
{
    //Code added for currency 
    public TurretBlueprint standardTurret;
    public TurretBlueprint missleLauncher;
    public TurretBlueprint laserBeamer;

    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }

    //routes to build manager for processing when select turret blue print
    public void SelectStandardTurret()
    {
        Debug.Log("Standard Turret Selected");
        buildManager.SelectTurretToBuild(standardTurret);
    }

    public void SelectMissileLauncher()
    {
        Debug.Log("Missile Launcher Selected");
        buildManager.SelectTurretToBuild(missleLauncher);
    }

    public void SelectLaserBeamer()
    {
        Debug.Log("Laser Beamer Selected");
        buildManager.SelectTurretToBuild(laserBeamer);
    }
}

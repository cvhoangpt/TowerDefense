﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] // to load all values in the inspector to edit
//Delete mono behaviour cause we dont want to attach to any game object
public class TurretBlueprint
{
    public GameObject prefab;
    public int cost; //storing cost of turret
}

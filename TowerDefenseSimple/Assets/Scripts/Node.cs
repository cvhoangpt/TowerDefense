﻿using System;
using System.Collections.Specialized;
using UnityEngine;
using UnityEngine.EventSystems;
public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Vector3 positionOffset;
    public Color notEnoughMoneyColor;

    [Header("Optional")]
    public GameObject turret;

    private Renderer rend;
    private Color startColor;

    BuildManager buildManager;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildManager = BuildManager.instance;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }
    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        //Check CanBuild or not with events
        if (!buildManager.CanBuild)
        {
            return;
        }
        if (turret != null)
        {
            Debug.Log("Can't build");
            return;
        }
        buildManager.BuildTurretOn(this);

    }
    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        //Check CanBuild or not with events
        if (!buildManager.CanBuild)
        {
            return;
        }
        //Check has money or not with this event
        if (buildManager.HasMoney)
        {
            rend.material.color = hoverColor;
        }
        else
        {
            rend.material.color = notEnoughMoneyColor;
        }
        
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;  
    }
}

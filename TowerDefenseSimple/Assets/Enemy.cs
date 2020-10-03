﻿using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;

    private Transform target;
    private int wayPointIndex = 0;

    void Start()
    {
        target = Waypoints.points[0];
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World); 
        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWayPoint();
        }
    }

    void GetNextWayPoint()
    {
        if (wayPointIndex >= Waypoints.points.Length - 1)
        {
            Destroy(gameObject);
        }
        wayPointIndex ++;
        target = Waypoints.points[wayPointIndex];
    }

}

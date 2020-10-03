using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public static Transform[] points; //To create point mark one enemy way

    void Awake()
    {
        points = new Transform[transform.childCount];
        for (int i = 0; i < points.Length; i++)
        {
            points[i] = transform.GetChild(i);
        }
    }
}

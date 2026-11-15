using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class VivariumManager : MonoBehaviour
{
    public static VivariumManager instance;

    public List<Transform> waypoints = new List<Transform>();
    
    private void Awake()
    {
        if (!instance) instance = this;
        else Destroy(gameObject);
        
        foreach (Transform point in transform)
        {
            waypoints.Add(point);
        }
    }

    public Transform RandomWaypoint()
    {
        return waypoints[Random.Range(0, waypoints.Count)];
    }
}

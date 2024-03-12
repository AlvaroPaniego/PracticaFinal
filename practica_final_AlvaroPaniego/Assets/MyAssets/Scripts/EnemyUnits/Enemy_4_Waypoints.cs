using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_4_Waypoints : MonoBehaviour
{

    public Transform[] waypoints; // paradas pertenecientes a una patrulla enemiga

    public Color color;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public Vector3 GetCurrentWaypoint (int _waypoint){

        return waypoints[_waypoint].position;
    }

    public Transform GetNextWaypointTransform (int _currentWaypointInt){

        return waypoints[_currentWaypointInt]; 
    }

    public int GetWaypointsLength (){

        return waypoints.Length;
    }
    
    void OnDrawGizmosSelected (){

        if (waypoints.Length < 2) return;

        Gizmos.color = color;
        Vector3 _extraHeight = Vector3.up * 0.5f;

        for (int i = 0; i < waypoints.Length; i++){

            if (i < waypoints.Length - 1) Gizmos.DrawLine (waypoints[i].position + _extraHeight, waypoints[i+1].position + _extraHeight);
            else Gizmos.DrawLine (waypoints[i].position + _extraHeight, waypoints[0].position + _extraHeight);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GoToPoint : MonoBehaviour
{
    NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            CamRaycast();
        }
    }
    void CamRaycast(){
        Ray _ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit _hit;
        bool _result = Physics.Raycast(_ray, out _hit, 1000);
        if(_result){
            Debug.DrawRay(_ray.origin,_ray.direction * _hit.distance, Color.yellow);
            Debug.Log("Moving to position");
            agent.SetDestination(_hit.point);
        }else Debug.Log("Didn´t hit anything");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Soldier_IA : MonoBehaviour
{
    NavMeshAgent agent;
    public bool seleccionado;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        seleccionado = false;
    }

    public void SetNewDestination (Vector3 _newDestination){

        agent.SetDestination (_newDestination);
    }
}

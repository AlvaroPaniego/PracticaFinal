using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WorkerController : MonoBehaviour
{
    public float health;
    public float timer;
    public float timerLimit;
    public int capacidad;
    public int materialQuantity;
    public Transform shipyard;
    NavMeshAgent agent;    
    // Start is called before the first frame update
    void Start()
    {
        timerLimit = 1;
        capacidad = 25;
        materialQuantity = 0;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider collider){
        if(collider.CompareTag("Asteroid")){
            AsteroidInfo _script = collider.GetComponent<AsteroidInfo>();
            if(_script.workersInAsteroid < _script.GetWorkers()){
                _script.AddWorkers();
                if(timer < timerLimit) timer += Time.deltaTime;
                else{
                    agent.SetDestination(collider.transform.position);
                    Work(_script);
                }
                if(materialQuantity >= capacidad) agent.SetDestination(shipyard.position);
            }
            
        }
    }
    public void Work(AsteroidInfo _script){
        for(int i = 0; i < capacidad; i++){
            _script.ExtractMaterial();
            materialQuantity++;
        }
    }
}

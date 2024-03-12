using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public EnemyStates state;
    NavMeshAgent agent;
    public float health;
    public float stateTimer;
    public float quietoLimit;
    public Enemy_4_Waypoints ScriptWaypoints;
    public Transform currentWaypointTransform;
    public int currentWaypointIndex;
    // Start is called before the first frame update
    void Start()
    {
        health = 100;
        agent = GetComponent<NavMeshAgent>();
        quietoLimit = 1;
        currentWaypointIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
    if (state == EnemyStates.Quieto){

            if (stateTimer < quietoLimit) stateTimer += Time.deltaTime;
            else SetState (EnemyStates.Patrullando);
        }

        if (state == EnemyStates.Patrullando){

            Vector3 _enemyPos = transform.position;
            Vector3 _targetPos = currentWaypointTransform.position;

            _enemyPos.y = 0f;
            _targetPos.y = 0f;

            if (Vector3.Distance (_enemyPos, _targetPos) <= 0.25f) SetState (EnemyStates.Quieto);
        }

    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Missile")){
            TakeDamage(20);
            Destroy(collision.gameObject);
        }
    }
    void SetState(EnemyStates _state){
        state = _state;
        Debug.Log("--- New enemy state: " + state + " ---");
        switch(state){
            //----------------------------------------
            case EnemyStates.Quieto:
            QuietoCase();
            break;
            //----------------------------------------
            //----------------------------------------
            case EnemyStates.Patrullando:
            PatrullandoCase();
            break;
            //----------------------------------------
            //----------------------------------------
            case EnemyStates.Persiguiendo:
            break;
            //----------------------------------------
            //----------------------------------------

            //----------------------------------------
        }
    }
    void QuietoCase(){
        agent.isStopped = true;
        stateTimer = 0;
    }
    void PatrullandoCase(){
        agent.isStopped = false;
        currentWaypointTransform = ScriptWaypoints.GetNextWaypointTransform(currentWaypointIndex);
        agent.SetDestination (currentWaypointTransform.position);

        if (currentWaypointIndex + 1 < ScriptWaypoints.GetWaypointsLength()) currentWaypointIndex++;
        else currentWaypointIndex = 0;
    }
    void PersiguiendoCase(){

    }
    void DisparandoCase(){

    }
    void TakeDamage(float _damage){
        health -= _damage;
        if(health <= 0) Destroy(gameObject);
    }
}
public enum EnemyStates
{
    Quieto = 0,
    Patrullando = 1,
    Persiguiendo = 2

}

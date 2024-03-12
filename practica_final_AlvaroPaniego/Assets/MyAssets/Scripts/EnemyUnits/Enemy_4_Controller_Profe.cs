using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_4_Controller_Profe : MonoBehaviour
{
    #region --- SECCION 1: DECLARACION DE VARIABLES ---

    public enemyStates_4 state;

    Animator anim;
    Rigidbody rb;
    NavMeshAgent agent;

    public float stateTimer;
    public float quietoLimit;
    public float muriendoLimit;

    Transform p1;
    Transform p2;

    public Enemy_4_Waypoints ScriptWaypoints;

    public Transform currentWaypointTransform;
    public int currentWaypointIndex;

    public enum enemyStates_4 { 
        
        Quieto = 0,
        Patrullando = 1,
        Muriendo = 2
    }
    #endregion

    #region --- SECCION 2: FUNCIONES PREDET UNITY ---
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();

        currentWaypointIndex = 0;

        SetState (enemyStates_4.Quieto);
    }

    // Update is called once per frame
    void Update()
    {
        if (state == enemyStates_4.Quieto){

            if (stateTimer < quietoLimit) stateTimer += Time.deltaTime;
            else SetState (enemyStates_4.Patrullando);
        }

        if (state == enemyStates_4.Patrullando){

            Vector3 _enemyPos = transform.position;
            Vector3 _targetPos = currentWaypointTransform.position;

            _enemyPos.y = 0f;
            _targetPos.y = 0f;

            if (Vector3.Distance (_enemyPos, _targetPos) <= 0.1f) SetState (enemyStates_4.Quieto);
        }

        if (state == enemyStates_4.Muriendo){

            if (stateTimer < muriendoLimit) stateTimer += Time.deltaTime;
            else Destroy (gameObject);
        }
    }

    void OnCollisionEnter (Collision collision){

        if (collision.gameObject.CompareTag ("PlayerProjectile")){

            if (state != enemyStates_4.Muriendo) SetState (enemyStates_4.Muriendo);
            Debug.Log ("Estrella player choca contra enemigo");
        }
    }

    public void YaEstaMuerto (){

        Debug.Log ("Ya esta muerto");
        Destroy (gameObject);
    }
    #endregion

    #region --- SECCION 3: METODOS ORIGINALES DECLARADOS ---    
    void SetState (enemyStates_4 _newState){

        state = _newState;

        Debug.Log ("Nuevo estado asignado: " + state);

        switch (state){

            // ------------------------------
            case enemyStates_4.Quieto:
            QuietoCase ();
            break;
            // ------------------------------
            case enemyStates_4.Patrullando:
            PatrullandoCase ();
            break;
            // ------------------------------
            case enemyStates_4.Muriendo:
            MuriendoCase ();
            break;
            // ------------------------------
        }
    }

    void QuietoCase (){

        SetAnimator_Float ("movement", 0f);
        stateTimer = 0f;
        quietoLimit = Random.Range (1f, 2.5f);
    }
    
    void PatrullandoCase (){

        SetAnimator_Float ("movement", 1f);

        currentWaypointTransform = ScriptWaypoints.GetNextWaypointTransform(currentWaypointIndex);
        agent.SetDestination (currentWaypointTransform.position);

        if (currentWaypointIndex + 1 < ScriptWaypoints.GetWaypointsLength()) currentWaypointIndex++;
        else currentWaypointIndex = 0;
    }

    void MuriendoCase (){

        agent.isStopped = true;
        rb.isKinematic = true;

        stateTimer = 0f;
        SetAnimator_Bool ("isDeath", true);
              
    }

    void SetAnimator_Float (string _name, float _value){
        anim.SetFloat (_name, _value);        
    }

    void SetAnimator_Bool (string _name, bool _value){
        anim.SetBool (_name, _value);
    } 
    #endregion
}

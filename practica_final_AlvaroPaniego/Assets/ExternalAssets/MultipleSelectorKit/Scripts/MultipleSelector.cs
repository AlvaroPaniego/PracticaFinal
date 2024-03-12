using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleSelector : MonoBehaviour
{

    public LayerMask rayMask;

    [Range (1f, 500f)]
    public float rayLength;

    public Vector3 firstPos;
    public Vector3 currentPos;

    public bool clicking;

    public Transform selector;
    public List<GameObject> objectsDetected;

    // Update is called once per frame
    void Update()
    {
        if (clicking != Input.GetMouseButton(0)){

            clicking = Input.GetMouseButton(0);

            if (!clicking){
                
                firstPos = Vector3.zero;
                currentPos = Vector3.zero;
                selector.GetChild(0).localScale = Vector3.zero;

            }else{

                //SetSelectionEffectsAllObjects();
                objectsDetected.Clear ();
            }
        }

        if (Input.GetMouseButton (1)){

            RaycastHit _hit;
            Ray _ray = Camera.main.ScreenPointToRay (Input.mousePosition);
            bool _result = Physics.Raycast (_ray, out _hit, rayLength, rayMask);

            if (_result){

                for (int i = 0; i < objectsDetected.Count; i++){

                    Soldier_IA _script = objectsDetected[i].GetComponent<Soldier_IA>();
                    _script.SetNewDestination (_hit.point);
                }
            }
        }
    }

    void FixedUpdate (){

        if (clicking) CamRaycast();
    }

    void CamRaycast (){

        RaycastHit _hit;

        Ray _ray = Camera.main.ScreenPointToRay (Input.mousePosition);
        bool _result = Physics.Raycast (_ray, out _hit, rayLength, rayMask);

        if (_result){

            Debug.DrawRay (_ray.origin, _ray.direction * _hit.distance, Color.red);

            if (firstPos == Vector3.zero){
                firstPos = _hit.point;
                selector.position = firstPos;
                selector.GetChild(0).localScale = Vector3.zero;
            }
            else{
                currentPos = _hit.point;

                Vector3 _diff = currentPos - firstPos;
                selector.GetChild(0).localScale = new Vector3 (_diff.x, 2f, _diff.z);
            } 

        }else{
            Debug.DrawRay (_ray.origin, _ray.direction * rayLength, Color.green);
        }
    }

    void OnTriggerEnter (Collider _collider){
        
        if (_collider.CompareTag ("Selectables")){
            Soldier_IA _script = _collider.GetComponent<Soldier_IA>();
            if(!_script.seleccionado){
                objectsDetected.Add (_collider.gameObject);
                _script.seleccionado = true;
            }
            
        } 
    }

    
    void OnTriggerExit (Collider _collider){
        Soldier_IA _script = _collider.GetComponent<Soldier_IA>();
        _script.seleccionado = false;
        if (_collider.CompareTag ("Selectables") && clicking){
            
            objectsDetected.Remove (_collider.gameObject);
            
        } 
    }
}

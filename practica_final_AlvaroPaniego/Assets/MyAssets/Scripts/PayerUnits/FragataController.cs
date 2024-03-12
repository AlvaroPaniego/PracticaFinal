using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FragataController : MonoBehaviour
{
    public float timer;
    public float timerLimit;
    public Rigidbody missile;
    public Transform shootOrigin;
    // Start is called before the first frame update
    void Start()
    {
        timerLimit = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerStay(Collider collider)
    {
        if(collider.CompareTag("Enemy")){
            Debug.Log("Enemy Detected!");
            RaycastHit _hit;
            bool _result = Physics.Raycast(transform.position, collider.transform.position - transform.position, out _hit, 300);
            if(_result){
                Debug.DrawRay(transform.position, collider.transform.position - transform.position, Color.green);
                if(_hit.collider.CompareTag("Enemy")){
                    if(timer < timerLimit) timer += Time.deltaTime;
                    else{
                        
                        Rigidbody _missile = Instantiate(missile, shootOrigin.position, shootOrigin.rotation);
                        _missile.transform.LookAt(_hit.point);
                        _missile.AddForce(_missile.transform.forward * 5, ForceMode.Impulse);
                        timer = 0;
                    }
                }
            }
        }
    }
}

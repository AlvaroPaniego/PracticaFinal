using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shipyard : MonoBehaviour
{
    public GameObject fragata;
    public GameObject caza;
    public GameObject playerUnits;
    public float timerCaza;
    public float timerFragata;
    public float timerLimitFragata;
    public float timerLimitCaza;
    bool creatingCaza;
    bool creatingFragata;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1)) GamplayPanelsManager.THIS.HideUnitList();
        if(creatingCaza){
            if(timerCaza < timerLimitCaza) timerCaza += Time.deltaTime;
            else{
                GameObject _caza = Instantiate(caza, transform.position, transform.rotation);
                _caza.transform.SetParent(playerUnits.transform);
                timerCaza = 0;
                creatingCaza =false;
            }
        }
        if(creatingFragata){
            if(timerFragata < timerLimitFragata) timerFragata += Time.deltaTime;
            else{
                GameObject _fragata = Instantiate(fragata, transform.position, transform.rotation);
                _fragata.transform.SetParent(playerUnits.transform);
                timerFragata = 0;
                creatingFragata =false;
            }
        }
    }
    void OnMouseDown()
    {
        GamplayPanelsManager.THIS.ShowUnitList();
    }
    public void CreateFragata(){
        creatingFragata = true;
    }
    public void CreateCaza(){
        creatingCaza = true;
    }
}

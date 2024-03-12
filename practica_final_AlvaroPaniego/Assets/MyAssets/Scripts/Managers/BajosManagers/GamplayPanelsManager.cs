using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamplayPanelsManager : MonoBehaviour
{
    public static GamplayPanelsManager THIS;
    public GameObject unitPanel;
    // Start is called before the first frame update
    void Awake()
    {
        THIS = this;
    }
    void Start()
    {
        HideUnitList();
    }
    public void ShowUnitList(){
        unitPanel.SetActive(true);
    }
    public void HideUnitList(){
        unitPanel.SetActive(false);
    }
    public void RefreshFragataTime()
    {

    }
}

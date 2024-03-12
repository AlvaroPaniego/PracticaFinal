using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UnitDataManager : MonoBehaviour
{
    public static UnitDataManager THIS;
    public UnitData unitData;
    // Start is called before the first frame update
    void Awake()
    {
        // uso de SINGLETON:
        // patron de diseño que permite asegurar
        // la asignacion y gestion de la misma instancia
        // en la navegacion entre escenas
        if(THIS == null){
            THIS = this;
            DontDestroyOnLoad(gameObject);
        }else Destroy(gameObject);
    }
    public void SetVida(float _vida){
        unitData.health = _vida;
    }
    public void TakeDamage(float _damage){
        unitData.health -= _damage;
    }
}
[Serializable]
public class UnitData{
    public float health = 100f;
    public float speed = 10f;
}


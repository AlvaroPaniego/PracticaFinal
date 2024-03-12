using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidInfo : MonoBehaviour
{
    public int materialRemaining;
    public int maxWorkers;
    public int workersInAsteroid;
    // Start is called before the first frame update
    void Start()
    {
        materialRemaining = 300;
        maxWorkers = 3;
        workersInAsteroid = 0;
    }
    public int GetMaterial(){
        return materialRemaining;
    }
    public int GetWorkers(){
        return maxWorkers;
    }
    public void AddWorkers(){
        workersInAsteroid++;
    }
    public void ExtractMaterial(){
        materialRemaining--;
    }
}

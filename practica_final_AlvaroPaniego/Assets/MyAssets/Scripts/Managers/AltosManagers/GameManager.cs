using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameStates states;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SetStates(GameStates _state)
    {
        states = _state;
        Debug.Log("*** New game state " + states + " ***");
        switch (states)
        {
            case GameStates.InitApp:
                break;
            case GameStates.Gameplay:
                break;
            case GameStates.GameOver:
                break;
            case GameStates.Win:
                break;
        }
    }
    void InitAppCase()
    {

    }
    void GameplayCase()
    {
        SceneManager.LoadScene(1);
    }
    void GameOverCase()
    {

    }
    void WinCase()
    {

    }
}
public enum GameStates
{
    InitApp = 0,
    Gameplay = 1,
    GameOver = 2,
    Win = 3
}

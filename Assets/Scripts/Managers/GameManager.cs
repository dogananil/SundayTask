using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager INSTANCE;
    private int levelNumber;
    private bool _levelFinish;

    private void Awake()
    {
        if(INSTANCE==null)
        {
            INSTANCE = this;
        }
    }
    void Start()
    {
        GameEvents.INSTANCE.winGame += WinGame;
        GameEvents.INSTANCE.looseGame+= LooseGame;
        //Firstly we should create our ball pool for level creation
        PoolManager.INSTANCE.CreatePools();
        //Secondly we should get player prefs
        GetPlayerPrefs();
        //Thirdly we should start levelmanager and create level
        LevelManager.INSTANCE.StartLevelManager();
        
        //Finally we can start our game
        StartGame();

    }
    private void StartGame()
    {
        LevelManager.INSTANCE.CreateLevel(levelNumber);

    }
    private void GetPlayerPrefs()
    {
        levelNumber = PlayerPrefs.GetInt("LevelNumber", 0);
    }
    public void WinGame()
    {
        if(!_levelFinish)
        {
            Debug.Log("Win the GAME");
            levelNumber++;
            PlayerPrefs.SetInt("LevelNumber", levelNumber);
        }
        _levelFinish = true;
    }
    public void LooseGame()
    {
        if(!_levelFinish)
        {
            Debug.Log("Loose the GAME");
        }

        _levelFinish = true;
    }
    

   
}

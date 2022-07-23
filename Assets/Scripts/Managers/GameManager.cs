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
        GameEvents.INSTANCE.startLevel += StartGame;
        //Firstly we should create our ball pool for level creation
        PoolManager.INSTANCE.CreatePools();
        //Secondly we should get player prefs
        
        //Thirdly we should start levelmanager and create level
        LevelManager.INSTANCE.StartLevelManager();
        
        //Finally we can start our game
        StartGame();

    }
    private void StartGame()
    {
        GetPlayerPrefs();
        _levelFinish = false;
        LevelManager.INSTANCE.StartLevel(levelNumber);

    }
    private void GetPlayerPrefs()
    {
        levelNumber = PlayerPrefs.GetInt("LevelNumber", 0);
    }
    private void WinGame()
    {
      
        if (!_levelFinish)
        {
          
            levelNumber++;
            PlayerPrefs.SetInt("LevelNumber", levelNumber);
        }
        _levelFinish = true;
    }
    private void LooseGame()
    {
        if(!_levelFinish)
        {
            
        }

        _levelFinish = true;
    }
    
    

   
}

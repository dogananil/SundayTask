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


        GetPlayerPrefs();
        //Finally we can start our game
        StartGame();

    }
    private void StartGame()
    {
        
        _levelFinish = false;
        
        SetPlayerPrefs();
        LevelManager.INSTANCE.StartLevel(levelNumber);
        GameEvents.INSTANCE.SetLevelTxt();
        
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
    private void SetPlayerPrefs()
    {
        if(levelNumber>LevelConfigurations.Instance.ballNumber.Count-1)
        {
            levelNumber = Random.Range(0, LevelConfigurations.Instance.ballNumber.Count);
        }
        PlayerPrefs.SetInt("LevelNumber", levelNumber);
    }
    

   
}

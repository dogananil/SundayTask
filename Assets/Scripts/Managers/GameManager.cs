using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int levelNumber;
    void Start()
    {
        //Firstly we should create our ball pool for level creation
        PoolManager.INSTANCE.CreatePools();
        //Secondly we should get player prefs
        SetPlayerPrefs();
        //Thirdly we should start levelmanager and create level
        LevelManager.INSTANCE.StartLevelManager();
        LevelManager.INSTANCE.CreateLevel(levelNumber);
        //Finally we can start our game
        StartGame();

    }
    private void StartGame()
    {
        
       
    }
    private void SetPlayerPrefs()
    {
        levelNumber = PlayerPrefs.GetInt("LevelNumber", 0);
    }

   
}

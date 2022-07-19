using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int levelNumber;
    void Start()
    {
        //First we should create our ball pool for level creation
        PoolManager.INSTANCE.CreatePool();
        //Second we should create level

        //Finally we can start our game
        StartGame();

    }
    private void StartGame()
    {
        SetPlayerPrefs();
        LevelManager.INSTANCE.StartLevelManager();
        LevelManager.INSTANCE.CreateLevel(levelNumber);
    }
    private void SetPlayerPrefs()
    {
        levelNumber = PlayerPrefs.GetInt("LevelNumber", 0);
    }

   
}

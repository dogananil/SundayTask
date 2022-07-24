using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameEvents : MonoBehaviour
{
    public static GameEvents INSTANCE;

    private void Awake()
    {
        if(INSTANCE==null)
        {
            INSTANCE = this;
        }
    }
    public event Action winGame;
    public void WinGame()
    {
        if(winGame!=null)
        {
            winGame();
        }
    }
    public event Action looseGame;
    public void LooseGame()
    {
        if (looseGame != null)
        {
            looseGame();
        }
    }
    public event Action startLevel;
    public void StartLevel()
    {
        if(startLevel != null)
        {
            startLevel();
        }
    }
    
    public event Action ballToCup;
    public void BallToCup()
    {
        if(ballToCup!=null)
        {
            ballToCup();
        }
    }
    public event Action setLevelTxt;
    public void SetLevelTxt()
    {
        if (setLevelTxt != null)
        {
            setLevelTxt();
        }
    }
}

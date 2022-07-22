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
}

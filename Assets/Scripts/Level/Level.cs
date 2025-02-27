using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
   
    public Transform ballSpawnPoint;
    public int _ballNumberInTheCup;
    private int _looseBallNumber,_tubeExitBallNumber;
    private int _desiredBallForLevel, _levelBallNumber;
    private bool levelFinish;

    
    public void ResetLevel()
    {
        int levelNumber = PlayerPrefs.GetInt("LevelNumber", 0);
        levelFinish = false;
        _ballNumberInTheCup = 0;
        _looseBallNumber = 0;
        _tubeExitBallNumber = 0;
        _desiredBallForLevel= LevelConfigurations.Instance.ballNumber[levelNumber];
        _levelBallNumber = LevelConfigurations.Instance.ballSize[levelNumber];
        GameEvents.INSTANCE.BallToCup();
        this.transform.position = new Vector3(0, 20, 0);
        this.transform.rotation = Quaternion.Euler(0, -180, 0);
    }
    public void SetMaterial()
    {
        GetComponent<MeshRenderer>().material = LevelGeneratorConfiguration.Instance.tubeMaterial;
    }
    public void CountBallInTheCup()
    {
        
        _ballNumberInTheCup++;
        GameEvents.INSTANCE.BallToCup();
        if (_ballNumberInTheCup>=_desiredBallForLevel/*_tubeExitBallNumber == _levelBallNumber &&*/|| (_looseBallNumber+_ballNumberInTheCup)== _levelBallNumber)

        {
            FinishLevel();
           
        }
    }
    public void LooseBall()
    {
        _looseBallNumber++;
        if ((_looseBallNumber + _ballNumberInTheCup) == _levelBallNumber)
        {
            FinishLevel();
            
        }
    }
    public void CountBallTubeExit()
    {
        _tubeExitBallNumber++;
        
    }
    private void FinishLevel()
    {
        if (levelFinish) return;
        if(_ballNumberInTheCup>=_desiredBallForLevel)
        {
            GameEvents.INSTANCE.WinGame();
        }
        else
        {
            GameEvents.INSTANCE.LooseGame();
        }
        levelFinish = true; 
    }
}

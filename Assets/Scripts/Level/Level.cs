using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
   
    public Transform ballSpawnPoint;
    private int _ballNumberInTheCup, _looseBallNumber,_tubeExitBallNumber;
    private int _desiredBallForLevel, _levelBallNumber;
   
    public void ResetLevel()
    {
        int levelNumber = PlayerPrefs.GetInt("LevelNumber", 0);
        _ballNumberInTheCup = 0;
        _looseBallNumber = 0;
        _tubeExitBallNumber = 0;
        _desiredBallForLevel= LevelConfigurations.Instance.ballNumber[levelNumber];
        _levelBallNumber = LevelConfigurations.Instance.ballSize[levelNumber];
     
        this.transform.position = new Vector3(0, 20, 0);
        this.transform.rotation = Quaternion.Euler(0, -180, 0);
    }
    public void SetMaterial()
    {
        GetComponent<MeshRenderer>().material = LevelGeneratorConfiguration.instance.tubeMaterial;
    }
    public void CountBallInTheCup()
    {
       
        _ballNumberInTheCup++;
        if(_tubeExitBallNumber == _levelBallNumber && (_looseBallNumber+_ballNumberInTheCup)==_tubeExitBallNumber)
        {
            Debug.Log("Win Game with " + _ballNumberInTheCup + " number of balls");
            FinishLevel();
           
        }
    }
    public void LooseBall()
    {
        _looseBallNumber++;
        if (_tubeExitBallNumber == _levelBallNumber && (_looseBallNumber + _ballNumberInTheCup) == _tubeExitBallNumber)
        {
            Debug.Log("Loose Game with " + _looseBallNumber + " number of balls");
            FinishLevel();
            
        }
    }
    public void CountBallTubeExit()
    {
        _tubeExitBallNumber++;
        
    }
    private void FinishLevel()
    {
        if(_ballNumberInTheCup>=_desiredBallForLevel)
        {
            GameEvents.INSTANCE.WinGame();
        }
        else
        {
            GameEvents.INSTANCE.LooseGame();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public static LevelManager INSTANCE;
    [SerializeField] private List<Level> levels = new List<Level>();
    [SerializeField] private GameObject cup;
    private GameObject levelCup;
    private List<Level> levelPool = new List<Level>();
    public Level currentLevel;


    private void Awake()
    {
     if(INSTANCE==null)
        {
            INSTANCE = this;
        }
    }
    public void StartLevelManager()
    {
        CreateCup();
        CreateLevelPool();
    }
    /// <summary>
    /// Create cup at start of the game
    /// </summary>
    private void CreateCup()
    {
        levelCup = Instantiate(cup);
        levelCup.SetActive(false); 
    }
    private void CreateLevelPool()
    {
        for(int i=0;i<levels.Count;i++)
        {
            Level newLevel = Instantiate(levels[i]);
            newLevel.gameObject.SetActive(false);
            levelPool.Add(newLevel);
        }
    }
    /// <summary>
    /// Create level for game by referencing level number
    /// </summary>
    /// <param name="levelNumber"></param>
    public void CreateLevel(int levelNumber)
    {
        levelCup.SetActive(true);
        levelPool[levelNumber].ResetLevel();
        levelPool[levelNumber].gameObject.SetActive(true);
        currentLevel = levelPool[levelNumber];
    }
    
}
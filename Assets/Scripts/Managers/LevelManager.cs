using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public static LevelManager INSTANCE;
    [SerializeField] private List<Level> levels = new List<Level>();
    [SerializeField] private GameObject cup;
    private GameObject levelCup;
    public List<Level> levelPool = new List<Level>();
    public Level currentLevel;
    [SerializeField] private Transform _currentLevelParent;
    private Transform _levelPoolParent;

    private List<Ball> levelBalls = new List<Ball>();
    public bool ballSpawning;

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
        
    }
    /// <summary>
    /// Create cup at start of the game
    /// </summary>
    private void CreateCup()
    {
        levelCup = Instantiate(cup);
        levelCup.SetActive(false); 
    }
    public void CreateLevelPool(Transform poolParentTransform)
    {
        _levelPoolParent = poolParentTransform;
        for(int i=0;i<levels.Count;i++)
        {
            Level newLevel = Instantiate(levels[i], poolParentTransform);
            newLevel.gameObject.SetActive(false);
            levelPool.Add(newLevel);
        }
    }
    /// <summary>
    /// Create level for game by referencing level number
    /// </summary>
    /// <param name="levelNumber"></param>
    public void StartLevel(int levelNumber)
    {

        levelCup.SetActive(true);
        if (currentLevel)
        {
            currentLevel.transform.SetParent(_levelPoolParent);
            currentLevel.gameObject.SetActive(false);
        }
            
        currentLevel = levelPool[levelNumber];
        currentLevel.gameObject.SetActive(true);
        currentLevel.transform.SetParent(_currentLevelParent);
        levelPool[levelNumber].ResetLevel();
        levelPool[levelNumber].gameObject.SetActive(true);
        ResetLevelBalls();
        StartCoroutine(SpawnLevelBalls(LevelConfigurations.Instance.ballSize[levelNumber], LevelConfigurations.Instance.spawnWaitTime));
    }
    private IEnumerator SpawnLevelBalls(int ballNumber,float spawnWaitTime)
    {
        int i = 0;
        ballSpawning = true;
        ParticleManager.INSTANCE._sparkle.transform.position = currentLevel.ballSpawnPoint.position;
        ParticleManager.INSTANCE._sparkle.Play();
        while (i<ballNumber)
        {
            PoolManager.INSTANCE.ballPool.ballPool[i].ResetBall();
            PoolManager.INSTANCE.ballPool.ballPool[i].RandomSpawn(currentLevel.ballSpawnPoint,currentLevel.transform);
            levelBalls.Add(PoolManager.INSTANCE.ballPool.ballPool[i]);
            i++;
            yield return new WaitForSeconds(spawnWaitTime);
        }
        ParticleManager.INSTANCE._sparkle.Stop();
        ballSpawning = false;
    }
    private void ResetLevelBalls()
    {
        int count = levelBalls.Count;
        for(int i=0;i<count;i++)
        {
            levelBalls[0].gameObject.SetActive(false);
            levelBalls.RemoveAt(0);
        }
    }
    
}

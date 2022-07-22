using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public static PoolManager INSTANCE;
    public BallPool ballPool;
    [SerializeField] private LevelGenerator levelGenerator;
    private void Awake()
    {
        if (INSTANCE == null)
        {
            INSTANCE = this;
        }
    }
    /// <summary>
    /// Create ball and level pool for game
    /// </summary>
    public void CreatePools()
    {
        ballPool.CreatePool();
        LevelManager.INSTANCE.CreateLevelPool(levelGenerator.transform);
        levelGenerator.CreateLevels();
    }
}

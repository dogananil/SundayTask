using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public static PoolManager INSTANCE;
    [SerializeField] private BallPool ballPool;
    [SerializeField] private LevelGenerator levelGenerator;
    private void Awake()
    {
        if (INSTANCE == null)
        {
            INSTANCE = this;
        }
    }
    public void CreatePools()
    {
        ballPool.CreatePool();
        LevelManager.INSTANCE.CreateLevelPool(levelGenerator.transform);
        levelGenerator.CreateLevels();
    }
}

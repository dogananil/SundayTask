using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public static PoolManager INSTANCE;
    [SerializeField] private Ball ballPrefab;
    [SerializeField] private int poolSize;
    public List<Ball> ballPool = new List<Ball>();

    private void Awake()
    {
        if(INSTANCE==null)
        {
            INSTANCE = this;
        }
    }
    private void Start()
    {
        CreatePool();
    }
    private void CreatePool()
    {
        for(int i=0;i<poolSize;i++)
        {
            Ball newBall = Instantiate(ballPrefab, this.transform);
            newBall.gameObject.SetActive(false);
            ballPool.Add(newBall);
        }
    }
}

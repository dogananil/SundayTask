using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public static PoolManager INSTANCE;
    [SerializeField] private Ball ballPrefab;
    [SerializeField] private int poolSize;
    public List<Ball> ballPool = new List<Ball>();
    [SerializeField] private List<Color> colors = new List<Color>();

    private void Awake()
    {
        if(INSTANCE==null)
        {
            INSTANCE = this;
        }
    }
    /// <summary>
    /// Create ball pool for gameplay
    /// </summary>
    public void CreatePool()
    {
        for(int i=0;i<poolSize;i++)
        {
            Ball newBall = Instantiate(ballPrefab, this.transform);
            newBall.gameObject.SetActive(false);
            MaterialPropertyBlock materialProperty = new MaterialPropertyBlock();
            int randomIndex = Random.Range(0, colors.Count);
            materialProperty.SetColor("_Color",colors[randomIndex]);
            newBall.GetComponent<MeshRenderer>().SetPropertyBlock(materialProperty);
            ballPool.Add(newBall);
        }
    }
}

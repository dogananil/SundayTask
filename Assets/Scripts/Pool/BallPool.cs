using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPool : MonoBehaviour
{
  
    
   
    public List<Ball> ballPool = new List<Ball>();
    

   
    /// <summary>
    /// Create ball pool for gameplay
    /// </summary>
    public void CreatePool()
    {
        for (int i = 0; i < BallPoolConfigurations.Instance.poolSize; i++)
        {
            Ball newBall = Instantiate(BallPoolConfigurations.Instance.ballPrefab, this.transform);
            newBall.gameObject.SetActive(false);
            MaterialPropertyBlock materialProperty = new MaterialPropertyBlock();
            int randomIndex = Random.Range(0, BallPoolConfigurations.Instance.colors.Count);
            materialProperty.SetColor("_Color", BallPoolConfigurations.Instance.colors[randomIndex]);
            newBall.GetComponent<MeshRenderer>().SetPropertyBlock(materialProperty);
            ballPool.Add(newBall);
        }
    }
}

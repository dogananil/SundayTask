using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class LevelGenerator : MonoBehaviour
{
    
    
    /// <summary>
    /// Create Levels from svg files and add to pool
    /// </summary>
    public void CreateLevels()
    {
       
        for (int i=0;i<LevelGeneratorConfiguration.instance.levels.Count;i++)
        {
            Level newLevel = Instantiate(LevelGeneratorConfiguration.instance.levels[i], this.transform);
            newLevel.gameObject.SetActive(false);
            LevelManager.INSTANCE.levelPool.Add(newLevel);
        }
    }
   
   
}

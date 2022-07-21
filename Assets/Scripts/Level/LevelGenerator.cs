using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class LevelGenerator : MonoBehaviour
{
    
    

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

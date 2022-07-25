using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Level Configurations", menuName = "Scriptable Objects/Level Configurations")]
public class LevelConfigurations : SingletonScriptableObjects<LevelConfigurations>
{
    [Header("Level Ball Number")]
    public List<int> ballSize = new List<int>();
    [Header("Desired Ball Number")]
    public List<int> ballNumber = new List<int>();
    [Header("Start Ball Spawn Time")]
    public float spawnWaitTime;
}

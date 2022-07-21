using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Ball Pool Configurations", menuName = "Scriptable Objects/Ball Pool Configurations")]
public class BallPoolConfigurations : SingletonScriptableObjects<BallPoolConfigurations>
{
    [Header("Ball Pool Size")]
    public int poolSize;
    [Header("Ball Colors")]
    public List<Color> colors = new List<Color>();
    [Header("Ball Prefab")]
    public Ball ballPrefab;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CreateAssetMenu(fileName ="Level Generator Configurations",menuName ="Scriptable Objects/Level Generator Configurations")]
public class LevelGeneratorConfiguration : ScriptableSingleton<LevelGeneratorConfiguration>
{
    
    [Header("Level SVG Sprites")]
    public List<Level> levels = new List<Level>();
    [Header("Tube Prefab")]
    public Level tube;
    [Header("Tube Material")]
    public Material tubeMaterial;
    
}

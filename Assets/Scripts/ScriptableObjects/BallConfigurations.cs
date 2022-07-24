using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Ball Configurations", menuName = "Scriptable Objects/Ball Configurations")]
public class BallConfigurations : SingletonScriptableObjects<BallConfigurations>
{
    [Header("Mass of Ball")]
    [Range(0,5)]
    public float mass;
    [Header("Drag of Ball")]
    [Range(0, 1)]
    public float drag;
    [Header("Angular Drag of Ball")]
    [Range(0, 0.1f)]
    public float angularDrag;
    [Header("Dynamic Friction of Ball")]
    [Range(0, 0.5f)]
    public float dynamicFriction;
    [Header("Static Friction of Ball")]
    [Range(0, 0.5f)]
    public float staticFriction;
    [Header("Bounciness of Ball")]
    [Range(0, 0.4f)]
    public float bounciness;
}

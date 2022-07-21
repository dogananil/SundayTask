using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player Controller Configurations", menuName = "Scriptable Objects/Player Controller Configurations")]
public class PlayerControllerConfigurations : SingletonScriptableObjects<PlayerControllerConfigurations>
{
    [Header("Rotation Speed of Tubes")]
    public float rotationSpeed;
}

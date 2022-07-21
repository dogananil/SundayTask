using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public MeshFilter meshFilter;
    public void ResetLevel()
    {
        this.transform.position = new Vector3(0, 20, 0);
        this.transform.rotation = Quaternion.Euler(0, -180, 0);
    }
    public void SetMaterial()
    {
        GetComponent<MeshRenderer>().material = LevelGeneratorConfiguration.instance.tubeMaterial;
    }
}

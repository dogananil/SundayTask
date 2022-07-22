using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public void RandomSpawn(Transform spawnPoint,Transform parent)
    {
        this.transform.SetParent(parent);
        this.gameObject.SetActive(true);
        Vector3 random = (Vector3)Random.insideUnitCircle;

        transform.position = random + spawnPoint.position;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.tag=="TubeExit")
        {
            this.transform.SetParent(PoolManager.INSTANCE.ballPool.transform);
        }
    }
    
   

}

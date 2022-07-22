using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private bool countedForEntry,countedForLoose;
    
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
            LevelManager.INSTANCE.currentLevel.CountBallTubeExit();
        }
        else if(collision.tag=="CupEntry" && !countedForEntry)
        {
            countedForEntry = true;
            LevelManager.INSTANCE.currentLevel.CountBallInTheCup();
        }
        else if(collision.tag=="LooseBall" && !countedForLoose)
        {
            countedForLoose = true;
            LevelManager.INSTANCE.currentLevel.LooseBall();
        }
        
    }
    public void ResetBall()
    {
        countedForEntry = false;
        countedForLoose = false;
    }



}

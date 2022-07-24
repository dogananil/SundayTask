using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private bool countedForEntry,countedForLoose;
    private Rigidbody _physicsOfBall;
    private SphereCollider _collider;


    private void Awake()
    {
        _physicsOfBall = GetComponent<Rigidbody>();
        _collider = GetComponent<SphereCollider>();
    }
    public void RandomSpawn(Transform spawnPoint,Transform parent)
    {
        this.transform.SetParent(parent);
        this.gameObject.SetActive(true);
        Vector3 random = (Vector3)Random.insideUnitCircle*0.5f;

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
        _physicsOfBall.mass = BallConfigurations.Instance.mass;
        _physicsOfBall.drag = BallConfigurations.Instance.drag;
        _physicsOfBall.angularDrag= BallConfigurations.Instance.angularDrag;
        _collider.material.dynamicFriction= BallConfigurations.Instance.dynamicFriction;
        _collider.material.staticFriction= BallConfigurations.Instance.staticFriction;
        _collider.material.bounciness= BallConfigurations.Instance.bounciness;
        _physicsOfBall.velocity = Vector3.zero;
    }



}

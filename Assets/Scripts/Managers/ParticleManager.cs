using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    [Header("Win Game Particles")]
    public ParticleSystem _confetti;
    public ParticleSystem _snow;
    [Header("Ball Spawn Particle")]
    public ParticleSystem _sparkle;

    public static ParticleManager INSTANCE;

    private void Start()
    {
        if(INSTANCE==null)
        {
            INSTANCE = this;
        }
    }
}

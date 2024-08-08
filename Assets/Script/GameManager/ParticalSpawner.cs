using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticalSpawner : Spawn
{
    // Start is called before the first frame update
    public string HIT_PARTICLE = "HitParticle";
    public string DEATH_PARTICLE = "DeathParticle";

    private ParticalSpawner instance;
    static public ParticalSpawner Instance;
    private void Awake()
    {

        if (instance != null) return;
        Instance = this;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : Spawn
{
    // Start is called before the first frame update
    public string ARROW = "Arrow";
    public string SLASH = "Slash";
    public string SLASH_EFFECT = "SlashEffect";

    

    private ProjectileSpawner instance;
    static public ProjectileSpawner Instance;
    private void Awake()
    {
        if (instance != null) return;
        Instance = this;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    [Header("Projectile Spawn Points")]
    public Transform seedSpawn;
    public Transform sapSpawn;
    public Transform pineconeSpawn;

    [Header("Tower/Wall Prices")]
    public float seedPrice;
    public float sapPrice;
    public float pineconePrice;
    public float wallPrice;

    [Header("Temporary Stuff")]
    public float currentPoints;
    public Transform[] wallSpawnPoints;
    public GameObject wall;
    public GameObject seedTurret;
    public GameObject sapTurret;
    public GameObject pineconeTurret;

    private void Start()
    {
        
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1) && currentPoints > wallPrice)
        {
            BuildWall(currentPoints, wallSpawnPoints[0]);
        }

        if(Input.GetKeyDown(KeyCode.Alpha2) && currentPoints > wallPrice)
        {
            BuildWall(currentPoints, wallSpawnPoints[1]);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) && currentPoints > wallPrice)
        {
            BuildWall(currentPoints, wallSpawnPoints[2]);
        }
    }
    public float BuildWall(float points, Transform spawnLocation)
    {
        Instantiate(wall, spawnLocation);
        points -= wallPrice;
        return points;
    }
}

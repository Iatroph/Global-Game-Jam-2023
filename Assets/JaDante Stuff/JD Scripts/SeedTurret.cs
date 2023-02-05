using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedTurret : Turret
{
    public Vector3 center;
    public Transform projectileSpawn1, projectileSpawn2, projectileSpawn3;
    public float attackRange;
    public LayerMask enemyLayer;
    public GameObject seed;

    private GameObject projectile;

    // change mesh for upgrade
    private void Start()
    {
        base.Start();
    }
    private void Update()
    {
        base.Update();
        //Debug.Log(turretLevel);
        //turretText.text = turretLevel.ToString();

        Collider[] inRange = Physics.OverlapSphere(center, attackRange, enemyLayer.value);

        if (inRange.Length > 0)
        {
            //Collider closest = FindClosest(inRange);
            //Debug.Log(closest.name);
            //Attack(closest.gameObject);
            Collider lowest = FindClosest(inRange);
            Attack(lowest.gameObject);
        }
    }
    private Collider FindClosest(Collider[] inRange)
    {
        Collider closest = inRange[0];
        float lowest = Vector3.Distance(closest.gameObject.transform.position, gameObject.transform.position);

        foreach(Collider collider in inRange)
        {

            float temp = Vector3.Distance(collider.gameObject.transform.position, gameObject.transform.position);
            if(temp < lowest)
            {
                temp = lowest;
                closest = collider;
            }
        }

        return closest;
    }
    public void Attack(GameObject closest)
    {
        transform.LookAt(closest.transform.position);

        if(projectile == null && turretLevel == 1)
        {
            //projectile = Instantiate(seed, projectileSpawn1);
            projectile = Instantiate(seed, projectileSpawn1.position, Quaternion.identity);
            projectile.GetComponent<SeedScript>().target = closest.transform;
            projectile.GetComponent<SeedScript>().speed = speedLevel1 * base.multiplier;
            projectile.GetComponent<SeedScript>().damage = damageLevel1 * base.multiplier;

            //projectile = Instantiate(seed, projectileSpawn2);
            projectile = Instantiate(seed, projectileSpawn2.position, Quaternion.identity);
            projectile.GetComponent<SeedScript>().target = closest.transform;
            projectile.GetComponent<SeedScript>().speed = speedLevel1 * base.multiplier;
            projectile.GetComponent<SeedScript>().damage = damageLevel1 * base.multiplier;
        }
        else if(projectile == null && turretLevel == 2)
        {
            projectile = Instantiate(seed, projectileSpawn1);
            projectile.GetComponent<SeedScript>().target = closest.transform; 
            projectile.GetComponent<SeedScript>().speed = speedLevel2 * base.multiplier;
            projectile.GetComponent<SeedScript>().damage = damageLevel2 * base.multiplier;

            projectile = Instantiate(seed, projectileSpawn2);
            projectile.GetComponent<SeedScript>().target = closest.transform;
            projectile.GetComponent<SeedScript>().speed = speedLevel2 * base.multiplier;
            projectile.GetComponent<SeedScript>().damage = damageLevel2 * base.multiplier;
        }
        else if (projectile == null && turretLevel == 3)
        {
            projectile = Instantiate(seed, projectileSpawn1);
            projectile.GetComponent<SeedScript>().target = closest.transform;
            projectile.GetComponent<SeedScript>().speed = speedLevel3 * base.multiplier;
            projectile.GetComponent<SeedScript>().damage = damageLevel3 * base.multiplier;

            projectile = Instantiate(seed, projectileSpawn2);
            projectile.GetComponent<SeedScript>().target = closest.transform;
            projectile.GetComponent<SeedScript>().speed = speedLevel3 * base.multiplier;
            projectile.GetComponent<SeedScript>().damage = damageLevel3 * base.multiplier;

            projectile = Instantiate(seed, projectileSpawn3);
            projectile.GetComponent<SeedScript>().target = closest.transform;
            projectile.GetComponent<SeedScript>().speed = speedLevel3 * base.multiplier;
            projectile.GetComponent<SeedScript>().damage = damageLevel3 * base.multiplier;
        }
    }
}

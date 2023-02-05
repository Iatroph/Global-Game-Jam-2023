using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SapTurret : Turret
{
    public float duration1, duration2, duration3;
    public float slowPercentage1, slowPercentage2, slowPercentage3;
    public Vector3 center;
    public Transform projectileSpawn1, projectileSpawn2, projectileSpawn3;
    public float attackRange;
    public LayerMask enemyLayer;
    public GameObject sap;

    private GameObject projectile;

    // change mesh for upgrade
    protected override void Start()
    {
        base.Start();
    }
    protected override void Update()
    {
        base.Update();
        //turretText.text = turretLevel.ToString();

        Collider[] inRange = Physics.OverlapSphere(transform.position, attackRange, enemyLayer.value);

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

        foreach (Collider collider in inRange)
        {

            float temp = Vector3.Distance(collider.gameObject.transform.position, gameObject.transform.position);
            if (temp < lowest)
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
        bool fired = false;

        if (projectile == null && turretLevel == 1)
        {
            projectile = Instantiate(sap, projectileSpawn1.position, Quaternion.identity);
            projectile.GetComponent<SapScript>().target = closest.transform;
            projectile.GetComponent<SapScript>().speed = speedLevel1 * base.multiplier;
            projectile.GetComponent<SapScript>().damage = damageLevel1 * base.multiplier;
            projectile.GetComponent<SapScript>().duration = duration1;
            projectile.GetComponent<SapScript>().slowPercentage = slowPercentage1;

            projectile = Instantiate(sap, projectileSpawn2.position, Quaternion.identity);
            projectile.GetComponent<SapScript>().target = closest.transform;
            projectile.GetComponent<SapScript>().speed = speedLevel1 * base.multiplier;
            projectile.GetComponent<SapScript>().damage = damageLevel1 * base.multiplier;
            projectile.GetComponent<SapScript>().duration = duration1;
            projectile.GetComponent<SapScript>().slowPercentage = slowPercentage1;

            fired = true;
        }
        else if (projectile == null && turretLevel == 2)
        {
            projectile = Instantiate(sap, projectileSpawn1.position, Quaternion.identity);
            projectile.GetComponent<SapScript>().target = closest.transform;
            projectile.GetComponent<SapScript>().speed = speedLevel2 * base.multiplier;
            projectile.GetComponent<SapScript>().damage = damageLevel2 * base.multiplier;
            projectile.GetComponent<SapScript>().duration = duration2;
            projectile.GetComponent<SapScript>().slowPercentage = slowPercentage2;

            projectile = Instantiate(sap, projectileSpawn2.position, Quaternion.identity);
            projectile.GetComponent<SapScript>().target = closest.transform;
            projectile.GetComponent<SapScript>().speed = speedLevel2 * base.multiplier;
            projectile.GetComponent<SapScript>().damage = damageLevel2 * base.multiplier;
            projectile.GetComponent<SapScript>().duration = duration2;
            projectile.GetComponent<SapScript>().slowPercentage = slowPercentage2;

            fired = true;
        }
        else if (projectile == null && turretLevel == 3)
        {
            projectile = Instantiate(sap, projectileSpawn1.position, Quaternion.identity);
            projectile.GetComponent<SapScript>().target = closest.transform;
            projectile.GetComponent<SapScript>().speed = speedLevel3 * base.multiplier;
            projectile.GetComponent<SapScript>().damage = damageLevel3 * base.multiplier;
            projectile.GetComponent<SapScript>().duration = duration3;
            projectile.GetComponent<SapScript>().slowPercentage = slowPercentage3;

            projectile = Instantiate(sap, projectileSpawn2.position, Quaternion.identity);
            projectile.GetComponent<SapScript>().target = closest.transform;
            projectile.GetComponent<SapScript>().speed = speedLevel3 * base.multiplier;
            projectile.GetComponent<SapScript>().damage = damageLevel3 * base.multiplier;
            projectile.GetComponent<SapScript>().duration = duration3;
            projectile.GetComponent<SapScript>().slowPercentage = slowPercentage3;

            fired = true;
        }

        if (fired)
        {
            base.aSource.clip = base.shootClips[Random.Range(0, shootClips.Length - 1)];
            base.aSource.Play();
        }
    }
}

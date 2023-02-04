using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SapTurret : Turret
{
    public Vector3 center;
    public Transform projectileSpawn;
    public float attackRange;
    public LayerMask enemyLayer;
    public GameObject sap;

    private GameObject projectile;

    // change mesh for upgrade
    private void Start()
    {
        turretLevel = 1;
    }
    private void Update()
    {
        turretText.text = turretLevel.ToString();
        Collider[] inRange = Physics.OverlapSphere(center, attackRange, enemyLayer.value);

        if (inRange.Length > 0)
        {
            Collider closest = FindClosest(inRange);
            Debug.Log(closest.name);
            Attack(closest.gameObject);
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

        if (projectile == null && turretLevel == 1)
        {
            projectile = Instantiate(sap, projectileSpawn);
            projectile.GetComponent<SapScript>().speed = speedLevel1;
            projectile.GetComponent<SapScript>().damage = damageLevel1;
        }
        else if (projectile == null && turretLevel == 2)
        {
            projectile = Instantiate(sap, projectileSpawn);
            projectile.GetComponent<SapScript>().speed = speedLevel2;
            projectile.GetComponent<SapScript>().damage = damageLevel2;
        }
    }
}

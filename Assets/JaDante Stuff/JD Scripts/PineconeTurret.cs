using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PineconeTurret : Turret
{
    public float aoeRadius1, aoeRadius2, aoeRadius3;
    public Vector3 center;
    public Transform projectileSpawn1, projectileSpawn2, projectileSpawn3;
    public float attackRange;
    public LayerMask enemyLayer;
    public GameObject pinecone;

    private GameObject projectile;

    // change mesh for upgrade
    private void Start()
    {
        base.Start();
    }
    private void Update()
    {
        base.Update();
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
            projectile = Instantiate(pinecone, projectileSpawn1.position, Quaternion.identity);
            projectile.GetComponent<PineconeScript>().target = closest.transform;
            projectile.GetComponent<PineconeScript>().speed = speedLevel1 * base.multiplier;
            projectile.GetComponent<PineconeScript>().damage = damageLevel1 * base.multiplier;
            projectile.GetComponent<PineconeScript>().damageRange = aoeRadius1;

            projectile = Instantiate(pinecone, projectileSpawn2.position, Quaternion.identity);
            projectile.GetComponent<PineconeScript>().target = closest.transform;
            projectile.GetComponent<PineconeScript>().speed = speedLevel1 * base.multiplier;
            projectile.GetComponent<PineconeScript>().damage = damageLevel1 * base.multiplier;
            projectile.GetComponent<PineconeScript>().damageRange = aoeRadius1;
        }
        else if (projectile == null && turretLevel == 2)
        {
            projectile = Instantiate(pinecone, projectileSpawn1.position, Quaternion.identity);
            projectile.GetComponent<PineconeScript>().target = closest.transform;
            projectile.GetComponent<PineconeScript>().speed = speedLevel2;
            projectile.GetComponent<PineconeScript>().damage = damageLevel2 * base.multiplier;
            projectile.GetComponent<PineconeScript>().damageRange = aoeRadius2;

            projectile = Instantiate(pinecone, projectileSpawn2.position, Quaternion.identity);
            projectile.GetComponent<PineconeScript>().target = closest.transform;
            projectile.GetComponent<PineconeScript>().speed = speedLevel2;
            projectile.GetComponent<PineconeScript>().damage = damageLevel2;
            projectile.GetComponent<PineconeScript>().damageRange = aoeRadius2;
        }
        else if (projectile == null && turretLevel == 3)
        {
            projectile = Instantiate(pinecone, projectileSpawn1.position, Quaternion.identity);
            projectile.GetComponent<PineconeScript>().target = closest.transform;
            projectile.GetComponent<PineconeScript>().speed = speedLevel3;
            projectile.GetComponent<PineconeScript>().damage = damageLevel3;
            projectile.GetComponent<PineconeScript>().damageRange = aoeRadius3;

            projectile = Instantiate(pinecone, projectileSpawn2.position, Quaternion.identity);
            projectile.GetComponent<PineconeScript>().target = closest.transform;
            projectile.GetComponent<PineconeScript>().speed = speedLevel3;
            projectile.GetComponent<PineconeScript>().damage = damageLevel3;
            projectile.GetComponent<PineconeScript>().damageRange = aoeRadius3;

            projectile = Instantiate(pinecone, projectileSpawn3.position, Quaternion.identity);
            projectile.GetComponent<PineconeScript>().target = closest.transform;
            projectile.GetComponent<PineconeScript>().speed = speedLevel3;
            projectile.GetComponent<PineconeScript>().damage = damageLevel3;
            projectile.GetComponent<PineconeScript>().damageRange = aoeRadius3;
        }
    }
}

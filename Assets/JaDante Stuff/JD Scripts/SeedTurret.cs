using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedTurret : MonoBehaviour
{
    public Vector3 center;
    public float attackRange;
    // change mesh for upgrade
    private void Start()
    {

    }
    private void Update()
    {
        Collider[] inRange = Physics.OverlapSphere(center, attackRange);

        if (inRange.Length > 0)
        {
            Collider closest = FindClosest(inRange);
            Attack(closest.gameObject);
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

        // instantiate projectile
    }
}

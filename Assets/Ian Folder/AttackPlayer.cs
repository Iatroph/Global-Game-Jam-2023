using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayer : MonoBehaviour
{
    public float damage = 5f;
    public bool isProjectile = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<Enemy>().ChangeHealth(damage * -1f);
        }
        else if(isProjectile)
        {
            Destroy(gameObject);
        }
    }
}

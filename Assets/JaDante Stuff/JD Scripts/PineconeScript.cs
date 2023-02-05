using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PineconeScript : MonoBehaviour
{
    public float damageRange;
    public LayerMask enemyLayer;
    public float damage, speed;
    //public float aoeRadius;
    public Transform target;

    private void Start()
    {
    }
    private void Update()
    {
        //transform.Translate(Vector3.forward * speed * Time.deltaTime);

        if (target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * 1.5f * Time.deltaTime);
        }

        if (target == null)
        {
            Destroy(gameObject);
        }
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Collider[] enemies = Physics.OverlapSphere(transform.position, damageRange, enemyLayer);

            foreach (Collider enemy in enemies)
            {
                enemy.gameObject.GetComponent<Enemy>().ChangeHealth(-damage);
            }
            Destroy(gameObject);
        }
    }
    
}

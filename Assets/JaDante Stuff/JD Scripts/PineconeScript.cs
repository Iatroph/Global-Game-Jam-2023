using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PineconeScript : MonoBehaviour
{
    public float damageRange;
    public LayerMask enemyLayer;
    public float damage, speed;
    public float aoeRadius;
    public Transform target;

    private void Start()
    {
    }
    private void Update()
    {
        //transform.Translate(Vector3.forward * speed * Time.deltaTime);

        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * 0.01f);
    }
    /*
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Collider[] enemies = Physics.OverlapSphere(transform.position, damageRange, enemyLayer);

            foreach (Collider enemy in enemies)
            {
                enemy.gameObject.GetComponent<Enemy>().ChangeHealth(-damage);
            }
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    */
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
    
}

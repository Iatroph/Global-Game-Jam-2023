using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedScript : MonoBehaviour
{
    public float damage, speed;
    public Transform target;

    private void Start()
    {

    }
    private void LateUpdate()
    {
        //transform.Translate(Vector3.forward * speed * Time.deltaTime);

        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * 0.01f);
    }
    /*
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<Enemy>().ChangeHealth(-damage);
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
        if(collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
    
}

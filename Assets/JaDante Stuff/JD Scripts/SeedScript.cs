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

    private void Update()
    {
        if(target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * 1.5f * Time.deltaTime);
        }

        if(target == null)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Enemy>().ChangeHealth(-damage);
            Destroy(gameObject);
        }

    }
    
}

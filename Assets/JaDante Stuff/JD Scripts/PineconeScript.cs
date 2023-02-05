using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PineconeScript : MonoBehaviour
{
    public float damage, speed;
    //public GameObject[] pineconeParts;

    private void Start()
    {
    }
    private void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<Enemy>().ChangeHealth(-damage);
            Destroy(gameObject);
        }
    }
    /*
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            
            Destroy(gameObject);
        }
    }
    */
}

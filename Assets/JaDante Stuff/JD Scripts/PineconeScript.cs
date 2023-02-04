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
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            //foreach(GameObject part in pineconeParts)
            //{
                
            //}
            //Instantiate()
            Destroy(gameObject);
        }
    }
}

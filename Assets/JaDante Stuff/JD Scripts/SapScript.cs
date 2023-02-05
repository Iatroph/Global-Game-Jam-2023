using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SapScript : MonoBehaviour
{
    public float damage, speed;
    public float duration, slowPercentage;
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
            other.gameObject.GetComponent<Enemy>().ChangeHealth(-damage);
            // Slow all enemies except flying. dont do effect on things that include hover
            //SendMessage("SlowEnemy");
            //Debug.Log("Slowing Effect!!!");
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

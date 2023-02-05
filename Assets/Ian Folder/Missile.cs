using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    private Rigidbody rb;

    public GameObject missileExplosion;

    public float speed = 5f;
    public float angleDeviationLimit = 4f;
    public float lifespan = 5f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = speed * transform.up;

        Destroy(gameObject, lifespan);
    }

    void FixedUpdate()
    {
        float xAngleMod = Random.Range(angleDeviationLimit * -1f, angleDeviationLimit);
        float yAngleMod = Random.Range(angleDeviationLimit * -1f, angleDeviationLimit);
        float zAngleMod = Random.Range(angleDeviationLimit * -1f, angleDeviationLimit);

        Vector3 newEulerAngles = new Vector3(xAngleMod, yAngleMod, zAngleMod) + new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, transform.localEulerAngles.z);
        rb.velocity = speed * transform.up;
        transform.eulerAngles = newEulerAngles;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.name.Contains("Turret"))
        {
            Instantiate(missileExplosion);
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : MonoBehaviour
{
    AudioSource aSource;

    public int energy;
    private bool isCollected = false;

    private void Start()
    {
        aSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player") && !isCollected)
        {
            isCollected = true;

            if(GameManager.Instance != null)
            {
                GameManager.Instance.AddCurrency(energy);
            }

            aSource.Play();
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            gameObject.GetComponent<BoxCollider>().enabled = false;

            Destroy(gameObject, 1f);
        }
    }
}

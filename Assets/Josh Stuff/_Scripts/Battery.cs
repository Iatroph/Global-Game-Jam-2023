using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : MonoBehaviour
{
    public int energy;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            if(GameManager.Instance != null)
            {
                GameManager.Instance.AddCurrency(energy);
            }
            Destroy(gameObject);
        }
    }
}

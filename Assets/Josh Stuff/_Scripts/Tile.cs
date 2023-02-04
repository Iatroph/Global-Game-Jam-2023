using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public bool canBuildOnTile = true;
    public bool wallPlaced = false;

    // Start is called before the first frame update
    void Start()
    {
        canBuildOnTile = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleWallPlaced(bool toggle)
    {
        wallPlaced= toggle;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Enemy"))
        {
            canBuildOnTile = false;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.transform.CompareTag("Enemy"))
        {
            canBuildOnTile = false;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.CompareTag("Enemy"))
        {
            canBuildOnTile = true;
        }
    }
}

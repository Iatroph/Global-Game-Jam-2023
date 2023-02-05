using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSpin : MonoBehaviour
{
    public enum Axis
    {
        X, Y, Z
    }

    public Axis axis;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(axis == Axis.X) 
        {
            transform.Rotate(20 * 5 * Time.deltaTime, 0, 0, 0); 
        }

        if (axis == Axis.Y)
        {
            transform.Rotate(0, 20 * 5 * Time.deltaTime, 0, 0);
        }

        if (axis == Axis.Z)
        {
            transform.Rotate(0, 0, 20 * 5 * Time.deltaTime, 0);
        }


    }
}

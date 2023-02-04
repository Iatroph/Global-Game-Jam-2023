using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallHologram : MonoBehaviour
{
    public Renderer[] matRenderers;
    public Material blueMat;
    public Material redMat;

    public void ToggleMeshRenderer(bool toggle)
    {
        foreach(Renderer r in matRenderers) 
        {
            r.enabled = toggle;
        }
    }

    public void BecomeRed()
    {
        foreach(Renderer r in matRenderers)
        {
            r.material = redMat;
        }
    }

    public void BecomeBlue()
    {
        foreach (Renderer r in matRenderers)
        {
            r.material = blueMat;
        }
    }


}

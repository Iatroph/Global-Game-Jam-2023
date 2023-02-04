using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TowerManager : MonoBehaviour
{
    // raycast to certain tiles to build walls/turrents
    [Header("Tower Prefab/Prices")]
    [SerializeField] public TowerStruct[] towers;

    public Camera playerCam;

    public float currentPoints;

    private int index = 0;
    private bool allowOutline, outlineDrawn = false, redrawOutline = false;
    GameObject towerOutline, currentWall;

    private void Start()
    {
        allowOutline = true;
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out RaycastHit hit, 8f))
            {
                if (hit.point != null)
                {
                    if (hit.transform.CompareTag("Wall"))
                    {
                        //Debug.Log(hit.transform.name);
                        //Debug.DrawLine(playerCam.transform.position, hit.point, Color.red, 2f);

                        GameObject tower = Instantiate(towers[index].tower, hit.transform);
                        tower.transform.DOMoveY(hit.transform.position.y + 2, 1);
                        //towers[0].towerTransparent.SetActive(false);
                        Destroy(towerOutline);
                        outlineDrawn = false;
                        allowOutline = false;
                        Invoke(nameof(ResetOutline), 0.2f);
                    }

                }
            }

           
        }

        if (Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out RaycastHit hit2, 8f) && allowOutline)
        {
            if (hit2.point != null && hit2.transform.childCount == 0)
            {
                if (hit2.transform.CompareTag("Wall") && !outlineDrawn)
                {
                    currentWall = hit2.transform.gameObject;
                    towerOutline = Instantiate(towers[index].towerTransparent);
                    towerOutline.transform.position = hit2.transform.position + new Vector3(0, 2, 0);
                    towerOutline.SetActive(true);
                    outlineDrawn = true;
                }
                else if(hit2.transform.gameObject != currentWall || redrawOutline)
                {
                    //towers[0].towerTransparent.SetActive(false);
                    Destroy(towerOutline);
                    outlineDrawn = false;
                    redrawOutline = false;
                }
            }
        }
        else
        {
            //towers[0].towerTransparent.SetActive(false);
            Destroy(towerOutline);
            outlineDrawn = false;
        }

        if(outlineDrawn)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                if(index == 0)
                {
                    index = towers.Length - 1;
                }
                else
                {
                    index--;
                }

                redrawOutline = true;
            }

            if(Input.GetKeyDown(KeyCode.E))
            {
                if(index == towers.Length - 1)
                {
                    index = 0;
                }
                else
                {
                    index++;
                }

                redrawOutline = true;
            }
        }
    }
    public void ResetOutline()
    {
        allowOutline = true;
    }
}

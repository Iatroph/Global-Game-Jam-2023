using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

// import, axis conversion, reset
public class TowerManager : MonoBehaviour
{
    // raycast to certain tiles to build walls/turrents
    [Header("Tower Prefab/Prices")]
    [SerializeField] public TowerStruct[] towers;
    public int towerCostLevel1, towerCostLevel2, towerCostLevel3;

    public Camera playerCam;

    public int currentPoints = 0;

    private int index = 0;
    private bool allowOutline, outlineDrawn = false, redrawOutline = false;
    GameObject towerOutline, currentWall, tower;
    float endVal = 0;

    private void Start()
    {
        allowOutline = true;
    }
    private void Update()
    {
        if(Input.GetKey(KeyCode.Mouse1))
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out RaycastHit hit, 8f))
                {
                    //Debug.Log("running");
                    if (hit.point != null)
                    {
                        if (hit.transform.CompareTag("Wall") && hit.transform.childCount == 2 && currentPoints > towerCostLevel1)
                        {
                            //Debug.Log(hit.transform.name);
                            //Debug.DrawLine(playerCam.transform.position, hit.point, Color.red, 2f);
                            //currentPoints -= towerCostLevel1;
                            if(GameManager.Instance != null)
                            {
                                GameManager.Instance.AddCurrency(-towerCostLevel1);
                            }
                            tower = Instantiate(towers[index].tower, hit.transform);
                            endVal = hit.transform.position.y + 2;
                            tower.transform.DOMoveY(endVal, 1);
                            tower.GetComponent<Turret>().turretLevel = 1;
                            //towers[0].towerTransparent.SetActive(false);
                            Destroy(towerOutline);
                            outlineDrawn = false;
                            allowOutline = false;
                            Invoke(nameof(ResetOutline), 0.2f);
                        }
                        else if (hit.transform.CompareTag("Wall") && hit.transform.childCount == 3 && hit.transform.GetChild(2).GetComponent<Turret>().turretLevel == 1 && currentPoints > towerCostLevel2)
                        {
                            //currentPoints -= towerCostLevel2;
                            if (GameManager.Instance != null)
                            {
                                GameManager.Instance.AddCurrency(-towerCostLevel2);
                            }
                            tower = hit.transform.GetChild(2).gameObject;
                            Destroy(tower);
                            tower = Instantiate(towers[hit.transform.GetChild(2).GetComponent<Turret>().turretIndex].tower2, hit.transform);
                            endVal = hit.transform.position.y + 2;
                            tower.transform.DOMoveY(endVal, 1);
                            tower.GetComponent<Turret>().turretLevel = 2;
                        }
                        else if(hit.transform.CompareTag("Wall") && hit.transform.childCount == 3 && hit.transform.GetChild(2).GetComponent<Turret>().turretLevel == 2 && currentPoints > towerCostLevel3)
                        {
                            //currentPoints -= towerCostLevel3;
                            if (GameManager.Instance != null)
                            {
                                GameManager.Instance.AddCurrency(-towerCostLevel3);
                            }
                            tower = hit.transform.GetChild(2).gameObject;
                            Destroy(tower);
                            tower = Instantiate(towers[hit.transform.GetChild(2).GetComponent<Turret>().turretIndex].tower3, hit.transform);
                            endVal = hit.transform.position.y + 2;
                            tower.transform.DOMoveY(endVal, 1);
                            tower.GetComponent<Turret>().turretLevel = 3;
                        }
                    }
                }


            }

            if (Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out RaycastHit hit2, 8f) && allowOutline)
            {
                if (hit2.point != null && hit2.transform.childCount == 2)
                {
                    if (hit2.transform.CompareTag("Wall") && !outlineDrawn)
                    {
                        currentWall = hit2.transform.gameObject;
                        towerOutline = Instantiate(towers[index].towerTransparent);
                        towerOutline.transform.position = hit2.transform.position + new Vector3(0, 2, 0);
                        towerOutline.SetActive(true);
                        outlineDrawn = true;
                    }
                    else if (hit2.transform.gameObject != currentWall || redrawOutline)
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

            if (outlineDrawn)
            {
                if (Input.GetKeyDown(KeyCode.Q) || Input.GetAxis("Mouse ScrollWheel") < 0)
                {
                    if (index == 0)
                    {
                        index = towers.Length - 1;
                    }
                    else
                    {
                        index--;
                    }

                    redrawOutline = true;
                }

                if (Input.GetKeyDown(KeyCode.E) || Input.GetAxis("Mouse ScrollWheel") > 0)
                {
                    if (index == towers.Length - 1)
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
        else
        {
            Destroy(towerOutline);
            redrawOutline = false;
            outlineDrawn = false;
        }

        //if (tower != null && tower.transform.position.y == endVal)
        //{
        //    tower.GetComponent<Turret>().enabled = true;
        //    tower = null;
        //    endVal = 0;
        //}
    }
    public void ResetOutline()
    {
        allowOutline = true;
    }
}

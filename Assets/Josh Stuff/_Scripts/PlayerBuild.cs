using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Diagnostics.Contracts;
using UnityEngine.AI;

public class PlayerBuild : MonoBehaviour
{
    public Camera playerCam;

    public GameObject wallObject;
    public GameObject wallOutlineObject;

    private WallHologram hologram;

    bool allowOutline;

    public bool canBuild;

    public bool pathWouldBeBlocked;

    [Header("Wall Parameters")]
    public float wallRiseSpeed = 0.8f;
    public float minWallHeight = 1.9f;
    public float maxWallHeight = 2.1f;

    private void Awake()
    {
       hologram = wallOutlineObject.GetComponent<WallHologram>();
    }
    // Start is called before the first frame update
    void Start()
    {
        allowOutline = true;
        canBuild = true;
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetMouseButton(1))
        {
            ShowWallOutline();
            if (Input.GetMouseButtonDown(0))
            {
                PlaceWall();
            }
        }
        else
        {
            hologram.ToggleMeshRenderer(false);
        }

    }

    public void PlaceWall()
    {
        if (Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out RaycastHit hit, 8f))
        {
            if (hit.point != null)
            {
                if (hit.transform.CompareTag("Ground Tile") && hit.transform.GetComponent<Tile>().canBuildOnTile)
                {
                    if (PathFindingManager.instance.noPathBlocked())
                    {
                        hit.transform.GetComponent<Tile>().ToggleWallPlaced(true);
                        GameObject wall = Instantiate(wallObject, hit.transform.position + new Vector3(0, -1.5f, 0), Quaternion.identity);
                        wall.transform.DOMoveY(hit.transform.position.y + Random.Range(minWallHeight, maxWallHeight), wallRiseSpeed);
                        hologram.ToggleMeshRenderer(false);
                        allowOutline = false;
                        Invoke(nameof(ResetOutline), 0.2f);
                    }

                }

            }
        }
    }

    public void ShowWallOutline()
    {
        if (Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out RaycastHit hit2, 8f)/* && allowOutline*/)
        {
            if (hit2.point != null)
            {
                if (hit2.transform.CompareTag("Ground Tile") && hit2.transform.GetComponent<Tile>().canBuildOnTile && !hit2.transform.GetComponent<Tile>().wallPlaced)
                {
                    if (PathFindingManager.instance.noPathBlocked())
                    {
                        wallOutlineObject.transform.position = hit2.transform.position + new Vector3(0, 1.5f, 0);
                        hologram.ToggleMeshRenderer(true);
                        hologram.BecomeBlue();
                    }
                    else
                    {
                        hologram.BecomeRed();
                        wallOutlineObject.transform.position = hit2.transform.position + new Vector3(0, 1.5f, 0);
                        hologram.ToggleMeshRenderer(true);

                    }
                }
            }

        }

    }
    public void ResetOutline()
    {
        allowOutline = true;
    }

}

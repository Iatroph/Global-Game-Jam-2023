using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerBuild : MonoBehaviour
{
    public Camera playerCam;

    public GameObject wallObject;
    public GameObject wallOutlineObject;

    bool allowOutline;

    private void Awake()
    {
       
    }
    // Start is called before the first frame update
    void Start()
    {
        allowOutline = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out RaycastHit hit, 8f))
            {
                if(hit.point != null)
                {
                    if(hit.transform.CompareTag("Ground Tile"))
                    {
                        Debug.Log(hit.transform.name);
                        Debug.DrawLine(playerCam.transform.position, hit.point, Color.red, 2f);

                        GameObject wall = Instantiate(wallObject, hit.transform.position + new Vector3(0, -2, 0), Quaternion.identity);
                        wall.transform.DOMoveY(hit.transform.position.y + 2, 1);
                        wallOutlineObject.SetActive(false);
                        allowOutline = false;
                        Invoke(nameof(ResetOutline), 0.2f);

                    }

                }
            }
        }

        if (Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out RaycastHit hit2, 8f) && allowOutline)
        {
            if (hit2.point != null)
            {
                if (hit2.transform.CompareTag("Ground Tile"))
                {
                    wallOutlineObject.transform.position = hit2.transform.position + new Vector3(0, 2, 0);
                    wallOutlineObject.SetActive(true);
                }

            }
        }
        else
        {
            wallOutlineObject.SetActive(false);
        }

    }

    public void ResetOutline()
    {
        allowOutline = true;
    }
}

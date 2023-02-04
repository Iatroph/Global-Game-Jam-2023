using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    // raycast to certain tiles to build walls/turrents
    [Header("Tower Prefab/Prices")]
    [SerializeField] public TowerStruct[] towers;

    [Header("Temporary Stuff")]
    public float currentPoints;
    public Transform towerSpawn;

    private GameObject towerTrans;
    private int index = 0;
    private bool towerPlaced = false;

    private void Start()
    {
        
    }
    private void Update()
    {
        if(!towerPlaced)
        {
            TowerOutline();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if(index - 1 < 0)
            {
                index = towers.Length - 1;
            }
            else
            {
                index--;
                Debug.Log(index);
            }

            towerPlaced = false;
        }

        if(Input.GetKeyDown(KeyCode.E))
        {
            if (index + 1 == towers.Length)
            {
                index = 0;
            }
            else
            {
                index++;
                Debug.Log(index);
            }

            towerPlaced = false;
        }

        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            BuildTowers();
        }
    }
    private void TowerOutline()
    {
        Destroy(towerTrans);

        towerTrans = Instantiate(towers[index].towerTransparent, towerSpawn);

        towerPlaced = true;
    }
    public void BuildTowers()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0) && currentPoints > towers[index].towerCost)
        {
            Destroy(towerTrans);
            Instantiate(towers[index].tower, towerSpawn);
            currentPoints -= towers[index].towerCost;
        }

        //towerPlaced = false;
    }
}

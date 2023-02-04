using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PathFindingManager : MonoBehaviour
{
    public static PathFindingManager instance;

    public DummyEnemy[] dummies;
    public PlayerBuild playerBuild;
    bool pathBlocked;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        pathBlocked = false;
    }

    public bool noPathBlocked()
    {
        bool[] unblocked = new bool[dummies.Length];

        for(int i = 0; i < dummies.Length;i++) 
        {
            if (dummies[i].canReachTree)
            {
                unblocked[i] = true;
            }
            else
            {
                continue;
            }
        }

        return unblocked.All(x => x);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(noPathBlocked());

        //if(noPathBlocked())
        //{
        //    playerBuild.canBuild = true;
        //    Debug.Log("CAN BUILD");
        //}
        //else if (!noPathBlocked())
        //{
        //    playerBuild.canBuild = false;
        //    Debug.Log("CANNOT BUILD");


        //}

        //foreach (DummyEnemy enemy in dummies)
        //{
        //    if (!enemy.canReachTree)
        //    {
        //        pathBlocked = true;
        //        break;
        //    }
        //    else
        //    {
        //        pathBlocked = false;

        //    }
        //}

        //if (pathBlocked == true)
        //{
        //    playerBuild.pathWouldBeBlocked = true;
        //}
        //else
        //{
        //    playerBuild.pathWouldBeBlocked = false;
        //}
    }
}

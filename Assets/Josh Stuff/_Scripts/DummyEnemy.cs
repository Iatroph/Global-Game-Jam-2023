using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DummyEnemy : MonoBehaviour
{
    NavMeshAgent navAgent;
    public Transform treePosition;
    public bool canReachTree;
    private void Awake()
    {
        navAgent = GetComponent<NavMeshAgent>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        NavMeshPath path = new NavMeshPath();
        navAgent.CalculatePath(treePosition.position, path);
        if(path.status == NavMeshPathStatus.PathComplete)
        {
            canReachTree = true;
        }
        else
        {
            canReachTree = false;
        }

        //Debug.Log(canReachTree);
    }
}

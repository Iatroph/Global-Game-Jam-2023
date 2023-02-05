using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;

[System.Serializable]
public class Wave
{
    public Group[] groups;
    public float groupInterval;
}

[System.Serializable]
public class Group
{
    public GameObject enemy;
    public int count;
    public int door;
    public float rate;
}
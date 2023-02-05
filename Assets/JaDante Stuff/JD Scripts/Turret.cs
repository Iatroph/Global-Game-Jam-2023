using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public abstract class Turret : MonoBehaviour
{
    public float damageLevel1, speedLevel1;
    public float damageLevel2, speedLevel2;
    public float damageLevel3, speedLevel3;
    public float turretLevel;
    public int turretIndex;

    private Tree tree;
    public float multiplier;
    //public TextMeshPro turretText;

    protected virtual void Start()
    {
        tree = GameObject.Find("THE LAST TREE").GetComponent<Tree>();
    }

    protected virtual void Update()
    {
        multiplier = tree.plantMultiplier;
    }
}

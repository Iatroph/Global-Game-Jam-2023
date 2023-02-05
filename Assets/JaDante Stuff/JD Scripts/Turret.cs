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

    protected AudioSource aSource;
    public AudioClip[] shootClips;

    private Tree tree;
    public float multiplier;
    //public TextMeshPro turretText;

    protected virtual void Start()
    {
        tree = GameObject.Find("THE LAST TREE").GetComponent<Tree>();
        aSource = GetComponent<AudioSource>();
    }

    protected virtual void Update()
    {
        multiplier = tree.plantMultiplier;
    }

    protected virtual Collider FindLowest(Collider[] inRange)
    {
        Collider lowest = inRange[0];
        float leastHealth = inRange[0].GetComponent<Enemy>().GetCurrentHealth();

        foreach (Collider collider in inRange)
        {
            float temp = Vector3.Distance(collider.gameObject.transform.position, gameObject.transform.position);
            if (temp < leastHealth)
            {
                temp = leastHealth;
                lowest = collider;
            }
        }

        return lowest;
    }
}

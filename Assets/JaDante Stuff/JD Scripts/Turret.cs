using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public abstract class Turret : MonoBehaviour
{
    public float damageLevel1, speedLevel1;
    public float damageLevel2, speedLevel2;
    public float turretLevel;
    public TextMeshPro turretText;
}
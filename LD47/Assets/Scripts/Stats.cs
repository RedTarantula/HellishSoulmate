using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Stats",fileName ="Stats")]
public class Stats : ScriptableObject
{
    public float soul;
    public float soulMult;
    [Range(-100f,100f)]
    public float calmToImpulsive;
    [Range(-100f, 100f)]
    public float shyToConfindent;
    [Range(-100f, 100f)]
    public float wildToCivilized;
    [Range(-100f, 100f)]
    public float reservedToExhibitionist;
}

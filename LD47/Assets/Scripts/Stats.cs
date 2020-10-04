using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Stats",fileName ="Stats")]
public class Stats : ScriptableObject
{
    public float soul;
    public float soulMult;
    [Range(-100f, 100f)]
    public float[] bars;

    public float[] statsMult;

    [Header("upgrades")]
    public bool IdleUpgrade;
    public float IdleSoul;

    [Header("DateTimes")]
    public int Tarrin;
        public int akathiz;
        public int zaros;
        public int azza;
}

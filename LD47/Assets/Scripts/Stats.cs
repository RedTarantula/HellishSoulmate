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
    public bool IdleUpgrade; // zaros
    public float IdleSoul;
    public bool soulsPerClickUpgrade; //Azza
    public float soulsPerClickValue;
    public bool scoreMinigameUpgrade; //Terrin
    public float scoreMinigameValue;
    public bool attributeUpgrade; //Akathiz
    public float attributeValue;
    public int resetTimes;

    [Header("Money")]
    public int tickets;

    [Header("DateTimes")]
    public int[] DateTimes;

    [Header("Presentes")] 
    public int isqueiro;
    public int florMurcha;
    public int lingerie;
    public int ursinho;
    public int drink;
}






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

    public void ResetValues()
    {
        soul = 0;
        soulMult = 1;

        bars = new float[4];
        for (int i = 0 ; i < bars.Length ; i++)
        {
            bars[i] = 0;
        }
        statsMult = new float[4];
        for (int i = 0 ; i < statsMult.Length ; i++)
        {
            statsMult[i] = 1;
        }

        IdleUpgrade = false;
        IdleSoul = 0;
        soulsPerClickUpgrade = true;
        soulsPerClickValue = 1;
        scoreMinigameUpgrade = false;
        scoreMinigameValue = 10;
        attributeUpgrade = true;
        attributeValue = 5;
        resetTimes = 0;

        tickets = 0;

        DateTimes = new int[4];
        for (int i = 0 ; i < DateTimes.Length ; i++)
        {
            DateTimes[i] = 0;
        }

        isqueiro = 0;
        florMurcha = 0;
        lingerie = 0;
        ursinho = 0;
        drink = 0;

    }

}






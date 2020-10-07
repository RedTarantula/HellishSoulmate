using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HellishSoulmateManager : MonoBehaviour
{
    public Stats stats;
    public bool clearStatsOnStart = true;

    private void Start()
    {
        if(clearStatsOnStart)
        {
            stats.ResetValues();
        }

    }

}

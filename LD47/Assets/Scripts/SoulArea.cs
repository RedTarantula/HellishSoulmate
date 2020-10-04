using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulArea : Interacting
{
    public Stats stats;
    public TMPro.TextMeshProUGUI souls;
    public ParticleSystem ps;

    // Start is called before the first frame update
    void Start()
    {
        souls.text = "Souls: " + ((int)stats.soul).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        SoulsPerSecond();
    }


    public void Click()
    {
        stats.soul += 1 * stats.soulMult;
        ChangeUI();
        ps.Emit(1);
    }

    public void ChangeUI()
    {
        souls.text = "Souls: " + ((int)stats.soul).ToString();
    }

    void SoulsPerSecond()
    {
        if (stats.IdleUpgrade)
        {
            stats.soul += stats.IdleSoul * Time.deltaTime;
            ChangeUI();
        }
    }

}

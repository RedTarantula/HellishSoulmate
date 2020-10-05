using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ConfigsSpace;

public class SoulArea : Interacting
{
    public Stats stats;
    public TMPro.TextMeshProUGUI souls;
    public ParticleSystem ps;

    // Start is called before the first frame update
    void Start()
    {
        souls.text =  ((int)stats.soul).ToString();

        if(stats.DateTimes[(int)Demons.zaros] > 0)
        {
            stats.IdleUpgrade = true;
            stats.IdleSoul *= stats.DateTimes[(int)Demons.zaros];
        }

        if(stats.DateTimes[(int)Demons.azza] > 0)
        {
            stats.soulsPerClickUpgrade = true;
            stats.soulsPerClickValue *= stats.DateTimes[(int)Demons.azza];
        }

        if(stats.DateTimes[(int)Demons.tarrin] > 0)
        {
            stats.scoreMinigameUpgrade = true;
            stats.scoreMinigameValue *= stats.DateTimes[(int)Demons.tarrin];
        }

         if(stats.DateTimes[(int)Demons.akathiz] > 0)
        {
            stats.attributeUpgrade = true;
            stats.attributeValue *= stats.DateTimes[(int)Demons.akathiz];
        }

    }

    // Update is called once per frame
    void Update()
    {
        SoulsPerSecond();
    }

// 40% Zaros (por ser impulsivo) idle
// 30% Azza (por ser mais fofim) mais almas por clique
// 20% Terrin (por ser calmo/paciente) mais score no minigame
// 10% Akathiz (por se fazer de difícil) mais atributo nos locais
//idle, mais almas por clique, mais score no minigame, mais atributo nos locais
    public void Click()
    {
        if(stats.soulsPerClickUpgrade)
        {
            stats.soul +=stats.soulsPerClickValue;
        }
        stats.soul += 1 * stats.soulMult * (stats.resetTimes*stats.resetTimes);
        ChangeUI();
        ps.Emit(1);
    }

    public void ChangeUI()
    {
        souls.text = ((int)stats.soul).ToString();
    }

    void SoulsPerSecond()
    {
        if (stats.IdleUpgrade)
        {
            stats.soul += stats.IdleSoul * Time.deltaTime * (stats.resetTimes*stats.resetTimes);
            ChangeUI();
        }
    }

}

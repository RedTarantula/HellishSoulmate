using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ConfigsSpace;
public class StatsArea : Interacting
{
    [Header("MainStats")]
    public Image mainStatusImage;
    public Bars mainBar;
    public float mainValue;

    [Header("SubStats")]
    public Image subStatusImage;
    public Bars subBar;
    public float subValue;


    [Header("Configs")]
    public float multplier;

    public Stats stats;

    private Vector3 aux;

    private void Start()
    {
        aux = mainStatusImage.rectTransform.localScale;

        aux.x = stats.bars[(int)mainBar] / 100f;

        mainStatusImage.rectTransform.localScale = aux;

        aux.x = stats.bars[(int)subBar] / 100f;

        subStatusImage.rectTransform.localScale = aux;
    }

    public void Click()
    {
        stats.bars[(int)mainBar] += mainValue * multplier;
        stats.bars[(int)subBar] += subValue * multplier;

        if (stats.bars[(int)mainBar] > 100)
        {
            stats.bars[(int)mainBar] = 100;
        }
        else if(stats.bars[(int)mainBar] < -100)
        {
            stats.bars[(int)mainBar] = -100;
        }

        if (stats.bars[(int)subBar] > 100)
        {
            stats.bars[(int)subBar] = 100;
        }
        else if (stats.bars[(int)subBar] < -100)
        {
            stats.bars[(int)subBar] = -100;
        }

        aux = mainStatusImage.rectTransform.localScale;

        aux.x = stats.bars[(int)mainBar] / 100f;

        mainStatusImage.rectTransform.localScale = aux;

        aux.x = stats.bars[(int)subBar] / 100f;

        subStatusImage.rectTransform.localScale = aux;
    }

   
}

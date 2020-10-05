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

    [Header("Price")]
    public float price;
    public float upgradePrice;

    [Header("Configs")]
    public Multpliers multplier;
    public TMPro.TextMeshProUGUI soulsText;
    public float priceUpgradeMultiplier;
    public float efectUpgradeMultiplier;

    public Stats stats;

    private Vector3 aux;
    private bool owned;

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
        if(owned)
        {
            ChangeStat();
        }
        else
        {
            if(stats.soul > price)
            {
                stats.soul -= price;
                owned = true;
                ChangeSouls();
            }
        }
    }

    void ChangeStat()
    {
        if(stats.attributeUpgrade)
        {
            stats.bars[(int)mainBar] += stats.attributeValue/50f;
        
        }
        stats.bars[(int)mainBar] += (mainValue) * stats.statsMult[(int)multplier] * (stats.resetTimes*stats.resetTimes);
        stats.bars[(int)subBar] += (subValue) * stats.statsMult[(int)multplier] * (stats.resetTimes*stats.resetTimes);

        if (stats.bars[(int)mainBar] > 100)
        {
            stats.bars[(int)mainBar] = 100;
        }
        else if (stats.bars[(int)mainBar] < -100)
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

        ChangeUI();
    }

    void ChangeUI()
    {
        aux = mainStatusImage.rectTransform.localScale;

        aux.x = stats.bars[(int)mainBar] / 100f;

        mainStatusImage.rectTransform.localScale = aux;

        aux.x = stats.bars[(int)subBar] / 100f;

        subStatusImage.rectTransform.localScale = aux;
    }

    void ChangeSouls()
    {
        soulsText.text =  ((int)stats.soul).ToString();
    }

    public void Upgrade()
    {
        if(stats.soul > upgradePrice)
        {
            stats.soul -= upgradePrice;
            stats.statsMult[(int)multplier] *= efectUpgradeMultiplier;

            upgradePrice *= priceUpgradeMultiplier;

            ChangeSouls();
        }
    }

  

}

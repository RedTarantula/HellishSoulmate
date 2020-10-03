using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoulArea : Interacting
{
    public Stats stats;
    public TMPro.TextMeshProUGUI souls;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
    }


    public void Click()
    {
        stats.soul += 1 * stats.soulMult;
        ChangeUI();
    }

    public void ChangeUI()
    {
        souls.text = "Souls: " + ((int)stats.soul).ToString();
    }

}

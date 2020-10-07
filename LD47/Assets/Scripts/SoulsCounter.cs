using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulsCounter : MonoBehaviour
{
    public Stats stats;
    public TMPro.TextMeshProUGUI souls;

    private void OnEnable()
    {
        UpdateText();
    }

    public void UpdateText()
    {
        souls.text = ((int)stats.soul).ToString();
    }
}

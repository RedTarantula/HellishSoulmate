using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameCollectObject_Point : MiniGameCollectObject
{
    
    [Header("Point")]
    [SerializeField]
    private int _score = 1;

    public override void OnCollect()
    {
        MiniGameController.Instance.AddScore(_score);
    }

}

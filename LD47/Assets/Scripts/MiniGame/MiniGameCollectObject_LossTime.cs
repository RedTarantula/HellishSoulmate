using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameCollectObject_LossTime : MiniGameCollectObject
{
    
    [Header("Time loss")]
    [SerializeField]
    private float _timeLoss = 1f;

    public override void OnCollect()
    {
        MiniGameController.Instance.RemoveTime(_timeLoss);
    }

}

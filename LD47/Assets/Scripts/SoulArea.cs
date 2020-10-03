using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulArea : Interacting
{
    public Stats stats;

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
    }


}

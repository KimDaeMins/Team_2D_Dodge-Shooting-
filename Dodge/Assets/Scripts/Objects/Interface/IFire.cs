using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFire
{
    public float FireDelay { get; set; }
    public float FireCoolTime { get; set; }

    public void FireUpdate()
    {
        if(FireCoolTime > FireDelay)
            FireDelay += Time.deltaTime;
    }
    public bool FireCheck()
    {
        if (FireDelay > FireCoolTime)
            return true;
        return false;
    }

    public void Fire();
}

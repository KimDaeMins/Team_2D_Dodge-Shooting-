using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFire
{
    public float FireCoolTime { get; set; }
    public bool IsFireAble { get; set; }

    public IEnumerator FireUpdate(float coolTime);

    public void Fire();
}

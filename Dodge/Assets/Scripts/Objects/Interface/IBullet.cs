using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBullet
{
    public float Damage { get; set; }
    public GameObject Target { get; set; }
    public float LifeTime { get; set; }


    public void Move();

    public bool DeadCheck();
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBullet
{
    public float Damage { get; set; }
    public GameObject Target { get; set; }
    public float LifeTime { get; set; }


    public void Move();

    public bool DeadCheck()
    {
        LifeTime -= Time.deltaTime;
        if (LifeTime < 0)
            return true;

        //여기서 지정한 화면 밖을 나가면 죽는거도 짜야함

        return false;
    }
}

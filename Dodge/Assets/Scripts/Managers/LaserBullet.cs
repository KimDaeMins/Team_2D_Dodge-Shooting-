using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raiser : Object_Base, IBullet
{
    int IBullet.Damage { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    GameObject IBullet.Target { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    float IBullet.LifeTime { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    bool IBullet.DeadCheck()
    {
        throw new System.NotImplementedException();
    }

    void IBullet.Move()
    {
        throw new System.NotImplementedException();
    }
}

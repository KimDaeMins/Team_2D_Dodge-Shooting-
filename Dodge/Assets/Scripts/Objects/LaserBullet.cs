using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBullet : Object_Base, IBullet
{

    private int _damage = 7;
    public int Damage
    {
        get => _damage;
        set => _damage = value;
    }

    private float _lifeTime = 10.0f;
    public float LifeTime
    {
        get => _lifeTime;
        set => _lifeTime = value;
    }

    private GameObject _target;
    public GameObject Target
    {
        get => _target;
        set => _target = value;
    }

    private void Awake()
    {
        _target = Managers.Object.GetPlayer();
        Move();
    }

    public void Move()
    {
        
    }

    public bool DeadCheck()
    {
        return false;
    }
}
